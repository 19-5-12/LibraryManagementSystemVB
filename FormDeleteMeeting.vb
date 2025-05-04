Imports Oracle.ManagedDataAccess.Client

Public Class FormDeleteMeeting
    Public Event MeetingDeleted As EventHandler
    Private Sub FormDeleteMeeting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub FormDeleteMeeting_Shown(sender As Object, e As EventArgs) Handles Me.Shown
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
        Dim bookingId As String = TxtSelectID.Text.Trim()

        If Not IsNumeric(bookingId) Then
            MessageBox.Show("Please enter a valid numeric Booking ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Confirm deletion with user
        Dim confirm = MessageBox.Show("Are you sure you want to delete this meeting booking?",
                                    "Confirm Deletion",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Warning)
        If confirm = DialogResult.No Then Return

        Try
            Using conn As New OracleConnection(connStr)
                conn.Open()

                ' First check if booking exists
                Dim checkSql = "SELECT COUNT(*) FROM TBL_ROOM_BOOKING WHERE BOOKING_ID = :id"
                Using checkCmd As New OracleCommand(checkSql, conn)
                    checkCmd.Parameters.Add(":id", OracleDbType.Int32).Value = Integer.Parse(bookingId)
                    Dim exists = Convert.ToInt32(checkCmd.ExecuteScalar())

                    If exists = 0 Then
                        MessageBox.Show("Booking ID not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return
                    End If
                End Using

                ' Delete the booking record
                Dim deleteSql = "DELETE FROM TBL_ROOM_BOOKING WHERE BOOKING_ID = :id"
                Using deleteCmd As New OracleCommand(deleteSql, conn)
                    deleteCmd.Parameters.Add(":id", OracleDbType.Int32).Value = Integer.Parse(bookingId)
                    Dim rowsDeleted = deleteCmd.ExecuteNonQuery()

                    If rowsDeleted > 0 Then
                        MessageBox.Show("Meeting booking deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        RaiseEvent MeetingDeleted(Me, EventArgs.Empty)
                        Me.Close()
                    Else
                        MessageBox.Show("No booking was deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error deleting meeting: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class