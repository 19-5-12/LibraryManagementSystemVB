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
            MessageBox.Show("Please enter a valid numeric Borrow ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim confirm = MessageBox.Show("Are you sure you want to delete this borrowing record?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If confirm = DialogResult.No Then Return

        Try
            Using conn As New OracleConnection(connStr)
                conn.Open()

                ' Step 1: Retrieve the BOOK_ID and STATUS
                Dim getInfoSql = "SELECT BOOK_ID, STATUS FROM TBL_BORROWING WHERE BORROWING_ID = :id"
                Using getInfoCmd As New OracleCommand(getInfoSql, conn)
                    getInfoCmd.Parameters.Add(":id", OracleDbType.Int32).Value = Integer.Parse(borrowingId)
                    Using reader As OracleDataReader = getInfoCmd.ExecuteReader()
                        If reader.Read() Then
                            Dim bookId As Integer = Convert.ToInt32(reader("BOOK_ID"))
                            Dim status As String = reader("STATUS").ToString().ToUpper()

                            ' Step 2: Delete from TBL_BORROWING
                            Dim deleteSql = "DELETE FROM TBL_BORROWING WHERE BORROWING_ID = :id"
                            Using deleteCmd As New OracleCommand(deleteSql, conn)
                                deleteCmd.Parameters.Add(":id", OracleDbType.Int32).Value = borrowingId
                                Dim rowsDeleted = deleteCmd.ExecuteNonQuery()

                                If rowsDeleted > 0 Then
                                    ' Step 3: Restore quantity only if not returned yet
                                    If status = "BORROWING" OrElse status = "OVERDUE" Then
                                        Dim updateBookSql = "UPDATE TBL_BOOKS SET QUANTITY_AVAILABLE = QUANTITY_AVAILABLE + 1 WHERE BOOK_ID = :bookId"
                                        Using updateBookCmd As New OracleCommand(updateBookSql, conn)
                                            updateBookCmd.Parameters.Add(":bookId", OracleDbType.Int32).Value = bookId
                                            updateBookCmd.ExecuteNonQuery()
                                        End Using
                                    End If

                                    MessageBox.Show("Borrowing record deleted successfully.")
                                    RaiseEvent BookDeleted(Me, EventArgs.Empty)
                                    Me.Close()
                                Else
                                    MessageBox.Show("Deletion failed. Borrow ID may not exist.")
                                End If
                            End Using
                        Else
                            MessageBox.Show("Borrow ID not found.")
                            Return
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

End Class