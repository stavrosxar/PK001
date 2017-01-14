Imports DotNetSiemensPLCToolBoxLibrary.Communication
Imports DotNetSiemensPLCToolBoxLibrary.DataTypes
Imports DotNetSiemensPLCToolBoxLibrary


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
    Dim labelCheckCounter As Integer
    Dim timer100sec As Boolean
    Dim timer1sec As Boolean
    Dim CommandSend As Boolean
    Dim rollUnderPrinter As Boolean
    Dim palletisbeingread As Boolean
    Dim CurrentRollID As Integer
    Dim CurrentATFPalletID As Integer
    Public CurrentPalletID As Integer


    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()

    End Sub

    Private Sub SerialCOMSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SerialCOMSettingsToolStripMenuItem.Click
        COMSettings.Show()
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EventLog.BeginInit()
        EventLog.Source = "PK-ATF"
        labelCheckCounter = 0
        DBFunctions.connectToDB()
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
                'PalletUpdate.Enabled = True
                LogForm.log1("Enable PLC Update")
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
        Dim printReadyTag As New Communication.PLCTag("DB98.DBW0")
        printReadyTag.DataTypeStringFormat = TagDisplayDataType.Decimal
        If myConn.Connected Then
            myConn.ReadValue(printReadyTag)

            If rollUnderPrinter Then
                Exit Sub
            End If
            If printReadyTag.Value = 1 Then
                rollUnderPrinter = True
                LogForm.log1("New Roll Detected")
                LogForm.log1("Roll Under Printer = " & printReadyTag.Value)
                getValuesFromPLC()
            Else
                'rollUnderPrinter = False
            End If

        Else
            PLCUpdate.Enabled = False
        End If
    End Sub

    Private Sub getValuesFromPLC()
        Dim success As Boolean
        Dim lst As New List(Of PLCTag)

        Dim rollATFID As New Communication.PLCTag("DB97.DBD0")
        rollATFID.TagDataType = TagDataType.Int
        Dim rollWidth As New Communication.PLCTag("DB97.DBW2")
        rollWidth.TagDataType = TagDataType.Int
        'Dim rollLength As New Communication.PLCTag("DB97.DBD26")


        Dim rollWeight As New Communication.PLCTag("DB97.DBD4")
        rollWeight.TagDataType = TagDataType.Float
        Dim rollDiameter As New Communication.PLCTag("DB97.DBW8")
        rollDiameter.TagDataType = TagDataType.Int

        lst.Add(rollATFID)
        lst.Add(rollWidth)
        'lst.Add(rollLength)
        lst.Add(rollWeight)
        lst.Add(rollDiameter)
        Try
            myConn.ReadValues(lst)
            success = True
            CurrentRollID = rollATFID.ValueAsString
            LogForm.log1("ATFID = " & rollATFID.Value)
            LogForm.log1("Width = " & rollWidth.Value)
            LogForm.log1("Weight = " & rollWeight.Value)
            LogForm.log1("Diameter = " & rollDiameter.Value)
        Catch ex As Exception
            EventLog.WriteEntry("Cannot retrieve values from PLC Msg= " + ex.ToString)
            success = False
        End Try

        If success Then
            writeDatatoOracle(rollATFID.ValueAsString, rollWidth.Value, rollWeight.Value, rollDiameter.Value)
        End If
      
    End Sub

    Private Sub writeDatatoOracle(ByVal rollATFID As String, ByVal rollWidth As Integer, ByVal rollWeight As Double, ByVal rollDiameter As Integer)
        'TODO  connect to Oracle and send the query to database
        'then commit the changes
        'after that start the sequence for applying the label
        Dim conResult = DBFunctions.insertToDB(rollATFID, rollWidth, rollWeight, rollDiameter)
        If conResult = 2 Then
            MsgBox("Problem inserting data to Database")
            writetoLog("Problem inserting data to Database")
            '---test
            rollUnderPrinter = False
            WriteResultToPLC(0, 1, 2)
            LogForm.log1("Error In DB")
            LogForm.log1("Waiting for new roll")
            Exit Sub
        End If
        If conResult = 0 Then
            MsgBox("Problem connecting to Database")
            '--test
            rollUnderPrinter = False
            WriteResultToPLC(0, 1, 2)
            LogForm.log1("Error In DB")
            LogForm.log1("Waiting for new roll")
            Exit Sub
        End If
        LogForm.log1("Write to DB completed")
        applyLabelRequest = True
        CommandSend = False
      
        'initiatePrintSeq()
    End Sub

    Private Sub writeEventToOracle(ByVal rollATFID As String, ByVal EventType As Integer)
        Dim conResult = DBFunctions.insertEventToDB(rollATFID, EventType)
        If conResult = 2 Then
            'MsgBox("Problem inserting data to Database")
            LogForm.log1("Problem writing event to Database")
            Exit Sub
        End If
        If conResult = 0 Then
            LogForm.log1("Problem connecting to Database")
            Exit Sub
        End If
    End Sub

    Private Sub dataReceived(sender As Object, e As IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort.DataReceived
        Try
            Dim incoming As String = SerialPort.ReadExisting
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
                ' MsgBox("Cannot open serial port")
            End Try
        End If

    End Sub

    Private Sub SerialInputManipulation(ByVal str As String)
        Dim typeofReply As String = str.Substring(0, 5)

        'MsgBox(str)
        'Standar and typical replies
        LogForm.log1("Reply =" & typeofReply & "SubString =" & str)
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
                    StatusStrip.Text = "Printer OK.The application arm is in start position"
                Case "1"
                    printerStatus = 1 ' Error during return
                    StatusStrip.Text = "Error during return"
                    applyLabelRequest = False
                Case "2"
                    printerStatus = 2 'Error during forward movement
                    StatusStrip.Text = "Error during forward movement"
                    applyLabelRequest = False
                Case "3"
                    printerStatus = 3 'No label on the pad
                    applyLabelRequest = False
                    applyLabelStatus = 0
                    StatusStrip.Text = "No label on the pad"
                Case "4"
                    printerStatus = 4 'Object not found
                    StatusStrip.Text = "Object not found"
                    applyLabelRequest = False
                Case "A"
                    printerStatus = 5 'Cycle completed
                    StatusStrip.Text = "Cycle completed"
            End Select

            'if for any reason the printer is in error mode then we must reset the error and then send any other command
            'Also exit this evaluation procedure
            If printerStatus > 0 And printerStatus < 5 Then
                SendSerialData("|01RE" + Chr(13))
                'in case of failure during going down or not finding a roll inform PLC
                If printerStatus = 2 Or printerStatus = 4 Then
                    Dim val1 As New Communication.PLCTag("DB98.DBW20")
                    Dim val2 As New Communication.PLCTag("DB98.DBW22") 'error in printing tag
                    val1.Controlvalue = 0
                    val2.Controlvalue = 1
                    writeEventToOracle(CurrentRollID, 2)
                    Try
                        myConn.WriteValue(val1)
                        myConn.WriteValue(val2)
                    Catch ex As Exception

                    End Try
                    applyLabelStatus = 0
                    LogForm.log1("Waiting for new roll")
                    LabelStatusTxt.Text = "Cycle completed with error. Waiting for new roll"
                End If
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

            If (str = "|01ST020" Or str = "|01STA20" Or str = "|01ST320" Or str = "|01AENI" + Chr(13)) And applyLabelRequest Then
                applyLabelStatus = 5
                'if we need to update something this is the trigger
                initiatePrintSeq() ' this 


            End If

        End If
        If (str = "|01AENI" + Chr(13) Or str = "|01ST020" + Chr(13)) And applyLabelRequest Then
            applyLabelStatus = 5
            'if we need to update something this is the trigger
            initiatePrintSeq() ' this 


        End If

        'TODO check the comment in teamwork
        If str = "|01RE" + Chr(13) Then 'if we receive a message that a alarm reset has been applied then request a status update
            Dim getStatusString = "|01ST" + Chr(13)
            SendSerialData(getStatusString)
            If applyLabelStatus > 0 Then
                applyLabelStatus = 0
            End If
        End If

        If typeofReply = "|01RI" Then
            Dim HEXcodeOfInputs As String = str.Substring(6, 2)
            ' debug code leave it as it is
            ' Dim DECcodeofInputs = Convert.ToInt32(HEXcodeOfInputs, 16)
            ' MsgBox(HEXcodeOfInputs)
            LogForm.log1("Input= " & HEXcodeOfInputs)
            If applyLabelRequest Then
                If HEXcodeOfInputs = 5 Then
                    'this means that a label is on pad so we can continue
                    applyLabelStatus = 2
                    initiatePrintSeq()
                    checkForLabelTimer.Enabled = False
                    labelCheckCounter = 0
                Else
                    'start a 1sec loop for checking the status of the inputs until label is on the pad
                    'or a specific ammount of tries has passed i.e 20 times = 15 x 1 sec = 15sec waiting for 
                    If checkForLabelTimer.Enabled = False Then
                        checkForLabelTimer.Enabled = True
                        LogForm.log1("Check for label enabled")
                    End If
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
        Label2.Text = applyLabelStatus
        If applyLabelRequest And applyLabelStatus = 0 Then
            'send command to enable blower 
            SendSerialData("|01SO1" + Chr(13))
            LabelStatusTxt.Text = "send command to enable blower "
            TimerTick1sec.Enabled = True
            'Exit Sub
        End If

        If applyLabelRequest And applyLabelStatus = 1 And timer100sec Then
            'send command to check for label on pad
            SendSerialData("|01RI" + Chr(13))
            LabelStatusTxt.Text = "send command to check for label on pad"

        End If

        If applyLabelRequest And applyLabelStatus = 2 And timer1sec Then
            'send command to enable suction
            TimerTick1sec.Enabled = False
            SendSerialData("|01AS1" + Chr(13))
            LabelStatusTxt.Text = "send command to enable suction"
            Exit Sub
        End If

        If applyLabelRequest And applyLabelStatus = 3 And timer1sec Then
            'send command to disable blow
            SendSerialData("|01SO0" + Chr(13))
            LabelStatusTxt.Text = "send command to disable blow"
            Exit Sub
        End If
        If applyLabelRequest And applyLabelStatus = 4 And timer1sec And CommandSend = False Then
            'send command to start application cycle
            SendSerialData("|01AENI" + Chr(13))
            'SendSerialData("|01ST" + Chr(13))
            CommandSend = True
            LabelStatusTxt.Text = "send command to start application cycle"
        End If
        If applyLabelRequest And applyLabelStatus = 4 And timer1sec And CommandSend = True Then
            'send command to start application cycle
            SendSerialData("|01ST" + Chr(13))
            LabelStatusTxt.Text = "send command to start application cycle"
        End If
        If applyLabelRequest And applyLabelStatus = 5 And timer1sec Then
            'if we need to trigger something this is the trigger
            LabelStatusTxt.Text = "Ended cycle"
            'write succesfull end of cycle
            Dim val1 As New Communication.PLCTag("DB98.DBW20")
            Dim val2 As New Communication.PLCTag("DB98.DBW22")
            val1.Controlvalue = 1
            val2.Controlvalue = 0
            writeEventToOracle(CurrentRollID, 1)
            Try
                myConn.WriteValue(val1)
                myConn.WriteValue(val2)
            Catch ex As Exception

            End Try
            applyLabelStatus = 0
            Label2.Text = applyLabelStatus
            'reset label request
            applyLabelRequest = False
            'listen again for new roll under printer
            rollUnderPrinter = False
            'reset any errors if any
            SendSerialData("|01RE" + Chr(13))
        End If

    End Sub

    Private Sub checkForLabelTimer_Tick(sender As Object, e As EventArgs) Handles checkForLabelTimer.Tick
        SendSerialData("|01RI" + Chr(13))
        labelCheckCounter = labelCheckCounter + 1
        StatusStrip.Text = "Waiting for label on pad"

        LogForm.log1("Waiting sec = " & labelCheckCounter)
        If labelCheckCounter = 15 Then
            applyLabelRequest = False
            applyLabelStatus = 0
            StatusStrip.Text = "No label found on the pad after 15 seconds"

            LogForm.log1("No label found on the pad after 15 seconds")
            LogForm.log1("Waiting for new roll")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles oracleTestbtn.Click
        DBFunctions.testConnectiivty()

    End Sub

    Private Sub OracleDBConnectionSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OracleDBConnectionSettingsToolStripMenuItem.Click
        DBSettings.Show()
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        applyLabelRequest = True
        CommandSend = False
        initiatePrintSeq()


    End Sub


    Public Function writetoLog(ByVal str As String)
        ' EventLog.WriteEntry(str)
        Return 0
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim conResult = DBFunctions.insertToDB(1111, 100, 100, 100)
        'evaluate result
        Select Case conResult
            Case 0
                StatusStrip.Text = "Failed to connect to Database. Review Log"
                StatusStrip.BackColor = Color.Red
            Case 1
                StatusStrip.Text = "Transaction with Database succesfull"
                StatusStrip.BackColor = Color.Green
            Case 2
                StatusStrip.Text = "Failed to finish transaction. Review Log"
                StatusStrip.BackColor = Color.Red
        End Select


    End Sub

    Private Sub TimerTick1sec_Tick(sender As Object, e As EventArgs) Handles TimerTick1sec.Tick
        If timer100sec Then
            timer100sec = False
            Label1.Text = "0"
        Else
            timer100sec = True
            Label1.Text = "1"
            initiatePrintSeq()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If timer1sec Then
            timer1sec = False

        Else
            timer1sec = True

            initiatePrintSeq()
        End If
    End Sub

    Private Sub PalletUpdate_Tick(sender As Object, e As EventArgs) Handles PalletUpdate.Tick
        Dim paletReadyTag As New Communication.PLCTag("DB98.DBW10")
        paletReadyTag.TagDataType = TagDataType.Int
        If myConn.Connected Then
            myConn.ReadValue(paletReadyTag)
            If palletisbeingread Then
                Exit Sub
            End If
            If paletReadyTag.Value = 1 Then
                palletisbeingread = True
                readPallet()
            Else
                'exit sub
            End If

        Else
            PalletUpdate.Enabled = False
        End If

    End Sub

    Private Sub readPallet()

        'TODO
        'Write code to handle reading of pallet data
        Dim success As Boolean
        Dim successRoll As Boolean
        Dim numberOfRollsOnPallet As Integer
        Dim lst As New List(Of PLCTag)

        Dim palletCode As New Communication.PLCTag("DB910.DBB0")
        palletCode.TagDataType = TagDataType.CharArray
        palletCode.ArraySize = 20
        Dim palletNumber As New Communication.PLCTag("DB910.DBW22")
        palletNumber.TagDataType = TagDataType.Int
        Dim palletHeight As New Communication.PLCTag("DB910.DBW24")
        palletHeight.TagDataType = TagDataType.Int
        Dim palletWidth As New Communication.PLCTag("DB910.DBW26")
        palletWidth.TagDataType = TagDataType.Int
        Dim palletDepth As New Communication.PLCTag("DB910.DBW28")
        palletDepth.TagDataType = TagDataType.Int
        Dim palletWeight As New Communication.PLCTag("DB910.DBW30")
        palletWeight.TagDataType = TagDataType.Int
        Dim palletRollsWeight As New Communication.PLCTag("DB910.DBW32")
        palletRollsWeight.TagDataType = TagDataType.Int
        Dim palletRollsNumber As New Communication.PLCTag("DB910.DBW34")
        palletRollsNumber.TagDataType = TagDataType.Int
        Dim palletID As New Communication.PLCTag("DB910.DBW48")
        palletID.TagDataType = TagDataType.Int


        
        lst.Add(palletCode)
        lst.Add(palletNumber)
        lst.Add(palletHeight)
        lst.Add(palletWidth)
        lst.Add(palletDepth)
        lst.Add(palletWeight)
        lst.Add(palletRollsWeight)
        lst.Add(palletRollsNumber)
        lst.Add(palletID)

        Try
            myConn.ReadValues(lst)
            success = True
            CurrentATFPalletID = palletID.Value
            numberOfRollsOnPallet = palletRollsNumber.Value
            writePalletToOracle("ATF01", palletID.Value, palletHeight.Value, palletWidth.Value, palletDepth.Value, palletWeight.Value, palletRollsNumber.Value, palletRollsWeight.Value)
        Catch ex As Exception
            EventLog.WriteEntry("Cannot retrieve values from PLC Msg= " + ex.ToString)
            success = False
        End Try

        If success Then
            'Code for reading all rolls on pallet
            'Loop for to number of occupied positions
            Dim lstRolls As New List(Of PLCTag)
            Dim startAddress As Integer = 50 'Starting  Adress
            Dim offsetPerRoll As Integer = 54 'Offset per Roll for looping in memory areas
            For i As Integer = 0 To numberOfRollsOnPallet - 1 Step 1
                Dim rollNumber As New Communication.PLCTag("DB910.DBW" & (startAddress + 22) + (offsetPerRoll * i))
                rollNumber.TagDataType = TagDataType.Int
                Dim rollWeight As New Communication.PLCTag("DB910.DBD" & (startAddress + 24) + (offsetPerRoll * i))
                rollWeight.TagDataType = TagDataType.Float
                Dim rollWidth As New Communication.PLCTag("DB910.DBW" & (startAddress + 28) + (offsetPerRoll * i))
                rollWidth.TagDataType = TagDataType.Int
                Dim rollDiameter As New Communication.PLCTag("DB910.DBW" & (startAddress + 36) + (offsetPerRoll * i))
                rollDiameter.TagDataType = TagDataType.Int
                Dim rollID As New Communication.PLCTag("DB910.DBW" & (startAddress + 46) + (offsetPerRoll * i))
                rollID.TagDataType = TagDataType.Int
                Dim rollPalletNumber As New Communication.PLCTag("DB910.DBW" & (startAddress + 48) + (offsetPerRoll * i))
                rollPalletNumber.TagDataType = TagDataType.Int
                Dim rollLabel As New Communication.PLCTag("DB910.DBW" & (startAddress + 50) + (offsetPerRoll * i))
                rollLabel.TagDataType = TagDataType.Int

                lstRolls.Add(rollNumber)
                lstRolls.Add(rollWeight)
                lstRolls.Add(rollWidth)
                lstRolls.Add(rollDiameter)
                lstRolls.Add(rollID)
                lstRolls.Add(rollPalletNumber)
                lstRolls.Add(rollLabel)

                Try
                    myConn.ReadValues(lstRolls)
                    successRoll = True
                Catch ex As Exception
                    EventLog.WriteEntry("Cannot retrieve values from PLC Msg= " + ex.ToString)
                    successRoll = False
                End Try

                If successRoll Then
                    writePalletRollToOracle(CurrentPalletID, "ATF01", CurrentATFPalletID, i, rollNumber.Value, rollWeight.Value, rollID.Value, rollLabel.Value)
                End If



            Next

            'when finished reading pallet data re-enable the reading function and infrom PLC
            palletisbeingread = False

            'finished reading pallet. Inform PLC
            Dim val1 As New Communication.PLCTag("DB98.DBW30")
            val1.Controlvalue = 1
            Try
                myConn.WriteValue(val1)
            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub writePalletToOracle(ByVal ATFID As String, ByVal ATFPalletID As Integer, ByVal PalletHeight As Integer, ByVal PalletWidth As Integer, ByVal PalletDepth As Integer, ByVal PalletWeight As Integer, ByVal PalletRollsNo As Integer, ByVal PalletRollsWeight As Integer)
        Dim conResult = DBFunctions.writePalletToDB(ATFPalletID, PalletHeight, PalletWidth, PalletDepth, PalletWeight, PalletRollsNo, PalletRollsWeight)
        If conResult = 2 Then
            'MsgBox("Problem inserting data to Database")
            writetoLog("Problem writing event to Database")
            Exit Sub
        End If
        If conResult = 0 Then
            writetoLog("Problem connecting to Database")
            Exit Sub
        End If
    End Sub

    Private Sub writePalletRollToOracle(ByVal palletOracleID As Integer, ByVal ATFID As String, ByVal ATFPalletID As Integer, ByVal rollAdressNo As Integer, ByVal rollNo As Integer, ByVal rollWeight As Integer, ByVal rollID As Integer, ByVal rollLabel As Integer)
        Dim conResult = DBFunctions.writePalletRollToDB(palletOracleID, ATFPalletID, rollAdressNo, rollNo, rollWeight, rollID, rollLabel)
        If conResult = 2 Then
            'MsgBox("Problem inserting data to Database")
            writetoLog("Problem writing event to Database")
            Exit Sub
        End If
        If conResult = 0 Then
            writetoLog("Problem connecting to Database")
            Exit Sub
        End If
    End Sub

    Private Sub ShowLogToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowLogToolStripMenuItem.Click
        LogForm.Show()
    End Sub

    Private Sub WriteResultToPLC(ByVal LabelOK As Integer, ByRef LabelNotOK As Integer, ByVal EventID As Integer)
        Dim val1 As New Communication.PLCTag("DB98.DBW20")
        Dim val2 As New Communication.PLCTag("DB98.DBW22")
        val1.Controlvalue = LabelOK
        val2.Controlvalue = LabelNotOK
        If LabelNotOK = 1 Or LabelOK = 1 Then
            writeEventToOracle(CurrentRollID, EventID)
        End If
        Try
            myConn.WriteValue(val1)
            myConn.WriteValue(val2)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        WriteResultToPLC(0, 0, 1)
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click

    End Sub
End Class
