Module DBFunctions
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
End Module
