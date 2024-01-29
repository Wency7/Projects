Public Class ManagementReport
    Private Sub cbxcashiers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxcashiers.SelectedIndexChanged

        Getlist()

    End Sub

    Private Sub ManagementReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim clss As New ManagementClass
            Dim dt As New DataTable
            dt = clss.ViewAllCashierName("")
            cbxcashiers.DataSource = dt
        Catch ex As Exception

        End Try
    End Sub


    Public Sub Getlist()
        Try
            Dim clss As New ManagementClass
            Dim dt As New DataTable
            dt = clss.ViewAllManagementRecords(cbxcashiers.Text, CheckBox1.Checked)
            DataGridView1.DataSource = dt
        Catch ex As Exception

        End Try

    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Getlist()
    End Sub

End Class