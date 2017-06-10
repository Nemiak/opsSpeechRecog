Option Explicit On
Imports System.IO
Imports System.Xml.Serialization

Module mod_XMLFuncts
    Public Sub XMLImportActions(ByRef acts As VoiceActions)

        Dim path As String = "actions.xml"
        Dim serializer As New XmlSerializer(GetType(VoiceActions))
        Dim reader As New StreamReader(path)
        acts = DirectCast(serializer.Deserialize(reader), VoiceActions)
        reader.Close()

    End Sub

    Public Sub XMLImportSettings(ByRef sett As VoiceSettings)

        Dim path As String = "actions.xml"
        Dim serializer As New XmlSerializer(GetType(VoiceSettings))
        Dim reader As New StreamReader(path)
        sett = DirectCast(serializer.Deserialize(reader), VoiceSettings)
        reader.Close()

    End Sub

    Public Function GetAction(strVoiceCommand As String, ByRef act As Action, ByRef acts As VoiceActions) As Boolean

        For i As Integer = 0 To acts.Action.Count - 1
            If UCase(acts.Action(i).Voice) = strVoiceCommand Then
                act.Connect = acts.Action(i).Connect
                act.Command = acts.Action(i).Command
                Return True
            End If
        Next

        Return False

    End Function

End Module
