Imports Oracle.ManagedDataAccess.Client

Public Class CFMeetingRooms
    Private Sub CFMeetingRooms_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim CRUDBtns As Button() = {BtnAdd, BtnModify, BtnDelete}
        SetupFormUI(CRUDBtns, DataGridView1, TimerDateTime, LblDateTimeMeeting, AddressOf LoadMeetingData)

        TBLPMeeting.Padding = New Padding(3)
    End Sub

    Private Sub LoadMeetingData()
        Dim connectionString As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"
        Dim query As String = "
        SELECT 
            B.BOOKING_ID AS ""Booking ID"",
            R.ROOM_NAME AS ""Room Name"",
            S.FIRST_NAME || ' ' || S.LAST_NAME AS ""Booked By"",
            B.BOOK_DATE AS ""Book Date"",
            B.TIME_FROM AS ""Time From"",
            B.TIME_TO AS ""Time To"",
            B.AVAILABILITY AS ""Next Available""
        FROM TBL_ROOM_BOOKING B
        JOIN TBL_ROOM R ON B.ROOM_ID = R.ROOM_ID
        JOIN TBL_STUDENT S ON B.USER_ID = S.STUDENT_ID
        ORDER BY B.BOOK_DATE DESC, B.TIME_FROM"


        Using conn As New OracleConnection(connectionString)
            Dim cmd As New OracleCommand(query, conn)
            Dim adapter As New OracleDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            DataGridView1.DataSource = dt

        End Using
    End Sub

    Private Sub TBLPMeeting_Paint(sender As Object, e As PaintEventArgs) Handles TBLPMeeting.Paint
        StyleShadowPanel(CType(sender, Panel), e)
    End Sub

End Class