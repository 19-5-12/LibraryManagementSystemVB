﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CFMeetingRooms
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
        Panel1 = New Panel()
        TableLayoutPanel1 = New TableLayoutPanel()
        TableLayoutPanel2 = New TableLayoutPanel()
        Panel14 = New Panel()
        ComboSearchDate = New ComboBox()
        Panel5 = New Panel()
        PnlDateEnd = New Panel()
        TableLayoutPanel21 = New TableLayoutPanel()
        Panel12 = New Panel()
        Label5 = New Label()
        Panel13 = New Panel()
        DateTimePickerEnd = New DateTimePicker()
        PnlViewStatistics = New Panel()
        BtnViewStats = New Button()
        Panel6 = New Panel()
        PnlDateStart = New Panel()
        TableLayoutPanel3 = New TableLayoutPanel()
        Panel9 = New Panel()
        Label3 = New Label()
        Panel11 = New Panel()
        DateTimePickerStart = New DateTimePicker()
        Panel3 = New Panel()
        PnlBelow = New Panel()
        Panel8 = New Panel()
        LblDateTimeMeeting = New Label()
        Label4 = New Label()
        Panel7 = New Panel()
        LblDateTime = New Label()
        Label2 = New Label()
        TBLPMeeting = New TableLayoutPanel()
        TBLTopOfData = New TableLayoutPanel()
        Label1 = New Label()
        PnlForData = New Panel()
        PnlForDataGridView = New Panel()
        DataGridView1 = New DataGridView()
        Panel10 = New Panel()
        TimerDateTime = New Timer(components)
        TBLFill.SuspendLayout()
        Panel1.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        Panel14.SuspendLayout()
        Panel5.SuspendLayout()
        PnlDateEnd.SuspendLayout()
        TableLayoutPanel21.SuspendLayout()
        Panel12.SuspendLayout()
        Panel13.SuspendLayout()
        PnlViewStatistics.SuspendLayout()
        Panel6.SuspendLayout()
        PnlDateStart.SuspendLayout()
        TableLayoutPanel3.SuspendLayout()
        Panel9.SuspendLayout()
        Panel11.SuspendLayout()
        PnlBelow.SuspendLayout()
        Panel8.SuspendLayout()
        Panel7.SuspendLayout()
        TBLPMeeting.SuspendLayout()
        TBLTopOfData.SuspendLayout()
        PnlForData.SuspendLayout()
        PnlForDataGridView.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TBLFill
        ' 
        TBLFill.ColumnCount = 1
        TBLFill.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TBLFill.Controls.Add(Panel1, 0, 0)
        TBLFill.Controls.Add(PnlBelow, 0, 1)
        TBLFill.Dock = DockStyle.Fill
        TBLFill.Location = New Point(0, 0)
        TBLFill.Margin = New Padding(0)
        TBLFill.Name = "TBLFill"
        TBLFill.RowCount = 2
        TBLFill.RowStyles.Add(New RowStyle(SizeType.Percent, 8.42F))
        TBLFill.RowStyles.Add(New RowStyle(SizeType.Percent, 91.58F))
        TBLFill.Size = New Size(967, 570)
        TBLFill.TabIndex = 1
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(TableLayoutPanel1)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Margin = New Padding(0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(967, 47)
        Panel1.TabIndex = 5
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.7755928F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 49.2244072F))
        TableLayoutPanel1.Controls.Add(TableLayoutPanel2, 0, 0)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Margin = New Padding(0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Size = New Size(967, 47)
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
        TableLayoutPanel2.Controls.Add(Panel5, 4, 0)
        TableLayoutPanel2.Controls.Add(PnlViewStatistics, 1, 0)
        TableLayoutPanel2.Controls.Add(Panel6, 3, 0)
        TableLayoutPanel2.Controls.Add(Panel3, 0, 0)
        TableLayoutPanel2.Dock = DockStyle.Fill
        TableLayoutPanel2.Location = New Point(0, 0)
        TableLayoutPanel2.Margin = New Padding(0)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 1
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.Size = New Size(491, 47)
        TableLayoutPanel2.TabIndex = 0
        ' 
        ' Panel14
        ' 
        Panel14.Controls.Add(ComboSearchDate)
        Panel14.Dock = DockStyle.Fill
        Panel14.Location = New Point(135, 18)
        Panel14.Margin = New Padding(5, 18, 5, 5)
        Panel14.Name = "Panel14"
        Panel14.Size = New Size(131, 24)
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
        ' Panel5
        ' 
        Panel5.Controls.Add(PnlDateEnd)
        Panel5.Dock = DockStyle.Fill
        Panel5.Location = New Point(386, 3)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(102, 41)
        Panel5.TabIndex = 7
        ' 
        ' PnlDateEnd
        ' 
        PnlDateEnd.Controls.Add(TableLayoutPanel21)
        PnlDateEnd.Dock = DockStyle.Fill
        PnlDateEnd.Location = New Point(0, 0)
        PnlDateEnd.Margin = New Padding(0)
        PnlDateEnd.Name = "PnlDateEnd"
        PnlDateEnd.Size = New Size(102, 41)
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
        TableLayoutPanel21.Size = New Size(102, 41)
        TableLayoutPanel21.TabIndex = 0
        ' 
        ' Panel12
        ' 
        Panel12.Controls.Add(Label5)
        Panel12.Dock = DockStyle.Fill
        Panel12.Location = New Point(0, 0)
        Panel12.Margin = New Padding(0)
        Panel12.Name = "Panel12"
        Panel12.Size = New Size(102, 17)
        Panel12.TabIndex = 0
        ' 
        ' Label5
        ' 
        Label5.Dock = DockStyle.Fill
        Label5.Font = New Font("Arial", 9F)
        Label5.Location = New Point(0, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(102, 17)
        Label5.TabIndex = 0
        Label5.Text = "Date End"
        Label5.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Panel13
        ' 
        Panel13.Controls.Add(DateTimePickerEnd)
        Panel13.Dock = DockStyle.Fill
        Panel13.Location = New Point(2, 17)
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
        PnlViewStatistics.Size = New Size(109, 27)
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
        BtnViewStats.Size = New Size(109, 27)
        BtnViewStats.TabIndex = 0
        BtnViewStats.Text = "Load List"
        BtnViewStats.UseVisualStyleBackColor = False
        ' 
        ' Panel6
        ' 
        Panel6.Controls.Add(PnlDateStart)
        Panel6.Dock = DockStyle.Fill
        Panel6.Location = New Point(276, 5)
        Panel6.Margin = New Padding(5)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(102, 37)
        Panel6.TabIndex = 3
        ' 
        ' PnlDateStart
        ' 
        PnlDateStart.Controls.Add(TableLayoutPanel3)
        PnlDateStart.Dock = DockStyle.Fill
        PnlDateStart.Location = New Point(0, 0)
        PnlDateStart.Margin = New Padding(0)
        PnlDateStart.Name = "PnlDateStart"
        PnlDateStart.Size = New Size(102, 37)
        PnlDateStart.TabIndex = 4
        ' 
        ' TableLayoutPanel3
        ' 
        TableLayoutPanel3.ColumnCount = 1
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel3.Controls.Add(Panel9, 0, 0)
        TableLayoutPanel3.Controls.Add(Panel11, 0, 1)
        TableLayoutPanel3.Dock = DockStyle.Fill
        TableLayoutPanel3.Location = New Point(0, 0)
        TableLayoutPanel3.Margin = New Padding(0)
        TableLayoutPanel3.Name = "TableLayoutPanel3"
        TableLayoutPanel3.RowCount = 2
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 43.2432442F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 56.7567558F))
        TableLayoutPanel3.Size = New Size(102, 37)
        TableLayoutPanel3.TabIndex = 0
        ' 
        ' Panel9
        ' 
        Panel9.Controls.Add(Label3)
        Panel9.Dock = DockStyle.Fill
        Panel9.Location = New Point(0, 0)
        Panel9.Margin = New Padding(0)
        Panel9.Name = "Panel9"
        Panel9.Size = New Size(102, 16)
        Panel9.TabIndex = 0
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
        ' Panel11
        ' 
        Panel11.Controls.Add(DateTimePickerStart)
        Panel11.Dock = DockStyle.Fill
        Panel11.Location = New Point(0, 16)
        Panel11.Margin = New Padding(0, 0, 2, 0)
        Panel11.Name = "Panel11"
        Panel11.Size = New Size(100, 21)
        Panel11.TabIndex = 1
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
        ' Panel3
        ' 
        Panel3.Dock = DockStyle.Fill
        Panel3.Location = New Point(3, 3)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(9, 41)
        Panel3.TabIndex = 1
        ' 
        ' PnlBelow
        ' 
        PnlBelow.Controls.Add(Panel8)
        PnlBelow.Controls.Add(Panel7)
        PnlBelow.Controls.Add(TBLPMeeting)
        PnlBelow.Dock = DockStyle.Fill
        PnlBelow.Location = New Point(0, 47)
        PnlBelow.Margin = New Padding(0)
        PnlBelow.Name = "PnlBelow"
        PnlBelow.Size = New Size(967, 523)
        PnlBelow.TabIndex = 3
        ' 
        ' Panel8
        ' 
        Panel8.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Panel8.Controls.Add(LblDateTimeMeeting)
        Panel8.Controls.Add(Label4)
        Panel8.Location = New Point(227, 500)
        Panel8.Margin = New Padding(0)
        Panel8.Name = "Panel8"
        Panel8.Size = New Size(556, 23)
        Panel8.TabIndex = 2
        ' 
        ' LblDateTimeMeeting
        ' 
        LblDateTimeMeeting.Font = New Font("Arial", 8F)
        LblDateTimeMeeting.ForeColor = Color.Gray
        LblDateTimeMeeting.Location = New Point(369, 0)
        LblDateTimeMeeting.Name = "LblDateTimeMeeting"
        LblDateTimeMeeting.Size = New Size(184, 23)
        LblDateTimeMeeting.TabIndex = 3
        LblDateTimeMeeting.Text = "time"
        LblDateTimeMeeting.TextAlign = ContentAlignment.MiddleLeft
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
        Panel7.Location = New Point(227, 1568)
        Panel7.Margin = New Padding(0)
        Panel7.Name = "Panel7"
        Panel7.Size = New Size(2857, 23)
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
        ' TBLPMeeting
        ' 
        TBLPMeeting.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        TBLPMeeting.AutoSize = True
        TBLPMeeting.BackColor = Color.White
        TBLPMeeting.ColumnCount = 1
        TBLPMeeting.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TBLPMeeting.Controls.Add(TBLTopOfData, 0, 0)
        TBLPMeeting.Controls.Add(PnlForData, 0, 2)
        TBLPMeeting.Controls.Add(Panel10, 0, 1)
        TBLPMeeting.Location = New Point(19, 23)
        TBLPMeeting.Name = "TBLPMeeting"
        TBLPMeeting.RowCount = 3
        TBLPMeeting.RowStyles.Add(New RowStyle(SizeType.Percent, 10F))
        TBLPMeeting.RowStyles.Add(New RowStyle(SizeType.Absolute, 1F))
        TBLPMeeting.RowStyles.Add(New RowStyle(SizeType.Percent, 90F))
        TBLPMeeting.Size = New Size(931, 436)
        TBLPMeeting.TabIndex = 0
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
        Label1.Text = "List of Meeting Rooms"
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
        PnlForDataGridView.Size = New Size(881, 353)
        PnlForDataGridView.TabIndex = 0
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowDrop = True
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.AllowUserToResizeColumns = False
        DataGridView1.AllowUserToResizeRows = False
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
        DataGridView1.EditMode = DataGridViewEditMode.EditOnEnter
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
        DataGridView1.Size = New Size(881, 353)
        DataGridView1.TabIndex = 1
        ' 
        ' Panel10
        ' 
        Panel10.BackColor = SystemColors.Control
        Panel10.Dock = DockStyle.Fill
        Panel10.Location = New Point(3, 46)
        Panel10.Name = "Panel10"
        Panel10.Size = New Size(925, 1)
        Panel10.TabIndex = 2
        ' 
        ' CFMeetingRooms
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(967, 570)
        Controls.Add(TBLFill)
        Name = "CFMeetingRooms"
        Text = "CFMeetingRooms"
        TBLFill.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel2.ResumeLayout(False)
        Panel14.ResumeLayout(False)
        Panel5.ResumeLayout(False)
        PnlDateEnd.ResumeLayout(False)
        TableLayoutPanel21.ResumeLayout(False)
        Panel12.ResumeLayout(False)
        Panel13.ResumeLayout(False)
        PnlViewStatistics.ResumeLayout(False)
        Panel6.ResumeLayout(False)
        PnlDateStart.ResumeLayout(False)
        TableLayoutPanel3.ResumeLayout(False)
        Panel9.ResumeLayout(False)
        Panel11.ResumeLayout(False)
        PnlBelow.ResumeLayout(False)
        PnlBelow.PerformLayout()
        Panel8.ResumeLayout(False)
        Panel7.ResumeLayout(False)
        TBLPMeeting.ResumeLayout(False)
        TBLTopOfData.ResumeLayout(False)
        PnlForData.ResumeLayout(False)
        PnlForData.PerformLayout()
        PnlForDataGridView.ResumeLayout(False)
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents TBLFill As TableLayoutPanel
    Friend WithEvents PnlBelow As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents LblDateTimeMeeting As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents LblDateTime As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TBLPMeeting As TableLayoutPanel
    Friend WithEvents TBLTopOfData As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents PnlForData As Panel
    Friend WithEvents PnlForDataGridView As Panel
    Friend WithEvents TimerDateTime As Timer
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Panel14 As Panel
    Friend WithEvents ComboSearchDate As ComboBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents PnlDateEnd As Panel
    Friend WithEvents TableLayoutPanel21 As TableLayoutPanel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel13 As Panel
    Friend WithEvents DateTimePickerEnd As DateTimePicker
    Friend WithEvents PnlViewStatistics As Panel
    Friend WithEvents BtnViewStats As Button
    Friend WithEvents PnlDateStart As Panel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel11 As Panel
    Friend WithEvents DateTimePickerStart As DateTimePicker
End Class
