Public Class Class5
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        'http://txodds.com/odds?ot=0,4&amp;pgid=13043,13053,13191,13229,13234,13235,13236,13237,13238,13239,13249,13250,13261,13263,13267,13268,13287,13329,13330,13331,13332,13333,13334,13338,13339,13361,13362,13363,13364,13367,13372,13373,13374,13375,13400,13401,13417,13418,13419,13438,13442,13443,13444,13445,13452,13454,13455,13460,13462,13549,13551,13552,13554,13555,13559,13564,13565,13566,13572,13574,13576,13577,13579,13581,13597,13598,13599,13609,13628,13629,13638,13639,13643,13644,13646,13647,13648,13656,13678,13693,13699,13703,13705,13707,13732,13763,13769,13782,13797,13800,13801,13826,13858,13860,13864,13887,13888,13901,13903,13917,13929,13981,13985,14032,14033,14035,14060,14070,14073,14074,14097,14114,14118,14128,14173,14184,14185,14193,14219,14232,14257,14302,14303,14320,14323,14370,14371,14380,14382,14383,14510,14633,14793,14911,14977,15022,15023,15026,15055,15056,15090,15092,15093,15242,15253,15276,15283,15284,15285,15290,15291,15310,15311,15371,15375,15377,15385,15389,15589,15594,15624,15627,15661,15710,15712,15727,15730,15735,15738,15827,15829,15834,15898,16027,16036,16080,16089,16121,16173,16207,16218,16280,16282&amp;bid=83&amp;ocflags=3&amp;date=2014-03-24%2008:09,2014-03-31%2000:00&amp;layout=0&amp;txt=1
        Me.Text = bookm
        Timer1.Enabled = True

        Dim dtNows As DateTime = DateTime.Now
        Dim dtNowe As DateTime = DateTime.Now

        dtNows = dtNows.AddDays(0)
        dtNowe = dtNowe.AddDays(1)
        'datei += 1

        Url = My.Settings("url1") & "327" & "&amp;date=" & dtNows.ToString("yyyy-MM-dd") & "%2000:00," & dtNowe.ToString("yyyy-MM-dd") & "%2000:00&amp;layout=0&amp;txt=1"
        My.Settings("url1") = Url
        wb1.Navigate(New System.Uri(Url))

        WB10.Navigate(My.Settings("url10"))
    End Sub

        Private Sub wb1_DocumentCompleted_1(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles wb1.DocumentCompleted
            On Error Resume Next
        Dim URL As String = e.Url.ToString()

            If URL = "http://backyjob.xsrv.jp/abi/" Then
                wb1.Navigate(New System.Uri(My.Settings("url1")))
                Exit Sub
            End If

        Do While wb1.IsBusy
            System.Windows.Forms.Application.DoEvents()
        Loop

            While wb1.IsBusy
                System.Windows.Forms.Application.DoEvents()
            End While

        While wb1.ReadyState <> WebBrowserReadyState.Complete
            System.Windows.Forms.Application.DoEvents()
        End While


            Dim cnt = -2
            Dim chekHTML
            Dim chekHTML2
            Dim strArry() As String
            Dim strArry2() As String

        'If URL = "http://www.pinnaclesports.com/League/Soccer/French+1/1/Lines.aspx" Then
            'If URL = My.Settings("url1") Then
            If InStr(URL, "http://txodds.com/odds?") > 0 Then

                '読込HTML取得
                'HTML_TXT = wb1.Document.DomDocument.documentElement.outerhtml
                'HTML_TXT = Replace(HTML_TXT, Chr(34), "") '「"」の削除
                'HTML_TXT = Replace(HTML_TXT, " ", "")
                'HTML_TXT = Replace(HTML_TXT, "　", "")
                'HTML_TXT = Replace(HTML_TXT, "&nbsp;", "")
                'HTML_TXT = Replace(HTML_TXT, "&NBSP;", "")

                'TextBox1.Text = wb1.Document.DomDocument.documentElement.innerTEXT
                strArry = Split(wb1.Document.DomDocument.documentElement.innerTEXT, vbCrLf)
                Dim re As System.Text.RegularExpressions.Regex
                re = New System.Text.RegularExpressions.Regex("\s+")

                Dim tc1 = 0
                Dim tc2 = 0

                For Each osdata As String In strArry
                    strArry2 = re.Split(osdata)
                Dim i = 0
                    For Each tc As String In strArry2
                        If tc = "-" Then
                            tc1 = i
                        ElseIf tc = "1x2" Or tc = "tot" Then
                            tc2 = i
                        End If
                        i += 1
                    Next


                    ' MsgBox(strArry2(8))
                    Dim dt() As String

                    strArry2(0) = Replace(strArry2(0), "-0", "-")
                    dt = Split(strArry2(0), "-")

                    bd(0) = dt(1) & "/" & dt(2) '曜日
                    bd(1) = strArry2(1) '時間

                    Dim dt2() As String

                    strArry2(0) = Replace(strArry2(tc2 + 4), "-0", "-")
                    dt2 = Split(strArry2(0), "-")

                    If dt(1) > dt2(1) Then
                        Continue For
                    ElseIf dt(1) = dt2(1) And dt(2) > dt2(2) + 3 Then
                        Continue For
                    End If


                    bd(2) = ""
                    For it = 2 To tc1 - 1
                        bd(2) = bd(2) & strArry2(it)  'チーム名（A)
                    Next

                    bd(4) = ""
                    For it = tc1 + 1 To tc2 - 2
                        bd(4) = bd(4) & strArry2(it)  'チーム名（B)
                    Next

                    ' MsgBox(strArry2(tc2 - 1)) 'BM名

                    bd(8) = ""
                    bd(11) = ""

                    bd(18) = bookm + bd(0) + bd(1) + bd(2) + bd(4)


                    If strArry2(tc2) = "1x2" Then
                        bd(9) = ""
                        bd(10) = ""
                        bd(12) = ""
                        bd(13) = ""

                        bd(3) = SpaceDel(txodd(strArry2(tc2 + 1))) '１×２　オッズ（１）
                        bd(5) = SpaceDel(txodd(strArry2(tc2 + 3))) '１×２　オッズ（２）
                        bd(6) = "Draw" 'チーム名（引分）
                        bd(7) = SpaceDel(txodd(strArry2(tc2 + 2))) '１×２　オッズ（引分）
                    ElseIf strArry2(tc2) = "tot" Then
                        bd(3) = ""
                        bd(5) = ""
                        bd(6) = ""
                        bd(7) = ""

                        bd(9) = strArry2(tc2 + 3)
                        bd(10) = SpaceDel(txodd(strArry2(tc2 + 1)))
                        bd(12) = strArry2(tc2 + 3)
                        bd(13) = SpaceDel(txodd(strArry2(tc2 + 2)))
                    End If


                ' text_show(cnt)
                    Dim bs = ""

                    For i2 = 0 To 13
                        bd(i2) = SpaceDel(bd(i2))
                        bs = bs & " " & bd(i2)
                    Next
                    'MsgBox(bs)
                    TextBox1.Text += bs + vbCrLf

                    Web_book = My.Settings("serverurl") + "?book=" + bookm + "&a_1=" + bd(0) + "&a_2=" + bd(1) + "&a_3=" + bd(2) + "&a_4=" + bd(3) + "&a_5=" + bd(4) + "&a_6=" + bd(5) + "&a_7=" + bd(6) + "&a_8=" + bd(7) + "&a_9=" + bd(9) + "&a_10=" + bd(10) + "&a_11=" + bd(12) + "&a_12=" + bd(13) + "&a_18=" + bd(18) + "&a_19="
                    oss_web_write(Web_book)
                    System.Threading.Thread.Sleep(1000)

                Next



                For Each es As HtmlElement In wb1.Document.GetElementsByTagName("script")

                If InStr(es.OuterHtml, "function initiateOddsDisplay") > 0 Then

                    Dim oos = es.OuterHtml
                    Dim a = InStr(oos, "'od'") + 5
                    Dim oos2 = Mid(oos, InStr(oos, "'od'") + 5)
                    oos2 = Replace(oos2, "[", "")
                    oos2 = Replace(oos2, "]", "")

                    Dim strTemp() As String
                    strTemp = Split(oos2, ",")

                    Dim i = 0
                    For Each t As String In strTemp
                        If t = "{}" Then

                            bd(0) = date_ch(strTemp(i - 6)) '曜日
                            bd(1) = date_ch2(strTemp(i - 6)) '時間
                            bd(2) = Replace(strTemp(i - 10), "'", "")  'チーム名（A)
                            bd(3) = strTemp(i + 23) '１×２　オッズ（１）
                            bd(4) = Replace(strTemp(i - 9), "'", "") 'チーム名（B)
                            bd(5) = strTemp(i + 24) '１×２　オッズ（２）
                            bd(6) = "Draw" 'チーム名（引分）
                            bd(7) = strTemp(i + 25) '１×２　オッズ（引分）


                            bd(8) = ossou(es.GetElementsByTagName("td").Item(15).InnerText) 'オーバー
                            bd(9) = ou(0)
                            bd(10) = ou(1)
                            bd(11) = ossou(es.GetElementsByTagName("td").Item(14).InnerText) 'アンダー
                            bd(12) = ou(0)
                            bd(13) = ou(1)


                            bd(18) = bookm + bd(0) + bd(1) + bd(2) + bd(4)

                            'テキストボックスに表示
                            ' text_show(cnt)
                            For i2 = 0 To 13
                                bd(i2) = SpaceDel(bd(i2))
                            Next

                            ' Web_book = My.Settings("serverurl") + "?book=" + bookm + "&a_1=" + bd(0) + "&a_2=" + bd(1) + "&a_3=" + bd(2) + " &a_4=" + bd(3) + "&a_5=" + bd(4) + "&a_6=" + bd(5) + "&a_7=" + bd(6) + " &a_8=" + bd(7) + " &a_18=" + bd(18) + " &a_19="
                            Web_book = My.Settings("serverurl") + "?book=" + bookm + "&a_1=" + bd(0) + "&a_2=" + bd(1) + "&a_3=" + bd(2) + " &a_4=" + bd(3) + "&a_5=" + bd(4) + "&a_6=" + bd(5) + "&a_7=" + bd(6) + " &a_8=" + bd(7) + " &a_9=" + bd(9) + " &a_10=" + bd(10) + " &a_11=" + bd(12) + " &a_12=" + bd(13) + " &a_18=" + bd(18) + " &a_19="
                            oss_web_write(Web_book)
                            System.Threading.Thread.Sleep(1000)

                        End If
                        i += 1
                    Next





                End If
                Next


                ToolStripStatusLabel1.Text = "解析完了"

                If datei < 6 Then


                    Dim dtNow As DateTime = DateTime.Now
                    dtNow = dtNow.AddDays(datei)
                    datei += 1
                    URL = My.Settings("url2") & dtNow.ToString("yyyy-MM-dd")
                    My.Settings("url1") = URL

                    '  wb1.Navigate(New System.Uri(URL))
                End If

            End If
        End Sub


    End Class
