Imports System.Drawing.Drawing2D
Imports Oracle.ManagedDataAccess.Client

Public Class FormAddBlock
    Public Event BlockAdded As EventHandler
    Private Sub FormAddBlock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        roundedPanels.Clear()

        ComboStatus.Items.Insert(0, "Select Status")
        ComboStatus.SelectedIndex = 0

        DTPDateBlocked.MaxDate = DateTime.Now.Date

        Dim paddedPanels = {PnlBorderBookID, PnlBorderBorrowID, PnlBorderStudentID, PnlBorderBorrowedDate,
            PnlBorderDueDate, PnlBorderStatus}
        For Each pnl In paddedPanels
            pnl.Padding = New Padding(3)
        Next
        PnlFill.Padding = New Padding(10)

        SetupPlaceholder(TxtBlockID, "Automatic")
        SetupPlaceholder(TxtStudentID, "Enter Student ID")
        SetupPlaceholder(TxtReason, "Enter Reason")

        roundedPanels.Add(PnlFill, 20)
        roundedPanels.Add(PnlBorderBorrowID, 5)
        roundedPanels.Add(PnlBorderStudentID, 5)
        roundedPanels.Add(PnlBorderBookID, 5)
        roundedPanels.Add(PnlBorderBorrowedDate, 5)
        roundedPanels.Add(PnlBorderDueDate, 5)
        roundedPanels.Add(PnlBorderStatus, 5)
    End Sub

    Private Sub Panel_Paint(sender As Object, e As PaintEventArgs) Handles PnlFill.Paint, PnlBorderBookID.Paint,
        PnlBorderBorrowID.Paint, PnlBorderStudentID.Paint, PnlBorderBorrowedDate.Paint, PnlBorderDueDate.Paint,
        PnlBorderStatus.Paint

        Dim pnl = DirectCast(sender, Panel)
        If roundedPanels.ContainsKey(pnl) Then
            MakeRoundedPanel(pnl, roundedPanels(pnl), e)
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub FormAddBlock_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        BtnAddBlocked.Focus()
    End Sub

    Private Sub BtnAddBlocked_Click(sender As Object, e As EventArgs) Handles BtnAddBlocked.Click
        Dim connStr As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"

        If Not IsNumeric(TxtBlockID.Text) Then
            MessageBox.Show("Please enter a valid Block ID.")
            TxtBlockID.Focus()
            Return
        End If

        If Not IsNumeric(TxtStudentID.Text) Then
            MessageBox.Show("Please enter a valid Student ID.")
            TxtStudentID.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(TxtReason.Text) Then
            MessageBox.Show("Please enter a reason.")
            TxtReason.Focus()
            Return
        End If

        If ComboStatus.SelectedIndex = 0 Then
            MessageBox.Show("Please select a valid status.")
            Return
        End If

        If DTPBlockExpiration.Value.Date < DTPDateBlocked.Value.Date Then
            MessageBox.Show("Block expiration date cannot be earlier than the block date.")
            DTPBlockExpiration.Focus()
            Return
        End If

        Dim bannedId = Integer.Parse(TxtBlockID.Text)
        Dim userId = Integer.Parse(TxtStudentID.Text)
        Dim reason = TxtReason.Text.Trim()
        Dim status = ComboStatus.SelectedItem.ToString()

        Try
            Using conn As New OracleConnection(connStr)
                conn.Open()

                Dim insertSql As String = "INSERT INTO TBL_BANNED (BANNED_ID, USER_ID, BANNED_END_DATE, BANNED_DATE, REASON, STATUS) " &
                                          "VALUES (:bannedId, :userId, :endDate, :bannedDate, :reason, :status)"

                Using cmd As New OracleCommand(insertSql, conn)
                    cmd.Parameters.Add(":bannedId", OracleDbType.Int32).Value = bannedId
                    cmd.Parameters.Add(":userId", OracleDbType.Int32).Value = userId
                    cmd.Parameters.Add(":bannedDate", OracleDbType.Date).Value = DTPDateBlocked.Value
                    cmd.Parameters.Add(":endDate", OracleDbType.Date).Value = DTPBlockExpiration.Value
                    cmd.Parameters.Add(":reason", OracleDbType.Varchar2).Value = reason
                    cmd.Parameters.Add(":status", OracleDbType.Varchar2).Value = status

                    Dim result = cmd.ExecuteNonQuery()
                    If result > 0 Then
                        MessageBox.Show("Banned record added successfully.")
                        RaiseEvent BlockAdded(Me, EventArgs.Empty)
                        Me.Close()
                    Else
                        MessageBox.Show("Failed to add banned record.")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub
End Class