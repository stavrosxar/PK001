<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
                myConn.Dispose()
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
        Me.OracleDBConnectionSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManualFunctionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LabelApplicatorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckSequenceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckDBConnectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SerialPort = New System.IO.Ports.SerialPort(Me.components)
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.EventLog = New System.Diagnostics.EventLog()
        Me.PLCConn = New System.Windows.Forms.Button()
        Me.UIupdate = New System.Windows.Forms.Timer(Me.components)
        Me.PLCUpdate = New System.Windows.Forms.Timer(Me.components)
        Me.ReceiveTxt = New System.Windows.Forms.TextBox()
        Me.SendTxt = New System.Windows.Forms.TextBox()
        Me.checkForLabelTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Button3 = New System.Windows.Forms.Button()
        Me.LabelStatusTxt = New System.Windows.Forms.TextBox()
        Me.TimerTick1sec = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1.SuspendLayout()
        CType(Me.EventLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.ManualFunctionToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(573, 24)
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
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(92, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SerialCOMSettingsToolStripMenuItem, Me.PLCConnectionSettingsToolStripMenuItem, Me.OracleDBConnectionSettingsToolStripMenuItem})
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'SerialCOMSettingsToolStripMenuItem
        '
        Me.SerialCOMSettingsToolStripMenuItem.Name = "SerialCOMSettingsToolStripMenuItem"
        Me.SerialCOMSettingsToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.SerialCOMSettingsToolStripMenuItem.Text = "Serial COM Settings..."
        '
        'PLCConnectionSettingsToolStripMenuItem
        '
        Me.PLCConnectionSettingsToolStripMenuItem.Name = "PLCConnectionSettingsToolStripMenuItem"
        Me.PLCConnectionSettingsToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.PLCConnectionSettingsToolStripMenuItem.Text = "PLC Connection Settings..."
        '
        'OracleDBConnectionSettingsToolStripMenuItem
        '
        Me.OracleDBConnectionSettingsToolStripMenuItem.Name = "OracleDBConnectionSettingsToolStripMenuItem"
        Me.OracleDBConnectionSettingsToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.OracleDBConnectionSettingsToolStripMenuItem.Text = "Oracle DB Connection Settings..."
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'ManualFunctionToolStripMenuItem
        '
        Me.ManualFunctionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LabelApplicatorToolStripMenuItem, Me.CheckSequenceToolStripMenuItem, Me.CheckDBConnectionToolStripMenuItem})
        Me.ManualFunctionToolStripMenuItem.Name = "ManualFunctionToolStripMenuItem"
        Me.ManualFunctionToolStripMenuItem.Size = New System.Drawing.Size(114, 20)
        Me.ManualFunctionToolStripMenuItem.Text = "Manual Functions"
        '
        'LabelApplicatorToolStripMenuItem
        '
        Me.LabelApplicatorToolStripMenuItem.Name = "LabelApplicatorToolStripMenuItem"
        Me.LabelApplicatorToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.LabelApplicatorToolStripMenuItem.Text = "Label Applicator"
        '
        'CheckSequenceToolStripMenuItem
        '
        Me.CheckSequenceToolStripMenuItem.Name = "CheckSequenceToolStripMenuItem"
        Me.CheckSequenceToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.CheckSequenceToolStripMenuItem.Text = "Check Sequence"
        '
        'CheckDBConnectionToolStripMenuItem
        '
        Me.CheckDBConnectionToolStripMenuItem.Name = "CheckDBConnectionToolStripMenuItem"
        Me.CheckDBConnectionToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.CheckDBConnectionToolStripMenuItem.Text = "Check DB Connection"
        '
        'SerialPort
        '
        Me.SerialPort.BaudRate = 19200
        Me.SerialPort.PortName = "COM2"
        '
        'StatusStrip
        '
        Me.StatusStrip.Location = New System.Drawing.Point(0, 355)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(573, 22)
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
        Me.PLCConn.Location = New System.Drawing.Point(54, 57)
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
        'ReceiveTxt
        '
        Me.ReceiveTxt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ReceiveTxt.Location = New System.Drawing.Point(11, 299)
        Me.ReceiveTxt.Name = "ReceiveTxt"
        Me.ReceiveTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ReceiveTxt.Size = New System.Drawing.Size(553, 20)
        Me.ReceiveTxt.TabIndex = 4
        '
        'SendTxt
        '
        Me.SendTxt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.SendTxt.Location = New System.Drawing.Point(12, 273)
        Me.SendTxt.Name = "SendTxt"
        Me.SendTxt.Size = New System.Drawing.Size(552, 20)
        Me.SendTxt.TabIndex = 5
        '
        'checkForLabelTimer
        '
        Me.checkForLabelTimer.Interval = 2000
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(312, 230)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(196, 37)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "Test DB write"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'LabelStatusTxt
        '
        Me.LabelStatusTxt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelStatusTxt.Location = New System.Drawing.Point(11, 325)
        Me.LabelStatusTxt.Name = "LabelStatusTxt"
        Me.LabelStatusTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.LabelStatusTxt.Size = New System.Drawing.Size(553, 20)
        Me.LabelStatusTxt.TabIndex = 9
        '
        'TimerTick1sec
        '
        Me.TimerTick1sec.Interval = 3000
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(525, 242)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Label1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(528, 196)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 13)
        Me.Label2.TabIndex = 11
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 2000
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(573, 377)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LabelStatusTxt)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.SendTxt)
        Me.Controls.Add(Me.ReceiveTxt)
        Me.Controls.Add(Me.PLCConn)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MainForm"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
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
    Friend WithEvents SendTxt As System.Windows.Forms.TextBox
    Friend WithEvents ReceiveTxt As System.Windows.Forms.TextBox
    Friend WithEvents checkForLabelTimer As System.Windows.Forms.Timer
    Friend WithEvents OracleDBConnectionSettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents LabelStatusTxt As System.Windows.Forms.TextBox
    Friend WithEvents TimerTick1sec As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ManualFunctionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LabelApplicatorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CheckSequenceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CheckDBConnectionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
