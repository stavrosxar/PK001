Public Class Form1

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()

    End Sub

    Private Sub SerialCOMSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SerialCOMSettingsToolStripMenuItem.Click
        COMSettings.Show()
    End Sub
End Class
