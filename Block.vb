Imports Oracle.ManagedDataAccess.Client

Public Class Block
    Private Sub Block_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim CRUDBtns As Button() = {BtnAdd, BtnModify, BtnDelete}
        SetupFormUI(CRUDBtns, DataGridView1, TimerDateTime, LblDateTimeBlock, AddressOf LoadBlocksData)

    End Sub

    Private Sub LoadBlocksData()
        Dim connectionString As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"
        Dim query As String = "SELECT BANNED_ID AS ""ID"",
                                      STUDENT_NAME AS ""Student Name"",
                                      USER_ID AS ""ID"",
                                      BANNED_START_DATE AS ""Block Date"",
                                      BANNED_END_DATE AS ""Expiry Date"",
                                      REASON AS ""Reason"",
                                      STATUS AS ""Status""
                                      FROM TBL_BANNED"

        Using conn As New OracleConnection(connectionString)
            Dim cmd As New OracleCommand(query, conn)
            Dim adapter As New OracleDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            DataGridView1.DataSource = dt

        End Using
    End Sub

    Private Sub TBLPBlock_Paint(sender As Object, e As PaintEventArgs) Handles TBLPBlock.Paint
        StyleShadowPanel(CType(sender, Panel), e)
    End Sub
End Class