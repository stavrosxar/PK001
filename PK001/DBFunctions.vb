Module DBFunctions
    Private DBconnected As Boolean

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

    Public Function insertToDB() As Integer
        Dim result As Integer
        'write code for inserting data to DB 
        'first test connectivity 
        If DBconnected Then
            'insert to DB
            'if success then result = 1
            'if failure then result = 2
        Else
            Dim conRes = connectToDB()
            If conRes = 0 Then
                result = 0
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
        Catch ex As Exception
            MainForm.writetoLog("Can not connect to DB " + ex.ToString)
            result = 0
        End Try
        Return result
    End Function
End Module
