Imports Oracle.ManagedDataAccess.Client

Public Class CFBorrowing
    Private Sub CFBorrowing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim CRUDBtns As Button() = {BtnAdd, BtnModify, BtnDelete}
        SetupFormUI(CRUDBtns, DataGridView1, TimerDateTime, LblDateTimeBorrowing, AddressOf LoadBorrowingData)

    End Sub

    Private Sub LoadBorrowingData()
        Dim connectionString As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"

        Using conn As New OracleConnection(connectionString)
            conn.Open()

            ' ✅ Actually execute the update query
            Dim updateQuery As String = "
            UPDATE TBL_BORROWING
            SET STATUS = 'RETURNED OVERDUE'
            WHERE STATUS = 'RETURNED'
              AND RETURN_DATE > RETURN_DUE_DATE"

            Using updateCmd As New OracleCommand(updateQuery, conn)
                updateCmd.ExecuteNonQuery()
            End Using

            ' 🔽 Then load the data
            Dim selectQuery As String = "SELECT 
            b.BORROWING_ID AS ""Borrow ID"",
            s.FIRST_NAME || ' ' || s.LAST_NAME AS ""Student Name"",
            bo.TITLE AS ""Book Title"",
            TO_CHAR(b.BORROW_DATE, 'DD/MM/YYYY') AS ""Borrowed Date"",
            TO_CHAR(b.RETURN_DUE_DATE, 'DD/MM/YYYY') AS ""Due Date"",
            TO_CHAR(b.RETURN_DATE, 'DD/MM/YYYY') AS ""Return Date"",
            b.STATUS AS ""Status""
            FROM TBL_BORROWING b
            JOIN TBL_STUDENT s ON b.USER_ID = s.STUDENT_ID
            JOIN TBL_BOOKS bo ON b.BOOK_ID = bo.BOOK_ID"

            Using cmd As New OracleCommand(selectQuery, conn)
                Dim adapter As New OracleDataAdapter(cmd)
                Dim dt As New DataTable()
                adapter.Fill(dt)
                DataGridView1.DataSource = dt
            End Using
        End Using
    End Sub

    Private Sub TBLPBorrowing_Paint(sender As Object, e As PaintEventArgs) Handles TBLPBorrowing.Paint
        StyleShadowPanel(CType(sender, Panel), e)
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Dim addForm As New FormAddBorrowing()
        AddHandler addForm.BorrowAdded, AddressOf BorrowAddedHandler
        addForm.ShowDialog()
        RemoveHandler addForm.BorrowAdded, AddressOf BorrowAddedHandler
    End Sub

    Private Sub BorrowAddedHandler(sender As Object, e As EventArgs)
        LoadBorrowingData()
    End Sub

    Private Sub BtnModify_Click(sender As Object, e As EventArgs) Handles BtnModify.Click
        Dim modifyForm As New FormModifyBorrowing()
        AddHandler modifyForm.BorrowModified, AddressOf BorrowModifiedHandler
        modifyForm.ShowDialog()
        RemoveHandler modifyForm.BorrowModified, AddressOf BorrowModifiedHandler
    End Sub

    Private Sub BorrowModifiedHandler(sender As Object, e As EventArgs)
        LoadBorrowingData()
    End Sub
End Class