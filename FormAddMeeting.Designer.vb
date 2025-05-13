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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        PnlFill = New Panel()
        SuspendLayout()
        ' 
        ' PnlFill
        ' 
        PnlFill.Dock = DockStyle.Fill
        PnlFill.Location = New Point(0, 0)
        PnlFill.Name = "PnlFill"
        PnlFill.Size = New Size(489, 510)
        PnlFill.TabIndex = 0
        ' 
        ' CFMonitoring
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(489, 510)
        Controls.Add(PnlFill)
        FormBorderStyle = FormBorderStyle.None
        Name = "CFMonitoring"
        StartPosition = FormStartPosition.CenterScreen
        Text = "FormAddMeeting"
        ResumeLayout(False)
    End Sub
    Friend WithEvents ComboStatus As ComboBox
    Friend WithEvents PnlFill As Panel
End Class
