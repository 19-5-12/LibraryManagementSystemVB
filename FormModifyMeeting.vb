Imports Oracle.ManagedDataAccess.Client

Public Class FormModifyMeeting

    Public Event MeetingModified As EventHandler
    Private Sub FormModifyMeeting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler TxtBookedBy.Leave, AddressOf TxtBookedBy_Leave
        roundedPanels.Clear()

        DTPFrom.Format = DateTimePickerFormat.Time
        DTPFrom.ShowUpDown = True

        DTPTo.Format = DateTimePickerFormat.Time
        DTPTo.ShowUpDown = True

        Dim paddedPanels = {
            PnlBorderBookID, PnlBorderBorrowID, PnlBorderStudentID,
            PnlBorderBorrowedDate, PnlBorderDueDate, PnlBorderReturnDate, PnlBorderStatus, PnlBorderSelectID
        }

        For Each pnl In paddedPanels
            pnl.Padding = New Padding(3)
        Next
        PnlFill.Padding = New Padding(10)

        SetupPlaceholder(TxtBookingID, "Enter Booking ID")
        SetupPlaceholder(TxtRoomID, "Enter Room ID")
        SetupPlaceholder(TxtBookedBy, "Enter Student ID")
        SetupPlaceholder(TxtSelectID, "Enter Booking ID to modify")

        roundedPanels.Add(PnlFill, 20)
        roundedPanels.Add(PnlBorderBorrowID, 5)
        roundedPanels.Add(PnlBorderStudentID, 5)
        roundedPanels.Add(PnlBorderBookID, 5)
        roundedPanels.Add(PnlBorderBorrowedDate, 5)
        roundedPanels.Add(PnlBorderDueDate, 5)
        roundedPanels.Add(PnlBorderReturnDate, 5)
        roundedPanels.Add(PnlBorderStatus, 5)
        roundedPanels.Add(PnlBorderSelectID, 5)
    End Sub

    Private Sub Panel_Paint(sender As Object, e As PaintEventArgs) Handles _
        PnlFill.Paint, PnlBorderBookID.Paint, PnlBorderBorrowID.Paint,
        PnlBorderStudentID.Paint, PnlBorderBorrowedDate.Paint,
        PnlBorderDueDate.Paint, PnlBorderReturnDate.Paint, PnlBorderStatus.Paint, PnlBorderSelectID.Paint

        Dim pnl = DirectCast(sender, Panel)
        If roundedPanels.ContainsKey(pnl) Then
            MakeRoundedPanel(pnl, roundedPanels(pnl), e)
        End If
    End Sub

    Private Sub TxtSelectID_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtSelectID.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            LoadMeetingDataByID()
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub FormModifyMeeting_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        BtnSave.Focus()
    End Sub

    Private Function IsStudentBanned(studentId As Integer) As Boolean
        Dim connStr As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"
        Try
            Using conn As New OracleConnection(connStr)
                conn.Open()
                Dim bannedCheckSql As String = "
                SELECT COUNT(*) FROM TBL_BANNED 
                WHERE USER_ID = :studentId 
                AND STATUS = 'Active' 
                AND BANNED_END_DATE >= TRUNC(SYSDATE)"

                Using cmd As New OracleCommand(bannedCheckSql, conn)
                    cmd.Parameters.Add(":studentId", OracleDbType.Int32).Value = studentId
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    Return count > 0
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error checking banned status: " & ex.Message)
            Return False
        End Try
    End Function

    Private Sub TxtBookedBy_Leave(sender As Object, e As EventArgs) Handles TxtBookedBy.Leave
        If Not IsNumeric(TxtBookedBy.Text) Then
            Return
        End If

        Dim studentId As Integer = Integer.Parse(TxtBookedBy.Text)

        If IsStudentBanned(studentId) Then
            MessageBox.Show("This student is currently banned and cannot book rooms.")
            TxtBookedBy.Clear()
            TxtBookedBy.Focus()
        End If
    End Sub

    Private Sub DTPTo_ValueChanged(sender As Object, e As EventArgs) Handles DTPTo.ValueChanged
        If DTPFrom.Value.TimeOfDay >= DTPTo.Value.TimeOfDay Then
            ' Auto-adjust start time to be 30 minutes before end time (or 1 minute earlier if close)
            Dim adjustedStart = DTPTo.Value.AddMinutes(-30)
            If adjustedStart < DTPFrom.MinDate Then adjustedStart = DTPTo.Value.AddMinutes(-1)
            DTPFrom.Value = adjustedStart
        End If
    End Sub

    Private Sub LoadMeetingDataByID()
        Dim connStr As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"
        Dim bookingIdStr As String = TxtSelectID.Text.Trim()

        If Not IsNumeric(bookingIdStr) Then
            MessageBox.Show("Please enter a valid numeric Booking ID.")
            Return
        End If

        Dim bookingId As Integer = Integer.Parse(bookingIdStr)

        Try
            Using conn As New OracleConnection(connStr)
                conn.Open()
                Dim sql As String = "SELECT BOOKING_ID, ROOM_ID, USER_ID, BOOK_DATE, TIME_FROM, TIME_TO, AVAILABILITY
                                FROM TBL_ROOM_BOOKING 
                                WHERE BOOKING_ID = :bookingId"

                Using cmd As New OracleCommand(sql, conn)
                    cmd.Parameters.Add(":bookingId", OracleDbType.Int32).Value = bookingId

                    Using reader As OracleDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            TxtBookingID.Text = If(reader("BOOKING_ID") IsNot DBNull.Value, reader("BOOKING_ID").ToString(), "")
                            TxtBookingID.ForeColor = SystemColors.WindowText
                            TxtRoomID.Text = If(reader("ROOM_ID") IsNot DBNull.Value, reader("ROOM_ID").ToString(), "")
                            TxtRoomID.ForeColor = SystemColors.WindowText
                            TxtBookedBy.Text = If(reader("USER_ID") IsNot DBNull.Value, reader("USER_ID").ToString(), "")
                            TxtBookedBy.ForeColor = SystemColors.WindowText

                            Dim bookDate As Date = If(reader("BOOK_DATE") IsNot DBNull.Value, Convert.ToDateTime(reader("BOOK_DATE")), Date.Today)
                            Dim timeFrom As Date = If(reader("TIME_FROM") IsNot DBNull.Value, Convert.ToDateTime(reader("TIME_FROM")), Date.Now)
                            Dim timeTo As Date = If(reader("TIME_TO") IsNot DBNull.Value, Convert.ToDateTime(reader("TIME_TO")), Date.Now.AddHours(1))
                            Dim availability As Date = If(reader("AVAILABILITY") IsNot DBNull.Value, Convert.ToDateTime(reader("AVAILABILITY")), Date.Now)

                            DTPFrom.Value = bookDate.Date.Add(timeFrom.TimeOfDay)
                            DTPTo.Value = bookDate.Date.Add(timeTo.TimeOfDay)
                            DTPNextAvailable.Value = availability
                        Else
                            MessageBox.Show("Booking ID not found.")
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading booking: " & ex.Message)
        End Try
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim connStr As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"

        ' Input validation
        If String.IsNullOrWhiteSpace(TxtBookingID.Text) OrElse Not IsNumeric(TxtBookingID.Text) Then
            MessageBox.Show("Please enter a valid Booking ID.")
            TxtBookingID.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(TxtRoomID.Text) OrElse Not IsNumeric(TxtRoomID.Text) Then
            MessageBox.Show("Please enter a valid Room ID.")
            TxtRoomID.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(TxtBookedBy.Text) OrElse Not IsNumeric(TxtBookedBy.Text) Then
            MessageBox.Show("Please enter a valid Student ID.")
            TxtBookedBy.Focus()
            Return
        End If

        Dim bookingId As Integer = Integer.Parse(TxtBookingID.Text)
        Dim roomId As Integer = Integer.Parse(TxtRoomID.Text)
        Dim studentId As Integer = Integer.Parse(TxtBookedBy.Text)

        ' Check if student is banned before saving
        If IsStudentBanned(studentId) Then
            MessageBox.Show("This student is currently banned and cannot be assigned to the booking.")
            TxtBookedBy.Focus()
            Return
        End If

        ' Combine date + time
        Dim bookingDateOnly As Date = DTPFrom.Value.Date
        Dim startDateTime As Date = bookingDateOnly.Add(DTPFrom.Value.TimeOfDay)
        Dim endDateTime As Date = bookingDateOnly.Add(DTPTo.Value.TimeOfDay)
        Dim availabilityTime As Date = DTPNextAvailable.Value

        If startDateTime >= endDateTime Then
            MessageBox.Show("Start time must be earlier than end time.")
            DTPFrom.Focus()
            Return
        End If

        ' Validate availability time
        If availabilityTime < endDateTime Then
            MessageBox.Show("Availability time cannot be earlier than meeting end time. Adjusting to meeting end time.")
            DTPNextAvailable.Value = endDateTime
            availabilityTime = endDateTime
        End If

        If Not IsRoomAvailabilityReached(roomId, startDateTime) Then
            MessageBox.Show("This room is not yet available at the selected start time. Please choose a later time.")
            Return
        End If


        Try
            Using conn As New OracleConnection(connStr)
                conn.Open()

                Dim updateSql As String = "UPDATE TBL_ROOM_BOOKING " &
    "SET ROOM_ID = :roomId, " &
    "USER_ID = :studentId, " &
    "BOOK_DATE = :bookDate, " &
    "TIME_FROM = :timeFrom, " &
    "TIME_TO = :timeTo, " &
    "AVAILABILITY = :availability " &
    "WHERE BOOKING_ID = :bookingId"


                Using cmd As New OracleCommand(updateSql, conn)
                    cmd.Parameters.Add(":roomId", OracleDbType.Int32).Value = roomId
                    cmd.Parameters.Add(":studentId", OracleDbType.Int32).Value = studentId
                    cmd.Parameters.Add(":bookDate", OracleDbType.Date).Value = bookingDateOnly
                    cmd.Parameters.Add(":timeFrom", OracleDbType.TimeStamp).Value = startDateTime
                    cmd.Parameters.Add(":timeTo", OracleDbType.TimeStamp).Value = endDateTime
                    cmd.Parameters.Add(":availability", OracleDbType.TimeStamp).Value = availabilityTime
                    cmd.Parameters.Add(":bookingId", OracleDbType.Int32).Value = bookingId

                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        MessageBox.Show("Meeting modified successfully.")
                        RaiseEvent MeetingModified(Me, EventArgs.Empty)
                        Me.Close()
                    Else
                        MessageBox.Show("No meeting was updated. Please check the Booking ID.")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error modifying meeting: " & ex.Message)
        End Try
    End Sub

    Private Function IsRoomAvailabilityReached(roomId As Integer, desiredStartTime As Date) As Boolean
        Dim connStr As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"
        Try
            Using conn As New OracleConnection(connStr)
                conn.Open()
                ' Modified SQL query to work with all Oracle versions
                Dim sql As String = "SELECT MAX(AVAILABILITY) FROM TBL_ROOM_BOOKING 
                              WHERE ROOM_ID = :roomId"

                Using cmd As New OracleCommand(sql, conn)
                    cmd.Parameters.Add(":roomId", OracleDbType.Int32).Value = roomId
                    Dim availabilityObj = cmd.ExecuteScalar()

                    If availabilityObj IsNot Nothing AndAlso Not IsDBNull(availabilityObj) Then
                        Dim availabilityTime As Date = Convert.ToDateTime(availabilityObj)
                        Return desiredStartTime >= availabilityTime
                    Else
                        ' If no availability info is found, assume it's allowed
                        Return True
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error checking room availability time: " & ex.Message)
            Return False
        End Try
    End Function



End Class