<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAddBooks
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        PnlFill = New Panel()
        TLPAddNewBook = New TableLayoutPanel()
        Panel10 = New Panel()
        PnlFillAddnewBook = New Panel()
        TLPAddNewBookFill = New TableLayoutPanel()
        TLPAddNewBookColumn = New Panel()
        TLPVariablesAddNewBook = New TableLayoutPanel()
        Panel7 = New Panel()
        TableLayoutPanel2 = New TableLayoutPanel()
        PnlBorderIBSN = New Panel()
        Panel12 = New Panel()
        TxtISBN = New TextBox()
        Panel13 = New Panel()
        Label6 = New Label()
        Panel2 = New Panel()
        TableLayoutPanel1 = New TableLayoutPanel()
        PnlBorderAuthor = New Panel()
        Panel8 = New Panel()
        TxtAuthor = New TextBox()
        Panel9 = New Panel()
        Label4 = New Label()
        PnlTitle = New Panel()
        TLPTitle = New TableLayoutPanel()
        Panel3 = New Panel()
        Panel4 = New Panel()
        TxtTitle = New TextBox()
        Panel5 = New Panel()
        Label5 = New Label()
        PnlBookID = New Panel()
        TLPBookID = New TableLayoutPanel()
        PnlTxtForBookID = New Panel()
        PnlFakeTextBox = New Panel()
        Label3 = New Label()
        PnlForLabelBookID = New Panel()
        Label2 = New Label()
        PnlCancelAdd = New Panel()
        TLPCancelAdd = New TableLayoutPanel()
        PnlForBtnAdd = New Panel()
        Panel1 = New Panel()
        Panel6 = New Panel()
        BtnAddBook = New Button()
        PnlForCancel = New Panel()
        PnlBtnCancel = New Panel()
        BtnCancel = New Button()
        PnlTopAddNewBook = New Panel()
        Label1 = New Label()
        PnlFill.SuspendLayout()
        TLPAddNewBook.SuspendLayout()
        PnlFillAddnewBook.SuspendLayout()
        TLPAddNewBookFill.SuspendLayout()
        TLPAddNewBookColumn.SuspendLayout()
        TLPVariablesAddNewBook.SuspendLayout()
        Panel7.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        PnlBorderIBSN.SuspendLayout()
        Panel12.SuspendLayout()
        Panel13.SuspendLayout()
        Panel2.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        PnlBorderAuthor.SuspendLayout()
        Panel8.SuspendLayout()
        Panel9.SuspendLayout()
        PnlTitle.SuspendLayout()
        TLPTitle.SuspendLayout()
        Panel3.SuspendLayout()
        Panel4.SuspendLayout()
        Panel5.SuspendLayout()
        PnlBookID.SuspendLayout()
        TLPBookID.SuspendLayout()
        PnlTxtForBookID.SuspendLayout()
        PnlFakeTextBox.SuspendLayout()
        PnlForLabelBookID.SuspendLayout()
        PnlCancelAdd.SuspendLayout()
        TLPCancelAdd.SuspendLayout()
        PnlForBtnAdd.SuspendLayout()
        Panel1.SuspendLayout()
        Panel6.SuspendLayout()
        PnlForCancel.SuspendLayout()
        PnlBtnCancel.SuspendLayout()
        PnlTopAddNewBook.SuspendLayout()
        SuspendLayout()
        ' 
        ' PnlFill
        ' 
        PnlFill.Controls.Add(TLPAddNewBook)
        PnlFill.Dock = DockStyle.Fill
        PnlFill.Location = New Point(0, 0)
        PnlFill.Margin = New Padding(5)
        PnlFill.Name = "PnlFill"
        PnlFill.Size = New Size(489, 510)
        PnlFill.TabIndex = 0
        ' 
        ' TLPAddNewBook
        ' 
        TLPAddNewBook.ColumnCount = 1
        TLPAddNewBook.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TLPAddNewBook.Controls.Add(Panel10, 0, 1)
        TLPAddNewBook.Controls.Add(PnlFillAddnewBook, 0, 2)
        TLPAddNewBook.Controls.Add(PnlTopAddNewBook, 0, 0)
        TLPAddNewBook.Dock = DockStyle.Fill
        TLPAddNewBook.Location = New Point(0, 0)
        TLPAddNewBook.Name = "TLPAddNewBook"
        TLPAddNewBook.RowCount = 3
        TLPAddNewBook.RowStyles.Add(New RowStyle(SizeType.Percent, 9.333335F))
        TLPAddNewBook.RowStyles.Add(New RowStyle(SizeType.Absolute, 0F))
        TLPAddNewBook.RowStyles.Add(New RowStyle(SizeType.Percent, 90.6666641F))
        TLPAddNewBook.Size = New Size(489, 510)
        TLPAddNewBook.TabIndex = 0
        ' 
        ' Panel10
        ' 
        Panel10.BackColor = SystemColors.Control
        Panel10.Dock = DockStyle.Fill
        Panel10.Location = New Point(3, 50)
        Panel10.Name = "Panel10"
        Panel10.Size = New Size(483, 1)
        Panel10.TabIndex = 4
        ' 
        ' PnlFillAddnewBook
        ' 
        PnlFillAddnewBook.Controls.Add(TLPAddNewBookFill)
        PnlFillAddnewBook.Dock = DockStyle.Fill
        PnlFillAddnewBook.Location = New Point(3, 50)
        PnlFillAddnewBook.Name = "PnlFillAddnewBook"
        PnlFillAddnewBook.Size = New Size(483, 457)
        PnlFillAddnewBook.TabIndex = 1
        ' 
        ' TLPAddNewBookFill
        ' 
        TLPAddNewBookFill.ColumnCount = 1
        TLPAddNewBookFill.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TLPAddNewBookFill.Controls.Add(TLPAddNewBookColumn, 0, 0)
        TLPAddNewBookFill.Controls.Add(PnlCancelAdd, 0, 1)
        TLPAddNewBookFill.Dock = DockStyle.Fill
        TLPAddNewBookFill.Location = New Point(0, 0)
        TLPAddNewBookFill.Name = "TLPAddNewBookFill"
        TLPAddNewBookFill.RowCount = 2
        TLPAddNewBookFill.RowStyles.Add(New RowStyle(SizeType.Percent, 89.0547256F))
        TLPAddNewBookFill.RowStyles.Add(New RowStyle(SizeType.Percent, 10.9452734F))
        TLPAddNewBookFill.Size = New Size(483, 457)
        TLPAddNewBookFill.TabIndex = 0
        ' 
        ' TLPAddNewBookColumn
        ' 
        TLPAddNewBookColumn.Controls.Add(TLPVariablesAddNewBook)
        TLPAddNewBookColumn.Dock = DockStyle.Fill
        TLPAddNewBookColumn.Location = New Point(3, 3)
        TLPAddNewBookColumn.Name = "TLPAddNewBookColumn"
        TLPAddNewBookColumn.Size = New Size(477, 400)
        TLPAddNewBookColumn.TabIndex = 0
        ' 
        ' TLPVariablesAddNewBook
        ' 
        TLPVariablesAddNewBook.ColumnCount = 1
        TLPVariablesAddNewBook.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TLPVariablesAddNewBook.Controls.Add(Panel7, 0, 3)
        TLPVariablesAddNewBook.Controls.Add(Panel2, 0, 2)
        TLPVariablesAddNewBook.Controls.Add(PnlTitle, 0, 1)
        TLPVariablesAddNewBook.Controls.Add(PnlBookID, 0, 0)
        TLPVariablesAddNewBook.Dock = DockStyle.Fill
        TLPVariablesAddNewBook.Location = New Point(0, 0)
        TLPVariablesAddNewBook.Name = "TLPVariablesAddNewBook"
        TLPVariablesAddNewBook.RowCount = 7
        TLPVariablesAddNewBook.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        TLPVariablesAddNewBook.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        TLPVariablesAddNewBook.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        TLPVariablesAddNewBook.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        TLPVariablesAddNewBook.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        TLPVariablesAddNewBook.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        TLPVariablesAddNewBook.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        TLPVariablesAddNewBook.Size = New Size(477, 400)
        TLPVariablesAddNewBook.TabIndex = 0
        ' 
        ' Panel7
        ' 
        Panel7.Controls.Add(TableLayoutPanel2)
        Panel7.Dock = DockStyle.Fill
        Panel7.Location = New Point(3, 174)
        Panel7.Name = "Panel7"
        Panel7.Size = New Size(471, 51)
        Panel7.TabIndex = 3
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 2
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 34.4418068F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 65.5582F))
        TableLayoutPanel2.Controls.Add(PnlBorderIBSN, 1, 0)
        TableLayoutPanel2.Controls.Add(Panel13, 0, 0)
        TableLayoutPanel2.Dock = DockStyle.Fill
        TableLayoutPanel2.Location = New Point(0, 0)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 1
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel2.Size = New Size(471, 51)
        TableLayoutPanel2.TabIndex = 0
        ' 
        ' PnlBorderIBSN
        ' 
        PnlBorderIBSN.Controls.Add(Panel12)
        PnlBorderIBSN.Dock = DockStyle.Fill
        PnlBorderIBSN.Location = New Point(162, 8)
        PnlBorderIBSN.Margin = New Padding(0, 8, 0, 8)
        PnlBorderIBSN.Name = "PnlBorderIBSN"
        PnlBorderIBSN.Size = New Size(309, 35)
        PnlBorderIBSN.TabIndex = 1
        ' 
        ' Panel12
        ' 
        Panel12.BackColor = Color.White
        Panel12.Controls.Add(TxtISBN)
        Panel12.Dock = DockStyle.Fill
        Panel12.ForeColor = Color.Black
        Panel12.Location = New Point(0, 0)
        Panel12.Margin = New Padding(0)
        Panel12.Name = "Panel12"
        Panel12.Padding = New Padding(0, 5, 0, 0)
        Panel12.Size = New Size(309, 35)
        Panel12.TabIndex = 0
        ' 
        ' TxtISBN
        ' 
        TxtISBN.BorderStyle = BorderStyle.None
        TxtISBN.Font = New Font("Arial", 11F)
        TxtISBN.Location = New Point(13, 7)
        TxtISBN.Name = "TxtISBN"
        TxtISBN.Size = New Size(267, 17)
        TxtISBN.TabIndex = 0
        TxtISBN.Text = "Enter"
        ' 
        ' Panel13
        ' 
        Panel13.Controls.Add(Label6)
        Panel13.Dock = DockStyle.Fill
        Panel13.Location = New Point(3, 3)
        Panel13.Name = "Panel13"
        Panel13.Size = New Size(156, 45)
        Panel13.TabIndex = 0
        ' 
        ' Label6
        ' 
        Label6.Dock = DockStyle.Fill
        Label6.Font = New Font("Arial", 14F)
        Label6.ForeColor = Color.DarkSlateGray
        Label6.Location = New Point(0, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(156, 45)
        Label6.TabIndex = 0
        Label6.Text = "ISBN"
        Label6.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(TableLayoutPanel1)
        Panel2.Dock = DockStyle.Fill
        Panel2.Location = New Point(3, 117)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(471, 51)
        Panel2.TabIndex = 2
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 34.4418068F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 65.5582F))
        TableLayoutPanel1.Controls.Add(PnlBorderAuthor, 1, 0)
        TableLayoutPanel1.Controls.Add(Panel9, 0, 0)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Size = New Size(471, 51)
        TableLayoutPanel1.TabIndex = 0
        ' 
        ' PnlBorderAuthor
        ' 
        PnlBorderAuthor.Controls.Add(Panel8)
        PnlBorderAuthor.Dock = DockStyle.Fill
        PnlBorderAuthor.Location = New Point(162, 8)
        PnlBorderAuthor.Margin = New Padding(0, 8, 0, 8)
        PnlBorderAuthor.Name = "PnlBorderAuthor"
        PnlBorderAuthor.Size = New Size(309, 35)
        PnlBorderAuthor.TabIndex = 1
        ' 
        ' Panel8
        ' 
        Panel8.BackColor = Color.White
        Panel8.Controls.Add(TxtAuthor)
        Panel8.Dock = DockStyle.Fill
        Panel8.ForeColor = Color.Black
        Panel8.Location = New Point(0, 0)
        Panel8.Margin = New Padding(0)
        Panel8.Name = "Panel8"
        Panel8.Padding = New Padding(0, 5, 0, 0)
        Panel8.Size = New Size(309, 35)
        Panel8.TabIndex = 0
        ' 
        ' TxtAuthor
        ' 
        TxtAuthor.BorderStyle = BorderStyle.None
        TxtAuthor.Font = New Font("Arial", 11F)
        TxtAuthor.Location = New Point(13, 7)
        TxtAuthor.Name = "TxtAuthor"
        TxtAuthor.Size = New Size(267, 17)
        TxtAuthor.TabIndex = 0
        TxtAuthor.Text = "Enter"
        ' 
        ' Panel9
        ' 
        Panel9.Controls.Add(Label4)
        Panel9.Dock = DockStyle.Fill
        Panel9.Location = New Point(3, 3)
        Panel9.Name = "Panel9"
        Panel9.Size = New Size(156, 45)
        Panel9.TabIndex = 0
        ' 
        ' Label4
        ' 
        Label4.Dock = DockStyle.Fill
        Label4.Font = New Font("Arial", 14F)
        Label4.ForeColor = Color.DarkSlateGray
        Label4.Location = New Point(0, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(156, 45)
        Label4.TabIndex = 0
        Label4.Text = "AUTHOR"
        Label4.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' PnlTitle
        ' 
        PnlTitle.Controls.Add(TLPTitle)
        PnlTitle.Dock = DockStyle.Fill
        PnlTitle.Location = New Point(3, 60)
        PnlTitle.Name = "PnlTitle"
        PnlTitle.Size = New Size(471, 51)
        PnlTitle.TabIndex = 1
        ' 
        ' TLPTitle
        ' 
        TLPTitle.ColumnCount = 2
        TLPTitle.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 34.4418068F))
        TLPTitle.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 65.5582F))
        TLPTitle.Controls.Add(Panel3, 1, 0)
        TLPTitle.Controls.Add(Panel5, 0, 0)
        TLPTitle.Dock = DockStyle.Fill
        TLPTitle.Location = New Point(0, 0)
        TLPTitle.Name = "TLPTitle"
        TLPTitle.RowCount = 1
        TLPTitle.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TLPTitle.Size = New Size(471, 51)
        TLPTitle.TabIndex = 0
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(Panel4)
        Panel3.Dock = DockStyle.Fill
        Panel3.Location = New Point(162, 8)
        Panel3.Margin = New Padding(0, 8, 0, 8)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(309, 35)
        Panel3.TabIndex = 1
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = Color.White
        Panel4.Controls.Add(TxtTitle)
        Panel4.Dock = DockStyle.Fill
        Panel4.ForeColor = Color.Black
        Panel4.Location = New Point(0, 0)
        Panel4.Margin = New Padding(0)
        Panel4.Name = "Panel4"
        Panel4.Padding = New Padding(0, 5, 0, 0)
        Panel4.Size = New Size(309, 35)
        Panel4.TabIndex = 0
        ' 
        ' TxtTitle
        ' 
        TxtTitle.BorderStyle = BorderStyle.None
        TxtTitle.Font = New Font("Arial", 11F)
        TxtTitle.Location = New Point(13, 7)
        TxtTitle.Name = "TxtTitle"
        TxtTitle.Size = New Size(267, 17)
        TxtTitle.TabIndex = 0
        TxtTitle.Text = "Enter"
        ' 
        ' Panel5
        ' 
        Panel5.Controls.Add(Label5)
        Panel5.Dock = DockStyle.Fill
        Panel5.Location = New Point(3, 3)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(156, 45)
        Panel5.TabIndex = 0
        ' 
        ' Label5
        ' 
        Label5.Dock = DockStyle.Fill
        Label5.Font = New Font("Arial", 14F)
        Label5.ForeColor = Color.DarkSlateGray
        Label5.Location = New Point(0, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(156, 45)
        Label5.TabIndex = 0
        Label5.Text = "TITLE"
        Label5.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' PnlBookID
        ' 
        PnlBookID.Controls.Add(TLPBookID)
        PnlBookID.Dock = DockStyle.Fill
        PnlBookID.Location = New Point(3, 3)
        PnlBookID.Name = "PnlBookID"
        PnlBookID.Size = New Size(471, 51)
        PnlBookID.TabIndex = 0
        ' 
        ' TLPBookID
        ' 
        TLPBookID.ColumnCount = 2
        TLPBookID.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 34.4418068F))
        TLPBookID.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 65.5582F))
        TLPBookID.Controls.Add(PnlTxtForBookID, 1, 0)
        TLPBookID.Controls.Add(PnlForLabelBookID, 0, 0)
        TLPBookID.Dock = DockStyle.Fill
        TLPBookID.Location = New Point(0, 0)
        TLPBookID.Name = "TLPBookID"
        TLPBookID.RowCount = 1
        TLPBookID.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TLPBookID.Size = New Size(471, 51)
        TLPBookID.TabIndex = 0
        ' 
        ' PnlTxtForBookID
        ' 
        PnlTxtForBookID.Controls.Add(PnlFakeTextBox)
        PnlTxtForBookID.Dock = DockStyle.Fill
        PnlTxtForBookID.Location = New Point(162, 8)
        PnlTxtForBookID.Margin = New Padding(0, 8, 0, 8)
        PnlTxtForBookID.Name = "PnlTxtForBookID"
        PnlTxtForBookID.Size = New Size(309, 35)
        PnlTxtForBookID.TabIndex = 1
        ' 
        ' PnlFakeTextBox
        ' 
        PnlFakeTextBox.BackColor = Color.White
        PnlFakeTextBox.Controls.Add(Label3)
        PnlFakeTextBox.Dock = DockStyle.Fill
        PnlFakeTextBox.ForeColor = Color.FromArgb(CByte(46), CByte(80), CByte(127))
        PnlFakeTextBox.Location = New Point(0, 0)
        PnlFakeTextBox.Margin = New Padding(0)
        PnlFakeTextBox.Name = "PnlFakeTextBox"
        PnlFakeTextBox.Size = New Size(309, 35)
        PnlFakeTextBox.TabIndex = 0
        ' 
        ' Label3
        ' 
        Label3.Dock = DockStyle.Fill
        Label3.Font = New Font("Arial", 11F)
        Label3.ForeColor = Color.Black
        Label3.Location = New Point(0, 0)
        Label3.Name = "Label3"
        Label3.Padding = New Padding(6, 8, 0, 0)
        Label3.Size = New Size(309, 35)
        Label3.TabIndex = 0
        Label3.Text = "Auto"
        ' 
        ' PnlForLabelBookID
        ' 
        PnlForLabelBookID.Controls.Add(Label2)
        PnlForLabelBookID.Dock = DockStyle.Fill
        PnlForLabelBookID.Location = New Point(3, 3)
        PnlForLabelBookID.Name = "PnlForLabelBookID"
        PnlForLabelBookID.Size = New Size(156, 45)
        PnlForLabelBookID.TabIndex = 0
        ' 
        ' Label2
        ' 
        Label2.Dock = DockStyle.Fill
        Label2.Font = New Font("Arial", 13F)
        Label2.ForeColor = Color.DarkSlateGray
        Label2.Location = New Point(0, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(156, 45)
        Label2.TabIndex = 0
        Label2.Text = "BOOK ID"
        Label2.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' PnlCancelAdd
        ' 
        PnlCancelAdd.Controls.Add(TLPCancelAdd)
        PnlCancelAdd.Dock = DockStyle.Fill
        PnlCancelAdd.Location = New Point(3, 409)
        PnlCancelAdd.Name = "PnlCancelAdd"
        PnlCancelAdd.Size = New Size(477, 45)
        PnlCancelAdd.TabIndex = 1
        ' 
        ' TLPCancelAdd
        ' 
        TLPCancelAdd.ColumnCount = 2
        TLPCancelAdd.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 75.4098358F))
        TLPCancelAdd.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 24.5901642F))
        TLPCancelAdd.Controls.Add(PnlForBtnAdd, 1, 0)
        TLPCancelAdd.Controls.Add(PnlForCancel, 0, 0)
        TLPCancelAdd.Dock = DockStyle.Fill
        TLPCancelAdd.Location = New Point(0, 0)
        TLPCancelAdd.Name = "TLPCancelAdd"
        TLPCancelAdd.RowCount = 1
        TLPCancelAdd.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TLPCancelAdd.Size = New Size(477, 45)
        TLPCancelAdd.TabIndex = 0
        ' 
        ' PnlForBtnAdd
        ' 
        PnlForBtnAdd.Controls.Add(Panel1)
        PnlForBtnAdd.Dock = DockStyle.Fill
        PnlForBtnAdd.Location = New Point(362, 3)
        PnlForBtnAdd.Name = "PnlForBtnAdd"
        PnlForBtnAdd.Size = New Size(112, 39)
        PnlForBtnAdd.TabIndex = 1
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(Panel6)
        Panel1.Dock = DockStyle.Left
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(96, 39)
        Panel1.TabIndex = 1
        ' 
        ' Panel6
        ' 
        Panel6.Controls.Add(BtnAddBook)
        Panel6.Dock = DockStyle.Right
        Panel6.Location = New Point(1, 0)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(95, 39)
        Panel6.TabIndex = 0
        ' 
        ' BtnAddBook
        ' 
        BtnAddBook.BackColor = Color.FromArgb(CByte(46), CByte(80), CByte(127))
        BtnAddBook.Dock = DockStyle.Fill
        BtnAddBook.FlatAppearance.BorderSize = 0
        BtnAddBook.FlatStyle = FlatStyle.Flat
        BtnAddBook.Font = New Font("Arial", 10F)
        BtnAddBook.ForeColor = Color.White
        BtnAddBook.Location = New Point(0, 0)
        BtnAddBook.Name = "BtnAddBook"
        BtnAddBook.Size = New Size(95, 39)
        BtnAddBook.TabIndex = 0
        BtnAddBook.Text = "Add Book"
        BtnAddBook.UseVisualStyleBackColor = False
        ' 
        ' PnlForCancel
        ' 
        PnlForCancel.Controls.Add(PnlBtnCancel)
        PnlForCancel.Dock = DockStyle.Fill
        PnlForCancel.Location = New Point(3, 3)
        PnlForCancel.Name = "PnlForCancel"
        PnlForCancel.Size = New Size(353, 39)
        PnlForCancel.TabIndex = 0
        ' 
        ' PnlBtnCancel
        ' 
        PnlBtnCancel.Controls.Add(BtnCancel)
        PnlBtnCancel.Dock = DockStyle.Right
        PnlBtnCancel.Location = New Point(258, 0)
        PnlBtnCancel.Name = "PnlBtnCancel"
        PnlBtnCancel.Size = New Size(95, 39)
        PnlBtnCancel.TabIndex = 0
        ' 
        ' BtnCancel
        ' 
        BtnCancel.BackColor = Color.FromArgb(CByte(224), CByte(232), CByte(241))
        BtnCancel.Dock = DockStyle.Fill
        BtnCancel.FlatAppearance.BorderSize = 0
        BtnCancel.FlatStyle = FlatStyle.Flat
        BtnCancel.Font = New Font("Arial", 10F)
        BtnCancel.ForeColor = Color.FromArgb(CByte(87), CByte(94), CByte(102))
        BtnCancel.Location = New Point(0, 0)
        BtnCancel.Name = "BtnCancel"
        BtnCancel.Size = New Size(95, 39)
        BtnCancel.TabIndex = 0
        BtnCancel.Text = "Cancel"
        BtnCancel.UseVisualStyleBackColor = False
        ' 
        ' PnlTopAddNewBook
        ' 
        PnlTopAddNewBook.Controls.Add(Label1)
        PnlTopAddNewBook.Dock = DockStyle.Fill
        PnlTopAddNewBook.Location = New Point(0, 0)
        PnlTopAddNewBook.Margin = New Padding(0)
        PnlTopAddNewBook.Name = "PnlTopAddNewBook"
        PnlTopAddNewBook.Size = New Size(489, 47)
        PnlTopAddNewBook.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.Dock = DockStyle.Fill
        Label1.Font = New Font("Arial", 14F, FontStyle.Bold)
        Label1.ForeColor = Color.DarkSlateGray
        Label1.Location = New Point(0, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(489, 47)
        Label1.TabIndex = 0
        Label1.Text = "   Add New Book"
        Label1.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' FormAddBooks
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(489, 510)
        ControlBox = False
        Controls.Add(PnlFill)
        DoubleBuffered = True
        FormBorderStyle = FormBorderStyle.None
        Name = "FormAddBooks"
        StartPosition = FormStartPosition.CenterScreen
        Text = "FormAddBooks"
        PnlFill.ResumeLayout(False)
        TLPAddNewBook.ResumeLayout(False)
        PnlFillAddnewBook.ResumeLayout(False)
        TLPAddNewBookFill.ResumeLayout(False)
        TLPAddNewBookColumn.ResumeLayout(False)
        TLPVariablesAddNewBook.ResumeLayout(False)
        Panel7.ResumeLayout(False)
        TableLayoutPanel2.ResumeLayout(False)
        PnlBorderIBSN.ResumeLayout(False)
        Panel12.ResumeLayout(False)
        Panel12.PerformLayout()
        Panel13.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        TableLayoutPanel1.ResumeLayout(False)
        PnlBorderAuthor.ResumeLayout(False)
        Panel8.ResumeLayout(False)
        Panel8.PerformLayout()
        Panel9.ResumeLayout(False)
        PnlTitle.ResumeLayout(False)
        TLPTitle.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        Panel5.ResumeLayout(False)
        PnlBookID.ResumeLayout(False)
        TLPBookID.ResumeLayout(False)
        PnlTxtForBookID.ResumeLayout(False)
        PnlFakeTextBox.ResumeLayout(False)
        PnlForLabelBookID.ResumeLayout(False)
        PnlCancelAdd.ResumeLayout(False)
        TLPCancelAdd.ResumeLayout(False)
        PnlForBtnAdd.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        Panel6.ResumeLayout(False)
        PnlForCancel.ResumeLayout(False)
        PnlBtnCancel.ResumeLayout(False)
        PnlTopAddNewBook.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents PnlFill As Panel
    Friend WithEvents TLPAddNewBook As TableLayoutPanel
    Friend WithEvents PnlFillAddnewBook As Panel
    Friend WithEvents PnlTopAddNewBook As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents TLPAddNewBookFill As TableLayoutPanel
    Friend WithEvents TLPAddNewBookColumn As Panel
    Friend WithEvents TLPVariablesAddNewBook As TableLayoutPanel
    Friend WithEvents PnlCancelAdd As Panel
    Friend WithEvents PnlBookID As Panel
    Friend WithEvents TLPBookID As TableLayoutPanel
    Friend WithEvents PnlForLabelBookID As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents PnlTxtForBookID As Panel
    Friend WithEvents PnlFakeTextBox As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents PnlTitle As Panel
    Friend WithEvents TLPTitle As TableLayoutPanel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents TxtTitle As TextBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents TLPCancelAdd As TableLayoutPanel
    Friend WithEvents PnlForBtnAdd As Panel
    Friend WithEvents PnlForCancel As Panel
    Friend WithEvents PnlBtnCancel As Panel
    Friend WithEvents BtnCancel As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents BtnAddBook As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents PnlBorderAuthor As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents TxtAuthor As TextBox
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents PnlBorderIBSN As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents TxtISBN As TextBox
    Friend WithEvents Panel13 As Panel
    Friend WithEvents Label6 As Label
End Class
