Imports Oracle.ManagedDataAccess.Client

Public Class CFExtend
    Public Event BlockDeleted As EventHandler

    Private previousStatus As String = ""
    Private isUpdatingStatus As Boolean = False

    Private Sub CFExtend_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetPendingStatusForNulls()
        LoadExtendData()
    End Sub

    Private Sub SetPendingStatusForNulls()
        Dim connectionString As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"
        Dim query As String = "UPDATE TBL_BORROW_EXTEND SET STATUS = 'Pending' WHERE STATUS IS NULL OR (STATUS <> 'Approved' AND STATUS <> 'Declined' AND STATUS <> 'Pending')"
        Using conn As New OracleConnection(connectionString)
            conn.Open()
            Using cmd As New OracleCommand(query, conn)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub LoadExtendData(Optional filterByDate As Boolean = False)
        Dim connectionString As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"

        Using conn As New OracleConnection(connectionString)
            conn.Open()

            Dim selectQuery As String = "SELECT " &
                "e.EXTEND_ID AS ""Extend ID"", " &
                "e.REQUEST_ID AS ""Request ID"", " &
                "s.FIRST_NAME || ' ' || s.LAST_NAME AS ""Student Name"", " &
                "b.TITLE AS ""Book Title"", " &
                "TO_CHAR(e.EXTEND_DATE, 'DD/MM/YYYY') AS ""Extend Request Date"", " &
                "e.STATUS AS ""Status"", " &
                "TO_CHAR(e.RESOLUTION_DATE, 'DD/MM/YYYY') AS ""Resolution Date"" " &
                "FROM TBL_BORROW_EXTEND e " &
                "JOIN TBL_BOOK_REQUEST r ON e.REQUEST_ID = r.REQUEST_ID " &
                "JOIN TBL_STUDENT s ON r.STUDENT_ID = s.STUDENT_ID " &
                "JOIN TBL_BOOKS b ON r.BOOK_ID = b.BOOK_ID " &
                "ORDER BY e.EXTEND_DATE DESC"

            Using cmd As New OracleCommand(selectQuery, conn)
                Dim adapter As New OracleDataAdapter(cmd)
                Dim dt As New DataTable()
                adapter.Fill(dt)

                ' Ensure STATUS values match ComboBox options
                For Each row As DataRow In dt.Rows
                    If row.IsNull("Status") OrElse Not {"Pending", "Approved", "Declined"}.Contains(row("Status").ToString()) Then
                        row("Status") = "Pending"
                    End If
                Next

                DataGridView1.DataSource = Nothing
                DataGridView1.Columns.Clear()
                DataGridView1.AutoGenerateColumns = False

                ' Add columns
                DataGridView1.Columns.Add(New DataGridViewTextBoxColumn() With {
                    .DataPropertyName = "Extend ID",
                    .HeaderText = "Extend ID",
                    .Name = "Extend ID",
                    .ReadOnly = True
                })
                DataGridView1.Columns.Add(New DataGridViewTextBoxColumn() With {
                    .DataPropertyName = "Request ID",
                    .HeaderText = "Request ID",
                    .Name = "Request ID",
                    .ReadOnly = True
                })
                DataGridView1.Columns.Add(New DataGridViewTextBoxColumn() With {
                    .DataPropertyName = "Student Name",
                    .HeaderText = "Student Name",
                    .Name = "Student Name",
                    .ReadOnly = True
                })
                DataGridView1.Columns.Add(New DataGridViewTextBoxColumn() With {
                    .DataPropertyName = "Book Title",
                    .HeaderText = "Book Title",
                    .Name = "Book Title",
                    .ReadOnly = True
                })
                DataGridView1.Columns.Add(New DataGridViewTextBoxColumn() With {
                    .DataPropertyName = "Extend Request Date",
                    .HeaderText = "Extend Request Date",
                    .Name = "Extend Request Date",
                    .ReadOnly = True
                })
                DataGridView1.Columns.Add(New DataGridViewTextBoxColumn() With {
                    .DataPropertyName = "Resolution Date",
                    .HeaderText = "Resolution Date",
                    .Name = "Resolution Date",
                    .ReadOnly = True
                })

                ' Add Status ComboBox column
                Dim statusCol As New DataGridViewComboBoxColumn() With {
                    .DataPropertyName = "Status",
                    .HeaderText = "Status",
                    .Name = "Status",
                    .DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton,
                    .FlatStyle = FlatStyle.Flat,
                    .ReadOnly = False,
                    .DisplayStyleForCurrentCellOnly = True
                }
                statusCol.Items.Add("Pending")
                statusCol.Items.Add("Approved")
                statusCol.Items.Add("Declined")
                DataGridView1.Columns.Add(statusCol)

                DataGridView1.EditMode = DataGridViewEditMode.EditOnEnter

                DataGridView1.DataSource = dt

                ' Make status cell read-only if already finalized
                For Each row As DataGridViewRow In DataGridView1.Rows
                    If row.Cells("Status").Value IsNot Nothing Then
                        Dim status As String = row.Cells("Status").Value.ToString()
                        If status = "Approved" Or status = "Declined" Then
                            row.Cells("Status").ReadOnly = True
                        Else
                            row.Cells("Status").ReadOnly = False
                        End If
                    End If
                Next
            End Using
        End Using
    End Sub

    Private Sub DataGridView1_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DataGridView1.CellBeginEdit
        If DataGridView1.Columns(e.ColumnIndex).Name = "Status" Then
            previousStatus = DataGridView1.Rows(e.RowIndex).Cells("Status").Value.ToString()
            Dim dgvCombo As DataGridViewComboBoxCell = CType(DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex), DataGridViewComboBoxCell)
            dgvCombo.Items.Clear()
            If previousStatus = "Approved" Or previousStatus = "Declined" Then
                dgvCombo.Items.Add(previousStatus)
            Else
                dgvCombo.Items.Add("Pending")
                dgvCombo.Items.Add("Approved")
                dgvCombo.Items.Add("Declined")
            End If
        End If
    End Sub

    Private Sub DataGridView1_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing
        If DataGridView1.CurrentCell.ColumnIndex = DataGridView1.Columns("Status").Index Then
            Dim combo As ComboBox = TryCast(e.Control, ComboBox)
            If combo IsNot Nothing Then
                RemoveHandler combo.SelectedIndexChanged, AddressOf StatusComboBox_SelectedIndexChanged
                AddHandler combo.SelectedIndexChanged, AddressOf StatusComboBox_SelectedIndexChanged
            End If
        End If
    End Sub

    Private Sub StatusComboBox_SelectedIndexChanged(sender As Object, e As EventArgs)
        DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        If isUpdatingStatus Then Exit Sub
        If e.RowIndex >= 0 AndAlso DataGridView1.Columns(e.ColumnIndex).Name = "Status" Then
            Dim extendId = DataGridView1.Rows(e.RowIndex).Cells("Extend ID").Value
            Dim requestId = DataGridView1.Rows(e.RowIndex).Cells("Request ID").Value
            Dim newStatus = DataGridView1.Rows(e.RowIndex).Cells("Status").Value.ToString()

            If (previousStatus = "Approved" Or previousStatus = "Declined") AndAlso newStatus = "Pending" Then
                MessageBox.Show("You cannot set the status back to Pending after it has been Approved or Declined.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                isUpdatingStatus = True
                DataGridView1.Rows(e.RowIndex).Cells("Status").Value = previousStatus
                isUpdatingStatus = False
                Exit Sub
            End If

            If (newStatus = "Approved" Or newStatus = "Declined") AndAlso previousStatus <> newStatus Then
                Dim result = MessageBox.Show($"Are you sure you want to set this extension as {newStatus}?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    Try
                        UpdateExtendStatusAndResolutionDateInDatabase(extendId, newStatus, Date.Today)
                        isUpdatingStatus = True
                        DataGridView1.Rows(e.RowIndex).Cells("Resolution Date").Value = Date.Today.ToString("dd/MM/yyyy")
                        DataGridView1.Rows(e.RowIndex).Cells("Status").ReadOnly = True
                        isUpdatingStatus = False
                        If newStatus = "Approved" Then
                            UpdateBorrowingDueDate(requestId)
                        End If
                        LoadExtendData()
                    Catch ex As Exception
                        MessageBox.Show("DB update error: " & ex.Message)
                        isUpdatingStatus = True
                        DataGridView1.Rows(e.RowIndex).Cells("Status").Value = "Pending"
                        isUpdatingStatus = False
                        UpdateExtendStatusAndResolutionDateInDatabase(extendId, "Pending", DBNull.Value)
                    End Try
                Else
                    isUpdatingStatus = True
                    DataGridView1.Rows(e.RowIndex).Cells("Status").Value = "Pending"
                    DataGridView1.Rows(e.RowIndex).Cells("Resolution Date").Value = ""
                    isUpdatingStatus = False
                    UpdateExtendStatusAndResolutionDateInDatabase(extendId, "Pending", DBNull.Value)
                End If
            ElseIf newStatus = "Pending" Then
                Try
                    UpdateExtendStatusAndResolutionDateInDatabase(extendId, newStatus, DBNull.Value)
                    isUpdatingStatus = True
                    DataGridView1.Rows(e.RowIndex).Cells("Resolution Date").Value = ""
                    isUpdatingStatus = False
                Catch ex As Exception
                    MessageBox.Show("DB update error: " & ex.Message)
                End Try
            Else
                Try
                    UpdateExtendStatusAndResolutionDateInDatabase(extendId, newStatus, DBNull.Value)
                Catch ex As Exception
                    MessageBox.Show("DB update error: " & ex.Message)
                End Try
            End If
        End If
    End Sub

    Private Sub UpdateExtendStatusAndResolutionDateInDatabase(extendId As Object, newStatus As String, resolutionDate As Object)
        Dim connectionString As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"
        Dim query As String = "UPDATE TBL_BORROW_EXTEND SET STATUS = :status, RESOLUTION_DATE = :resolutionDate WHERE EXTEND_ID = :extendId"
        Using conn As New OracleConnection(connectionString)
            conn.Open()
            Using cmd As New OracleCommand(query, conn)
                cmd.Parameters.Add(":status", OracleDbType.Varchar2).Value = newStatus
                If resolutionDate Is DBNull.Value Then
                    cmd.Parameters.Add(":resolutionDate", OracleDbType.Date).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(":resolutionDate", OracleDbType.Date).Value = resolutionDate
                End If
                cmd.Parameters.Add(":extendId", OracleDbType.Int32).Value = Convert.ToInt32(extendId)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub UpdateBorrowingDueDate(requestId As Object)
        Dim connectionString As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"
        Dim query As String = "UPDATE TBL_BORROWING SET RETURN_DUE_DATE = RETURN_DUE_DATE + 1 WHERE BORROWING_ID = (SELECT BORROWING_ID FROM TBL_BOOK_REQUEST WHERE REQUEST_ID = :requestId)"
        Using conn As New OracleConnection(connectionString)
            conn.Open()
            Using cmd As New OracleCommand(query, conn)
                cmd.Parameters.Add(":requestId", OracleDbType.Int32).Value = Convert.ToInt32(requestId)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub DataGridView1_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DataGridView1.CurrentCellDirtyStateChanged
        If DataGridView1.IsCurrentCellDirty Then
            DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles BtnLog.Click
        Dim parentForm = Me.Parent
        While parentForm IsNot Nothing AndAlso Not TypeOf parentForm Is CFMonitoring
            parentForm = parentForm.Parent
        End While

        If TypeOf parentForm Is CFMonitoring Then
            CType(parentForm, CFMonitoring).ChildForm(New CFBorrowing())
            CType(parentForm, CFMonitoring).UpdateDashboardLabel("Borrowing Monitoring")
        End If
    End Sub

    Private Sub BtnRequest_Click(sender As Object, e As EventArgs) Handles BtnRequest.Click
        Dim parentForm = Me.Parent
        While parentForm IsNot Nothing AndAlso Not TypeOf parentForm Is CFMonitoring
            parentForm = parentForm.Parent
        End While

        If TypeOf parentForm Is CFMonitoring Then
            CType(parentForm, CFMonitoring).ChildForm(New CFRequests())
            CType(parentForm, CFMonitoring).UpdateDashboardLabel("Requests Monitoring")
        End If
    End Sub
End Class
