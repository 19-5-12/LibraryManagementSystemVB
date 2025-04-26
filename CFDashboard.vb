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
        PnlIMageOverdue,
        PnlForDataGridView,
        TableLayoutPanel9
    }

        For Each pnl In panelsToStyle
            AddHandler pnl.Paint, Sub(s, eArgs) StyleShadowPanel(DirectCast(s, Panel), eArgs)
            AddHandler pnl.Resize, Sub() pnl.Invalidate()
        Next

        TimerDateTime.Interval = 1000
        TimerDateTime.Start()
        UpdateTimeLabel()

        LoadAttendanceData()
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

End Class