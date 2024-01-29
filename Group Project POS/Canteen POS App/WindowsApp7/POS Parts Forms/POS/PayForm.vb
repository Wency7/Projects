Public Class PayForm
    Private _GridData As DataTable
    Public Sub New(pTotal As Double, pGridData As DataTable)

        ' This call is required by the designer.
        InitializeComponent()
        _GridData = pGridData
        ' Add any initialization after the InitializeComponent() call.
        lblTA.Text = MyConversionTool.FormatDecimalCurrency2DP(pTotal)
    End Sub

    Private Sub Btnlogin_Click(sender As Object, e As EventArgs) Handles Btnlogin.Click
        Me.Close()
    End Sub
    Private Sub txtTendered_TextChanged(sender As Object, e As EventArgs) Handles txtTendered.TextChanged
        If IsNumeric(txtTendered.Text) Then
            Dim ten As Double = txtTendered.Text
            Dim amou As Double = lblTA.Text

            lblChange.Text = ten - amou
        Else
            lblChange.Text = "0.00"
        End If
        If lblChange.Text < 0 Then
            lblChange.Text = "0.00"
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            Dim ten As Double = txtTendered.Text
            Dim amou As Double = lblTA.Text
            Dim SR As New SalesClass
            If (ten - amou) < 0 Then
                MessageBox.Show("Insufficient Amount")
            Else
                SR.SaveTransactionH(txtTendered.Text, lblTA.Text, _GridData)
                Me.Hide()
            End If
        Catch ex As Exception
            Throw ex
        End Try



    End Sub
End Class