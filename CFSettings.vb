Public Class CFSettings
    Private Sub CFSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load, MyBase.Load
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
        ComboBox3.SelectedIndex = 0

    End Sub

    Private Sub PnlAppearanceSettings_Paint(sender As Object, e As PaintEventArgs) Handles PnlAppearanceSettings.Paint
        RoundPanel(CType(sender, Panel), e) ' 👈 Make it rounded
    End Sub
End Class