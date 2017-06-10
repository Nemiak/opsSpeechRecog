Option Explicit On
Imports Renci.SshNet

Module mod_connect
    Private webClient As New Net.WebClient

    Public Sub SshToPi(strCommandToSend As String, ByRef sett As VoiceSettings)

        Dim strAddress As String = sett.Settings(0).Name_or_IP_of_RaspberryPi
        Dim strName As String = sett.Settings(0).Raspi_LoginName
        Dim strPassword As String = sett.Settings(0).Raspi_LoginPassword

        Dim sshInfo As New PasswordConnectionInfo(strAddress, strName, strPassword)
        Dim sshClient As New SshClient(sshInfo)

        Dim rt As SshCommand

        Try
            sshClient.Connect()
            rt = sshClient.RunCommand(strCommandToSend)
            'Debug.Print(rt.Result)
            sshClient.Disconnect()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Fehler")
        End Try

    End Sub

    Public Sub CallWeb(strCommandToSend As String)

        Try
            webClient.OpenRead(strCommandToSend)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Fehler")
        End Try

    End Sub

End Module
