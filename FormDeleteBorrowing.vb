Imports Oracle.ManagedDataAccess.Client

Public Class FormDeleteBorrowing
    Public Event BookDeleted As EventHandler
    Private Sub FormDeleteBorrowing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        roundedPanels.Clear()
        Dim paddedPanels = {PnlBorderSelectID, PnlFill}
        For Each pnl In paddedPanels
            pnl.Padding = New Padding(3)
        Next
        PnlFill.Padding = New Padding(10)

        UIHelpers.SetupPlaceholder(TxtSelectID, "Enter borrow ID")

        roundedPanels.Add(PnlTopAddNewBook, 5)
        roundedPanels.Add(PnlBorderSelectID, 5)
        roundedPanels.Add(PnlFill, 20)
    End Sub

    Private Sub FormDeleteBorrowing_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        BtnDelete.Focus()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub Panel_Paint(sender As Object, e As PaintEventArgs) Handles PnlFill.Paint, PnlBorderSelectID.Paint
        HandlePanelPaint(sender, e)
    End Sub

    Private Sub TableLayoutPanel6_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel6.Paint
        RoundTableLayoutPanel(TableLayoutPanel6, e)
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        Dim connStr As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"
        Dim borrowingId As String = TxtSelectID.Text.Trim()

        If Not IsNumeric(borrowingId) Then
            MessageBox.Show("Please enter a valid numeric Borrowing ID.")
            Return
        End If

        Dim confirm = MessageBox.Show("Are you sure you want to delete this borrowing record?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If confirm = DialogResult.No Then Return

        Try
            Using conn As New OracleConnection(connStr)
                conn.Open()

                ' Step 1: Get BOOK_ID from borrowing record
                Dim getBookIdCmd As New OracleCommand("SELECT BOOK_ID FROM TBL_BORROWING WHERE BORROWING_ID = :id", conn)
                getBookIdCmd.Parameters.Add(":id", OracleDbType.Int32).Value = Integer.Parse(borrowingId)
                Dim bookIdObj = getBookIdCmd.ExecuteScalar()

                If bookIdObj Is Nothing Then
                    MessageBox.Show("Borrowing ID not found.")
                    Return
                End If

                Dim bookId As Integer = Convert.ToInt32(bookIdObj)

                ' Step 2: Delete the borrowing record
                Dim deleteCmd As New OracleCommand("DELETE FROM TBL_BORROWING WHERE BORROWING_ID = :id", conn)
                deleteCmd.Parameters.Add(":id", OracleDbType.Int32).Value = borrowingId
                Dim rowsDeleted = deleteCmd.ExecuteNonQuery()

                If rowsDeleted > 0 Then
                    ' Step 3: Restore book quantity
                    Dim updateBookCmd As New OracleCommand("UPDATE TBL_BOOKS SET QUANTITY = QUANTITY + 1 WHERE BOOK_ID = :bookId", conn)
                    updateBookCmd.Parameters.Add(":bookId", OracleDbType.Int32).Value = bookId
                    updateBookCmd.ExecuteNonQuery()

                    MessageBox.Show("Borrowing record deleted and book restored.")
                    RaiseEvent BookDeleted(Me, EventArgs.Empty)
                    Me.Close()
                Else
                    MessageBox.Show("Borrowing record not found or failed to delete.")
                End If

            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub


End Class