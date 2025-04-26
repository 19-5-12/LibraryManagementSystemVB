Imports Oracle.ManagedDataAccess.Client

Public Class CFMeetingRooms
    Private Sub CFMeetingRooms_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim CRUDBtns As Button() = {BtnAdd, BtnModify, BtnDelete, BtnBack}
        SetupFormUI(CRUDBtns, DataGridView1, TimerDateTime, LblDateTimeMeeting, AddressOf LoadMeetingData)
    End Sub

    Private Sub LoadMeetingData()
        Dim connectionString As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"
        Dim query As String = "SELECT ROOM_ID AS ""Room ID"",
                                      ROOM_NAME AS ""Room Name"",
                                      CAPACITY AS ""Capacity"",
                                      NULL AS ""Features"",
                                      NULL AS ""Current Booking"",
                                      AVAILABILITY AS ""Next Available"",
                                      NULL AS ""Status""
                                      FROM TBL_ROOM"

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