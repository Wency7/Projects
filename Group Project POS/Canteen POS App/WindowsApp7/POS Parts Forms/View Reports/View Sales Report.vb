Public Class ViewTransactions
    Private Sub ViewTransactions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Getlist()
    End Sub
    Public Sub Getlist()
        Try
            Dim clss As New SalesClass
            Dim dt As New DataTable
            dt = clss.ViewTransactionH
            DataGridView1.DataSource = dt
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        Try
            If e.ColumnIndex = 5 Then
                Dim nID As String = DataGridView1.SelectedRows(0).Cells("TransactionID").Value.ToString
                Dim det As New TransactionDetails(nID)
                det.ShowDialog()
            End If
        Catch ex As Exception

        End Try

    End Sub
End Class