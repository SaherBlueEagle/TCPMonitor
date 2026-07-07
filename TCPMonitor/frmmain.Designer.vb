<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmmain
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmmain))
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.LstItems = New System.Windows.Forms.ListView()
        Me.cFile = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cLocal = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cLocalPort = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cRemoteAddr = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cRemotePort = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cState = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cPID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ImgList = New System.Windows.Forms.ImageList(Me.components)
        Me.cmdKill = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdRefresh.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdRefresh.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdRefresh.Location = New System.Drawing.Point(8, 288)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(75, 23)
        Me.cmdRefresh.TabIndex = 1
        Me.cmdRefresh.Text = "&Refresh"
        Me.cmdRefresh.UseVisualStyleBackColor = False
        '
        'LstItems
        '
        Me.LstItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LstItems.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.cFile, Me.cLocal, Me.cLocalPort, Me.cRemoteAddr, Me.cRemotePort, Me.cState, Me.cPID})
        Me.LstItems.FullRowSelect = True
        Me.LstItems.Location = New System.Drawing.Point(8, 8)
        Me.LstItems.Name = "LstItems"
        Me.LstItems.Size = New System.Drawing.Size(752, 272)
        Me.LstItems.SmallImageList = Me.ImgList
        Me.LstItems.TabIndex = 0
        Me.LstItems.UseCompatibleStateImageBehavior = False
        Me.LstItems.View = System.Windows.Forms.View.Details
        '
        'cFile
        '
        Me.cFile.Text = "Filename"
        Me.cFile.Width = 100
        '
        'cLocal
        '
        Me.cLocal.Text = "Local Host"
        Me.cLocal.Width = 120
        '
        'cLocalPort
        '
        Me.cLocalPort.Text = "Local Port"
        '
        'cRemoteAddr
        '
        Me.cRemoteAddr.Text = "Remote Host"
        Me.cRemoteAddr.Width = 120
        '
        'cRemotePort
        '
        Me.cRemotePort.Text = "Remote Port"
        Me.cRemotePort.Width = 80
        '
        'cState
        '
        Me.cState.Text = "Stats"
        Me.cState.Width = 120
        '
        'cPID
        '
        Me.cPID.Text = "PID"
        Me.cPID.Width = 80
        '
        'ImgList
        '
        Me.ImgList.ImageStream = CType(resources.GetObject("ImgList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImgList.TransparentColor = System.Drawing.Color.Fuchsia
        Me.ImgList.Images.SetKeyName(0, "app.png")
        '
        'cmdKill
        '
        Me.cmdKill.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdKill.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdKill.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdKill.Location = New System.Drawing.Point(88, 288)
        Me.cmdKill.Name = "cmdKill"
        Me.cmdKill.Size = New System.Drawing.Size(104, 23)
        Me.cmdKill.TabIndex = 2
        Me.cmdKill.Text = "Close &Process"
        Me.cmdKill.UseVisualStyleBackColor = False
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Location = New System.Drawing.Point(195, 288)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(64, 23)
        Me.cmdClose.TabIndex = 3
        Me.cmdClose.Text = "&Close"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'frmmain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(768, 320)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdKill)
        Me.Controls.Add(Me.LstItems)
        Me.Controls.Add(Me.cmdRefresh)
        Me.Name = "frmmain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TCP Monitor"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents LstItems As System.Windows.Forms.ListView
    Friend WithEvents cFile As System.Windows.Forms.ColumnHeader
    Friend WithEvents cLocal As System.Windows.Forms.ColumnHeader
    Friend WithEvents cLocalPort As System.Windows.Forms.ColumnHeader
    Friend WithEvents cRemoteAddr As System.Windows.Forms.ColumnHeader
    Friend WithEvents cRemotePort As System.Windows.Forms.ColumnHeader
    Friend WithEvents cState As System.Windows.Forms.ColumnHeader
    Friend WithEvents cPID As System.Windows.Forms.ColumnHeader
    Friend WithEvents cmdKill As System.Windows.Forms.Button
    Friend WithEvents ImgList As System.Windows.Forms.ImageList
    Friend WithEvents cmdClose As System.Windows.Forms.Button

End Class
