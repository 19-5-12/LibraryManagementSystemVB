Imports Oracle.ManagedDataAccess.Client

Public Class FormModifyBorrowing
    Public Event BorrowModified As EventHandler
    Private Sub FormModifyBorrowing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        roundedPanels.Clear()

        ComboStatus.Items.Insert(0, "Select Status")
        ComboStatus.SelectedIndex = 0

        DTPReturnDate.MaxDate = DateTime.Today
        DTPReturnDate.MinDate = DateTime.Today.AddYears(-200)

        Dim paddedPanels = {PnlBorderSelectID, PnlBorderBookID, PnlBorderBorrowID, PnlBorderStudentID, PnlBorderBorrowedDate,
            PnlBorderDueDate, PnlBorderReturnDate, PnlBorderStatus}
        For Each pnl In paddedPanels
            pnl.Padding = New Padding(3)
        Next
        PnlFill.Padding = New Padding(10)

        SetupPlaceholder(TxtBorrowID, "Enter Borrowing ID")
        SetupPlaceholder(TxtStudentID, "Enter Student ID")
        SetupPlaceholder(TxtBookID, "Enter Book ID")
        SetupPlaceholder(TxtSelectID, "Enter Borrowing ID to modify")

        roundedPanels.Add(PnlFill, 20)
        roundedPanels.Add(PnlBorderBorrowID, 5)
        roundedPanels.Add(PnlBorderStudentID, 5)
        roundedPanels.Add(PnlBorderBookID, 5)
        roundedPanels.Add(PnlBorderBorrowedDate, 5)
        roundedPanels.Add(PnlBorderDueDate, 5)
        roundedPanels.Add(PnlBorderReturnDate, 5)
        roundedPanels.Add(PnlBorderStatus, 5)
        roundedPanels.Add(PnlBorderSelectID, 5)
    End Sub

    Private Sub Modify_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        BtnSave.Focus()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub Panel_Paint(sender As Object, e As PaintEventArgs) Handles PnlFill.Paint, PnlBorderSelectID.Paint, PnlBorderBookID.Paint,
        PnlBorderBorrowID.Paint, PnlBorderStudentID.Paint, PnlBorderBorrowedDate.Paint, PnlBorderDueDate.Paint,
        PnlBorderReturnDate.Paint, PnlBorderStatus.Paint

        HandlePanelPaint(sender, e)
    End Sub

    Private Sub TxtSelectID_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtSelectID.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            LoadBorrowingDataByID()

        End If
    End Sub

    Private Sub LoadBorrowingDataByID()
        Dim connStr As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"
        Dim borrowId As String = TxtSelectID.Text.Trim()

        If Not IsNumeric(borrowId) Then
            MessageBox.Show("Please enter a valid numeric Borrowing ID.")
            Return
        End If

        Try
            Using conn As New OracleConnection(connStr)
                conn.Open()
                Dim sql As String = "SELECT * FROM TBL_BORROWING WHERE BORROWING_ID = :borrowId"
                Using cmd As New OracleCommand(sql, conn)
                    cmd.Parameters.Add(":borrowId", OracleDbType.Int32).Value = Integer.Parse(borrowId)

                    Using reader As OracleDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            TxtBorrowID.Text = reader("BORROWING_ID").ToString()
                            TxtBorrowID.ForeColor = SystemColors.WindowText
                            TxtStudentID.Text = reader("USER_ID").ToString()
                            TxtStudentID.ForeColor = SystemColors.WindowText
                            TxtBookID.Text = reader("BOOK_ID").ToString()
                            TxtBookID.ForeColor = SystemColors.WindowText
                            DTPBorrowedDate.Value = Convert.ToDateTime(reader("BORROW_DATE"))
                            DTPDueDate.Value = Convert.ToDateTime(reader("RETURN_DUE_DATE"))

                            If reader("RETURN_DATE") Is DBNull.Value Then
                                DTPReturnDate.Value = DateTime.Today
                            Else
                                Dim returnDate As DateTime = Convert.ToDateTime(reader("RETURN_DATE"))
                                If returnDate < DTPReturnDate.MinDate Then
                                    DTPReturnDate.Value = DTPReturnDate.MinDate
                                ElseIf returnDate > DTPReturnDate.MaxDate Then
                                    DTPReturnDate.Value = DTPReturnDate.MaxDate
                                Else
                                    DTPReturnDate.Value = returnDate
                                End If
                            End If

                            ComboStatus.SelectedItem = reader("STATUS").ToString()
                        Else
                            MessageBox.Show("Borrowing ID not found.")
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

        If Not IsNumeric(TxtBorrowID.Text) OrElse Not IsNumeric(TxtStudentID.Text) OrElse Not IsNumeric(TxtBookID.Text) Then
            MessageBox.Show("Borrow ID, Student ID, and Book ID must all be valid numbers.")
            Return
        End If

        If ComboStatus.SelectedIndex = 0 Then
            MessageBox.Show("Please select a valid status.")
            Return
        End If

        Dim status As String = ComboStatus.SelectedItem.ToString()
        Dim returnDate As Object = If(status = "BORROWING", DBNull.Value, CType(DTPReturnDate.Value, Object))

        If status = "RETURNED" AndAlso DTPReturnDate.Value.Date > DateTime.Now.Date Then
            MessageBox.Show("Return date cannot be in the future.")
            Return
        End If

        Try
            Using conn As New OracleConnection(connStr)
                conn.Open()

                ' Get current status of record
                Dim previousStatus As String = ""
                Using checkCmd As New OracleCommand("SELECT STATUS FROM TBL_BORROWING WHERE BORROWING_ID = :id", conn)
                    checkCmd.Parameters.Add(":id", TxtBorrowID.Text)
                    previousStatus = checkCmd.ExecuteScalar()?.ToString()
                End Using

                Dim sql As String = "UPDATE TBL_BORROWING 
                                 SET USER_ID = :studentId, 
                                     BOOK_ID = :bookId, 
                                     BORROW_DATE = :borrowDate, 
                                     RETURN_DUE_DATE = :dueDate, 
                                     RETURN_DATE = :returnDate, 
                                     STATUS = :status 
                                 WHERE BORROWING_ID = :borrowId"

                Using cmd As New OracleCommand(sql, conn)
                    cmd.Parameters.Add(":studentId", TxtStudentID.Text)
                    cmd.Parameters.Add(":bookId", TxtBookID.Text)
                    cmd.Parameters.Add(":borrowDate", DTPBorrowedDate.Value)
                    cmd.Parameters.Add(":dueDate", DTPDueDate.Value)
                    cmd.Parameters.Add(":returnDate", returnDate)
                    cmd.Parameters.Add(":status", status)
                    cmd.Parameters.Add(":borrowId", TxtBorrowID.Text)

                    Dim rowsAffected = cmd.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        ' Handle quantity adjustment
                        If previousStatus <> "RETURNED" AndAlso status = "RETURNED" Then
                            ' Increase quantity by 1
                            Dim updateQtySql = "UPDATE TBL_BOOKS SET QUANTITY_AVAILABLE = QUANTITY_AVAILABLE + 1 WHERE BOOK_ID = :bookId"
                            Using updateQtyCmd As New OracleCommand(updateQtySql, conn)
                                updateQtyCmd.Parameters.Add(":bookId", TxtBookID.Text)
                                updateQtyCmd.ExecuteNonQuery()
                            End Using
                        End If

                        MessageBox.Show("Borrowing record updated successfully.")
                        RaiseEvent BorrowModified(Me, EventArgs.Empty)
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