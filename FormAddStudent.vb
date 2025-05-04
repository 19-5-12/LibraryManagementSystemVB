Imports Oracle.ManagedDataAccess.Client

Public Class FormAddStudent
    Public Event AttendanceAdded As EventHandler

    Private Sub FormAddStudent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        roundedPanels.Clear()

        ComboStatus.Items.Insert(0, "Select Status")
        ComboStatus.SelectedIndex = 0

        DTPDate.MaxDate = DateTime.Now.Date

        Dim paddedPanels = {PnlBorderBookID, PnlBorderBorrowID, PnlBorderStudentID, PnlBorderBorrowedDate,
            PnlBorderDueDate}
        For Each pnl In paddedPanels
            pnl.Padding = New Padding(3)
        Next
        PnlFill.Padding = New Padding(10)

        SetupPlaceholder(TxtAttendanceID, "Enter Attendance ID")
        SetupPlaceholder(TxtStudentID, "Enter Student ID")

        roundedPanels.Add(PnlFill, 20)
        roundedPanels.Add(PnlBorderBorrowID, 5)
        roundedPanels.Add(PnlBorderStudentID, 5)
        roundedPanels.Add(PnlBorderBookID, 5)
        roundedPanels.Add(PnlBorderBorrowedDate, 5)
        roundedPanels.Add(PnlBorderDueDate, 5)

        DTPTimeIn.Format = DateTimePickerFormat.Time
        DTPTimeIn.ShowUpDown = True
        DTPTimeIn.Value = DateTime.Now
    End Sub

    Private Sub Panel_Paint(sender As Object, e As PaintEventArgs) Handles PnlFill.Paint, PnlBorderBookID.Paint,
        PnlBorderBorrowID.Paint, PnlBorderStudentID.Paint, PnlBorderBorrowedDate.Paint, PnlBorderDueDate.Paint

        Dim pnl = DirectCast(sender, Panel)
        If roundedPanels.ContainsKey(pnl) Then
            MakeRoundedPanel(pnl, roundedPanels(pnl), e)
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub FormAddStudent_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        BtnAddAttendance.Focus()
    End Sub

    Private Function ValidateInputs() As Boolean
        If Not IsNumeric(TxtStudentID.Text) Then
            MessageBox.Show("Please enter a valid Student ID.")
            TxtStudentID.Focus()
            Return False
        End If

        If ComboStatus.SelectedIndex = 0 Then
            MessageBox.Show("Please select a valid status.")
            ComboStatus.Focus()
            Return False
        End If

        If DTPDate.Value.Date <> DTPTimeIn.Value.Date Then
            MessageBox.Show("Date and Time In must be on the same day.")
            DTPTimeIn.Focus()
            Return False
        End If

        Return True
    End Function


    Private Function InsertAttendanceRecord() As Boolean
        Dim connStr As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"
        Dim status As String = ComboStatus.SelectedItem.ToString()

        Dim insertSql As String = "INSERT INTO TBL_ATTENDANCE (ATTENDANCE_ID, STUDENT_ID, ATTENDANCE_DATE, TIME_IN, STATUS) " &
                                  "VALUES (:attendance_id, :student_id, :attendance_date, :time_in, :status)"

        Try
            Using conn As New OracleConnection(connStr)
                conn.Open()

                Using cmd As New OracleCommand(insertSql, conn)
                    cmd.Parameters.Add(":attendance_id", OracleDbType.Int32).Value = Integer.Parse(TxtAttendanceID.Text)
                    cmd.Parameters.Add(":student_id", OracleDbType.Int32).Value = Integer.Parse(TxtStudentID.Text)
                    cmd.Parameters.Add(":attendance_date", OracleDbType.Date).Value = DTPDate.Value.Date
                    Dim fullDateTime As DateTime = DTPDate.Value.Date + DTPTimeIn.Value.TimeOfDay
                    cmd.Parameters.Add(":time_in", OracleDbType.TimeStamp).Value = fullDateTime
                    cmd.Parameters.Add(":status", OracleDbType.Varchar2).Value = status

                    Dim result = cmd.ExecuteNonQuery()
                    If result = 0 Then
                        MessageBox.Show("Failed to add attendance record.")
                        Return False
                    End If
                End Using

                MessageBox.Show("Attendance record added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                RaiseEvent AttendanceAdded(Me, EventArgs.Empty)
                Me.Close()
                Return True
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Private Sub BtnAddAttendance_Click(sender As Object, e As EventArgs) Handles BtnAddAttendance.Click
        If ValidateInputs() Then
            InsertAttendanceRecord()
        End If
    End Sub

    Private Sub TxtStudentID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtStudentID.KeyPress
        ' Allow only digits and control characters like Backspace
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtAttendanceID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtAttendanceID.KeyPress
        ' Allow only digits and control characters like Backspace
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

End Class
