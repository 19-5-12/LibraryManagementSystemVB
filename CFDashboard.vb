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

        DataGridView1.EnableHeadersVisualStyles = False
        SetDataGridHeaderWhite(DataGridView1)

    End Sub

    Private Sub TimerDateTime_Tick(sender As Object, e As EventArgs) Handles TimerDateTime.Tick
        UpdateTimeLabel()
    End Sub
    Private Sub UpdateTimeLabel()
        LblDateTime.Text = DateTime.Now.ToString("MMMM dd, yyyy - hh:mm:ss tt")
    End Sub

    Private Sub LoadAttendanceData()
        Dim connectionString As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"
        Dim query As String = "SELECT STUDENT_ID as ""Student ID"", LAST_NAME || ', ' || FIRST_NAME || ' ' || SUBSTR(MIDDLE_NAME, 1, 1) || '.' as ""Student Name"", TO_CHAR(TIME_IN, 'DD/MM/YYYY') AS ""Date"", TO_CHAR(TIME_IN, 'HH:MI AM') AS ""Time In"", NULL as ""Time Out"", STUDENT_STATUS as ""Status"" FROM TBL_STUDENT"

        Using conn As New OracleConnection(connectionString)
            Dim cmd As New OracleCommand(query, conn)
            Dim adapter As New OracleDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            DataGridView1.DataSource = dt

        End Using
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

    Private Sub TLPRecentStudentAttendance_Paint(sender As Object, e As PaintEventArgs) Handles TLPRecentStudentAttendance.Paint
        StyleShadowPanel(CType(sender, Panel), e)
    End Sub
End Class