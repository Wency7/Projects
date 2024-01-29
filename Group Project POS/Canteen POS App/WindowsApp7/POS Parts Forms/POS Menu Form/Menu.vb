Public Class Menu
    Private Sub Btnlogin_Click(sender As Object, e As EventArgs) Handles btnpos.Click
        Dim pos As New CanteenPOS
        Me.Hide()
        pos.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnsalesrep.Click
        Dim sales As New ViewTransactions
        sales.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnmanage.Click
        Dim man As New ManagementReport
        man.ShowDialog()
    End Sub
    Private Sub Menu_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim losave As New ManagementClass
        losave.SaveLogout()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnaboutus.Click
        Dim ab As New AboutUs
        ab.ShowDialog()
    End Sub
End Class