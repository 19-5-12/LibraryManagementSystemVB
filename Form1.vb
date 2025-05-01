Imports System.Drawing.Drawing2D
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class LoginForm
    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = FormBorderStyle.Sizable
        Me.Region = Nothing ' Remove rounded corners from form
        PanelLogin.Region = GetRoundedRegion(PanelLogin.ClientRectangle, 25) ' Keep rounded panels

        SetTransparentControls()

        TxtUser1.Text = "Enter your Username"
        TxtUser1.ForeColor = Color.Gray

        TxtPass1.Text = "Enter your Password"
        TxtPass1.ForeColor = Color.Gray

        btnFocus.Focus()

        ForgotPassword.LinkBehavior = LinkBehavior.NeverUnderline
        TermsAndCondition.LinkBehavior = LinkBehavior.NeverUnderline

        ApplyCursorHand(BtnLogin)

    End Sub

    Private Sub PanelLeft_Paint(sender As Object, e As PaintEventArgs) Handles PanelLeft.Paint
        Dim topColor = ColorTranslator.FromHtml("#58859e")
        Dim bottomColor = ColorTranslator.FromHtml("#63a1cb")

        Using brush As New LinearGradientBrush(
            New Point(0, 0),
            New Point(0, PanelLeft.Height),
            topColor,
            bottomColor)

            e.Graphics.FillRectangle(brush, PanelLeft.ClientRectangle)
        End Using
    End Sub

    Private Sub LoginForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        PanelLogin.Region = GetRoundedRegion(PanelLogin.ClientRectangle, 25)

        Dim scaleFactor As Single = If(Me.WindowState = FormWindowState.Maximized,
                                1.4F,
                                Math.Min(Me.Width / 700, Me.Height / 540))

        ScaleFonts(scaleFactor)
    End Sub

    Private Sub SetTransparentControls()
        ' Organize by control type if needed
        Dim transparentSettings As New Dictionary(Of Type, List(Of Control)) From {
        {GetType(Panel), New List(Of Control) From {PanelLogo, PanelList, Panel1, Panel2, Panel8}},
        {GetType(Label), New List(Of Control) From {Label1, Label10}} ' Add all labels
    }

        For Each setting In transparentSettings
            For Each ctrl In setting.Value
                ctrl.BackColor = Color.Transparent
            Next
        Next
    End Sub


    Private Sub ScaleFonts(scaleFactor As Single)
        Dim fontSettings As New Dictionary(Of Single, List(Of Label)) From {
        {25.0F, New List(Of Label) From {Label1, Label3}},
        {15.0F, New List(Of Label) From {Label10, Label8}},
        {10.0F, New List(Of Label) From {Label4, Label5, Label6, Label7, Label9}}
    }

        For Each setting In fontSettings
            Dim baseSize As Single = setting.Key
            For Each lbl In setting.Value
                lbl.Font = New Font(lbl.Font.FontFamily, baseSize * scaleFactor, lbl.Font.Style)
            Next
        Next
    End Sub


    Private Function GetRoundedRegion(rect As Rectangle, radius As Integer) As Region
        Dim path As New GraphicsPath()
        path.StartFigure()
        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90)
        path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90)
        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90)
        path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90)
        path.CloseFigure()
        Return New Region(path)
    End Function

    Private Sub TxtPass1_GotFocus(sender As Object, e As EventArgs) Handles TxtPass1.GotFocus
        If TxtPass1.Text = "Enter your Password" Then
            TxtPass1.Text = ""
            TxtPass1.ForeColor = Color.Black
            TxtPass1.PasswordChar = "●"
        End If
    End Sub

    Private Sub TxtPass1_LostFocus(sender As Object, e As EventArgs) Handles TxtPass1.LostFocus
        If TxtPass1.Text = "" Then
            TxtPass1.Text = "Enter your Password"
            TxtPass1.ForeColor = Color.Gray
            TxtPass1.PasswordChar = ""
        End If
    End Sub

    Private Sub TxtUser1_TextChanged_1(sender As Object, e As EventArgs) Handles TxtUser1.TextChanged

    End Sub

    Private Sub TxtUser1_GotFocus(sender As Object, e As EventArgs) Handles TxtUser1.GotFocus
        If TxtUser1.Text = "Enter your Username" Then
            TxtUser1.Text = ""
            TxtUser1.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TxtUser1_LostFocus(sender As Object, e As EventArgs) Handles TxtUser1.LostFocus
        If TxtUser1.Text = "" Then
            TxtUser1.Text = "Enter your Username"
            TxtUser1.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles BtnLogin.Click
        If TxtUser1.Text = "a" And
            TxtPass1.Text = "a" Then
            TxtUser1.Text = "Enter your Username"
            TxtUser1.ForeColor = Color.LightGray

            TxtPass1.Text = "Enter your Password"
            TxtPass1.ForeColor = Color.LightGray
            TxtPass1.PasswordChar = ""

            Me.Hide()
            AdminDashboard.Show()

        Else
            MessageBox.Show("Wrong Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
End Class
