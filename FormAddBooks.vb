Public Class FormAddBooks
    Private Sub FormAddBooks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PnlFill.Padding = New Padding(10)
        PnlFakeTextBox.Padding = New Padding(3)
        Panel3.Padding = New Padding(3)
        PnlBorderAuthor.Padding = New Padding(3)

        TxtTitle.Text = "Enter Book Title"
        TxtTitle.ForeColor = Color.Gray
        TxtAuthor.Text = "Enter Author Name"
        TxtAuthor.ForeColor = Color.Gray

    End Sub

    Private Sub FormAddBooks_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        BtnAddBook.Focus()
    End Sub

    Private Sub PnlFill_Paint(sender As Object, e As PaintEventArgs) Handles PnlFill.Paint
        MakeRoundedPanel(PnlFill, 20, e)
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub PnlFakeTextBox_Paint(sender As Object, e As PaintEventArgs) Handles PnlFakeTextBox.Paint
        MakeRoundedPanel(PnlFakeTextBox, 5, e)
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint
        MakeRoundedPanel(Panel3, 5, e)
    End Sub

    Private Sub TxtTitle_GotFocus(sender As Object, e As EventArgs) Handles TxtTitle.GotFocus
        If TxtTitle.Text = "Enter Book Title" Then
            TxtTitle.Text = ""
            TxtTitle.ForeColor = SystemColors.WindowText
        End If
    End Sub

    Private Sub TxtTitle_LostFocus(sender As Object, e As EventArgs) Handles TxtTitle.LostFocus
        If TxtTitle.Text = "" Then
            TxtTitle.Text = "Enter Book Title"
            TxtTitle.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub TxtAuthor_GotFocus(sender As Object, e As EventArgs) Handles TxtAuthor.GotFocus
        If TxtAuthor.Text = "Enter Author Name" Then
            TxtAuthor.Text = ""
            TxtAuthor.ForeColor = SystemColors.WindowText
        End If
    End Sub

    Private Sub TxtAuthor_LostFocus(sender As Object, e As EventArgs) Handles TxtAuthor.LostFocus
        If TxtAuthor.Text = "" Then
            TxtAuthor.Text = "Enter Author Name"
            TxtAuthor.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub PnlBorderAuthor_Paint(sender As Object, e As PaintEventArgs) Handles PnlBorderAuthor.Paint
        MakeRoundedPanel(Panel3, 5, e)
    End Sub

    Private Sub TLPAddNewBook_Paint(sender As Object, e As PaintEventArgs) Handles TLPAddNewBook.Paint
        StyleShadowPanel(CType(sender, Panel), e)
    End Sub

    Private Sub PnlBorderIBSN_Paint(sender As Object, e As PaintEventArgs) Handles PnlBorderIBSN.Paint

    End Sub
End Class