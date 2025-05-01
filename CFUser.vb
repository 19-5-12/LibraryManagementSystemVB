Imports Oracle.ManagedDataAccess.Client

Public Class CFUser
    Private Sub CFUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim CRUDBtns As Button() = {BtnAdd, BtnModify, BtnDelete, BtnBack}
        SetupFormUI(CRUDBtns, DataGridView1, TimerDateTime, LblDateTimeUser, AddressOf LoadUserData)

    End Sub

    Private Sub LoadUserData()
        Dim connectionString As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"
        Dim query As String = "SELECT NULL AS ""ID"",
                                      NULL AS ""Username"",
                                      NULL AS ""Full Name"",
                                      NULL AS ""Role"",
                                      NULL AS ""Email"",
                                      NULL AS ""Date Created"",
                                      NULL AS ""Last Login"",
                                      NULL AS ""Status""
                                      FROM TBL_LOGIN"

        Using conn As New OracleConnection(connectionString)
            Dim cmd As New OracleCommand(query, conn)
            Dim adapter As New OracleDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            DataGridView1.DataSource = dt
        End Using
    End Sub

    Private Sub TBLPUser_Paint(sender As Object, e As PaintEventArgs) Handles TBLPUser.Paint
        StyleShadowPanel(CType(sender, Panel), e)
    End Sub
End Class