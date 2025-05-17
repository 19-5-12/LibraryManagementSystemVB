Imports Oracle.ManagedDataAccess.Client

Public Class CFBorrowing
    Private SelectedStartDate As Date?
    Private SelectedEndDate As Date?

    Private Sub CFBorrowing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim CRUDBtns As Button() = {BtnViewStats}
        SetupFormUI(CRUDBtns, DataGridView1, TimerDateTime, LblDateTimeBorrowing, AddressOf LoadBorrowingData)

        TBLPBorrowing.Padding = New Padding(3)

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
        LoadBorrowingData()
    End Sub

    Private Sub LoadBorrowingData(Optional filterByDate As Boolean = False)
        Dim connectionString As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"

        Using conn As New OracleConnection(connectionString)
            conn.Open()

            ' 1. First update RETURNED OVERDUE status for returned items
            Dim updateReturnedOverdueSql As String = "
            UPDATE TBL_BORROWING
            SET STATUS = 'RETURNED OVERDUE'
            WHERE RETURN_DATE IS NOT NULL
              AND RETURN_DATE > RETURN_DUE_DATE
              AND STATUS != 'RETURNED OVERDUE'"

            Using cmdReturnedOverdue As New OracleCommand(updateReturnedOverdueSql, conn)
                cmdReturnedOverdue.ExecuteNonQuery()
            End Using

            ' 2. Correct status from RETURNED OVERDUE back to RETURNED if return was actually on time
            Dim fixWrongReturnedOverdueSql As String = "
            UPDATE TBL_BORROWING
            SET STATUS = 'RETURNED'
            WHERE STATUS = 'RETURNED OVERDUE'
              AND RETURN_DATE <= RETURN_DUE_DATE"

            Using fixCmd As New OracleCommand(fixWrongReturnedOverdueSql, conn)
                fixCmd.ExecuteNonQuery()
            End Using

            ' 3. Update status to "OVERDUE" ONLY for unreturned items where due date has passed
            Dim updateOverdueSql As String = "
            UPDATE TBL_BORROWING
            SET STATUS = 'OVERDUE'
            WHERE STATUS = 'BORROWING'
              AND RETURN_DUE_DATE < TRUNC(SYSDATE)
              AND RETURN_DATE IS NULL"

            Using cmdOverdue As New OracleCommand(updateOverdueSql, conn)
                cmdOverdue.ExecuteNonQuery()
            End Using

            ' 4. Change back to BORROWING if due date is in the future (shouldn't be needed but just in case)
            Dim fixWrongOverdueSql As String = "
            UPDATE TBL_BORROWING
            SET STATUS = 'BORROWING'
            WHERE STATUS = 'OVERDUE'
              AND RETURN_DUE_DATE >= TRUNC(SYSDATE)"

            Using fixOverdueCmd As New OracleCommand(fixWrongOverdueSql, conn)
                fixOverdueCmd.ExecuteNonQuery()
            End Using

            ' Load the data for display
            Dim selectQuery As String = "SELECT DISTINCT
                b.BORROWING_ID AS ""Borrow ID"",
                s.FIRST_NAME || ' ' || s.LAST_NAME AS ""Student Name"",
                bo.TITLE AS ""Book Title"",
                TO_CHAR(b.BORROW_DATE, 'DD/MM/YYYY') AS ""Borrowed Date"",
                TO_CHAR(b.RETURN_DUE_DATE, 'DD/MM/YYYY') AS ""Due Date"",
                TO_CHAR(b.RETURN_DATE, 'DD/MM/YYYY') AS ""Return Date"",
                b.STATUS AS ""Status""
                FROM TBL_BORROWING b
                JOIN TBL_STUDENT s ON b.USER_ID = s.STUDENT_ID
                JOIN TBL_BOOKS bo ON b.BOOK_ID = bo.BOOK_ID"

            If filterByDate AndAlso SelectedStartDate.HasValue AndAlso SelectedEndDate.HasValue Then
                selectQuery &= " WHERE b.BORROW_DATE BETWEEN :startDate AND :endDate"
            End If

            selectQuery &= " ORDER BY ""Borrowed Date"" DESC"

            Using cmd As New OracleCommand(selectQuery, conn)
                If filterByDate AndAlso SelectedStartDate.HasValue AndAlso SelectedEndDate.HasValue Then
                    cmd.Parameters.Add(":startDate", OracleDbType.Date).Value = SelectedStartDate.Value
                    cmd.Parameters.Add(":endDate", OracleDbType.Date).Value = SelectedEndDate.Value
                End If

                Dim adapter As New OracleDataAdapter(cmd)
                Dim dt As New DataTable()
                adapter.Fill(dt)
                DataGridView1.DataSource = dt
            End Using
        End Using
    End Sub

    Private Sub TBLPBorrowing_Paint(sender As Object, e As PaintEventArgs) Handles TBLPBorrowing.Paint
        StyleShadowPanel(CType(sender, Panel), e)
    End Sub

    Private Sub BtnViewStats_Click(sender As Object, e As EventArgs) Handles BtnViewStats.Click
        If ComboSearchDate.SelectedItem IsNot Nothing AndAlso ComboSearchDate.SelectedItem.ToString = "Custom Range" Then
            SelectedStartDate = DateTimePickerStart.Value.Date
            SelectedEndDate = DateTimePickerEnd.Value.Date
        End If

        If SelectedStartDate.HasValue AndAlso SelectedEndDate.HasValue Then
            LoadBorrowingData(True)
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
            LoadBorrowingData() ' Show all records
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
        LoadBorrowingData(True) ' Apply the filter immediately
    End Sub

    Private Sub BtnRequest_Click(sender As Object, e As EventArgs) Handles BtnRequest.Click
        ' Find the parent CFMonitoring form
        Dim parentForm = Me.Parent
        While parentForm IsNot Nothing AndAlso Not TypeOf parentForm Is CFMonitoring
            parentForm = parentForm.Parent
        End While

        If TypeOf parentForm Is CFMonitoring Then
            CType(parentForm, CFMonitoring).ChildForm(New CFRequests())
            CType(parentForm, CFMonitoring).UpdateDashboardLabel("Requests Monitoring")
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
End Class