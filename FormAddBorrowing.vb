Imports Oracle.ManagedDataAccess.Client

Public Class FormAddBorrowing

    Public Event BorrowAdded As EventHandler
    Private Sub FormAddBorrowing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        roundedPanels.Clear()

        ComboStatus.Items.Insert(0, "Select Status")
        ComboStatus.SelectedIndex = 0

        DTPReturnDate.MaxDate = DateTime.Now.Date

        Dim paddedPanels = {PnlBorderBookID, PnlBorderBorrowID, PnlBorderStudentID, PnlBorderBorrowedDate,
            PnlBorderDueDate, PnlBorderReturnDate, PnlBorderStatus}
        For Each pnl In paddedPanels
            pnl.Padding = New Padding(3)
        Next
        PnlFill.Padding = New Padding(10)

        SetupPlaceholder(TxtBorrowID, "Enter Borrowing ID")
        SetupPlaceholder(TxtStudentID, "Enter Student ID")
        SetupPlaceholder(TxtBookID, "Enter Book ID")

        roundedPanels.Add(PnlFill, 20)
        roundedPanels.Add(PnlBorderBorrowID, 5)
        roundedPanels.Add(PnlBorderStudentID, 5)
        roundedPanels.Add(PnlBorderBookID, 5)
        roundedPanels.Add(PnlBorderBorrowedDate, 5)
        roundedPanels.Add(PnlBorderDueDate, 5)
        roundedPanels.Add(PnlBorderReturnDate, 5)
        roundedPanels.Add(PnlBorderStatus, 5)
    End Sub

    Private Sub Panel_Paint(sender As Object, e As PaintEventArgs) Handles PnlFill.Paint, PnlBorderBookID.Paint,
        PnlBorderBorrowID.Paint, PnlBorderStudentID.Paint, PnlBorderBorrowedDate.Paint, PnlBorderDueDate.Paint,
        PnlBorderReturnDate.Paint, PnlBorderStatus.Paint

        Dim pnl = DirectCast(sender, Panel)
        If roundedPanels.ContainsKey(pnl) Then
            MakeRoundedPanel(pnl, roundedPanels(pnl), e)
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub FormAddBorrowing_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        BtnAddBorrowed.Focus()
    End Sub

    Private Sub BtnAddBorrowed_Click(sender As Object, e As EventArgs) Handles BtnAddBorrowed.Click
        Dim connStr As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"

        If Not IsNumeric(TxtBorrowID.Text) Then
            MessageBox.Show("Please enter a valid Borrow ID.")
            TxtBorrowID.Focus()
            Return
        End If

        If Not IsNumeric(TxtStudentID.Text) Then
            MessageBox.Show("Please enter a valid Student ID.")
            TxtStudentID.Focus()
            Return
        End If

        If Not IsNumeric(TxtBookID.Text) Then
            MessageBox.Show("Please enter a valid Book ID.")
            TxtBookID.Focus()
            Return
        End If

        If ComboStatus.SelectedIndex = 0 Then
            MessageBox.Show("Please select a valid status.")
            Return
        End If

        Dim status As String = ComboStatus.SelectedItem.ToString()

        Try
            Using conn As New OracleConnection(connStr)
                conn.Open()

                Dim bannedCheckSql As String = "SELECT COUNT(*) FROM TBL_BANNED WHERE USER_ID = :studentId AND STATUS = 'Active' AND BANNED_END_DATE >= TRUNC(SYSDATE)"
                Using bannedCmd As New OracleCommand(bannedCheckSql, conn)
                    bannedCmd.Parameters.Add(":studentId", OracleDbType.Int32).Value = Integer.Parse(TxtStudentID.Text)

                    Dim bannedCount As Integer = Convert.ToInt32(bannedCmd.ExecuteScalar())
                    If bannedCount > 0 Then
                        MessageBox.Show("This student is currently banned and cannot borrow books.")
                        Return
                    End If
                End Using


                ' Insert into TBL_BORROWING
                Dim insertSql As String = "INSERT INTO TBL_BORROWING (BORROWING_ID, USER_ID, BOOK_ID, BORROW_DATE, RETURN_DUE_DATE, RETURN_DATE, STATUS) " &
                                          "VALUES (:borrowId, :studentId, :bookId, :borrowedDate, :dueDate, :returnDate, :status)"

                Using insertCmd As New OracleCommand(insertSql, conn)
                    insertCmd.Parameters.Add(":borrowId", OracleDbType.Int32).Value = Integer.Parse(TxtBorrowID.Text)
                    insertCmd.Parameters.Add(":studentId", OracleDbType.Int32).Value = Integer.Parse(TxtStudentID.Text)
                    insertCmd.Parameters.Add(":bookId", OracleDbType.Int32).Value = Integer.Parse(TxtBookID.Text)
                    insertCmd.Parameters.Add(":borrowedDate", OracleDbType.Date).Value = DTPBorrowedDate.Value
                    insertCmd.Parameters.Add(":dueDate", OracleDbType.Date).Value = DTPDueDate.Value

                    ' Set RETURN_DATE based on status
                    Dim returnDateParam As New OracleParameter(":returnDate", OracleDbType.Date)
                    If status = "BORROWING" Then
                        returnDateParam.Value = DBNull.Value
                    Else
                        returnDateParam.Value = DTPReturnDate.Value
                    End If
                    insertCmd.Parameters.Add(returnDateParam)

                    insertCmd.Parameters.Add(":status", OracleDbType.Varchar2).Value = status

                    Dim result = insertCmd.ExecuteNonQuery()
                    If result = 0 Then
                        MessageBox.Show("Failed to add borrowing record.")
                        Return
                    End If
                End Using

                ' Update QUANTITY_AVAILABLE depending on status
                Dim updateSql As String
                If status = "BORROWING" Then
                    updateSql = "UPDATE TBL_BOOKS SET QUANTITY_AVAILABLE = QUANTITY_AVAILABLE - 1 WHERE BOOK_ID = :bookId AND QUANTITY_AVAILABLE > 0"
                ElseIf status = "RETURNED" Then
                    updateSql = "UPDATE TBL_BOOKS SET QUANTITY_AVAILABLE = QUANTITY_AVAILABLE + 1 WHERE BOOK_ID = :bookId"
                Else
                    updateSql = "" ' OVERDUE or others - no quantity change
                End If

                If updateSql <> "" Then
                    Using updateCmd As New OracleCommand(updateSql, conn)
                        updateCmd.Parameters.Add(":bookId", OracleDbType.Int32).Value = Integer.Parse(TxtBookID.Text)
                        Dim rowsAffected = updateCmd.ExecuteNonQuery()

                        If rowsAffected = 0 And status = "BORROWING" Then
                            MessageBox.Show("Warning: Book not available or quantity already zero.")
                            Return
                        End If
                    End Using
                End If

                MessageBox.Show("Borrowing record added successfully.")
                RaiseEvent BorrowAdded(Me, EventArgs.Empty)
                Me.Close()

            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

End Class