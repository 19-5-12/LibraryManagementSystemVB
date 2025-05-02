Public Class Modify
    Private roundedPanels As New Dictionary(Of Panel, Integer)

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
        SetupPlaceholder(TxtTitle, "Enter Book Title")
        SetupPlaceholder(TxtAuthor, "Enter Author Name")
        SetupPlaceholder(TxtISBN, "Enter ISBN")
        SetupPlaceholder(TxtQuantity, "Enter Quantity")
        SetupPlaceholder(TxtSelectID, "Enter Book ID")

        ' Rounded corners
        roundedPanels.Add(PnlFill, 20)
        roundedPanels.Add(PnlFakeTextBox, 5)
        roundedPanels.Add(Panel3, 5)
        roundedPanels.Add(PnlBorderAuthor, 5)
        roundedPanels.Add(PnlBorderIBSN, 5)
        roundedPanels.Add(PnlBorderCategory, 5)
        roundedPanels.Add(PnlBorderPubYear, 5)
        roundedPanels.Add(PnlBorderQuantity, 5)
        roundedPanels.Add(PnlBorderSelectID, 5)
    End Sub

    Private Sub Modify_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        BtnAddBook.Focus()
    End Sub

    Private Sub Panel_Paint(sender As Object, e As PaintEventArgs) Handles PnlFill.Paint,
        PnlFakeTextBox.Paint, Panel3.Paint, PnlBorderAuthor.Paint, PnlBorderIBSN.Paint,
        PnlBorderCategory.Paint, PnlBorderPubYear.Paint, PnlBorderQuantity.Paint, PnlBorderSelectID.Paint

        Dim pnl = DirectCast(sender, Panel)
        If roundedPanels.ContainsKey(pnl) Then
            MakeRoundedPanel(pnl, roundedPanels(pnl), e)
        End If
    End Sub


    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub SetupPlaceholder(txtBox As TextBox, placeholder As String)
        txtBox.Text = placeholder
        txtBox.ForeColor = Color.Gray

        AddHandler txtBox.GotFocus, Sub(sender, e)
                                        If txtBox.Text = placeholder Then
                                            txtBox.Text = ""
                                            txtBox.ForeColor = SystemColors.WindowText
                                        End If
                                    End Sub

        AddHandler txtBox.LostFocus, Sub(sender, e)
                                         If txtBox.Text = "" Then
                                             txtBox.Text = placeholder
                                             txtBox.ForeColor = Color.Gray
                                         End If
                                     End Sub
    End Sub

End Class