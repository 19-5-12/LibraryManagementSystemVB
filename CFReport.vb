Imports System.Configuration
Imports Oracle.ManagedDataAccess.Client
Public Class CFReport
    Private SelectedStartDate As Date?
    Private SelectedEndDate As Date?

    Private CategoryStats As New Dictionary(Of String, CategoryStat)
    Private Sub CFReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePickerStart.MaxDate = DateTime.Today
        DateTimePickerEnd.MaxDate = DateTime.Today

        ComboSearchDate.Items.Insert(0, "Select Date Range")
        ComboSearchDate.SelectedIndex = 0

        ' Hide date panels initially
        PnlDateStart.Visible = False
        PnlDateEnd.Visible = False

        ' Hide date labels initially
        LblDateBorrowingStatistics.Text = ""
        LblDatePopularCategories.Text = ""
        LblDateUserActivity.Text = ""
        LblDateMeetingRoomUsage.Text = ""

        roundedPanels.Clear()

        Dim paddedPanels = {PnlBorrowingStatistics, PnlPopularCategories, PNLUserActivity, PnlMeetingRoomUsage, PnlDateStart, PnlDateEnd}
        For Each pnl In paddedPanels
            pnl.Padding = New Padding(3)
        Next

        roundedPanels.Add(PnlBorrowingStatistics, 5)
        roundedPanels.Add(PnlPopularCategories, 5)
        roundedPanels.Add(PNLUserActivity, 5)
        roundedPanels.Add(PnlMeetingRoomUsage, 5)
        roundedPanels.Add(PnlDateStart, 5)
        roundedPanels.Add(PnlDateEnd, 5)

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


        TimerDateTime.Interval = 1000
        TimerDateTime.Start()
        AddHandler TimerDateTime.Tick, Sub() LblDateTimeMeeting.Text = DateTime.Now.ToString("MMMM dd, yyyy - hh:mm:ss tt")
        LblDateTimeMeeting.Text = DateTime.Now.ToString("MMMM dd, yyyy - hh:mm:ss tt")

        AddShadowBetweenRows(TLPBorrowingStatistics, 0, 1)
        AddShadowBetweenRows(TLPPopularCategories, 0, 1)
        AddShadowBetweenRows(TLPUserActivity, 0, 1)
        AddShadowBetweenRows(TLPMeetingRoomUsage, 0, 1)

        SetupRoomBars()
    End Sub

    Private Sub Panel_Paint(sender As Object, e As PaintEventArgs) Handles PnlBorrowingStatistics.Paint, PnlPopularCategories.Paint,
        PNLUserActivity.Paint, PnlMeetingRoomUsage.Paint, PnlDateStart.Paint, PnlDateEnd.Paint

        Dim pnl = DirectCast(sender, Panel)
        If roundedPanels.ContainsKey(pnl) Then
            MakeRoundedPanel(pnl, roundedPanels(pnl), e)
        End If
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
        Dim activeMembers As Integer = SafeToInt(LblNumberOfActiveMembers.Text)
        Dim engagedMembers As Integer = SafeToInt(LblNumberOfLibraryVisits.Text) ' temp variable, corrected below
        Dim engagementCount As Integer = SafeToInt(LblNumberOfNewRegistration.Text) ' this now holds EngagementCount

        ' Calculate percentage safely
        Dim engagementRate As Double = 0
        If activeMembers > 0 Then
            engagementRate = (engagementCount / activeMembers) * 100.0
        End If

        ' Clamp to max 100 for visuals
        engagementRate = Math.Min(engagementRate, 100.0)

        ' Set progress bar and label
        SetEngagementBar(PnlBarBackMemberEngagement, PnlFillBarMemberEngagement, engagementRate)
        LblPercentMemberEngagement.Text = engagementRate.ToString("0.0") & "%"
    End Sub

    Private Sub SetupRoomBars()
        ' Initialize fill widths to 0 at startup
        For Each fillPanel As Panel In New Panel() {
        PnlFillStudyRoomA,
        PnlFillCollaborationSpace,
        PnlFillConferenceRoom,
        PnlFillQuietStudyRoom,
        PnlFillMediaLab
    }
            fillPanel.Width = 0
        Next

        ' Dummy data will be overwritten later by actual stats
        Dim totalBookings As Integer = 87 ' Optional fallback

        Dim roomData As New Dictionary(Of Panel, Integer) From {
        {PnlFillStudyRoomA, 0},
        {PnlFillCollaborationSpace, 0},
        {PnlFillConferenceRoom, 0},
        {PnlFillQuietStudyRoom, 0},
        {PnlFillMediaLab, 0}
    }

        For Each kvp In roomData
            Dim fillPanel = kvp.Key
            Dim bookings = kvp.Value
            Dim backPanel = DirectCast(fillPanel.Parent, Panel) ' Assuming FillPanel is inside BackPanel

            ' Set initial bar (width is already zero)
            SetRoomBookingBar(fillPanel, bookings, totalBookings, backPanel.Width)

            ' Handle dynamic resize later
            AddHandler backPanel.Resize, Sub()
                                             SetRoomBookingBar(fillPanel, bookings, totalBookings, backPanel.Width)
                                         End Sub
        Next
    End Sub

    Private Sub BtnViewStats_Click(sender As Object, e As EventArgs) Handles BtnViewStats.Click
        If ComboSearchDate.SelectedItem.ToString() = "Custom Range" Then
            SelectedStartDate = DateTimePickerStart.Value.Date
            SelectedEndDate = DateTimePickerEnd.Value.Date
        End If

        If SelectedStartDate.HasValue AndAlso SelectedEndDate.HasValue Then
            UpdateDateLabels()
            LoadStats(SelectedStartDate.Value, SelectedEndDate.Value)
        Else
            MessageBox.Show("Please select a valid date range first.")
        End If
    End Sub

    Private Sub ComboSearchDate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboSearchDate.SelectedIndexChanged
        If ComboSearchDate.SelectedIndex = 0 Then
            SelectedStartDate = Nothing
            SelectedEndDate = Nothing
            PnlDateStart.Visible = False
            PnlDateEnd.Visible = False
            Exit Sub
        End If

        Dim startDate As Date
        Dim endDate As Date = Date.Today

        Select Case ComboSearchDate.SelectedItem.ToString()
            Case "Today"
                startDate = Date.Today
                PnlDateStart.Visible = False
                PnlDateEnd.Visible = False
            Case "This Week"
                startDate = Date.Today.AddDays(-CInt(Date.Today.DayOfWeek))
                PnlDateStart.Visible = False
                PnlDateEnd.Visible = False
            Case "This Month"
                startDate = New Date(Date.Today.Year, Date.Today.Month, 1)
                endDate = startDate.AddMonths(1).AddDays(-1)
                PnlDateStart.Visible = False
                PnlDateEnd.Visible = False
            Case "This Year"
                startDate = New Date(Date.Today.Year, 1, 1)
                endDate = New Date(Date.Today.Year, 12, 31)
                PnlDateStart.Visible = False
                PnlDateEnd.Visible = False
            Case "Custom Range"
                PnlDateStart.Visible = True
                PnlDateEnd.Visible = True
                Exit Sub
            Case Else
                Exit Sub
        End Select

        SelectedStartDate = startDate
        SelectedEndDate = endDate
    End Sub

    Private Sub UpdatePopularCategoryBars()
        ' Get the numeric values from the labels
        Dim cl As Integer = SafeToInt(LblFOrNumberOfCL.Text)
        Dim st As Integer = SafeToInt(LblForNumbersOfST.Text)
        Dim history As Integer = SafeToInt(LblForNumberOfHistory.Text)
        Dim fiction As Integer = SafeToInt(LblForNumberOfFiction.Text)

        ' Calculate total
        Dim totalBorrowed = cl + st + history + fiction
        If totalBorrowed = 0 Then totalBorrowed = 1 ' Prevent division by zero

        ' Define max width
        Dim maxBarWidth As Integer = PnlBackBarCL.Width

        ' Set bar widths based on percentage of total
        PnlFillBarCL.Width = CInt((cl / totalBorrowed) * maxBarWidth)
        PnlFIllBarST.Width = CInt((st / totalBorrowed) * maxBarWidth)
        PnlFillBarHistory.Width = CInt((history / totalBorrowed) * maxBarWidth)
        PnlFillBarFiction.Width = CInt((fiction / totalBorrowed) * maxBarWidth)
    End Sub

    Private Sub UpdateDateLabels()
        If Not SelectedStartDate.HasValue OrElse Not SelectedEndDate.HasValue Then Return

        Dim startDate = SelectedStartDate.Value
        Dim endDate = SelectedEndDate.Value
        Dim labelText As String = ""

        Select Case ComboSearchDate.SelectedItem?.ToString()
            Case "This Week"
                ' Start from Monday
                Dim monday = Date.Today.AddDays(-(CInt(Date.Today.DayOfWeek) - 1))
                If Date.Today.DayOfWeek = DayOfWeek.Sunday Then
                    monday = Date.Today.AddDays(-6)
                End If

                ' End on Sunday or today, whichever is earlier
                Dim sunday = monday.AddDays(6)
                Dim displayEndDate = If(Date.Today < sunday, Date.Today, sunday)

                labelText = monday.ToString("MMMM d") & "–" &
                        If(displayEndDate.Month = monday.Month,
                           displayEndDate.ToString("d, yyyy"),
                           displayEndDate.ToString("MMMM d, yyyy"))

            Case "Custom Range"
                labelText = startDate.ToString("MMMM d, yyyy") & " – " & endDate.ToString("MMMM d, yyyy")

            Case Else
                If startDate = endDate Then
                    labelText = startDate.ToString("MMMM d, yyyy")
                ElseIf startDate.Day = 1 AndAlso endDate = startDate.AddMonths(1).AddDays(-1) Then
                    labelText = startDate.ToString("MMMM yyyy")
                ElseIf startDate.Month = 1 AndAlso startDate.Day = 1 AndAlso endDate.Month = 12 AndAlso endDate.Day = 31 Then
                    labelText = startDate.ToString("yyyy")
                Else
                    labelText = startDate.ToString("MMMM d") & "–" &
                            If(endDate.Month = startDate.Month,
                               endDate.ToString("d, yyyy"),
                               endDate.ToString("MMMM d, yyyy"))
                End If
        End Select

        ' Update all related labels
        LblDateBorrowingStatistics.Text = labelText
        LblDatePopularCategories.Text = labelText
        LblDateUserActivity.Text = labelText
        LblDateMeetingRoomUsage.Text = labelText
    End Sub



    Private Sub LoadStats(startDate As Date, endDate As Date)

        LblNumberOfTotalBooks.Text = "0"
        LblNumberOfBooksReturned.Text = "0"
        LblNumberOfBooksOutstanding.Text = "0"
        LblNumOfOverdueReturns.Text = "0"
        LblNumberOfActiveMembers.Text = "0"
        LblNumberOfLibraryVisits.Text = "0"
        LblNumberOfBooksBorrowed.Text = "0"
        LblNumberOfNewRegistration.Text = "0"
        LblNumbersOfTotalBookings.Text = "0"

        Dim connStr As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"

        Try
            Using conn As New OracleConnection(connStr)
                conn.Open()

                ' Borrowing stats
                Dim borrowSql As String = "
                SELECT 
                    COUNT(*) AS TotalBorrowed,
                    SUM(CASE WHEN RETURN_DATE IS NOT NULL THEN 1 ELSE 0 END) AS Returned,
                    SUM(CASE WHEN RETURN_DATE IS NULL THEN 1 ELSE 0 END) AS Outstanding,
                    SUM(CASE WHEN RETURN_DATE > RETURN_DUE_DATE THEN 1 ELSE 0 END) AS Overdue
                FROM TBL_BORROWING
                WHERE BORROW_DATE BETWEEN :startDate AND :endDate"

                Using cmd As New OracleCommand(borrowSql, conn)
                    cmd.Parameters.Add(":startDate", OracleDbType.Date).Value = startDate
                    cmd.Parameters.Add(":endDate", OracleDbType.Date).Value = endDate

                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim total = SafeToInt(reader("TotalBorrowed"))
                            Dim returned = SafeToInt(reader("Returned"))
                            Dim outstanding = SafeToInt(reader("Outstanding"))
                            Dim overdue = SafeToInt(reader("Overdue"))

                            LblNumberOfTotalBooks.Text = SafeToString(reader("TotalBorrowed"))
                            LblNumberOfBooksReturned.Text = SafeToString(reader("Returned"))
                            LblNumberOfBooksOutstanding.Text = outstanding.ToString()
                            LblNumOfOverdueReturns.Text = overdue.ToString()

                            UpdateReturnRateBar(Nothing, Nothing)
                        End If
                    End Using
                End Using

                ' Room bookings
                Dim roomSql As String = "
                SELECT R.ROOM_NAME, COUNT(*) AS Bookings
                FROM TBL_ROOM_BOOKING B
                JOIN TBL_ROOM R ON B.ROOM_ID = R.ROOM_ID
                WHERE B.BOOK_DATE BETWEEN :startDate AND :endDate
                GROUP BY R.ROOM_NAME
