Public Class Class1
    Private HTML_TXT As Object 'HTML内容
    Private HTML_TXT2 As Object 'HTML内容

    Private Web_book As String '保存内容
    Dim bd(20) As String 'ブックメーカー項目

    Private ou(1) As String 'オーバーアンダー


    Private datei As Integer = 1 '日付
    Private p_date As String = 1 '試合日

    Private pinnacle_id = My.Settings("id1")
    Private pinnacle_pass = My.Settings("pass1")
    Private Url = My.Settings("url1")
    Private bookm = My.Settings("bookm")

     "http://txodds.com/odds/txt?ocflags=3&amp;pgid=15254,15281,15290,15291,15302,15304,15371,15393,15627,15628,16035,16070,16089,16768,16781,16893,16900,16907,16944,16955,16988,17019,17026,17060,17075,17109,17113,17114,17150,17188,17200,17357,17418,17458,17459,17669,17698,17702,17823,17851,17988,17989,17994,18117,18153,18259,18271,18325,18464,18638&amp;date=2014-10-06%2000:00,2014-10-07%2000:00&amp;layout=0&amp;bid=83&amp;ot=0,4"
    188 bid=365
    BETCRIS bid=238
    SBO bid=327
    PINACLE bid=83
    Private TX_url = http://txodds.com/odds/txt?ocflags=3&amp;pgid=14844,15276,15277,15291,15302,15311,15371,15399,15628,15832,15833,16070,16100,16195,16640,16659,16813,16954,16955,16975,16998,17004,17025,17029,17057,17065,17076,17079,17107,17150,17171,17199,17200,17416,17438,17444,17496,17664,17668,17669,17702,17817,17851,18034,18072,18079,18088,18099,18117,18134,18151,18154,18512,18526,18961,19117,19119&amp;date=2014-10-08%2000:00,2014-10-09%2000:00&amp;layout=0&amp;bid=83&amp;ot=0,4

    Private TX_url = "http://txodds.com/odds/txt?ocflags=3&amp;pgid=14844,15254,15276,15277,15281,15290,15291,15302,15304,15311,15371,15393,15399,15627,15628,15832,15833,16035,16070,16089,16100,16195,16640,16659,16768,16781,16813,16893,16900,16907,16944,16954,16955,16975,16988,17004,17019,17025,17026,17029,17057,17060,17065,17075,17076,17079,17107,17109,17113,17114,17150,17171,17188,17199,17200,17357,17416,17418,17438,17444,17458,17459,17496,17664,17668,17669,17698,17702,17817,17823,17851,17988,17989,17994,18034,18072,18079,18088,18099,18117,18134,18151,18153,18154,18259,18271,18325,18464,18512,18526,18961,19117,19119&amp;layout=0&amp;ot=0,4"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        http://txodds.com/odds?ot=0,4&amp;pgid=13043,13053,13191,13229,13234,13235,13236,13237,13238,13239,13249,13250,13261,13263,13267,13268,13287,13329,13330,13331,13332,13333,13334,13338,13339,13361,13362,13363,13364,13367,13372,13373,13374,13375,13400,13401,13417,13418,13419,13438,13442,13443,13444,13445,13452,13454,13455,13460,13462,13549,13551,13552,13554,13555,13559,13564,13565,13566,13572,13574,13576,13577,13579,13581,13597,13598,13599,13609,13628,13629,13638,13639,13643,13644,13646,13647,13648,13656,13678,13693,13699,13703,13705,13707,13732,13763,13769,13782,13797,13800,13801,13826,13858,13860,13864,13887,13888,13901,13903,13917,13929,13981,13985,14032,14033,14035,14060,14070,14073,14074,14097,14114,14118,14128,14173,14184,14185,14193,14219,14232,14257,14302,14303,14320,14323,14370,14371,14380,14382,14383,14510,14633,14793,14911,14977,15022,15023,15026,15055,15056,15090,15092,15093,15242,15253,15276,15283,15284,15285,15290,15291,15310,15311,15371,15375,15377,15385,15389,15589,15594,15624,15627,15661,15710,15712,15727,15730,15735,15738,15827,15829,15834,15898,16027,16036,16080,16089,16121,16173,16207,16218,16280,16282&amp;bid=83&amp;ocflags=3&amp;date=2014-03-24%2008:09,2014-03-31%2000:00&amp;layout=0&amp;txt=1
        Url = My.Settings("url2") & dtNow.ToString("yyyy-MM-dd")
        My.Settings("url1") = Url
        2014-03-24%2008:09,2014-03-31%2000:00&amp;layout=0&amp;txt=1


        Timer1.Enabled = True
        Timer1.Start()

        Timer1.Enabled = True

        Dim dtNows As DateTime = DateTime.Now
        Dim dtNowe As DateTime = DateTime.Now

        dtNows = dtNows.AddDays(0)
        dtNowe = dtNowe.AddDays(1)
        datei += 1

        p_date = dtNows.ToString("yyyy-MM-dd")

        Url = My.Settings("url1") & "83" & "&amp;date=" & dtNows.ToString("yyyy-MM-dd") & "%2000:00," & dtNowe.ToString("yyyy-MM-dd") & "%2000:00&amp;layout=0&amp;txt=1"
        My.Settings("url1") = "http://txodds.com/login"
        wb1.Navigate(New System.Uri(Url))

        WB10.Navigate(My.Settings("url10"))
        WB10.Navigate("http://txodds.com/login")
    End Sub

    Private Sub wb1_DocumentCompleted_1(sender As Object, e As WebBrowserDocumentCompletedEventArgs)
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

        If URL = "http://www.pinnaclesports.com/League/Soccer/French+1/1/Lines.aspx" Then
            If URL = My.Settings("url1") Then
                If InStr(URL, "http://txodds.com/odds?") > 0 Then

                    HTML_TXT = wb1.Document.DomDocument.documentElement.outerhtml
                    HTML_TXT = Replace(HTML_TXT, Chr(34), "") '「"」の削除
                    HTML_TXT = Replace(HTML_TXT, " ", "")
                    HTML_TXT = Replace(HTML_TXT, "　", "")
                    HTML_TXT = Replace(HTML_TXT, "&nbsp;", "")
                    HTML_TXT = Replace(HTML_TXT, "&NBSP;", "")

                    TextBox1.Text = wb1.Document.DomDocument.documentElement.innerTEXT
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


                        MsgBox(strArry2(8))
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


                        bd(8) = ""
                        bd(11) = ""

                        bd(18) = bookm + bd(0) + bd(1) + bd(2) + bd(4)


                        If strArry2(tc2) = "1x2" Then
                            bd(9) = ""
                            bd(10) = ""
                            bd(12) = ""
                            bd(13) = ""

                            bd(3) = txodd(strArry2(tc2 + 1)) '１×２　オッズ（１）
                            bd(5) = txodd(strArry2(tc2 + 3)) '１×２　オッズ（２）
                            bd(6) = "Draw" 'チーム名（引分）
                            bd(7) = txodd(strArry2(tc2 + 2)) '１×２　オッズ（引分）
                        ElseIf strArry2(tc2) = "tot" Then
                            bd(3) = ""
                            bd(5) = ""
                            bd(6) = ""
                            bd(7) = ""

                            bd(9) = strArry2(tc2 + 3)
                            bd(10) = txodd(strArry2(tc2 + 1))
                            bd(12) = strArry2(tc2 + 3)
                            bd(13) = txodd(strArry2(tc2 + 2))
                        End If


                        Dim bs = ""

                        For i2 = 0 To 13
                            bd(i2) = SpaceDel(bd(i2))
                            bs = bs & " " & bd(i2)
                        Next
                        TextBox1.Text += bs + vbCrLf

                        Web_book = My.Settings("serverurl") + "?book=" + bookm + "&a_1=" + bd(0) + "&a_2=" + bd(1) + "&a_3=" + bd(2) + " &a_4=" + bd(3) + "&a_5=" + bd(4) + "&a_6=" + bd(5) + "&a_7=" + bd(6) + "&a_8=" + bd(7) + "&a_9=" + bd(9) + "&a_10=" + bd(10) + "&a_11=" + bd(12) + "&a_12=" + bd(13) + "&a_18=" + bd(18) + "&a_19="
                        Web_book = My.Settings("serverurl") + "?book=" + bd(1) + "&a_1=" + p_date + "&a_2=" + bd(1) + "&a_3=" + bd(2) + " &a_4=" + bd(3) + "&a_5=" + bd(4) + "&a_6=" + bd(5) + "&a_7=" + bd(6) + "&a_8=" + bd(7) + "&a_9=" + bd(9) + "&a_10=" + bd(10) + "&a_11=" + bd(12) + "&a_12=" + bd(13) + "&a_18=" + bd(18) + "&a_19="
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

                                    テキストボックスに表示()
                                    text_show(cnt)
                                    For i2 = 0 To 13
                                        bd(i2) = SpaceDel(bd(i2))
                                    Next

                                    Web_book = My.Settings("serverurl") + "?book=" + bookm + "&a_1=" + bd(0) + "&a_2=" + bd(1) + "&a_3=" + bd(2) + " &a_4=" + bd(3) + "&a_5=" + bd(4) + "&a_6=" + bd(5) + "&a_7=" + bd(6) + " &a_8=" + bd(7) + " &a_18=" + bd(18) + " &a_19="
                                    Web_book = My.Settings("serverurl") + "?book=" + p_date + "&a_1=" + bd(0) + "&a_2=" + bd(1) + "&a_3=" + bd(2) + " &a_4=" + bd(3) + "&a_5=" + bd(4) + "&a_6=" + bd(5) + "&a_7=" + bd(6) + " &a_8=" + bd(7) + " &a_9=" + bd(9) + " &a_10=" + bd(10) + " &a_11=" + bd(12) + " &a_12=" + bd(13) + " &a_18=" + bd(18) + " &a_19="
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

                    End If

                End If
    End Sub

    Private Sub oss_web_write(txt)
        http://s-commu.jp/abit/bookm.php?a_1=1&a_2=2&a_3=4&a_4=4&a_5=5&a_6=6
        WB2.Navigate(New System.Uri(txt))
    End Sub

    Private Sub PinnaclesportscomToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PinnaclesportscomToolStripMenuItem.Click
        wb1.Navigate(New System.Uri(Url))
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        wb1.Navigate("http://backyjob.xsrv.jp/abi")
        wb1.Navigate("http://txodds.com/odds/txt?ocflags=3&amp;pgid=15276,15302,15393,15591,15627,15628,15792,16089,16100,16121,16218,16459,16491,16640,16689,16745,16780,16786,16936,16937,16943,16988,17099,17151,17173,17364,17417,17438,17441,17455,17698,17817,17850,17994&amp;date=2014-08-21%2000:00,2014-08-22%2000:00&amp;layout=0&amp;bid=42,83,238,274,327,365&amp;ot=0,4")

        Dim url2 = "http://txodds.com/odds/txt?ocflags=3&amp;pgid=15276,15302,15393,15591,15627,15628,15832,16089,16100,16121,16218,16459,16491,16640,16659,16689,16745,16780,16786,16936,16937,16943,16988,17099,17150,17151,17173,17364,17417,17438,17441,17455,17698,17817,17850,17994&amp;date=2014-08-21%2000:00,2014-08-22%2000:00&amp;layout=0&amp;bid=42,83,238,274,327,365&amp;ot=0,4"
        url2 = "http://txodds.com/odds/txt?ocflags=3&amp;pgid=15104,15230,15273,15276,15277,15281,15290,15291,15304,15371,15393,15394,15591,15592,15594,15624,15625,15674,15704,15712,15790,15792,15793,15823,15832,15833,15849,15878,15924,15957,16035,16036,16089,16096,16100,16101,16121,16208,16218,16348,16399,16400,16422,16423,16424,16425,16426,16427,16428,16429,16430,16459,16493,16494,16541,16595,16768,16769,16781,16819,16820,16822,16823,16824,16828,16843,16881,16882,16883,16885,16887,16888,16889,16890,16891,16892,16893,16894,16895,16896,16897,16898,16899,16900,16901,16907,16909,16911,16943,16944,16945,16954,16957,16958,16959,16974,16975,16983,16993,16995,16996,16998,17002,17003,17004,17005,17019,17026,17060,17064,17065,17075,17076,17078,17079,17086,17087,17089,17090,17094,17095,17099,17107,17108,17109,17112,17114,17122,17128,17150,17151,17171,17188,17189,17200,17360,17363,17367,17411,17440,17443,17445,17447,17456,17465,17470,17471,17472,17477,17495,17496,17500,17516,17631,17668,17670,17695,17823,17843,17848,17850,17852,17853,17855,17857,17919,17929,17957,18003,18006,18024,18072,18077,18087,18088,18143,18153,18244,18245&amp;date=2014-09-13%2000:00,2014-09-14%2000:00&amp;layout=0&amp;bid=42,83,238,274,327,365&amp;ot=0,4"

        WB10.Navigate(url2)
    End Sub


    Private Sub LoginToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoginToolStripMenuItem.Click
        Dim url = "http://txodds.com/odds/txt?ocflags=3&amp;pgid=15276,15302,15393,15591,15627,15628,15832,16089,16100,16121,16218,16459,16491,16640,16659,16689,16745,16780,16786,16936,16937,16943,16988,17099,17150,17151,17173,17364,17417,17438,17441,17455,17698,17817,17850,17994&amp;date=2014-08-21%2000:00,2014-08-22%2000:00&amp;layout=0&amp;bid=42,83,238,274,327,365&amp;ot=0,4"

        url = "http://txodds.com/odds/txt?ocflags=3&amp;pgid=15104,15230,15273,15276,15277,15281,15290,15291,15304,15371,15393,15394,15591,15592,15594,15624,15625,15674,15704,15712,15790,15792,15793,15823,15832,15833,15849,15878,15924,15957,16035,16036,16089,16096,16100,16101,16121,16208,16218,16348,16399,16400,16422,16423,16424,16425,16426,16427,16428,16429,16430,16459,16493,16494,16541,16595,16768,16769,16781,16819,16820,16822,16823,16824,16828,16843,16881,16882,16883,16885,16887,16888,16889,16890,16891,16892,16893,16894,16895,16896,16897,16898,16899,16900,16901,16907,16909,16911,16943,16944,16945,16954,16957,16958,16959,16974,16975,16983,16993,16995,16996,16998,17002,17003,17004,17005,17019,17026,17060,17064,17065,17075,17076,17078,17079,17086,17087,17089,17090,17094,17095,17099,17107,17108,17109,17112,17114,17122,17128,17150,17151,17171,17188,17189,17200,17360,17363,17367,17411,17440,17443,17445,17447,17456,17465,17470,17471,17472,17477,17495,17496,17500,17516,17631,17668,17670,17695,17823,17843,17848,17850,17852,17853,17855,17857,17919,17929,17957,18003,18006,18024,18072,18077,18087,18088,18143,18153,18244,18245&amp;date=2014-09-13%2000:00,2014-09-14%2000:00&amp;layout=0&amp;bid=42,83,238,274,327,365&amp;ot=0,4"

        WB10.Navigate(url)
        WB10.Visible = False

        Dim dtNows As DateTime = DateTime.Now
        Dim dtNowe As DateTime = DateTime.Now

        dtNows = dtNows.AddDays(0)
        dtNowe = dtNowe.AddDays(1)
        datei += 1
        p_date = dtNows.ToString("yyyy-MM-dd")

        Dim url2 = TX_url & "&amp;date=" & dtNows.ToString("yyyy-MM-dd") & "%2000:00," & dtNowe.ToString("yyyy-MM-dd") & "%2000:00&amp;bid=83"
        WebBrowser4.Navigate(url2)

        url2 = TX_url & "&amp;date=" & dtNows.ToString("yyyy-MM-dd") & "%2000:00," & dtNowe.ToString("yyyy-MM-dd") & "%2000:00&amp;bid=365"
        WebBrowser1.Navigate(url2)

        url2 = TX_url & "&amp;date=" & dtNows.ToString("yyyy-MM-dd") & "%2000:00," & dtNowe.ToString("yyyy-MM-dd") & "%2000:00&amp;bid=238"
        WebBrowser2.Navigate(url2)


        url2 = TX_url & "&amp;date=" & dtNows.ToString("yyyy-MM-dd") & "%2000:00," & dtNowe.ToString("yyyy-MM-dd") & "%2000:00&amp;bid=327"
        WebBrowser3.Navigate(url2)

        Dim url2 = TX_url & "&amp;date=" & dtNows.ToString("yyyy-MM-dd") & "%2000:00," & dtNowe.ToString("yyyy-MM-dd") & "%2000:00&amp;bid=365,238,327,83"
        WebBrowser1.Navigate(url2)



    End Sub

    Private Sub WB10_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WB10.DocumentCompleted
        On Error Resume Next
        Dim URL As String = e.Url.ToString()

        If URL = "http://backyjob.xsrv.jp/abi/" Then
            WB10.Navigate(New System.Uri(My.Settings("url1")))
            Exit Sub
        End If

        Do While WB10.IsBusy
            System.Windows.Forms.Application.DoEvents()
        Loop

        While WB10.IsBusy
            System.Windows.Forms.Application.DoEvents()
        End While

        While WB10.ReadyState <> WebBrowserReadyState.Complete
            System.Windows.Forms.Application.DoEvents()
        End While


        Dim cnt = -2
        Dim chekHTML
        Dim chekHTML2
        Dim strArry() As String
        Dim strArry2() As String

        If URL = "http://www.pinnaclesports.com/League/Soccer/French+1/1/Lines.aspx" Then
            If URL = My.Settings("url1") Then
                Dim ab = InStr(URL, "http://txodds.com/odds/txt?")
                If InStr(URL, "http://txodds.com/odds/txt?") > 0 Then

                    読込HTML取得()
                    HTML_TXT = wb1.Document.DomDocument.documentElement.outerhtml
                    HTML_TXT = Replace(HTML_TXT, Chr(34), "") '「"」の削除
                    HTML_TXT = Replace(HTML_TXT, " ", "")
                    HTML_TXT = Replace(HTML_TXT, "　", "")
                    HTML_TXT = Replace(HTML_TXT, "&nbsp;", "")
                    HTML_TXT = Replace(HTML_TXT, "&NBSP;", "")

                    TextBox1.Text = wb1.Document.DomDocument.documentElement.innerTEXT
                    strArry = Split(WB10.Document.DomDocument.documentElement.innerTEXT, vbCrLf)
                    Dim re As System.Text.RegularExpressions.Regex
                    re = New System.Text.RegularExpressions.Regex("\s+")

                    Dim tc1 = 0
                    Dim tc2 = 0

                    Dim leag_flg = 0
                    Dim leag_name

                    For Each osdata As String In strArry
                        osdata = Replace(osdata, " Hi", "Hi")
                        strArry2 = re.Split(osdata)


                        If InStr(strArry2(0), "-2014") > 0 Then
                            leag_flg = 1
                            Continue For
                        End If

                        If leag_flg = 1 Then
                            leag_flg = 0
                            leag_name = osdata
                            Continue For
                        End If

                        Dim i = 0
                        For Each tc As String In strArry2
                            If tc = "-" Then
                                tc1 = i
                            ElseIf tc = "1x2" Or tc = "tot" Then
                                tc2 = i
                            End If
                            i += 1
                        Next


                        MsgBox(strArry2(8))
                        Dim dt() As String

                        strArry2(0) = Replace(strArry2(0), "-0", "-")
                        dt = Split(strArry2(0), "-")

                        bd(0) = dt(1) & "/" & dt(2) '曜日
                        bd(1) = strArry2(1) '時間

                        Dim dt2() As String

                        strArry2(0) = Replace(strArry2(tc2 + 4), "-0", "-")
                        dt2 = Split(strArry2(0), "-")


                        Dim teama = osdata.Substring(0, InStr(osdata, "-"))
                        teama = teama.Substring(InStr(teama, "  "))
                        teama = Replace(teama, "  ", "")
                        teama = Replace(teama, "-", "")

                        Dim teamb = osdata.Substring(InStr(osdata, "-"))
                        teamb = teamb.Substring(0, InStr(teamb, "  "))
                        teamb = Replace(teamb, "  ", "")

                        bd(2) = teama  'チーム名（A)
                        bd(4) = teamb  'チーム名（B)



                        bd(8) = ""
                        bd(11) = ""

                        区別名()
                        bd(18) = bookm + bd(0) + bd(1) + bd(2) + bd(4)

                        オッズ()

                        Dim arl = strArry2.Length

                        If strArry2(arl - 2) = "-" Then
                            MsgBox("tot")
                            bd(3) = ""
                            bd(5) = ""
                            bd(6) = ""
                            bd(7) = ""

                            bd(9) = strArry2(arl - 1) 'tot
                            bd(10) = strArry2(arl - 4) 'oss(1)
                            bd(12) = strArry2(arl - 1) 'tot
                            bd(13) = strArry2(arl - 3) 'oss(2)
                        Else
                            MsgBox("1*2")
                            bd(9) = ""
                            bd(10) = ""
                            bd(12) = ""
                            bd(13) = ""

                            bd(3) = strArry2(arl - 3) '１×２　オッズ（１）
                            bd(5) = strArry2(arl - 1) '１×２　オッズ（２）
                            bd(6) = "Draw" 'チーム名（引分）
                            bd(7) = strArry2(arl - 2) '１×２　オッズ（引分）
                        End If

                        Dim stCurrentDir As String = System.IO.Directory.GetCurrentDirectory()
                        Dim textFile As System.IO.StreamWriter

                        Dim rtxt = bookm + "," + bd(0) + "," + bd(1) + "," + bd(2) + " ," + bd(3) + "," + bd(4) + "," + bd(5) + "," + bd(6) + "," + bd(7) + "," + bd(9) + "," + bd(10) + "," + bd(12) + "," + bd(13) + "," + bd(18)

                        textFile = New System.IO.StreamWriter(stCurrentDir & "\\log.txt", True, System.Text.Encoding.Default)
                        textFile.WriteLine(rtxt)
                        textFile.Close()



                        Web_book = My.Settings("serverurl") + "?book=" + bookm + "&a_1=" + bd(0) + "&a_2=" + bd(1) + "&a_3=" + bd(2) + " &a_4=" + bd(3) + "&a_5=" + bd(4) + "&a_6=" + bd(5) + "&a_7=" + bd(6) + "&a_8=" + bd(7) + "&a_9=" + bd(9) + "&a_10=" + bd(10) + "&a_11=" + bd(12) + "&a_12=" + bd(13) + "&a_18=" + bd(18) + "&a_19="
                        Web_book = My.Settings("serverurl") + "?book=" + bd(1) + "&a_1=" + p_date + "&a_2=" + bd(1) + "&a_3=" + bd(2) + " &a_4=" + bd(3) + "&a_5=" + bd(4) + "&a_6=" + bd(5) + "&a_7=" + bd(6) + "&a_8=" + bd(7) + "&a_9=" + bd(9) + "&a_10=" + bd(10) + "&a_11=" + bd(12) + "&a_12=" + bd(13) + "&a_18=" + bd(18) + "&a_19="
                        oss_web_write(Web_book)
                        System.Threading.Thread.Sleep(1000)
                    Next


                    Dim url2 = "http://txodds.com/odds/txt?ocflags=3&amp;pgid=15276,15302,15393,15591,15627,15628,15832,16089,16100,16121,16218,16459,16491,16640,16659,16689,16745,16780,16786,16936,16937,16943,16988,17099,17150,17151,17173,17364,17417,17438,17441,17455,17698,17817,17850,17994&amp;date=2014-08-21%2000:00,2014-08-22%2000:00&amp;layout=0&amp;bid=42,83,238,274,327,365&amp;ot=0,4"
                    url2 = "http://txodds.com/odds/txt?ocflags=3&amp;pgid=15104,15230,15273,15276,15277,15281,15290,15291,15304,15371,15393,15394,15591,15592,15594,15624,15625,15674,15704,15712,15790,15792,15793,15823,15832,15833,15849,15878,15924,15957,16035,16036,16089,16096,16100,16101,16121,16208,16218,16348,16399,16400,16422,16423,16424,16425,16426,16427,16428,16429,16430,16459,16493,16494,16541,16595,16768,16769,16781,16819,16820,16822,16823,16824,16828,16843,16881,16882,16883,16885,16887,16888,16889,16890,16891,16892,16893,16894,16895,16896,16897,16898,16899,16900,16901,16907,16909,16911,16943,16944,16945,16954,16957,16958,16959,16974,16975,16983,16993,16995,16996,16998,17002,17003,17004,17005,17019,17026,17060,17064,17065,17075,17076,17078,17079,17086,17087,17089,17090,17094,17095,17099,17107,17108,17109,17112,17114,17122,17128,17150,17151,17171,17188,17189,17200,17360,17363,17367,17411,17440,17443,17445,17447,17456,17465,17470,17471,17472,17477,17495,17496,17500,17516,17631,17668,17670,17695,17823,17843,17848,17850,17852,17853,17855,17857,17919,17929,17957,18003,18006,18024,18072,18077,18087,18088,18143,18153,18244,18245&amp;date=2014-09-13%2000:00,2014-09-14%2000:00&amp;layout=0&amp;bid=42,83,238,274,327,365&amp;ot=0,4"
                    WB10.Navigate(url2)



                    For Each es As HtmlElement In WB10.Document.GetElementsByTagName("script")

                        MsgBox(oos)
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

                                    テキストボックスに表示()
                                    text_show(cnt)
                                    For i2 = 0 To 13
                                        bd(i2) = SpaceDel(bd(i2))
                                    Next

                                    Web_book = My.Settings("serverurl") + "?book=" + bookm + "&a_1=" + bd(0) + "&a_2=" + bd(1) + "&a_3=" + bd(2) + " &a_4=" + bd(3) + "&a_5=" + bd(4) + "&a_6=" + bd(5) + "&a_7=" + bd(6) + " &a_8=" + bd(7) + " &a_18=" + bd(18) + " &a_19="
                                    Web_book = My.Settings("serverurl") + "?book=" + bookm + "&a_1=" + bd(0) + "&a_2=" + bd(1) + "&a_3=" + bd(2) + " &a_4=" + bd(3) + "&a_5=" + bd(4) + "&a_6=" + bd(5) + "&a_7=" + bd(6) + " &a_8=" + bd(7) + " &a_9=" + bd(9) + " &a_10=" + bd(10) + " &a_11=" + bd(12) + " &a_12=" + bd(13) + " &a_18=" + bd(18) + " &a_19="
                                    Web_book = My.Settings("serverurl") + "?book=" + bd(1) + "&a_1=" + p_date + "&a_2=" + bd(1) + "&a_3=" + bd(2) + " &a_4=" + bd(3) + "&a_5=" + bd(4) + "&a_6=" + bd(5) + "&a_7=" + bd(6) + " &a_8=" + bd(7) + " &a_9=" + bd(9) + " &a_10=" + bd(10) + " &a_11=" + bd(12) + " &a_12=" + bd(13) + " &a_18=" + bd(18) + " &a_19="
                                    oss_web_write(Web_book)
                                    System.Threading.Thread.Sleep(1000)

                                End If
                                i += 1
                            Next





                        End If
                    Next


                End If



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim dtNows As DateTime = DateTime.Now
        Dim dtNowe As DateTime = DateTime.Now

        dtNows = dtNows.AddDays(0)
        dtNowe = dtNowe.AddDays(1)
        datei += 1

        p_date = dtNows.ToString("yyyy-MM-dd")

        Dim url2 = TX_url & "&amp;date=" & dtNows.ToString("yyyy-MM-dd") & "%2000:00," & dtNowe.ToString("yyyy-MM-dd") & "%2000:00&amp;bid=365"

        WebBrowser1.Navigate(url2)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim url2 = "http://txodds.com/odds/txt?ocflags=3&amp;pgid=15276,15302,15393,15591,15627,15628,15832,16089,16100,16121,16218,16459,16491,16640,16659,16689,16745,16780,16786,16936,16937,16943,16988,17099,17150,17151,17173,17364,17417,17438,17441,17455,17698,17817,17850,17994&amp;date=2014-08-21%2000:00,2014-08-22%2000:00&amp;layout=0&amp;bid=42,83,238,274,327,365&amp;ot=0,4"
        url2 = "http://txodds.com/odds/txt?ocflags=3&amp;pgid=15104,15230,15273,15276,15277,15281,15290,15291,15304,15371,15393,15394,15591,15592,15594,15624,15625,15674,15704,15712,15790,15792,15793,15823,15832,15833,15849,15878,15924,15957,16035,16036,16089,16096,16100,16101,16121,16208,16218,16348,16399,16400,16422,16423,16424,16425,16426,16427,16428,16429,16430,16459,16493,16494,16541,16595,16768,16769,16781,16819,16820,16822,16823,16824,16828,16843,16881,16882,16883,16885,16887,16888,16889,16890,16891,16892,16893,16894,16895,16896,16897,16898,16899,16900,16901,16907,16909,16911,16943,16944,16945,16954,16957,16958,16959,16974,16975,16983,16993,16995,16996,16998,17002,17003,17004,17005,17019,17026,17060,17064,17065,17075,17076,17078,17079,17086,17087,17089,17090,17094,17095,17099,17107,17108,17109,17112,17114,17122,17128,17150,17151,17171,17188,17189,17200,17360,17363,17367,17411,17440,17443,17445,17447,17456,17465,17470,17471,17472,17477,17495,17496,17500,17516,17631,17668,17670,17695,17823,17843,17848,17850,17852,17853,17855,17857,17919,17929,17957,18003,18006,18024,18072,18077,18087,18088,18143,18153,18244,18245&amp;date=2014-09-13%2000:00,2014-09-14%2000:00&amp;layout=0&amp;bid=42,83,238,274,327,365&amp;ot=0,4"
        wb1.Navigate(url2)
    End Sub



    Private Sub Web_txt(html, url)
        On Error Resume Next

        Dim cnt = -2
        Dim chekHTML
        Dim chekHTML2
        Dim strArry() As String
        Dim strArry2() As String

        Dim ab = InStr(url, "http://txodds.com/odds/txt?")
        If InStr(url, "http://txodds.com/odds/txt?") > 0 Then

            strArry = Split(html, vbCrLf)
            Dim re As System.Text.RegularExpressions.Regex
            re = New System.Text.RegularExpressions.Regex("\s+")

            Dim tc1 = 0
            Dim tc2 = 0

            Dim leag_flg = 0
            Dim leag_name

            For Each osdata As String In strArry
                osdata = Replace(osdata, " Hi", "Hi")
                strArry2 = re.Split(osdata)

                If InStr(strArry2(0), "-2014") > 0 Then
                    leag_flg = 1
                    Continue For
                End If

                If leag_flg = 1 Then
                    leag_flg = 0
                    leag_name = osdata
                    Continue For
                End If

                Dim i = 0
                For Each tc As String In strArry2
                    If tc = "-" Then
                        tc1 = i
                    ElseIf tc = "1x2" Or tc = "tot" Then
                        tc2 = i
                    End If
                    i += 1
                Next


                Dim dt() As String

                strArry2(0) = Replace(strArry2(0), "-0", "-")
                dt = Split(strArry2(0), "-")

                bd(0) = dt(1) & "/" & dt(2) '曜日
                bd(1) = strArry2(1) '時間

                Dim dt2() As String

                strArry2(0) = Replace(strArry2(tc2 + 4), "-0", "-")
                dt2 = Split(strArry2(0), "-")


                Dim teama = osdata.Substring(0, InStr(osdata, "-"))
                teama = teama.Substring(InStr(teama, "  "))
                teama = Replace(teama, "  ", "")
                teama = Replace(teama, "-", "")

                Dim teamb = osdata.Substring(InStr(osdata, "-"))
                teamb = teamb.Substring(0, InStr(teamb, "  "))
                teamb = Replace(teamb, "  ", "")

                bd(2) = teama  'チーム名（A)
                bd(4) = teamb  'チーム名（B)

                bd(8) = ""
                bd(11) = ""

                区別名()
                bd(18) = bd(0) + bd(1) + bd(2) + bd(4)

                オッズ()

                Dim arl = strArry2.Length

                If strArry2(arl - 2) = "-" Then
                    MsgBox("tot")
                    bd(3) = ""
                    bd(5) = ""
                    bd(6) = ""
                    bd(7) = ""

                    bd(9) = strArry2(arl - 1) 'tot
                    bd(10) = strArry2(arl - 4) 'oss(1)
                    bd(12) = strArry2(arl - 1) 'tot
                    bd(13) = strArry2(arl - 3) 'oss(2)
                Else
                    MsgBox("1*2")
                    bd(9) = ""
                    bd(10) = ""
                    bd(12) = ""
                    bd(13) = ""

                    bd(3) = strArry2(arl - 3) '１×２　オッズ（１）
                    bd(5) = strArry2(arl - 1) '１×２　オッズ（２）
                    bd(6) = "Draw" 'チーム名（引分）
                    bd(7) = strArry2(arl - 2) '１×２　オッズ（引分）
                End If

                Dim stCurrentDir As String = System.IO.Directory.GetCurrentDirectory()
                Dim textFile As System.IO.StreamWriter

                Dim rtxt = bd(1) + "," + bd(0) + "," + bd(1) + "," + bd(2) + " ," + bd(3) + "," + bd(4) + "," + bd(5) + "," + bd(6) + "," + bd(7) + "," + bd(9) + "," + bd(10) + "," + bd(12) + "," + bd(13) + "," + bd(18) + "," + leag_name + "," + DateTime.Now.ToString("HH:mm")

                textFile = New System.IO.StreamWriter(stCurrentDir & "\\" & DateTime.Now.ToString("yyyyMMdd") & "log.txt", True, System.Text.Encoding.Default)
                textFile.WriteLine(rtxt)
                textFile.Close()

                Web_book = My.Settings("serverurl") + "?book=" + bookm + "&a_1=" + bd(0) + "&a_2=" + bd(1) + "&a_3=" + bd(2) + " &a_4=" + bd(3) + "&a_5=" + bd(4) + "&a_6=" + bd(5) + "&a_7=" + bd(6) + "&a_8=" + bd(7) + "&a_9=" + bd(9) + "&a_10=" + bd(10) + "&a_11=" + bd(12) + "&a_12=" + bd(13) + "&a_18=" + bd(18) + "&a_19="
                Web_book = My.Settings("serverurl") + "?book=" + bd(1) + "&a_1=" + p_date + "&a_2=" + bd(1) + "&a_3=" + bd(2) + " &a_4=" + bd(3) + "&a_5=" + bd(4) + "&a_6=" + bd(5) + "&a_7=" + bd(6) + "&a_8=" + bd(7) + "&a_9=" + bd(9) + "&a_10=" + bd(10) + "&a_11=" + bd(12) + "&a_12=" + bd(13) + "&a_18=" + bd(18) + "&a_17=" + leag_name
                oss_web_write(Web_book)
                WebBrowser4.Navigate(Web_book)
                System.Threading.Thread.Sleep(200)
            Next

            WebBrowser4.Refresh()


            Dim dtNows As DateTime = DateTime.Now
            Dim dtNowe As DateTime = DateTime.Now

            dtNows = dtNows.AddDays(0)
            dtNowe = dtNowe.AddDays(1)
            datei += 1
            p_date = dtNows.ToString("yyyy-MM-dd")
            Dim url2 = TX_url & "&amp;date=" & dtNows.ToString("yyyy-MM-dd") & "%2000:00," & dtNowe.ToString("yyyy-MM-dd") & "%2000:00&amp;bid=365,238,327,83"
            WebBrowser1.Navigate(url2)

        End If
        Exit Sub
    End Sub




    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        Do While WebBrowser1.IsBusy
            System.Windows.Forms.Application.DoEvents()
        Loop

        While WebBrowser1.IsBusy
            System.Windows.Forms.Application.DoEvents()
        End While

        While WebBrowser1.ReadyState <> WebBrowserReadyState.Complete
            System.Windows.Forms.Application.DoEvents()
        End While

        Web_txt(WebBrowser1.Document.DomDocument.documentElement.innerTEXT, e.Url.ToString())


        Dim dtNows As DateTime = DateTime.Now
        Dim dtNowe As DateTime = DateTime.Now

        dtNows = dtNows.AddDays(0)
        dtNowe = dtNowe.AddDays(1)
        datei += 1
        p_date = dtNows.ToString("yyyy-MM-dd")
        Dim url2 = TX_url & "&amp;date=" & dtNows.ToString("yyyy-MM-dd") & "%2000:00," & dtNowe.ToString("yyyy-MM-dd") & "%2000:00&amp;bid=365"
        WebBrowser1.Navigate(url2)

    End Sub


    Private Sub WebBrowser2_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser2.DocumentCompleted
        Do While WebBrowser2.IsBusy
            System.Windows.Forms.Application.DoEvents()
        Loop

        While WebBrowser2.IsBusy
            System.Windows.Forms.Application.DoEvents()
        End While

        While WebBrowser2.ReadyState <> WebBrowserReadyState.Complete
            System.Windows.Forms.Application.DoEvents()
        End While

        Web_txt(WebBrowser2.Document.DomDocument.documentElement.innerTEXT, e.Url.ToString())

        Dim dtNows As DateTime = DateTime.Now
        Dim dtNowe As DateTime = DateTime.Now

        dtNows = dtNows.AddDays(0)
        dtNowe = dtNowe.AddDays(1)
        datei += 1
        p_date = dtNows.ToString("yyyy-MM-dd")
        Dim url2 = TX_url & "&amp;date=" & dtNows.ToString("yyyy-MM-dd") & "%2000:00," & dtNowe.ToString("yyyy-MM-dd") & "%2000:00&amp;bid=238"
        WebBrowser2.Navigate(url2)

    End Sub

    Private Sub WebBrowser3_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser3.DocumentCompleted
        Do While WebBrowser3.IsBusy
            System.Windows.Forms.Application.DoEvents()
        Loop

        While WebBrowser3.IsBusy
            System.Windows.Forms.Application.DoEvents()
        End While

        While WebBrowser3.ReadyState <> WebBrowserReadyState.Complete
            System.Windows.Forms.Application.DoEvents()
        End While

        Web_txt(WebBrowser3.Document.DomDocument.documentElement.innerTEXT, e.Url.ToString())


        Dim dtNows As DateTime = DateTime.Now
        Dim dtNowe As DateTime = DateTime.Now

        dtNows = dtNows.AddDays(0)
        dtNowe = dtNowe.AddDays(1)
        datei += 1
        p_date = dtNows.ToString("yyyy-MM-dd")
        Dim url2 = TX_url & "&amp;date=" & dtNows.ToString("yyyy-MM-dd") & "%2000:00," & dtNowe.ToString("yyyy-MM-dd") & "%2000:00&amp;bid=327"
        WebBrowser3.Navigate(url2)

    End Sub

    Private Sub WebBrowser4_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser4.DocumentCompleted
        Do While WebBrowser4.IsBusy
            System.Windows.Forms.Application.DoEvents()
        Loop

        While WebBrowser4.IsBusy
            System.Windows.Forms.Application.DoEvents()
        End While

        ドキュメントの読み込みが完了するまで待機する(JavaScript)
        While WebBrowser4.ReadyState <> WebBrowserReadyState.Complete
            System.Windows.Forms.Application.DoEvents()
        End While

        Web_txt(WebBrowser4.Document.DomDocument.documentElement.innerTEXT, e.Url.ToString())


        Dim dtNows As DateTime = DateTime.Now
        Dim dtNowe As DateTime = DateTime.Now

        dtNows = dtNows.AddDays(0)
        dtNowe = dtNowe.AddDays(1)
        datei += 1
        p_date = dtNows.ToString("yyyy-MM-dd")
        Dim url2 = TX_url & "&amp;date=" & dtNows.ToString("yyyy-MM-dd") & "%2000:00," & dtNowe.ToString("yyyy-MM-dd") & "%2000:00&amp;bid=83"
        WebBrowser4.Navigate(url2)

    End Sub

End Class
