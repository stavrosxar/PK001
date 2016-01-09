Public Class PrinterManual

   

    Private Sub getStatus_Click(sender As Object, e As EventArgs) Handles getStatusBtn.Click
        'Get status string
        Dim getStatusString = "|01ST" + Chr(13)
        MainForm.SendSerialData(getStatusString)

    End Sub

    Private Sub BlowBtn_Click(sender As Object, e As EventArgs) Handles BlowBtn.Click
        Dim BlowString As String
       
        If MainForm.blowStatus Then
            BlowString = "|01SO0" + Chr(13)
        Else
            BlowString = "|01SO1" + Chr(13)
        End If
        MainForm.SendSerialData(BlowString)
    End Sub

    Private Sub SucctionBtn_Click(sender As Object, e As EventArgs) Handles SucctionBtn.Click
        Dim SuctionString As String
        If MainForm.suctionStatus Then
            SuctionString = "|01AS0" + Chr(13)
        Else
            SuctionString = "|01AS1" + Chr(13)
        End If
        MainForm.SendSerialData(SuctionString)
    End Sub

  
    Private Sub ReadInputsBtn_Click(sender As Object, e As EventArgs) Handles ReadInputsBtn.Click
        Dim getInputsString = "|01RI" + Chr(13)
        MainForm.SendSerialData(getInputsString)
    End Sub
End Class