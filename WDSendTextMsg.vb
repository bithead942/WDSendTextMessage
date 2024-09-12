Module Module1

    Sub Main(ByVal CmdArgs() As String)
        Dim i As Integer
        Dim mySMTPClient As SmtpClient = New SmtpClient
        Dim strMessage As String
        Dim Message As MailMessage = New MailMessage("Watchdog@VH.com", CmdArgs(0) & "@vtext.com")

        Message.Subject = "SECURITY WARNING"
        Message.Priority = MailPriority.High
        strMessage = ""
        mySMTPClient.Host = "smtp-server.cinci.rr.com"
        mySMTPClient.Port = 25
        If CmdArgs.Length > 0 Then
            For i = 1 To (CmdArgs.Length - 1)
                strMessage = strMessage & " " & CmdArgs(i)
            Next i
            Message.Body = strMessage
            Try
                mySMTPClient.Send(Message)
            Catch ex As Exception
                Exit Sub
            End Try
        End If
    End Sub

End Module
