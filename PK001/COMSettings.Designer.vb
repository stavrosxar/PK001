﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.COMSelect = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'COMSelect
        '
        Me.COMSelect.FormattingEnabled = True
        Me.COMSelect.Location = New System.Drawing.Point(106, 12)
        Me.COMSelect.Name = "COMSelect"
        Me.COMSelect.Size = New System.Drawing.Size(121, 21)
        Me.COMSelect.TabIndex = 1
        '
        'COMSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(449, 303)
        Me.Controls.Add(Me.COMSelect)
        Me.Name = "COMSettings"
        Me.Text = "COMSettings"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents COMSelect As System.Windows.Forms.ComboBox
End Class