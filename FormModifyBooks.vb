Imports System.Net
Imports Oracle.ManagedDataAccess.Client
Public Class FormModifyBooks
    Public Event BookModified As EventHandler

    Private Sub Modify_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        roundedPanels.Clear()

        ComboCategory.FlatStyle = FlatStyle.Flat
        ComboCategory.Items.Insert(0, "Select category")
        ComboCategory.SelectedIndex = 0

        Dim paddedPanels = {PnlBorderBookID, Panel3, PnlBorderAuthor, PnlBorderIBSN,
            PnlBorderCategory, PnlBorderPubYear, PnlBorderQuantity, PnlBorderSelectID}
        For Each pnl In paddedPanels
            pnl.Padding = New Padding(3)
        Next
        PnlFill.Padding = New Padding(10)

        DateTimePicker1.MaxDate = DateTime.Today

        ' Placeholder setup
        UIHelpers.SetupPlaceholder(TxtBookID, "Enter Book ID")
        UIHelpers.SetupPlaceholder(TxtTitle, "Enter Book Title")
        UIHelpers.SetupPlaceholder(TxtAuthor, "Enter Author Name")
        UIHelpers.SetupPlaceholder(TxtISBN, "Enter ISBN")
        UIHelpers.SetupPlaceholder(TxtQuantity, "Enter Quantity")
        UIHelpers.SetupPlaceholder(TxtSelectID, "Enter Book ID to modify")

        ' Rounded corners
        UIHelpers.roundedPanels.Add(PnlFill, 20)
        UIHelpers.roundedPanels.Add(PnlBorderBookID, 5)
        UIHelpers.roundedPanels.Add(Panel3, 5)
        UIHelpers.roundedPanels.Add(PnlBorderAuthor, 5)
        UIHelpers.roundedPanels.Add(PnlBorderIBSN, 5)
        UIHelpers.roundedPanels.Add(PnlBorderCategory, 5)
        UIHelpers.roundedPanels.Add(PnlBorderPubYear, 5)
        UIHelpers.roundedPanels.Add(PnlBorderQuantity, 5)
        UIHelpers.roundedPanels.Add(PnlBorderSelectID, 5)
    End Sub

    Private Sub Modify_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        BtnSave.Focus()
    End Sub


    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub Panel_Paint(sender As Object, e As PaintEventArgs) Handles PnlFill.Paint, PnlBorderBookID.Paint, Panel3.Paint, PnlBorderAuthor.Paint, PnlBorderIBSN.Paint, PnlBorderCategory.Paint, PnlBorderPubYear.Paint, PnlBorderQuantity.Paint, PnlBorderSelectID.Paint

        HandlePanelPaint(sender, e)
    End Sub

    Private Sub TxtSelectID_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtSelectID.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            LoadBookDataByID()

        End If
    End Sub

    Private Sub LoadBookDataByID()
        Dim connStr As String = "User Id=SYSTEM;Password=1234;Data Source=localhost:1521/xe"
        Dim bookId As String = TxtSelectID.Text.Trim()

        If Not IsNumeric(bookId) Then
            MessageBox.Show("Please enter a valid numeric Book ID.")
            Return
        End If
        Try
            Using conn As New OracleConnection(connStr)
                conn.Open()
                Dim sql As String = "SELECT * FROM TBL_BOOKS WHERE BOOK_ID = :bookId"
                Using cmd As New OracleCommand(sql, conn)
                    cmd.Parameters.Add(":bookId", OracleDbType.Int32).Value = Integer.Parse(bookId)

                    Using reader As OracleDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            TxtBookID.Text = reader("BOOK_ID").ToString()
                            TxtBookID.ForeColor = SystemColors.WindowText
                            TxtTitle.Text = reader("TITLE").ToString()
                            TxtTitle.ForeColor = SystemColors.WindowText
                            TxtAuthor.Text = reader("AUTHOR").ToString()
                            TxtAuthor.ForeColor = SystemColors.WindowText
                            TxtISBN.Text = reader("ISBN").ToString()
                            TxtISBN.ForeColor = SystemColors.WindowText
                            ComboCategory.SelectedItem = reader("CATEGORY").ToString()
                            ComboCategory.ForeColor = SystemColors.WindowText
                            DateTimePicker1.Value = Convert.ToDateTime(reader("PUBLICATION_YEAR"))
                            TxtQuantity.Text = reader("QUANTITY_AVAILABLE").ToString()
                            TxtQuantity.ForeColor = SystemColors.WindowText
                        Else
                            MessageBox.Show("Book ID not found.")
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

        ' Validate Book ID
        If Not IsNumeric(TxtBookID.Text) Then
            MessageBox.Show("Book ID is invalid.")
            Return
        End If

        ' Validate ISBN
        If Not IsNumeric(TxtISBN.Text) Then
            MessageBox.Show("ISBN must contain digits only.")
            Return
        End If

        ' Validate Category
        If ComboCategory.SelectedIndex = 0 Then
            MessageBox.Show("Please select a valid category.")
            Return
        End If

        ' Validate Publication Year
        Dim pubYear As Integer = DateTimePicker1.Value.Year
        If pubYear > DateTime.Now.Year Then
            MessageBox.Show("Publication year must not be in the future.")
            Return
        End If

        ' Validate Quantity
        If Not IsNumeric(TxtQuantity.Text) OrElse Convert.ToInt32(TxtQuantity.Text) < 0 Then
            MessageBox.Show("Quantity must be a non-negative number.")
            Return
        End If

        Try
            Using conn As New OracleConnection(connStr)
                conn.Open()

                Dim sql As String = "UPDATE TBL_BOOKS SET TITLE = :title, AUTHOR = :author, ISBN = :isbn, CATEGORY = :category, PUBLICATION_YEAR = :pubyear, QUANTITY_AVAILABLE = :quantity WHERE BOOK_ID = :bookId"

                Using cmd As New OracleCommand(sql, conn)
                    cmd.Parameters.Add(":title", TxtTitle.Text)
                    cmd.Parameters.Add(":author", TxtAuthor.Text)
                    cmd.Parameters.Add(":isbn", TxtISBN.Text)
                    cmd.Parameters.Add(":category", ComboCategory.SelectedItem.ToString())
                    Dim pubDate As Date = DateTimePicker1.Value
                    cmd.Parameters.Add(":pubdate", pubDate)
                    cmd.Parameters.Add(":quantity", TxtQuantity.Text)
                    cmd.Parameters.Add(":bookId", TxtBookID.Text)

                    Dim rowsAffected = cmd.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        MessageBox.Show("Book record updated successfully.")
                        RaiseEvent BookModified(Me, EventArgs.Empty)
                        Me.Close()
                    Else
                        MessageBox.Show("No changes made or Book ID not found.")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

End Class