<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm4
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LabelUpdCount = New System.Windows.Forms.Label()
        Me.LabelErrCount = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LabelLastErr = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LabelSinceLastUpd = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LabelLastUpd = New System.Windows.Forms.Label()
        Me.ButtonStart = New System.Windows.Forms.Button()
        Me.ButtonStop = New System.Windows.Forms.Button()
        Me.ButtonExecuteNow = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LabelWorkTime = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.LabelLastOpen = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.LabelNexUpdate = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.HScrollBar1 = New System.Windows.Forms.HScrollBar()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LabelDeltaStart = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LabelToNextUpd = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TBOserver = New System.Windows.Forms.TextBox()
        Me.TBOuser = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TBOpass = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TBFpass = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TBFuser = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TBFserver = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.ButApply = New System.Windows.Forms.Button()
        Me.TBpathPossibleData = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TBpathLiveData = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TBWTGQua = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label6.Location = New System.Drawing.Point(733, 129)
        Me.Label6.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 36)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "WPP:"
        '
        'LabelUpdCount
        '
        Me.LabelUpdCount.AutoSize = True
        Me.LabelUpdCount.Location = New System.Drawing.Point(880, 196)
        Me.LabelUpdCount.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.LabelUpdCount.Name = "LabelUpdCount"
        Me.LabelUpdCount.Size = New System.Drawing.Size(30, 32)
        Me.LabelUpdCount.TabIndex = 20
        Me.LabelUpdCount.Text = "0"
        '
        'LabelErrCount
        '
        Me.LabelErrCount.AutoSize = True
        Me.LabelErrCount.ForeColor = System.Drawing.Color.Red
        Me.LabelErrCount.Location = New System.Drawing.Point(880, 227)
        Me.LabelErrCount.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.LabelErrCount.Name = "LabelErrCount"
        Me.LabelErrCount.Size = New System.Drawing.Size(30, 32)
        Me.LabelErrCount.TabIndex = 21
        Me.LabelErrCount.Text = "0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(765, 227)
        Me.Label9.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 32)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Errors:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(723, 196)
        Me.Label10.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(136, 32)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Updades:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(648, 258)
        Me.Label11.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(211, 32)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "Last error code:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LabelLastErr
        '
        Me.LabelLastErr.AutoSize = True
        Me.LabelLastErr.Location = New System.Drawing.Point(880, 258)
        Me.LabelLastErr.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.LabelLastErr.Name = "LabelLastErr"
        Me.LabelLastErr.Size = New System.Drawing.Size(30, 32)
        Me.LabelLastErr.TabIndex = 24
        Me.LabelLastErr.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(555, 320)
        Me.Label1.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(306, 32)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Time since last update:"
        '
        'LabelSinceLastUpd
        '
        Me.LabelSinceLastUpd.AutoSize = True
        Me.LabelSinceLastUpd.Location = New System.Drawing.Point(880, 320)
        Me.LabelSinceLastUpd.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.LabelSinceLastUpd.Name = "LabelSinceLastUpd"
        Me.LabelSinceLastUpd.Size = New System.Drawing.Size(89, 32)
        Me.LabelSinceLastUpd.TabIndex = 28
        Me.LabelSinceLastUpd.Text = "Never"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(688, 289)
        Me.Label3.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(171, 32)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Last update:"
        '
        'LabelLastUpd
        '
        Me.LabelLastUpd.AutoSize = True
        Me.LabelLastUpd.Location = New System.Drawing.Point(880, 289)
        Me.LabelLastUpd.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.LabelLastUpd.Name = "LabelLastUpd"
        Me.LabelLastUpd.Size = New System.Drawing.Size(89, 32)
        Me.LabelLastUpd.TabIndex = 26
        Me.LabelLastUpd.Text = "Never"
        '
        'ButtonStart
        '
        Me.ButtonStart.Location = New System.Drawing.Point(1347, 129)
        Me.ButtonStart.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.ButtonStart.Name = "ButtonStart"
        Me.ButtonStart.Size = New System.Drawing.Size(277, 98)
        Me.ButtonStart.TabIndex = 30
        Me.ButtonStart.Text = "Start"
        Me.ButtonStart.UseVisualStyleBackColor = True
        '
        'ButtonStop
        '
        Me.ButtonStop.Location = New System.Drawing.Point(1347, 241)
        Me.ButtonStop.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.ButtonStop.Name = "ButtonStop"
        Me.ButtonStop.Size = New System.Drawing.Size(277, 98)
        Me.ButtonStop.TabIndex = 31
        Me.ButtonStop.Text = "Stop"
        Me.ButtonStop.UseVisualStyleBackColor = True
        '
        'ButtonExecuteNow
        '
        Me.ButtonExecuteNow.Location = New System.Drawing.Point(1347, 384)
        Me.ButtonExecuteNow.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.ButtonExecuteNow.Name = "ButtonExecuteNow"
        Me.ButtonExecuteNow.Size = New System.Drawing.Size(277, 98)
        Me.ButtonExecuteNow.TabIndex = 32
        Me.ButtonExecuteNow.Text = "Execute now"
        Me.ButtonExecuteNow.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(709, 417)
        Me.Label5.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(148, 32)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "Work time:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LabelWorkTime
        '
        Me.LabelWorkTime.AutoSize = True
        Me.LabelWorkTime.Location = New System.Drawing.Point(880, 417)
        Me.LabelWorkTime.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.LabelWorkTime.Name = "LabelWorkTime"
        Me.LabelWorkTime.Size = New System.Drawing.Size(77, 32)
        Me.LabelWorkTime.TabIndex = 35
        Me.LabelWorkTime.Text = "Time"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(712, 386)
        Me.Label14.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(147, 32)
        Me.Label14.TabIndex = 34
        Me.Label14.Text = "Last open:"
        '
        'LabelLastOpen
        '
        Me.LabelLastOpen.AutoSize = True
        Me.LabelLastOpen.Location = New System.Drawing.Point(880, 386)
        Me.LabelLastOpen.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.LabelLastOpen.Name = "LabelLastOpen"
        Me.LabelLastOpen.Size = New System.Drawing.Size(158, 32)
        Me.LabelLastOpen.TabIndex = 33
        Me.LabelLastOpen.Text = "01.01.2021"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(683, 472)
        Me.Label16.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(175, 32)
        Me.Label16.TabIndex = 38
        Me.Label16.Text = "Next update:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LabelNexUpdate
        '
        Me.LabelNexUpdate.AutoSize = True
        Me.LabelNexUpdate.Location = New System.Drawing.Point(880, 472)
        Me.LabelNexUpdate.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.LabelNexUpdate.Name = "LabelNexUpdate"
        Me.LabelNexUpdate.Size = New System.Drawing.Size(77, 32)
        Me.LabelNexUpdate.TabIndex = 37
        Me.LabelNexUpdate.Text = "Time"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'HScrollBar1
        '
        Me.HScrollBar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.HScrollBar1.Location = New System.Drawing.Point(0, 1049)
        Me.HScrollBar1.Maximum = 570
        Me.HScrollBar1.Minimum = 90
        Me.HScrollBar1.Name = "HScrollBar1"
        Me.HScrollBar1.Size = New System.Drawing.Size(2133, 24)
        Me.HScrollBar1.TabIndex = 40
        Me.HScrollBar1.Value = 175
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(608, 942)
        Me.Label2.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(251, 32)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Next update delay:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LabelDeltaStart
        '
        Me.LabelDeltaStart.AutoSize = True
        Me.LabelDeltaStart.Location = New System.Drawing.Point(880, 942)
        Me.LabelDeltaStart.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.LabelDeltaStart.Name = "LabelDeltaStart"
        Me.LabelDeltaStart.Size = New System.Drawing.Size(126, 32)
        Me.LabelDeltaStart.TabIndex = 41
        Me.LabelDeltaStart.Text = "00:02:55"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(587, 503)
        Me.Label4.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(272, 32)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "Time to next update:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LabelToNextUpd
        '
        Me.LabelToNextUpd.AutoSize = True
        Me.LabelToNextUpd.Location = New System.Drawing.Point(880, 503)
        Me.LabelToNextUpd.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.LabelToNextUpd.Name = "LabelToNextUpd"
        Me.LabelToNextUpd.Size = New System.Drawing.Size(77, 32)
        Me.LabelToNextUpd.TabIndex = 43
        Me.LabelToNextUpd.Text = "Time"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(147, 599)
        Me.Label7.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(180, 32)
        Me.Label7.TabIndex = 45
        Me.Label7.Text = "ODBC server"
        '
        'TBOserver
        '
        Me.TBOserver.Location = New System.Drawing.Point(347, 591)
        Me.TBOserver.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.TBOserver.Name = "TBOserver"
        Me.TBOserver.Size = New System.Drawing.Size(260, 38)
        Me.TBOserver.TabIndex = 46
        '
        'TBOuser
        '
        Me.TBOuser.Location = New System.Drawing.Point(347, 653)
        Me.TBOuser.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.TBOuser.Name = "TBOuser"
        Me.TBOuser.Size = New System.Drawing.Size(260, 38)
        Me.TBOuser.TabIndex = 48
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Location = New System.Drawing.Point(147, 661)
        Me.Label8.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(157, 32)
        Me.Label8.TabIndex = 47
        Me.Label8.Text = "ODBC user"
        '
        'TBOpass
        '
        Me.TBOpass.Location = New System.Drawing.Point(347, 715)
        Me.TBOpass.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.TBOpass.Name = "TBOpass"
        Me.TBOpass.Size = New System.Drawing.Size(260, 38)
        Me.TBOpass.TabIndex = 50
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(147, 723)
        Me.Label12.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(162, 32)
        Me.Label12.TabIndex = 49
        Me.Label12.Text = "ODBC pass"
        '
        'TBFpass
        '
        Me.TBFpass.Location = New System.Drawing.Point(864, 715)
        Me.TBFpass.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.TBFpass.Name = "TBFpass"
        Me.TBFpass.Size = New System.Drawing.Size(260, 38)
        Me.TBFpass.TabIndex = 56
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(664, 723)
        Me.Label13.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(134, 32)
        Me.Label13.TabIndex = 55
        Me.Label13.Text = "FTP pass"
        '
        'TBFuser
        '
        Me.TBFuser.Location = New System.Drawing.Point(864, 653)
        Me.TBFuser.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.TBFuser.Name = "TBFuser"
        Me.TBFuser.Size = New System.Drawing.Size(260, 38)
        Me.TBFuser.TabIndex = 54
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label15.Location = New System.Drawing.Point(664, 661)
        Me.Label15.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(129, 32)
        Me.Label15.TabIndex = 53
        Me.Label15.Text = "FTP user"
        '
        'TBFserver
        '
        Me.TBFserver.Location = New System.Drawing.Point(864, 591)
        Me.TBFserver.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.TBFserver.Name = "TBFserver"
        Me.TBFserver.Size = New System.Drawing.Size(260, 38)
        Me.TBFserver.TabIndex = 52
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(664, 599)
        Me.Label17.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(152, 32)
        Me.Label17.TabIndex = 51
        Me.Label17.Text = "FTP server"
        '
        'ButApply
        '
        Me.ButApply.Location = New System.Drawing.Point(1155, 770)
        Me.ButApply.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.ButApply.Name = "ButApply"
        Me.ButApply.Size = New System.Drawing.Size(840, 52)
        Me.ButApply.TabIndex = 57
        Me.ButApply.Text = "Apply"
        Me.ButApply.UseVisualStyleBackColor = True
        '
        'TBpathPossibleData
        '
        Me.TBpathPossibleData.Location = New System.Drawing.Point(1728, 653)
        Me.TBpathPossibleData.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.TBpathPossibleData.Name = "TBpathPossibleData"
        Me.TBpathPossibleData.Size = New System.Drawing.Size(260, 38)
        Me.TBpathPossibleData.TabIndex = 62
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label19.Location = New System.Drawing.Point(1147, 661)
        Me.Label19.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(578, 32)
        Me.Label19.TabIndex = 61
        Me.Label19.Text = "FTP Path ""SCADA_LIVE_POSSIBLE_DATA"""
        '
        'TBpathLiveData
        '
        Me.TBpathLiveData.Location = New System.Drawing.Point(1728, 591)
        Me.TBpathLiveData.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.TBpathLiveData.Name = "TBpathLiveData"
        Me.TBpathLiveData.Size = New System.Drawing.Size(260, 38)
        Me.TBpathLiveData.TabIndex = 60
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(1147, 599)
        Me.Label20.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(423, 32)
        Me.Label20.TabIndex = 59
        Me.Label20.Text = "FTP Path ""SCADA_LIVE_DATA"""
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(1147, 715)
        Me.Label21.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(596, 32)
        Me.Label21.TabIndex = 63
        Me.Label21.Text = "Example: /SCADA/WPP/SCADA_LIVE_DATA/"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(509, 849)
        Me.Label18.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(458, 32)
        Me.Label18.TabIndex = 58
        Me.Label18.Text = "Note: for no changes leave it blank."
        '
        'TBWTGQua
        '
        Me.TBWTGQua.Location = New System.Drawing.Point(347, 777)
        Me.TBWTGQua.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.TBWTGQua.Name = "TBWTGQua"
        Me.TBWTGQua.Size = New System.Drawing.Size(260, 38)
        Me.TBWTGQua.TabIndex = 65
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(147, 785)
        Me.Label22.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(155, 32)
        Me.Label22.TabIndex = 64
        Me.Label22.Text = "WTGs runs"
        '
        'MainForm4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 31.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(2133, 1073)
        Me.Controls.Add(Me.TBWTGQua)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.TBpathPossibleData)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.TBpathLiveData)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.ButApply)
        Me.Controls.Add(Me.TBFpass)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TBFuser)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.TBFserver)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.TBOpass)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TBOuser)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TBOserver)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LabelToNextUpd)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LabelDeltaStart)
        Me.Controls.Add(Me.HScrollBar1)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.LabelNexUpdate)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LabelWorkTime)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.LabelLastOpen)
        Me.Controls.Add(Me.ButtonExecuteNow)
        Me.Controls.Add(Me.ButtonStop)
        Me.Controls.Add(Me.ButtonStart)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LabelSinceLastUpd)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LabelLastUpd)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.LabelLastErr)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.LabelErrCount)
        Me.Controls.Add(Me.LabelUpdCount)
        Me.Controls.Add(Me.Label6)
        Me.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.Name = "MainForm4"
        Me.Text = "Сервер выгрузки SCADA данных ВЭС"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label6 As Label
    Friend WithEvents LabelUpdCount As Label
    Friend WithEvents LabelErrCount As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents LabelLastErr As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents LabelSinceLastUpd As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents LabelLastUpd As Label
    Friend WithEvents ButtonStart As Button
    Friend WithEvents ButtonStop As Button
    Friend WithEvents ButtonExecuteNow As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents LabelWorkTime As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents LabelLastOpen As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents LabelNexUpdate As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents HScrollBar1 As HScrollBar
    Friend WithEvents Label2 As Label
    Friend WithEvents LabelDeltaStart As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents LabelToNextUpd As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TBOserver As TextBox
    Friend WithEvents TBOuser As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TBOpass As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents TBFpass As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents TBFuser As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents TBFserver As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents ButApply As Button
    Friend WithEvents TBpathPossibleData As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents TBpathLiveData As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents TBWTGQua As TextBox
    Friend WithEvents Label22 As Label
End Class
