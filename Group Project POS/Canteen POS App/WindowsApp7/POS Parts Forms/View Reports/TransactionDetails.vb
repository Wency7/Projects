Public Class TransactionDetails
    Dim TransactionID As String
    Public Sub New(pTransactionID As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        TransactionID = pTransactionID

    End Sub

    Private Sub TransactionDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblTransId.Text = TransactionID
        Try
            Dim clss As New SalesClass
            Dim dt As New DataTable
            dt = clss.ViewTransactionD(TransactionID)
            DGVItems.DataSource = dt
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class