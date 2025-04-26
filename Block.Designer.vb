<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Block
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
        PnlFill = New Panel()
        TBLFill = New TableLayoutPanel()
        PnlBelow = New Panel()
        Panel8 = New Panel()
        LblDateTimeBlock = New Label()
        Label4 = New Label()
        Panel7 = New Panel()
        LblDateTime = New Label()
        Label2 = New Label()
        TBLPBlock = New TableLayoutPanel()
        TBLTopOfData = New TableLayoutPanel()
        LblViewAll = New Label()
        Label1 = New Label()
        PnlForData = New Panel()
        PnlForDataGridView = New Panel()
        DataGridView1 = New DataGridView()
        Panel1 = New Panel()
        TableLayoutPanel1 = New TableLayoutPanel()
        Panel5 = New Panel()
        TableLayoutPanel2 = New TableLayoutPanel()
        Panel9 = New Panel()
        BtnBack = New Button()
        Panel6 = New Panel()
        BtnDelete = New Button()
        Panel4 = New Panel()
        BtnModify = New Button()
        Panel2 = New Panel()
        BtnAdd = New Button()
        Panel3 = New Panel()
        TimerDateTime = New Timer(components)
        PnlFill.SuspendLayout()
        TBLFill.SuspendLayout()
        PnlBelow.SuspendLayout()
        Panel8.SuspendLayout()
        Panel7.SuspendLayout()
        TBLPBlock.SuspendLayout()
        TBLTopOfData.SuspendLayout()
        PnlForData.SuspendLayout()
        PnlForDataGridView.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        Panel9.SuspendLayout()
        Panel6.SuspendLayout()
        Panel4.SuspendLayout()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' PnlFill
        ' 
        PnlFill.Controls.Add(TBLFill)
        PnlFill.Dock = DockStyle.Fill
        PnlFill.Location = New Point(0, 0)
        PnlFill.Margin = New Padding(0)
        PnlFill.Name = "PnlFill"
        PnlFill.Size = New Size(967, 570)
        PnlFill.TabIndex = 2
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
        TBLFill.RowStyles.Add(New RowStyle(SizeType.Percent, 20F))
        TBLFill.RowStyles.Add(New RowStyle(SizeType.Percent, 80F))
        TBLFill.Size = New Size(967, 570)
        TBLFill.TabIndex = 0
        ' 
        ' PnlBelow
        ' 
        PnlBelow.Controls.Add(Panel8)
        PnlBelow.Controls.Add(Panel7)
        PnlBelow.Controls.Add(TBLPBlock)
        PnlBelow.Dock = DockStyle.Fill
        PnlBelow.Location = New Point(0, 114)
        PnlBelow.Margin = New Padding(0)
        PnlBelow.Name = "PnlBelow"
        PnlBelow.Size = New Size(967, 456)
        PnlBelow.TabIndex = 3
        ' 
        ' Panel8
        ' 
        Panel8.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Panel8.Controls.Add(LblDateTimeBlock)
        Panel8.Controls.Add(Label4)
        Panel8.Location = New Point(227, 433)
        Panel8.Margin = New Padding(0)
        Panel8.Name = "Panel8"
        Panel8.Size = New Size(556, 23)
        Panel8.TabIndex = 2
        ' 
        ' LblDateTimeBlock
        ' 
        LblDateTimeBlock.Font = New Font("Arial", 8F)
        LblDateTimeBlock.ForeColor = Color.Gray
        LblDateTimeBlock.Location = New Point(369, 0)
        LblDateTimeBlock.Name = "LblDateTimeBlock"
        LblDateTimeBlock.Size = New Size(184, 23)
        LblDateTimeBlock.TabIndex = 3
        LblDateTimeBlock.Text = "time"
        LblDateTimeBlock.TextAlign = ContentAlignment.MiddleLeft
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
        Panel7.Location = New Point(227, 1145)
        Panel7.Margin = New Padding(0)
        Panel7.Name = "Panel7"
        Panel7.Size = New Size(2090, 23)
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
        ' TBLPBlock
        ' 
        TBLPBlock.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        TBLPBlock.AutoSize = True
        TBLPBlock.BackColor = Color.White
        TBLPBlock.ColumnCount = 1
        TBLPBlock.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TBLPBlock.Controls.Add(TBLTopOfData, 0, 0)
        TBLPBlock.Controls.Add(PnlForData, 0, 1)
        TBLPBlock.Location = New Point(19, 23)
        TBLPBlock.Name = "TBLPBlock"
        TBLPBlock.RowCount = 2
        TBLPBlock.RowStyles.Add(New RowStyle(SizeType.Percent, 10F))
        TBLPBlock.RowStyles.Add(New RowStyle(SizeType.Percent, 90F))
        TBLPBlock.Size = New Size(931, 369)
        TBLPBlock.TabIndex = 0
        ' 
        ' TBLTopOfData
        ' 
        TBLTopOfData.BackColor = Color.White
        TBLTopOfData.ColumnCount = 2
        TBLTopOfData.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 80F))
        TBLTopOfData.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 20F))
        TBLTopOfData.Controls.Add(LblViewAll, 1, 0)
        TBLTopOfData.Controls.Add(Label1, 0, 0)
        TBLTopOfData.Dock = DockStyle.Fill
        TBLTopOfData.Location = New Point(0, 0)
        TBLTopOfData.Margin = New Padding(0)
        TBLTopOfData.Name = "TBLTopOfData"
        TBLTopOfData.RowCount = 1
        TBLTopOfData.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TBLTopOfData.Size = New Size(931, 36)
        TBLTopOfData.TabIndex = 0
        ' 
        ' LblViewAll
        ' 
        LblViewAll.Dock = DockStyle.Fill
        LblViewAll.Font = New Font("Arial", 10F)
        LblViewAll.ForeColor = Color.Blue
        LblViewAll.Location = New Point(747, 0)
        LblViewAll.Name = "LblViewAll"
        LblViewAll.Padding = New Padding(0, 0, 20, 0)
        LblViewAll.Size = New Size(181, 36)
        LblViewAll.TabIndex = 1
        LblViewAll.Text = "View All"
        LblViewAll.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' Label1
        ' 
        Label1.Dock = DockStyle.Fill
        Label1.Font = New Font("Arial", 10F, FontStyle.Bold)
        Label1.ForeColor = Color.DarkSlateGray
        Label1.Location = New Point(3, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(738, 36)
        Label1.TabIndex = 0
        Label1.Text = "List of Blocked Students"
        Label1.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' PnlForData
        ' 
        PnlForData.BackColor = Color.White
        PnlForData.Controls.Add(PnlForDataGridView)
        PnlForData.Dock = DockStyle.Fill
        PnlForData.Location = New Point(0, 36)
        PnlForData.Margin = New Padding(0)
        PnlForData.Name = "PnlForData"
        PnlForData.Size = New Size(931, 333)
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
        PnlForDataGridView.Size = New Size(881, 294)
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
        DataGridView1.MaximumSize = New Size(0, 300)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.ReadOnly = True
        DataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridView1.RowHeadersVisible = False
        DataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle3.ForeColor = Color.DarkSlateGray
        DataGridViewCellStyle3.SelectionForeColor = Color.DarkSlateGray
        DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle3
        DataGridView1.RowTemplate.Height = 40
        DataGridView1.RowTemplate.ReadOnly = True
        DataGridView1.RowTemplate.Resizable = DataGridViewTriState.False
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.Size = New Size(881, 294)
        DataGridView1.TabIndex = 0
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(TableLayoutPanel1)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Margin = New Padding(0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(967, 114)
        Panel1.TabIndex = 0
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Controls.Add(Panel5, 1, 0)
        TableLayoutPanel1.Controls.Add(TableLayoutPanel2, 0, 0)
        TableLayoutPanel1.Dock = DockStyle.Bottom
        TableLayoutPanel1.Location = New Point(0, 65)
        TableLayoutPanel1.Margin = New Padding(0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Size = New Size(967, 49)
        TableLayoutPanel1.TabIndex = 0
        ' 
        ' Panel5
        ' 
        Panel5.Dock = DockStyle.Fill
        Panel5.Location = New Point(486, 3)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(478, 43)
        Panel5.TabIndex = 2
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 5
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 4.16666651F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 23.958334F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 23.958334F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 23.958334F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 23.958334F))
        TableLayoutPanel2.Controls.Add(Panel9, 4, 0)
        TableLayoutPanel2.Controls.Add(Panel6, 3, 0)
        TableLayoutPanel2.Controls.Add(Panel4, 2, 0)
        TableLayoutPanel2.Controls.Add(Panel2, 1, 0)
        TableLayoutPanel2.Controls.Add(Panel3, 0, 0)
        TableLayoutPanel2.Dock = DockStyle.Fill
        TableLayoutPanel2.Location = New Point(0, 0)
        TableLayoutPanel2.Margin = New Padding(0)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 1
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.Size = New Size(483, 49)
        TableLayoutPanel2.TabIndex = 0
        ' 
        ' Panel9
        ' 
        Panel9.Controls.Add(BtnBack)
        Panel9.Dock = DockStyle.Fill
        Panel9.Location = New Point(370, 5)
        Panel9.Margin = New Padding(5)
        Panel9.Name = "Panel9"
        Panel9.Size = New Size(108, 39)
        Panel9.TabIndex = 4
        ' 
        ' BtnBack
        ' 
        BtnBack.BackColor = Color.FromArgb(CByte(112), CByte(128), CByte(148))
        BtnBack.Dock = DockStyle.Fill
        BtnBack.FlatStyle = FlatStyle.Flat
        BtnBack.Font = New Font("Arial", 11F, FontStyle.Bold)
        BtnBack.ForeColor = Color.White
        BtnBack.Location = New Point(0, 0)
        BtnBack.Margin = New Padding(0)
        BtnBack.Name = "BtnBack"
        BtnBack.Size = New Size(108, 39)
        BtnBack.TabIndex = 2
        BtnBack.Text = "🔙 Back"
        BtnBack.UseVisualStyleBackColor = False
        ' 
        ' Panel6
        ' 
        Panel6.Controls.Add(BtnDelete)
        Panel6.Dock = DockStyle.Fill
        Panel6.Location = New Point(255, 5)
        Panel6.Margin = New Padding(5)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(105, 39)
        Panel6.TabIndex = 3
        ' 
        ' BtnDelete
        ' 
        BtnDelete.BackColor = Color.FromArgb(CByte(229), CByte(65), CByte(63))
        BtnDelete.Dock = DockStyle.Fill
        BtnDelete.FlatStyle = FlatStyle.Flat
        BtnDelete.Font = New Font("Arial", 11F, FontStyle.Bold)
        BtnDelete.ForeColor = Color.White
        BtnDelete.Location = New Point(0, 0)
        BtnDelete.Margin = New Padding(0)
        BtnDelete.Name = "BtnDelete"
        BtnDelete.Size = New Size(105, 39)
        BtnDelete.TabIndex = 2
        BtnDelete.Text = "🗑️ Delete"
        BtnDelete.UseVisualStyleBackColor = False
        ' 
        ' Panel4
        ' 
        Panel4.Controls.Add(BtnModify)
        Panel4.Dock = DockStyle.Fill
        Panel4.Location = New Point(140, 5)
        Panel4.Margin = New Padding(5)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(105, 39)
        Panel4.TabIndex = 2
        ' 
        ' BtnModify
        ' 
        BtnModify.BackColor = Color.FromArgb(CByte(236), CByte(137), CByte(54))
        BtnModify.Dock = DockStyle.Fill
        BtnModify.FlatStyle = FlatStyle.Flat
        BtnModify.Font = New Font("Arial", 11F, FontStyle.Bold)
        BtnModify.ForeColor = Color.White
        BtnModify.Location = New Point(0, 0)
        BtnModify.Margin = New Padding(0)
        BtnModify.Name = "BtnModify"
        BtnModify.Size = New Size(105, 39)
        BtnModify.TabIndex = 2
        BtnModify.Text = "✏️ Modify"
        BtnModify.UseVisualStyleBackColor = False
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(BtnAdd)
        Panel2.Dock = DockStyle.Fill
        Panel2.Location = New Point(25, 5)
        Panel2.Margin = New Padding(5)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(105, 39)
        Panel2.TabIndex = 0
        ' 
        ' BtnAdd
        ' 
        BtnAdd.BackColor = Color.FromArgb(CByte(44), CByte(80), CByte(126))
        BtnAdd.Dock = DockStyle.Fill
        BtnAdd.FlatStyle = FlatStyle.Flat
        BtnAdd.Font = New Font("Arial", 11F, FontStyle.Bold)
        BtnAdd.ForeColor = Color.White
        BtnAdd.Location = New Point(0, 0)
        BtnAdd.Margin = New Padding(0)
        BtnAdd.Name = "BtnAdd"
        BtnAdd.Size = New Size(105, 39)
        BtnAdd.TabIndex = 1
        BtnAdd.Text = "➕ Add"
        BtnAdd.UseVisualStyleBackColor = False
        ' 
        ' Panel3
        ' 
        Panel3.Dock = DockStyle.Fill
        Panel3.Location = New Point(3, 3)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(14, 43)
        Panel3.TabIndex = 1
        ' 
        ' Block
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(967, 570)
        Controls.Add(PnlFill)
        Name = "Block"
        Text = "Block"
        PnlFill.ResumeLayout(False)
        TBLFill.ResumeLayout(False)
        PnlBelow.ResumeLayout(False)
        PnlBelow.PerformLayout()
        Panel8.ResumeLayout(False)
        Panel7.ResumeLayout(False)
        TBLPBlock.ResumeLayout(False)
        TBLTopOfData.ResumeLayout(False)
        PnlForData.ResumeLayout(False)
        PnlForData.PerformLayout()
        PnlForDataGridView.ResumeLayout(False)
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel2.ResumeLayout(False)
        Panel9.ResumeLayout(False)
        Panel6.ResumeLayout(False)
        Panel4.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents PnlFill As Panel
    Friend WithEvents TBLFill As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents BtnBack As Button
    Friend WithEvents Panel6 As Panel
    Friend WithEvents BtnDelete As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents BtnModify As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents BtnAdd As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents PnlBelow As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents LblDateTimeBlock As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents LblDateTime As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TBLPBlock As TableLayoutPanel
    Friend WithEvents TBLTopOfData As TableLayoutPanel
    Friend WithEvents LblViewAll As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PnlForData As Panel
    Friend WithEvents PnlForDataGridView As Panel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents TimerDateTime As Timer
End Class
