Imports Oracle.ManagedDataAccess.Client

Public Class CFBorrowing
    Private Sub CFBorrowing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim CRUDBtns As Button() = {BtnAdd, BtnModify, BtnDelete}
        SetupFormUI(CRUDBtns, DataGridView1, TimerDateTime, LblDateTimeBorrowing, AddressOf LoadBorrowingData)


        TBLPBorrowing.Padding = New Padding(3)
    End Sub

    Private Sub LoadBorrowingData()
        Dim connectionString As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"

        Using conn As New OracleConnection(connectionString)
            conn.Open()

            ' 1. First update RETURNED OVERDUE status for returned items
            Dim updateReturnedOverdueSql As String = "
            UPDATE TBL_BORROWING
            SET STATUS = 'RETURNED OVERDUE'
            WHERE RETURN_DATE IS NOT NULL
              AND RETURN_DATE > RETURN_DUE_DATE
              AND STATUS != 'RETURNED OVERDUE'"

            Using cmdReturnedOverdue As New OracleCommand(updateReturnedOverdueSql, conn)
                cmdReturnedOverdue.ExecuteNonQuery()
            End Using

            ' 2. Correct status from RETURNED OVERDUE back to RETURNED if return was actually on time
            Dim fixWrongReturnedOverdueSql As String = "
            UPDATE TBL_BORROWING
            SET STATUS = 'RETURNED'
            WHERE STATUS = 'RETURNED OVERDUE'
              AND RETURN_DATE <= RETURN_DUE_DATE"

            Using fixCmd As New OracleCommand(fixWrongReturnedOverdueSql, conn)
                fixCmd.ExecuteNonQuery()
            End Using

            ' 3. Update status to "OVERDUE" ONLY for unreturned items where due date has passed
            Dim updateOverdueSql As String = "
            UPDATE TBL_BORROWING
            SET STATUS = 'OVERDUE'
            WHERE STATUS = 'BORROWING'
              AND RETURN_DUE_DATE < TRUNC(SYSDATE)
              AND RETURN_DATE IS NULL"

            Using cmdOverdue As New OracleCommand(updateOverdueSql, conn)
                cmdOverdue.ExecuteNonQuery()
            End Using

            ' 4. Change back to BORROWING if due date is in the future (shouldn't be needed but just in case)
            Dim fixWrongOverdueSql As String = "
            UPDATE TBL_BORROWING
            SET STATUS = 'BORROWING'
            WHERE STATUS = 'OVERDUE'
              AND RETURN_DUE_DATE >= TRUNC(SYSDATE)"

            Using fixOverdueCmd As New OracleCommand(fixWrongOverdueSql, conn)
                fixOverdueCmd.ExecuteNonQuery()
            End Using

            ' Load the data for display
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
                JOIN TBL_BOOKS bo ON b.BOOK_ID = bo.BOOK_ID
                ORDER BY b.BORROW_DATE DESC"

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

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        Dim deleteForm As New FormDeleteBorrowing()
        AddHandler deleteForm.BookDeleted, AddressOf BorrowDeletedHandler
        deleteForm.ShowDialog()
        RemoveHandler deleteForm.BookDeleted, AddressOf BorrowDeletedHandler
    End Sub

    Private Sub BorrowDeletedHandler(sender As Object, e As EventArgs)
        LoadBorrowingData()
    End Sub
End Class