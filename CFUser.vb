Imports Oracle.ManagedDataAccess.Client

Public Class CFUser
    Private Sub CFUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim CRUDBtns As Button() = {BtnAdd, BtnModify, BtnDelete}
        SetupFormUI(CRUDBtns, DataGridView1, TimerDateTime, LblDateTimeUser, AddressOf LoadUserData)
        TBLPUser.Padding = New Padding(3)
    End Sub

    Private Sub LoadUserData()
        Dim connectionString As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"
        Dim query As String = "SELECT ID, 
                                     USERNAME AS ""Username"",
                                     FULL_NAME AS ""Full Name"",
                                     ROLE AS ""Role"",
                                     EMAIL AS ""Email"",
                                     TO_CHAR(DATE_CREATED, 'MM/DD/YYYY') AS ""Date Created"",
                                     TO_CHAR(LAST_LOGIN, 'MM/DD/YYYY HH24:MI:SS') AS ""Last Login"",
                                     STATUS AS ""Status""
                              FROM TBL_USER
                              ORDER BY ID"

        Using conn As New OracleConnection(connectionString)
            Try
                conn.Open()
                Dim cmd As New OracleCommand(query, conn)
                Dim adapter As New OracleDataAdapter(cmd)
                Dim dt As New DataTable()
                adapter.Fill(dt)

                ' Format the DataGridView
                DataGridView1.DataSource = dt
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)

            Catch ex As OracleException
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show($"General error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub TBLPUser_Paint(sender As Object, e As PaintEventArgs) Handles TBLPUser.Paint
        StyleShadowPanel(CType(sender, Panel), e)
    End Sub
End Class