Imports System.Data.SQLite
Imports System.Text
Public Class ProductClass
    Friend Property ProductName As String
    Friend Property ProductPrice As String
    Friend Property ProductCost As String
    Friend Property Category As String
    Friend Property ProductId As String


    Public Function Getproductlist(pCategory As String) As DataTable
        Dim dset As New DataTable
        Try
            Using koneksyon As New SQLiteConnection(POSClass.ConnectionString)
                koneksyon.Open()

                Dim sbld As New StringBuilder
                sbld.AppendLine("SELECT Id, ProductName, ProductPrice ")
                sbld.AppendLine("FROM Product")
                sbld.AppendLine("WHERE Category = @Category")
                Dim komand As New SQLiteCommand(sbld.ToString, koneksyon)
                komand.Parameters.AddWithValue("@Category", pCategory)
                Dim dadapter As New SQLiteDataAdapter(komand)
                dadapter.Fill(dset)
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return dset
    End Function
    Friend Function GetProductsFile(ByVal pProductId As String) As Boolean
        Dim bReturn As Boolean = False
        Try
            Using con As New SQLiteConnection(POSClass.ConnectionString)
                con.Open()
                Dim xSQL1 As New StringBuilder
                xSQL1.AppendLine("SELECT * FROM Product")
                xSQL1.AppendLine("WHERE Id = @Id")

                Using cmd1 As New SQLiteCommand(xSQL1.ToString, con)
                    cmd1.Parameters.Add(New SQLiteParameter("@Id", pProductId))
                    Using dr1 As SQLiteDataReader = cmd1.ExecuteReader
                        If dr1.HasRows Then
                            dr1.Read()
                            If Not IsDBNull(dr1("Id")) Then Me.ProductId = dr1("Id").ToString
                            If Not IsDBNull(dr1("ProductName")) Then Me.ProductName = dr1("ProductName").ToString
                            If Not IsDBNull(dr1("ProductPrice")) Then Me.ProductPrice = dr1("ProductPrice").ToString
                            If Not IsDBNull(dr1("ProductCost")) Then Me.ProductCost = dr1("ProductCost").ToString
                            If Not IsDBNull(dr1("Category")) Then Me.Category = dr1("Category").ToString
                            bReturn = True
                        End If
                    End Using
                End Using

            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return bReturn
    End Function
End Class
