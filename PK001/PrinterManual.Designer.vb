<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrinterManual
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
        Me.getStatusBtn = New System.Windows.Forms.Button()
        Me.BlowBtn = New System.Windows.Forms.Button()
        Me.SucctionBtn = New System.Windows.Forms.Button()
        Me.ReadInputsBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'getStatusBtn
        '
        Me.getStatusBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.getStatusBtn.Location = New System.Drawing.Point(13, 11)
        Me.getStatusBtn.Name = "getStatusBtn"
        Me.getStatusBtn.Size = New System.Drawing.Size(158, 58)
        Me.getStatusBtn.TabIndex = 0
        Me.getStatusBtn.Text = "Get Status"
        Me.getStatusBtn.UseVisualStyleBackColor = True
        '
        'BlowBtn
        '
        Me.BlowBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlowBtn.Location = New System.Drawing.Point(13, 86)
        Me.BlowBtn.Name = "BlowBtn"
        Me.BlowBtn.Size = New System.Drawing.Size(158, 57)
        Me.BlowBtn.TabIndex = 1
        Me.BlowBtn.Text = "Enable Blow"
        Me.BlowBtn.UseVisualStyleBackColor = True
        '
        'SucctionBtn
        '
        Me.SucctionBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SucctionBtn.Location = New System.Drawing.Point(177, 86)
        Me.SucctionBtn.Name = "SucctionBtn"
        Me.SucctionBtn.Size = New System.Drawing.Size(158, 57)
        Me.SucctionBtn.TabIndex = 2
        Me.SucctionBtn.Text = "Enable Suction"
        Me.SucctionBtn.UseVisualStyleBackColor = True
        '
        'ReadInputsBtn
        '
        Me.ReadInputsBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReadInputsBtn.Location = New System.Drawing.Point(347, 86)
        Me.ReadInputsBtn.Name = "ReadInputsBtn"
        Me.ReadInputsBtn.Size = New System.Drawing.Size(158, 57)
        Me.ReadInputsBtn.TabIndex = 3
        Me.ReadInputsBtn.Text = "Read Inputs"
        Me.ReadInputsBtn.UseVisualStyleBackColor = True
        '
        'PrinterManual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(516, 241)
        Me.Controls.Add(Me.ReadInputsBtn)
        Me.Controls.Add(Me.SucctionBtn)
        Me.Controls.Add(Me.BlowBtn)
        Me.Controls.Add(Me.getStatusBtn)
        Me.Name = "PrinterManual"
        Me.Text = "PrinterManual"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents getStatusBtn As System.Windows.Forms.Button
    Friend WithEvents BlowBtn As System.Windows.Forms.Button
    Friend WithEvents SucctionBtn As System.Windows.Forms.Button
    Friend WithEvents ReadInputsBtn As System.Windows.Forms.Button
End Class
