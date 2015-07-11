Public Class COMSettings

    Private Sub COMSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each sp As String In My.Computer.Ports.SerialPortNames
            COMSelect.Items.Add(sp)
        Next
    End Sub
End Class