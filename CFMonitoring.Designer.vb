<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CFMonitoring
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

    Public Sub New()
        InitializeComponent()
        ' WARNING: _dashboard is not set, so avoid using it unless assigned later
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        PnlFill = New Panel()
        PnlForBtns = New Panel()
        TLPBtnsMonitoring = New TableLayoutPanel()
        PnlForBtnBlock = New Panel()
        BtnBlocklist = New Button()
        PnlForBtnReports = New Panel()
        BtnReports = New Button()
        PnlForBtnBorrowing = New Panel()
        BtnBorrowing = New Button()
        PnlFill.SuspendLayout()
        PnlForBtns.SuspendLayout()
        TLPBtnsMonitoring.SuspendLayout()
        PnlForBtnBlock.SuspendLayout()
        PnlForBtnReports.SuspendLayout()
        PnlForBtnBorrowing.SuspendLayout()
        SuspendLayout()
        ' 
        ' PnlFill
        ' 
        PnlFill.BackColor = SystemColors.Control
        PnlFill.Controls.Add(PnlForBtns)
        PnlFill.Dock = DockStyle.Fill
        PnlFill.Location = New Point(0, 0)
        PnlFill.Name = "PnlFill"
        PnlFill.Size = New Size(983, 609)
        PnlFill.TabIndex = 0
        ' 
        ' PnlForBtns
        ' 
        PnlForBtns.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        PnlForBtns.Controls.Add(TLPBtnsMonitoring)
        PnlForBtns.Location = New Point(318, 95)
        PnlForBtns.Name = "PnlForBtns"
        PnlForBtns.Size = New Size(305, 312)
        PnlForBtns.TabIndex = 0
        ' 
        ' TLPBtnsMonitoring
        ' 
        TLPBtnsMonitoring.BackColor = Color.White
        TLPBtnsMonitoring.ColumnCount = 1
        TLPBtnsMonitoring.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TLPBtnsMonitoring.Controls.Add(PnlForBtnBlock, 0, 2)
        TLPBtnsMonitoring.Controls.Add(PnlForBtnReports, 0, 1)
        TLPBtnsMonitoring.Controls.Add(PnlForBtnBorrowing, 0, 0)
        TLPBtnsMonitoring.Dock = DockStyle.Fill
        TLPBtnsMonitoring.Location = New Point(0, 0)
        TLPBtnsMonitoring.Name = "TLPBtnsMonitoring"
        TLPBtnsMonitoring.RowCount = 3
        TLPBtnsMonitoring.RowStyles.Add(New RowStyle(SizeType.Percent, 33.3333321F))
        TLPBtnsMonitoring.RowStyles.Add(New RowStyle(SizeType.Percent, 33.3333321F))
        TLPBtnsMonitoring.RowStyles.Add(New RowStyle(SizeType.Percent, 33.3333321F))
        TLPBtnsMonitoring.Size = New Size(305, 312)
        TLPBtnsMonitoring.TabIndex = 0
        ' 
        ' PnlForBtnBlock
        ' 
        PnlForBtnBlock.Controls.Add(BtnBlocklist)
        PnlForBtnBlock.Dock = DockStyle.Fill
        PnlForBtnBlock.Location = New Point(20, 228)
        PnlForBtnBlock.Margin = New Padding(20)
        PnlForBtnBlock.Name = "PnlForBtnBlock"
        PnlForBtnBlock.Size = New Size(265, 64)
        PnlForBtnBlock.TabIndex = 2
        ' 
        ' BtnBlocklist
        ' 
        BtnBlocklist.BackColor = Color.FromArgb(CByte(229), CByte(65), CByte(63))
        BtnBlocklist.Dock = DockStyle.Fill
        BtnBlocklist.FlatAppearance.BorderSize = 0
        BtnBlocklist.FlatStyle = FlatStyle.Flat
        BtnBlocklist.Font = New Font("Arial Black", 10F)
        BtnBlocklist.ForeColor = Color.White
        BtnBlocklist.Location = New Point(0, 0)
        BtnBlocklist.Name = "BtnBlocklist"
        BtnBlocklist.Size = New Size(265, 64)
        BtnBlocklist.TabIndex = 2
        BtnBlocklist.Text = "Blocklist"
        BtnBlocklist.UseVisualStyleBackColor = False
        ' 
        ' PnlForBtnReports
        ' 
        PnlForBtnReports.Controls.Add(BtnReports)
        PnlForBtnReports.Dock = DockStyle.Fill
        PnlForBtnReports.Location = New Point(20, 124)
        PnlForBtnReports.Margin = New Padding(20)
        PnlForBtnReports.Name = "PnlForBtnReports"
        PnlForBtnReports.Size = New Size(265, 64)
        PnlForBtnReports.TabIndex = 1
        ' 
        ' BtnReports
        ' 
        BtnReports.BackColor = Color.FromArgb(CByte(236), CByte(137), CByte(54))
        BtnReports.Dock = DockStyle.Fill
        BtnReports.FlatAppearance.BorderSize = 0
        BtnReports.FlatStyle = FlatStyle.Flat
        BtnReports.Font = New Font("Arial Black", 10F)
        BtnReports.ForeColor = Color.White
        BtnReports.Location = New Point(0, 0)
        BtnReports.Name = "BtnReports"
        BtnReports.Size = New Size(265, 64)
        BtnReports.TabIndex = 2
        BtnReports.Text = "Reports"
        BtnReports.UseVisualStyleBackColor = False
        ' 
        ' PnlForBtnBorrowing
        ' 
        PnlForBtnBorrowing.Controls.Add(BtnBorrowing)
        PnlForBtnBorrowing.Dock = DockStyle.Fill
        PnlForBtnBorrowing.Location = New Point(20, 20)
        PnlForBtnBorrowing.Margin = New Padding(20)
        PnlForBtnBorrowing.Name = "PnlForBtnBorrowing"
        PnlForBtnBorrowing.Size = New Size(265, 64)
        PnlForBtnBorrowing.TabIndex = 0
        ' 
        ' BtnBorrowing
        ' 
        BtnBorrowing.BackColor = Color.FromArgb(CByte(44), CByte(80), CByte(126))
        BtnBorrowing.Dock = DockStyle.Fill
        BtnBorrowing.FlatAppearance.BorderSize = 0
        BtnBorrowing.FlatStyle = FlatStyle.Flat
        BtnBorrowing.Font = New Font("Arial Black", 10F)
        BtnBorrowing.ForeColor = Color.White
        BtnBorrowing.Location = New Point(0, 0)
        BtnBorrowing.Name = "BtnBorrowing"
        BtnBorrowing.Size = New Size(265, 64)
        BtnBorrowing.TabIndex = 1
        BtnBorrowing.Text = "Borrowing Logs"
        BtnBorrowing.UseVisualStyleBackColor = False
        ' 
        ' CFMonitoring
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(983, 609)
        Controls.Add(PnlFill)
        FormBorderStyle = FormBorderStyle.None
        Name = "CFMonitoring"
        StartPosition = FormStartPosition.CenterScreen
        Text = "FormAddMeeting"
        PnlFill.ResumeLayout(False)
        PnlForBtns.ResumeLayout(False)
        TLPBtnsMonitoring.ResumeLayout(False)
        PnlForBtnBlock.ResumeLayout(False)
        PnlForBtnReports.ResumeLayout(False)
        PnlForBtnBorrowing.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Friend WithEvents ComboStatus As ComboBox
    Friend WithEvents PnlFill As Panel
    Friend WithEvents PnlForBtns As Panel
    Friend WithEvents TLPBtnsMonitoring As TableLayoutPanel
    Friend WithEvents PnlForBtnBorrowing As Panel
    Friend WithEvents PnlForBtnBlock As Panel
    Friend WithEvents PnlForBtnReports As Panel
    Friend WithEvents BtnBorrowing As Button
    Friend WithEvents BtnBlocklist As Button
    Friend WithEvents BtnReports As Button
End Class
