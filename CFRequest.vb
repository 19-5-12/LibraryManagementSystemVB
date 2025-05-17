Imports Oracle.ManagedDataAccess.Client
Imports Oracle.ManagedDataAccess.Types ' Required for OracleDbType.Date if not already implicitly available

Public Class CFRequests

    Private isLoading As Boolean = False
    Private SelectedStartDate As Date?
    Private SelectedEndDate As Date?
    Private previousStatus As String = ""

    ' NEW CODE: Define a default borrowing period
    Private Const DefaultBorrowingDays As Integer = 7 ' e.g., 7 days

    Private Sub CFRequests_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isLoading = True
        Dim CRUDBtns As Button() = {BtnViewStats}
        SetupFormUI(CRUDBtns, DataGridView1, TimerDateTime, LblDateTimeRequests, AddressOf LoadRequestsData)
        TBLPRequests.Padding = New Padding(3)
        DateTimePickerStart.MaxDate = DateTime.Today
        DateTimePickerEnd.MaxDate = DateTime.Today
        PnlDateStart.Visible = False
        PnlDateEnd.Visible = False
        ComboSearchDate.Items.Insert(0, "Select Date Range")
        ComboSearchDate.SelectedIndex = 0
        isLoading = False
        LoadRequestsData()
    End Sub


    Private Sub LoadRequestsData(Optional filterByDate As Boolean = False)
        Dim connectionString As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"
        Using conn As New OracleConnection(connectionString)
            conn.Open()
            Dim selectQuery As String = "SELECT DISTINCT " &
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
            selectQuery &= " ORDER BY r.REQUEST_ID DESC"
            Using cmd As New OracleCommand(selectQuery, conn)
                If filterByDate AndAlso SelectedStartDate.HasValue AndAlso SelectedEndDate.HasValue Then
                    cmd.Parameters.Add(":startDate", OracleDbType.Date).Value = SelectedStartDate.Value
                    cmd.Parameters.Add(":endDate", OracleDbType.Date).Value = SelectedEndDate.Value
                End If
                Dim adapter As New OracleDataAdapter(cmd)
                Dim dt As New DataTable()
                adapter.Fill(dt)
                For Each row As DataRow In dt.Rows
                    If row.IsNull("Status") OrElse Not {"Pending", "Approved", "Declined"}.Contains(row("Status").ToString()) Then
                        row("Status") = "Pending"
                    End If
                Next
                ' This loop is for initial data hygiene, main logic is in CellValueChanged
                For Each row As DataRow In dt.Rows
                    If (row("Status").ToString() = "Approved" Or row("Status").ToString() = "Declined") AndAlso String.IsNullOrWhiteSpace(row("Resolution Date").ToString()) Then
                        UpdateStatusAndResolutionDateInDatabase(row("Request ID"), row("Status").ToString(), Date.Today)
                        row("Resolution Date") = Date.Today.ToString("dd/MM/yyyy")
                    End If
                Next
                DataGridView1.DataSource = Nothing
                DataGridView1.Columns.Clear()
                DataGridView1.AutoGenerateColumns = False
                DataGridView1.Columns.Add(New DataGridViewTextBoxColumn() With {.DataPropertyName = "Request ID", .HeaderText = "Request ID", .Name = "Request ID", .ReadOnly = True})
                DataGridView1.Columns.Add(New DataGridViewTextBoxColumn() With {.DataPropertyName = "Student Name", .HeaderText = "Student Name", .Name = "Student Name", .ReadOnly = True})
                DataGridView1.Columns.Add(New DataGridViewTextBoxColumn() With {.DataPropertyName = "Book Title", .HeaderText = "Book Title", .Name = "Book Title", .ReadOnly = True})
                DataGridView1.Columns.Add(New DataGridViewTextBoxColumn() With {.DataPropertyName = "Request Date", .HeaderText = "Request Date", .Name = "Request Date", .ReadOnly = True})
                DataGridView1.Columns.Add(New DataGridViewTextBoxColumn() With {.DataPropertyName = "Resolution Date", .HeaderText = "Resolution Date", .Name = "Resolution Date", .ReadOnly = True})
                Dim statusCol As New DataGridViewComboBoxColumn() With {.DataPropertyName = "Status", .HeaderText = "Status", .Name = "Status", .DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton, .FlatStyle = FlatStyle.Flat, .ReadOnly = False, .DisplayStyleForCurrentCellOnly = True}
                statusCol.Items.Add("Pending")
                statusCol.Items.Add("Approved")
                statusCol.Items.Add("Declined")
                DataGridView1.Columns.Add(statusCol)
                DataGridView1.EditMode = DataGridViewEditMode.EditOnEnter
                DataGridView1.DataSource = dt
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
        ElseIf ComboSearchDate.SelectedItem IsNot Nothing AndAlso ComboSearchDate.SelectedItem.ToString <> "Custom Range" AndAlso ComboSearchDate.SelectedItem.ToString <> "Select Date Range" Then
            LoadRequestsData(True)
        ElseIf ComboSearchDate.SelectedItem IsNot Nothing AndAlso ComboSearchDate.SelectedItem.ToString = "Select Date Range" Then
            LoadRequestsData(False)
        Else
            MessageBox.Show("Please select a valid date range or 'Select Date Range' to clear filters.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ComboSearchDate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboSearchDate.SelectedIndexChanged
        If isLoading Then Exit Sub
        If ComboSearchDate.SelectedIndex = 0 Then
            SelectedStartDate = Nothing
            SelectedEndDate = Nothing
            PnlDateStart.Visible = False
            PnlDateEnd.Visible = False
            LoadRequestsData()
            Exit Sub
        End If
        Dim startDate As Date
        Dim endDate = Date.Today
        Select Case ComboSearchDate.SelectedItem.ToString
            Case "Today"
                startDate = Date.Today
                endDate = Date.Today
                PnlDateStart.Visible = False : PnlDateEnd.Visible = False
            Case "This Week"
                startDate = Date.Today.AddDays(-CInt(Date.Today.DayOfWeek))
                endDate = startDate.AddDays(6)
                PnlDateStart.Visible = False : PnlDateEnd.Visible = False
            Case "This Month"
                startDate = New Date(Date.Today.Year, Date.Today.Month, 1)
                endDate = startDate.AddMonths(1).AddDays(-1)
                PnlDateStart.Visible = False : PnlDateEnd.Visible = False
            Case "This Year"
                startDate = New Date(Date.Today.Year, 1, 1)
                endDate = New Date(Date.Today.Year, 12, 31)
                PnlDateStart.Visible = False : PnlDateEnd.Visible = False
            Case "Custom Range"
                PnlDateStart.Visible = True : PnlDateEnd.Visible = True
                SelectedStartDate = Nothing : SelectedEndDate = Nothing
                Exit Sub
            Case Else
                Exit Sub
        End Select
        SelectedStartDate = startDate
        SelectedEndDate = endDate
        LoadRequestsData(True)
    End Sub


    ' MODIFIED: DataGridView1_CellValueChanged
    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        If isLoading OrElse e.RowIndex < 0 OrElse DataGridView1.Rows(e.RowIndex).IsNewRow Then Exit Sub

        If DataGridView1.Columns(e.ColumnIndex).Name = "Status" Then
            Dim requestIdObj = DataGridView1.Rows(e.RowIndex).Cells("Request ID").Value
            If requestIdObj Is Nothing OrElse requestIdObj Is DBNull.Value Then Exit Sub ' Should not happen
            Dim requestId As Integer = Convert.ToInt32(requestIdObj)
            Dim newStatus = DataGridView1.Rows(e.RowIndex).Cells("Status").Value.ToString()

            If (previousStatus = "Approved" Or previousStatus = "Declined") AndAlso newStatus = "Pending" Then
                MessageBox.Show("You cannot set the status back to Pending after it has been Approved or Declined.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                isLoading = True
                DataGridView1.Rows(e.RowIndex).Cells("Status").Value = previousStatus
                isLoading = False
                Exit Sub
            End If

            If (newStatus = "Approved" Or newStatus = "Declined") AndAlso previousStatus <> newStatus Then
                Dim result = MessageBox.Show($"Are you sure you want to set this request as {newStatus}?", "Confirm Action", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    If newStatus = "Approved" Then
                        Dim requestDetails = GetRequestDetailsForBorrowing(requestId)
                        If requestDetails.StudentId > 0 AndAlso requestDetails.BookId > 0 Then
                            If DecrementBookQuantity(requestDetails.BookId) Then ' Step 1: Try to decrement quantity
                                Try
                                    ' Step 2: Quantity decremented, try to create borrowing record
                                    Dim borrowDate As Date = Date.Today
                                    Dim returnDueDate As Date = borrowDate.AddDays(DefaultBorrowingDays)
                                    InsertIntoBorrowing(requestDetails.StudentId, requestDetails.BookId, borrowDate, returnDueDate)

                                    ' Step 3: Borrowing record created, update request status
                                    UpdateStatusAndResolutionDateInDatabase(requestId, newStatus, Date.Today)

                                    ' All DB operations successful, update UI
                                    isLoading = True
                                    DataGridView1.Rows(e.RowIndex).Cells("Resolution Date").Value = Date.Today.ToString("dd/MM/yyyy")
                                    DataGridView1.Rows(e.RowIndex).Cells("Status").ReadOnly = True
                                    isLoading = False
                                    LoadRequestsData() ' Reload to reflect all changes
                                Catch exBorrow As Exception
                                    ' Failed to insert borrowing record (or update request status if moved there)
                                    ' Roll back quantity decrement
                                    IncrementBookQuantity(requestDetails.BookId)
                                    Dim errorMsg As String = $"Failed to finalize approval for Request ID {requestId}."
                                    If TypeOf exBorrow Is OracleException Then
                                        Dim oraEx = CType(exBorrow, OracleException)
                                        errorMsg &= $"{vbCrLf}Oracle Error: {oraEx.Message} (Code: {oraEx.Number})"
                                    Else
                                        errorMsg &= $"{vbCrLf}Error: {exBorrow.Message}"
                                    End If
                                    errorMsg &= $"{vbCrLf}Book quantity has been reverted."
                                    MessageBox.Show(errorMsg, "Operation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    ' Revert status in UI
                                    isLoading = True
                                    DataGridView1.Rows(e.RowIndex).Cells("Status").Value = previousStatus
                                    isLoading = False
                                    ' No need to call LoadRequestsData() here as we want the UI to reflect the revert
                                End Try
                            Else
                                ' Failed to decrement quantity (e.g., quantity was 0 or DB error during decrement)
                                ' DecrementBookQuantity function already shows a MessageBox for DB errors.
                                ' If it returns false without an error shown by itself, it means quantity was 0.
                                If Not Application.OpenForms.Cast(Of Form)().Any(Function(f) TypeOf f Is Form AndAlso f.Modal AndAlso f.Text.Contains("Database Error")) Then
                                    MessageBox.Show($"Failed to approve Request ID {requestId}: Book is out of stock.", "Approval Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                End If
                                ' Revert status in UI
                                isLoading = True
                                DataGridView1.Rows(e.RowIndex).Cells("Status").Value = previousStatus
                                isLoading = False
                            End If
                        Else
                            MessageBox.Show($"Could not retrieve student or book details for Request ID {requestId}. Approval failed.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            isLoading = True
                            DataGridView1.Rows(e.RowIndex).Cells("Status").Value = previousStatus
                            isLoading = False
                        End If
                    ElseIf newStatus = "Declined" Then
                        UpdateStatusAndResolutionDateInDatabase(requestId, newStatus, Date.Today)
                        isLoading = True
                        DataGridView1.Rows(e.RowIndex).Cells("Resolution Date").Value = Date.Today.ToString("dd/MM/yyyy")
                        DataGridView1.Rows(e.RowIndex).Cells("Status").ReadOnly = True
                        isLoading = False
                        LoadRequestsData()
                    End If
                Else
                    ' User clicked "No" on the confirmation MessageBox
                    isLoading = True
                    DataGridView1.Rows(e.RowIndex).Cells("Status").Value = previousStatus
                    isLoading = False
                End If
            ElseIf newStatus = "Pending" AndAlso previousStatus <> newStatus Then
                ' This case is for explicitly setting back to Pending IF it wasn't already Approved/Declined.
                ' The check at the beginning handles not reverting from Approved/Declined.
                UpdateStatusAndResolutionDateInDatabase(requestId, newStatus, DBNull.Value)
                isLoading = True
                DataGridView1.Rows(e.RowIndex).Cells("Resolution Date").Value = "" ' Clear resolution date
                isLoading = False
                ' Optional: LoadRequestsData() if needed, but usually not if just reverting a new edit.
            End If
        End If
    End Sub

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
                If resolutionDate Is DBNull.Value OrElse resolutionDate Is Nothing Then
                    cmd.Parameters.Add(":resolutionDate", OracleDbType.Date).Value = DBNull.Value
                Else
                    cmd.Parameters.Add(":resolutionDate", OracleDbType.Date).Value = Convert.ToDateTime(resolutionDate)
                End If
                cmd.Parameters.Add(":requestId", OracleDbType.Int32).Value = Convert.ToInt32(requestId)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    ' --- NEW HELPER FUNCTIONS ---
    Private Function GetRequestDetailsForBorrowing(requestId As Object) As (StudentId As Integer, BookId As Integer)
        Dim connectionString As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"
        Dim studentId As Integer = 0
        Dim bookId As Integer = 0
        Dim query As String = "SELECT STUDENT_ID, BOOK_ID FROM TBL_BOOK_REQUEST WHERE REQUEST_ID = :reqId"
        Using conn As New OracleConnection(connectionString)
            conn.Open()
            Using cmd As New OracleCommand(query, conn)
                cmd.Parameters.Add(":reqId", OracleDbType.Int32).Value = Convert.ToInt32(requestId)
                Using reader As OracleDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        studentId = Convert.ToInt32(reader("STUDENT_ID"))
                        bookId = Convert.ToInt32(reader("BOOK_ID"))
                    End If
                End Using
            End Using
        End Using
        Return (studentId, bookId)
    End Function

    Private Sub InsertIntoBorrowing(studentId As Integer, bookId As Integer, borrowDate As Date, returnDueDate As Date)
        Dim connectionString As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"
        Dim query As String = "INSERT INTO TBL_BORROWING (USER_ID, BOOK_ID, BORROW_DATE, RETURN_DUE_DATE, STATUS) " &
                              "VALUES (:userId, :bookId, :borrowDate, :returnDueDate, :status)"
        Using conn As New OracleConnection(connectionString)
            conn.Open()
            Using cmd As New OracleCommand(query, conn)
                cmd.Parameters.Add(":userId", OracleDbType.Int32).Value = studentId
                cmd.Parameters.Add(":bookId", OracleDbType.Int32).Value = bookId
                cmd.Parameters.Add(":borrowDate", OracleDbType.Date).Value = borrowDate
                cmd.Parameters.Add(":returnDueDate", OracleDbType.Date).Value = returnDueDate
                cmd.Parameters.Add(":status", OracleDbType.Varchar2).Value = "BORROWING"
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Function DecrementBookQuantity(bookId As Integer) As Boolean
        Dim connectionString As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"
        Dim query As String = "UPDATE TBL_BOOKS SET QUANTITY_AVAILABLE = QUANTITY_AVAILABLE - 1 WHERE BOOK_ID = :bookId AND QUANTITY_AVAILABLE > 0"
        Dim rowsAffected As Integer = 0
        Try
            Using conn As New OracleConnection(connectionString)
                conn.Open()
                Using cmd As New OracleCommand(query, conn)
                    cmd.Parameters.Add(":bookId", OracleDbType.Int32).Value = bookId
                    rowsAffected = cmd.ExecuteNonQuery()
                End Using
            End Using
            Return rowsAffected > 0 ' True if one row was updated
        Catch ex As OracleException
            MessageBox.Show($"Error decrementing book quantity for Book ID {bookId}: {ex.Message & vbCrLf & ex.Number}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False ' Indicate failure
        Catch ex As Exception
            MessageBox.Show($"Generic error decrementing book quantity for Book ID {bookId}: {ex.Message}", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Private Sub IncrementBookQuantity(bookId As Integer)
        Dim connectionString As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"
        Dim query As String = "UPDATE TBL_BOOKS SET QUANTITY_AVAILABLE = QUANTITY_AVAILABLE + 1 WHERE BOOK_ID = :bookId"
        Try
            Using conn As New OracleConnection(connectionString)
                conn.Open()
                Using cmd As New OracleCommand(query, conn)
                    cmd.Parameters.Add(":bookId", OracleDbType.Int32).Value = bookId
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            ' Log this critical error as a rollback action failed.
            MessageBox.Show($"CRITICAL ERROR: Failed to re-increment book quantity for Book ID {bookId}. Please check database manually. Error: {ex.Message}", "Rollback Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' --- END NEW HELPER FUNCTIONS ---


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
        If isLoading Then
            e.Cancel = True
            Exit Sub
        End If
        If e.RowIndex >= 0 AndAlso DataGridView1.Columns(e.ColumnIndex).Name = "Status" Then
            If DataGridView1.Rows(e.RowIndex).Cells("Status").Value IsNot Nothing Then
                previousStatus = DataGridView1.Rows(e.RowIndex).Cells("Status").Value.ToString()
            Else
                previousStatus = "Pending" ' Default if somehow null
            End If
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