<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LoginForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        PanelFill = New Panel()
        btnFocus = New Button()
        PanelLogin = New TableLayoutPanel()
        PanelRight = New Panel()
        TableLayoutPanel1 = New TableLayoutPanel()
        TableLayoutPanel2 = New TableLayoutPanel()
        Panellabel = New Panel()
        Label9 = New Label()
        Panel9 = New Panel()
        PanelLableAdminPortal = New Panel()
        Label8 = New Label()
        TableLayoutPanel3 = New TableLayoutPanel()
        TableLayoutPanel4 = New TableLayoutPanel()
        Panel10 = New Panel()
        TxtUser1 = New TextBox()
        Panel3 = New Panel()
        Label2 = New Label()
        TableLayoutPanel5 = New TableLayoutPanel()
        PnlPass = New Panel()
        TxtPass1 = New TextBox()
        Panel11 = New Panel()
        Label11 = New Label()
        TableLayoutPanel6 = New TableLayoutPanel()
        Panel12 = New Panel()
        TLPForgotTerms = New TableLayoutPanel()
        Panel15 = New Panel()
        Panel16 = New Panel()
        Panel14 = New Panel()
        Panel13 = New Panel()
        BtnLogin = New Button()
        Panel17 = New Panel()
        Panel18 = New Panel()
        Label12 = New Label()
        PanelLeft = New Panel()
        Panel2 = New Panel()
        Label10 = New Label()
        Label3 = New Label()
        Label1 = New Label()
        PanelList = New Panel()
        Panel4 = New Panel()
        Label4 = New Label()
        Panel5 = New Panel()
        Label5 = New Label()
        Panel6 = New Panel()
        Label6 = New Label()
        Panel7 = New Panel()
        Label7 = New Label()
        Panel8 = New Panel()
        Panel1 = New Panel()
        PnlQCULogo = New Panel()
        PnlPicQCU = New Panel()
        PicQCULogo = New PictureBox()
        PnlLibraryBuilding = New Panel()
        PnlPicBuilding = New Panel()
        PicLibBuilding = New PictureBox()
        PanelLogo = New Panel()
        PanelFill.SuspendLayout()
        PanelLogin.SuspendLayout()
        PanelRight.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        Panellabel.SuspendLayout()
        PanelLableAdminPortal.SuspendLayout()
        TableLayoutPanel3.SuspendLayout()
        TableLayoutPanel4.SuspendLayout()
        Panel10.SuspendLayout()
        Panel3.SuspendLayout()
        TableLayoutPanel5.SuspendLayout()
        PnlPass.SuspendLayout()
        Panel11.SuspendLayout()
        TableLayoutPanel6.SuspendLayout()
        Panel12.SuspendLayout()
        TLPForgotTerms.SuspendLayout()
        Panel15.SuspendLayout()
        Panel13.SuspendLayout()
        Panel17.SuspendLayout()
        Panel18.SuspendLayout()
        PanelLeft.SuspendLayout()
        Panel2.SuspendLayout()
        PanelList.SuspendLayout()
        Panel4.SuspendLayout()
        Panel5.SuspendLayout()
        Panel6.SuspendLayout()
        Panel7.SuspendLayout()
        Panel1.SuspendLayout()
        PnlQCULogo.SuspendLayout()
        PnlPicQCU.SuspendLayout()
        CType(PicQCULogo, ComponentModel.ISupportInitialize).BeginInit()
        PnlLibraryBuilding.SuspendLayout()
        PnlPicBuilding.SuspendLayout()
        CType(PicLibBuilding, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PanelFill
        ' 
        PanelFill.BackColor = Color.FromArgb(CByte(25), CByte(85), CByte(123))
        PanelFill.Controls.Add(btnFocus)
        PanelFill.Controls.Add(PanelLogin)
        PanelFill.Dock = DockStyle.Fill
        PanelFill.Location = New Point(0, 0)
        PanelFill.Name = "PanelFill"
        PanelFill.Size = New Size(984, 661)
        PanelFill.TabIndex = 0
        ' 
        ' btnFocus
        ' 
        btnFocus.FlatStyle = FlatStyle.Flat
        btnFocus.Location = New Point(-17, 102)
        btnFocus.Name = "btnFocus"
        btnFocus.Size = New Size(1, 1)
        btnFocus.TabIndex = 1
        btnFocus.Text = "Button1"
        btnFocus.UseVisualStyleBackColor = True
        ' 
        ' PanelLogin
        ' 
        PanelLogin.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        PanelLogin.ColumnCount = 2
        PanelLogin.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 60F))
        PanelLogin.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 40F))
        PanelLogin.Controls.Add(PanelRight, 1, 0)
        PanelLogin.Controls.Add(PanelLeft, 0, 0)
        PanelLogin.Location = New Point(28, 12)
        PanelLogin.Name = "PanelLogin"
        PanelLogin.RowCount = 1
        PanelLogin.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        PanelLogin.Size = New Size(927, 637)
        PanelLogin.TabIndex = 0
        ' 
        ' PanelRight
        ' 
        PanelRight.BackColor = Color.White
        PanelRight.Controls.Add(TableLayoutPanel1)
        PanelRight.Dock = DockStyle.Fill
        PanelRight.Location = New Point(556, 0)
        PanelRight.Margin = New Padding(0)
        PanelRight.Name = "PanelRight"
        PanelRight.Size = New Size(371, 637)
        PanelRight.TabIndex = 1
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 1
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Controls.Add(TableLayoutPanel2, 0, 0)
        TableLayoutPanel1.Controls.Add(TableLayoutPanel3, 0, 1)
        TableLayoutPanel1.Controls.Add(TableLayoutPanel6, 0, 2)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 3
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 20F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 40F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 40F))
        TableLayoutPanel1.Size = New Size(371, 637)
        TableLayoutPanel1.TabIndex = 0
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 1
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.Controls.Add(Panellabel, 0, 2)
        TableLayoutPanel2.Controls.Add(Panel9, 0, 0)
        TableLayoutPanel2.Controls.Add(PanelLableAdminPortal, 0, 1)
        TableLayoutPanel2.Dock = DockStyle.Fill
        TableLayoutPanel2.Location = New Point(0, 0)
        TableLayoutPanel2.Margin = New Padding(0)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 3
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 20F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 40F))
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 40F))
        TableLayoutPanel2.Size = New Size(371, 127)
        TableLayoutPanel2.TabIndex = 0
        ' 
        ' Panellabel
        ' 
        Panellabel.Controls.Add(Label9)
        Panellabel.Dock = DockStyle.Fill
        Panellabel.Location = New Point(0, 75)
        Panellabel.Margin = New Padding(0)
        Panellabel.Name = "Panellabel"
        Panellabel.Size = New Size(371, 52)
        Panellabel.TabIndex = 2
        ' 
        ' Label9
        ' 
        Label9.Dock = DockStyle.Fill
        Label9.Font = New Font("Segoe UI", 10F)
        Label9.ForeColor = Color.Gray
        Label9.Location = New Point(0, 0)
        Label9.Name = "Label9"
        Label9.Size = New Size(371, 52)
        Label9.TabIndex = 4
        Label9.Text = "Please log in with your credentials"
        Label9.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Panel9
        ' 
        Panel9.Dock = DockStyle.Fill
        Panel9.Location = New Point(3, 3)
        Panel9.Name = "Panel9"
        Panel9.Size = New Size(365, 19)
        Panel9.TabIndex = 0
        ' 
        ' PanelLableAdminPortal
        ' 
        PanelLableAdminPortal.Controls.Add(Label8)
        PanelLableAdminPortal.Dock = DockStyle.Fill
        PanelLableAdminPortal.Location = New Point(0, 25)
        PanelLableAdminPortal.Margin = New Padding(0)
        PanelLableAdminPortal.Name = "PanelLableAdminPortal"
        PanelLableAdminPortal.Size = New Size(371, 50)
        PanelLableAdminPortal.TabIndex = 1
        ' 
        ' Label8
        ' 
        Label8.Dock = DockStyle.Fill
        Label8.Font = New Font("Segoe UI", 15F, FontStyle.Bold)
        Label8.ForeColor = Color.Black
        Label8.Location = New Point(0, 0)
        Label8.Name = "Label8"
        Label8.Size = New Size(371, 50)
        Label8.TabIndex = 3
        Label8.Text = "Admin Portal"
        Label8.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' TableLayoutPanel3
        ' 
        TableLayoutPanel3.ColumnCount = 1
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel3.Controls.Add(TableLayoutPanel4, 0, 0)
        TableLayoutPanel3.Controls.Add(TableLayoutPanel5, 0, 1)
        TableLayoutPanel3.Dock = DockStyle.Fill
        TableLayoutPanel3.Location = New Point(0, 127)
        TableLayoutPanel3.Margin = New Padding(0)
        TableLayoutPanel3.Name = "TableLayoutPanel3"
        TableLayoutPanel3.RowCount = 2
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel3.Size = New Size(371, 254)
        TableLayoutPanel3.TabIndex = 1
        ' 
        ' TableLayoutPanel4
        ' 
        TableLayoutPanel4.ColumnCount = 1
        TableLayoutPanel4.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel4.Controls.Add(Panel10, 0, 1)
        TableLayoutPanel4.Controls.Add(Panel3, 0, 0)
        TableLayoutPanel4.Dock = DockStyle.Fill
        TableLayoutPanel4.Location = New Point(0, 0)
        TableLayoutPanel4.Margin = New Padding(0)
        TableLayoutPanel4.Name = "TableLayoutPanel4"
        TableLayoutPanel4.RowCount = 2
        TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel4.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel4.Size = New Size(371, 127)
        TableLayoutPanel4.TabIndex = 0
        ' 
        ' Panel10
        ' 
        Panel10.Controls.Add(TxtUser1)
        Panel10.Dock = DockStyle.Fill
        Panel10.Location = New Point(0, 63)
        Panel10.Margin = New Padding(0)
        Panel10.Name = "Panel10"
        Panel10.Size = New Size(371, 64)
        Panel10.TabIndex = 1
        ' 
        ' TxtUser1
        ' 
        TxtUser1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        TxtUser1.BorderStyle = BorderStyle.FixedSingle
        TxtUser1.Font = New Font("Segoe UI", 15F)
        TxtUser1.Location = New Point(26, 3)
        TxtUser1.Multiline = True
        TxtUser1.Name = "TxtUser1"
        TxtUser1.Size = New Size(326, 32)
        TxtUser1.TabIndex = 1
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(Label2)
        Panel3.Dock = DockStyle.Bottom
        Panel3.Location = New Point(0, 33)
        Panel3.Margin = New Padding(0)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(371, 30)
        Panel3.TabIndex = 0
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Dock = DockStyle.Bottom
        Label2.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label2.Location = New Point(0, 11)
        Label2.Name = "Label2"
        Label2.Padding = New Padding(20, 0, 0, 0)
        Label2.Size = New Size(96, 19)
        Label2.TabIndex = 0
        Label2.Text = "Username"
        ' 
        ' TableLayoutPanel5
        ' 
        TableLayoutPanel5.ColumnCount = 1
        TableLayoutPanel5.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel5.Controls.Add(PnlPass, 0, 1)
        TableLayoutPanel5.Controls.Add(Panel11, 0, 0)
        TableLayoutPanel5.Dock = DockStyle.Fill
        TableLayoutPanel5.Location = New Point(0, 127)
        TableLayoutPanel5.Margin = New Padding(0)
        TableLayoutPanel5.Name = "TableLayoutPanel5"
        TableLayoutPanel5.RowCount = 2
        TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Percent, 20F))
        TableLayoutPanel5.RowStyles.Add(New RowStyle(SizeType.Percent, 80F))
        TableLayoutPanel5.Size = New Size(371, 127)
        TableLayoutPanel5.TabIndex = 1
        ' 
        ' PnlPass
        ' 
        PnlPass.Controls.Add(TxtPass1)
        PnlPass.Dock = DockStyle.Fill
        PnlPass.Location = New Point(0, 25)
        PnlPass.Margin = New Padding(0)
        PnlPass.Name = "PnlPass"
        PnlPass.Size = New Size(371, 102)
        PnlPass.TabIndex = 2
        ' 
        ' TxtPass1
        ' 
        TxtPass1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        TxtPass1.BorderStyle = BorderStyle.FixedSingle
        TxtPass1.Font = New Font("Segoe UI", 15F)
        TxtPass1.Location = New Point(26, 3)
        TxtPass1.Multiline = True
        TxtPass1.Name = "TxtPass1"
        TxtPass1.Size = New Size(328, 34)
        TxtPass1.TabIndex = 0
        ' 
        ' Panel11
        ' 
        Panel11.Controls.Add(Label11)
        Panel11.Dock = DockStyle.Fill
        Panel11.Location = New Point(0, 0)
        Panel11.Margin = New Padding(0)
        Panel11.Name = "Panel11"
        Panel11.Size = New Size(371, 25)
        Panel11.TabIndex = 0
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Dock = DockStyle.Bottom
        Label11.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        Label11.Location = New Point(0, 6)
        Label11.Name = "Label11"
        Label11.Padding = New Padding(20, 0, 0, 0)
        Label11.Size = New Size(93, 19)
        Label11.TabIndex = 1
        Label11.Text = "Password"
        ' 
        ' TableLayoutPanel6
        ' 
        TableLayoutPanel6.ColumnCount = 1
        TableLayoutPanel6.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel6.Controls.Add(Panel12, 0, 0)
        TableLayoutPanel6.Controls.Add(Panel17, 0, 1)
        TableLayoutPanel6.Dock = DockStyle.Fill
        TableLayoutPanel6.Location = New Point(0, 381)
        TableLayoutPanel6.Margin = New Padding(0)
        TableLayoutPanel6.Name = "TableLayoutPanel6"
        TableLayoutPanel6.RowCount = 2
        TableLayoutPanel6.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel6.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel6.Size = New Size(371, 256)
        TableLayoutPanel6.TabIndex = 2
        ' 
        ' Panel12
        ' 
        Panel12.Controls.Add(TLPForgotTerms)
        Panel12.Controls.Add(Panel13)
        Panel12.Dock = DockStyle.Fill
        Panel12.Location = New Point(0, 0)
        Panel12.Margin = New Padding(0)
        Panel12.Name = "Panel12"
        Panel12.Size = New Size(371, 128)
        Panel12.TabIndex = 0
        ' 
        ' TLPForgotTerms
        ' 
        TLPForgotTerms.ColumnCount = 2
        TLPForgotTerms.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TLPForgotTerms.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TLPForgotTerms.Controls.Add(Panel15, 1, 0)
        TLPForgotTerms.Controls.Add(Panel14, 0, 0)
        TLPForgotTerms.Dock = DockStyle.Fill
        TLPForgotTerms.Location = New Point(0, 54)
        TLPForgotTerms.Margin = New Padding(0)
        TLPForgotTerms.Name = "TLPForgotTerms"
        TLPForgotTerms.RowCount = 1
        TLPForgotTerms.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TLPForgotTerms.Size = New Size(371, 74)
        TLPForgotTerms.TabIndex = 1
        ' 
        ' Panel15
        ' 
        Panel15.Controls.Add(Panel16)
        Panel15.Dock = DockStyle.Fill
        Panel15.Location = New Point(185, 0)
        Panel15.Margin = New Padding(0)
        Panel15.Name = "Panel15"
        Panel15.Size = New Size(186, 74)
        Panel15.TabIndex = 1
        ' 
        ' Panel16
        ' 
        Panel16.Dock = DockStyle.Fill
        Panel16.Location = New Point(0, 0)
        Panel16.Margin = New Padding(0)
        Panel16.Name = "Panel16"
        Panel16.Size = New Size(186, 74)
        Panel16.TabIndex = 1
        ' 
        ' Panel14
        ' 
        Panel14.Dock = DockStyle.Fill
        Panel14.Location = New Point(0, 0)
        Panel14.Margin = New Padding(0)
        Panel14.Name = "Panel14"
        Panel14.Size = New Size(185, 74)
        Panel14.TabIndex = 0
        ' 
        ' Panel13
        ' 
        Panel13.Controls.Add(BtnLogin)
        Panel13.Dock = DockStyle.Top
        Panel13.Location = New Point(0, 0)
        Panel13.Margin = New Padding(0)
        Panel13.Name = "Panel13"
        Panel13.Size = New Size(371, 54)
        Panel13.TabIndex = 0
        ' 
        ' BtnLogin
        ' 
        BtnLogin.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        BtnLogin.BackColor = Color.FromArgb(CByte(27), CByte(82), CByte(116))
        BtnLogin.FlatStyle = FlatStyle.Flat
        BtnLogin.ForeColor = Color.White
        BtnLogin.Location = New Point(26, 0)
        BtnLogin.Margin = New Padding(0)
        BtnLogin.Name = "BtnLogin"
        BtnLogin.Size = New Size(328, 34)
        BtnLogin.TabIndex = 0
        BtnLogin.Text = "Log In"
        BtnLogin.UseVisualStyleBackColor = False
        ' 
        ' Panel17
        ' 
        Panel17.Controls.Add(Panel18)
        Panel17.Dock = DockStyle.Fill
        Panel17.Location = New Point(0, 128)
        Panel17.Margin = New Padding(0)
        Panel17.Name = "Panel17"
        Panel17.Size = New Size(371, 128)
        Panel17.TabIndex = 1
        ' 
        ' Panel18
        ' 
        Panel18.Controls.Add(Label12)
        Panel18.Dock = DockStyle.Top
        Panel18.Location = New Point(0, 0)
        Panel18.Name = "Panel18"
        Panel18.Size = New Size(371, 47)
        Panel18.TabIndex = 1
        ' 
        ' Label12
        ' 
        Label12.Dock = DockStyle.Fill
        Label12.ForeColor = Color.Gray
        Label12.Location = New Point(0, 0)
        Label12.Name = "Label12"
        Label12.Size = New Size(371, 47)
        Label12.TabIndex = 0
        Label12.Text = "© 2025 Quezon City University Library. All rights reserved."
        Label12.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' PanelLeft
        ' 
        PanelLeft.Controls.Add(Panel2)
        PanelLeft.Controls.Add(PanelList)
        PanelLeft.Controls.Add(Panel8)
        PanelLeft.Controls.Add(Panel1)
        PanelLeft.Controls.Add(PanelLogo)
        PanelLeft.Dock = DockStyle.Fill
        PanelLeft.Location = New Point(0, 0)
        PanelLeft.Margin = New Padding(0)
        PanelLeft.Name = "PanelLeft"
        PanelLeft.Size = New Size(556, 637)
        PanelLeft.TabIndex = 0
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(Label10)
        Panel2.Controls.Add(Label3)
        Panel2.Controls.Add(Label1)
        Panel2.Dock = DockStyle.Fill
        Panel2.Location = New Point(0, 126)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(556, 249)
        Panel2.TabIndex = 4
        ' 
        ' Label10
        ' 
        Label10.Dock = DockStyle.Fill
        Label10.Font = New Font("Segoe UI", 15F)
        Label10.ForeColor = Color.White
        Label10.Location = New Point(0, 207)
        Label10.Name = "Label10"
        Label10.Size = New Size(556, 42)
        Label10.TabIndex = 3
        Label10.Text = "QUEZON CITY UNIVERSITY"
        Label10.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label3
        ' 
        Label3.Dock = DockStyle.Top
        Label3.Font = New Font("Segoe UI", 25F, FontStyle.Bold)
        Label3.ForeColor = Color.White
        Label3.Location = New Point(0, 149)
        Label3.Name = "Label3"
        Label3.Size = New Size(556, 58)
        Label3.TabIndex = 2
        Label3.Text = "SYSTEM"
        Label3.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label1
        ' 
        Label1.Dock = DockStyle.Top
        Label1.Font = New Font("Segoe UI", 25F, FontStyle.Bold)
        Label1.ForeColor = Color.White
        Label1.Location = New Point(0, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(556, 149)
        Label1.TabIndex = 1
        Label1.Text = "LIBRARY MANAGEMENT"
        Label1.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' PanelList
        ' 
        PanelList.Controls.Add(Panel4)
        PanelList.Controls.Add(Panel5)
        PanelList.Controls.Add(Panel6)
        PanelList.Controls.Add(Panel7)
        PanelList.Dock = DockStyle.Bottom
        PanelList.Location = New Point(0, 375)
        PanelList.Name = "PanelList"
        PanelList.Size = New Size(556, 184)
        PanelList.TabIndex = 6
        ' 
        ' Panel4
        ' 
        Panel4.Controls.Add(Label4)
        Panel4.Dock = DockStyle.Fill
        Panel4.Location = New Point(0, 0)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(556, 81)
        Panel4.TabIndex = 0
        ' 
        ' Label4
        ' 
        Label4.Dock = DockStyle.Fill
        Label4.Font = New Font("Calibri", 10F)
        Label4.ForeColor = Color.White
        Label4.Location = New Point(0, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(556, 81)
        Label4.TabIndex = 3
        Label4.Text = "Search and browse the entire collection"
        Label4.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' Panel5
        ' 
        Panel5.Controls.Add(Label5)
        Panel5.Dock = DockStyle.Bottom
        Panel5.Location = New Point(0, 81)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(556, 34)
        Panel5.TabIndex = 1
        ' 
        ' Label5
        ' 
        Label5.Dock = DockStyle.Fill
        Label5.Font = New Font("Calibri", 10F)
        Label5.ForeColor = Color.White
        Label5.Location = New Point(0, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(556, 34)
        Label5.TabIndex = 3
        Label5.Text = "Check book availability in real-time       "
        Label5.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' Panel6
        ' 
        Panel6.Controls.Add(Label6)
        Panel6.Dock = DockStyle.Bottom
        Panel6.Location = New Point(0, 115)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(556, 34)
        Panel6.TabIndex = 2
        ' 
        ' Label6
        ' 
        Label6.Dock = DockStyle.Fill
        Label6.Font = New Font("Calibri", 10F)
        Label6.ForeColor = Color.White
        Label6.Location = New Point(0, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(556, 34)
        Label6.TabIndex = 3
        Label6.Text = "Manage loans and reservation               "
        Label6.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' Panel7
        ' 
        Panel7.Controls.Add(Label7)
        Panel7.Dock = DockStyle.Bottom
        Panel7.Location = New Point(0, 149)
        Panel7.Name = "Panel7"
        Panel7.Size = New Size(556, 35)
        Panel7.TabIndex = 3
        ' 
        ' Label7
        ' 
        Label7.Dock = DockStyle.Fill
        Label7.Font = New Font("Calibri", 10F)
        Label7.ForeColor = Color.White
        Label7.Location = New Point(0, 0)
        Label7.Name = "Label7"
        Label7.Size = New Size(556, 35)
        Label7.TabIndex = 3
        Label7.Text = "Access digital resources and e-books    "
        Label7.TextAlign = ContentAlignment.BottomCenter
        ' 
        ' Panel8
        ' 
        Panel8.Dock = DockStyle.Bottom
        Panel8.Location = New Point(0, 559)
        Panel8.Name = "Panel8"
        Panel8.Size = New Size(556, 78)
        Panel8.TabIndex = 1
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(PnlQCULogo)
        Panel1.Controls.Add(PnlLibraryBuilding)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 44)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(556, 82)
        Panel1.TabIndex = 3
        ' 
        ' PnlQCULogo
        ' 
        PnlQCULogo.Controls.Add(PnlPicQCU)
        PnlQCULogo.Dock = DockStyle.Fill
        PnlQCULogo.Location = New Point(0, 39)
        PnlQCULogo.Name = "PnlQCULogo"
        PnlQCULogo.Size = New Size(556, 43)
        PnlQCULogo.TabIndex = 1
        ' 
        ' PnlPicQCU
        ' 
        PnlPicQCU.Controls.Add(PicQCULogo)
        PnlPicQCU.Dock = DockStyle.Left
        PnlPicQCU.Location = New Point(0, 0)
        PnlPicQCU.Name = "PnlPicQCU"
        PnlPicQCU.Size = New Size(48, 43)
        PnlPicQCU.TabIndex = 1
        ' 
        ' PicQCULogo
        ' 
        PicQCULogo.BackgroundImageLayout = ImageLayout.Stretch
        PicQCULogo.Dock = DockStyle.Fill
        PicQCULogo.Location = New Point(0, 0)
        PicQCULogo.Name = "PicQCULogo"
        PicQCULogo.Size = New Size(48, 43)
        PicQCULogo.TabIndex = 1
        PicQCULogo.TabStop = False
        ' 
        ' PnlLibraryBuilding
        ' 
        PnlLibraryBuilding.Controls.Add(PnlPicBuilding)
        PnlLibraryBuilding.Dock = DockStyle.Top
        PnlLibraryBuilding.Location = New Point(0, 0)
        PnlLibraryBuilding.Name = "PnlLibraryBuilding"
        PnlLibraryBuilding.Size = New Size(556, 39)
        PnlLibraryBuilding.TabIndex = 0
        ' 
        ' PnlPicBuilding
        ' 
        PnlPicBuilding.Controls.Add(PicLibBuilding)
        PnlPicBuilding.Dock = DockStyle.Left
        PnlPicBuilding.Location = New Point(0, 0)
        PnlPicBuilding.Name = "PnlPicBuilding"
        PnlPicBuilding.Size = New Size(48, 39)
        PnlPicBuilding.TabIndex = 0
        ' 
        ' PicLibBuilding
        ' 
        PicLibBuilding.BackgroundImageLayout = ImageLayout.Stretch
        PicLibBuilding.Dock = DockStyle.Fill
        PicLibBuilding.Location = New Point(0, 0)
        PicLibBuilding.Name = "PicLibBuilding"
        PicLibBuilding.Size = New Size(48, 39)
        PicLibBuilding.TabIndex = 0
        PicLibBuilding.TabStop = False
        ' 
        ' PanelLogo
        ' 
        PanelLogo.Dock = DockStyle.Top
        PanelLogo.Location = New Point(0, 0)
        PanelLogo.Name = "PanelLogo"
        PanelLogo.Size = New Size(556, 44)
        PanelLogo.TabIndex = 0
        ' 
        ' LoginForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(984, 661)
        Controls.Add(PanelFill)
        Name = "LoginForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Library Management System"
        WindowState = FormWindowState.Maximized
        PanelFill.ResumeLayout(False)
        PanelLogin.ResumeLayout(False)
        PanelRight.ResumeLayout(False)
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel2.ResumeLayout(False)
        Panellabel.ResumeLayout(False)
        PanelLableAdminPortal.ResumeLayout(False)
        TableLayoutPanel3.ResumeLayout(False)
        TableLayoutPanel4.ResumeLayout(False)
        Panel10.ResumeLayout(False)
        Panel10.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        TableLayoutPanel5.ResumeLayout(False)
        PnlPass.ResumeLayout(False)
        PnlPass.PerformLayout()
        Panel11.ResumeLayout(False)
        Panel11.PerformLayout()
        TableLayoutPanel6.ResumeLayout(False)
        Panel12.ResumeLayout(False)
        TLPForgotTerms.ResumeLayout(False)
        Panel15.ResumeLayout(False)
        Panel13.ResumeLayout(False)
        Panel17.ResumeLayout(False)
        Panel18.ResumeLayout(False)
        PanelLeft.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        PanelList.ResumeLayout(False)
        Panel4.ResumeLayout(False)
        Panel5.ResumeLayout(False)
        Panel6.ResumeLayout(False)
        Panel7.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        PnlQCULogo.ResumeLayout(False)
        PnlPicQCU.ResumeLayout(False)
        CType(PicQCULogo, ComponentModel.ISupportInitialize).EndInit()
        PnlLibraryBuilding.ResumeLayout(False)
        PnlPicBuilding.ResumeLayout(False)
        CType(PicLibBuilding, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents PanelFill As Panel
    Friend WithEvents PanelLogin As TableLayoutPanel
    Friend WithEvents PanelRight As Panel
    Friend WithEvents PanelLeft As Panel
    Friend WithEvents PanelLogo As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PanelList As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents PnlQCULogo As Panel
    Friend WithEvents PnlPicQCU As Panel
    Friend WithEvents PnlLibraryBuilding As Panel
    Friend WithEvents PnlPicBuilding As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents PicQCULogo As PictureBox
    Friend WithEvents PicLibBuilding As PictureBox
    Friend WithEvents Panel8 As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents PanelLableAdminPortal As Panel
    Friend WithEvents Panellabel As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Label10 As Label
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents btnFocus As Button
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents Panel11 As Panel
    Friend WithEvents Label11 As Label
    Friend WithEvents PnlPass As Panel
    Friend WithEvents TxtPass1 As TextBox
    Friend WithEvents TableLayoutPanel6 As TableLayoutPanel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents Panel13 As Panel
    Friend WithEvents BtnLogin As Button
    Friend WithEvents TxtUser1 As TextBox
    Friend WithEvents TLPForgotTerms As TableLayoutPanel
    Friend WithEvents Panel15 As Panel
    Friend WithEvents Panel14 As Panel
    Friend WithEvents Panel16 As Panel
    Friend WithEvents Panel17 As Panel
    Friend WithEvents Panel18 As Panel
    Friend WithEvents Label12 As Label

End Class
