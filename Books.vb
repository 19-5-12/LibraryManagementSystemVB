Imports Oracle.ManagedDataAccess.Client

Public Class Books

    Private Sub Books_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim CRUDBtns As Button() = {BtnAdd, BtnModify, BtnDelete}
        SetupFormUI(CRUDBtns, DataGridView1, TimerDateTime, LblDateTimeBook, AddressOf LoadBooksData)


        TBLListOfBooks.Padding = New Padding(3)
    End Sub

    Private Sub LoadBooksData()
        Dim connectionString As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"
        Dim query As String = "
            SELECT 
                BOOK_ID AS ""Book ID"",
                TITLE AS ""Title"",
                AUTHOR AS ""Author"",
                ISBN,
                CATEGORY AS ""Category"",
                PUBLICATION_YEAR AS ""Publication Date"",
                QUANTITY_AVAILABLE AS ""Quantity"",
                CASE 
                    WHEN QUANTITY_AVAILABLE > 0 THEN 'Available'
                    ELSE 'Unavailable'
                END AS ""Status""
            FROM 
                TBL_BOOKS"

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
        Dim addForm As New FormAddBooks()
        AddHandler addForm.BookAdded, AddressOf BookAddedHandler
        addForm.ShowDialog()
        RemoveHandler addForm.BookAdded, AddressOf BookAddedHandler
    End Sub

    Private Sub BookAddedHandler(sender As Object, e As EventArgs)
        LoadBooksData() 
    End Sub

    Private Sub BtnModify_Click(sender As Object, e As EventArgs) Handles BtnModify.Click
        Dim modifyForm As New FormModifyBooks()
        AddHandler modifyForm.BookModified, AddressOf BookModifiedHandler
        modifyForm.ShowDialog()
        RemoveHandler modifyForm.BookModified, AddressOf BookModifiedHandler
    End Sub

    Private Sub BookModifiedHandler(sender As Object, e As EventArgs)
        LoadBooksData()
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        Dim deleteForm As New FormDeleteBooks()
        AddHandler deleteForm.BookDeleted, AddressOf BookDeletedHandler
        deleteForm.ShowDialog()
        RemoveHandler deleteForm.BookDeleted, AddressOf BookDeletedHandler
    End Sub

    Private Sub BookDeletedHandler(sender As Object, e As EventArgs)
        LoadBooksData()
    End Sub

End Class
