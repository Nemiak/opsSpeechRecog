Imports System.Xml.Serialization

<Serializable()>
Public Class Action
    <XmlElement("Voice")>
    Public Property Voice() As String
        Get
            Return m_Voice
        End Get
        Set
            m_Voice = Value
        End Set
    End Property
    Private m_Voice As String

    <XmlElement("Connect")>
    Public Property Connect() As String
        Get
            Return m_Connect
        End Get
        Set
            m_Connect = Value
        End Set
    End Property
    Private m_Connect As String

    <XmlElement("Command")>
    Public Property Command() As String
        Get
            Return m_Command
        End Get
        Set
            m_Command = Value
        End Set
    End Property
    Private m_Command As String
End Class

<XmlRoot("VoiceActions")>
Public Class VoiceActions
    <XmlArray("Actions")>
    <XmlArrayItem("Action", GetType(Action))>
    Public Property Action() As Action()
        Get
            Return m_Action
        End Get
        Set
            m_Action = Value
        End Set
    End Property
    Private m_Action As Action()

End Class

<Serializable()>
Public Class Settings
    <XmlElement("Name_or_IP_of_RaspberryPi")>
    Public Property Name_or_IP_of_RaspberryPi() As String
        Get
            Return m_Name_or_IP_of_RaspberryPi
        End Get
        Set
            m_Name_or_IP_of_RaspberryPi = Value
        End Set
    End Property
    Private m_Name_or_IP_of_RaspberryPi As String

    <XmlElement("Raspi_LoginName")>
    Public Property Raspi_LoginName() As String
        Get
            Return m_Raspi_LoginName
        End Get
        Set
            m_Raspi_LoginName = Value
        End Set
    End Property
    Private m_Raspi_LoginName As String

    <XmlElement("Raspi_LoginPassword")>
    Public Property Raspi_LoginPassword() As String
        Get
            Return m_Raspi_LoginPassword
        End Get
        Set
            m_Raspi_LoginPassword = Value
        End Set
    End Property
    Private m_Raspi_LoginPassword As String

    <XmlElement("TTS_Voice")>
    Public Property TTS_Voice() As String
        Get
            Return m_TTS_Voice
        End Get
        Set
            m_TTS_Voice = Value
        End Set
    End Property
    Private m_TTS_Voice As String

    <XmlElement("WaitForVoiceCommand")>
    Public Property WaitForVoiceCommand() As Integer
        Get
            Return m_WaitForVoiceCommand
        End Get
        Set
            m_WaitForVoiceCommand = Value
        End Set
    End Property
    Private m_WaitForVoiceCommand As Integer

    <XmlElement("AcousticFeedback")>
    Public Property AcousticFeedback() As Integer
        Get
            Return m_AcousticFeedback
        End Get
        Set
            m_AcousticFeedback = Value
        End Set
    End Property
    Private m_AcousticFeedback As Integer

End Class

<XmlRoot("VoiceActions")>
Public Class VoiceSettings
    <XmlArray("Settings")>
    <XmlArrayItem("MySettings", GetType(Settings))>
    Public Property Settings() As Settings()
        Get
            Return m_Settings
        End Get
        Set
            m_Settings = Value
        End Set
    End Property
    Private m_Settings As Settings()

End Class