"

                Dim roomData As New Dictionary(Of String, Integer)
                Using cmd As New OracleCommand(roomSql, conn)
                    cmd.Parameters.Add(":startDate", OracleDbType.Date).Value = startDate
                    cmd.Parameters.Add(":endDate", OracleDbType.Date).Value = endDate

                    Using reader = cmd.ExecuteReader()
                        While reader.Read()
                            roomData(reader("ROOM_NAME").ToString()) = Convert.ToInt32(reader("Bookings"))
                        End While
                    End Using
                End Using

                Dim totalBookingsSql As String = "
                    SELECT COUNT(BOOKING_ID) AS TotalBookings
                        FROM TBL_ROOM_BOOKING
                        WHERE BOOK_DATE BETWEEN :startDate AND :endDate"

                Using cmd As New OracleCommand(totalBookingsSql, conn)
                    cmd.Parameters.Add(":startDate", OracleDbType.Date).Value = startDate
                    cmd.Parameters.Add(":endDate", OracleDbType.Date).Value = endDate

                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            LblNumbersOfTotalBookings.Text = SafeToString(reader("TotalBookings"))
                        End If
                    End Using
                End Using


                UpdateRoomBars(roomData)

                ' User activity
                Dim userSql As String = "
SELECT
    (SELECT COUNT(*) 
     FROM TBL_STUDENT s
     WHERE s.STUDENT_STATUS = 'Studying'
     AND NOT EXISTS (
         SELECT 1 FROM TBL_BANNED b 
         WHERE b.USER_ID = s.STUDENT_ID
         AND b.STATUS = 'Active'
         AND b.BANNED_END_DATE >= TRUNC(SYSDATE)
     )) AS ActiveMembers,

    (SELECT COUNT(*) FROM TBL_STUDENT 
     WHERE TIME_IN BETWEEN :startDate AND :endDate) AS LibraryVisits,

    (SELECT COUNT(*) FROM TBL_BORROWING 
     WHERE RETURN_DATE IS NULL AND BORROW_DATE BETWEEN :startDate AND :endDate) AS BooksBorrowed,
    
    (
        SELECT COUNT(DISTINCT STUDENT_ID) FROM (
            SELECT STUDENT_ID FROM TBL_STUDENT WHERE TIME_IN BETWEEN :startDate AND :endDate
            UNION
            SELECT USER_ID AS STUDENT_ID FROM TBL_BORROWING 
            WHERE RETURN_DATE IS NULL AND BORROW_DATE BETWEEN :startDate AND :endDate
        )
    ) AS EngagementCount
