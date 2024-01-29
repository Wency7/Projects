
Public Class LoginForm
    Private Sub Btnlogin_Click(sender As Object, e As EventArgs) Handles Btnlogin.Click
        Try
            Dim userlog As New LoginClass

            If userlog.LogInUser(txtusername.Text, txtpassword.Text) Then
                MessageBox.Show("Welcome " & userlog.CashierName)
                POSClass.CashierName = userlog.CashierName
                Dim lsave As New ManagementClass
                lsave.CashierName = userlog.CashierName
                lsave.SaveLogin()
                Me.Hide()
                Dim f As New Menu
                f.ShowDialog()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub




End Class
