﻿Imports Oracle.ManagedDataAccess.Client

Public Class FormAddStudent
    Public Event AttendanceAdded As EventHandler

    Private Sub FormAddStudent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        roundedPanels.Clear()

        ' Set default status based on current time
        SetDefaultStatus()
        ComboStatus.SelectedIndex = 0

        ' Set date to current date
        DTPDate.Value = DateTime.Now.Date
        DTPDate.MaxDate = DateTime.Now.Date

        Dim paddedPanels = {PnlBorderBookID, PnlBorderBorrowID, PnlBorderStudentID, PnlBorderBorrowedDate,
            PnlBorderDueDate}
        For Each pnl In paddedPanels
            pnl.Padding = New Padding(3)
        Next
        PnlFill.Padding = New Padding(10)

        ' Generate and set Attendance ID
        GenerateAttendanceID()
        TxtAttendanceID.ReadOnly = True
        UIHelpers.SetupPlaceholder(TxtStudentID, "Enter Student ID")

        roundedPanels.Add(PnlFill, 20)
        roundedPanels.Add(PnlBorderBorrowID, 5)
        roundedPanels.Add(PnlBorderStudentID, 5)
        roundedPanels.Add(PnlBorderBookID, 5)
        roundedPanels.Add(PnlBorderBorrowedDate, 5)
        roundedPanels.Add(PnlBorderDueDate, 5)

        ' Set up time picker
        DTPTimeIn.Format = DateTimePickerFormat.Time
        DTPTimeIn.ShowUpDown = True
        DTPTimeIn.Value = DateTime.Now

        ' Make fields read-only except Student ID
        DTPDate.Enabled = False
        DTPTimeIn.Enabled = False
        ComboStatus.Enabled = False
    End Sub

    Private Sub SetDefaultStatus()
        ' Clear existing items
        ComboStatus.Items.Clear()

        ' Add the two possible statuses
        ComboStatus.Items.Add("Currently In")
        ComboStatus.Items.Add("Timed Out")

        ' Set default based on current time
        ' Assuming library hours are 8 AM to 5 PM
        Dim currentHour = DateTime.Now.Hour
        If currentHour >= 8 AndAlso currentHour < 17 Then
            ComboStatus.SelectedIndex = 0 ' Currently In
        Else
            ComboStatus.SelectedIndex = 1 ' Timed Out
        End If
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

    Private Sub GenerateAttendanceID()
        Dim connStr As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"
        Try
            Using conn As New OracleConnection(connStr)
                conn.Open()
                Dim query As String = "SELECT NVL(MAX(ATTENDANCE_ID), 0) + 1 FROM TBL_ATTENDANCE"
                Using cmd As New OracleCommand(query, conn)
                    Dim newID As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    TxtAttendanceID.Text = newID.ToString()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error generating Attendance ID: " & ex.Message)
            TxtAttendanceID.Text = "0" ' Set a default value if there's an error
        End Try
    End Sub

    Private Function ValidateInputs() As Boolean
        If Not IsNumeric(TxtStudentID.Text) Then
            MessageBox.Show("Please enter a valid Student ID.")
            TxtStudentID.Focus()
            Return False
        End If

        Return True
    End Function

    Private Function InsertAttendanceRecord() As Boolean
        Dim connStr As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"
        Dim status As String = ComboStatus.SelectedItem.ToString() ' Get the selected status

        Try
            Using conn As New OracleConnection(connStr)
                conn.Open()

                ' 🔍 Check if Student ID exists in TBL_STUDENT
                Dim studentExistsSql As String = "SELECT COUNT(*) FROM TBL_STUDENT WHERE STUDENT_ID = :studentId"
                Using checkCmd As New OracleCommand(studentExistsSql, conn)
                    checkCmd.Parameters.Add(":studentId", OracleDbType.Int32).Value = Integer.Parse(TxtStudentID.Text)
                    Dim studentExists As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
                    If studentExists = 0 Then
                        MessageBox.Show("Student ID not found. Please enter a valid student.", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return False
                    End If
                End Using

                ' 🚫 Check if student is actively banned
                Dim bannedCheckSql As String = "SELECT COUNT(*) FROM TBL_BANNED " &
                                          "WHERE USER_ID = :studentId " &
                                          "AND STATUS = 'Active' " &
                                          "AND BANNED_END_DATE >= TRUNC(SYSDATE)"

                Using bannedCmd As New OracleCommand(bannedCheckSql, conn)
                    bannedCmd.Parameters.Add(":studentId", OracleDbType.Int32).Value = Integer.Parse(TxtStudentID.Text)
                    Dim bannedCount As Integer = Convert.ToInt32(bannedCmd.ExecuteScalar())

                    If bannedCount > 0 Then
                        MessageBox.Show("This student is currently banned and cannot record attendance.",
                                  "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return False
                    End If
                End Using

                ' ✅ Proceed with insert
                Dim insertSql As String = "INSERT INTO TBL_ATTENDANCE " &
                                    "(ATTENDANCE_ID, STUDENT_ID, ATTENDANCE_DATE, TIME_IN, STATUS) " &
                                    "VALUES (:attendance_id, :student_id, :attendance_date, :time_in, :status)"

                Using cmd As New OracleCommand(insertSql, conn)
                    cmd.Parameters.Add(":attendance_id", OracleDbType.Int32).Value = Integer.Parse(TxtAttendanceID.Text)
                    cmd.Parameters.Add(":student_id", OracleDbType.Int32).Value = Integer.Parse(TxtStudentID.Text)
                    cmd.Parameters.Add(":attendance_date", OracleDbType.Date).Value = DateTime.Now.Date
                    cmd.Parameters.Add(":time_in", OracleDbType.TimeStamp).Value = DateTime.Now
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