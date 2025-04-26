Imports System.Drawing
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D

Public Class RoundedTextBox
    Inherits TextBox

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
    End Sub

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        Dim path As New GraphicsPath()
        path.AddArc(0, 0, 10, 10, 180, 90)
        path.AddArc(Me.Width - 10, 0, 10, 10, 270, 90)
        path.AddArc(Me.Width - 10, Me.Height - 10, 10, 10, 0, 90)
        path.AddArc(0, Me.Height - 10, 10, 10, 90, 90)
        path.CloseAllFigures()
        Me.Region = New Region(path)
    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        OnCreateControl()
    End Sub
End Class
