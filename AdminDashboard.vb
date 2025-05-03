Public Class AdminDashboard
    Private Const DEFAULT_RADIUS As Integer = 15
    Private Const HOVER_RADIUS As Integer = 15

    Private ReadOnly HighlightColor As Color = ColorTranslator.FromHtml("#1b5274")
    Private ReadOnly DefaultColor As Color = ColorTranslator.FromHtml("#2d3e50")
    Private BtnCurrentlyHighlighted As Button

    Private Sub AdminDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Style sidebar buttons
        Dim sidebarButtons As Button() = {
            BtnDashboard, BtnBooks, BtnBorrowing, BtnBlock,
            BtnMeeting, BtnReport, BtnUser, BtnSettings
        }

        For Each btn In sidebarButtons
            StyleSidebarButton(btn)
        Next

        ' Add top line - Might not be needed
        TBLAdmin.RowStyles(0).Height = 2
        TBLAdmin.RowStyles(0).SizeType = SizeType.Absolute

        Dim line As New Panel() With {
            .BackColor = ColorTranslator.FromHtml("#f4f5fa"),
            .Dock = DockStyle.Fill
        }
        TBLAdmin.Controls.Add(line, 0, 0)
        TBLAdmin.SetColumnSpan(line, TBLAdmin.ColumnCount)

        ' Setup search panel
        TxtSearch.Text = "Search..."
        TxtSearch.ForeColor = Color.Gray

        AddHandler PnlSearch.Paint, AddressOf PnlSearch_Paint
        AddHandler PnlSearch.Resize, Sub() PnlSearch.Invalidate()

        PnlSearch.BackColor = Color.White
        PnlSearch.BorderStyle = BorderStyle.None
        PnlSearch.Margin = New Padding(5)

        ' Add shadow separator between dashboard rows
        AddShadowBetweenRows(TBLDashboard, 0, 1)

        ' Load default child form
        ChildForm(New CFDashboard())
        BtnCurrentlyHighlighted = BtnDashboard
        HighlightButton(BtnDashboard)

        ApplyCursorHand(BtnAdd)


    End Sub

    Private Sub AdminDashboard_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If String.IsNullOrWhiteSpace(TxtSearch.Text) Then
            TxtSearch.Text = "Search..."
            TxtSearch.ForeColor = Color.Gray
        End If
    End Sub

    ' ---------------- Sidebar Button Styling ----------------
    Private Sub StyleSidebarButton(btn As Button)
        With btn
            .ForeColor = Color.White
            .BackColor = DefaultColor
            .FlatAppearance.BorderSize = 0
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.MouseOverBackColor = HighlightColor
            .Cursor = Cursors.Hand
        End With

        ' Corner radius hover effect
        AddHandler btn.MouseEnter, Sub()
                                       If BtnCurrentlyHighlighted IsNot btn Then
                                           UnhighlightButton(BtnCurrentlyHighlighted)
                                           HighlightButton(btn)
                                       End If
                                       ApplyCornerRadius(btn, HOVER_RADIUS)
                                   End Sub

        AddHandler btn.MouseLeave, Sub()
                                       If BtnCurrentlyHighlighted IsNot btn Then
                                           UnhighlightButton(btn)
                                           HighlightButton(BtnCurrentlyHighlighted)
                                       End If
                                       ApplyCornerRadius(btn, DEFAULT_RADIUS)
                                   End Sub

        AddHandler btn.Resize, Sub() ApplyCornerRadius(btn, DEFAULT_RADIUS)
    End Sub

    Private Sub HighlightButton(btn As Button)
        btn.BackColor = HighlightColor
        btn.FlatAppearance.BorderColor = HighlightColor
    End Sub

    Private Sub UnhighlightButton(btn As Button)
        btn.BackColor = DefaultColor
        btn.FlatAppearance.BorderColor = DefaultColor
    End Sub

    Private Sub ApplyCornerRadius(btn As Button, radius As Integer)
        Dim path As New Drawing2D.GraphicsPath()
        Dim rect As New Rectangle(0, 0, btn.Width, btn.Height)

        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90)
        path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90)
        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90)
        path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90)
        path.CloseAllFigures()

        btn.Region = New Region(path)
    End Sub

    ' ---------------- Search Field ----------------
    Private Sub TxtSearch_GotFocus(sender As Object, e As EventArgs) Handles TxtSearch.GotFocus
        If TxtSearch.Text = "Search..." Then
            TxtSearch.Text = ""
            TxtSearch.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TxtSearch_LostFocus(sender As Object, e As EventArgs) Handles TxtSearch.LostFocus
        If TxtSearch.Text = "" Then
            TxtSearch.Text = "Search..."
            TxtSearch.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub PnlSearch_Paint(sender As Object, e As PaintEventArgs)
        Dim radius As Integer = PnlSearch.Height \ 2
        Dim path As New Drawing2D.GraphicsPath()

        path.StartFigure()
        path.AddArc(0, 0, radius * 2, radius * 2, 180, 90)
        path.AddArc(PnlSearch.Width - radius * 2, 0, radius * 2, radius * 2, 270, 90)
        path.AddArc(PnlSearch.Width - radius * 2, PnlSearch.Height - radius * 2, radius * 2, radius * 2, 0, 90)
        path.AddArc(0, PnlSearch.Height - radius * 2, radius * 2, radius * 2, 90, 90)
        path.CloseFigure()

        PnlSearch.Region = New Region(path)
    End Sub

    ' ---------------- Layout / Utility ----------------

    Private Sub ChildForm(childForm As Form)
        RestoreDashboard()
        PnlChildForm.Controls.Clear()
        With childForm
            .TopLevel = False
            .FormBorderStyle = FormBorderStyle.None
            .Dock = DockStyle.Fill
        End With
        PnlChildForm.Controls.Add(childForm)
        childForm.Show()
    End Sub

    Private Sub ReportChildForm(childForm As Form)
        TBLDashboard.Controls.Clear()
        TBLDashboard.RowStyles.Clear()
        TBLDashboard.RowCount = 1
        TBLDashboard.RowStyles.Add(New RowStyle(SizeType.Percent, 100))

        With childForm
            .TopLevel = False
            .FormBorderStyle = FormBorderStyle.None
            .Dock = DockStyle.Fill
        End With

        TBLDashboard.Controls.Add(childForm, 0, 0)
        TBLDashboard.SetColumnSpan(childForm, TBLDashboard.ColumnCount) ' Optional if more than one column
        TBLDashboard.SetRowSpan(childForm, TBLDashboard.RowCount) ' Important if you want to span all rows

        childForm.Show()
    End Sub


    Private Sub RestoreDashboard()
        TBLDashboard.Controls.Clear()
        TBLDashboard.RowStyles.Clear()
        TBLDashboard.RowCount = 3 ' Adjust as needed: 1 for top, 1 for shadow, 1 for main content

        ' Recreate original row layout
        TBLDashboard.RowStyles.Add(New RowStyle(SizeType.Absolute, PanelTop.Height)) ' Top panel row
        TBLDashboard.RowStyles.Add(New RowStyle(SizeType.Absolute, 4)) ' Shadow separator row
        TBLDashboard.RowStyles.Add(New RowStyle(SizeType.Percent, 100)) ' Main content row

        ' Add PanelTop back in row 0
        TBLDashboard.Controls.Add(PanelTop, 0, 0)
        TBLDashboard.SetColumnSpan(PanelTop, TBLDashboard.ColumnCount)

        ' Add shadow back in row 1
        Dim shadow As New Panel() With {
        .Height = 4,
        .Dock = DockStyle.Fill,
        .BackColor = Color.FromArgb(60, 0, 0, 0)
    }
        TBLDashboard.Controls.Add(shadow, 0, 1)
        TBLDashboard.SetColumnSpan(shadow, TBLDashboard.ColumnCount)

        ' Add PnlChildForm back in row 2
        TBLDashboard.Controls.Add(PnlChildForm, 0, 2)
        TBLDashboard.SetColumnSpan(PnlChildForm, TBLDashboard.ColumnCount)
    End Sub



    Private Sub AdminDashboard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then Application.Exit()
    End Sub

    ' ---------------- BtnAdd Paint (rounded corner) ----------------
    Private Sub BtnAdd_Paint(sender As Object, e As PaintEventArgs) Handles BtnAdd.Paint
        ApplyCornerRadius(BtnAdd, DEFAULT_RADIUS)
    End Sub

    Private Sub BtnBooks_Click(sender As Object, e As EventArgs) Handles BtnBooks.Click
        ChildForm(New Books())
        BtnCurrentlyHighlighted = BtnBooks
        HighlightButton(BtnBooks)
        LblAdminDashBoard.Text = "Book Management"
        HideSearchAddBtn()
    End Sub

    Private Sub BtnDashboard_Click(sender As Object, e As EventArgs) Handles BtnDashboard.Click
        ChildForm(New CFDashboard())
        BtnCurrentlyHighlighted = BtnDashboard
        HighlightButton(BtnDashboard)
        LblAdminDashBoard.Text = "Admin Dashboard"
        Panel15.Show()
        Panel17.Show()
    End Sub

    Private Sub BtnBlock_Click(sender As Object, e As EventArgs) Handles BtnBlock.Click
        ChildForm(New Block())
        BtnCurrentlyHighlighted = BtnBlock
        HighlightButton(BtnBlock)
        LblAdminDashBoard.Text = "Blocking Management"
        HideSearchAddBtn()
    End Sub

    Private Sub BtnMeeting_Click(sender As Object, e As EventArgs) Handles BtnMeeting.Click
        ChildForm(New CFMeetingRooms())
        BtnCurrentlyHighlighted = BtnMeeting
        HighlightButton(BtnMeeting)
        LblAdminDashBoard.Text = "Room Availability"
        HideSearchAddBtn()
    End Sub

    Private Sub BtnReport_Click(sender As Object, e As EventArgs) Handles BtnReport.Click
        ReportChildForm(New CFReport()) ' Replace CFReport with your actual form
        BtnCurrentlyHighlighted = BtnReport
        HighlightButton(BtnReport)
    End Sub

    Private Sub BtnBorrowing_Click(sender As Object, e As EventArgs) Handles BtnBorrowing.Click
        ChildForm(New CFBorrowing())
        BtnCurrentlyHighlighted = BtnBorrowing
        HighlightButton(BtnBorrowing)
        LblAdminDashBoard.Text = "Books Borrowed Management"
        HideSearchAddBtn()
    End Sub

    Private Sub BtnUser_Click(sender As Object, e As EventArgs) Handles BtnUser.Click
        ChildForm(New CFUser())
        BtnCurrentlyHighlighted = BtnUser
        HighlightButton(BtnUser)
        LblAdminDashBoard.Text = "Users Management"
        HideSearchAddBtn()
    End Sub

    Private Sub BtnSettings_Click(sender As Object, e As EventArgs) Handles BtnSettings.Click
        ChildForm(New CFSettings())
        BtnCurrentlyHighlighted = BtnSettings
        HighlightButton(BtnSettings)
        LblAdminDashBoard.Text = "Settings"
        HideSearchAddBtn()
    End Sub

    Public Sub HideSearchAddBtn()
        Panel15.Hide()
        Panel17.Hide()
    End Sub
End Class