FROM DUAL"


                Using cmd As New OracleCommand(userSql, conn)
                    cmd.Parameters.Add(":startDate", OracleDbType.Date).Value = startDate
                    cmd.Parameters.Add(":endDate", OracleDbType.Date).Value = endDate

                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            LblNumberOfActiveMembers.Text = SafeToString(reader("ActiveMembers"))
                            LblNumberOfLibraryVisits.Text = SafeToString(reader("LibraryVisits"))
                            LblNumberOfBooksBorrowed.Text = SafeToString(reader("BooksBorrowed"))
                            LblNumberOfNewRegistration.Text = SafeToString(reader("EngagementCount"))
                            UpdateEngagementBar(Nothing, Nothing)
                        End If
                    End Using
                End Using


                ' Popular categories
                Dim categorySql As String = "
SELECT BK.CATEGORY, COUNT(*) AS BorrowedCount
FROM TBL_BORROWING B
JOIN TBL_BOOKS BK ON B.BOOK_ID = BK.BOOK_ID
WHERE B.BORROW_DATE BETWEEN :startDate AND :endDate
AND BK.CATEGORY IN ('Classic Literature', 'Science and Technology', 'History', 'Fiction')
GROUP BY BK.CATEGORY"


                Using cmd As New OracleCommand(categorySql, conn)
                    cmd.Parameters.Add(":startDate", OracleDbType.Date).Value = startDate
                    cmd.Parameters.Add(":endDate", OracleDbType.Date).Value = endDate

                    Using reader = cmd.ExecuteReader()
                        ' Reset first
                        LblFOrNumberOfCL.Text = "0"
                        LblForNumbersOfST.Text = "0"
                        LblForNumberOfHistory.Text = "0"
                        LblForNumberOfFiction.Text = "0"

                        ' Then overwrite if found in query
                        While reader.Read()
                            Dim category = reader("CATEGORY").ToString()
                            Dim count = SafeToInt(reader("BorrowedCount"))
                            If CategoryStats.ContainsKey(category) Then
                                CategoryStats(category).Value = count
                            End If

                            Select Case category
                                Case "Classic Literature"
                                    LblFOrNumberOfCL.Text = count.ToString()
                                Case "Science and Technology", "Science & Technology"
                                    LblForNumbersOfST.Text = count.ToString()
                                Case "History"
                                    LblForNumberOfHistory.Text = count.ToString()
                                Case "Fiction"
                                    LblForNumberOfFiction.Text = count.ToString()
                            End Select
                        End While

                    End Using
                End Using

                ' Redraw popular categories bars
                For Each stat In CategoryStats.Values
                    SetCategoryBarProgress(stat.FillPanel, stat.Value, stat.BackPanel.Width)
                Next
                UpdatePopularCategoryBars()

            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub UpdateRoomBars(roomData As Dictionary(Of String, Integer))
        Dim totalBookings = roomData.Values.Sum()
        Dim roomPanels As New Dictionary(Of String, Panel) From {
        {"Meeting Room A", PnlFillStudyRoomA},
        {"Meeting Room B", PnlFillCollaborationSpace},
        {"Meeting Room C", PnlFillConferenceRoom},
        {"Meeting Room D", PnlFillQuietStudyRoom},
        {"Meeting Room E", PnlFillMediaLab}
    }

        For Each kvp In roomPanels
            Dim roomName = kvp.Key
            Dim fillPanel = kvp.Value
            Dim backPanel = DirectCast(fillPanel.Parent, Panel)
            Dim bookings = If(roomData.ContainsKey(roomName), roomData(roomName), 0)
            SetRoomBookingBar(fillPanel, bookings, totalBookings, backPanel.Width)
        Next
    End Sub

    ' Safely converts a database value to Integer
    Private Function SafeToInt(value As Object) As Integer
        If IsDBNull(value) OrElse value Is Nothing Then
            Return 0
        End If
        Return Convert.ToInt32(value)
    End Function

    ' Safely converts a database value to String
    Private Function SafeToString(value As Object) As String
        If IsDBNull(value) OrElse value Is Nothing Then
            Return "0"
        End If
        Return value.ToString()
    End Function

    ' Safely converts a database value to Double
    Private Function SafeToDouble(value As Object) As Double
        If IsDBNull(value) OrElse value Is Nothing Then
            Return 0.0
        End If
        Return Convert.ToDouble(value)
    End Function
End Class