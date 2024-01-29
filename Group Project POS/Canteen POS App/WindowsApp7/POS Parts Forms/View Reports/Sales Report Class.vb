Imports System.Data.SQLite
Imports System.Text
Public Class SalesClass
    Friend Property CashierName As String
    Friend Property TransactionId As String
    Public Function SaveTransactionH(tend As String, ta As String, pGridData As DataTable)
        Dim bReturn As Boolean = False
        Try
            POSClass.TransactionDateTime = MyConversionTool.DateToYMDHMSDash(DateAndTime.Now)

            Using connect As New SQLiteConnection
                connect.ConnectionString = POSClass.ConnectionString
                connect.Open()


                Dim sqlID As String = "SELECT MAX(TransactionID) FROM TransactionHeader LIMIT 1"
                Dim cmdID As New SQLiteCommand(sqlID, connect)
                Dim nID As Integer = cmdID.ExecuteScalar()
                nID += 1

                Dim sSQL As New StringBuilder

                sSQL.AppendLine("INSERT INTO TransactionHeader ")
                sSQL.AppendLine("(")
                sSQL.AppendLine("TransactionID,")
                sSQL.AppendLine("TransactionDateTime,")
                sSQL.AppendLine("TotalAmountPrice,")
                sSQL.AppendLine("TenderedAmount,")
                sSQL.AppendLine("CashierName")
                sSQL.AppendLine(")")
                sSQL.AppendLine("Values")
                sSQL.AppendLine("(")
                sSQL.AppendLine("@TransactionID,")
                sSQL.AppendLine("@TransactionDateTime,")
                sSQL.AppendLine("@TotalAmountPrice,")
                sSQL.AppendLine("@TenderedAmount,")
                sSQL.AppendLine("@CashierName")
                sSQL.AppendLine(")")

                Using cm As New SQLiteCommand(sSQL.ToString, connect)
                    cm.CommandType = CommandType.Text

                    cm.Parameters.AddWithValue("@TransactionID", nID)
                    cm.Parameters.AddWithValue("@TransactionDateTime", POSClass.TransactionDateTime)
                    cm.Parameters.AddWithValue("@TotalAmountPrice", ta)
                    cm.Parameters.AddWithValue("@TenderedAmount", tend)
                    cm.Parameters.AddWithValue("@CashierName", POSClass.CashierName)


                    Dim n As Integer = cm.ExecuteNonQuery
                    If n <> 0 Then
                        bReturn = True
                    Else
                        Throw New Exception("Failed")
                    End If

                    Dim sSQL1 As New StringBuilder

                    sSQL1.AppendLine("INSERT INTO TransactionDetails")
                    sSQL1.AppendLine("(TransactionID, ")

                    sSQL1.AppendLine("ProductId,")
                    sSQL1.AppendLine("ProductName,")
                    sSQL1.AppendLine("EachPrice,")
                    sSQL1.AppendLine("ProductCost,")

                    sSQL1.AppendLine("Quantity,")
                    sSQL1.AppendLine("TotalPrice")

                    sSQL1.AppendLine(")")
                    sSQL1.AppendLine("Values")
                    sSQL1.AppendLine("(@TransactionID, ")

                    sSQL1.AppendLine("@ProductId,")
                    sSQL1.AppendLine("@ProductName,")
                    sSQL1.AppendLine("@EachPrice,")
                    sSQL1.AppendLine("@ProductCost,")
                    sSQL1.AppendLine("@Quantity,")
                    sSQL1.AppendLine("@TotalPrice")
                    sSQL1.AppendLine(")")

                    Using CMD As New SQLiteCommand(sSQL1.ToString, connect)
                        CMD.CommandType = CommandType.Text
                        CMD.Parameters.Add(New SQLiteParameter("@TransactionID"))
                        CMD.Parameters.Add(New SQLiteParameter("@ProductId"))
                        CMD.Parameters.Add(New SQLiteParameter("@ProductName"))
                        CMD.Parameters.Add(New SQLiteParameter("@EachPrice"))
                        CMD.Parameters.Add(New SQLiteParameter("@ProductCost"))
                        CMD.Parameters.Add(New SQLiteParameter("@Quantity"))
                        CMD.Parameters.Add(New SQLiteParameter("@TotalPrice"))
                        CMD.Prepare()
                        For Each item As DataRow In pGridData.Rows
                            CMD.Parameters("@TransactionID").Value = nID
                            CMD.Parameters("@ProductId").Value = item("Id")
                            CMD.Parameters("@ProductName").Value = item("ProductName")
                            CMD.Parameters("@EachPrice").Value = item("ProductPrice")
                            CMD.Parameters("@ProductCost").Value = item("ProductCost")
                            CMD.Parameters("@Quantity").Value = item("Quantity")
                            CMD.Parameters("@TotalPrice").Value = item("Total")

                            Dim S As Integer = CMD.ExecuteNonQuery
                            If S <> 0 Then
                                bReturn = True
                            Else
                                Throw New Exception("Failed")
                            End If
                        Next



                    End Using

                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return bReturn

    End Function
    Public Function ViewTransactionH() As DataTable
        Dim DT As New DataTable
        Try
            Using connects As New SQLiteConnection
                connects.ConnectionString = POSClass.ConnectionString
                connects.Open()
                Dim ssql As String = "SELECT TransactionID,TransactionDateTime,TotalAmountPrice,TenderedAmount,CashierName, 'View Details' as View FROM TransactionHeader"
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

    Public Function ViewTransactionD(nCashier As String) As DataTable
        Dim DT As New DataTable
        Try
            Using connects As New SQLiteConnection
                connects.ConnectionString = POSClass.ConnectionString
                connects.Open()
                Dim ssql As New StringBuilder
                ssql.AppendLine("Select ProductName, ")
                ssql.AppendLine("ProductId, ")
                ssql.AppendLine("Quantity, ")
                ssql.AppendLine("EachPrice, ")
                ssql.AppendLine("ProductCost, ")
                ssql.AppendLine("TotalPrice")
                ssql.AppendLine("FROM TransactionDetails")
                ssql.AppendLine(" WHERE TransactionID = @TransactionID")
                Dim cm As New SQLiteCommand(ssql.ToString, connects)
                cm.CommandType = CommandType.Text
                cm.Parameters.AddWithValue("@TransactionID", nCashier)
                Dim DatAdpt As New SQLiteDataAdapter(cm)
                Dim ds As New DataSet
                DatAdpt.Fill(DT)
            End Using
        Catch ex As Exception

        End Try

        Return DT
    End Function
End Class
