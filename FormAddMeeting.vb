Imports Oracle.ManagedDataAccess.Client

Public Class FormAddMeeting
    Public Event MeetingAdded As EventHandler

    Private Sub FormAddMeeting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler TxtBookedBy.Leave, AddressOf TxtBookedBy_Leave
        roundedPanels.Clear()

        DTPFrom.Format = DateTimePickerFormat.Time
        DTPFrom.ShowUpDown = True

        DTPTo.Format = DateTimePickerFormat.Time
        DTPTo.ShowUpDown = True

        Dim paddedPanels = {
            PnlBorderBookID, PnlBorderBorrowID, PnlBorderStudentID,
            PnlBorderBorrowedDate, PnlBorderDueDate, PnlBorderReturnDate, PnlBorderStatus
        }

        For Each pnl In paddedPanels
            pnl.Padding = New Padding(3)
        Next
        PnlFill.Padding = New Padding(10)

        SetupPlaceholder(TxtBookingID, "Enter Booking ID")
        SetupPlaceholder(TxtRoomID, "Enter Room ID")
        SetupPlaceholder(TxtBookedBy, "Enter Student ID")

        roundedPanels.Add(PnlFill, 20)
        roundedPanels.Add(PnlBorderBorrowID, 5)
        roundedPanels.Add(PnlBorderStudentID, 5)
        roundedPanels.Add(PnlBorderBookID, 5)
        roundedPanels.Add(PnlBorderBorrowedDate, 5)
        roundedPanels.Add(PnlBorderDueDate, 5)
        roundedPanels.Add(PnlBorderReturnDate, 5)
        roundedPanels.Add(PnlBorderStatus, 5)
    End Sub

    Private Sub Panel_Paint(sender As Object, e As PaintEventArgs) Handles _
        PnlFill.Paint, PnlBorderBookID.Paint, PnlBorderBorrowID.Paint,
        PnlBorderStudentID.Paint, PnlBorderBorrowedDate.Paint,
        PnlBorderDueDate.Paint, PnlBorderReturnDate.Paint, PnlBorderStatus.Paint

        Dim pnl = DirectCast(sender, Panel)
        If roundedPanels.ContainsKey(pnl) Then
            MakeRoundedPanel(pnl, roundedPanels(pnl), e)
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub FormAddMeeting_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        BtnAddMeeting.Focus()
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

    Private Function GetRoomAvailabilityTime(roomId As Integer, bookDate As Date) As Date?
        Dim connStr As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"

        Try
            Using conn As New OracleConnection(connStr)
                conn.Open()
                Dim sql As String = "
                SELECT MIN(AVAILABILITY) AS AVAILABILITY 
                FROM TBL_ROOM_BOOKING 
                WHERE ROOM_ID = :roomId AND BOOK_DATE = :bookDate"

                Using cmd As New OracleCommand(sql, conn)
                    cmd.Parameters.Add(":roomId", OracleDbType.Int32).Value = roomId
                    cmd.Parameters.Add(":bookDate", OracleDbType.Date).Value = bookDate

                    Dim result = cmd.ExecuteScalar()
                    If result IsNot DBNull.Value Then
                        Return Convert.ToDateTime(result)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error fetching room availability: " & ex.Message)
        End Try

        Return Nothing
    End Function


    Private Sub BtnAddMeeting_Click(sender As Object, e As EventArgs) Handles BtnAddMeeting.Click
        Dim connStr As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"

        ' Basic validation
        If Not IsNumeric(TxtBookingID.Text) Then
            MessageBox.Show("Please enter a valid Booking ID.")
            TxtBookingID.Focus()
            Return
        End If

        If Not IsNumeric(TxtBookedBy.Text) Then
            MessageBox.Show("Please enter a valid Student ID.")
            TxtBookedBy.Focus()
            Return
        End If

        If Not IsNumeric(TxtRoomID.Text) Then
            MessageBox.Show("Please enter a valid Room ID.")
            TxtRoomID.Focus()
            Return
        End If

        Dim bookingId As Integer = Integer.Parse(TxtBookingID.Text)
        Dim roomId As Integer = Integer.Parse(TxtRoomID.Text)
        Dim studentId As Integer = Integer.Parse(TxtBookedBy.Text)

        ' Combine date + time
        Dim bookingDateOnly As Date = DTPBOOKEDDATE.Value.Date
        Dim startDateTime As Date = bookingDateOnly.Add(DTPFrom.Value.TimeOfDay)
        Dim endDateTime As Date = bookingDateOnly.Add(DTPTo.Value.TimeOfDay)
        Dim availabilityDateTime As Date = bookingDateOnly.Add(DTPNextAvailable.Value.TimeOfDay)

        ' Validate times
        If startDateTime >= endDateTime Then
            MessageBox.Show("Start time must be earlier than end time.")
            DTPFrom.Focus()
            Return
        End If

        If availabilityDateTime < endDateTime Then
            MessageBox.Show("Availability time cannot be earlier than end time.")
            DTPNextAvailable.Focus()
            Return
        End If

        Try
            Using conn As New OracleConnection(connStr)
                conn.Open()

                ' Check if student is banned
                If IsStudentBanned(studentId) Then
                    MessageBox.Show("This student is currently banned and cannot book rooms.")
                    Return
                End If

                Dim currentAvailability = GetRoomAvailabilityTime(roomId, bookingDateOnly)
                If currentAvailability.HasValue AndAlso startDateTime < currentAvailability.Value Then
                    MessageBox.Show("This room cannot be booked yet. It becomes available at " & currentAvailability.Value.ToString("hh:mm tt") & ".")
                    DTPFrom.Focus()
                    Return
                End If

                ' Check room availability
                If Not IsRoomAvailable(roomId, bookingDateOnly, startDateTime, endDateTime) Then
                        MessageBox.Show("The room is not available during the selected time period.")
                        Return
                    End If

                    ' Insert the booking if room is available
                    Dim insertSql As String = "
                INSERT INTO TBL_ROOM_BOOKING 
                (BOOKING_ID, ROOM_ID, USER_ID, BOOK_DATE, TIME_FROM, TIME_TO, AVAILABILITY) 
                VALUES 
                (:bookingId, :roomId, :userId, :bookDate, :timeFrom, :timeTo, :availability)"

                    Using cmd As New OracleCommand(insertSql, conn)
                        cmd.Parameters.Add(":bookingId", OracleDbType.Int32).Value = bookingId
                        cmd.Parameters.Add(":roomId", OracleDbType.Int32).Value = roomId
                        cmd.Parameters.Add(":userId", OracleDbType.Int32).Value = studentId
                        cmd.Parameters.Add(":bookDate", OracleDbType.Date).Value = bookingDateOnly
                        cmd.Parameters.Add(":timeFrom", OracleDbType.TimeStamp).Value = startDateTime
                        cmd.Parameters.Add(":timeTo", OracleDbType.TimeStamp).Value = endDateTime
                        cmd.Parameters.Add(":availability", OracleDbType.TimeStamp).Value = availabilityDateTime

                        Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                        If rowsAffected > 0 Then
                            MessageBox.Show("Meeting booked successfully!")
                            RaiseEvent MeetingAdded(Me, EventArgs.Empty)
                            Me.Close()
                        Else
                            MessageBox.Show("Failed to book meeting.")
                        End If
                    End Using
        End Using
        Catch ex As Exception
            MessageBox.Show("Error booking meeting: " & ex.Message)
        End Try
    End Sub

    Private Function IsRoomAvailable(roomId As Integer, bookDate As Date, startTime As Date, endTime As Date) As Boolean
        Dim connStr As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"

        Try
            Using conn As New OracleConnection(connStr)
                conn.Open()
                Dim sql As String = "
                SELECT COUNT(*) FROM TBL_ROOM_BOOKING
                WHERE ROOM_ID = :roomId
                AND BOOK_DATE = :bookDate
                AND (
                    (TIME_FROM < :endTime AND TIME_TO > :startTime)
                )"

                Using cmd As New OracleCommand(sql, conn)
                    cmd.Parameters.Add(":roomId", OracleDbType.Int32).Value = roomId
                    cmd.Parameters.Add(":bookDate", OracleDbType.Date).Value = bookDate
                    cmd.Parameters.Add(":startTime", OracleDbType.TimeStamp).Value = startTime
                    cmd.Parameters.Add(":endTime", OracleDbType.TimeStamp).Value = endTime

                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    Return count = 0 ' Room is available if no conflicting bookings found
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error checking room availability: " & ex.Message)
            Return False ' Assume not available if error occurs
        End Try
    End Function

End Class
