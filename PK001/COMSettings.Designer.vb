<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class COMSettings
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
        Me.newCOMSelect = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CurrentCOMNUM = New System.Windows.Forms.TextBox()
        Me.CurrentSpeed = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CurrentBits = New System.Windows.Forms.TextBox()
        Me.newSpeed = New System.Windows.Forms.TextBox()
        Me.newBits = New System.Windows.Forms.TextBox()
        Me.SaveComSettingsBtn = New System.Windows.Forms.Button()
        Me.CancelBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'newCOMSelect
        '
        Me.newCOMSelect.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.newCOMSelect.FormattingEnabled = True
        Me.newCOMSelect.Location = New System.Drawing.Point(70, 30)
        Me.newCOMSelect.Name = "newCOMSelect"
        Me.newCOMSelect.Size = New System.Drawing.Size(121, 28)
        Me.newCOMSelect.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(19, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "COM"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(85, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Select new"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(257, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Current"
        '
        'CurrentCOMNUM
        '
        Me.CurrentCOMNUM.Enabled = False
        Me.CurrentCOMNUM.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurrentCOMNUM.Location = New System.Drawing.Point(209, 30)
        Me.CurrentCOMNUM.Name = "CurrentCOMNUM"
        Me.CurrentCOMNUM.Size = New System.Drawing.Size(100, 26)
        Me.CurrentCOMNUM.TabIndex = 5
        '
        'CurrentSpeed
        '
        Me.CurrentSpeed.Enabled = False
        Me.CurrentSpeed.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurrentSpeed.Location = New System.Drawing.Point(209, 61)
        Me.CurrentSpeed.Name = "CurrentSpeed"
        Me.CurrentSpeed.Size = New System.Drawing.Size(100, 26)
        Me.CurrentSpeed.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 20)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Speed"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(28, 102)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 20)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Bits"
        '
        'CurrentBits
        '
        Me.CurrentBits.Enabled = False
        Me.CurrentBits.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurrentBits.Location = New System.Drawing.Point(209, 95)
        Me.CurrentBits.Name = "CurrentBits"
        Me.CurrentBits.Size = New System.Drawing.Size(100, 26)
        Me.CurrentBits.TabIndex = 9
        '
        'newSpeed
        '
        Me.newSpeed.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.newSpeed.Location = New System.Drawing.Point(70, 64)
        Me.newSpeed.Name = "newSpeed"
        Me.newSpeed.Size = New System.Drawing.Size(121, 26)
        Me.newSpeed.TabIndex = 10
        '
        'newBits
        '
        Me.newBits.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.newBits.Location = New System.Drawing.Point(70, 96)
        Me.newBits.Name = "newBits"
        Me.newBits.Size = New System.Drawing.Size(121, 26)
        Me.newBits.TabIndex = 11
        '
        'SaveComSettingsBtn
        '
        Me.SaveComSettingsBtn.Location = New System.Drawing.Point(12, 144)
        Me.SaveComSettingsBtn.Name = "SaveComSettingsBtn"
        Me.SaveComSettingsBtn.Size = New System.Drawing.Size(179, 25)
        Me.SaveComSettingsBtn.TabIndex = 12
        Me.SaveComSettingsBtn.Text = "Save and Close"
        Me.SaveComSettingsBtn.UseVisualStyleBackColor = True
        '
        'CancelBtn
        '
        Me.CancelBtn.Location = New System.Drawing.Point(209, 142)
        Me.CancelBtn.Name = "CancelBtn"
        Me.CancelBtn.Size = New System.Drawing.Size(99, 26)
        Me.CancelBtn.TabIndex = 13
        Me.CancelBtn.Text = "Cancel"
        Me.CancelBtn.UseVisualStyleBackColor = True
        '
        'COMSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(329, 172)
        Me.Controls.Add(Me.CancelBtn)
        Me.Controls.Add(Me.SaveComSettingsBtn)
        Me.Controls.Add(Me.newBits)
        Me.Controls.Add(Me.newSpeed)
        Me.Controls.Add(Me.CurrentBits)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CurrentSpeed)
        Me.Controls.Add(Me.CurrentCOMNUM)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.newCOMSelect)
        Me.Name = "COMSettings"
        Me.Text = "COM Port Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents newCOMSelect As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CurrentCOMNUM As System.Windows.Forms.TextBox
    Friend WithEvents CurrentSpeed As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CurrentBits As System.Windows.Forms.TextBox
    Friend WithEvents newSpeed As System.Windows.Forms.TextBox
    Friend WithEvents newBits As System.Windows.Forms.TextBox
    Friend WithEvents SaveComSettingsBtn As System.Windows.Forms.Button
    Friend WithEvents CancelBtn As System.Windows.Forms.Button
End Class
