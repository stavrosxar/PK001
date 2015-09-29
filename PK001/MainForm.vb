Imports DotNetSiemensPLCToolBoxLibrary.Communication
Imports DotNetSiemensPLCToolBoxLibrary.DataTypes
Imports DotNetSiemensPLCToolBoxLibrary
Imports Oracle.DataAccess.Client.OracleConnection

Public Class MainForm
    Dim myConn As New PLCConnection("ATF PLC Connection")
    Public blowStatus As Boolean
    Public suctionStatus As Boolean
    Public printerStatus As Integer
    Public applicationArmStatus As Integer
    Public applyLabelRequest As Boolean
    Dim applyLabelStatus As Integer '0 waiting to start
    '1 Step1 is finished (enable blower)
    '2 Step2 is finished (label has been detected on the pad)
    '3 Step3 is finished (Suction Enabled)
    '4 Step4 is finished (Blow disabled)
    '5 Step5 is finished (Cycle completed)
    '6 Error has occured


    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()

    End Sub

    Private Sub SerialCOMSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SerialCOMSettingsToolStripMenuItem.Click
        COMSettings.Show()
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EventLog.BeginInit()
        EventLog.Source = "PK-ATF"
    End Sub

    Private Sub PLCConnectionSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PLCConnectionSettingsToolStripMenuItem.Click
        Configuration.ShowConfiguration("ATF PLC Connection", True)

    End Sub


    Private Sub ComConn_Click(sender As Object, e As EventArgs) Handles PLCConn.Click
        If myConn.Connected Then
            Try
                myConn.Disconnect()
                PLCUpdate.Enabled = False
                PLCConn.Text = "Start PLC Communication"
            Catch ex1 As Exception
                MsgBox("There was a problem disconnecting. Please restart your program to reset connection")
                EventLog.WriteEntry("Problem at disconnection." + ex1.Message.ToString)
            End Try
        Else
                Try
                    myConn.Connect()
                PLCUpdate.Enabled = True
                PLCConn.Text = "Stop PLC Communication"
                Catch ex As Exception
                MsgBox("No connection could be made. Please check your settings")

                EventLog.WriteEntry("Problem at connection to PLC." + ex.Message.ToString)
                End Try
        End If
    End Sub

    Private Sub UIupdate_Tick(sender As Object, e As EventArgs) Handles UIupdate.Tick
        If myConn.Connected Then
            PLCConn.Text = "Disconnect"
            PLCConn.BackColor = Color.Lime
        Else
            PLCConn.Text = "Start PLC Communication"
            PLCConn.BackColor = Color.Silver
        End If
    End Sub

    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        myConn.Dispose()
        EventLog.Close()
    End Sub

    Private Sub PLCUpdate_Tick(sender As Object, e As EventArgs) Handles PLCUpdate.Tick
        Dim printReadyTag As New Communication.PLCTag("DB97.DBW50")
        printReadyTag.DataTypeStringFormat = TagDisplayDataType.Decimal
        If myConn.Connected Then
            myConn.ReadValue(printReadyTag)
            If printReadyTag.DataTypeStringFormat = 1 Then
                getValuesFromPLC()
            Else
                'exit sub
            End If

        Else
            PLCUpdate.Enabled = False
        End If
    End Sub

    Private Sub getValuesFromPLC()
        Dim success As Boolean
        Dim lst As New List(Of PLCTag)

        Dim rollWidth As New Communication.PLCTag("DB97.DBW24")

        Dim rollWeight As New Communication.PLCTag("DB97.DBD30")
        Dim rollDiameter As New Communication.PLCTag("DB97.DBW38")

        lst.Add(rollWidth)
        lst.Add(rollWeight)
        lst.Add(rollDiameter)
        Try
            myConn.ReadValues(lst)
            success = True
        Catch ex As Exception
            EventLog.WriteEntry("Cannot retrieve values from PLC Msg= " + ex.ToString)
            success = False
        End Try

        If success Then
            writeDatatoOracle(rollWidth.Value.ToString, rollWeight.Value.ToString, rollDiameter.Value.ToString)
        End If
        'TODO get the values from the PLC and store them in local variables also set a value that you had read the values 
        'at the end call the write to DB function
    End Sub

    Private Sub writeDatatoOracle(ByVal rollWidth As Integer, ByVal rollWeight As Double, ByVal rollDiameter As Integer)
        'TODO  connect to Oracle and send the query to database
        'then commit the changes
        'after that start the sequence for applying the label
        initiatePrintSeq()
    End Sub

    Private Sub dataReceived(sender As Object, e As IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort.DataReceived
        Try
            Dim incoming As String = SerialPort.ReadLine
            ReceiveTxt.Text = incoming
            SerialInputManipulation(incoming)
        Catch ex As Exception
            EventLog.WriteEntry("Cannot read Serial Port. Msg=" + ex.ToString)
            Exit Sub
        Finally
            If SerialPort IsNot Nothing Then
                SerialPort.Close()
            End If
        End Try
    End Sub

    Public Sub SendSerialData(ByVal str As String)
        If SerialPort Is Nothing Then
            MsgBox("No serial port detected. Please check settings")
            Exit Sub
        End If

        If SerialPort.IsOpen Then
            Try
                SendTxt.Text = str
                SerialPort.WriteLine(str)
            Catch ex As Exception
                EventLog.WriteEntry("Cannot write to Serial Port. Msg =" + ex.ToString)
                MsgBox("Cannot write to Serial Port. Msg =" + ex.ToString)
                SerialPort.Close()

            End Try
        Else
            Try
                SerialPort.Open()
                SendSerialData(str)

            Catch ex1 As Exception
                MsgBox("Cannot open serial port")
            End Try
        End If

    End Sub

    Private Sub SerialInputManipulation(ByVal str As String)
        Dim typeofReply As String = str.Substring(0, 4)


        'Standar and typical replies
        Select Case str
            Case "|01SO0" + Chr(13) ' blow is disabled
                blowStatus = False
                If applyLabelRequest Then
                    applyLabelStatus = 4
                    initiatePrintSeq()
                End If
            Case "|01SO1" + Chr(13) ' blow is enabled
                blowStatus = True
                'incase that a request for apply a new label is there then
                If applyLabelRequest Then
                    'move to the the next step
                    applyLabelStatus = 1
                    initiatePrintSeq()
                End If
            Case "|01AS0" + Chr(13) ' suction is bisabled
                suctionStatus = False
            Case "|01AS1" + Chr(13) ' suction is enabled
                suctionStatus = True
                If applyLabelRequest Then
                    applyLabelStatus = 3
                    initiatePrintSeq()
                End If
        End Select

        If typeofReply = "|01ST" Then
            'this is a status message .
            'Take the next parts of str and evaluate
            Dim printerStatusStr As String = GetChar(str, 6)
            Select Case printerStatusStr
                Case "0"
                    printerStatus = 0 ' Printer OK.The application arm is in start position
                Case "1"
                    printerStatus = 1 ' Error during return
                Case "2"
                    printerStatus = 2 'Error during forward movement
                Case "3"
                    printerStatus = 3 'No label on the pad
                Case "4"
                    printerStatus = 4 'Object not found
                Case "A"
                    printerStatus = 5 'Cycle completed
            End Select

            'if for any reason the printer is in error mode then we must reset the error and then send any other command
            'Also exit this evaluation procedure
            If printerStatus > 0 And printerStatus < 5 Then
                SendSerialData("|01RE" + Chr(13))
                Exit Sub
            End If

            Dim applicationArmStatusStr As String = GetChar(str, 7)
            Select Case applicationArmStatusStr
                Case "0"
                    applicationArmStatus = 0 'Application arm is in start position and ok
                Case "1"
                    applicationArmStatus = 1 'Application arm is returning
                Case "2"
                    applicationArmStatus = 2 ' Arm back in start position
                Case "3"
                    applicationArmStatus = 3 'Arm is moving forward
                Case "4"
                    applicationArmStatus = 4 'Arm at the end of the run
                Case "5"
                    applicationArmStatus = 5 'Arm has found the object
            End Select

            If (str = "|01ST020" Or str = "|01STA20") And applyLabelRequest Then
                applyLabelStatus = 5
                'if we need to update something this is the trigger
                initiatePrintSeq() ' this 
            End If

        End If

        'TODO check the comment in teamwork
        If str = "|01RE" + Chr(13) Then 'if we receive a message that a alarm reset has been applied then request a status update
            Dim getStatusString = "|01ST" + Chr(13)
            SendSerialData(getStatusString)
        End If

        If typeofReply = "|01RI" Then
            'TODO check the return of the printer for the status of the inputs and then implement this part of the code

            'the following code has to change in the if-section so it an match the inputs of the printer
            Dim HEXcodeOfInputs As String = str.Substring(6, 2)
            Dim DECcodeofInputs = Convert.ToInt32(HEXcodeOfInputs, 16)
            If applyLabelRequest Then
                If DECcodeofInputs = 1 Then
                    'this means that a label is on pad so we can continue
                    applyLabelStatus = 2
                    initiatePrintSeq()
                    checkForLabelTimer.Enabled = False
                Else
                    'start a 2sec loop for checking the status of the inputs until label is on the pad
                    'or a specific ammount of tries has passed i.e 20 times = 20 x 2 sec = 40sec waiting for 
                    checkForLabelTimer.Enabled = True
                End If

            End If

        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PrinterManual.Show()
    End Sub

    Public Sub initiatePrintSeq()
        If applyLabelRequest = False Then
            Exit Sub
        End If
        If applyLabelRequest And applyLabelStatus = 0 Then
            'send command to enable blower 
            SendSerialData("|01SO1" + Chr(13))
        End If

        If applyLabelRequest And applyLabelStatus = 1 Then
            'send command to check for label on pad
            SendSerialData("|01RI" + Chr(13))
        End If

        If applyLabelRequest And applyLabelStatus = 2 Then
            'send command to enable suction
            SendSerialData("|01AS01" + Chr(13))
        End If
        If applyLabelRequest And applyLabelStatus = 3 Then
            'send command to disable blow
            SendSerialData("|01SO0" + Chr(13))
        End If
        If applyLabelRequest And applyLabelStatus = 4 Then
            'send command to start application cycle
            SendSerialData("|01AENI" + Chr(13))
        End If
        If applyLabelRequest And applyLabelStatus = 5 Then
            'if we need to trigger something this is the trigger

            Dim val1 As New Communication.PLCTag("DB98.DBW0")
            val1.Controlvalue = 0
            Try
                myConn.WriteValue(val1)
            Catch ex As Exception

            End Try
            applyLabelStatus = 0
            applyLabelRequest = False
        End If

    End Sub

    Private Sub checkForLabelTimer_Tick(sender As Object, e As EventArgs) Handles checkForLabelTimer.Tick
        SendSerialData("|01RI" + Chr(13))
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim strCon


        strCon = "Driver={Microsoft ODBC for Oracle}; " & _
                 "CONNECTSTRING=(DESCRIPTION=" & _
                 "(ADDRESS=(PROTOCOL=TCP)" & _
                 "(HOST=WIN7-VM-SCS)(PORT=1521))" & _
                 "(CONNECT_DATA=(SERVICE_NAME=XE))); uid=test;pwd=1234;"

        Dim oCon = CreateObject("ADODB.Connection")

        Dim oRs = CreateObject("ADODB.Recordset")
        Try
            oCon.Open(strCon)
            MsgBox("Success")

        Catch ex As Exception
            MsgBox("Fail = " + ex.ToString)

        End Try

    End Sub
End Class
