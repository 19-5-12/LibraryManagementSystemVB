Imports Oracle.ManagedDataAccess.Client

Public Class CFMeetingRooms
    Private SelectedStartDate As Date?
    Private SelectedEndDate As Date?

    Private Sub CFMeetingRooms_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim CRUDBtns As Button() = {BtnViewStats}
        SetupFormUI(CRUDBtns, DataGridView1, TimerDateTime, LblDateTimeMeeting, AddressOf LoadMeetingData)

        TBLPMeeting.Padding = New Padding(3)

        ' Initialize date pickers
        DateTimePickerStart.MaxDate = DateTime.Today
        DateTimePickerEnd.MaxDate = DateTime.Today

        ' Hide date panels initially
        PnlDateStart.Visible = False
        PnlDateEnd.Visible = False

        ' Setup ComboSearchDate
        ComboSearchDate.Items.Insert(0, "Select Date Range")
        ComboSearchDate.SelectedIndex = 0

        ' Show all records on load
        LoadMeetingData()
    End Sub

    Private Sub LoadMeetingData(Optional filterByDate As Boolean = False)
        Dim connectionString As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"
        Dim dt As New DataTable()

        ' Update all statuses that are neither Confirmed nor Declined to Pending
        Using conn As New OracleConnection(connectionString)
            conn.Open()
            Dim updateQuery As String = "UPDATE TBL_ROOM_BOOKING SET STATUS = 'Pending' WHERE STATUS NOT IN ('Confirmed', 'Declined') OR STATUS IS NULL"
            Using updateCmd As New OracleCommand(updateQuery, conn)
                updateCmd.ExecuteNonQuery()
            End Using
        End Using

        Dim query As String = "
        SELECT 
            B.BOOKING_ID AS ""Booking ID"",
            R.ROOM_NAME AS ""Room Name"",
            S.FIRST_NAME || ' ' || S.LAST_NAME AS ""Booked By"",
            B.BOOK_DATE AS ""Booked Date"",
            B.TIME_FROM AS ""Time From"",
            B.TIME_TO AS ""Time To"",
            B.STATUS AS ""STATUS""
        FROM TBL_ROOM_BOOKING B
        JOIN TBL_ROOM R ON B.ROOM_ID = R.ROOM_ID
        JOIN TBL_STUDENT S ON B.USER_ID = S.STUDENT_ID"
        If filterByDate AndAlso SelectedStartDate.HasValue AndAlso SelectedEndDate.HasValue Then
            query &= " WHERE B.BOOK_DATE BETWEEN :startDate AND :endDate"
        End If
        query &= " ORDER BY B.BOOK_DATE DESC, B.TIME_FROM"

        Using conn As New OracleConnection(connectionString)
            Dim cmd As New OracleCommand(query, conn)
            If filterByDate AndAlso SelectedStartDate.HasValue AndAlso SelectedEndDate.HasValue Then
                cmd.Parameters.Add(":startDate", OracleDbType.Date).Value = SelectedStartDate.Value
                cmd.Parameters.Add(":endDate", OracleDbType.Date).Value = SelectedEndDate.Value
            End If
            Dim adapter As New OracleDataAdapter(cmd)

            adapter.Fill(dt)

            ' Ensure STATUS values match ComboBox options
            For Each row As DataRow In dt.Rows
                If row.IsNull("STATUS") OrElse Not {"Pending", "Confirmed", "Declined"}.Contains(row("STATUS").ToString()) Then
                    row("STATUS") = "Pending"
                End If
            Next

            DataGridView1.DataSource = Nothing
            DataGridView1.Columns.Clear()
            DataGridView1.AutoGenerateColumns = False

            ' Add columns
            DataGridView1.Columns.Add(New DataGridViewTextBoxColumn() With {
                .DataPropertyName = "Booking ID",
                .HeaderText = "Booking ID",
                .Name = "Booking ID",
                .ReadOnly = True
            })
            DataGridView1.Columns.Add(New DataGridViewTextBoxColumn() With {
                .DataPropertyName = "Room Name",
                .HeaderText = "Room Name",
                .Name = "Room Name",
                .ReadOnly = True
            })
            DataGridView1.Columns.Add(New DataGridViewTextBoxColumn() With {
                .DataPropertyName = "Booked By",
                .HeaderText = "Booked By",
                .Name = "Booked By",
                .ReadOnly = True
            })
            DataGridView1.Columns.Add(New DataGridViewTextBoxColumn() With {
                .DataPropertyName = "Booked Date",
                .HeaderText = "Booked Date",
                .Name = "Booked Date",
                .ReadOnly = True
            })
            DataGridView1.Columns.Add(New DataGridViewTextBoxColumn() With {
                .DataPropertyName = "Time From",
                .HeaderText = "Time From",
                .Name = "Time From",
                .ReadOnly = True
            })
            DataGridView1.Columns.Add(New DataGridViewTextBoxColumn() With {
                .DataPropertyName = "Time To",
                .HeaderText = "Time To",
                .Name = "Time To",
                .ReadOnly = True
            })

            ' Add Status ComboBox column
            Dim statusCol As New DataGridViewComboBoxColumn() With {
                .DataPropertyName = "STATUS",
                .HeaderText = "Status",
                .Name = "STATUS",
                .DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton,
                .FlatStyle = FlatStyle.Flat,
                .ReadOnly = False,
                .DisplayStyleForCurrentCellOnly = True
            }
            statusCol.Items.Add("Pending")
            statusCol.Items.Add("Confirmed")
            statusCol.Items.Add("Declined")
            DataGridView1.Columns.Add(statusCol)

            DataGridView1.DataSource = dt
        End Using
    End Sub

    Private Sub TBLPMeeting_Paint(sender As Object, e As PaintEventArgs) Handles TBLPMeeting.Paint
        StyleShadowPanel(CType(sender, Panel), e)
    End Sub

    Private Sub MeetingAddedHandler(sender As Object, e As EventArgs)
        LoadMeetingData()
    End Sub

    Private Sub BtnModify_Click(sender As Object, e As EventArgs)
        Dim addForm As New FormModifyMeeting
        AddHandler addForm.MeetingModified, AddressOf MeetingModifiedHandler
        addForm.ShowDialog()
        RemoveHandler addForm.MeetingModified, AddressOf MeetingModifiedHandler
    End Sub

    Private Sub MeetingModifiedHandler(sender As Object, e As EventArgs)
        LoadMeetingData()
    End Sub

    Private Sub MeetingDeletedHandler(sender As Object, e As EventArgs)
        LoadMeetingData()
    End Sub

    Private Sub BtnViewStats_Click_1(sender As Object, e As EventArgs) Handles BtnViewStats.Click
        If ComboSearchDate.SelectedItem IsNot Nothing AndAlso ComboSearchDate.SelectedItem.ToString = "Custom Range" Then
            SelectedStartDate = DateTimePickerStart.Value.Date
            SelectedEndDate = DateTimePickerEnd.Value.Date
        End If

        If SelectedStartDate.HasValue AndAlso SelectedEndDate.HasValue Then
            LoadMeetingData(True)
        Else
            MessageBox.Show("Please select a valid date range first.")
        End If
    End Sub

    Private Sub ComboSearchDate_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ComboSearchDate.SelectedIndexChanged
        If ComboSearchDate.SelectedIndex = 0 Then
            SelectedStartDate = Nothing
            SelectedEndDate = Nothing
            PnlDateStart.Visible = False
            PnlDateEnd.Visible = False
            Exit Sub
        End If

        Dim startDate As Date
        Dim endDate = Date.Today

        Select Case ComboSearchDate.SelectedItem.ToString
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

    ' Add this handler to save status changes
    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        If e.RowIndex >= 0 AndAlso DataGridView1.Columns(e.ColumnIndex).Name = "STATUS" Then
            Dim bookingId = DataGridView1.Rows(e.RowIndex).Cells("Booking ID").Value
            Dim newStatus = DataGridView1.Rows(e.RowIndex).Cells("STATUS").Value.ToString()
            UpdateStatusInDatabase(bookingId, newStatus)
        End If
    End Sub

    ' Add this to commit edits immediately when ComboBox changes
    Private Sub DataGridView1_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DataGridView1.CurrentCellDirtyStateChanged
        If DataGridView1.IsCurrentCellDirty Then
            DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    ' Update the database with the new status
    Private Sub UpdateStatusInDatabase(bookingId As Object, newStatus As String)
        Dim connectionString As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"
        Dim query As String = "UPDATE TBL_ROOM_BOOKING SET STATUS = :status WHERE BOOKING_ID = :bookingId"
        Using conn As New OracleConnection(connectionString)
            conn.Open()
            Using cmd As New OracleCommand(query, conn)
                cmd.Parameters.Add(":status", OracleDbType.Varchar2).Value = newStatus
                cmd.Parameters.Add(":bookingId", OracleDbType.Int32).Value = Convert.ToInt32(bookingId)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

End Class