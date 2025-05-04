<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDeleteMeeting
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
        TLPFill = New TableLayoutPanel()
        PnlCancelAdd = New Panel()
        TLPCancelAdd = New TableLayoutPanel()
        PnlForBtnAdd = New Panel()
        Panel1 = New Panel()
        Panel6 = New Panel()
        BtnDelete = New Button()
        PnlForCancel = New Panel()
        PnlBtnCancel = New Panel()
        BtnCancel = New Button()
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
        TLPFill.SuspendLayout()
        PnlCancelAdd.SuspendLayout()
        TLPCancelAdd.SuspendLayout()
        PnlForBtnAdd.SuspendLayout()
        Panel1.SuspendLayout()
        Panel6.SuspendLayout()
        PnlForCancel.SuspendLayout()
        PnlBtnCancel.SuspendLayout()
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
        PnlFill.Controls.Add(TLPFill)
        PnlFill.Dock = DockStyle.Fill
        PnlFill.Location = New Point(0, 0)
        PnlFill.Name = "PnlFill"
        PnlFill.Size = New Size(483, 115)
        PnlFill.TabIndex = 2
        ' 
        ' TLPFill
        ' 
        TLPFill.ColumnCount = 1
        TLPFill.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TLPFill.Controls.Add(PnlCancelAdd, 0, 1)
        TLPFill.Controls.Add(PnlTopAddNewBook, 0, 0)
        TLPFill.Dock = DockStyle.Fill
        TLPFill.Location = New Point(0, 0)
        TLPFill.Name = "TLPFill"
        TLPFill.RowCount = 2
        TLPFill.RowStyles.Add(New RowStyle(SizeType.Percent, 62.608696F))
        TLPFill.RowStyles.Add(New RowStyle(SizeType.Percent, 37.391304F))
        TLPFill.Size = New Size(483, 115)
        TLPFill.TabIndex = 0
        ' 
        ' PnlCancelAdd
        ' 
        PnlCancelAdd.BackColor = Color.White
        PnlCancelAdd.Controls.Add(TLPCancelAdd)
        PnlCancelAdd.Dock = DockStyle.Fill
        PnlCancelAdd.Location = New Point(3, 75)
        PnlCancelAdd.Name = "PnlCancelAdd"
        PnlCancelAdd.Size = New Size(477, 37)
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
        TLPCancelAdd.Size = New Size(477, 37)
        TLPCancelAdd.TabIndex = 0
        ' 
        ' PnlForBtnAdd
        ' 
        PnlForBtnAdd.Controls.Add(Panel1)
        PnlForBtnAdd.Dock = DockStyle.Fill
        PnlForBtnAdd.Location = New Point(362, 3)
        PnlForBtnAdd.Name = "PnlForBtnAdd"
        PnlForBtnAdd.Size = New Size(112, 31)
        PnlForBtnAdd.TabIndex = 1
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(Panel6)
        Panel1.Dock = DockStyle.Left
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(109, 31)
        Panel1.TabIndex = 1
        ' 
        ' Panel6
        ' 
        Panel6.Controls.Add(BtnDelete)
        Panel6.Dock = DockStyle.Right
        Panel6.Location = New Point(0, 0)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(109, 31)
        Panel6.TabIndex = 0
        ' 
        ' BtnDelete
        ' 
        BtnDelete.BackColor = Color.FromArgb(CByte(46), CByte(80), CByte(127))
        BtnDelete.Dock = DockStyle.Fill
        BtnDelete.FlatAppearance.BorderSize = 0
        BtnDelete.FlatStyle = FlatStyle.Flat
        BtnDelete.Font = New Font("Arial", 10F)
        BtnDelete.ForeColor = Color.White
        BtnDelete.Location = New Point(0, 0)
        BtnDelete.Name = "BtnDelete"
        BtnDelete.Size = New Size(109, 31)
        BtnDelete.TabIndex = 0
        BtnDelete.Text = "Delete"
        BtnDelete.UseVisualStyleBackColor = False
        ' 
        ' PnlForCancel
        ' 
        PnlForCancel.Controls.Add(PnlBtnCancel)
        PnlForCancel.Dock = DockStyle.Fill
        PnlForCancel.Location = New Point(3, 3)
        PnlForCancel.Name = "PnlForCancel"
        PnlForCancel.Size = New Size(353, 31)
        PnlForCancel.TabIndex = 0
        ' 
        ' PnlBtnCancel
        ' 
        PnlBtnCancel.Controls.Add(BtnCancel)
        PnlBtnCancel.Dock = DockStyle.Right
        PnlBtnCancel.Location = New Point(258, 0)
        PnlBtnCancel.Name = "PnlBtnCancel"
        PnlBtnCancel.Size = New Size(95, 31)
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
        BtnCancel.Size = New Size(95, 31)
        BtnCancel.TabIndex = 0
        BtnCancel.Text = "Cancel"
        BtnCancel.UseVisualStyleBackColor = False
        ' 
        ' PnlTopAddNewBook
        ' 
        PnlTopAddNewBook.BackColor = Color.White
        PnlTopAddNewBook.Controls.Add(Panel20)
        PnlTopAddNewBook.Dock = DockStyle.Fill
        PnlTopAddNewBook.Location = New Point(3, 3)
        PnlTopAddNewBook.Margin = New Padding(3, 3, 3, 0)
        PnlTopAddNewBook.Name = "PnlTopAddNewBook"
        PnlTopAddNewBook.Size = New Size(477, 69)
        PnlTopAddNewBook.TabIndex = 2
        ' 
        ' Panel20
        ' 
        Panel20.Controls.Add(TableLayoutPanel6)
        Panel20.Dock = DockStyle.Fill
        Panel20.Location = New Point(0, 0)
        Panel20.Name = "Panel20"
        Panel20.Padding = New Padding(30, 0, 0, 0)
        Panel20.Size = New Size(477, 69)
        Panel20.TabIndex = 0
        ' 
        ' TableLayoutPanel6
        ' 
        TableLayoutPanel6.BackColor = SystemColors.Control
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
        TableLayoutPanel6.Size = New Size(447, 69)
        TableLayoutPanel6.TabIndex = 0
        ' 
        ' Panel24
        ' 
        Panel24.Controls.Add(PnlSelect)
        Panel24.Dock = DockStyle.Fill
        Panel24.Location = New Point(10, 34)
        Panel24.Margin = New Padding(10, 0, 50, 2)
        Panel24.Name = "Panel24"
        Panel24.Size = New Size(387, 33)
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
        PnlSelect.Size = New Size(387, 33)
        PnlSelect.TabIndex = 0
        ' 
        ' PnlBorderSelectID
        ' 
        PnlBorderSelectID.Controls.Add(Panel25)
        PnlBorderSelectID.Dock = DockStyle.Fill
        PnlBorderSelectID.Location = New Point(0, 0)
        PnlBorderSelectID.Margin = New Padding(0, 5, 0, 5)
        PnlBorderSelectID.Name = "PnlBorderSelectID"
        PnlBorderSelectID.Size = New Size(387, 33)
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
        Panel25.Size = New Size(387, 33)
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
        TxtSelectID.Text = "Enter"
        ' 
        ' Panel23
        ' 
        Panel23.Controls.Add(Label1)
        Panel23.Dock = DockStyle.Fill
        Panel23.Location = New Point(3, 3)
        Panel23.Name = "Panel23"
        Panel23.Size = New Size(441, 28)
        Panel23.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.BackColor = SystemColors.Control
        Label1.Dock = DockStyle.Fill
        Label1.Font = New Font("Arial", 12F, FontStyle.Bold)
        Label1.ForeColor = Color.DarkSlateGray
        Label1.Location = New Point(0, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(441, 28)
        Label1.TabIndex = 1
        Label1.Text = "Select a borrow ID to DELETE:"
        Label1.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' FormDeleteMeeting
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(483, 115)
        Controls.Add(PnlFill)
        FormBorderStyle = FormBorderStyle.None
        Name = "FormDeleteMeeting"
        StartPosition = FormStartPosition.CenterScreen
        Text = "FormDeleteMeeting"
        PnlFill.ResumeLayout(False)
        TLPFill.ResumeLayout(False)
        PnlCancelAdd.ResumeLayout(False)
        TLPCancelAdd.ResumeLayout(False)
        PnlForBtnAdd.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        Panel6.ResumeLayout(False)
        PnlForCancel.ResumeLayout(False)
        PnlBtnCancel.ResumeLayout(False)
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
    Friend WithEvents TLPFill As TableLayoutPanel
    Friend WithEvents PnlCancelAdd As Panel
    Friend WithEvents TLPCancelAdd As TableLayoutPanel
    Friend WithEvents PnlForBtnAdd As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents BtnDelete As Button
    Friend WithEvents PnlForCancel As Panel
    Friend WithEvents PnlBtnCancel As Panel
    Friend WithEvents BtnCancel As Button
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
End Class
