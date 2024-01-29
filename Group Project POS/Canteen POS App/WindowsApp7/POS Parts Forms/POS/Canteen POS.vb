Imports System.ComponentModel

Public Class CanteenPOS

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs)

    End Sub
    Private OnSale As Boolean = False
    Dim dtGrid As New DataTable

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub pindutan(pCat As String)
        Try
            FlowLayoutPanel1.Controls.Clear()
            Dim prod As New ProductClass
            Dim dt As DataTable = prod.Getproductlist(pCat)
            For Each dr As DataRow In dt.Rows
                Dim BTN As New Button
                BTN.Text = dr("ProductName") & vbCrLf & "(" & "₱ " & dr("ProductPrice") & ")"
                BTN.Tag = dr("ID")
                BTN.Size = btnTemplate.Size
                BTN.Font = btnTemplate.Font
                BTN.BackColor = btnTemplate.BackColor
                AddHandler BTN.Click, AddressOf btnTemplate_Click
                FlowLayoutPanel1.Controls.Add(BTN)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnBreakfast.Click
        pindutan("Breakfast")

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnMeal.Click
        pindutan("Meal")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnSnack.Click
        pindutan("Snacks")
    End Sub

    Private Sub Button37_Click(sender As Object, e As EventArgs) Handles Button37.Click
        pindutan("Biscuits")
    End Sub

    Private Sub Button38_Click(sender As Object, e As EventArgs) Handles Button38.Click
        pindutan("Drinks")
    End Sub

    Private Sub btnTemplate_Click(sender As Object, e As EventArgs) Handles btnTemplate.Click
        Try
            Dim btnTag As String = DirectCast(sender, Button).Tag
            Dim procls As New ProductClass
            If procls.GetProductsFile(btnTag) Then
                Dim dx() As DataRow = dtGrid.Select("Id='" & btnTag & "'")
                If dx.Length > 0 Then
                    Dim qty As Integer = dx(0)("Quantity") + 1
                    dx(0)("Quantity") = qty
                    dx(0)("Total") = dx(0)("ProductPrice") * qty
                Else
                    Dim dr As DataRow = dtGrid.NewRow
                    dr("Id") = procls.ProductId
                    dr("ProductName") = procls.ProductName
                    dr("Quantity") = 1
                    dr("ProductPrice") = procls.ProductPrice
                    dr("ProductCost") = procls.ProductCost
                    dr("Total") = procls.ProductPrice
                    dtGrid.Rows.Add(dr)
                End If
                UpdateTotal()
                DGVItems.Refresh()
            End If
        Catch ex As Exception

        End Try


    End Sub
    Private Sub UpdateTotal()
        Try
            Dim sum As Double = Convert.ToInt32(dtGrid.Compute("SUM(Total)", String.Empty))
            lbltotalamount.Text = MyConversionTool.FormatDecimalCurrency2DP(sum)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CanteenPOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim CASHI As New LoginClass

        lblCN.Text = POSClass.CashierName
        lblDateToday.Text = DateTime.Now.ToLongDateString & "   "
        pindutan("Breakfast")

        dtGrid.Columns.Add("Id", GetType(String))
        dtGrid.Columns.Add("ProductName", GetType(String))
        dtGrid.Columns.Add("ProductPrice", GetType(Single))
        dtGrid.Columns.Add("ProductCost", GetType(Single))
        dtGrid.Columns.Add("Quantity", GetType(Integer))
        dtGrid.Columns.Add("Total", GetType(Single))

        DGVItems.DataSource = dtGrid
    End Sub

    Private Sub btncancelorder_Click(sender As Object, e As EventArgs) Handles btncancelorder.Click
        dtGrid.Rows.Clear()
        lbltotalamount.Text = 0

    End Sub

    Private Sub btnpayorder_Click(sender As Object, e As EventArgs) Handles btnpayorder.Click
        Dim f As New PayForm(CDbl(lbltotalamount.Text), dtGrid)
        Dim s As New SalesClass
        f.ShowDialog()
    End Sub

    Private Sub btbBackMenu_Click(sender As Object, e As EventArgs) Handles btbBackMenu.Click
        Dim back As New Menu
        Me.Hide()
        back.ShowDialog()

    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Dim losave As New ManagementClass
        losave.SaveLogout()
        Me.Close()
    End Sub
    Private Sub CanteenPOS_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim losave As New ManagementClass
        losave.SaveLogout()
    End Sub
End Class
