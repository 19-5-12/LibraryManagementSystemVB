Imports Oracle.ManagedDataAccess.Client
Public Class CFDashboard
    Private Sub CFDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim panelsToStyle As Panel() = {
        PnlTotalBooks,
        PnlBorrowed,
        PnlActMem,
        PnlOverdue,
        PnlImageTotalBooks,
        PnlImageBooksBorrowed,
        PnlImageActMem,
        PnlIMageOverdue
    }

        For Each pnl In panelsToStyle
            AddHandler pnl.Paint, Sub(s, eArgs) StyleShadowPanel(DirectCast(s, Panel), eArgs)
            AddHandler pnl.Resize, Sub() pnl.Invalidate()
        Next

        TimerDateTime.Interval = 1000
        TimerDateTime.Start()
        UpdateTimeLabel()
        LoadOverdueReturnsCount()

        LoadAttendanceData()
        LoadBorrowedBooksCount()
        LoadTotalBooksQuantity()
        LoadActiveStudentsCount()

        DataGridView1.EnableHeadersVisualStyles = False
        SetDataGridHeaderWhite(DataGridView1)

        TLPRecentStudentAttendance.Padding = New Padding(3)

        AddHandler DataGridView1.CellFormatting, AddressOf DataGridView1_CellFormatting
    End Sub

    Private Sub TimerDateTime_Tick(sender As Object, e As EventArgs) Handles TimerDateTime.Tick
        UpdateTimeLabel()
    End Sub
    Private Sub UpdateTimeLabel()
        LblDateTime.Text = DateTime.Now.ToString("MMMM dd, yyyy - hh:mm:ss tt")
    End Sub

    Public Sub LoadAttendanceData()
        AddHandler DataGridView1.CellClick, AddressOf DataGridView1_CellClick

        Dim connectionString As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"
        Dim query As String = "SELECT a.ATTENDANCE_ID as ""Attendance ID"", " &
                          "a.STUDENT_ID as ""Student ID"", " &
                          "s.LAST_NAME || ', ' || s.FIRST_NAME || ' ' || SUBSTR(s.MIDDLE_NAME, 1, 1) || '.' as ""Student Name"", " &
                          "TO_CHAR(a.ATTENDANCE_DATE, 'DD/MM/YYYY') AS ""Date"", " &
                          "TO_CHAR(a.TIME_IN, 'HH:MI AM') AS ""Time In"", " &
                          "TO_CHAR(a.TIME_OUT, 'HH:MI AM') as ""Time Out"", " &
                          "a.STATUS as ""Status"" " &
                          "FROM TBL_ATTENDANCE a " &
                          "JOIN TBL_STUDENT s ON a.STUDENT_ID = s.STUDENT_ID " &
                          "ORDER BY a.ATTENDANCE_DATE DESC, a.TIME_IN DESC"

        Using conn As New OracleConnection(connectionString)
            Dim cmd As New OracleCommand(query, conn)
            Dim adapter As New OracleDataAdapter(cmd)
            Dim dt As New DataTable()

            Try
                adapter.Fill(dt)
                DataGridView1.DataSource = dt
            Catch ex As Exception
                MessageBox.Show("Error loading attendance data: " & ex.Message)
            End Try
        End Using

        DataGridView1.Refresh()
    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        If DataGridView1.Columns(e.ColumnIndex).Name = "Status" AndAlso e.Value IsNot Nothing Then
            Dim status = e.Value.ToString()
            Dim cellStyle = e.CellStyle

            If status = "Currently In" Then
                cellStyle.ForeColor = Color.Green
            ElseIf status = "Checked Out" Then
                cellStyle.ForeColor = Color.Red
            End If

            ' Prevent selection from overriding your color
            cellStyle.SelectionForeColor = cellStyle.ForeColor
            cellStyle.SelectionBackColor = DataGridView1.DefaultCellStyle.BackColor
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 AndAlso DataGridView1.Columns(e.ColumnIndex).Name = "Status" Then
            Dim row = DataGridView1.Rows(e.RowIndex)
            Dim status As String = row.Cells("Status").Value.ToString()

            If status = "Currently In" Then
                Dim result = MessageBox.Show("Mark this student as Checked Out?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    Dim attendanceId = row.Cells("Attendance ID").Value

                    Dim connectionString As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"
                    Dim query As String = "UPDATE TBL_ATTENDANCE SET TIME_OUT = :time_out, STATUS = 'Checked Out' WHERE ATTENDANCE_ID = :attendance_id"

                    Using conn As New OracleConnection(connectionString)
                        Using cmd As New OracleCommand(query, conn)
                            cmd.Parameters.Add(":time_out", OracleDbType.TimeStamp).Value = DateTime.Now
                            cmd.Parameters.Add(":attendance_id", OracleDbType.Int32).Value = Convert.ToInt32(attendanceId)

                            Try
                                conn.Open()
                                cmd.ExecuteNonQuery()
                                MessageBox.Show("Status updated to Checked Out.")
                                LoadAttendanceData()
                            Catch ex As Exception
                                MessageBox.Show("Error updating status: " & ex.Message)
                            End Try
                        End Using
                    End Using
                End If
            End If
        End If
    End Sub

    Private Sub LoadBorrowedBooksCount()
        Dim connectionString As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"
        Dim query As String = "SELECT COUNT(*) FROM TBL_BORROWING WHERE RETURN_DATE IS NULL"

        Using conn As New OracleConnection(connectionString)
            Dim cmd As New OracleCommand(query, conn)

            Try
                conn.Open()
                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                LblNumBorrowed.Text = count.ToString()
            Catch ex As Exception
                MessageBox.Show("Error loading borrowed books count: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub LoadTotalBooksQuantity()
        Dim connectionString As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"
        Dim query As String = "SELECT SUM(QUANTITY_AVAILABLE) FROM TBL_BOOKS"

        Using conn As New OracleConnection(connectionString)
            Dim cmd As New OracleCommand(query, conn)

            Try
                conn.Open()
                Dim totalQuantity As Object = cmd.ExecuteScalar()
                If totalQuantity IsNot DBNull.Value Then
                    LblNumTotalBooks.Text = totalQuantity.ToString()
                Else
                    LblNumTotalBooks.Text = "0"
                End If
            Catch ex As Exception
                MessageBox.Show("Error loading total books quantity: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub LoadOverdueReturnsCount()
        Dim connectionString As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"
        Dim query As String = "SELECT COUNT(*) FROM TBL_BORROWING WHERE RETURN_DATE IS NULL AND RETURN_DUE_DATE < SYSDATE"

        Using conn As New OracleConnection(connectionString)
            Dim cmd As New OracleCommand(query, conn)

            Try
                conn.Open()
                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                LblNumOverdue.Text = count.ToString()
            Catch ex As Exception
                MessageBox.Show("Error loading overdue returns: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub LoadActiveStudentsCount()
        Dim connectionString As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"

        ' Count active students (Studying status) who are not currently blocked
        Dim query As String = "SELECT COUNT(*) FROM TBL_STUDENT s " &
                          "WHERE s.STUDENT_STATUS = 'Studying' " &
                          "AND NOT EXISTS (SELECT 1 FROM TBL_BANNED b " &
                          "WHERE b.USER_ID = s.STUDENT_ID " &
                          "AND b.STATUS = 'Active' " &
                          "AND b.BANNED_END_DATE >= TRUNC(SYSDATE))"

        Using conn As New OracleConnection(connectionString)
            Dim cmd As New OracleCommand(query, conn)

            Try
                conn.Open()
                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                LblNumActMem.Text = count.ToString()
            Catch ex As Exception
                MessageBox.Show("Error loading active students count: " & ex.Message)
            End Try
        End Using
    End Sub


    Private Sub TLPRecentStudentAttendance_Paint(sender As Object, e As PaintEventArgs) Handles TLPRecentStudentAttendance.Paint
        StyleShadowPanel(CType(sender, Panel), e)
    End Sub

End Class