Public Class FormDeleteBooks
    Private Sub FormDeleteBooks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        roundedPanels.Clear()
        Dim paddedPanels = {PnlBorderSelectID, PnlFill}
        For Each pnl In paddedPanels
            pnl.Padding = New Padding(3)
        Next
        PnlFill.Padding = New Padding(10)

        UIHelpers.SetupPlaceholder(TxtSelectID, "Enter Book ID")

        roundedPanels.Add(PnlTopAddNewBook, 5)
        roundedPanels.Add(PnlBorderSelectID, 5)
        roundedPanels.Add(PnlFill, 20)
    End Sub

    Private Sub FormDeleteBooks_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        BtnDelete.Focus()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub Panel_Paint(sender As Object, e As PaintEventArgs) Handles PnlFill.Paint, PnlBorderSelectID.Paint
        HandlePanelPaint(sender, e)
    End Sub

    Private Sub TableLayoutPanel6_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel6.Paint
        RoundTableLayoutPanel(TableLayoutPanel6, e)
    End Sub
End Class