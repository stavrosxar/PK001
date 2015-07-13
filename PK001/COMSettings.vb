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
            If MainForm.SerialPort.IsOpen Then
                Try
                    MainForm.SerialPort.Close()
                    MainForm.SerialPort.PortName = My.Settings.ComNum

                    MainForm.SerialPort.Open()
                Catch ex2 As Exception
                    MsgBox("Failed open port")
                End Try

            End If

        End If
        If newSpeed.Text <> "" Then
            My.Settings.ComSpeed = newSpeed.Text
            If MainForm.SerialPort.IsOpen Then
                Try
                    MainForm.SerialPort.Close()
                    MainForm.SerialPort.BaudRate = My.Settings.ComSpeed
                    MainForm.SerialPort.Open()
                Catch ex2 As Exception
                    MsgBox("Failed open port")
                End Try

            End If

        End If
        If newBits.Text <> "" Then
            My.Settings.ComBits = newBits.Text
            If MainForm.SerialPort.IsOpen Then
                Try
                    MainForm.SerialPort.Close()
                    MainForm.SerialPort.DataBits = My.Settings.ComBits
                    MainForm.SerialPort.Open()
                Catch ex2 As Exception
                    MsgBox("Failed open port")
                End Try
            End If

        End If

        Me.Close()
    End Sub

    Private Sub CancelBtn_Click(sender As Object, e As EventArgs) Handles CancelBtn.Click

        Me.Close()
    End Sub
End Class