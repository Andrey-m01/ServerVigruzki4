Imports System.IO
Imports System.Text
Imports System.Data.Sql



Public Class MainForm4

    Dim MaxWTG, MaxTimeBit As Int16


    Dim TimeToRun, WT, test 'As VariantType
    Dim fPath$, FTPPathB$, FTPPathBP$, FTPPathO$, FTPPathOP$, CMD_WINSCPp$, FTPconnect$
    Dim ODBCaddress$, ODBCuser$, ODBCpass$, FTPaddress$, FTPuser$, FTPpass$

    Dim LastF, DayXX As Date
    Dim QStDel, WTGs As Integer
    Dim EnableStart As Boolean = True

    Public Class DataBase

        'Structure DB

        Public TimeStamp(0 To MainForm4.MaxTimeBit) As Date
        Public TotActPwr(0 To MainForm4.MaxWTG, 0 To MainForm4.MaxTimeBit)
        Public HCnt_Avg_Run(0 To MainForm4.MaxWTG, 0 To MainForm4.MaxTimeBit)
        Public PsblePwr_Avg(0 To MainForm4.MaxWTG, 0 To MainForm4.MaxTimeBit)
        Public FirstActAlarmNo(0 To MainForm4.MaxWTG, 0 To MainForm4.MaxTimeBit)
        Public FirstActAlarmPar1(0 To MainForm4.MaxWTG, 0 To MainForm4.MaxTimeBit)
        Public InternalDerateStat(0 To MainForm4.MaxWTG, 0 To MainForm4.MaxTimeBit)
        Public ReferenceValue10Min(0 To MainForm4.MaxWTG, 0 To MainForm4.MaxTimeBit)
        Public Source10Min(0 To MainForm4.MaxWTG, 0 To MainForm4.MaxTimeBit)
        Public WindSpeed(0 To MainForm4.MaxWTG, 0 To MainForm4.MaxTimeBit)
        Public Temperature(0 To MainForm4.MaxWTG, 0 To MainForm4.MaxTimeBit)

        Public PowerSum(0 To MainForm4.MaxTimeBit)
        Public AvailabilitySum(0 To MainForm4.MaxTimeBit)
        Public PossiblePowerSum(0 To MainForm4.MaxTimeBit)
        Public Quontity309par5(0 To MainForm4.MaxTimeBit)
        Public QuontityCode18(0 To MainForm4.MaxTimeBit)
        Public QuontityCode19(0 To MainForm4.MaxTimeBit)
        Public QuontitHiLimit(0 To MainForm4.MaxTimeBit)
        Public CurtailmentStatus(0 To MainForm4.MaxTimeBit) As Boolean


    End Class


    Sub RunAll()
        On Error Resume Next
        Call NextRun()
        Dim DTm As Object, utc As Date
        Dim Mask2$, TmpStr$, CMD_WINSCP$
        Dim ComArr As Array
        Dim rez

        DTm = CreateObject("WbemScripting.SWbemDateTime")
        DTm.SetVarDate(Now)
        utc = CDate(Format(DateAdd("h", -2, DTm.GetVarDate(False)), "dd.MM.yyyy HH:") & Fix(CSng(Format(DTm.GetVarDate(False), "mm")) / 10) * 10)
        CMD_WINSCPp = ""
        If Minute(utc) Mod 10 > 0 Then
            DateAdd("n", -Minute(utc) Mod 10, utc)
        End If
        If Second(utc) Mod 10 > 0 Then
            DateAdd("n", -Second(utc) Mod 10, utc)
        End If


        rez = WPPAmbientPower(utc, fPath, FTPPathB, LastF)
        If rez = 0 Then
            Me.LabelUpdCount.Text = CSng(Me.LabelUpdCount.Text) + 1
            Me.LabelLastUpd.Text = Format(Now, "dd.MM.yyyy HH:mm:ss")
        Else
            Me.LabelErrCount.Text = CSng(Me.LabelErrCount.Text) + 1
            Me.LabelLastErr.Text = rez
        End If




        If DayXX <> CDate(Format(Now, "dd.MM.yyyy")) And QStDel < 8 Then 'CInt(Format(Now, "d")) - DayXX <> 0
            Mask2 = Format(DateAdd("d", -8, Now), "yyyy-MM-dd")

            TmpStr = ""
            ComArr = Split("cd /SCADA/WPP/SCADA_LIVE_DATA/&cd /SCADA/_WPP/SCADA_LIVE_DATA/&" _
                    & "cd /SCADA/_WPP/SCADA_LIVE_POSSIBLE_DATA/", "&")

            For fni = LBound(ComArr) To UBound(ComArr)
                TmpStr = TmpStr & Chr(34) & ComArr(fni) & Chr(34) & " ""rm " & "*.csv<" & Mask2 & """ "
            Next fni

            CMD_WINSCP =
            "C:\Program Files (x86)\WinSCP\WinSCP.com /Command ""open " & FTPconnect & """ " & TmpStr & " ""exit"""""  '""exit""
            Shell(CMD_WINSCP)

            QStDel = QStDel + 1
            'Shell("net time \\192.168.1.254 /set /y")
        Else
            QStDel = 0
            DayXX = CDate(Format(Now, "dd.MM.yyyy"))
        End If
    End Sub

    Sub RunAllNow()
        Dim DTm As Object, utc As Date
        Dim rez, CMD_WINSCP

        On Error Resume Next



        DTm = CreateObject("WbemScripting.SWbemDateTime")
        DTm.SetVarDate(Now)
        DTm = CreateObject("WbemScripting.SWbemDateTime")
        DTm.SetVarDate(Now)
        utc = CDate(Format(DateAdd("h", -2, DTm.GetVarDate(False)), "dd.MM.yyyy HH:") & Fix(CSng(Format(DTm.GetVarDate(False), "mm")) / 10) * 10)
        CMD_WINSCPp = ""
        If Minute(utc) Mod 10 > 0 Then
            DateAdd("n", -Minute(utc) Mod 10, utc)
        End If
        If Second(utc) Mod 10 > 0 Then
            DateAdd("n", -Second(utc) Mod 10, utc)
        End If


        rez = WPPAmbientPower(utc, fPath, FTPPathB, LastF)
        If rez = 0 Then
            Me.LabelUpdCount.Text = CSng(Me.LabelUpdCount.Text) + 1
            Me.LabelLastUpd.Text = Format(Now, "dd.MM.yyyy HH:mm:ss")
        Else
            Me.LabelErrCount.Text = CSng(Me.LabelErrCount.Text) + 1
            Me.LabelLastErr.Text = rez
        End If

        If CMD_WINSCPp <> "" Then
            CMD_WINSCP =
            "C:\Program Files (x86)\WinSCP\WinSCP.com /Command ""open " & FTPconnect & """" & CMD_WINSCPp & " ""exit"""""
            Shell(CMD_WINSCP)
        End If

    End Sub


    Sub NextRun()
        TimeToRun = DateAdd("S", 600 + Me.HScrollBar1.Value, CDate(Format(Now, "dd.MM.yyyy HH:") & Fix(CSng(Format(Now, "mm")) / 10) * 10)) ' + CDate("00:12:55") '= Now + TimeValue("00:10:00") 12:55 = 775 2:55 = 175
        'test = Format(Now, "dd.MM.yyyy HH:mm")
        'test = DateAdd("s", 775, CDate(Format(Now, "dd.MM.yyyy HH:mm")))
        'test = Fix(CSng(Format(Now, "mm")) / 10) * 10

        LabelNexUpdate.Text = Format(TimeToRun, "dd.MM.yyyy HH:mm:ss")
    End Sub
    Sub Init()
        fPath = "C:\Temp\1\"
        If TBpathLiveData.Text = "" Then
            FTPPathB = "/SCADA/WPP/SCADA_LIVE_DATA/"
        Else
            FTPPathB = TBpathLiveData.Text
        End If
        If TBpathPossibleData.Text = "" Then
            FTPPathBP = "/SCADA/WPP/SCADA_LIVE_POSSIBLE_DATA/"
        Else
            FTPPathBP = TBpathPossibleData.Text
        End If
        If TBFserver.Text = "" Then
            FTPaddress = "ftp.server.com"
        Else
            FTPaddress = TBFserver.Text
        End If
        If TBFuser.Text = "" Then
            FTPuser = "user"
        Else
            FTPuser = TBFuser.Text
        End If
        If TBFpass.Text = "" Then
            FTPpass = "orjitegoiujhnOU"
        Else
            FTPpass = TBFpass.Text
        End If
        FTPconnect = "sftp://" & FTPuser & ":" & FTPpass & "@" & FTPaddress & "/"

        If TBOserver.Text = "" Then
            ODBCaddress = "127.0.0.1"
        Else
            ODBCaddress = TBOserver.Text
        End If
        If TBOuser.Text = "" Then
            ODBCuser = "user1"
        Else
            ODBCuser = TBOuser.Text
        End If
        If TBOpass.Text = "" Then
            ODBCpass = "onlyPass"
        Else
            ODBCpass = TBOpass.Text
        End If
        If TBWTGQua.Text = "" Then
            WTGs = 0
        End If

        LastF = CDate("01.02.2022") 'Now - 1
        LastF = DateAdd("h", -12, Now)

        LastF = CDate(Format(LastF, "dd.MM.yyyy HH:") & Fix(CSng(Format(LastF, "mm")) / 10) * 10)

        WT = Split(",T_WTG053,T_WTG056,T_WTG057,T_WTG058,T_WTG067,T_WTG076,T_WTG085,T_WTG090," _
                   & "T_WTG093,T_WTG103,T_WTG104,T_WTG153,T_WTG302,T_WTG304,T_WTG305,T_WTG306," _  '39
                   & "T_WTG312,T_WTG313,T_WTG314,T_WTG323,T_WTG324,T_WTG328,T_WTG329,T_WTG330," _
                   & "T_WTG333,T_WTG334,T_WTG336,T_WTG338,T_WTG339,T_WTG340,T_WTG343,T_WTG344," _
                   & "T_WTG348,T_WTG349,T_WTG350,T_WTG351,T_WTG352,T_WTG357,T_WTG375," _
                   & "T_2WTG004,T_2WTG005,T_2WTG006,T_2WTG007,T_2WTG008,T_2WTG009,T_2WTG010," _
                   & "T_2WTG011,T_2WTG012,T_2WTG013,T_2WTG014,T_2WTG015,T_2WTG016,T_2WTG017," _
                   & "T_2WTG018,T_2WTG019,T_2WTG029,T_2WTG030,T_2WTG031,T_2WTG032,T_2WTG033," _   '44
                   & "T_2WTG034,T_2WTG035,T_2WTG036,T_2WTG037,T_2WTG038,T_2WTG039,T_2WTG040," _
                   & "T_2WTG041,T_2WTG042,T_2WTG043,T_2WTG044,T_2WTG051,T_2WTG052,T_2WTG053," _
                   & "T_2WTG054,T_2WTG055,T_2WTG056,T_2WTG057,T_2WTG058,T_2WTG059,T_2WTG060," _
                   & "T_2WTG061,T_2WTG062", ",")

        MaxWTG = 83
        MaxTimeBit = 24

        'Dim DirPath$, TmpStr$

        fPath = Application.ExecutablePath
        fPath = Mid(fPath, 1, InStrRev(fPath, "\")) & "ServerData\"
        If Not IO.Directory.Exists(fPath) Then
            IO.Directory.CreateDirectory(fPath)
        End If

    End Sub

    Private Sub MainForm4_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonExecuteNow_Click(sender As Object, e As EventArgs) Handles ButtonExecuteNow.Click
        Call RunAllNow()
    End Sub

    Private Sub ButtonStop_Click(sender As Object, e As EventArgs) Handles ButtonStop.Click
        Call Finish()
    End Sub


    Private Sub HScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar1.Scroll
        LabelDeltaStart.Text = TimeSpan.FromSeconds(HScrollBar1.Value).ToString
    End Sub


    Private Sub ButtonStart_Click(sender As Object, e As EventArgs) Handles ButtonStart.Click
        Call Start()
    End Sub

    Sub Start()
        Dim tempDate

        LabelUpdCount.Text = 0
        LabelErrCount.Text = 0
        'LabelLastUpd.Text = ""
        'LabelWorkTime.Text = ""

        Call Init()

        EnableStart = True


        tempDate = DateAdd("s", Me.HScrollBar1.Value, CDate(Format(Now, "dd.MM.yyyy HH:") & Fix(CSng(Format(Now, "mm")) / 10) * 10)) '+ TimeValue("00:02:55")
        If tempDate > Now Then
            TimeToRun = tempDate
        Else
            TimeToRun = DateAdd("s", 600, tempDate) '+ TimeValue("00:10:00")
        End If
        LabelNexUpdate.Text = TimeToRun
    End Sub

    Sub Finish()
        If EnableStart = True Then
            EnableStart = False
            'MsgBox("Done")
        End If
    End Sub


    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TBOuser.TextChanged

    End Sub

    Private Sub ButApply_Click(sender As Object, e As EventArgs) Handles ButApply.Click
        Call Init()
    End Sub

    Function FTPLastFileTime(Mask, FTPPath, LastF)
        Dim CMD_WINSCPList, FileList(0 To 0) As String
        Dim im, LasF, mTi, tt1, t2, tt2, mTiD, i, j

        im = 0
        LasF = LastF


        CMD_WINSCPList = " /Command ""open " & FTPconnect & """" _
          & CChar(vbCr) & CChar(vbLf) & " ""cd " & FTPPath & """" _
          & CChar(vbCr) & CChar(vbLf) & " " & "ls " & CChar(vbCr) & CChar(vbLf) & "exit"

        Dim oProcess As New Process()
        Dim oStartInfo As New ProcessStartInfo("C:\Program Files (x86)\WinSCP\WinSCP.com", CMD_WINSCPList)
        oStartInfo.UseShellExecute = False
        oStartInfo.RedirectStandardOutput = True
        oStartInfo.CreateNoWindow = True
        oProcess.StartInfo = oStartInfo
        oProcess.Start()

        Dim sOutput() As String
        Using oStreamReader As System.IO.StreamReader = oProcess.StandardOutput
            sOutput = oStreamReader.ReadToEnd.Split(CChar(vbCr))
        End Using

        j = 0
        For i = LBound(sOutput) To UBound(sOutput)
            If sOutput(i) Like "*" & Mask & "*.csv" Then
                ReDim Preserve FileList(0 To j)
                FileList(j) = Mid(sOutput(i), InStrRev(sOutput(i), " ") + 1)
                j = j + 1
            End If
        Next i

        Erase sOutput

        For i = LBound(FileList) To UBound(FileList)

            mTi = Strings.Right(FileList(i), Len(FileList(i)) - InStrRev(FileList(i), "\"))
            tt1 = ""
            For ik = 1 To Len(mTi)
                t2 = Mid(mTi, ik, 1)
                If IsNumeric(t2) Then tt1 = tt1 & t2  't2 = "_" Or t2 = "." Or
            Next ik
            tt2 = Strings.Left(tt1, 4) & "." & Mid(tt1, 5, 2) & "." & Mid(tt1, 7, 2) & " " & Mid(tt1, 9, 2) & ":" & Mid(tt1, 11, 2)
            If Len(tt2) < 5 Then Continue For
            mTiD = CDate(tt2)

            If LasF < mTiD Then LasF = mTiD
        Next i

        Erase FileList

        FTPLastFileTime = LasF

    End Function



    Function LastFileTime(Mask, fPath, LastF)
        Dim FileBot(0 To 0) As String
        Dim FSO, curfold
        Dim im, LasF, mTi, tt1, t2, tt2, mTiD

        im = 0

        LasF = LastF
        FSO = CreateObject("Scripting.FileSystemObject")
        curfold = FSO.GetFolder(fPath)
        For Each fil In curfold.Files
            If fil.Name Like "*" & Mask & "*" Then '"*" &
                ReDim Preserve FileBot(0 To im)
                FileBot(im) = fil.Path
                im = im + 1
            End If
        Next
        If Len(FileBot) > 1 Then
            For i = LBound(FileBot) To UBound(FileBot)

                mTi = Strings.Right(FileBot(i), Len(FileBot(i)) - InStrRev(FileBot(i), "\"))
                tt1 = ""
                For ik = 1 To Len(mTi)
                    t2 = Mid(mTi, ik, 1)
                    If IsNumeric(t2) Then tt1 = tt1 & t2  't2 = "_" Or t2 = "." Or
                Next ik
                tt2 = Strings.Left(tt1, 4) & "." & Mid(tt1, 5, 2) & "." & Mid(tt1, 7, 2) & " " & Mid(tt1, 9, 2) & ":" & Mid(tt1, 11, 2)
                If Len(tt2) < 5 Then Continue For
                mTiD = CDate(tt2)

                If LasF < mTiD Then LasF = mTiD
            Next i
        End If
        Erase FileBot

        LastFileTime = LasF
    End Function

    Function LastFileTime2(Mask, FPath, LastF)
        Dim CMD_List, FileList(0 To 0) As String
        Dim im, LasF, mTi, tt1, t2, tt2, mTiD, i, j

        im = 0
        LasF = LastF

        CMD_List = "dir /b " & FPath & CChar(vbCr) & CChar(vbLf) & " exit " _
          & CChar(vbCr) & CChar(vbLf)

        Dim oProcess As New Process()
        Dim oStartInfo As New ProcessStartInfo("""C:\Windows\System32\cmd.exe"" /c ""dir " & FPath & " /b""") ', CMD_List)
        oStartInfo.UseShellExecute = False
        oStartInfo.RedirectStandardOutput = True
        oStartInfo.CreateNoWindow = True
        oProcess.StartInfo = oStartInfo
        oProcess.Start()

        Dim sOutput() As String
        Using oStreamReader As System.IO.StreamReader = oProcess.StandardOutput
            sOutput = oStreamReader.ReadToEnd.Split(CChar(vbCr))
        End Using

        j = 0
        For i = LBound(sOutput) To UBound(sOutput)
            If sOutput(i) Like "*" & Mask & "*.csv" Then
                ReDim Preserve FileList(0 To j)
                FileList(j) = Mid(sOutput(i), InStrRev(sOutput(i), " ") + 1)
                j = j + 1
            End If
        Next i
        Erase sOutput

        For i = LBound(FileList) To UBound(FileList)

            mTi = Strings.Right(FileList(i), Len(FileList(i)) - InStrRev(FileList(i), "\"))
            tt1 = ""
            For ik = 1 To Len(mTi)
                t2 = Mid(mTi, ik, 1)
                If IsNumeric(t2) Then tt1 = tt1 & t2
            Next ik
            tt2 = Strings.Left(tt1, 4) & "." & Mid(tt1, 5, 2) & "." & Mid(tt1, 7, 2) & " " & Mid(tt1, 9, 2) & ":" & Mid(tt1, 11, 2)
            If Len(tt2) < 5 Then Continue For
            mTiD = CDate(tt2)

            If LasF < mTiD Then LasF = mTiD
        Next i

        Erase FileList

        LastFileTime2 = LasF

    End Function

    Function WPPAmbientPower(utc As Date, fPath As String, FTPPathB As String, LastF As Date)
        If fPath = "" Or FTPPathB = "" Then Call Init()
        Err.Clear()
        Dim CMD_WINSCP$
        Dim DbT

        On Error Resume Next

        'Dim ToWrt As StreamWriter
        Dim sb As New StringBuilder
        Dim cnDB, rsRecords
        Dim fNameP(0), fName(0)
        Dim TMP(0 To 10, 0 To 25)

        Dim ic, fn, fnP, n, m As Integer
        Dim LastFT, LastFTcheck As Date
        Dim LostSend, PWR, AVB, PosPWR, DPosPWR, PWR1

        cnDB = CreateObject("ADODB.Connection")
        rsRecords = CreateObject("ADODB.Recordset")


        WPPAmbientPower = 0
        ic = 0
        fn = 0
        fnP = 0
a1:

        cnDB.Open("Provider=SQLOLEDB.1;PWD=" & ODBCpass & ";User ID=" & ODBCuser & ";Initial Catalog=WPPa_DB;Data Source=" & ODBCaddress)

        If cnDB.State = 1 Then

            'utc1 = utc


            LastFT = LastFileTime2("WPP", fPath, LastF)
            'LastFT = CDate("2021.12.01 00:00")   '   ("2021.06.11 05:00")

            LastFT = CDate(Format(LastFT, "dd.MM.yyyy HH:") & Fix(CSng(Format(LastFT, "mm")) / 10) * 10)

            LostSend = DateAndTime.DateDiff(DateInterval.Minute, LastFT, CDate(Format(DateAdd("h", 2, utc), "dd.MM.yyyy HH:") & Fix(CSng(Format(utc, "mm")) / 10) * 10)) / 10   'CInt((DateAdd("h", 2, utc) - LastFT) * 144)  ' последний раз оригинальный utc в коде

            LastFTcheck = LastFT
            If LostSend > 20 Then
                LastFT = FTPLastFileTime("WPP", FTPPathB, LastF)
                LostSend = DateAndTime.DateDiff(DateInterval.Minute, LastFT, CDate(Format(DateAdd("h", 2, utc), "dd.MM.yyyy HH:") & Fix(CSng(Format(utc, "mm")) / 10) * 10)) / 10   'CInt((DateAdd("h", 2, utc) - LastFT) * 144)  ' последний раз оригинальный utc в коде
            End If

            If LastFT <> LastFTcheck Then
                CMD_WINSCPp = ""
                CMD_WINSCPp = CMD_WINSCPp & " ""get " & FTPPathB & "DTEK_WPP_WPP_availability_" & Format(LastFT, "yyyyMMddHHmm") & ".csv" & " " & fPath & """"
                CMD_WINSCPp = CMD_WINSCPp & " ""get " & FTPPathB & "DTEK_WPP_WPP_generation_" & Format(LastFT, "yyyyMMddHHmm") & ".csv" & " " & fPath & """"
                CMD_WINSCP =
            "C:\Program Files (x86)\WinSCP\WinSCP.com /Command ""open " & FTPconnect & """" & CMD_WINSCPp & " ""exit"""""
                Shell(CMD_WINSCP)
                CMD_WINSCPp = ""
            End If

            'autocalculation number of run turbines


            If WTGs = 0 Then


                For ix = 1 To MaxWTG
                    If rsRecords.State <> 0 Then rsRecords.Close
                    rsRecords.Open("SELECT count(distinct Amb_WindSpeed_Avg) as cnt1 " _
                               & "FROM " & CStr(WT(ix)) & "_10MINDATA", cnDB)
                    Err.Clear()

                    'DATA(0) = CInt(rsRecords.GetString)
                    If CInt(rsRecords.GetString) > 20 Then WTGs = WTGs + 1

                Next ix


            End If

            For ix = 1 To LostSend   ' ix = LostSend To 1 Step -1 ' ix = 1 To LostSend

                If cnDB.State <> 1 Then Exit For

                utc = DateAdd("h", -2, DateAdd("n", 10 * ix, LastFT))  ' -2  + TimeValue("00:10:00") * ix

                utc = CDate(Format(utc, "dd.MM.yyyy HH:") & Fix(CSng(Format(utc, "mm")) / 10) * 10)


                DbT = New DataBase

                For it = 0 To MaxTimeBit - 1
                    DbT.TimeStamp(it) = DateAdd("n", (it + 1) * 10, DateAdd("h", -2, utc))

                Next it
                Dim test1

                For i = 1 To MaxWTG

                    test1 = rsRecords.State
                    If rsRecords.State <> 0 Then rsRecords.Close
                    rsRecords.Open("SELECT TTimeStamp, Prod_LatestAvg_TotActPwr, HCnt_Avg_Run, " _
                                       & "Grd_Prod_PsblePwr_Avg, Sys_Logs_FirstActAlarmNo, " _
                                       & "Sys_Logs_FirstActAlarmPar1, Grd_Prod_Pwr_InternalDerateStat, " _
                                       & "Grd_Sets_ActPwr_ReferenceValue10Min, Grd_Sets_ActPwr_Source10Min, " _
                                       & "Amb_WindSpeed_Avg, Amb_Temp_Avg " & Chr(10) _
                                       & "FROM WPPa_DB.dbo." & WT(i) & "_10MINDATA " & Chr(10) _
                                       & "WHERE (" & WT(i) & "_10MINDATA.TTimeStamp> '" & Format(DateAdd("h", -2, utc), "yyyy/MM/dd HH:mm") _
                                       & "') AND (" & WT(i) & "_10MINDATA.TTimeStamp<= '" & Format(DateAdd("h", 2, utc), "yyyy/MM/dd HH:mm") _
                                       & "')  order by TTimeStamp", cnDB)

                    test1 = rsRecords.State
                    'On Error Resume Next
                    Err.Clear()
                    If Not rsRecords.eof Then TMP = rsRecords.GetRows
                    test1 = rsRecords.State
                    If rsRecords.State <> 0 Then rsRecords.Close
                    If Err.Number = 0 And Not IsNothing(TMP) Then
                        m = 0
                        n = 0
                        While m <= UBound(TMP, 2)
                            For n = m To MaxTimeBit
                                If Format(DbT.TimeStamp(n), "yyyy/MM/dd HH:mm") = Format(TMP(0, m), "yyyy/MM/dd HH:mm") Then
                                    '                        If CDate(DbT.TimeStamp(n)) = CDate(TMP(0, m)) Then
                                    DbT.TotActPwr(i, n) = TMP(1, m)
                                    DbT.HCnt_Avg_Run(i, n) = TMP(2, m)
                                    DbT.PsblePwr_Avg(i, n) = Math.Round(TMP(3, m) * 1000 / 6, 1)
                                    DbT.FirstActAlarmNo(i, n) = TMP(4, m)
                                    DbT.FirstActAlarmPar1(i, n) = TMP(5, m)
                                    DbT.InternalDerateStat(i, n) = TMP(6, m)
                                    DbT.ReferenceValue10Min(i, n) = TMP(7, m)
                                    DbT.Source10Min(i, n) = TMP(8, m)
                                    DbT.WindSpeed(i, n) = TMP(9, m)
                                    DbT.Temperature(i, n) = TMP(10, m)
                                    Exit For
                                End If
                            Next n
                            m = m + 1
                        End While

                    End If
                    On Error GoTo 0
                    TMP = Nothing


                Next i

                For n = 0 To MaxTimeBit - 1
                    PWR = 0
                    AVB = 0
                    PosPWR = 0
                    DPosPWR = 0

                    DbT.Quontity309par5(n) = 0
                    DbT.CurtailmentStatus(n) = True
                    For i = 1 To MaxWTG
                        '                If DbT.TotActPwr(n) <> Null Then
                        ''                    If CSng(DbT.TotActPwr(n)) > 0 Then
                        PWR = PWR + CSng(DbT.TotActPwr(i, n))
                        ''                    End If
                        AVB = AVB + CSng(DbT.HCnt_Avg_Run(i, n))
                        PosPWR = PosPWR + CSng(DbT.PsblePwr_Avg(i, n))
                        If DbT.FirstActAlarmNo(i, n) = 0 And DbT.TotActPwr(i, n) > 0 And DbT.HCnt_Avg_Run(i, n) > 590 Then DPosPWR = DPosPWR + CSng(DbT.PsblePwr_Avg(i, n)) - CSng(DbT.TotActPwr(i, n)) ' looses calculation
                        If DbT.FirstActAlarmNo(i, n) = 309 And DbT.FirstActAlarmPar1(i, n) = 5 Then
                            DbT.Quontity309par5(i, n) = DbT.Quontity309par5(i, n) + 1 ' find pause by PPC
                        End If

                        If DbT.InternalDerateStat(i, n) = 18 Then
                            DbT.QuontityCode18(n) = DbT.QuontityCode18(n) + 1 ' sum code18
                        End If
                        If DbT.InternalDerateStat(i, n) = 19 Then
                            DbT.QuontityCode19(n) = DbT.QuontityCode19(n) + 1 ' sum code19
                        End If
                        If DbT.PsblePwr_Avg(i, n) * 6 / 1000 - DbT.ReferenceValue10Min(i, n) > 250 And
                                    DbT.InternalDerateStat(i, n) = 18 And DbT.HCnt_Avg_Run(i, n) > 590 Then

                            DbT.QuontitHiLimit(n) = DbT.QuontitHiLimit(n) + 1 ' sum lim < 3075 by PPC
                        End If

                        '                End If
                    Next i
                    DbT.PowerSum(n) = Math.Round(PWR / 1000, 0)
                    DbT.AvailabilitySum(n) = CStr(Math.Round(AVB / (WTGs * 6), 2)) 'Replace(CStr(Math.Round(AVB / 42, 2)), ",", ".")  '600s in 10 minutes => (WTGs*6)

                    DbT.PossiblePowerSum(n) = Math.Round(PosPWR / 1000, 0)
                    If DbT.Quontity309par5(n) > 3 Then
                        DbT.CurtailmentStatus(n) = False
                    End If
                    If DbT.QuontitHiLimit(n) > 12 Then
                        DbT.CurtailmentStatus(n) = False
                    End If
                    If PWR <> 0 And PosPWR > 152200 And DbT.QuontityCode18(n) > 3 Then
                        PWR1 = Math.Abs(PWR)
                        If DPosPWR / PosPWR > 0.055 Then '/ PWR1
                            DbT.CurtailmentStatus(n) = False ' = DPosPWR / PosPWR '
                        End If
                    End If
                Next n

                fn = fn + 1
                ReDim Preserve fName(0 To fn)
                fName(fn) = Format(DateAdd("h", 2, utc), "yyyy.MM.dd_HH.mm") & "_UTC_WPP_Power.csv"
                'If Dir(fPath & fName(fn)) <> "" Then
                '    Kill(fPath & fName(fn))
                'End If

                ''
                sb.Append("TStamp beginning, UTC;TStamp end, UTC;TStamp beginning, EET/EEST;TStamp end, EET/EEST")
                For i = 1 To MaxWTG

                    sb.Append(";" & WT(i) & " Production;" & WT(i) & " Availability")
                Next i
                For i = 0 To MaxTimeBit - 1
                    sb.Append(vbCrLf & Format(DateAdd("n", -10, DbT.TimeStamp(i)), "dd.MM.yyyy HH:mm:ss") & ";")
                    sb.Append(Format(DbT.TimeStamp(i), "dd.MM.yyyy HH:mm:ss") & ";")
                    sb.Append(Format(DateAdd("h", 2, DateAdd("n", -10, DbT.TimeStamp(i))), "dd.MM.yyyy HH:mm:ss") & ";")
                    sb.Append(Format(DateAdd("h", 2, DbT.TimeStamp(i)), "dd.MM.yyyy HH:mm:ss"))
                    For J = 1 To MaxWTG
                        sb.Append(";" & Format(DbT.TotActPwr(J, i)))
                        sb.Append(";" & Format(DbT.HCnt_Avg_Run(J, i)))
                    Next J
                Next i
                Using ToWrt1 As New StreamWriter(fPath & fName(fn), True)
                    ToWrt1.Write(sb.ToString())
                End Using

                sb.Clear()

                '        fn = fn + 1   ' commented fo no sending UTC_***_Power to FTP
                '        ReDim Preserve fName(0 To fn)

                fName(fn) = "DTEK_WPP_WPP_generation_" & Format(DateAdd("h", 2, utc), "yyyyMMddHHmm") & ".csv"
                'If Dir(fPath & fName(fn)) <> "" Then
                '    Kill(fPath & fName(fn))
                'End If

                sb.Append("Asset ID;Starts YYYY-mm-dd HH:MM:SS;Ends YYYY-mm-dd HH:MM:SS;Timezone;Energy kWh;Valid;Generation Type")
                For i = 0 To MaxTimeBit - 1
                    sb.Append(vbCrLf & "DTEK_WPP_WPP;")
                    sb.Append(Format(DateAdd("n", -10, DbT.TimeStamp(i)), "yyyy-MM-dd HH:mm:ss") & ";")
                    sb.Append(CStr(Format(DbT.TimeStamp(i), "yyyy-MM-dd HH:mm:ss")) & ";UTC;")
                    sb.Append(Format(DbT.PowerSum(i)) & ";")
                    sb.Append(Format(DbT.CurtailmentStatus(i)) & ";")
                    sb.Append("Realtime")
                Next i

                Using ToWrt1 As New StreamWriter(fPath & fName(fn), True)
                    ToWrt1.Write(sb.ToString())
                End Using

                sb.Clear()

                fn += 1
                ReDim Preserve fName(0 To fn)
                fName(fn) = "DTEK_WPP_WPP_availability_" & Format(DateAdd("h", 2, utc), "yyyyMMddHHmm") & ".csv"
                'If Dir(fPath & fName(fn)) <> "" Then
                '    Kill(fPath & fName(fn))
                'End If

                sb.Append("Asset ID;Starts YYYY-mm-dd HH:MM:SS;Ends YYYY-mm-dd HH:MM:SS;Timezone;Availability %;Availability type")
                For i = 0 To MaxTimeBit - 1
                    sb.Append(vbCrLf & "DTEK_WPP_WPP;")
                    sb.Append(Format(DateAdd("n", -10, DbT.TimeStamp(i)), "yyyy-MM-dd HH:mm:ss") & ";")
                    sb.Append(Format(DbT.TimeStamp(i), "yyyy-MM-dd HH:mm:ss") & ";UTC;")
                    sb.Append(Format(DbT.AvailabilitySum(i)) & ";RD")
                Next i

                Using ToWrt1 As New StreamWriter(fPath & fName(fn), True)
                    ToWrt1.Write(sb.ToString())
                End Using

                sb.Clear()

                fnP = fnP + 1
                ReDim Preserve fNameP(0 To fnP)
                'fNameP(fnP) = Format(DateAdd("h", 2, utc), "yyyy.MM.dd_HH.mm") & "_UTC_WPP_PossiblePower.csv"
                fNameP(fnP) = "DTEK_WPP_WPP_PossiblePower_" & Format(DateAdd("h", 2, utc), "yyyyMMddHHmm") & "_UTC.csv"
                'If Dir(fPath & fName(fnP)) <> "" Then
                '    Kill(fPath & fName(fnP))
                'End If

                sb.Append("TStamp beginning, UTC;TStamp end, UTC;TStamp beginning, EET/EEST;TStamp end, EET/EEST")
                For i = 1 To MaxWTG
                    sb.Append(";" & WT(i) & "_Power;" & WT(i) & "_PossiblePower;" & WT(i) & "_FirstActAlarmNo")  ' Strings.Right(WT(i), 3)
                Next i
                For i = 0 To MaxTimeBit - 1
                    sb.Append(vbCrLf & Format(DateAdd("n", -10, DbT.TimeStamp(i)), "dd.MM.yyyy HH:mm:ss") & ";")
                    sb.Append(Format(DbT.TimeStamp(i), "dd.MM.yyyy HH:mm:ss") & ";")
                    sb.Append(Format(DateAdd("h", 2, DateAdd("n", -10, DbT.TimeStamp(i))), "dd.MM.yyyy HH:mm:ss") & ";")
                    sb.Append(Format(DateAdd("h", 2, DbT.TimeStamp(i)), "dd.MM.yyyy HH:mm:ss"))
                    For J = 1 To MaxWTG
                        sb.Append(";" & Format(DbT.TotActPwr(J, i)))
                        sb.Append(";" & Format(DbT.PsblePwr_Avg(J, i)))
                        sb.Append(";" & Format(DbT.FirstActAlarmNo(J, i)))
                    Next J
                Next i

                Using ToWrt1 As New StreamWriter(fPath & fNameP(fnP), True)
                    ToWrt1.Write(sb.ToString())
                End Using

                sb.Clear()


                fnP = fnP + 1
                ReDim Preserve fNameP(0 To fnP)
                'fNameP(fnP) = Format(DateAdd("h", 2, utc), "yyyy.MM.dd_HH.mm") & "_UTC_WPP_Data.csv"
                fNameP(fnP) = "DTEK_WPP_WPP_Data_" & Format(DateAdd("h", 2, utc), "yyyyMMddHHmm") & "_UTC.csv"

                sb.Append("TStamp end, UTC")  'sb.Append("TStamp beginning, UTC;TStamp end, UTC;TStamp beginning, EET/EEST;TStamp end, EET/EEST")
                For i = 1 To MaxWTG
                    sb.Append(";" & WT(i) & "_TotActPwr;" & WT(i) & "_Avg_Run;" & WT(i) & "_PsblePwr_Avg;" _
                               & WT(i) & "_FirstActAlarmNo;" & WT(i) & "_FirstActAlarmPar1;" & WT(i) & "_InternalDerateStat;" _
                               & WT(i) & "_ActPwr_ReferenceValue10Min;" & WT(i) & "_ActPwr_Source10Min;" & WT(i) & "_WindSpeed_Avg;" _
                               & WT(i) & "_Amb_Temp_Avg")  ' Strings.Right(WT(i), 3)
                Next i
                For i = 0 To MaxTimeBit - 1
                    '  sb.Append(vbCrLf & Format(DateAdd("n", -10, DbT.TimeStamp(i)), "dd.MM.yyyy HH:mm:ss") & ";")
                    sb.Append(vbCrLf & Format(DbT.TimeStamp(i), "dd.MM.yyyy HH:mm:ss"))
                    '  sb.Append(Format(DateAdd("h", 2, DateAdd("n", -10, DbT.TimeStamp(i))), "dd.MM.yyyy HH:mm:ss") & ";")
                    '  sb.Append(Format(DateAdd("h", 2, DbT.TimeStamp(i)), "dd.MM.yyyy HH:mm:ss"))
                    For J = 1 To MaxWTG
                        sb.Append(";" & Format(DbT.TotActPwr(J, i)))
                        sb.Append(";" & Format(DbT.HCnt_Avg_Run(J, i)))
                        sb.Append(";" & Format(DbT.PsblePwr_Avg(J, i)))
                        sb.Append(";" & Format(DbT.FirstActAlarmNo(J, i)))
                        sb.Append(";" & Format(DbT.FirstActAlarmPar1(J, i)))
                        sb.Append(";" & Format(DbT.InternalDerateStat(J, i)))
                        sb.Append(";" & Format(DbT.ReferenceValue10Min(J, i)))
                        sb.Append(";" & Format(DbT.Source10Min(J, i)))
                        sb.Append(";" & Format(DbT.WindSpeed(J, i)))
                        sb.Append(";" & Format(DbT.Temperature(J, i)))
                    Next J
                Next i

                Using ToWrt1 As New StreamWriter(fPath & fNameP(fnP), True)
                    ToWrt1.Write(sb.ToString())
                End Using

                sb.Clear()

                If fn > 150 Then
                    For fni = 1 To fn
                        CMD_WINSCPp = CMD_WINSCPp & " ""put " & fPath & fName(fni) & " " & FTPPathB & """"
                    Next fni

                    For fni = 1 To fnP
                        CMD_WINSCPp = CMD_WINSCPp & " ""put " & fPath & fNameP(fni) & " " & FTPPathBP & """"
                    Next fni

                    CMD_WINSCP =
                    "C:\Program Files (x86)\WinSCP\WinSCP.com /Command ""open " & FTPconnect & """" & CMD_WINSCPp & " ""exit"""""
                    Shell(CMD_WINSCP)
                    ReDim fName(0 To 1)
                    ReDim fNameP(0 To 1)
                    fn = 0
                    fnP = 0
                    CMD_WINSCPp = ""
                End If

                DbT = Nothing

            Next ix

            For fni = 1 To fn
                CMD_WINSCPp = CMD_WINSCPp & " ""put " & fPath & fName(fni) & " " & FTPPathB & """"
            Next fni

            For fni = 1 To fnP
                CMD_WINSCPp = CMD_WINSCPp & " ""put " & fPath & fNameP(fni) & " " & FTPPathBP & """"
            Next fni



            rsRecords = Nothing
            cnDB.Close
            cnDB = Nothing

            If CMD_WINSCPp <> "" Then
                CMD_WINSCP =
                "C:\Program Files (x86)\WinSCP\WinSCP.com /Command ""open " & FTPconnect & """" & CMD_WINSCPp & " ""exit"""""  '""exit""

                Shell(CMD_WINSCP)
                CMD_WINSCP = ""
            End If




        Else
            'здесь будет код для установления VPN подключения
            If ic < 2 Then
                ic = ic + 1


                Shell("TASKKILL /F /IM ipsecc.exe /T")
                Threading.Thread.Sleep(1000)
                Shell("C:\Program Files\ShrewSoft\VPN Client\ipsecc.exe -r ""WPP.pcf"" -u UserName -p Password -a")
                Threading.Thread.Sleep(5000)
                GoTo a1
            Else
                WPPAmbientPower = 2
            End If

        End If


        'On Error GoTo 0

        If WPPAmbientPower = 0 Then WPPAmbientPower = Err.Number

    End Function



    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        LabelLastOpen.Text = Now
        Call Init()
        Call Start()
        Me.Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If EnableStart Then
            If LabelLastUpd.Text <> "Never" Then LabelSinceLastUpd.Text = TimeSpan.FromSeconds(DateAndTime.DateDiff(DateInterval.Second, CDate(LabelLastUpd.Text), Now)).ToString
            If LabelNexUpdate.Text <> "Never" Then LabelToNextUpd.Text = TimeSpan.FromSeconds(DateAndTime.DateDiff(DateInterval.Second, CDate(LabelNexUpdate.Text), Now)).ToString
            If Format(Now, "yyyy/MM/dd HH:mm") = Format(TimeToRun, "yyyy/MM/dd HH:mm") Then Call RunAll()
        Else
            LabelNexUpdate.Text = "Never"
        End If
        LabelWorkTime.Text = TimeSpan.FromSeconds(DateAndTime.DateDiff(DateInterval.Second, CDate(LabelLastOpen.Text), Now)).ToString '& Format(DateAndTime.DateDiff(DateInterval.Second, Now, CDate(LabelLastOpen.Text), " HH:mm:ss"))
        Timer1.Enabled = True


    End Sub






End Class


