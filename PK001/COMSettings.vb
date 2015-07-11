Public Class COMSettings

    Private Sub COMSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        For Each sp As String In My.Computer.Ports.SerialPortNames
            newCOMSelect.Items.Add(sp)
        Next

        CurrentCOMNUM.Text = My.Settings.ComNum
        CurrentSpeed.Text = My.Settings.ComSpeed
        CurrentBits.Text = My.Settings.ComBits


      
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub SaveComSettingsBtn_Click(sender As Object, e As EventArgs) Handles SaveComSettingsBtn.Click
        If newCOMSelect.SelectedItem IsNot Nothing Then
            My.Settings.ComNum = newCOMSelect.SelectedItem.ToString
            MainForm.SerialPort.PortName = My.Settings.ComNum
        End If
        If newSpeed.Text <> "" Then
            My.Settings.ComSpeed = newSpeed.Text
            MainForm.SerialPort.BaudRate = My.Settings.ComSpeed
        End If
        If newBits.Text <> "" Then
            My.Settings.ComBits = newBits.Text
            MainForm.SerialPort.DataBits = My.Settings.ComBits
        End If

        Me.Close()
    End Sub

    Private Sub CancelBtn_Click(sender As Object, e As EventArgs) Handles CancelBtn.Click

        Me.Close()
    End Sub
End Class