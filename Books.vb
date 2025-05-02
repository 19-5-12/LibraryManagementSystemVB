Imports Oracle.ManagedDataAccess.Client

Public Class Books

    Private Sub Books_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim CRUDBtns As Button() = {BtnAdd, BtnModify, BtnDelete, BtnBack}
        SetupFormUI(CRUDBtns, DataGridView1, TimerDateTime, LblDateTimeBook, AddressOf LoadBooksData)

    End Sub

    Private Sub LoadBooksData()
        Dim connectionString As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"
        Dim query As String = "SELECT BOOK_ID AS ""Book ID"",
                                      TITLE AS ""Title"",
                                      AUTHOR AS ""Author"",
                                      ISBN,
                                      CATEGORY AS ""Category"",
                                      PUBLICATION_YEAR AS ""Publication Date"",
                                      QUANTITY_AVAILABLE AS ""Quantity"",
                                      NULL AS ""Status"" FROM TBL_BOOKS"

        Using conn As New OracleConnection(connectionString)
            Dim cmd As New OracleCommand(query, conn)
            Dim adapter As New OracleDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            DataGridView1.DataSource = dt

        End Using
    End Sub

    Private Sub TBLListOfBooks_Paint(sender As Object, e As PaintEventArgs) Handles TBLListOfBooks.Paint
        StyleShadowPanel(CType(sender, Panel), e)
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        FormAddBooks.ShowDialog()
    End Sub

    Private Sub BtnModify_Click(sender As Object, e As EventArgs) Handles BtnModify.Click
        Modify.ShowDialog()
    End Sub
End Class
