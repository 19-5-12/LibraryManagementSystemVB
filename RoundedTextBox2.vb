Imports System.Drawing.Drawing2D

Public Class RoundedTextBox2
    Inherits UserControl


    Private WithEvents Txt As New TextBox()


    Public Property BorderRadius As Integer = 15

    Public Property PlaceholderText As String
        Get
            Return txt.PlaceholderText
        End Get
        Set(value As String)
            txt.PlaceholderText = value
        End Set
    End Property

    Private _passwordChar As Char = ControlChars.NullChar

    Public Property PasswordChar As Char
        Get
            Return _passwordChar
        End Get
        Set(value As Char)
            _passwordChar = value
            Txt.PasswordChar = value
            Invalidate()
        End Set
    End Property


    Public Sub New()
        InitializeComponent()
        SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or
             ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or
             ControlStyles.SupportsTransparentBackColor, True)
        Me.ForeColor = Color.Black
        Me.DoubleBuffered = True
        Me.BackColor = Color.White
        Me.Padding = New Padding(5)
        Me.Size = New Size(200, 35)

        Txt.BorderStyle = BorderStyle.None
        Txt.Dock = DockStyle.Fill
        Txt.BackColor = Color.White
        Txt.Font = New Font("Segoe UI", 10)

        Me.Controls.Add(Txt)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        Dim path As New GraphicsPath()
        path.AddArc(0, 0, BorderRadius, BorderRadius, 180, 90)
        path.AddArc(Me.Width - BorderRadius, 0, BorderRadius, BorderRadius, 270, 90)
        path.AddArc(Me.Width - BorderRadius, Me.Height - BorderRadius, BorderRadius, BorderRadius, 0, 90)
        path.AddArc(0, Me.Height - BorderRadius, BorderRadius, BorderRadius, 90, 90)
        path.CloseFigure()

        Me.Region = New Region(path)
        Using pen As New Pen(Color.Gray, 1)
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
            e.Graphics.DrawPath(pen, path)
        End Using
    End Sub

    Public Overrides Property Text As String
        Get
            Return Txt.Text
        End Get
        Set(value As String)
            Txt.Text = value
        End Set
    End Property
End Class
