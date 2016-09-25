<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LogForm
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
        Me.LogBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'LogBox
        '
        Me.LogBox.Location = New System.Drawing.Point(12, 30)
        Me.LogBox.Multiline = True
        Me.LogBox.Name = "LogBox"
        Me.LogBox.Size = New System.Drawing.Size(488, 324)
        Me.LogBox.TabIndex = 0
        '
        'LogForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(533, 366)
        Me.Controls.Add(Me.LogBox)
        Me.Name = "LogForm"
        Me.Text = "LogForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LogBox As System.Windows.Forms.TextBox
End Class
