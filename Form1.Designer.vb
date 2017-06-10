<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ckb_StartSpeech = New System.Windows.Forms.CheckBox()
        Me.rt_Out = New System.Windows.Forms.RichTextBox()
        Me.pb_Status = New System.Windows.Forms.PictureBox()
        Me.tmr_StayActive = New System.Windows.Forms.Timer(Me.components)
        Me.pb_Active = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.pb_Status, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_Active, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ckb_StartSpeech
        '
        Me.ckb_StartSpeech.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ckb_StartSpeech.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckb_StartSpeech.Location = New System.Drawing.Point(0, 0)
        Me.ckb_StartSpeech.Name = "ckb_StartSpeech"
        Me.ckb_StartSpeech.Size = New System.Drawing.Size(247, 44)
        Me.ckb_StartSpeech.TabIndex = 0
        Me.ckb_StartSpeech.Text = "Spracherkennung"
        Me.ckb_StartSpeech.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ckb_StartSpeech.UseVisualStyleBackColor = False
        '
        'rt_Out
        '
        Me.rt_Out.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rt_Out.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rt_Out.Location = New System.Drawing.Point(0, 45)
        Me.rt_Out.Name = "rt_Out"
        Me.rt_Out.Size = New System.Drawing.Size(389, 339)
        Me.rt_Out.TabIndex = 2
        Me.rt_Out.Text = ""
        '
        'pb_Status
        '
        Me.pb_Status.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pb_Status.BackColor = System.Drawing.Color.Gray
        Me.pb_Status.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pb_Status.Location = New System.Drawing.Point(367, 22)
        Me.pb_Status.Name = "pb_Status"
        Me.pb_Status.Size = New System.Drawing.Size(22, 22)
        Me.pb_Status.TabIndex = 3
        Me.pb_Status.TabStop = False
        '
        'tmr_StayActive
        '
        Me.tmr_StayActive.Interval = 5000
        '
        'pb_Active
        '
        Me.pb_Active.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pb_Active.BackColor = System.Drawing.Color.Gray
        Me.pb_Active.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pb_Active.Location = New System.Drawing.Point(367, 0)
        Me.pb_Active.Name = "pb_Active"
        Me.pb_Active.Size = New System.Drawing.Size(22, 22)
        Me.pb_Active.TabIndex = 4
        Me.pb_Active.TabStop = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(253, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Bereit für Kommando:"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(265, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Letzte Erkennung:"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(389, 384)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pb_Active)
        Me.Controls.Add(Me.pb_Status)
        Me.Controls.Add(Me.rt_Out)
        Me.Controls.Add(Me.ckb_StartSpeech)
        Me.MinimumSize = New System.Drawing.Size(405, 423)
        Me.Name = "Form1"
        Me.Text = "opsSpeechRecog"
        CType(Me.pb_Status, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_Active, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ckb_StartSpeech As System.Windows.Forms.CheckBox
   Friend WithEvents rt_Out As System.Windows.Forms.RichTextBox
    Friend WithEvents pb_Status As PictureBox
    Friend WithEvents tmr_StayActive As Timer
    Friend WithEvents pb_Active As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
