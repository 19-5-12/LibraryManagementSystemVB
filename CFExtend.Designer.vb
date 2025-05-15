<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CFExtend
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
        components = New ComponentModel.Container()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        TBLFill = New TableLayoutPanel()
        PnlBelow = New Panel()
        Panel8 = New Panel()
        LblDateTimeRequests = New Label()
        Label4 = New Label()
        Panel7 = New Panel()
        LblDateTime = New Label()
        Label2 = New Label()
        TBLPRequests = New TableLayoutPanel()
        Panel10 = New Panel()
        TBLTopOfData = New TableLayoutPanel()
        Label1 = New Label()
        PnlForData = New Panel()
        PnlForDataGridView = New Panel()
        DataGridView1 = New DataGridView()
        Panel1 = New Panel()
        TableLayoutPanel1 = New TableLayoutPanel()
        TableLayoutPanel2 = New TableLayoutPanel()
        Panel14 = New Panel()
        ComboSearchDate = New ComboBox()
        Panel9 = New Panel()
        PnlDateEnd = New Panel()
        TableLayoutPanel21 = New TableLayoutPanel()
        Panel12 = New Panel()
        Label5 = New Label()
        Panel13 = New Panel()
        DateTimePickerEnd = New DateTimePicker()
        PnlViewStatistics = New Panel()
        BtnViewStats = New Button()
        Panel11 = New Panel()
        PnlDateStart = New Panel()
        TableLayoutPanel3 = New TableLayoutPanel()
        Panel15 = New Panel()
        Label3 = New Label()
        Panel16 = New Panel()
        DateTimePickerStart = New DateTimePicker()
        Panel17 = New Panel()
        Panel5 = New Panel()
        TableLayoutPanel5 = New TableLayoutPanel()
        PnlForBtnBlock = New Panel()
        BtnExtend = New Button()
        PnlForBtnReports = New Panel()
        BtnRequest = New Button()
        PnlForBtnBorrowing = New Panel()
        BtnLog = New Button()
        TimerDateTime = New Timer(components)
        TBLFill.SuspendLayout()
        PnlBelow.SuspendLayout()
        Panel8.SuspendLayout()
        Panel7.SuspendLayout()
        TBLPRequests.SuspendLayout()
        TBLTopOfData.SuspendLayout()
        PnlForData.SuspendLayout()
        PnlForDataGridView.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        Panel14.SuspendLayout()
        Panel9.SuspendLayout()
        PnlDateEnd.SuspendLayout()
        TableLayoutPanel21.SuspendLayout()
        Panel12.SuspendLayout()
        Panel13.SuspendLayout()
        PnlViewStatistics.SuspendLayout()
        Panel11.SuspendLayout()
        PnlDateStart.SuspendLayout()
        TableLayoutPanel3.SuspendLayout()
        Panel15.SuspendLayout()
        Panel16.SuspendLayout()
        Panel5.SuspendLayout()
        TableLayoutPanel5.SuspendLayout()
        PnlForBtnBlock.SuspendLayout()
        PnlForBtnReports.SuspendLayout()
        PnlForBtnBorrowing.SuspendLayout()
        SuspendLayout()
        ' 
        ' TBLFill
        ' 
        TBLFill.ColumnCount = 1
        TBLFill.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TBLFill.Controls.Add(PnlBelow, 0, 1)
        TBLFill.Controls.Add(Panel1, 0, 0)
        TBLFill.Dock = DockStyle.Fill
        TBLFill.Location = New Point(0, 0)
        TBLFill.Margin = New Padding(0)
        TBLFill.Name = "TBLFill"
        TBLFill.RowCount = 2
        TBLFill.RowStyles.Add(New RowStyle(SizeType.Percent, 8.421053F))
        TBLFill.RowStyles.Add(New RowStyle(SizeType.Percent, 91.57895F))
        TBLFill.Size = New Size(967, 570)
        TBLFill.TabIndex = 3
        ' 
        ' PnlBelow
        ' 
        PnlBelow.Controls.Add(Panel8)
        PnlBelow.Controls.Add(Panel7)
        PnlBelow.Controls.Add(TBLPRequests)
        PnlBelow.Dock = DockStyle.Fill
        PnlBelow.Location = New Point(0, 48)
        PnlBelow.Margin = New Padding(0)
        PnlBelow.Name = "PnlBelow"
        PnlBelow.Size = New Size(967, 522)
        PnlBelow.TabIndex = 3
        ' 
        ' Panel8
        ' 
        Panel8.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Panel8.Controls.Add(LblDateTimeRequests)
        Panel8.Controls.Add(Label4)
        Panel8.Location = New Point(227, 499)
        Panel8.Margin = New Padding(0)
        Panel8.Name = "Panel8"
        Panel8.Size = New Size(556, 23)
        Panel8.TabIndex = 2
        ' 
        ' LblDateTimeRequests
        ' 
        LblDateTimeRequests.Font = New Font("Arial", 8F)
        LblDateTimeRequests.ForeColor = Color.Gray
        LblDateTimeRequests.Location = New Point(369, 0)
        LblDateTimeRequests.Name = "LblDateTimeRequests"
        LblDateTimeRequests.Size = New Size(184, 23)
        LblDateTimeRequests.TabIndex = 3
        LblDateTimeRequests.Text = "time"
        LblDateTimeRequests.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label4
        ' 
        Label4.Font = New Font("Arial", 8F)
        Label4.ForeColor = Color.Gray
        Label4.Location = New Point(0, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(370, 23)
        Label4.TabIndex = 2
        Label4.Text = "© 2025 Quezon City University Library Management System | Current Time:"
        Label4.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' Panel7
        ' 
        Panel7.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Panel7.Controls.Add(LblDateTime)
        Panel7.Controls.Add(Label2)
        Panel7.Location = New Point(227, 2411)
        Panel7.Margin = New Padding(0)
        Panel7.Name = "Panel7"
        Panel7.Size = New Size(4391, 23)
        Panel7.TabIndex = 1
        ' 
        ' LblDateTime
        ' 
        LblDateTime.Font = New Font("Arial", 8F)
        LblDateTime.ForeColor = Color.Gray
        LblDateTime.Location = New Point(369, 0)
        LblDateTime.Name = "LblDateTime"
        LblDateTime.Size = New Size(184, 23)
        LblDateTime.TabIndex = 3
        LblDateTime.Text = "time"
        LblDateTime.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label2
        ' 
        Label2.Font = New Font("Arial", 8F)
        Label2.ForeColor = Color.Gray
        Label2.Location = New Point(0, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(370, 23)
        Label2.TabIndex = 2
        Label2.Text = "© 2025 Quezon City University Library Management System | Current Time:"
        Label2.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' TBLPRequests
        ' 
        TBLPRequests.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        TBLPRequests.AutoSize = True
        TBLPRequests.BackColor = Color.White
        TBLPRequests.ColumnCount = 1
        TBLPRequests.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TBLPRequests.Controls.Add(Panel10, 0, 1)
        TBLPRequests.Controls.Add(TBLTopOfData, 0, 0)
        TBLPRequests.Controls.Add(PnlForData, 0, 2)
        TBLPRequests.Location = New Point(19, 23)
        TBLPRequests.Name = "TBLPRequests"
        TBLPRequests.RowCount = 3
        TBLPRequests.RowStyles.Add(New RowStyle(SizeType.Percent, 10F))
        TBLPRequests.RowStyles.Add(New RowStyle(SizeType.Absolute, 1F))
        TBLPRequests.RowStyles.Add(New RowStyle(SizeType.Percent, 90F))
        TBLPRequests.Size = New Size(931, 436)
        TBLPRequests.TabIndex = 0
        ' 
        ' Panel10
        ' 
        Panel10.BackColor = SystemColors.Control
        Panel10.Dock = DockStyle.Fill
        Panel10.Location = New Point(3, 46)
        Panel10.Name = "Panel10"
        Panel10.Size = New Size(925, 1)
        Panel10.TabIndex = 3
        ' 
        ' TBLTopOfData
        ' 
        TBLTopOfData.BackColor = Color.White
        TBLTopOfData.ColumnCount = 1
        TBLTopOfData.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 80F))
        TBLTopOfData.Controls.Add(Label1, 0, 0)
        TBLTopOfData.Dock = DockStyle.Fill
        TBLTopOfData.Location = New Point(0, 0)
        TBLTopOfData.Margin = New Padding(0)
        TBLTopOfData.Name = "TBLTopOfData"
        TBLTopOfData.RowCount = 1
        TBLTopOfData.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TBLTopOfData.Size = New Size(931, 43)
        TBLTopOfData.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.Dock = DockStyle.Fill
        Label1.Font = New Font("Arial", 10F, FontStyle.Bold)
        Label1.ForeColor = Color.DarkSlateGray
        Label1.Location = New Point(3, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(925, 43)
        Label1.TabIndex = 0
        Label1.Text = "List of Extention Requests"
        Label1.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' PnlForData
        ' 
        PnlForData.BackColor = Color.White
        PnlForData.Controls.Add(PnlForDataGridView)
        PnlForData.Dock = DockStyle.Fill
        PnlForData.Location = New Point(0, 44)
        PnlForData.Margin = New Padding(0)
        PnlForData.Name = "PnlForData"
        PnlForData.Size = New Size(931, 392)
        PnlForData.TabIndex = 1
        ' 
        ' PnlForDataGridView
        ' 
        PnlForDataGridView.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        PnlForDataGridView.AutoScroll = True
        PnlForDataGridView.AutoSize = True
        PnlForDataGridView.Controls.Add(DataGridView1)
        PnlForDataGridView.Location = New Point(25, 13)
        PnlForDataGridView.Name = "PnlForDataGridView"
        PnlForDataGridView.Size = New Size(881, 352)
        PnlForDataGridView.TabIndex = 0
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.BackgroundColor = Color.White
        DataGridView1.BorderStyle = BorderStyle.None
        DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        DataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = SystemColors.Control
        DataGridViewCellStyle1.Font = New Font("Arial", 10F, FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = Color.DarkSlateGray
        DataGridViewCellStyle1.SelectionBackColor = Color.White
        DataGridViewCellStyle1.SelectionForeColor = Color.DarkSlateGray
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        DataGridView1.ColumnHeadersHeight = 30
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = SystemColors.Window
        DataGridViewCellStyle2.Font = New Font("Arial", 9F)
        DataGridViewCellStyle2.ForeColor = Color.DarkSlateGray
        DataGridViewCellStyle2.Padding = New Padding(0, 10, 10, 0)
        DataGridViewCellStyle2.SelectionBackColor = Color.White
        DataGridViewCellStyle2.SelectionForeColor = Color.DarkSlateGray
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        DataGridView1.Dock = DockStyle.Fill
        DataGridView1.EnableHeadersVisualStyles = False
        DataGridView1.GridColor = Color.White
        DataGridView1.Location = New Point(0, 0)
        DataGridView1.Margin = New Padding(0)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridView1.RowHeadersVisible = False
        DataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle3.ForeColor = Color.DarkSlateGray
        DataGridViewCellStyle3.SelectionForeColor = Color.DarkSlateGray
        DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle3
        DataGridView1.RowTemplate.Height = 40
        DataGridView1.RowTemplate.Resizable = DataGridViewTriState.False
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.Size = New Size(881, 352)
        DataGridView1.TabIndex = 1
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(TableLayoutPanel1)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Margin = New Padding(0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(967, 48)
        Panel1.TabIndex = 0
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.78F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 49.22F))
        TableLayoutPanel1.Controls.Add(TableLayoutPanel2, 0, 0)
        TableLayoutPanel1.Controls.Add(Panel5, 1, 0)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Margin = New Padding(0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Size = New Size(967, 48)
        TableLayoutPanel1.TabIndex = 0
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 5
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 3.19865322F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 23.4215889F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 28.7169037F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 22.81059F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 21.5885944F))
        TableLayoutPanel2.Controls.Add(Panel14, 2, 0)
        TableLayoutPanel2.Controls.Add(Panel9, 4, 0)
        TableLayoutPanel2.Controls.Add(PnlViewStatistics, 1, 0)
        TableLayoutPanel2.Controls.Add(Panel11, 3, 0)
        TableLayoutPanel2.Controls.Add(Panel17, 0, 0)
        TableLayoutPanel2.Dock = DockStyle.Fill
        TableLayoutPanel2.Location = New Point(0, 0)
        TableLayoutPanel2.Margin = New Padding(0)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 1
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.Size = New Size(491, 48)
        TableLayoutPanel2.TabIndex = 3
        ' 
        ' Panel14
        ' 
        Panel14.Controls.Add(ComboSearchDate)
        Panel14.Dock = DockStyle.Fill
        Panel14.Location = New Point(135, 18)
        Panel14.Margin = New Padding(5, 18, 5, 5)
        Panel14.Name = "Panel14"
        Panel14.Size = New Size(131, 25)
        Panel14.TabIndex = 8
        ' 
        ' ComboSearchDate
        ' 
        ComboSearchDate.Dock = DockStyle.Fill
        ComboSearchDate.DropDownStyle = ComboBoxStyle.DropDownList
        ComboSearchDate.Font = New Font("Arial", 11F)
        ComboSearchDate.FormattingEnabled = True
        ComboSearchDate.Items.AddRange(New Object() {"Today", "This Week", "This Month", "This Year", "Custom Range"})
        ComboSearchDate.Location = New Point(0, 0)
        ComboSearchDate.Name = "ComboSearchDate"
        ComboSearchDate.Size = New Size(131, 25)
        ComboSearchDate.TabIndex = 1
        ' 
        ' Panel9
        ' 
        Panel9.Controls.Add(PnlDateEnd)
        Panel9.Dock = DockStyle.Fill
        Panel9.Location = New Point(386, 3)
        Panel9.Name = "Panel9"
        Panel9.Size = New Size(102, 42)
        Panel9.TabIndex = 7
        ' 
        ' PnlDateEnd
        ' 
        PnlDateEnd.Controls.Add(TableLayoutPanel21)
        PnlDateEnd.Dock = DockStyle.Fill
        PnlDateEnd.Location = New Point(0, 0)
        PnlDateEnd.Margin = New Padding(0)
        PnlDateEnd.Name = "PnlDateEnd"
        PnlDateEnd.Size = New Size(102, 42)
        PnlDateEnd.TabIndex = 8
        ' 
        ' TableLayoutPanel21
        ' 
        TableLayoutPanel21.ColumnCount = 1
        TableLayoutPanel21.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel21.Controls.Add(Panel12, 0, 0)
        TableLayoutPanel21.Controls.Add(Panel13, 0, 1)
        TableLayoutPanel21.Dock = DockStyle.Fill
        TableLayoutPanel21.Location = New Point(0, 0)
        TableLayoutPanel21.Margin = New Padding(0)
        TableLayoutPanel21.Name = "TableLayoutPanel21"
        TableLayoutPanel21.RowCount = 2
        TableLayoutPanel21.RowStyles.Add(New RowStyle(SizeType.Percent, 43.2432442F))
        TableLayoutPanel21.RowStyles.Add(New RowStyle(SizeType.Percent, 56.7567558F))
        TableLayoutPanel21.Size = New Size(102, 42)
        TableLayoutPanel21.TabIndex = 0
        ' 
        ' Panel12
        ' 
        Panel12.Controls.Add(Label5)
        Panel12.Dock = DockStyle.Fill
        Panel12.Location = New Point(0, 0)
        Panel12.Margin = New Padding(0)
        Panel12.Name = "Panel12"
        Panel12.Size = New Size(102, 18)
        Panel12.TabIndex = 0
        ' 
        ' Label5
        ' 
        Label5.Dock = DockStyle.Fill
        Label5.Font = New Font("Arial", 9F)
        Label5.Location = New Point(0, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(102, 18)
        Label5.TabIndex = 0
        Label5.Text = "Date End"
        Label5.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Panel13
        ' 
        Panel13.Controls.Add(DateTimePickerEnd)
        Panel13.Dock = DockStyle.Fill
        Panel13.Location = New Point(2, 18)
        Panel13.Margin = New Padding(2, 0, 0, 0)
        Panel13.Name = "Panel13"
        Panel13.Size = New Size(100, 24)
        Panel13.TabIndex = 1
        ' 
        ' DateTimePickerEnd
        ' 
        DateTimePickerEnd.Dock = DockStyle.Fill
        DateTimePickerEnd.Font = New Font("Arial", 9F)
        DateTimePickerEnd.Format = DateTimePickerFormat.Short
        DateTimePickerEnd.Location = New Point(0, 0)
        DateTimePickerEnd.Name = "DateTimePickerEnd"
        DateTimePickerEnd.Size = New Size(100, 21)
        DateTimePickerEnd.TabIndex = 0
        ' 
        ' PnlViewStatistics
        ' 
        PnlViewStatistics.Controls.Add(BtnViewStats)
        PnlViewStatistics.Dock = DockStyle.Fill
        PnlViewStatistics.Location = New Point(18, 15)
        PnlViewStatistics.Margin = New Padding(3, 15, 3, 5)
        PnlViewStatistics.Name = "PnlViewStatistics"
        PnlViewStatistics.Size = New Size(109, 28)
        PnlViewStatistics.TabIndex = 6
        ' 
        ' BtnViewStats
        ' 
        BtnViewStats.BackColor = Color.FromArgb(CByte(44), CByte(80), CByte(126))
        BtnViewStats.Dock = DockStyle.Fill
        BtnViewStats.FlatAppearance.BorderSize = 0
        BtnViewStats.FlatStyle = FlatStyle.Flat
        BtnViewStats.Font = New Font("Arial", 13F)
        BtnViewStats.ForeColor = Color.White
        BtnViewStats.Location = New Point(0, 0)
        BtnViewStats.Name = "BtnViewStats"
        BtnViewStats.Size = New Size(109, 28)
        BtnViewStats.TabIndex = 0
        BtnViewStats.Text = "Load List"
        BtnViewStats.UseVisualStyleBackColor = False
        ' 
        ' Panel11
        ' 
        Panel11.Controls.Add(PnlDateStart)
        Panel11.Dock = DockStyle.Fill
        Panel11.Location = New Point(276, 5)
        Panel11.Margin = New Padding(5)
        Panel11.Name = "Panel11"
        Panel11.Size = New Size(102, 38)
        Panel11.TabIndex = 3
        ' 
        ' PnlDateStart
        ' 
        PnlDateStart.Controls.Add(TableLayoutPanel3)
        PnlDateStart.Dock = DockStyle.Fill
        PnlDateStart.Location = New Point(0, 0)
        PnlDateStart.Margin = New Padding(0)
        PnlDateStart.Name = "PnlDateStart"
        PnlDateStart.Size = New Size(102, 38)
        PnlDateStart.TabIndex = 4
        ' 
        ' TableLayoutPanel3
        ' 
        TableLayoutPanel3.ColumnCount = 1
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel3.Controls.Add(Panel15, 0, 0)
        TableLayoutPanel3.Controls.Add(Panel16, 0, 1)
        TableLayoutPanel3.Dock = DockStyle.Fill
        TableLayoutPanel3.Location = New Point(0, 0)
        TableLayoutPanel3.Margin = New Padding(0)
        TableLayoutPanel3.Name = "TableLayoutPanel3"
        TableLayoutPanel3.RowCount = 2
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 43.2432442F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 56.7567558F))
        TableLayoutPanel3.Size = New Size(102, 38)
        TableLayoutPanel3.TabIndex = 0
        ' 
        ' Panel15
        ' 
        Panel15.Controls.Add(Label3)
        Panel15.Dock = DockStyle.Fill
        Panel15.Location = New Point(0, 0)
        Panel15.Margin = New Padding(0)
        Panel15.Name = "Panel15"
        Panel15.Size = New Size(102, 16)
        Panel15.TabIndex = 0
        ' 
        ' Label3
        ' 
        Label3.Dock = DockStyle.Fill
        Label3.Font = New Font("Arial", 9F)
        Label3.Location = New Point(0, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(102, 16)
        Label3.TabIndex = 0
        Label3.Text = "Date Start"
        Label3.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Panel16
        ' 
        Panel16.Controls.Add(DateTimePickerStart)
        Panel16.Dock = DockStyle.Fill
        Panel16.Location = New Point(0, 16)
        Panel16.Margin = New Padding(0, 0, 2, 0)
        Panel16.Name = "Panel16"
        Panel16.Size = New Size(100, 22)
        Panel16.TabIndex = 1
        ' 
        ' DateTimePickerStart
        ' 
        DateTimePickerStart.Dock = DockStyle.Fill
        DateTimePickerStart.Font = New Font("Arial", 9F)
        DateTimePickerStart.Format = DateTimePickerFormat.Short
        DateTimePickerStart.Location = New Point(0, 0)
        DateTimePickerStart.Name = "DateTimePickerStart"
        DateTimePickerStart.Size = New Size(100, 21)
        DateTimePickerStart.TabIndex = 0
        ' 
        ' Panel17
        ' 
        Panel17.Dock = DockStyle.Fill
        Panel17.Location = New Point(3, 3)
        Panel17.Name = "Panel17"
        Panel17.Size = New Size(9, 42)
        Panel17.TabIndex = 1
        ' 
        ' Panel5
        ' 
        Panel5.Controls.Add(TableLayoutPanel5)
        Panel5.Dock = DockStyle.Fill
        Panel5.Location = New Point(494, 3)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(470, 42)
        Panel5.TabIndex = 2
        ' 
        ' TableLayoutPanel5
        ' 
        TableLayoutPanel5.ColumnCount = 3
        TableLayoutPanel5.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel5.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel5.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel5.Controls.Add(PnlForBtnBlock, 2, 0)
        TableLayoutPanel5.Controls.Add(PnlForBtnReports, 1, 0)
        TableLayoutPanel5.Controls.Add(PnlForBtnBorrowing, 0, 0)
        TableLayoutPanel5.Dock = DockStyle.Fill
        TableLayoutPanel5.Location = New Point(0, 0)
        TableLayoutPanel5.Name = "TableLayoutPanel5"
        TableLayoutPanel5.RowCount = 1
        TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel5.Size = New Size(470, 42)
        TableLayoutPanel5.TabIndex = 2
        ' 
        ' PnlForBtnBlock
        ' 
        PnlForBtnBlock.Controls.Add(BtnExtend)
        PnlForBtnBlock.Dock = DockStyle.Fill
        PnlForBtnBlock.Location = New Point(315, 5)
        PnlForBtnBlock.Margin = New Padding(3, 5, 6, 5)
        PnlForBtnBlock.Name = "PnlForBtnBlock"
        PnlForBtnBlock.Size = New Size(149, 32)
        PnlForBtnBlock.TabIndex = 3
        ' 
        ' BtnExtend
        ' 
        BtnExtend.BackColor = Color.FromArgb(CByte(229), CByte(65), CByte(63))
        BtnExtend.Dock = DockStyle.Fill
        BtnExtend.FlatAppearance.BorderSize = 0
        BtnExtend.FlatStyle = FlatStyle.Flat
        BtnExtend.Font = New Font("Arial Black", 10F)
        BtnExtend.ForeColor = Color.White
        BtnExtend.Location = New Point(0, 0)
        BtnExtend.Margin = New Padding(3, 3, 5, 3)
        BtnExtend.Name = "BtnExtend"
        BtnExtend.Size = New Size(149, 32)
        BtnExtend.TabIndex = 2
        BtnExtend.Text = "Extention"
        BtnExtend.UseVisualStyleBackColor = False
        ' 
        ' PnlForBtnReports
        ' 
        PnlForBtnReports.Controls.Add(BtnRequest)
        PnlForBtnReports.Dock = DockStyle.Fill
        PnlForBtnReports.Location = New Point(160, 5)
        PnlForBtnReports.Margin = New Padding(4, 5, 5, 5)
        PnlForBtnReports.Name = "PnlForBtnReports"
        PnlForBtnReports.Size = New Size(147, 32)
        PnlForBtnReports.TabIndex = 2
        ' 
        ' BtnRequest
        ' 
        BtnRequest.BackColor = Color.FromArgb(CByte(236), CByte(137), CByte(54))
        BtnRequest.Dock = DockStyle.Fill
        BtnRequest.FlatAppearance.BorderSize = 0
        BtnRequest.FlatStyle = FlatStyle.Flat
        BtnRequest.Font = New Font("Arial Black", 10F)
        BtnRequest.ForeColor = Color.White
        BtnRequest.Location = New Point(0, 0)
        BtnRequest.Margin = New Padding(4, 3, 5, 3)
        BtnRequest.Name = "BtnRequest"
        BtnRequest.Size = New Size(147, 32)
        BtnRequest.TabIndex = 2
        BtnRequest.Text = "Requests"
        BtnRequest.UseVisualStyleBackColor = False
        ' 
        ' PnlForBtnBorrowing
        ' 
        PnlForBtnBorrowing.Controls.Add(BtnLog)
        PnlForBtnBorrowing.Dock = DockStyle.Fill
        PnlForBtnBorrowing.Location = New Point(13, 5)
        PnlForBtnBorrowing.Margin = New Padding(13, 5, 4, 5)
        PnlForBtnBorrowing.Name = "PnlForBtnBorrowing"
        PnlForBtnBorrowing.Size = New Size(139, 32)
        PnlForBtnBorrowing.TabIndex = 1
        ' 
        ' BtnLog
        ' 
        BtnLog.BackColor = Color.FromArgb(CByte(44), CByte(80), CByte(126))
        BtnLog.Dock = DockStyle.Fill
        BtnLog.FlatAppearance.BorderSize = 0
        BtnLog.FlatStyle = FlatStyle.Flat
        BtnLog.Font = New Font("Arial Black", 10F)
        BtnLog.ForeColor = Color.White
        BtnLog.Location = New Point(0, 0)
        BtnLog.Name = "BtnLog"
        BtnLog.Size = New Size(139, 32)
        BtnLog.TabIndex = 1
        BtnLog.Text = "Borrowing Logs"
        BtnLog.UseVisualStyleBackColor = False
        ' 
        ' CFExtend
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(967, 570)
        Controls.Add(TBLFill)
        Name = "CFExtend"
        StartPosition = FormStartPosition.CenterScreen
        Text = "FormDeleteBlock"
        TBLFill.ResumeLayout(False)
        PnlBelow.ResumeLayout(False)
        PnlBelow.PerformLayout()
        Panel8.ResumeLayout(False)
        Panel7.ResumeLayout(False)
        TBLPRequests.ResumeLayout(False)
        TBLTopOfData.ResumeLayout(False)
        PnlForData.ResumeLayout(False)
        PnlForData.PerformLayout()
        PnlForDataGridView.ResumeLayout(False)
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel2.ResumeLayout(False)
        Panel14.ResumeLayout(False)
        Panel9.ResumeLayout(False)
        PnlDateEnd.ResumeLayout(False)
        TableLayoutPanel21.ResumeLayout(False)
        Panel12.ResumeLayout(False)
        Panel13.ResumeLayout(False)
        PnlViewStatistics.ResumeLayout(False)
        Panel11.ResumeLayout(False)
        PnlDateStart.ResumeLayout(False)
        TableLayoutPanel3.ResumeLayout(False)
        Panel15.ResumeLayout(False)
        Panel16.ResumeLayout(False)
        Panel5.ResumeLayout(False)
        TableLayoutPanel5.ResumeLayout(False)
        PnlForBtnBlock.ResumeLayout(False)
        PnlForBtnReports.ResumeLayout(False)
        PnlForBtnBorrowing.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents TBLFill As TableLayoutPanel
    Friend WithEvents PnlBelow As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents LblDateTimeRequests As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents LblDateTime As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TBLPRequests As TableLayoutPanel
    Friend WithEvents Panel10 As Panel
    Friend WithEvents TBLTopOfData As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents PnlForData As Panel
    Friend WithEvents PnlForDataGridView As Panel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Panel14 As Panel
    Friend WithEvents ComboSearchDate As ComboBox
    Friend WithEvents Panel9 As Panel
    Friend WithEvents PnlDateEnd As Panel
    Friend WithEvents TableLayoutPanel21 As TableLayoutPanel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel13 As Panel
    Friend WithEvents DateTimePickerEnd As DateTimePicker
    Friend WithEvents PnlViewStatistics As Panel
    Friend WithEvents BtnViewStats As Button
    Friend WithEvents Panel11 As Panel
    Friend WithEvents PnlDateStart As Panel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Panel15 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel16 As Panel
    Friend WithEvents DateTimePickerStart As DateTimePicker
    Friend WithEvents Panel17 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents PnlForBtnBlock As Panel
    Friend WithEvents BtnExtend As Button
    Friend WithEvents PnlForBtnReports As Panel
    Friend WithEvents BtnRequest As Button
    Friend WithEvents PnlForBtnBorrowing As Panel
    Friend WithEvents BtnLog As Button
    Friend WithEvents TimerDateTime As Timer
End Class
