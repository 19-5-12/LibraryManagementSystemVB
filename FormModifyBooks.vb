Public Class FormModifyBooks

    Private Sub Modify_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        roundedPanels.Clear()

        ComboCategory.FlatStyle = FlatStyle.Flat
        ComboCategory.Items.Insert(0, "Select category")
        ComboCategory.SelectedIndex = 0

        Dim paddedPanels = {PnlFakeTextBox, Panel3, PnlBorderAuthor, PnlBorderIBSN,
            PnlBorderCategory, PnlBorderPubYear, PnlBorderQuantity, PnlBorderSelectID}
        For Each pnl In paddedPanels
            pnl.Padding = New Padding(3)
        Next
        PnlFill.Padding = New Padding(10)

        ' Placeholder setup
        UIHelpers.SetupPlaceholder(TxtTitle, "Enter Book Title")
        UIHelpers.SetupPlaceholder(TxtAuthor, "Enter Author Name")
        UIHelpers.SetupPlaceholder(TxtISBN, "Enter ISBN")
        UIHelpers.SetupPlaceholder(TxtQuantity, "Enter Quantity")
        UIHelpers.SetupPlaceholder(TxtSelectID, "Enter Book ID")

        ' Rounded corners
        UIHelpers.roundedPanels.Add(PnlFill, 20)
        UIHelpers.roundedPanels.Add(PnlFakeTextBox, 5)
        UIHelpers.roundedPanels.Add(Panel3, 5)
        UIHelpers.roundedPanels.Add(PnlBorderAuthor, 5)
        UIHelpers.roundedPanels.Add(PnlBorderIBSN, 5)
        UIHelpers.roundedPanels.Add(PnlBorderCategory, 5)
        UIHelpers.roundedPanels.Add(PnlBorderPubYear, 5)
        UIHelpers.roundedPanels.Add(PnlBorderQuantity, 5)
        UIHelpers.roundedPanels.Add(PnlBorderSelectID, 5)
    End Sub

    Private Sub Modify_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        BtnAddBook.Focus()
    End Sub


    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub Panel_Paint(sender As Object, e As PaintEventArgs) Handles PnlFill.Paint,
    PnlFakeTextBox.Paint, Panel3.Paint, PnlBorderAuthor.Paint, PnlBorderIBSN.Paint,
    PnlBorderCategory.Paint, PnlBorderPubYear.Paint, PnlBorderQuantity.Paint, PnlBorderSelectID.Paint

        UIHelpers.HandlePanelPaint(sender, e)
    End Sub
End Class