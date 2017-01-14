Module DBFunctions
    Private DBconnected As Boolean
    Private oConPrivate

    Public Function testConnectiivty()
        Dim strCon


        strCon = "Driver={Microsoft ODBC for Oracle}; " & _
                 "CONNECTSTRING=(DESCRIPTION=" & _
                 "(ADDRESS=(PROTOCOL=TCP)" & _
                 "(HOST=" & My.Settings.host & ")(PORT=" & My.Settings.port & "))" & _
                 "(CONNECT_DATA=(SERVICE_NAME=" & My.Settings.serviceName & "))); uid=" & My.Settings.user & ";pwd=" & My.Settings.password & ";"

        Dim oCon = CreateObject("ADODB.Connection")

        Dim oRs = CreateObject("ADODB.Recordset")
        Try
            oCon.Open(strCon)

            MsgBox("Success")
            oCon.Close()

        Catch ex As Exception
            MsgBox("Fail = " + ex.ToString)
        End Try
        Return 0
    End Function

    Public Function insertToDB(ByVal rollATFID As Integer, ByVal rollWidth As Integer, ByVal rollWeight As Integer, ByVal rollDiameter As Integer) As Integer
        Dim result As Integer
        Dim strSql As String
        Dim id As Double
        id = getMaxID() + 1
        strSql = "INSERT INTO PR_FYLWS_ATF_ROLLS " _
                 & "( ID,ATF_ID, ATF_ROLLID, ATF_roll_actual_widthmm, ATF_roll_actual_weight, ATF_roll_actual_diammm, ATF_dtIns, Flg_curState, Flg_manual_entry)" _
                 & "VALUES ( " & id & ", " _
                 & "'ATF01'" & ", " _
                 & rollATFID & ", " _
                 & rollWidth & ", " _
                 & rollWeight & ", " _
                 & rollDiameter & ", " _
                 & " SYSDATE, " _
                 & "0 , 0)"
        Dim Rs = CreateObject("ADODB.Recordset")
        If DBconnected Then
            'insert to DB

            Try
                LogForm.log1(strSql)
                Rs.Open(strSql, oConPrivate)
                'oConPrivate.close()
                'DBconnected = False

                result = 1
            Catch e As Exception
                'MsgBox(strSql) 
                LogForm.log1("Error in SQL")
                MsgBox(e.ToString)
                result = 2
            End Try

            'if success then result = 1
            'if failure to insert then result = 2
        Else
            'if not connected try to connect and attempt one more time to insert the values
            Dim conRes = connectToDB()

            If conRes = 0 Then 'if failure to connect
                result = 0
            Else
                insertToDB(rollATFID, rollWidth, rollWeight, rollDiameter)
            End If
        End If
        Return result
    End Function

    Public Function connectToDB() As Integer
        Dim strCon
        Dim result As Integer
        strCon = "Driver={Microsoft ODBC for Oracle}; " & _
                 "CONNECTSTRING=(DESCRIPTION=" & _
                 "(ADDRESS=(PROTOCOL=TCP)" & _
                 "(HOST=" & My.Settings.host & ")(PORT=" & My.Settings.port & "))" & _
                 "(CONNECT_DATA=(SERVICE_NAME=" & My.Settings.serviceName & "))); uid=" & My.Settings.user & ";pwd=" & My.Settings.password & ";"

        Dim oCon = CreateObject("ADODB.Connection")

        Dim oRs = CreateObject("ADODB.Recordset")
        Try
            oCon.Open(strCon)
            DBconnected = True
            result = 1
            oConPrivate = oCon
        Catch ex As Exception
            MainForm.writetoLog("Can not connect to DB " + ex.ToString)
            result = 0
        End Try
        Return result
    End Function


    Private Function getMaxID() As Double
        Dim result As Double
        Dim strSql As String

        strSql = "select nvl(max(id),0) from PR_FYLWS_ATF_ROLLS"

        Dim Rs = CreateObject("ADODB.Recordset")
        If DBconnected Then
            'insert to DB

            'Try
            Rs.Open(strSql, oConPrivate)
            'oConPrivate.close()
            'DBconnected = False

            result = Rs.Fields(0).Value
            '   Catch e As Exception
            '      MainForm.writetoLog(e.ToString)
            '     result = 2
            'End Try

            'if success then result = 1
            'if failure to insert then result = 2
        Else
            Dim conRes = connectToDB()

            If conRes = 0 Then 'if failure to connect
                result = 0
            Else
                getMaxID()
            End If

        End If


        Return result
    End Function

    Public Function insertEventToDB(ByVal rollATFID As String, ByVal EventType As Integer) As Integer
        Dim result As Integer
        Dim strSql As String
        Dim id As Double
        id = getEventMaxID() + 1
        strSql = "INSERT INTO pr_FYLWS_ATF_events " _
                 & "( EVENTID, ATF_ID, EVENT_TYPE, ATF_ROLLID, ATF_DTINS)" _
                 & "VALUES ( " & id & ", " _
                 & "ATF01," _
                 & EventType & "," _
                 & rollATFID & "," _
                 & " SYSDATE)"
        Dim Rs = CreateObject("ADODB.Recordset")
        If DBconnected Then
            'insert to DB

            Try
                Rs.Open(strSql, oConPrivate)
                'oConPrivate.close()
                'DBconnected = False
                result = 1
            Catch e As Exception
                'MsgBox(strSql)
                MainForm.writetoLog(strSql) 'e.ToString & " " & 
                result = 2
            End Try

            'if success then result = 1
            'if failure to insert then result = 2
        Else
            'if not connected try to connect and attempt one more time to insert the values
            Dim conRes = connectToDB()

            If conRes = 0 Then 'if failure to connect
                result = 0
            Else
                insertEventToDB(rollATFID, EventType)
            End If
        End If
        Return result
    End Function
    Private Function getEventMaxID() As Double
        Dim result As Double
        Dim strSql As String

        strSql = "select nvl(max(EVENTID),0) from pr_FYLWS_ATF_events"

        Dim Rs = CreateObject("ADODB.Recordset")
        If DBconnected Then
            'insert to DB

            'Try
            Rs.Open(strSql, oConPrivate)
            'oConPrivate.close()
            'DBconnected = False

            result = Rs.Fields(0).Value
            '   Catch e As Exception
            '      MainForm.writetoLog(e.ToString)
            '     result = 2
            'End Try

            'if success then result = 1
            'if failure to insert then result = 2
        Else
            Dim conRes = connectToDB()

            If conRes = 0 Then 'if failure to connect
                result = 0
            Else
                getEventMaxID()
            End If

        End If


        Return result
    End Function

    Public Function writePalletToDB(ByVal ATFPalletID As Integer, ByVal palletHeight As Integer, ByVal palletWidth As Integer, ByVal palletDepth As Integer, ByVal palletWeight As Integer, ByVal palletRollsNo As Integer, ByVal palletRollsWeight As Integer) As Integer
        Dim result As Integer
        Dim strSql As String
        Dim id As Double
        id = getPalletMaxID() + 1
        MainForm.CurrentPalletID = id
        strSql = "INSERT INTO pr_FYLWS_ATF_PltHdr " _
                 & "( pltID, ATF_ID, plt_ATFID, ATF_plt_height_mm, ATF_plt_Width_mm, ATF_plt_Depth_mm, ATF_plt_Weight_kg, ATF_plt_Rolls_no, ATF_plt_Rolls_weight, DTINS)" _
                 & "VALUES ( " & id & ", " _
                 & "ATF01," _
                 & ATFPalletID & "," _
                 & palletHeight & "," _
                 & palletWidth & "," _
                 & palletDepth & "," _
                 & palletWeight & "," _
                 & palletRollsNo & "," _
                 & palletRollsWeight & "," _
                 & " SYSDATE)"
        Dim Rs = CreateObject("ADODB.Recordset")
        If DBconnected Then
            'insert to DB
            Try
                Rs.Open(strSql, oConPrivate)
                result = 1
            Catch e As Exception
                'MsgBox(strSql)
                MainForm.writetoLog(strSql) 'e.ToString & " " & 
                result = 2
            End Try

            'if success then result = 1
            'if failure to insert then result = 2
        Else
            'if not connected try to connect and attempt one more time to insert the values
            Dim conRes = connectToDB()

            If conRes = 0 Then 'if failure to connect
                result = 0
            Else
                writePalletToDB(ATFPalletID, palletHeight, palletWidth, palletDepth, palletRollsWeight, palletRollsNo, palletRollsWeight)
            End If
        End If
        Return result
    End Function

    Public Function writePalletRollToDB(ByVal pltID As Integer, ByVal ATFpalletID As Integer, ByVal ATF_pltroll_AddressNo As Integer, ByVal ATF_pltroll_Number As Integer, ByVal ATF_pltroll_weight As Integer, ByVal ATF_pltrollID As Integer, ByVal ATF_pltroll_No_label As Integer) As Integer
        Dim result As Integer
        Dim strSql As String
        strSql = "INSERT INTO pr_FYLWS_ATF_PltRoll " _
                 & "( pltID, ATF_ID, ATF_pltID, ATF_pltroll_AddressNo, ATF_pltroll_Number, ATF_pltroll_weight, ATF_pltrollID, ATF_pltroll_No_label, DTINS)" _
                 & "VALUES ( " & pltID & ", " _
                 & "ATF01," _
                 & ATFpalletID & "," _
                 & ATF_pltroll_AddressNo & "," _
                 & ATF_pltroll_Number & "," _
                 & ATF_pltroll_weight & "," _
                 & ATF_pltrollID & "," _
                 & ATF_pltroll_No_label & "," _
                 & " SYSDATE)"
        Dim Rs = CreateObject("ADODB.Recordset")
        If DBconnected Then
            'insert to DB
            Try
                Rs.Open(strSql, oConPrivate)
                result = 1
            Catch e As Exception
                'MsgBox(strSql)
                MainForm.writetoLog(strSql) 'e.ToString & " " & 
                result = 2
            End Try

            'if success then result = 1
            'if failure to insert then result = 2
        Else
            'if not connected try to connect and attempt one more time to insert the values
            Dim conRes = connectToDB()

            If conRes = 0 Then 'if failure to connect
                result = 0
            Else
                writePalletRollToDB(pltID, ATFpalletID, ATF_pltroll_AddressNo, ATF_pltroll_Number, ATF_pltroll_weight, ATF_pltrollID, ATF_pltroll_No_label)
            End If
        End If
        Return result
    End Function

    Private Function getPalletMaxID() As Double
        Dim result As Double
        Dim strSql As String

        strSql = "select nvl(max(EVENTID),0) from pr_FYLWS_ATF_PltHdr"

        Dim Rs = CreateObject("ADODB.Recordset")
        If DBconnected Then
            'insert to DB

            'Try
            Rs.Open(strSql, oConPrivate)
            'oConPrivate.close()
            'DBconnected = False

            result = Rs.Fields(0).Value
            '   Catch e As Exception
            '      MainForm.writetoLog(e.ToString)
            '     result = 2
            'End Try

            'if success then result = 1
            'if failure to insert then result = 2
        Else
            Dim conRes = connectToDB()

            If conRes = 0 Then 'if failure to connect
                result = 0
            Else
                getPalletMaxID()
            End If

        End If


        Return result
    End Function
End Module
