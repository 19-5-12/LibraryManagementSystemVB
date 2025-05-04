Imports System.Configuration
Imports Oracle.ManagedDataAccess.Client
Public Class CFReport
    Private SelectedStartDate As Date?
    Private SelectedEndDate As Date?

    Private CategoryStats As New Dictionary(Of String, CategoryStat)
    Private Sub CFReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        ComboSearchDate.Items.Insert(0, "Select Date")
        ComboSearchDate.SelectedIndex = 0

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

    Private Sub BtnViewStats_Click(sender As Object, e As EventArgs) Handles BtnViewStats.Click
        If SelectedStartDate.HasValue AndAlso SelectedEndDate.HasValue Then
            LoadStats(SelectedStartDate.Value, SelectedEndDate.Value)
        Else
            MessageBox.Show("Please select a valid date range first.")
        End If
    End Sub

    Private Sub ComboSearchDate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboSearchDate.SelectedIndexChanged
        If ComboSearchDate.SelectedIndex = 0 Then
            SelectedStartDate = Nothing
            SelectedEndDate = Nothing
            Exit Sub
        End If

        Dim startDate As Date
        Dim endDate As Date = Date.Today

        Select Case ComboSearchDate.SelectedItem.ToString()
            Case "Today"
                startDate = Date.Today
            Case "This Week"
                startDate = Date.Today.AddDays(-CInt(Date.Today.DayOfWeek))
            Case "This Month"
                startDate = New Date(Date.Today.Year, Date.Today.Month, 1)
            Case "This Year"
                startDate = New Date(Date.Today.Year, 1, 1)
            Case "Custom Range"
                MessageBox.Show("Custom range not implemented yet.")
                Exit Sub
            Case Else
                Exit Sub
        End Select

        SelectedStartDate = startDate
        SelectedEndDate = endDate

    End Sub

    Private Sub LoadStats(startDate As Date, endDate As Date)
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

                            LblNumberOfTotalBooks.Text = total.ToString()
                            LblNumberOfBooksReturned.Text = returned.ToString()
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
                    (SELECT COUNT(*) FROM TBL_STUDENT WHERE STUDENT_STATUS = 'Studying') AS ActiveMembers,
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
                            LblNumberOfNewRegistration.Text = SafeToString(reader("EngagementCount")) ' if you still want NewRegistrations, you'll need to re-add it
                            UpdateEngagementBar(Nothing, Nothing)
                        End If
                    End Using
                End Using

                ' Popular categories
                Dim categorySql As String = "
SELECT C.CATEGORY_NAME, COUNT(*) AS BorrowedCount
FROM TBL_BORROWING B
JOIN TBL_BOOK BK ON B.BOOK_ID = BK.BOOK_ID
JOIN TBL_CATEGORY C ON BK.CATEGORY_ID = C.CATEGORY_ID
WHERE B.BORROW_DATE BETWEEN :startDate AND :endDate
AND C.CATEGORY_NAME IN ('Classic Literature', 'Science and Technology', 'History', 'Fiction')
GROUP BY C.CATEGORY_NAME
"

                Using cmd As New OracleCommand(categorySql, conn)
                    cmd.Parameters.Add(":startDate", OracleDbType.Date).Value = startDate
                    cmd.Parameters.Add(":endDate", OracleDbType.Date).Value = endDate

                    Using reader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim category = reader("CATEGORY_NAME").ToString()
                            Dim count = SafeToInt(reader("BorrowedCount"))

                            If CategoryStats.ContainsKey(category) Then
                                CategoryStats(category).Value = count
                            End If
                        End While
                    End Using
                End Using

                ' Redraw popular categories bars
                For Each stat In CategoryStats.Values
                    SetCategoryBarProgress(stat.FillPanel, stat.Value, stat.BackPanel.Width)
                Next


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
            Return String.Empty
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