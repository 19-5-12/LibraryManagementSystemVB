Imports Oracle.ManagedDataAccess.Client

Public Class Block
    Private Sub Block_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim CRUDBtns As Button() = {BtnAdd, BtnModify, BtnDelete}
        SetupFormUI(CRUDBtns, DataGridView1, TimerDateTime, LblDateTimeBlock, AddressOf LoadBlocksData)


        TBLPBlock.Padding = New Padding(3)
    End Sub

    Private Sub LoadBlocksData()
        Dim connectionString As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"

        ' Update expired statuses
        Dim updateQuery As String = "
    UPDATE TBL_BANNED
       SET STATUS = CASE
                     WHEN BANNED_END_DATE < TRUNC(SYSDATE) THEN 'Expired'
                     WHEN BANNED_END_DATE >= TRUNC(SYSDATE) THEN 'Active'
                   END
     WHERE STATUS != CASE
                       WHEN BANNED_END_DATE < TRUNC(SYSDATE) THEN 'Expired'
                       WHEN BANNED_END_DATE >= TRUNC(SYSDATE) THEN 'Active'
                     END"

        ' Select updated data
        Dim selectQuery As String = "
        SELECT B.BANNED_ID AS ""Block ID"",
               B.USER_ID AS ""Student ID"",
               S.LAST_NAME || ', ' || S.FIRST_NAME || ' ' || NVL(S.MIDDLE_NAME, '') AS ""Student Name"",
               TO_CHAR(B.BANNED_DATE, 'DD/MM/YYYY') AS ""Blocked Date"",
               B.BANNED_END_DATE AS ""Expiry Date"",
               B.REASON AS ""Remarks"",
               B.STATUS AS ""Status""
          FROM TBL_BANNED B
    INNER JOIN TBL_STUDENT S ON B.USER_ID = S.STUDENT_ID"

        Using conn As New OracleConnection(connectionString)
            conn.Open()

            ' Execute update query
            Using updateCmd As New OracleCommand(updateQuery, conn)
                updateCmd.ExecuteNonQuery()
            End Using

            ' Load updated data
            Using selectCmd As New OracleCommand(selectQuery, conn)
                Dim adapter As New OracleDataAdapter(selectCmd)
                Dim dt As New DataTable()
                adapter.Fill(dt)
                DataGridView1.DataSource = dt
            End Using
        End Using
    End Sub


    Private Sub TBLPBlock_Paint(sender As Object, e As PaintEventArgs) Handles TBLPBlock.Paint
        StyleShadowPanel(CType(sender, Panel), e)
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Dim addForm As New FormAddBlock()
        AddHandler addForm.BlockAdded, AddressOf BlockAddedHandler
        addForm.ShowDialog()
        RemoveHandler addForm.BlockAdded, AddressOf BlockAddedHandler
    End Sub

    Private Sub BlockAddedHandler(sender As Object, e As EventArgs)
        LoadBlocksData()
    End Sub

    Private Sub BtnModify_Click(sender As Object, e As EventArgs) Handles BtnModify.Click
        Dim addForm As New FormModifyBlock()
        AddHandler addForm.BlockModified, AddressOf BlockModifyHandler
        addForm.ShowDialog()
        RemoveHandler addForm.BlockModified, AddressOf BlockModifyHandler
    End Sub

    Private Sub BlockModifyHandler(sender As Object, e As EventArgs)
        LoadBlocksData()
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        Dim addForm As New FormDeleteBlock()
        AddHandler addForm.BlockDeleted, AddressOf BlockDeleteHandler
        addForm.ShowDialog()
        RemoveHandler addForm.BlockDeleted, AddressOf BlockDeleteHandler
    End Sub

    Private Sub BlockDeleteHandler(sender As Object, e As EventArgs)
        LoadBlocksData()
    End Sub
End Class