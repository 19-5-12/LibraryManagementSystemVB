<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormModifyBorrowing
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
        TLPModifyBook = New TableLayoutPanel()
        PnlFillAddnewBook = New Panel()
        TLPAddNewBookFill = New TableLayoutPanel()
        PnlCancelAdd = New Panel()
        TLPCancelAdd = New TableLayoutPanel()
        PnlForBtnAdd = New Panel()
        Panel3 = New Panel()
        Panel6 = New Panel()
        BtnSave = New Button()
        PnlForCancel = New Panel()
        PnlBtnCancel = New Panel()
        BtnCancel = New Button()
        TLPAddNewBookColumn = New Panel()
        TLPVariablesAddNewBook = New TableLayoutPanel()
        Panel17 = New Panel()
        TableLayoutPanel5 = New TableLayoutPanel()
        PnlBorderStatus = New Panel()
        Panel21 = New Panel()
        ComboStatus = New ComboBox()
        Panel22 = New Panel()
        Label9 = New Label()
        Panel14 = New Panel()
        TableLayoutPanel4 = New TableLayoutPanel()
        PnlBorderReturnDate = New Panel()
        Panel18 = New Panel()
        DTPReturnDate = New DateTimePicker()
        Panel19 = New Panel()
        Label8 = New Label()
        Panel11 = New Panel()
        TableLayoutPanel3 = New TableLayoutPanel()
        PnlBorderDueDate = New Panel()
        Panel15 = New Panel()
        DTPDueDate = New DateTimePicker()
        Panel16 = New Panel()
        Label7 = New Label()
        Panel7 = New Panel()
        TableLayoutPanel2 = New TableLayoutPanel()
        PnlBorderBorrowedDate = New Panel()
        Panel12 = New Panel()
        DTPBorrowedDate = New DateTimePicker()
        Panel13 = New Panel()
        Label6 = New Label()
        Panel2 = New Panel()
        TableLayoutPanel1 = New TableLayoutPanel()
        PnlBorderBookID = New Panel()
        Panel8 = New Panel()
        TxtBookID = New TextBox()
        Panel9 = New Panel()
        Label4 = New Label()
        PnlTitle = New Panel()
        TLPTitle = New TableLayoutPanel()
        PnlBorderStudentID = New Panel()
        Panel4 = New Panel()
        TxtStudentID = New TextBox()
        Panel5 = New Panel()
        Label5 = New Label()
        PnlBookID = New Panel()
        TLPBookID = New TableLayoutPanel()
        PnlBorderBorrowID = New Panel()
        Panel1 = New Panel()
        TxtBorrowID = New TextBox()
        PnlForLabelBookID = New Panel()
        Label2 = New Label()
        Panel10 = New Panel()
        PnlTopAddNewBook = New Panel()
        Panel20 = New Panel()
        TableLayoutPanel6 = New TableLayoutPanel()
        Panel24 = New Panel()
        PnlSelect = New Panel()
        PnlBorderSelectID = New Panel()
        Panel25 = New Panel()
        TxtSelectID = New TextBox()
        Panel23 = New Panel()
        Label1 = New Label()
        PnlFill.SuspendLayout()
        TLPModifyBook.SuspendLayout()
        PnlFillAddnewBook.SuspendLayout()
        TLPAddNewBookFill.SuspendLayout()
        PnlCancelAdd.SuspendLayout()
        TLPCancelAdd.SuspendLayout()
        PnlForBtnAdd.SuspendLayout()
        Panel3.SuspendLayout()
        Panel6.SuspendLayout()
        PnlForCancel.SuspendLayout()
        PnlBtnCancel.SuspendLayout()
        TLPAddNewBookColumn.SuspendLayout()
        TLPVariablesAddNewBook.SuspendLayout()
        Panel17.SuspendLayout()
        TableLayoutPanel5.SuspendLayout()
        PnlBorderStatus.SuspendLayout()
        Panel21.SuspendLayout()
        Panel22.SuspendLayout()
        Panel14.SuspendLayout()
        TableLayoutPanel4.SuspendLayout()
        PnlBorderReturnDate.SuspendLayout()
        Panel18.SuspendLayout()
        Panel19.SuspendLayout()
        Panel11.SuspendLayout()
        TableLayoutPanel3.SuspendLayout()
        PnlBorderDueDate.SuspendLayout()
        Panel15.SuspendLayout()
        Panel16.SuspendLayout()
        Panel7.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        PnlBorderBorrowedDate.SuspendLayout()
        Panel12.SuspendLayout()
        Panel13.SuspendLayout()
        Panel2.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        PnlBorderBookID.SuspendLayout()
        Panel8.SuspendLayout()
        Panel9.SuspendLayout()
        PnlTitle.SuspendLayout()
        TLPTitle.SuspendLayout()
        PnlBorderStudentID.SuspendLayout()
        Panel4.SuspendLayout()
        Panel5.SuspendLayout()
        PnlBookID.SuspendLayout()
        TLPBookID.SuspendLayout()
        PnlBorderBorrowID.SuspendLayout()
        Panel1.SuspendLayout()
        PnlForLabelBookID.SuspendLayout()
        PnlTopAddNewBook.SuspendLayout()
        Panel20.SuspendLayout()
        TableLayoutPanel6.SuspendLayout()
        Panel24.SuspendLayout()
        PnlSelect.SuspendLayout()
        PnlBorderSelectID.SuspendLayout()
        Panel25.SuspendLayout()
        Panel23.SuspendLayout()
        SuspendLayout()
        ' 
        ' PnlFill
        ' 
        PnlFill.BackColor = Color.White
        PnlFill.Controls.Add(TLPModifyBook)
        PnlFill.Dock = DockStyle.Fill
        PnlFill.Location = New Point(0, 0)
        PnlFill.Margin = New Padding(5)
        PnlFill.Name = "PnlFill"
        PnlFill.Size = New Size(489, 510)
        PnlFill.TabIndex = 2
        ' 
        ' TLPModifyBook
        ' 
        TLPModifyBook.ColumnCount = 1
        TLPModifyBook.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TLPModifyBook.Controls.Add(PnlFillAddnewBook, 0, 1)
        TLPModifyBook.Controls.Add(PnlTopAddNewBook, 0, 0)
        TLPModifyBook.Dock = DockStyle.Fill
        TLPModifyBook.Location = New Point(0, 0)
        TLPModifyBook.Name = "TLPModifyBook"
        TLPModifyBook.RowCount = 2
        TLPModifyBook.RowStyles.Add(New RowStyle(SizeType.Percent, 12.15686F))
        TLPModifyBook.RowStyles.Add(New RowStyle(SizeType.Percent, 87.84314F))
        TLPModifyBook.Size = New Size(489, 510)
        TLPModifyBook.TabIndex = 0
        ' 
        ' PnlFillAddnewBook
        ' 
        PnlFillAddnewBook.Controls.Add(TLPAddNewBookFill)
        PnlFillAddnewBook.Dock = DockStyle.Fill
        PnlFillAddnewBook.Location = New Point(3, 64)
        PnlFillAddnewBook.Name = "PnlFillAddnewBook"
        PnlFillAddnewBook.Size = New Size(483, 443)
        PnlFillAddnewBook.TabIndex = 2
        ' 
        ' TLPAddNewBookFill
        ' 
        TLPAddNewBookFill.ColumnCount = 1
        TLPAddNewBookFill.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TLPAddNewBookFill.Controls.Add(PnlCancelAdd, 0, 2)
        TLPAddNewBookFill.Controls.Add(TLPAddNewBookColumn, 0, 1)
        TLPAddNewBookFill.Controls.Add(Panel10, 0, 0)
        TLPAddNewBookFill.Dock = DockStyle.Fill
        TLPAddNewBookFill.Location = New Point(0, 0)
        TLPAddNewBookFill.Name = "TLPAddNewBookFill"
        TLPAddNewBookFill.RowCount = 3
        TLPAddNewBookFill.RowStyles.Add(New RowStyle(SizeType.Absolute, 0F))
        TLPAddNewBookFill.RowStyles.Add(New RowStyle(SizeType.Percent, 89.05473F))
        TLPAddNewBookFill.RowStyles.Add(New RowStyle(SizeType.Percent, 10.9452705F))
        TLPAddNewBookFill.Size = New Size(483, 443)
        TLPAddNewBookFill.TabIndex = 0
        ' 
        ' PnlCancelAdd
        ' 
        PnlCancelAdd.Controls.Add(TLPCancelAdd)
        PnlCancelAdd.Dock = DockStyle.Fill
        PnlCancelAdd.Location = New Point(3, 397)
        PnlCancelAdd.Name = "PnlCancelAdd"
        PnlCancelAdd.Size = New Size(477, 43)
        PnlCancelAdd.TabIndex = 3
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
        TLPCancelAdd.Size = New Size(477, 43)
        TLPCancelAdd.TabIndex = 0
        ' 
        ' PnlForBtnAdd
        ' 
        PnlForBtnAdd.Controls.Add(Panel3)
        PnlForBtnAdd.Dock = DockStyle.Fill
        PnlForBtnAdd.Location = New Point(362, 3)
        PnlForBtnAdd.Name = "PnlForBtnAdd"
        PnlForBtnAdd.Size = New Size(112, 37)
        PnlForBtnAdd.TabIndex = 1
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(Panel6)
        Panel3.Dock = DockStyle.Left
        Panel3.Location = New Point(0, 0)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(109, 37)
        Panel3.TabIndex = 1
        ' 
        ' Panel6
        ' 
        Panel6.Controls.Add(BtnSave)
        Panel6.Dock = DockStyle.Right
        Panel6.Location = New Point(0, 0)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(109, 37)
        Panel6.TabIndex = 0
        ' 
        ' BtnSave
        ' 
        BtnSave.BackColor = Color.FromArgb(CByte(46), CByte(80), CByte(127))
        BtnSave.Dock = DockStyle.Fill
        BtnSave.FlatAppearance.BorderSize = 0
        BtnSave.FlatStyle = FlatStyle.Flat
        BtnSave.Font = New Font("Arial", 10F)
        BtnSave.ForeColor = Color.White
        BtnSave.Location = New Point(0, 0)
        BtnSave.Name = "BtnSave"
        BtnSave.Size = New Size(109, 37)
        BtnSave.TabIndex = 0
        BtnSave.Text = "Save Changes"
        BtnSave.UseVisualStyleBackColor = False
        ' 
        ' PnlForCancel
        ' 
        PnlForCancel.Controls.Add(PnlBtnCancel)
        PnlForCancel.Dock = DockStyle.Fill
        PnlForCancel.Location = New Point(3, 3)
        PnlForCancel.Name = "PnlForCancel"
        PnlForCancel.Size = New Size(353, 37)
        PnlForCancel.TabIndex = 0
        ' 
        ' PnlBtnCancel
        ' 
        PnlBtnCancel.Controls.Add(BtnCancel)
        PnlBtnCancel.Dock = DockStyle.Right
        PnlBtnCancel.Location = New Point(258, 0)
        PnlBtnCancel.Name = "PnlBtnCancel"
        PnlBtnCancel.Size = New Size(95, 37)
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
        BtnCancel.Size = New Size(95, 37)
        BtnCancel.TabIndex = 0
        BtnCancel.Text = "Cancel"
        BtnCancel.UseVisualStyleBackColor = False
        ' 
        ' TLPAddNewBookColumn
        ' 
        TLPAddNewBookColumn.Controls.Add(TLPVariablesAddNewBook)
        TLPAddNewBookColumn.Dock = DockStyle.Fill
        TLPAddNewBookColumn.Location = New Point(3, 3)
        TLPAddNewBookColumn.Name = "TLPAddNewBookColumn"
        TLPAddNewBookColumn.Size = New Size(477, 388)
        TLPAddNewBookColumn.TabIndex = 0
        ' 
        ' TLPVariablesAddNewBook
        ' 
        TLPVariablesAddNewBook.ColumnCount = 1
        TLPVariablesAddNewBook.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TLPVariablesAddNewBook.Controls.Add(Panel17, 0, 6)
        TLPVariablesAddNewBook.Controls.Add(Panel14, 0, 5)
        TLPVariablesAddNewBook.Controls.Add(Panel11, 0, 4)
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
        TLPVariablesAddNewBook.Size = New Size(477, 388)
        TLPVariablesAddNewBook.TabIndex = 0
        ' 
        ' Panel17
        ' 
        Panel17.Controls.Add(TableLayoutPanel5)
        Panel17.Dock = DockStyle.Fill
        Panel17.Location = New Point(3, 333)
        Panel17.Name = "Panel17"
        Panel17.Size = New Size(471, 52)
        Panel17.TabIndex = 6
        ' 
        ' TableLayoutPanel5
        ' 
        TableLayoutPanel5.ColumnCount = 2
        TableLayoutPanel5.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 34.4418068F))
        TableLayoutPanel5.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 65.5582F))
        TableLayoutPanel5.Controls.Add(PnlBorderStatus, 1, 0)
        TableLayoutPanel5.Controls.Add(Panel22, 0, 0)
        TableLayoutPanel5.Dock = DockStyle.Fill
        TableLayoutPanel5.Location = New Point(0, 0)
        TableLayoutPanel5.Name = "TableLayoutPanel5"
        TableLayoutPanel5.RowCount = 1
        TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel5.Size = New Size(471, 52)
        TableLayoutPanel5.TabIndex = 0
        ' 
        ' PnlBorderStatus
        ' 
        PnlBorderStatus.Controls.Add(Panel21)
        PnlBorderStatus.Dock = DockStyle.Fill
        PnlBorderStatus.Location = New Point(162, 5)
        PnlBorderStatus.Margin = New Padding(0, 5, 0, 5)
        PnlBorderStatus.Name = "PnlBorderStatus"
        PnlBorderStatus.Size = New Size(309, 42)
        PnlBorderStatus.TabIndex = 1
        ' 
        ' Panel21
        ' 
        Panel21.BackColor = Color.White
        Panel21.Controls.Add(ComboStatus)
        Panel21.Dock = DockStyle.Fill
        Panel21.ForeColor = Color.Black
        Panel21.Location = New Point(0, 0)
        Panel21.Margin = New Padding(0)
        Panel21.Name = "Panel21"
        Panel21.Padding = New Padding(10, 5, 0, 0)
        Panel21.Size = New Size(309, 42)
        Panel21.TabIndex = 0
        ' 
        ' ComboStatus
        ' 
        ComboStatus.BackColor = Color.White
        ComboStatus.Dock = DockStyle.Fill
        ComboStatus.DropDownStyle = ComboBoxStyle.DropDownList
        ComboStatus.FlatStyle = FlatStyle.Flat
        ComboStatus.Font = New Font("Arial", 11F)
        ComboStatus.FormattingEnabled = True
        ComboStatus.Items.AddRange(New Object() {"BORROWING", "RETURNED", "OVERDUE", "RETURNED OVERDUE"})
        ComboStatus.Location = New Point(10, 5)
        ComboStatus.Name = "ComboStatus"
        ComboStatus.Size = New Size(299, 25)
        ComboStatus.TabIndex = 1
        ' 
        ' Panel22
        ' 
        Panel22.Controls.Add(Label9)
        Panel22.Dock = DockStyle.Fill
        Panel22.Location = New Point(3, 3)
        Panel22.Name = "Panel22"
        Panel22.Size = New Size(156, 46)
        Panel22.TabIndex = 0
        ' 
        ' Label9
        ' 
        Label9.Dock = DockStyle.Fill
        Label9.Font = New Font("Arial", 14F)
        Label9.ForeColor = Color.DarkSlateGray
        Label9.Location = New Point(0, 0)
        Label9.Name = "Label9"
        Label9.Size = New Size(156, 46)
        Label9.TabIndex = 0
        Label9.Text = "Status"
        Label9.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' Panel14
        ' 
        Panel14.Controls.Add(TableLayoutPanel4)
        Panel14.Dock = DockStyle.Fill
        Panel14.Location = New Point(3, 278)
        Panel14.Name = "Panel14"
        Panel14.Size = New Size(471, 49)
        Panel14.TabIndex = 5
        ' 
        ' TableLayoutPanel4
        ' 
        TableLayoutPanel4.ColumnCount = 2
        TableLayoutPanel4.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 34.4418068F))
        TableLayoutPanel4.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 65.5582F))
        TableLayoutPanel4.Controls.Add(PnlBorderReturnDate, 1, 0)
        TableLayoutPanel4.Controls.Add(Panel19, 0, 0)
        TableLayoutPanel4.Dock = DockStyle.Fill
        TableLayoutPanel4.Location = New Point(0, 0)
        TableLayoutPanel4.Name = "TableLayoutPanel4"
        TableLayoutPanel4.RowCount = 1
        TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel4.Size = New Size(471, 49)
        TableLayoutPanel4.TabIndex = 0
        ' 
        ' PnlBorderReturnDate
        ' 
        PnlBorderReturnDate.Controls.Add(Panel18)
        PnlBorderReturnDate.Dock = DockStyle.Fill
        PnlBorderReturnDate.Location = New Point(162, 5)
        PnlBorderReturnDate.Margin = New Padding(0, 5, 0, 5)
        PnlBorderReturnDate.Name = "PnlBorderReturnDate"
        PnlBorderReturnDate.Size = New Size(309, 39)
        PnlBorderReturnDate.TabIndex = 1
        ' 
        ' Panel18
        ' 
        Panel18.BackColor = Color.White
        Panel18.Controls.Add(DTPReturnDate)
        Panel18.Dock = DockStyle.Fill
        Panel18.ForeColor = Color.Black
        Panel18.Location = New Point(0, 0)
        Panel18.Margin = New Padding(0)
        Panel18.Name = "Panel18"
        Panel18.Padding = New Padding(10, 5, 0, 0)
        Panel18.Size = New Size(309, 39)
        Panel18.TabIndex = 0
        ' 
        ' DTPReturnDate
        ' 
        DTPReturnDate.CalendarMonthBackground = Color.White
        DTPReturnDate.Dock = DockStyle.Fill
        DTPReturnDate.Font = New Font("Arial", 11F)
        DTPReturnDate.Format = DateTimePickerFormat.Short
        DTPReturnDate.Location = New Point(10, 5)
        DTPReturnDate.Name = "DTPReturnDate"
        DTPReturnDate.Size = New Size(299, 24)
        DTPReturnDate.TabIndex = 0
        ' 
        ' Panel19
        ' 
        Panel19.Controls.Add(Label8)
        Panel19.Dock = DockStyle.Fill
        Panel19.Location = New Point(3, 3)
        Panel19.Name = "Panel19"
        Panel19.Size = New Size(156, 43)
        Panel19.TabIndex = 0
        ' 
        ' Label8
        ' 
        Label8.Dock = DockStyle.Fill
        Label8.Font = New Font("Arial", 13F)
        Label8.ForeColor = Color.DarkSlateGray
        Label8.Location = New Point(0, 0)
        Label8.Name = "Label8"
        Label8.Size = New Size(156, 43)
        Label8.TabIndex = 0
        Label8.Text = "Return Date"
        Label8.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' Panel11
        ' 
        Panel11.Controls.Add(TableLayoutPanel3)
        Panel11.Dock = DockStyle.Fill
        Panel11.Location = New Point(3, 223)
        Panel11.Name = "Panel11"
        Panel11.Size = New Size(471, 49)
        Panel11.TabIndex = 4
        ' 
        ' TableLayoutPanel3
        ' 
        TableLayoutPanel3.ColumnCount = 2
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 34.4418068F))
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 65.5582F))
        TableLayoutPanel3.Controls.Add(PnlBorderDueDate, 1, 0)
        TableLayoutPanel3.Controls.Add(Panel16, 0, 0)
        TableLayoutPanel3.Dock = DockStyle.Fill
        TableLayoutPanel3.Location = New Point(0, 0)
        TableLayoutPanel3.Name = "TableLayoutPanel3"
        TableLayoutPanel3.RowCount = 1
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel3.Size = New Size(471, 49)
        TableLayoutPanel3.TabIndex = 0
        ' 
        ' PnlBorderDueDate
        ' 
        PnlBorderDueDate.Controls.Add(Panel15)
        PnlBorderDueDate.Dock = DockStyle.Fill
        PnlBorderDueDate.Location = New Point(162, 5)
        PnlBorderDueDate.Margin = New Padding(0, 5, 0, 5)
        PnlBorderDueDate.Name = "PnlBorderDueDate"
        PnlBorderDueDate.Size = New Size(309, 39)
        PnlBorderDueDate.TabIndex = 1
        ' 
        ' Panel15
        ' 
        Panel15.BackColor = Color.White
        Panel15.Controls.Add(DTPDueDate)
        Panel15.Dock = DockStyle.Fill
        Panel15.ForeColor = Color.Black
        Panel15.Location = New Point(0, 0)
        Panel15.Margin = New Padding(0)
        Panel15.Name = "Panel15"
        Panel15.Padding = New Padding(10, 5, 0, 0)
        Panel15.Size = New Size(309, 39)
        Panel15.TabIndex = 0
        ' 
        ' DTPDueDate
        ' 
        DTPDueDate.CalendarMonthBackground = Color.White
        DTPDueDate.Dock = DockStyle.Fill
        DTPDueDate.Font = New Font("Arial", 11F)
        DTPDueDate.Format = DateTimePickerFormat.Short
        DTPDueDate.Location = New Point(10, 5)
        DTPDueDate.Name = "DTPDueDate"
        DTPDueDate.Size = New Size(299, 24)
        DTPDueDate.TabIndex = 1
        ' 
        ' Panel16
        ' 
        Panel16.Controls.Add(Label7)
        Panel16.Dock = DockStyle.Fill
        Panel16.Location = New Point(3, 3)
        Panel16.Name = "Panel16"
        Panel16.Size = New Size(156, 43)
        Panel16.TabIndex = 0
        ' 
        ' Label7
        ' 
        Label7.Dock = DockStyle.Fill
        Label7.Font = New Font("Arial", 14F)
        Label7.ForeColor = Color.DarkSlateGray
        Label7.Location = New Point(0, 0)
        Label7.Name = "Label7"
        Label7.Size = New Size(156, 43)
        Label7.TabIndex = 0
        Label7.Text = "Due Date"
        Label7.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' Panel7
        ' 
        Panel7.Controls.Add(TableLayoutPanel2)
        Panel7.Dock = DockStyle.Fill
        Panel7.Location = New Point(3, 168)
        Panel7.Name = "Panel7"
        Panel7.Size = New Size(471, 49)
        Panel7.TabIndex = 3
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 2
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 34.4418068F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 65.5582F))
        TableLayoutPanel2.Controls.Add(PnlBorderBorrowedDate, 1, 0)
        TableLayoutPanel2.Controls.Add(Panel13, 0, 0)
        TableLayoutPanel2.Dock = DockStyle.Fill
        TableLayoutPanel2.Location = New Point(0, 0)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 1
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel2.Size = New Size(471, 49)
        TableLayoutPanel2.TabIndex = 0
        ' 
        ' PnlBorderBorrowedDate
        ' 
        PnlBorderBorrowedDate.Controls.Add(Panel12)
        PnlBorderBorrowedDate.Dock = DockStyle.Fill
        PnlBorderBorrowedDate.Location = New Point(162, 5)
        PnlBorderBorrowedDate.Margin = New Padding(0, 5, 0, 5)
        PnlBorderBorrowedDate.Name = "PnlBorderBorrowedDate"
        PnlBorderBorrowedDate.Size = New Size(309, 39)
        PnlBorderBorrowedDate.TabIndex = 1
        ' 
        ' Panel12
        ' 
        Panel12.BackColor = Color.White
        Panel12.Controls.Add(DTPBorrowedDate)
        Panel12.Dock = DockStyle.Fill
        Panel12.ForeColor = Color.Black
        Panel12.Location = New Point(0, 0)
        Panel12.Margin = New Padding(0)
        Panel12.Name = "Panel12"
        Panel12.Padding = New Padding(10, 5, 0, 0)
        Panel12.Size = New Size(309, 39)
        Panel12.TabIndex = 0
        ' 
        ' DTPBorrowedDate
        ' 
        DTPBorrowedDate.CalendarMonthBackground = Color.White
        DTPBorrowedDate.Dock = DockStyle.Fill
        DTPBorrowedDate.Font = New Font("Arial", 11F)
        DTPBorrowedDate.Format = DateTimePickerFormat.Short
        DTPBorrowedDate.Location = New Point(10, 5)
        DTPBorrowedDate.Name = "DTPBorrowedDate"
        DTPBorrowedDate.Size = New Size(299, 24)
        DTPBorrowedDate.TabIndex = 1
        ' 
        ' Panel13
        ' 
        Panel13.Controls.Add(Label6)
        Panel13.Dock = DockStyle.Fill
        Panel13.Location = New Point(3, 3)
        Panel13.Name = "Panel13"
        Panel13.Size = New Size(156, 43)
        Panel13.TabIndex = 0
        ' 
        ' Label6
        ' 
        Label6.Dock = DockStyle.Fill
        Label6.Font = New Font("Arial", 14F)
        Label6.ForeColor = Color.DarkSlateGray
        Label6.Location = New Point(0, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(156, 43)
        Label6.TabIndex = 0
        Label6.Text = "Borrowed Date"
        Label6.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(TableLayoutPanel1)
        Panel2.Dock = DockStyle.Fill
        Panel2.Location = New Point(3, 113)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(471, 49)
        Panel2.TabIndex = 2
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 34.4418068F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 65.5582F))
        TableLayoutPanel1.Controls.Add(PnlBorderBookID, 1, 0)
        TableLayoutPanel1.Controls.Add(Panel9, 0, 0)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Size = New Size(471, 49)
        TableLayoutPanel1.TabIndex = 0
        ' 
        ' PnlBorderBookID
        ' 
        PnlBorderBookID.Controls.Add(Panel8)
        PnlBorderBookID.Dock = DockStyle.Fill
        PnlBorderBookID.Location = New Point(162, 5)
        PnlBorderBookID.Margin = New Padding(0, 5, 0, 5)
        PnlBorderBookID.Name = "PnlBorderBookID"
        PnlBorderBookID.Size = New Size(309, 39)
        PnlBorderBookID.TabIndex = 1
        ' 
        ' Panel8
        ' 
        Panel8.BackColor = Color.White
        Panel8.Controls.Add(TxtBookID)
        Panel8.Dock = DockStyle.Fill
        Panel8.ForeColor = Color.Black
        Panel8.Location = New Point(0, 0)
        Panel8.Margin = New Padding(0)
        Panel8.Name = "Panel8"
        Panel8.Padding = New Padding(0, 5, 0, 0)
        Panel8.Size = New Size(309, 39)
        Panel8.TabIndex = 0
        ' 
        ' TxtBookID
        ' 
        TxtBookID.BorderStyle = BorderStyle.None
        TxtBookID.Font = New Font("Arial", 11F)
        TxtBookID.Location = New Point(13, 7)
        TxtBookID.Name = "TxtBookID"
        TxtBookID.Size = New Size(267, 17)
        TxtBookID.TabIndex = 0
        TxtBookID.Text = "Enter"
        ' 
        ' Panel9
        ' 
        Panel9.Controls.Add(Label4)
        Panel9.Dock = DockStyle.Fill
        Panel9.Location = New Point(3, 3)
        Panel9.Name = "Panel9"
        Panel9.Size = New Size(156, 43)
        Panel9.TabIndex = 0
        ' 
        ' Label4
        ' 
        Label4.Dock = DockStyle.Fill
        Label4.Font = New Font("Arial", 14F)
        Label4.ForeColor = Color.DarkSlateGray
        Label4.Location = New Point(0, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(156, 43)
        Label4.TabIndex = 0
        Label4.Text = "Book ID"
        Label4.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' PnlTitle
        ' 
        PnlTitle.Controls.Add(TLPTitle)
        PnlTitle.Dock = DockStyle.Fill
        PnlTitle.Location = New Point(3, 58)
        PnlTitle.Name = "PnlTitle"
        PnlTitle.Size = New Size(471, 49)
        PnlTitle.TabIndex = 1
        ' 
        ' TLPTitle
        ' 
        TLPTitle.ColumnCount = 2
        TLPTitle.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 34.4418068F))
        TLPTitle.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 65.5582F))
        TLPTitle.Controls.Add(PnlBorderStudentID, 1, 0)
        TLPTitle.Controls.Add(Panel5, 0, 0)
        TLPTitle.Dock = DockStyle.Fill
        TLPTitle.Location = New Point(0, 0)
        TLPTitle.Name = "TLPTitle"
        TLPTitle.RowCount = 1
        TLPTitle.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TLPTitle.Size = New Size(471, 49)
        TLPTitle.TabIndex = 0
        ' 
        ' PnlBorderStudentID
        ' 
        PnlBorderStudentID.Controls.Add(Panel4)
        PnlBorderStudentID.Dock = DockStyle.Fill
        PnlBorderStudentID.Location = New Point(162, 5)
        PnlBorderStudentID.Margin = New Padding(0, 5, 0, 5)
        PnlBorderStudentID.Name = "PnlBorderStudentID"
        PnlBorderStudentID.Size = New Size(309, 39)
        PnlBorderStudentID.TabIndex = 1
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = Color.White
        Panel4.Controls.Add(TxtStudentID)
        Panel4.Dock = DockStyle.Fill
        Panel4.ForeColor = Color.Black
        Panel4.Location = New Point(0, 0)
        Panel4.Margin = New Padding(0)
        Panel4.Name = "Panel4"
        Panel4.Padding = New Padding(0, 5, 0, 0)
        Panel4.Size = New Size(309, 39)
        Panel4.TabIndex = 0
        ' 
        ' TxtStudentID
        ' 
        TxtStudentID.BorderStyle = BorderStyle.None
        TxtStudentID.Font = New Font("Arial", 11F)
        TxtStudentID.Location = New Point(13, 7)
        TxtStudentID.Name = "TxtStudentID"
        TxtStudentID.Size = New Size(267, 17)
        TxtStudentID.TabIndex = 0
        TxtStudentID.Text = "Enter"
        ' 
        ' Panel5
        ' 
        Panel5.Controls.Add(Label5)
        Panel5.Dock = DockStyle.Fill
        Panel5.Location = New Point(3, 3)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(156, 43)
        Panel5.TabIndex = 0
        ' 
        ' Label5
        ' 
        Label5.Dock = DockStyle.Fill
        Label5.Font = New Font("Arial", 14F)
        Label5.ForeColor = Color.DarkSlateGray
        Label5.Location = New Point(0, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(156, 43)
        Label5.TabIndex = 0
        Label5.Text = "Student ID"
        Label5.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' PnlBookID
        ' 
        PnlBookID.Controls.Add(TLPBookID)
        PnlBookID.Dock = DockStyle.Fill
        PnlBookID.Location = New Point(3, 3)
        PnlBookID.Name = "PnlBookID"
        PnlBookID.Size = New Size(471, 49)
        PnlBookID.TabIndex = 0
        ' 
        ' TLPBookID
        ' 
        TLPBookID.ColumnCount = 2
        TLPBookID.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 34.4418068F))
        TLPBookID.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 65.5582F))
        TLPBookID.Controls.Add(PnlBorderBorrowID, 1, 0)
        TLPBookID.Controls.Add(PnlForLabelBookID, 0, 0)
        TLPBookID.Dock = DockStyle.Fill
        TLPBookID.Location = New Point(0, 0)
        TLPBookID.Name = "TLPBookID"
        TLPBookID.RowCount = 1
        TLPBookID.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TLPBookID.Size = New Size(471, 49)
        TLPBookID.TabIndex = 0
        ' 
        ' PnlBorderBorrowID
        ' 
        PnlBorderBorrowID.Controls.Add(Panel1)
        PnlBorderBorrowID.Dock = DockStyle.Fill
        PnlBorderBorrowID.Location = New Point(162, 5)
        PnlBorderBorrowID.Margin = New Padding(0, 5, 0, 5)
        PnlBorderBorrowID.Name = "PnlBorderBorrowID"
        PnlBorderBorrowID.Size = New Size(309, 39)
        PnlBorderBorrowID.TabIndex = 2
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.White
        Panel1.Controls.Add(TxtBorrowID)
        Panel1.Dock = DockStyle.Fill
        Panel1.ForeColor = Color.Black
        Panel1.Location = New Point(0, 0)
        Panel1.Margin = New Padding(0)
        Panel1.Name = "Panel1"
        Panel1.Padding = New Padding(0, 5, 0, 0)
        Panel1.Size = New Size(309, 39)
        Panel1.TabIndex = 0
        ' 
        ' TxtBorrowID
        ' 
        TxtBorrowID.BorderStyle = BorderStyle.None
        TxtBorrowID.Font = New Font("Arial", 11F)
        TxtBorrowID.Location = New Point(13, 7)
        TxtBorrowID.Name = "TxtBorrowID"
        TxtBorrowID.Size = New Size(267, 17)
        TxtBorrowID.TabIndex = 0
        TxtBorrowID.Text = "Enter"
        ' 
        ' PnlForLabelBookID
        ' 
        PnlForLabelBookID.Controls.Add(Label2)
        PnlForLabelBookID.Dock = DockStyle.Fill
        PnlForLabelBookID.Location = New Point(3, 3)
        PnlForLabelBookID.Name = "PnlForLabelBookID"
        PnlForLabelBookID.Size = New Size(156, 43)
        PnlForLabelBookID.TabIndex = 0
        ' 
        ' Label2
        ' 
        Label2.Dock = DockStyle.Fill
        Label2.Font = New Font("Arial", 13F)
        Label2.ForeColor = Color.DarkSlateGray
        Label2.Location = New Point(0, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(156, 43)
        Label2.TabIndex = 0
        Label2.Text = "Borrow ID"
        Label2.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' Panel10
        ' 
        Panel10.BackColor = SystemColors.Control
        Panel10.BorderStyle = BorderStyle.Fixed3D
        Panel10.Dock = DockStyle.Fill
        Panel10.Location = New Point(3, 3)
        Panel10.Name = "Panel10"
        Panel10.Size = New Size(477, 1)
        Panel10.TabIndex = 2
        ' 
        ' PnlTopAddNewBook
        ' 
        PnlTopAddNewBook.BackColor = SystemColors.Control
        PnlTopAddNewBook.Controls.Add(Panel20)
        PnlTopAddNewBook.Dock = DockStyle.Fill
        PnlTopAddNewBook.Location = New Point(3, 3)
        PnlTopAddNewBook.Margin = New Padding(3, 3, 3, 0)
        PnlTopAddNewBook.Name = "PnlTopAddNewBook"
        PnlTopAddNewBook.Size = New Size(483, 58)
        PnlTopAddNewBook.TabIndex = 0
        ' 
        ' Panel20
        ' 
        Panel20.Controls.Add(TableLayoutPanel6)
        Panel20.Dock = DockStyle.Fill
        Panel20.Location = New Point(0, 0)
        Panel20.Name = "Panel20"
        Panel20.Padding = New Padding(30, 0, 0, 0)
        Panel20.Size = New Size(483, 58)
        Panel20.TabIndex = 0
        ' 
        ' TableLayoutPanel6
        ' 
        TableLayoutPanel6.ColumnCount = 1
        TableLayoutPanel6.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel6.Controls.Add(Panel24, 0, 1)
        TableLayoutPanel6.Controls.Add(Panel23, 0, 0)
        TableLayoutPanel6.Dock = DockStyle.Fill
        TableLayoutPanel6.Location = New Point(30, 0)
        TableLayoutPanel6.Name = "TableLayoutPanel6"
        TableLayoutPanel6.RowCount = 2
        TableLayoutPanel6.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel6.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel6.Size = New Size(453, 58)
        TableLayoutPanel6.TabIndex = 0
        ' 
        ' Panel24
        ' 
        Panel24.Controls.Add(PnlSelect)
        Panel24.Dock = DockStyle.Fill
        Panel24.Location = New Point(10, 29)
        Panel24.Margin = New Padding(10, 0, 50, 2)
        Panel24.Name = "Panel24"
        Panel24.Size = New Size(393, 27)
        Panel24.TabIndex = 2
        ' 
        ' PnlSelect
        ' 
        PnlSelect.BackColor = Color.White
        PnlSelect.Controls.Add(PnlBorderSelectID)
        PnlSelect.Dock = DockStyle.Fill
        PnlSelect.ForeColor = Color.Black
        PnlSelect.Location = New Point(0, 0)
        PnlSelect.Margin = New Padding(0)
        PnlSelect.Name = "PnlSelect"
        PnlSelect.Size = New Size(393, 27)
        PnlSelect.TabIndex = 0
        ' 
        ' PnlBorderSelectID
        ' 
        PnlBorderSelectID.Controls.Add(Panel25)
        PnlBorderSelectID.Dock = DockStyle.Fill
        PnlBorderSelectID.Location = New Point(0, 0)
        PnlBorderSelectID.Margin = New Padding(0, 5, 0, 5)
        PnlBorderSelectID.Name = "PnlBorderSelectID"
        PnlBorderSelectID.Size = New Size(393, 27)
        PnlBorderSelectID.TabIndex = 2
        ' 
        ' Panel25
        ' 
        Panel25.BackColor = Color.White
        Panel25.Controls.Add(TxtSelectID)
        Panel25.Dock = DockStyle.Fill
        Panel25.ForeColor = Color.Black
        Panel25.Location = New Point(0, 0)
        Panel25.Margin = New Padding(0)
        Panel25.Name = "Panel25"
        Panel25.Padding = New Padding(0, 5, 0, 0)
        Panel25.Size = New Size(393, 27)
        Panel25.TabIndex = 0
        ' 
        ' TxtSelectID
        ' 
        TxtSelectID.BorderStyle = BorderStyle.None
        TxtSelectID.Font = New Font("Arial", 11F)
        TxtSelectID.Location = New Point(12, 3)
        TxtSelectID.Name = "TxtSelectID"
        TxtSelectID.Size = New Size(267, 17)
        TxtSelectID.TabIndex = 0
        ' 
        ' Panel23
        ' 
        Panel23.Controls.Add(Label1)
        Panel23.Dock = DockStyle.Fill
        Panel23.Location = New Point(3, 3)
        Panel23.Name = "Panel23"
        Panel23.Size = New Size(447, 23)
        Panel23.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.Dock = DockStyle.Fill
        Label1.Font = New Font("Arial", 12F, FontStyle.Bold)
        Label1.ForeColor = Color.DarkSlateGray
        Label1.Location = New Point(0, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(447, 23)
        Label1.TabIndex = 1
        Label1.Text = "Select a Borrow ID to MODIFY:"
        Label1.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' FormModifyBorrowing
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(489, 510)
        Controls.Add(PnlFill)
        FormBorderStyle = FormBorderStyle.None
        Name = "FormModifyBorrowing"
        StartPosition = FormStartPosition.CenterScreen
        Text = "FormModifyBorrowing"
        PnlFill.ResumeLayout(False)
        TLPModifyBook.ResumeLayout(False)
        PnlFillAddnewBook.ResumeLayout(False)
        TLPAddNewBookFill.ResumeLayout(False)
        PnlCancelAdd.ResumeLayout(False)
        TLPCancelAdd.ResumeLayout(False)
        PnlForBtnAdd.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        Panel6.ResumeLayout(False)
        PnlForCancel.ResumeLayout(False)
        PnlBtnCancel.ResumeLayout(False)
        TLPAddNewBookColumn.ResumeLayout(False)
        TLPVariablesAddNewBook.ResumeLayout(False)
        Panel17.ResumeLayout(False)
        TableLayoutPanel5.ResumeLayout(False)
        PnlBorderStatus.ResumeLayout(False)
        Panel21.ResumeLayout(False)
        Panel22.ResumeLayout(False)
        Panel14.ResumeLayout(False)
        TableLayoutPanel4.ResumeLayout(False)
        PnlBorderReturnDate.ResumeLayout(False)
        Panel18.ResumeLayout(False)
        Panel19.ResumeLayout(False)
        Panel11.ResumeLayout(False)
        TableLayoutPanel3.ResumeLayout(False)
        PnlBorderDueDate.ResumeLayout(False)
        Panel15.ResumeLayout(False)
        Panel16.ResumeLayout(False)
        Panel7.ResumeLayout(False)
        TableLayoutPanel2.ResumeLayout(False)
        PnlBorderBorrowedDate.ResumeLayout(False)
        Panel12.ResumeLayout(False)
        Panel13.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        TableLayoutPanel1.ResumeLayout(False)
        PnlBorderBookID.ResumeLayout(False)
        Panel8.ResumeLayout(False)
        Panel8.PerformLayout()
        Panel9.ResumeLayout(False)
        PnlTitle.ResumeLayout(False)
        TLPTitle.ResumeLayout(False)
        PnlBorderStudentID.ResumeLayout(False)
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        Panel5.ResumeLayout(False)
        PnlBookID.ResumeLayout(False)
        TLPBookID.ResumeLayout(False)
        PnlBorderBorrowID.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        PnlForLabelBookID.ResumeLayout(False)
        PnlTopAddNewBook.ResumeLayout(False)
        Panel20.ResumeLayout(False)
        TableLayoutPanel6.ResumeLayout(False)
        Panel24.ResumeLayout(False)
        PnlSelect.ResumeLayout(False)
        PnlBorderSelectID.ResumeLayout(False)
        Panel25.ResumeLayout(False)
        Panel25.PerformLayout()
        Panel23.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents PnlFill As Panel
    Friend WithEvents TLPModifyBook As TableLayoutPanel
    Friend WithEvents PnlTopAddNewBook As Panel
    Friend WithEvents Panel20 As Panel
    Friend WithEvents TableLayoutPanel6 As TableLayoutPanel
    Friend WithEvents Panel24 As Panel
    Friend WithEvents PnlSelect As Panel
    Friend WithEvents PnlBorderSelectID As Panel
    Friend WithEvents Panel25 As Panel
    Friend WithEvents TxtSelectID As TextBox
    Friend WithEvents Panel23 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents PnlFillAddnewBook As Panel
    Friend WithEvents TLPAddNewBookFill As TableLayoutPanel
    Friend WithEvents TLPAddNewBookColumn As Panel
    Friend WithEvents TLPVariablesAddNewBook As TableLayoutPanel
    Friend WithEvents Panel17 As Panel
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents PnlBorderStatus As Panel
    Friend WithEvents Panel21 As Panel
    Friend WithEvents ComboStatus As ComboBox
    Friend WithEvents Panel22 As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents Panel14 As Panel
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents PnlBorderReturnDate As Panel
    Friend WithEvents Panel18 As Panel
    Friend WithEvents DTPReturnDate As DateTimePicker
    Friend WithEvents Panel19 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel11 As Panel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents PnlBorderDueDate As Panel
    Friend WithEvents Panel15 As Panel
    Friend WithEvents DTPDueDate As DateTimePicker
    Friend WithEvents Panel16 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents PnlBorderBorrowedDate As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents DTPBorrowedDate As DateTimePicker
    Friend WithEvents Panel13 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents PnlBorderBookID As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents TxtBookID As TextBox
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents PnlTitle As Panel
    Friend WithEvents TLPTitle As TableLayoutPanel
    Friend WithEvents PnlBorderStudentID As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents TxtStudentID As TextBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents PnlBookID As Panel
    Friend WithEvents TLPBookID As TableLayoutPanel
    Friend WithEvents PnlBorderBorrowID As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TxtBorrowID As TextBox
    Friend WithEvents PnlForLabelBookID As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel10 As Panel
    Friend WithEvents PnlCancelAdd As Panel
    Friend WithEvents TLPCancelAdd As TableLayoutPanel
    Friend WithEvents PnlForBtnAdd As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents BtnSave As Button
    Friend WithEvents PnlForCancel As Panel
    Friend WithEvents PnlBtnCancel As Panel
    Friend WithEvents BtnCancel As Button
End Class
