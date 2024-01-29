Imports System.Data.SQLite
Imports System.Text
Public Class ManagementClass
    Friend Property CashierName As String

    Friend Property LogoutTime As String

    Public Function SaveLogin()
        Dim bReturn As Boolean = False
        Try

            POSClass.CashierName = Me.CashierName
            POSClass.Logindate = MyConversionTool.DateToYMDDash(DateAndTime.Now)
            POSClass.LoginTime = MyConversionTool.TimeHHmmSS(DateAndTime.Now)

            Using connect As New SQLiteConnection
                connect.ConnectionString = POSClass.ConnectionString
                connect.Open()
                Dim sSQL As New StringBuilder

                sSQL.AppendLine("INSERT INTO[ManagementReports]")
                sSQL.AppendLine("(")

                sSQL.AppendLine("CashierName,")
                sSQL.AppendLine("Date,")
                sSQL.AppendLine("LoginTime")

                sSQL.AppendLine(")")
                sSQL.AppendLine("Values")
                sSQL.AppendLine("(")

                sSQL.AppendLine("@CashierName,")
                sSQL.AppendLine("@Date,")
                sSQL.AppendLine("@LoginTime")
                sSQL.AppendLine(")")

                Using cm As New SQLiteCommand(sSQL.ToString, connect)
                    cm.CommandType = CommandType.Text
                    cm.Parameters.AddWithValue("@CashierName", Me.CashierName)
                    cm.Parameters.AddWithValue("@Date", POSClass.Logindate)
                    cm.Parameters.AddWithValue("@LoginTime", POSClass.LoginTime)
                    Dim n As Integer = cm.ExecuteNonQuery
                    If n <> 0 Then
                        bReturn = True
                    Else
                        Throw New Exception("Failed")
                    End If

                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return bReturn

    End Function
    Public Sub SaveLogout()
        Dim bret As Boolean = False
        Try
            Using connct As New SQLiteConnection
                connct.ConnectionString = POSClass.ConnectionString
                connct.Open()

                Dim blder As New StringBuilder
                blder.AppendLine("UPDATE ManagementReports ")
                blder.AppendLine("SET ")
                blder.AppendLine("LogoutTime = @LogoutTime ")
                blder.AppendLine("WHERE CashierName = @CashierName ")
                blder.AppendLine("AND Date = @Date ")
                blder.AppendLine("AND LoginTime = @LoginTime ")

                Dim komand As New SQLiteCommand(blder.ToString, connct)
                komand.CommandType = CommandType.Text

                komand.Parameters.AddWithValue("@LogoutTime", MyConversionTool.TimeHHmmSS(DateAndTime.Now))
                komand.Parameters.AddWithValue("@CashierName", POSClass.CashierName)
                komand.Parameters.AddWithValue("@Date", POSClass.Logindate)
                komand.Parameters.AddWithValue("@LoginTime", POSClass.LoginTime)

                Dim n As Integer = komand.ExecuteNonQuery
                If n <> 0 Then
                    bret = True
                Else
                    Throw New Exception("Failed")
                End If
            End Using

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function ViewAllCashierName(nCashier As String) As DataTable
        Dim DT As New DataTable
        Try
            Using connects As New SQLiteConnection
                connects.ConnectionString = POSClass.ConnectionString
                connects.Open()
                Dim ssql As String = "SELECT distinct CashierName FROM ManagementReports order by CashierName"
                Dim cm As New SQLiteCommand(ssql, connects)
                cm.CommandType = CommandType.Text
                Dim DatAdpt As New SQLiteDataAdapter(cm)
                Dim ds As New DataSet
                DatAdpt.Fill(DT)
            End Using
        Catch ex As Exception

        End Try

        Return DT
    End Function
    Public Function ViewAllManagementRecords(nCashier As String, Optional showall As Boolean = False) As DataTable
        Dim DT As New DataTable
        Try
            Using connects As New SQLiteConnection
                connects.ConnectionString = POSClass.ConnectionString
                connects.Open()
                Dim ssql As String
                If Not showall Then
                    ssql = "SELECT CashierName,Date,LoginTime,LogoutTime FROM ManagementReports WHERE CashierName = @CashierName"
                Else
                    ssql = "SELECT CashierName,Date,LoginTime,LogoutTime FROM ManagementReports"
                End If

                Dim cm As New SQLiteCommand(ssql, connects)

                If Not showall Then
                    cm.Parameters.AddWithValue("@CashierName", nCashier)
                End If

                cm.CommandType = CommandType.Text
                Dim DatAdpt As New SQLiteDataAdapter(cm)
                Dim ds As New DataSet
                DatAdpt.Fill(DT)


            End Using
        Catch ex As Exception

        End Try

        Return DT
    End Function
End Class
