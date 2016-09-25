Public Class LogForm

    Private Sub LogForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub log1(ByVal str As String)
        LogBox.Text = str & vbNewLine & LogBox.Text
    End Sub
End Class