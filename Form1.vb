Option Explicit On
Imports System.Speech.Recognition
Imports System.Speech.Synthesis
Imports System.IO

Public Class Form1

    Public bReady As Boolean = False
    Private strGrFilename As String = Path.GetFullPath("grammar.xml")
    Private XMLActions As VoiceActions = Nothing
    Private XMLSettings As VoiceSettings = Nothing

    Private WithEvents mySTT As SpeechRecognitionEngine
    Private myTTS As New SpeechSynthesizer
    'Private webClient As New Net.WebClient

    Private Sub mySTT_SpeechDetected(ByVal sender As Object, ByVal e As SpeechDetectedEventArgs) Handles mySTT.SpeechDetected
        'irgendeine Erkennung
        pb_Status.BackColor = Color.Yellow
        pb_Status.Update()
        ''Timer neu starten
        'tmr_StayActive.Stop()
        'tmr_StayActive.Start()
    End Sub

    Private Sub mySTT_SpeechRecogReject(ByVal sender As Object, ByVal e As SpeechRecognitionRejectedEventArgs) Handles mySTT.SpeechRecognitionRejected
        'Erkennung fehlerhaft
        pb_Status.BackColor = Color.Red
        pb_Status.Update()
        rt_Out.AppendText(e.Result.Text + vbCr)
        rt_Out.Update()
        If bReady = True Then
            Select Case XMLSettings.Settings(0).AcousticFeedback
                Case 1
                    Console.Beep(1000, 50)
                    Console.Beep(800, 100)
                Case 2
                    Speak("Befehl nicht erkannt")
            End Select
            'Timer neu starten
            tmr_StayActive.Stop()
            tmr_StayActive.Start()
        End If
    End Sub

    Private Sub mySTT_SpeechRecognized(ByVal sender As Object, ByVal e As SpeechRecognizedEventArgs) Handles mySTT.SpeechRecognized
        'Erkennung erfolgreich
        Dim col As Color = pb_Status.BackColor
        pb_Status.BackColor = Color.Green
        pb_Status.Update()

        Dim strSTT As String = e.Result.Text
        Dim obj As String = ""
        Dim todo As String = ""
        Dim loc As String = ""

        'Debug.Print(e.Result.Semantics.Value.ToString)
        Debug.Print(strSTT)

        If bReady = False Then
            If e.Result.Semantics.Item("Object").Value.ToString = "ACTIVATE" Then
                bReady = True
                Speak("Bereit")
                pb_Active.BackColor = Color.Orange
                pb_Active.Update()
                tmr_StayActive.Start()
            Else
                'pb_Status.BackColor = col
                'pb_Status.Update()
            End If
            Exit Sub
        End If

        rt_Out.AppendText(strSTT)
        rt_Out.Update()

        Select Case e.Result.Words.Count 'e.Result.Semantics.Count
            Case 1
                obj = e.Result.Semantics.Item("Object").Value.ToString
            Case 2
                obj = e.Result.Semantics.Item("Object").Value.ToString
                todo = e.Result.Semantics.Item("Command").Value.ToString
            Case 3
                obj = e.Result.Semantics.Item("Object").Value.ToString
                todo = e.Result.Semantics.Item("Command").Value.ToString
                loc = e.Result.Semantics.Item("Location").Value.ToString
        End Select

        Dim cmd As String = obj
        If loc <> "" Then cmd += " " + loc
        cmd += " " + todo

        rt_Out.AppendText("  => " + cmd + vbCr)
        rt_Out.Update()

        If obj = "EXIT" Then
            Close()
            Exit Sub
        End If

        'Speak("Schalte " + obj + " " + loc + " " + todo)

        'entsprechende Funktion ermitteln
        Dim act As New Action

        If GetAction(UCase(cmd), act, XMLActions) = True Then
            Speak("Schalte " + cmd)
            Select Case act.Connect
                Case "SSH"
                    SshToPi(act.Command, XMLSettings)
                Case "WEB"
                    CallWeb(act.Command)
            End Select
        Else
            Select Case XMLSettings.Settings(0).AcousticFeedback
                Case 1
                    Console.Beep(1000, 50)
                    Console.Beep(800, 100)
                Case 2
                    Speak("Keine Aktion definiert")
            End Select
        End If

        'Timer neu starten
        tmr_StayActive.Stop()
        tmr_StayActive.Start()


        'webClient.OpenRead("http://raspi/LichtAn.php")
        'webClient.OpenRead("http://raspi/LichtAus.php")
        'webClient.OpenRead("http://remotepi/tvpower.php")
        'webClient.OpenRead("http://remotepi/tvvolumedown.php")
        'webClient.OpenRead("http://remotepi/tvvolumeup.php")
        'webClient.OpenRead("http://remotepi/tvmute.php")


    End Sub

    Private Sub frm_Main_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles Me.FormClosed
        If mySTT IsNot Nothing Then mySTT.Dispose()
    End Sub

    Private Sub ckb_StartSpeech_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ckb_StartSpeech.CheckedChanged

        If ckb_StartSpeech.Checked Then
            mySTT = New SpeechRecognitionEngine()
            Try
                mySTT.SetInputToDefaultAudioDevice()
            Catch
                MsgBox("Kein Micro gefunden", MsgBoxStyle.Critical, "Spracherkennung nicht möglich")
                ckb_StartSpeech.Checked = False
                Exit Sub
            End Try
            Dim grammar As New Grammar(strGrFilename, "Main")
            mySTT.UnloadAllGrammars()
            mySTT.LoadGrammar(grammar)
            mySTT.RecognizeAsync(RecognizeMode.Multiple)
            DisplayManual()
        Else
            'rt_Out.Clear()
            mySTT.Dispose()
            mySTT = Nothing
        End If

    End Sub

    Private Sub DisplayManual()
        Using sw As New StringWriter
            'sw.WriteLine("folgende Worte (Sätze) können erkannt werden:")
            'Dim xDoc = XDocument.Load(strGrFilename)
            'For Each xel In xDoc.Elements()(0).Elements()(0).Elements()(0).Elements()
            '    sw.WriteLine(xel.Value)
            'Next
            'sw.WriteLine("")
            'sw.WriteLine("Das Wort ""Beenden"" beendet das Programm")
            'rt_Out.Text = sw.ToString
            rt_Out.AppendText("Das Wort ""Beenden"" beendet das Programm." + vbCr)
            rt_Out.Update()
        End Using
    End Sub

    Private Sub frm_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        pb_Active.BackColor = Color.Gray
        pb_Active.Update()
        pb_Status.BackColor = Color.Gray
        pb_Status.Update()

        rt_Out.AppendText("Installierte Sprachstimmen: " + vbCr)
        For Each v In myTTS.GetInstalledVoices()
            rt_Out.AppendText(" - " + v.VoiceInfo.Name + vbCr)
            Debug.Print(v.VoiceInfo.Name)
        Next
        rt_Out.Update()

        XMLImportSettings(XMLSettings)
        tmr_StayActive.Interval = XMLSettings.Settings(0).WaitForVoiceCommand * 1000

        Me.Update()

        'Select Case XMLSettings.Settings(0).AcousticFeedback
        '    Case 1
        '        Console.Beep(800, 50)
        '        Console.Beep(900, 100)
        '        Console.Beep(1000, 100)
        '    Case 2
        '        Try
        '            myTTS.SelectVoice(XMLSettings.Settings(0).TTS_Voice)
        '            myTTS.Speak("Lade System")
        '        Catch ex As Exception
        '            MsgBox("Bitte in den Settings (""actions.xml"") die korrekte Stimme" + vbCr +
        '           "für die Sprachausgabe eintragen.", MsgBoxStyle.Exclamation, "Sprachausgabe nicht möglich")
        '        End Try
        'End Select

        XMLImportActions(XMLActions)

    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        Select Case XMLSettings.Settings(0).AcousticFeedback
            Case 1
                Console.Beep(800, 50)
                Console.Beep(900, 100)
                Console.Beep(1000, 100)
            Case 2
                Try
                    myTTS.SelectVoice(XMLSettings.Settings(0).TTS_Voice)
                    myTTS.Speak("Lade System")
                Catch ex As Exception
                    MsgBox("Bitte in den Settings (""actions.xml"") die korrekte Stimme" + vbCr +
                   "für die Sprachausgabe eintragen.", MsgBoxStyle.Exclamation, "Sprachausgabe nicht möglich")
                End Try
        End Select

    End Sub

    Private Sub Speak(strTextToSpeak As String)

        Select Case XMLSettings.Settings(0).AcousticFeedback
            Case 1
                Console.Beep(800, 50)
                Console.Beep(1000, 100)
            Case 2
                pb_Status.BackColor = Color.Gray
                pb_Status.Update()
                'Spracherkennung stoppen, damit SprachAUSGABE nicht als EINGABE erkannt wird
                mySTT.RecognizeAsyncStop()
                myTTS.Speak(strTextToSpeak)
                'Spracherkennung wieder starten
                mySTT.RecognizeAsync(RecognizeMode.Multiple)
        End Select

    End Sub

    Private Sub tmr_StayActive_Tick(sender As Object, e As EventArgs) Handles tmr_StayActive.Tick
        tmr_StayActive.Stop()
        bReady = False
        pb_Active.BackColor = Color.Gray
        pb_Active.Update()
    End Sub

End Class
