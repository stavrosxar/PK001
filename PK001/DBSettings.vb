Public Class DBSettings

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Settings.host = hostTxt.Text
        My.Settings.port = portTxt.Text
        My.Settings.serviceName = serviceNameTxt.Text
        My.Settings.user = userTxt.Text
        My.Settings.password = passwordTxt.Text
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Public Sub DBSettings_Load(sender As Object, e As EventArgs) Handles Me.Load
        hostTxt.Text = My.Settings.host
        portTxt.Text = My.Settings.port
        serviceNameTxt.Text = My.Settings.serviceName
        userTxt.Text = My.Settings.user
        passwordTxt.Text = My.Settings.password
    End Sub
End Class