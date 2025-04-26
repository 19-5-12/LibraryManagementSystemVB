Public Class DashboardButton
    Inherits UserControl

    Public Property Icon As Image
        Get
            Return IconPictureBox.Image
        End Get
        Set(value As Image)
            IconPictureBox.Image = value
        End Set
    End Property

    Public Property ValueText As String
        Get
            Return LblValue.Text
        End Get
        Set(value As String)
            LblValue.Text = value
        End Set
    End Property

    Public Property DescriptionText As String
        Get
            Return LblText.Text
        End Get
        Set(value As String)
            LblText.Text = value
        End Set
    End Property

    Public Property IconBackColor As Color
        Get
            Return IconPanel.BackColor
        End Get
        Set(value As Color)
            IconPanel.BackColor = value
        End Set
    End Property

    Public Sub New()
        Me.BackColor = Color.White
        Me.ForeColor = Color.Black
        Me.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        Me.Size = New Size(200, 100)

        ' Layout Setup
        IconPanel = New Panel With {
            .Size = New Size(40, 40),
            .BackColor = Color.Gray,
            .Location = New Point(10, 10)
        }

        IconPictureBox = New PictureBox With {
            .Size = New Size(40, 40),
            .SizeMode = PictureBoxSizeMode.CenterImage,
            .Dock = DockStyle.Fill
        }
        IconPanel.Controls.Add(IconPictureBox)



        LblValue = New Label With {
            .Text = "0",
            .Font = New Font("Segoe UI", 12, FontStyle.Bold),
            .Location = New Point(60, 10),
            .AutoSize = True
        }

        LblText = New Label With {
            .Text = "Label",
            .Font = New Font("Segoe UI", 9, FontStyle.Regular),
            .ForeColor = Color.Gray,
            .Location = New Point(60, 35),
            .AutoSize = True
        }

        Me.Controls.Add(IconPanel)
        Me.Controls.Add(LblValue)
        Me.Controls.Add(LblText)
    End Sub

    Protected Overrides Sub OnClick(e As EventArgs)
        MyBase.OnClick(e)
        ' Do something when clicked
    End Sub

    Protected Overrides Sub OnPaint(pe As PaintEventArgs)
        MyBase.OnPaint(pe)

        ' Rounded corners
        Dim radius As Integer = 20
        Dim path As New Drawing2D.GraphicsPath()
        Dim rect = Me.ClientRectangle

        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90)
        path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90)
        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90)
        path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90)
        path.CloseFigure()

        Me.Region = New Region(path)

        ' Subtle shadow
        Using shadowPen As New Pen(Color.FromArgb(40, 0, 0, 0), 1)
            pe.Graphics.DrawPath(shadowPen, path)
        End Using
    End Sub

    Private IconPanel As Panel
    Private IconPictureBox As PictureBox
    Private LblValue As Label
    Private LblText As Label
End Class
