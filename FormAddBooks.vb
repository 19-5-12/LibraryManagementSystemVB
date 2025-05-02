Imports Oracle.ManagedDataAccess.Client

Public Class FormAddBooks
    Public Event BookAdded As EventHandler
    Private roundedPanels As New Dictionary(Of Panel, Integer)

    Private Sub FormAddBooks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        roundedPanels.Clear()

        ComboCategory.FlatStyle = FlatStyle.Flat
        ComboCategory.Items.Insert(0, "Select category")
        ComboCategory.SelectedIndex = 0

        ' Padding
        Dim paddedPanels = {PnlBorderBookID, Panel3, PnlBorderAuthor, PnlBorderIBSN,
            PnlBorderCategory, PnlBorderPubYear, PnlBorderQuantity}
        For Each pnl In paddedPanels
            pnl.Padding = New Padding(3)
        Next
        PnlFill.Padding = New Padding(10)

        ' Placeholder setup
        SetupPlaceholder(TxtBookID, "Enter Book ID")
        SetupPlaceholder(TxtTitle, "Enter Book Title")
        SetupPlaceholder(TxtAuthor, "Enter Author Name")
        SetupPlaceholder(TxtISBN, "Enter ISBN")
        SetupPlaceholder(TxtQuantity, "Enter Quantity")

        ' Rounded corners
        roundedPanels.Add(PnlFill, 20)
        roundedPanels.Add(PnlBorderBookID, 5)
        roundedPanels.Add(Panel3, 5)
        roundedPanels.Add(PnlBorderAuthor, 5)
        roundedPanels.Add(PnlBorderIBSN, 5)
        roundedPanels.Add(PnlBorderCategory, 5)
        roundedPanels.Add(PnlBorderPubYear, 5)
        roundedPanels.Add(PnlBorderQuantity, 5)


    End Sub

    Private Sub Panel_Paint(sender As Object, e As PaintEventArgs) Handles PnlFill.Paint, PnlBorderBookID.Paint, Panel3.Paint, PnlBorderAuthor.Paint, PnlBorderIBSN.Paint, PnlBorderCategory.Paint, PnlBorderPubYear.Paint, PnlBorderQuantity.Paint

        Dim pnl = DirectCast(sender, Panel)
        If roundedPanels.ContainsKey(pnl) Then
            MakeRoundedPanel(pnl, roundedPanels(pnl), e)
        End If
    End Sub

    Private Sub FormAddBooks_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        BtnAddBook.Focus()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub SetupPlaceholder(txtBox As TextBox, placeholder As String)
        txtBox.Text = placeholder
        txtBox.ForeColor = Color.Gray

        AddHandler txtBox.GotFocus, Sub(sender, e)
                                        If txtBox.Text = placeholder Then
                                            txtBox.Text = ""
                                            txtBox.ForeColor = SystemColors.WindowText
                                        End If
                                    End Sub

        AddHandler txtBox.LostFocus, Sub(sender, e)
                                         If txtBox.Text = "" Then
                                             txtBox.Text = placeholder
                                             txtBox.ForeColor = Color.Gray
                                         End If
                                     End Sub
    End Sub

    Private Sub BtnAddBook_Click(sender As Object, e As EventArgs) Handles BtnAddBook.Click
        Dim connStr As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"

        If Not IsNumeric(TxtBookID.Text) Then
            MessageBox.Show("Please enter a valid Book ID")
            TxtBookID.Focus()
            Return
        End If

        If Not IsNumeric(TxtISBN.Text) Then
            MessageBox.Show("ISBN must contain digits only.")
            Return
        End If

        If ComboCategory.SelectedIndex = 0 Then
            MessageBox.Show("Please select a valid category.")
            Return
        End If

        Dim pubYear As Integer = DateTimePicker1.Value.Year
        If pubYear > DateTime.Now.Year Then
            MessageBox.Show("Publication year must not be in the future.")
            Return
        End If

        Try
            Using conn As New OracleConnection(connStr)
                conn.Open()

                Dim checkSql As String = "SELECT COUNT(*) FROM TBL_BOOKS WHERE BOOK_ID = :bookId"
                Using checkCmd As New OracleCommand(checkSql, conn)
                    checkCmd.Parameters.Add(":bookId", OracleDbType.Int32).Value = Integer.Parse(TxtBookID.Text)
                    Dim existingCount As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                    If existingCount > 0 Then
                        MessageBox.Show("This Book ID already exists. Please use a different ID.")
                        TxtBookID.Focus()
                        Return
                    End If
                End Using

                Dim sql As String = "INSERT INTO TBL_BOOKS (BOOK_ID, TITLE, AUTHOR, ISBN, CATEGORY, PUBLICATION_YEAR, QUANTITY_AVAILABLE, CAMPUS_ID) " &
                                "VALUES (:bookId, :title, :author, :isbn, :category, :pubdate, :quantity, 1)"

                Using cmd As New OracleCommand(sql, conn)
                    cmd.Parameters.Add(":bookId", TxtBookID.Text)
                    cmd.Parameters.Add(":title", TxtTitle.Text)
                    cmd.Parameters.Add(":author", TxtAuthor.Text)
                    cmd.Parameters.Add(":isbn", TxtISBN.Text)
                    cmd.Parameters.Add(":category", ComboCategory.SelectedItem.ToString())
                    Dim pubDate As Date = DateTimePicker1.Value
                    cmd.Parameters.Add(":pubdate", pubDate)
                    cmd.Parameters.Add(":quantity", TxtQuantity.Text)

                    Dim result = cmd.ExecuteNonQuery()
                    If result > 0 Then
                        MessageBox.Show("Book added successfully.")
                        RaiseEvent BookAdded(Me, EventArgs.Empty)
                        Me.Close()
                    Else
                        MessageBox.Show("Failed to add book.")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try

    End Sub
End Class