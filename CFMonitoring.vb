Imports System.Drawing.Drawing2D
Public Class CFMonitoring
    Private _dashboard As AdminDashboard

    Public Sub New(dashboard As AdminDashboard)
        InitializeComponent()
        _dashboard = dashboard
    End Sub

    Private Sub PnlForBtns_Paint(sender As Object, e As PaintEventArgs) Handles PnlForBtns.Paint

    End Sub

    Private Sub CFMonitoring_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim btnmonitor As Button() = {BtnBorrowing, BtnReports, BtnBlocklist}
        For Each btn In btnmonitor
            CornerRadius(btn)
        Next

        Dim paddedPanels = {PnlForBtns}
        For Each pnl In paddedPanels
            pnl.Padding = New Padding(3)
        Next

        roundedPanels.Add(PnlForBtns, 15)
    End Sub

    Private Sub CFMonitoring_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim btnmonitor As Button() = {BtnBorrowing, BtnReports, BtnBlocklist}
        For Each btn In btnmonitor
            CornerRadius(btn)
        Next
    End Sub

    Private Sub Panel_Paint(sender As Object, e As PaintEventArgs) Handles PnlForBtns.Paint

        Dim pnl = DirectCast(sender, Panel)
        If roundedPanels.ContainsKey(pnl) Then
            MakeRoundedPanel(pnl, roundedPanels(pnl), e)
        End If
    End Sub

    Public Sub ChildForm(childForm As Form)
        PnlFill.Controls.Clear()
        With childForm
            .TopLevel = False
            .FormBorderStyle = FormBorderStyle.None
            .Dock = DockStyle.Fill
        End With
        PnlFill.Controls.Add(childForm)
        childForm.Show()
    End Sub


    Private Sub BtnBorrowing_Click(sender As Object, e As EventArgs) Handles BtnBorrowing.Click
        Dim borrowForm As New CFBorrowing()
        ChildForm(borrowForm)
        UpdateDashboardLabel("Borrowing Monitoring")
    End Sub

    Private Sub BtnBlocklist_Click(sender As Object, e As EventArgs) Handles BtnBlocklist.Click
        ChildForm(New Block())
        AdminDashboard.LblAdminDashBoard.Text = "Blocklist"
    End Sub

    Private Sub BtnReports_Click(sender As Object, e As EventArgs) Handles BtnReports.Click
        AdminDashboard.ReportChildForm(New CFReport()) ' Replace CFReport with your actual form
        AdminDashboard.LblAdminDashBoard.Text = "Reports"
    End Sub


    Public Sub UpdateDashboardLabel(text As String)
        _dashboard.UpdateDashboardLabel(text)
    End Sub
End Class
