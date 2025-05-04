Imports Oracle.ManagedDataAccess.Client

Public Class FormModifyBlock
    Public Event BlockModified As EventHandler
    Private Sub FormModifyBlock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        roundedPanels.Clear()

        ComboStatus.Items.Insert(0, "Select Status")
        ComboStatus.SelectedIndex = 0

        DTPDateBlocked.MaxDate = DateTime.MaxValue  ' Allow future dates
        DTPBlockExpiration.MaxDate = DateTime.MaxValue  ' Allow future dates

        Dim paddedPanels = {PnlBorderBookID, PnlBorderBorrowID, PnlBorderStudentID, PnlBorderBorrowedDate,
            PnlBorderDueDate, PnlBorderStatus}
        For Each pnl In paddedPanels
            pnl.Padding = New Padding(3)
        Next
        PnlFill.Padding = New Padding(10)

        SetupPlaceholder(TxtBlockID, "Enter Block ID")
        SetupPlaceholder(TxtStudentID, "Enter Student ID")
        SetupPlaceholder(TxtReason, "Enter Reason")
        SetupPlaceholder(TxtSelectID, "Enter Block ID")

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

    Private Sub Modify_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        BtnSave.Focus()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub TxtSelectID_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtSelectID.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            LoadBannedDataByID()
        End If
    End Sub

    Private Sub LoadBannedDataByID()
        Dim connStr As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"
        Dim bannedId As String = TxtSelectID.Text.Trim()

        If Not IsNumeric(bannedId) Then
            MessageBox.Show("Please enter a valid numeric Block ID.")
            Return
        End If

        Try
            Using conn As New OracleConnection(connStr)
                conn.Open()
                Dim sql As String = "SELECT * FROM TBL_BANNED WHERE BANNED_ID = :id"
                Using cmd As New OracleCommand(sql, conn)
                    cmd.Parameters.Add(":id", OracleDbType.Int32).Value = Integer.Parse(bannedId)

                    Using reader As OracleDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            TxtBlockID.Text = reader("BANNED_ID").ToString()
                            TxtBlockID.ForeColor = SystemColors.WindowText
                            TxtStudentID.Text = reader("USER_ID").ToString()
                            TxtStudentID.ForeColor = SystemColors.WindowText
                            DTPDateBlocked.Value = Convert.ToDateTime(reader("BANNED_DATE"))
                            DTPBlockExpiration.Value = Convert.ToDateTime(reader("BANNED_END_DATE"))
                            TxtReason.Text = reader("REASON").ToString()
                            TxtReason.ForeColor = SystemColors.WindowText
                            ComboStatus.SelectedItem = reader("STATUS").ToString()
                        Else
                            MessageBox.Show("Block ID not found.")
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim connStr As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"

        If DTPDateBlocked.Value > DateTime.Now Then
            MessageBox.Show("Block date cannot be in the future.")
            Return
        End If

        If DTPBlockExpiration.Value < DTPDateBlocked.Value Then
            MessageBox.Show("Expiration date must be after block date.")
            Return
        End If

        If Not IsNumeric(TxtBlockID.Text) OrElse Not IsNumeric(TxtStudentID.Text) Then
            MessageBox.Show("Block ID and Student ID must be valid numbers.")
            Return
        End If

        If ComboStatus.SelectedIndex = 0 Then
            MessageBox.Show("Please select a valid status.")
            Return
        End If

        Try
            Using conn As New OracleConnection(connStr)
                conn.Open()

                Dim sql As String = "UPDATE TBL_BANNED 
                                 SET USER_ID = :studentId, 
                                     BANNED_DATE = :bannedDate, 
                                     BANNED_END_DATE = :endDate, 
                                     REASON = :reason, 
                                     STATUS = :status 
                                 WHERE BANNED_ID = :bannedId"

                Using cmd As New OracleCommand(sql, conn)
                    cmd.Parameters.Add(":studentId", TxtStudentID.Text)
                    cmd.Parameters.Add(":bannedDate", DTPDateBlocked.Value)
                    cmd.Parameters.Add(":endDate", DTPBlockExpiration.Value)
                    cmd.Parameters.Add(":reason", TxtReason.Text)
                    cmd.Parameters.Add(":status", ComboStatus.SelectedItem.ToString())
                    cmd.Parameters.Add(":bannedId", TxtBlockID.Text)

                    Dim rowsAffected = cmd.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        MessageBox.Show("Block record updated successfully.")
                        RaiseEvent BlockModified(Me, EventArgs.Empty)
                        Me.Close()
                    Else
                        MessageBox.Show("No record updated.")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

End Class