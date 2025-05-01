Public Class CFSettings
    Private Sub CFSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load, MyBase.Load
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
        ComboBox3.SelectedIndex = 0

    End Sub

    Private Sub TableLayoutPanel2_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel2.Paint
        StyleShadowPanel(CType(sender, Panel), e)
    End Sub
End Class