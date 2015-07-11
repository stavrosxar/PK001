<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SerialCOMSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PLCConnectionSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SerialPort = New System.IO.Ports.SerialPort(Me.components)
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.EventLog = New System.Diagnostics.EventLog()
        Me.PLCConn = New System.Windows.Forms.Button()
        Me.UIupdate = New System.Windows.Forms.Timer(Me.components)
        Me.PLCUpdate = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1.SuspendLayout()
        CType(Me.EventLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(643, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SerialCOMSettingsToolStripMenuItem, Me.PLCConnectionSettingsToolStripMenuItem})
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'SerialCOMSettingsToolStripMenuItem
        '
        Me.SerialCOMSettingsToolStripMenuItem.Name = "SerialCOMSettingsToolStripMenuItem"
        Me.SerialCOMSettingsToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.SerialCOMSettingsToolStripMenuItem.Text = "Serial COM Settings"
        '
        'PLCConnectionSettingsToolStripMenuItem
        '
        Me.PLCConnectionSettingsToolStripMenuItem.Name = "PLCConnectionSettingsToolStripMenuItem"
        Me.PLCConnectionSettingsToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.PLCConnectionSettingsToolStripMenuItem.Text = "PLC Connection Settings"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'StatusStrip
        '
        Me.StatusStrip.Location = New System.Drawing.Point(0, 411)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(643, 22)
        Me.StatusStrip.TabIndex = 1
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'EventLog
        '
        Me.EventLog.SynchronizingObject = Me
        '
        'PLCConn
        '
        Me.PLCConn.BackColor = System.Drawing.Color.Silver
        Me.PLCConn.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PLCConn.Location = New System.Drawing.Point(36, 95)
        Me.PLCConn.Name = "PLCConn"
        Me.PLCConn.Size = New System.Drawing.Size(197, 70)
        Me.PLCConn.TabIndex = 2
        Me.PLCConn.Text = "Start PLC Communication"
        Me.PLCConn.UseVisualStyleBackColor = False
        '
        'UIupdate
        '
        Me.UIupdate.Enabled = True
        Me.UIupdate.Interval = 2000
        '
        'PLCUpdate
        '
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(643, 433)
        Me.Controls.Add(Me.PLCConn)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MainForm"
        Me.Text = "PK-ATF"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.EventLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SerialCOMSettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PLCConnectionSettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SerialPort As System.IO.Ports.SerialPort
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents EventLog As System.Diagnostics.EventLog
    Friend WithEvents PLCConn As System.Windows.Forms.Button
    Friend WithEvents UIupdate As System.Windows.Forms.Timer
    Friend WithEvents PLCUpdate As System.Windows.Forms.Timer

End Class
