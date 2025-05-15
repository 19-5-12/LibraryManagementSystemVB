Imports Oracle.ManagedDataAccess.Client

Public Class CFRequests
    Private SelectedStartDate As Date?
    Private SelectedEndDate As Date?
    Private previousStatus As String = ""

    Private Sub CFRequests_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim CRUDBtns As Button() = {BtnViewStats}
        SetupFormUI(CRUDBtns, DataGridView1, TimerDateTime, LblDateTimeRequests, AddressOf LoadRequestsData)
        TBLPRequests.Padding = New Padding(3)
        ' Initialize date pickers
        DateTimePickerStart.MaxDate = DateTime.Today
        DateTimePickerEnd.MaxDate = DateTime.Today
        ' Hide date panels initially
        PnlDateStart.Visible = False
        PnlDateEnd.Visible = False
        ' Setup ComboSearchDate
        ComboSearchDate.Items.Insert(0, "Select Date Range")
        ComboSearchDate.SelectedIndex = 0
        ' Show all records on load
        LoadRequestsData()
    End Sub

    Private Sub LoadRequestsData(Optional filterByDate As Boolean = False)
        Dim connectionString As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"

        Using conn As New OracleConnection(connectionString)
            conn.Open()

            Dim selectQuery As String = "SELECT " &
                "r.REQUEST_ID AS ""Request ID"", " &
                "s.FIRST_NAME || ' ' || s.LAST_NAME AS ""Student Name"", " &
                "b.TITLE AS ""Book Title"", " &
                "TO_CHAR(r.REQUEST_DATE, 'DD/MM/YYYY') AS ""Request Date"", " &
                "r.STATUS AS ""Status"", " &
                "TO_CHAR(r.RESOLUTION_DATE, 'DD/MM/YYYY') AS ""Resolution Date"" " &
                "FROM TBL_BOOK_REQUEST r " &
                "JOIN TBL_STUDENT s ON r.STUDENT_ID = s.STUDENT_ID " &
                "JOIN TBL_BOOKS b ON r.BOOK_ID = b.BOOK_ID"

            If filterByDate AndAlso SelectedStartDate.HasValue AndAlso SelectedEndDate.HasValue Then
                selectQuery &= " WHERE r.REQUEST_DATE BETWEEN :startDate AND :endDate"
            End If

            selectQuery &= " ORDER BY r.REQUEST_DATE DESC"

            Using cmd As New OracleCommand(selectQuery, conn)
                If filterByDate AndAlso SelectedStartDate.HasValue AndAlso SelectedEndDate.HasValue Then
                    cmd.Parameters.Add(":startDate", OracleDbType.Date).Value = SelectedStartDate.Value
                    cmd.Parameters.Add(":endDate", OracleDbType.Date).Value = SelectedEndDate.Value
                End If

                Dim adapter As New OracleDataAdapter(cmd)
                Dim dt As New DataTable()
                adapter.Fill(dt)

                ' Ensure STATUS values match ComboBox options
                For Each row As DataRow In dt.Rows
                    If row.IsNull("Status") OrElse Not {"Pending", "Approved", "Declined"}.Contains(row("Status").ToString()) Then
                        row("Status") = "Pending"
                    End If
                Next

                ' Instantly update DB for Approved/Declined with null resolution date
                For Each row As DataRow In dt.Rows
                    If (row("Status").ToString() = "Approved" Or row("Status").ToString() = "Declined") AndAlso String.IsNullOrWhiteSpace(row("Resolution Date").ToString()) Then
                        UpdateStatusAndResolutionDateInDatabase(row("Request ID"), row("Status").ToString(), Date.Today)
                        row("Resolution Date") = Date.Today.ToString("dd/MM/yyyy")
                    End If
                Next

                DataGridView1.DataSource = Nothing
                DataGridView1.Columns.Clear()
                DataGridView1.AutoGenerateColumns = False

                ' Add columns
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
                    .DataPropertyName = "Request Date",
                    .HeaderText = "Request Date",
                    .Name = "Request Date",
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

    Private Sub TBLPRequests_Paint(sender As Object, e As PaintEventArgs) Handles TBLPRequests.Paint
        StyleShadowPanel(CType(sender, Panel), e)
    End Sub

    Private Sub BtnViewStats_Click(sender As Object, e As EventArgs) Handles BtnViewStats.Click
        If ComboSearchDate.SelectedItem IsNot Nothing AndAlso ComboSearchDate.SelectedItem.ToString = "Custom Range" Then
            SelectedStartDate = DateTimePickerStart.Value.Date
            SelectedEndDate = DateTimePickerEnd.Value.Date
        End If

        If SelectedStartDate.HasValue AndAlso SelectedEndDate.HasValue Then
            LoadRequestsData(True)
        Else
            MessageBox.Show("Please select a valid date range first.")
        End If
    End Sub

    Private Sub ComboSearchDate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboSearchDate.SelectedIndexChanged
        If ComboSearchDate.SelectedIndex = 0 Then
            SelectedStartDate = Nothing
            SelectedEndDate = Nothing
            PnlDateStart.Visible = False
            PnlDateEnd.Visible = False
            LoadRequestsData() ' Show all records
            Exit Sub
        End If

        Dim startDate As Date
        Dim endDate = Date.Today

        Select Case ComboSearchDate.SelectedItem.ToString
            Case "Today"
                startDate = Date.Today
                PnlDateStart.Visible = False
                PnlDateEnd.Visible = False
            Case "This Week"
                startDate = Date.Today.AddDays(-CInt(Date.Today.DayOfWeek))
                PnlDateStart.Visible = False
                PnlDateEnd.Visible = False
            Case "This Month"
                startDate = New Date(Date.Today.Year, Date.Today.Month, 1)
                endDate = startDate.AddMonths(1).AddDays(-1)
                PnlDateStart.Visible = False
                PnlDateEnd.Visible = False
            Case "This Year"
                startDate = New Date(Date.Today.Year, 1, 1)
                endDate = New Date(Date.Today.Year, 12, 31)
                PnlDateStart.Visible = False
                PnlDateEnd.Visible = False
            Case "Custom Range"
                PnlDateStart.Visible = True
                PnlDateEnd.Visible = True
                Exit Sub
            Case Else
                Exit Sub
        End Select

        SelectedStartDate = startDate
        SelectedEndDate = endDate
        LoadRequestsData(True) ' Apply the filter immediately
    End Sub

    ' Save status changes to the database
    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        If e.RowIndex >= 0 AndAlso DataGridView1.Columns(e.ColumnIndex).Name = "Status" Then
            Dim requestId = DataGridView1.Rows(e.RowIndex).Cells("Request ID").Value
            Dim newStatus = DataGridView1.Rows(e.RowIndex).Cells("Status").Value.ToString()

            ' Prevent changing back to Pending if already Approved/Declined
            If (previousStatus = "Approved" Or previousStatus = "Declined") AndAlso newStatus = "Pending" Then
                MessageBox.Show("You cannot set the status back to Pending after it has been Approved or Declined.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                DataGridView1.Rows(e.RowIndex).Cells("Status").Value = previousStatus
                Exit Sub
            End If

            ' If changing to Approved or Declined, ask for confirmation
            If (newStatus = "Approved" Or newStatus = "Declined") AndAlso previousStatus <> newStatus Then
                Dim result = MessageBox.Show($"Are you sure you want to set this request as {newStatus}?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    UpdateStatusAndResolutionDateInDatabase(requestId, newStatus, Date.Today)
                    DataGridView1.Rows(e.RowIndex).Cells("Resolution Date").Value = Date.Today.ToString("dd/MM/yyyy")
                    DataGridView1.Rows(e.RowIndex).Cells("Status").ReadOnly = True
                    LoadRequestsData() ' Reload to enforce lock and update UI
                Else
                    DataGridView1.Rows(e.RowIndex).Cells("Status").Value = previousStatus
                End If
            ElseIf newStatus = "Pending" Then
                UpdateStatusAndResolutionDateInDatabase(requestId, newStatus, DBNull.Value)
                DataGridView1.Rows(e.RowIndex).Cells("Resolution Date").Value = ""
            Else
                UpdateStatusAndResolutionDateInDatabase(requestId, newStatus, DBNull.Value)
            End If
        End If
    End Sub

    ' Commit edit immediately when ComboBox changes
    Private Sub DataGridView1_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DataGridView1.CurrentCellDirtyStateChanged
        If DataGridView1.IsCurrentCellDirty Then
            DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub UpdateStatusAndResolutionDateInDatabase(requestId As Object, newStatus As String, resolutionDate As Object)
        Dim connectionString As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"
        Dim query As String = "UPDATE TBL_BOOK_REQUEST SET STATUS = :status, RESOLUTION_DATE = :resolutionDate WHERE REQUEST_ID = :requestId"
        Using conn As New OracleConnection(connectionString)
            conn.Open()
            Using cmd As New OracleCommand(query, conn)
                cmd.Parameters.Add(":status", OracleDbType.Varchar2).Value = newStatus
                If resolutionDate Is DBNull.Value Then
                    cmd.Parameters.Add(":resolutionDate", OracleDbType.Date).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(":resolutionDate", OracleDbType.Date).Value = resolutionDate
                End If
                cmd.Parameters.Add(":requestId", OracleDbType.Int32).Value = Convert.ToInt32(requestId)
                cmd.ExecuteNonQuery()
            End Using
        End Using
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

    Private Sub BtnExtend_Click(sender As Object, e As EventArgs) Handles BtnExtend.Click
        Dim parentForm = Me.Parent
        While parentForm IsNot Nothing AndAlso Not TypeOf parentForm Is CFMonitoring
            parentForm = parentForm.Parent
        End While

        If TypeOf parentForm Is CFMonitoring Then
            CType(parentForm, CFMonitoring).ChildForm(New CFExtend())
            CType(parentForm, CFMonitoring).UpdateDashboardLabel("Borrowing Extention Monitoring")
        End If
    End Sub

    Private Sub DataGridView1_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DataGridView1.CellBeginEdit
        If DataGridView1.Columns(e.ColumnIndex).Name = "Status" Then
            previousStatus = DataGridView1.Rows(e.RowIndex).Cells("Status").Value.ToString()

            ' Dynamically set ComboBox items for this cell
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

End Class