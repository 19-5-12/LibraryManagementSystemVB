<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CFBorrowingManagement
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
        TableLayoutPanel1 = New TableLayoutPanel()
        TableLayoutPanel2 = New TableLayoutPanel()
        TableLayoutPanel3 = New TableLayoutPanel()
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
        TableLayoutPanel4 = New TableLayoutPanel()
        Panel15 = New Panel()
        Label3 = New Label()
        Panel16 = New Panel()
        DateTimePickerStart = New DateTimePicker()
        Panel17 = New Panel()
        Panel5 = New Panel()
        ParentForm = New Panel()
        PnlFill.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        TableLayoutPanel3.SuspendLayout()
        Panel14.SuspendLayout()
        Panel9.SuspendLayout()
        PnlDateEnd.SuspendLayout()
        TableLayoutPanel21.SuspendLayout()
        Panel12.SuspendLayout()
        Panel13.SuspendLayout()
        PnlViewStatistics.SuspendLayout()
        Panel11.SuspendLayout()
        PnlDateStart.SuspendLayout()
        TableLayoutPanel4.SuspendLayout()
        Panel15.SuspendLayout()
        Panel16.SuspendLayout()
        SuspendLayout()
        ' 
        ' PnlFill
        ' 
        PnlFill.BackColor = SystemColors.Control
        PnlFill.Controls.Add(TableLayoutPanel1)
        PnlFill.Dock = DockStyle.Fill
        PnlFill.Location = New Point(0, 0)
        PnlFill.Name = "PnlFill"
        PnlFill.Size = New Size(983, 609)
        PnlFill.TabIndex = 1
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 1
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Controls.Add(TableLayoutPanel2, 0, 0)
        TableLayoutPanel1.Controls.Add(ParentForm, 0, 1)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 2
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 556F))
        TableLayoutPanel1.Size = New Size(983, 609)
        TableLayoutPanel1.TabIndex = 1
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 2
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.78F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 49.22F))
        TableLayoutPanel2.Controls.Add(TableLayoutPanel3, 0, 0)
        TableLayoutPanel2.Controls.Add(Panel5, 1, 0)
        TableLayoutPanel2.Dock = DockStyle.Fill
        TableLayoutPanel2.Location = New Point(0, 0)
        TableLayoutPanel2.Margin = New Padding(0)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 1
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.Size = New Size(983, 53)
        TableLayoutPanel2.TabIndex = 1
        ' 
        ' TableLayoutPanel3
        ' 
        TableLayoutPanel3.ColumnCount = 5
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 3.19865322F))
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 23.4215889F))
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 28.7169037F))
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 22.81059F))
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 21.5885944F))
        TableLayoutPanel3.Controls.Add(Panel14, 2, 0)
        TableLayoutPanel3.Controls.Add(Panel9, 4, 0)
        TableLayoutPanel3.Controls.Add(PnlViewStatistics, 1, 0)
        TableLayoutPanel3.Controls.Add(Panel11, 3, 0)
        TableLayoutPanel3.Controls.Add(Panel17, 0, 0)
        TableLayoutPanel3.Dock = DockStyle.Fill
        TableLayoutPanel3.Location = New Point(0, 0)
        TableLayoutPanel3.Margin = New Padding(0)
        TableLayoutPanel3.Name = "TableLayoutPanel3"
        TableLayoutPanel3.RowCount = 1
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel3.Size = New Size(499, 53)
        TableLayoutPanel3.TabIndex = 3
        ' 
        ' Panel14
        ' 
        Panel14.Controls.Add(ComboSearchDate)
        Panel14.Dock = DockStyle.Fill
        Panel14.Location = New Point(138, 18)
        Panel14.Margin = New Padding(5, 18, 5, 5)
        Panel14.Name = "Panel14"
        Panel14.Size = New Size(133, 30)
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
        ComboSearchDate.Size = New Size(133, 25)
        ComboSearchDate.TabIndex = 1
        ' 
        ' Panel9
        ' 
        Panel9.Controls.Add(PnlDateEnd)
        Panel9.Dock = DockStyle.Fill
        Panel9.Location = New Point(393, 3)
        Panel9.Name = "Panel9"
        Panel9.Size = New Size(103, 47)
        Panel9.TabIndex = 7
        ' 
        ' PnlDateEnd
        ' 
        PnlDateEnd.Controls.Add(TableLayoutPanel21)
        PnlDateEnd.Dock = DockStyle.Fill
        PnlDateEnd.Location = New Point(0, 0)
        PnlDateEnd.Margin = New Padding(0)
        PnlDateEnd.Name = "PnlDateEnd"
        PnlDateEnd.Size = New Size(103, 47)
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
        TableLayoutPanel21.Size = New Size(103, 47)
        TableLayoutPanel21.TabIndex = 0
        ' 
        ' Panel12
        ' 
        Panel12.Controls.Add(Label5)
        Panel12.Dock = DockStyle.Fill
        Panel12.Location = New Point(0, 0)
        Panel12.Margin = New Padding(0)
        Panel12.Name = "Panel12"
        Panel12.Size = New Size(103, 20)
        Panel12.TabIndex = 0
        ' 
        ' Label5
        ' 
        Label5.Dock = DockStyle.Fill
        Label5.Font = New Font("Arial", 9F)
        Label5.Location = New Point(0, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(103, 20)
        Label5.TabIndex = 0
        Label5.Text = "Date End"
        Label5.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Panel13
        ' 
        Panel13.Controls.Add(DateTimePickerEnd)
        Panel13.Dock = DockStyle.Fill
        Panel13.Location = New Point(2, 20)
        Panel13.Margin = New Padding(2, 0, 0, 0)
        Panel13.Name = "Panel13"
        Panel13.Size = New Size(101, 27)
        Panel13.TabIndex = 1
        ' 
        ' DateTimePickerEnd
        ' 
        DateTimePickerEnd.Dock = DockStyle.Fill
        DateTimePickerEnd.Font = New Font("Arial", 9F)
        DateTimePickerEnd.Format = DateTimePickerFormat.Short
        DateTimePickerEnd.Location = New Point(0, 0)
        DateTimePickerEnd.Name = "DateTimePickerEnd"
        DateTimePickerEnd.Size = New Size(101, 21)
        DateTimePickerEnd.TabIndex = 0
        ' 
        ' PnlViewStatistics
        ' 
        PnlViewStatistics.Controls.Add(BtnViewStats)
        PnlViewStatistics.Dock = DockStyle.Fill
        PnlViewStatistics.Location = New Point(19, 15)
        PnlViewStatistics.Margin = New Padding(3, 15, 3, 5)
        PnlViewStatistics.Name = "PnlViewStatistics"
        PnlViewStatistics.Size = New Size(111, 33)
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
        BtnViewStats.Size = New Size(111, 33)
        BtnViewStats.TabIndex = 0
        BtnViewStats.Text = "Load List"
        BtnViewStats.UseVisualStyleBackColor = False
        ' 
        ' Panel11
        ' 
        Panel11.Controls.Add(PnlDateStart)
        Panel11.Dock = DockStyle.Fill
        Panel11.Location = New Point(281, 5)
        Panel11.Margin = New Padding(5)
        Panel11.Name = "Panel11"
        Panel11.Size = New Size(104, 43)
        Panel11.TabIndex = 3
        ' 
        ' PnlDateStart
        ' 
        PnlDateStart.Controls.Add(TableLayoutPanel4)
        PnlDateStart.Dock = DockStyle.Fill
        PnlDateStart.Location = New Point(0, 0)
        PnlDateStart.Margin = New Padding(0)
        PnlDateStart.Name = "PnlDateStart"
        PnlDateStart.Size = New Size(104, 43)
        PnlDateStart.TabIndex = 4
        ' 
        ' TableLayoutPanel4
        ' 
        TableLayoutPanel4.ColumnCount = 1
        TableLayoutPanel4.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel4.Controls.Add(Panel15, 0, 0)
        TableLayoutPanel4.Controls.Add(Panel16, 0, 1)
        TableLayoutPanel4.Dock = DockStyle.Fill
        TableLayoutPanel4.Location = New Point(0, 0)
        TableLayoutPanel4.Margin = New Padding(0)
        TableLayoutPanel4.Name = "TableLayoutPanel4"
        TableLayoutPanel4.RowCount = 2
        TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Percent, 43.2432442F))
        TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Percent, 56.7567558F))
        TableLayoutPanel4.Size = New Size(104, 43)
        TableLayoutPanel4.TabIndex = 0
        ' 
        ' Panel15
        ' 
        Panel15.Controls.Add(Label3)
        Panel15.Dock = DockStyle.Fill
        Panel15.Location = New Point(0, 0)
        Panel15.Margin = New Padding(0)
        Panel15.Name = "Panel15"
        Panel15.Size = New Size(104, 18)
        Panel15.TabIndex = 0
        ' 
        ' Label3
        ' 
        Label3.Dock = DockStyle.Fill
        Label3.Font = New Font("Arial", 9F)
        Label3.Location = New Point(0, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(104, 18)
        Label3.TabIndex = 0
        Label3.Text = "Date Start"
        Label3.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Panel16
        ' 
        Panel16.Controls.Add(DateTimePickerStart)
        Panel16.Dock = DockStyle.Fill
        Panel16.Location = New Point(0, 18)
        Panel16.Margin = New Padding(0, 0, 2, 0)
        Panel16.Name = "Panel16"
        Panel16.Size = New Size(102, 25)
        Panel16.TabIndex = 1
        ' 
        ' DateTimePickerStart
        ' 
        DateTimePickerStart.Dock = DockStyle.Fill
        DateTimePickerStart.Font = New Font("Arial", 9F)
        DateTimePickerStart.Format = DateTimePickerFormat.Short
        DateTimePickerStart.Location = New Point(0, 0)
        DateTimePickerStart.Name = "DateTimePickerStart"
        DateTimePickerStart.Size = New Size(102, 21)
        DateTimePickerStart.TabIndex = 0
        ' 
        ' Panel17
        ' 
        Panel17.Dock = DockStyle.Fill
        Panel17.Location = New Point(3, 3)
        Panel17.Name = "Panel17"
        Panel17.Size = New Size(10, 47)
        Panel17.TabIndex = 1
        ' 
        ' Panel5
        ' 
        Panel5.Dock = DockStyle.Fill
        Panel5.Location = New Point(502, 3)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(478, 47)
        Panel5.TabIndex = 2
        ' 
        ' ParentForm
        ' 
        ParentForm.Dock = DockStyle.Fill
        ParentForm.Location = New Point(3, 56)
        ParentForm.Name = "ParentForm"
        ParentForm.Size = New Size(977, 550)
        ParentForm.TabIndex = 0
        ' 
        ' CFBorrowingManagement
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(983, 609)
        Controls.Add(PnlFill)
        FormBorderStyle = FormBorderStyle.None
        Name = "CFBorrowingManagement"
        Text = "CFBorrowingManagement"
        PnlFill.ResumeLayout(False)
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel2.ResumeLayout(False)
        TableLayoutPanel3.ResumeLayout(False)
        Panel14.ResumeLayout(False)
        Panel9.ResumeLayout(False)
        PnlDateEnd.ResumeLayout(False)
        TableLayoutPanel21.ResumeLayout(False)
        Panel12.ResumeLayout(False)
        Panel13.ResumeLayout(False)
        PnlViewStatistics.ResumeLayout(False)
        Panel11.ResumeLayout(False)
        PnlDateStart.ResumeLayout(False)
        TableLayoutPanel4.ResumeLayout(False)
        Panel15.ResumeLayout(False)
        Panel16.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents PnlFill As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents ParentForm As Panel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
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
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents Panel15 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel16 As Panel
    Friend WithEvents DateTimePickerStart As DateTimePicker
    Friend WithEvents Panel17 As Panel
    Friend WithEvents Panel5 As Panel
End Class
