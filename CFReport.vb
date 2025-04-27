Imports System.Configuration
Imports Oracle.ManagedDataAccess.Client
Public Class CFReport

    Private CategoryStats As New Dictionary(Of String, CategoryStat)
    Private Sub CFReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each btn In New Button() {BtnThisMonth, BtnLastMonth, BtnYearToDate, BtnThisQuarter, BtnCustomRange}
            EnableResponsiveCornerRadius(btn)
        Next

        For Each pnl As Panel In New Panel() {
            PnlRow, PnlCLBar, PnlBarST, PnlBarHistory, PnlBarFiction,
            PnlBarForMemberEngagement, PnlBarStudyRoomA, PnlBarCollaborationSpace, PnlBarConferenceRoom,
            PnlBarQuietStudyRoom, PnlBarMediaLab
}
            Dim currentPanel = pnl
            AddHandler currentPanel.Paint, Sub(sender2, e2)
                                               PanelPillRadius(currentPanel, e2)
                                           End Sub
        Next

        For Each pnl In New Panel() {PnlBorrowingStatistics, PnlPopularCategories, PNLUserActivity, PnlMeetingRoomUsage}
            Dim currentPanel = pnl

            AddHandler currentPanel.Paint, Sub(s, pe)
                                               StyleShadowPanel(DirectCast(s, Panel), pe)
                                           End Sub

            AddHandler currentPanel.Resize, Sub(s, args)
                                                currentPanel.Invalidate()
                                            End Sub
        Next

        TimerDateTime.Interval = 1000
        TimerDateTime.Start()
        AddHandler TimerDateTime.Tick, Sub() LblDateTimeMeeting.Text = DateTime.Now.ToString("MMMM dd, yyyy - hh:mm:ss tt")
        LblDateTimeMeeting.Text = DateTime.Now.ToString("MMMM dd, yyyy - hh:mm:ss tt")

        AddShadowBetweenRows(TLPBorrowingStatistics, 0, 1)
        AddShadowBetweenRows(TLPPopularCategories, 0, 1)
        AddShadowBetweenRows(TLPUserActivity, 0, 1)
        AddShadowBetweenRows(TLPMeetingRoomUsage, 0, 1)

        CategoryStats.Add("Classic Literature", New CategoryStat With {
            .Value = 43,
            .FillPanel = PnlFillBarCL,
            .BackPanel = PnlBackBarCL
        })

        CategoryStats.Add("Science & Technology", New CategoryStat With {
            .Value = 37,
            .FillPanel = PnlFIllBarST,
            .BackPanel = PnlBackBarST
        })

        CategoryStats.Add("History", New CategoryStat With {
            .Value = 32,
            .FillPanel = PnlFillBarHistory,
            .BackPanel = PnlBackBarHistory
        })

        CategoryStats.Add("Fiction", New CategoryStat With {
            .Value = 28,
            .FillPanel = PnlFillBarFiction,
            .BackPanel = PnlBackBarFiction
        })

        AddHandler PnlBarBack.Resize, AddressOf UpdateReturnRateBar
        AddHandler PnlBarBackMemberEngagement.Resize, AddressOf UpdateEngagementBar

        SetupRoomBars()


    End Sub

    Private Sub CFReport_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ' Then loop through all of them to set the progress:
        For Each stat In CategoryStats.Values
            Dim fullBarWidth As Integer = stat.BackPanel.Width
            SetCategoryBarProgress(stat.FillPanel, stat.Value, fullBarWidth)
        Next
    End Sub


    Private Sub PnlRow_Paint(sender As Object, e As PaintEventArgs)
        PanelPillRadius(PnlRow, e)
    End Sub

    Private Sub UpdateReturnRateBar(sender As Object, e As EventArgs)
        Dim totalBorrowed As Integer = Integer.Parse(LblNumberOfTotalBooks.Text)
        Dim booksReturned As Integer = Integer.Parse(LblNumberOfBooksReturned.Text)
        SetReturnRateBar(PnlBarBack, PnlBarFill, booksReturned, totalBorrowed, LblReturnRatePercent)
    End Sub

    Private Sub UpdateEngagementBar(sender As Object, e As EventArgs)
        Dim activeMembers As Integer = Integer.Parse(LblNumberOfActiveMembers.Text)
        Dim libraryVisits As Integer = Integer.Parse(LblNumberOfLibraryVisits.Text)
        Dim booksBorrowed As Integer = Integer.Parse(LblNumberOfBooksBorrowed.Text)
        Dim newRegistrations As Integer = Integer.Parse(LblNumberOfNewRegistration.Text)

        Dim engagementRate As Double = CalculateMemberEngagement(activeMembers, libraryVisits, booksBorrowed, newRegistrations)
        SetEngagementBar(PnlBarBackMemberEngagement, PnlFillBarMemberEngagement, engagementRate)
        LblPercentMemberEngagement.Text = engagementRate.ToString("0.0") & "%"
    End Sub

    Private Sub SetupRoomBars()
        Dim totalBookings As Integer = 87 ' Or get dynamically if needed

        Dim roomData As New Dictionary(Of Panel, Integer) From {
        {PnlFillStudyRoomA, 37},
        {PnlFillCollaborationSpace, 25},
        {PnlFillConferenceRoom, 15},
        {PnlFillQuietStudyRoom, 7},
        {PnlFillMediaLab, 5}
    }

        For Each kvp In roomData
            Dim fillPanel = kvp.Key
            Dim bookings = kvp.Value
            Dim backPanel = DirectCast(fillPanel.Parent, Panel) ' Assuming FillPanel inside a BackPanel

            ' Set bar immediately
            SetRoomBookingBar(fillPanel, bookings, totalBookings, backPanel.Width)

            ' Handle resizing dynamically
            AddHandler backPanel.Resize, Sub()
                                             SetRoomBookingBar(fillPanel, bookings, totalBookings, backPanel.Width)
                                         End Sub
        Next
    End Sub

End Class