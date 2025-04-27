Imports Oracle.ManagedDataAccess.Client

Public Class CFBorrowing
    Private Sub CFBorrowing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim CRUDBtns As Button() = {BtnAdd, BtnModify, BtnDelete, BtnBack}
        SetupFormUI(CRUDBtns, DataGridView1, TimerDateTime, LblDateTimeBorrowing, AddressOf LoadBorrowingData)

    End Sub

    Private Sub LoadBorrowingData()
        Dim connectionString As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"
        Dim query As String = "SELECT 
                                b.BORROWING_ID AS ""Borrow ID"",
                                s.FIRST_NAME || ' ' || s.LAST_NAME AS ""Student Name"",
                                bo.TITLE AS ""Book Title"",
                                b.BORROW_DATE AS ""Borrowed Date"",
                                b.RETURN_DUE_DATE AS ""Due Date"",
                                b.RETURN_DATE AS ""Return Date"",
                                NULL AS ""Status"" 
                           FROM 
                                TBL_BORROWING b
                           JOIN 
                                TBL_STUDENT s ON b.USER_ID = s.STUDENT_ID
                           JOIN 
                                TBL_BOOKS bo ON b.BOOK_ID = bo.BOOK_ID"

        Using conn As New OracleConnection(connectionString)
            Dim cmd As New OracleCommand(query, conn)
            Dim adapter As New OracleDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            DataGridView1.DataSource = dt
        End Using
    End Sub

    Private Sub TBLPBorrowing_Paint(sender As Object, e As PaintEventArgs) Handles TBLPBorrowing.Paint
        StyleShadowPanel(CType(sender, Panel), e)
    End Sub
End Class