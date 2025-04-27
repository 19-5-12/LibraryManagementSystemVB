' File: UIHelpers.vb
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Module UIHelpers

    Public Sub ApplyCornerRadius(btn As Button)
        Dim radius As Integer = btn.Height \ 2 ' or use a fixed number like 15
        Dim path As New GraphicsPath()
        Dim rect As New Rectangle(0, 0, btn.Width, btn.Height)

        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90)
        path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90)
        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90)
        path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90)
        path.CloseAllFigures()

        btn.Region = New Region(path)
    End Sub

    Public Sub SetDataGridHeaderWhite(grid As DataGridView)
        For Each col As DataGridViewColumn In grid.Columns
            col.HeaderCell.Style.BackColor = Color.White
        Next
    End Sub

    Public Sub StyleShadowPanel(pnl As Panel, e As PaintEventArgs, Optional radius As Integer = 15)
        Dim shadowColor As Color = Color.FromArgb(50, Color.Black)
        Using g As Graphics = e.Graphics
            g.SmoothingMode = SmoothingMode.AntiAlias

            ' Draw shadow
            Dim shadowRect = New Rectangle(3, 3, pnl.Width - 6, pnl.Height - 6)
            Using shadowPath As New GraphicsPath()
                shadowPath.AddArc(shadowRect.X, shadowRect.Y, radius, radius, 180, 90)
                shadowPath.AddArc(shadowRect.Right - radius, shadowRect.Y, radius, radius, 270, 90)
                shadowPath.AddArc(shadowRect.Right - radius, shadowRect.Bottom - radius, radius, radius, 0, 90)
                shadowPath.AddArc(shadowRect.X, shadowRect.Bottom - radius, radius, radius, 90, 90)
                shadowPath.CloseFigure()
                Using shadowBrush As New SolidBrush(shadowColor)
                    g.FillPath(shadowBrush, shadowPath)
                End Using
            End Using

            ' Apply rounded region
            Dim mainRect = New Rectangle(0, 0, pnl.Width - 6, pnl.Height - 6)
            Using path As New GraphicsPath()
                path.AddArc(mainRect.X, mainRect.Y, radius, radius, 180, 90)
                path.AddArc(mainRect.Right - radius, mainRect.Y, radius, radius, 270, 90)
                path.AddArc(mainRect.Right - radius, mainRect.Bottom - radius, radius, radius, 0, 90)
                path.AddArc(mainRect.X, mainRect.Bottom - radius, radius, radius, 90, 90)
                path.CloseFigure()
                pnl.Region = New Region(path)
            End Using
        End Using
    End Sub

    Public Sub RoundPanel(pnl As Panel, e As PaintEventArgs, Optional radius As Integer = 20)
        Dim path As New Drawing2D.GraphicsPath()

        path.StartFigure()
        path.AddArc(0, 0, radius, radius, 180, 90)
        path.AddArc(pnl.Width - radius, 0, radius, radius, 270, 90)
        path.AddArc(pnl.Width - radius, pnl.Height - radius, radius, radius, 0, 90)
        path.AddArc(0, pnl.Height - radius, radius, radius, 90, 90)
        path.CloseFigure()

        pnl.Region = New Region(path)
    End Sub


    Public Sub SetupFormUI(CRUDBtns As Button(), grid As DataGridView, timer As Timer, timeLabel As Label, loadDataAction As Action)
        ' Style buttons
        For Each btn In CRUDBtns
            ApplyCornerRadius(btn)
            AddHandler btn.Resize, Sub() ApplyCornerRadius(btn)
        Next

        ' Start timer and update label
        timer.Interval = 1000
        timer.Start()
        AddHandler timer.Tick, Sub() timeLabel.Text = DateTime.Now.ToString("MMMM dd, yyyy - hh:mm:ss tt")
        timeLabel.Text = DateTime.Now.ToString("MMMM dd, yyyy - hh:mm:ss tt")

        ' Load data into DataGridView
        loadDataAction.Invoke()

        ' Style DataGridView headers
        grid.EnableHeadersVisualStyles = False
        SetDataGridHeaderWhite(grid)
        ApplyCursorHand(CRUDBtns)
    End Sub

    Public Sub ApplyCursorHand(ParamArray buttons As Button())
        For Each btn In buttons
            btn.Cursor = Cursors.Hand
        Next
    End Sub

    Public Sub SetReturnRateBar(bgPanel As Panel, fillPanel As Panel, booksReturned As Integer, totalBorrowed As Integer, Optional lblRateText As Label = Nothing)
        If totalBorrowed <= 0 Then
            fillPanel.Width = 0
            If lblRateText IsNot Nothing Then lblRateText.Text = "0%"
            Return
        End If

        Dim returnRate As Double = booksReturned / totalBorrowed
        Dim barWidth As Integer = CInt(bgPanel.Width * returnRate)

        fillPanel.Width = barWidth

        ' Optional: Set label text to show return rate percentage
        If lblRateText IsNot Nothing Then
            lblRateText.Text = (returnRate * 100).ToString("0.0") & "%"
        End If
    End Sub

    Public Sub PanelPillRadius(pnl As Panel, e As PaintEventArgs)
        Dim radius As Integer = pnl.Height \ 2
        Dim path As New Drawing2D.GraphicsPath()

        path.StartFigure()
        path.AddArc(0, 0, radius * 2, radius * 2, 180, 90)
        path.AddArc(pnl.Width - radius * 2, 0, radius * 2, radius * 2, 270, 90)
        path.AddArc(pnl.Width - radius * 2, pnl.Height - radius * 2, radius * 2, radius * 2, 0, 90)
        path.AddArc(0, pnl.Height - radius * 2, radius * 2, radius * 2, 90, 90)
        path.CloseFigure()

        pnl.Region = New Region(path)
    End Sub

    Public Sub AddShadowBetweenRows(tbl As TableLayoutPanel, rowAbove As Integer, rowBelow As Integer)
        Dim shadow As New Panel() With {
        .Height = 4,
        .Dock = DockStyle.Fill,
        .BackColor = Color.FromArgb(60, 0, 0, 0)
    }

        tbl.RowCount += 1

        ' Shift rows down
        For i As Integer = tbl.RowCount - 1 To rowBelow + 1 Step -1
            tbl.RowStyles.Insert(i, New RowStyle(tbl.RowStyles(i - 1).SizeType, tbl.RowStyles(i - 1).Height))
            For c As Integer = 0 To tbl.ColumnCount - 1
                Dim ctrl = tbl.GetControlFromPosition(c, i - 1)
                If ctrl IsNot Nothing Then
                    tbl.SetRow(ctrl, i)
                End If
            Next
        Next

        tbl.RowStyles.Insert(rowBelow, New RowStyle(SizeType.Absolute, shadow.Height))
        tbl.Controls.Add(shadow, 0, rowBelow)
        tbl.SetColumnSpan(shadow, tbl.ColumnCount)
    End Sub

    Public Sub ApplyCornerRadius(btn As Button, Optional radius As Integer = -1)
        If btn.Width = 0 OrElse btn.Height = 0 Then Exit Sub

        ' Auto mode: make pill-like based on height
        If radius = -1 Then radius = btn.Height \ 2

        Dim path As New Drawing2D.GraphicsPath()
        Dim rect As New Rectangle(0, 0, btn.Width, btn.Height)

        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90)
        path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90)
        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90)
        path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90)
        path.CloseFigure()

        btn.Region = New Region(path)
    End Sub

    Public Sub EnableResponsiveCornerRadius(btn As Button, Optional radius As Integer = -1)
        ' Apply immediately
        ApplyCornerRadius(btn, radius)

        ' Reapply on resize
        AddHandler btn.Resize, Sub() ApplyCornerRadius(btn, radius)
    End Sub

    Public Sub SetCategoryBarProgress(fillPanel As Panel, value As Integer, fullBarWidth As Integer)
        Dim maxValue As Integer = 100

        ' Increase max every 50 if value is higher
        While value > maxValue
            maxValue += 50
        End While

        Dim fillPercent As Double = value / maxValue
        Dim fillWidth As Integer = CInt(Math.Round(fullBarWidth * fillPercent))

        If value = maxValue Then
            fillWidth = fullBarWidth
        Else
            fillWidth = CInt(Math.Round(fullBarWidth * fillPercent))
        End If


        fillPanel.Width = fillWidth
    End Sub

    Public Function CalculateMemberEngagement(activeMembers As Integer, libraryVisits As Integer, booksBorrowed As Integer, newRegistrations As Integer) As Double
        If activeMembers <= 0 Then Return 0

        Dim memberActivity As Integer = libraryVisits + booksBorrowed + newRegistrations
        Dim engagementRate As Double = (memberActivity / activeMembers) * 100

        Return engagementRate
    End Function

    Public Sub SetEngagementBar(bgPanel As Panel, fillPanel As Panel, engagementRate As Double)
        Dim percent As Double = Math.Min(engagementRate / 100.0, 1.0) ' Ensure max is 100%
        Dim fillWidth As Integer = CInt(bgPanel.Width * percent)

        fillPanel.Width = fillWidth
    End Sub

    Public Sub SetRoomBookingBar(fillPanel As Panel, roomBookings As Integer, totalBookings As Integer, fullBarWidth As Integer)
        If totalBookings <= 0 Then
            fillPanel.Width = 0
            Return
        End If

        Dim fillPercent As Double = roomBookings / totalBookings
        Dim fillWidth As Integer = CInt(Math.Round(fullBarWidth * fillPercent))

        fillPanel.Width = fillWidth
    End Sub

    Public Sub RoundTableLayoutPanel(tbl As TableLayoutPanel, e As PaintEventArgs, Optional radius As Integer = 20)
        Dim path As New Drawing2D.GraphicsPath()

        ' Create a rounded rectangle
        path.StartFigure()
        path.AddArc(0, 0, radius, radius, 180, 90)
        path.AddArc(tbl.Width - radius, 0, radius, radius, 270, 90)
        path.AddArc(tbl.Width - radius, tbl.Height - radius, radius, radius, 0, 90)
        path.AddArc(0, tbl.Height - radius, radius, radius, 90, 90)
        path.CloseFigure()

        tbl.Region = New Region(path)
    End Sub

End Module
