Imports Oracle.ManagedDataAccess.Client

Public Class FormDeleteBooks
    Public Event BookDeleted As EventHandler

    Private Sub FormDeleteBooks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        roundedPanels.Clear()
        Dim paddedPanels = {PnlBorderSelectID, PnlFill}
        For Each pnl In paddedPanels
            pnl.Padding = New Padding(3)
        Next
        PnlFill.Padding = New Padding(10)

        UIHelpers.SetupPlaceholder(TxtSelectID, "Enter Book ID")

        roundedPanels.Add(PnlTopAddNewBook, 5)
        roundedPanels.Add(PnlBorderSelectID, 5)
        roundedPanels.Add(PnlFill, 20)
    End Sub

    Private Sub FormDeleteBooks_Shown(sender As Object, e As EventArgs) Handles Me.Shown
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
        Dim bookId As String = TxtSelectID.Text.Trim()

        If Not IsNumeric(bookId) Then
            MessageBox.Show("Please enter a valid numeric Book ID.")
            Return
        End If

        Dim confirm = MessageBox.Show("Are you sure you want to delete this book?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If confirm = DialogResult.No Then Return

        Try
            Using conn As New OracleConnection(connStr)
                conn.Open()
                Dim sql As String = "DELETE FROM TBL_BOOKS WHERE BOOK_ID = :bookId"
                Using cmd As New OracleCommand(sql, conn)
                    cmd.Parameters.Add(":bookId", OracleDbType.Int32).Value = Integer.Parse(bookId)

                    Dim rowsAffected = cmd.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        MessageBox.Show("Book deleted successfully.")
                        RaiseEvent BookDeleted(Me, EventArgs.Empty)
                        Me.Close()
                    Else
                        MessageBox.Show("Book ID not found.")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub
End Class