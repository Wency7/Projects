Imports System.Data.SQLite
Public Class LoginClass
    Public Property Username As String
    Public Property Password As String
    Public Property Active As Integer
    Public Property CashierName As String
    Public Property CashierId As String


    Public Function LogInUser(Username As String, Password As String) As Boolean
        Dim bolreturn As Boolean = True
        Try
            Dim connects As New SQLiteConnection
            connects.ConnectionString = POSClass.ConnectionString
            connects.Open()
            Dim sql As String = "SELECT * FROM LoginUser WHERE Username ='" & Username & "'"
            Dim cmd As New SQLiteCommand(sql, connects)
            cmd.Connection = connects
            cmd.CommandType = CommandType.Text
            Using dr As SQLiteDataReader = cmd.ExecuteReader
                If dr.HasRows Then
                    While dr.Read
                        If dr("Active") = 1 Then
                            If Password = dr("Password") Then
                                Username = dr("UserName")
                                CashierName = dr("CashierName")
                                CashierId = dr("Id")
                                bolreturn = True
                            Else
                                Throw New Exception("Invalid Pssword")
                            End If
                        Else
                            Throw New Exception("User is not Active")
                        End If
                        Exit While
                    End While
                Else
                    Throw New Exception("User not Found")
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return bolreturn
    End Function
End Class
