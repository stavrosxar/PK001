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

    Public Function insertToDB(ByVal rollATFID As String, ByVal rollWidth As Double, ByVal rollWeight As Double, ByVal rollDiameter As Double) As Integer
        Dim result As Integer
        Dim strSql As String
        Dim id As Double
        id = getMaxID() + 1
        strSql = "INSERT INTO PR_FYLWS_ATF_ROLLS " _
                 & "( ID, ATF_DTINS, ATF_ROLLID, ATF_ROLL_ACTUAL_WEIGHT, ATF_ROLL_ACTUAL_DIAM, ATF_ROLL_ACTUAL_WIDTH, ATF_ROLL_ACTUAL_LENGTH, ATF_ID, FLG_CURSTATE)" _
                 & "VALUES ( " & id & ", " _
                 & " SYSDATE, " _
                 & id & ", " _
                 & rollWeight & ", " _
                 & rollDiameter & ", " _
                 & rollWidth & ", " _
                 & "'ATF01' , 0)"
        Dim Rs = CreateObject("ADODB.Recordset")
        If DBconnected Then
            'insert to DB

            Try
                Rs.Open(strSql, oConPrivate)
                'oConPrivate.close()
                'DBconnected = False
                result = 1
            Catch e As Exception
                MsgBox(strSql)
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
                insertToDB(rollATFID, rollWidth, rollWeight, rollDiameter)
            End If
        End If
        Return result
    End Function

    Private Function connectToDB() As Integer
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
                MsgBox(strSql)
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
                insertToDB(rollATFID, rollWidth, rollWeight, rollDiameter)
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
                getMaxID()
            End If

        End If


        Return result
    End Function
End Module
