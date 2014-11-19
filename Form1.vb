Public Class Form1
    http://pinnaclesports.com
    http://www.5dimes.eu/
    https://en.betclic.com/sport/
    http://sports.williamhill.com/bet/ja
    http://www.marathonbet.com/en/
    https://sports.bwin.com/en/sports
    http://www.188bet.com/en-gb/
    https://www.sbobet.com/
    http://www.12bet.com/index.aspx
    https://www.unibet.com/start
    http://www.ladbrokes.com/en/home6/
    http://www.paddypower.com/


    Private Book_name(15, 10) As String '各ブックメーカー
    Private HTML_TXT As Object 'HTML内容
    Private HTML_TXT2 As Object 'HTML内容

    Private b_url 'BET　URL
    Private abi_url 'アービトラージチェック　URL

    Private Web_book As String '保存内容
    Dim bd(10) As String 'ブックメーカー項目

    Private XML_ck(6) As String '入力チェック
    Dim chekHTML
    Dim chekHTML2
    Dim d_flg = ""
    Dim f_cnt = 0
    Dim es3 As HtmlElement
    Dim es4 As HtmlElement
    Dim strArry() As String

    Private URL As String

    Private Bet_txt(6, 2) As String '日付：チーム名
    Private Bet_oss(6) As Double 'オッズ
    Private Bet_df(6) As Integer 'Drawフラグ
    Private Bet_bet(6) As Integer 'Bet額

    Private Function date_ch(txt)
        txt = Replace(txt, "Mon", "")
        txt = Replace(txt, "Tue", "")
        txt = Replace(txt, "Wed", "")
        txt = Replace(txt, "Thu", "")
        txt = Replace(txt, "Fri", "")
        txt = Replace(txt, "Sat", "")
        txt = Replace(txt, "Sun", "")
        Return txt
    End Function

    Private Function date_ch2(txt)
        Dim strArry() As String
        strArry = Split(txt, "Feb")
        txt = "1/" + strArry(0)
        Return txt
    End Function

    Private Function date_ch3(txt)
        Dim strArry() As String
        strArry = Split(txt, "Feb")
        txt = strArry(1)
        Return txt
    End Function

    Private Function team_name(txt)
        txt = Replace(txt, "(ENG-FACup)", "")
        txt = Replace(txt, "(ENG-P)", "")
        txt = Replace(txt, "(ENG-Trophy)", "")
        txt = Replace(txt, "(ENG-One)", "")
        txt = Replace(txt, "(ENG-Conf)", "")
        Return txt
    End Function

    Private Function oss(txt)
        Dim strArry() As String
        Dim oss2(2) As Integer
        strArry = Split(txt, "/")

        oss2(0) = Integer.Parse(strArry(0))
        oss2(1) = Integer.Parse(strArry(1))

        txt = (oss2(0) + oss2(1)) / oss2(1) * 100
        txt = Math.Floor(txt) / 100

        Return txt
    End Function

    Private Function SpaceDel(txt)
        txt = Replace(txt, " ", "")
        txt = Replace(txt, "　", "")
        Return txt
    End Function

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Environment.Exit(0)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Book_name(1, 0) = My.Resources.book_login_url_1
        Book_name(2, 0) = My.Resources.book_login_url_2
        Book_name(3, 0) = My.Resources.book_login_url_3
        Book_name(4, 0) = My.Resources.book_login_url_4
        Book_name(5, 0) = My.Resources.book_login_url_5
        Book_name(6, 0) = My.Resources.book_login_url_6

        Timer1.Enabled = True

        abi_url = My.Settings.abi_url
        wb_server.Navigate(abi_url)

        wb1.Navigate(Book_name(1, 0))
        wb2.Navigate(Book_name(2, 0))
        wb3.Navigate(Book_name(3, 0))
        wb4.Navigate(Book_name(4, 0))
        wb5.Navigate(Book_name(5, 0))
        wb6.Navigate(Book_name(6, 0))

        Timer2.Enabled = True
        Timer2.Start()
    End Sub

    Private Sub ID管理ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ID管理ToolStripMenuItem.Click
        form2.Show()
    End Sub


    Private Sub Book_login(wb As Object, bURL As String)

        For i = 1 To 10
            Book_name(i, 1) = My.Settings("Book_id_" & i)
            Book_name(i, 2) = My.Settings("Book_pass_" & i)
        Next


        'ログイン処理
        If bURL = "http://www.pinnaclesports.com/League/Soccer/French+1/1/Lines.aspx" Then
            wb.Forms(0).DomElement("UserName").Value = Book_name(1, 1)
            wb.Forms(0).DomElement("password").Value = Book_name(1, 2)
            wb.Forms(0).DomElement("Password").focus()
            SendKeys.SendWait("{TAB}")
            SendKeys.SendWait("{ENTER}")
            ' wb1.Document.Forms(0).DomElement("submit1").click()
        End If

        If bURL = "http://www.5dimes.eu/sportsbook.html" Then
            wb.Forms(0).DomElement("customerID").Value = Book_name(2, 1)
            wb.Forms(0).DomElement("password").Value = Book_name(2, 2)
            wb.Forms(0).DomElement("submit1").click()
        End If


        If bURL = "https://en.betclic.com/sport/" Then
            wb.Forms(0).DomElement("login-username").Value = Book_name(3, 1)
            wb.Forms(0).DomElement("login-password").Value = Book_name(3, 2)
            wb.Forms(0).DomElement("login-submit").click()
        End If


        If bURL = "http://sports.williamhill.com/bet/ja" Then
            wb.Forms(1).DomElement("username").Value = Book_name(4, 1)
            wb.Forms(1).DomElement("password").Value = Book_name(4, 2)
            wb.Forms(1).DomElement("signInBtn").click()

        End If

        If bURL = "http://www.marathonbet.com/en/" Then
            wb.Forms(0).DomElement("auth_login").Value = Book_name(5, 1)
            wb.Forms(0).DomElement("auth_login_password").Value = Book_name(5, 2)
            wb.Forms(0).DomElement("auth_login").focus()
            SendKeys.SendWait("{TAB}{TAB}")
            SendKeys.SendWait("{ENTER}")
            System.Threading.Thread.Sleep(2000)
            For Each es As HtmlElement In wb.GetElementsByTagName("a")
                If es.GetAttribute("className") = "but-login" Then
                    es.InvokeMember("click")
                End If
            Next
        End If

        If bURL = "https://sports.bwin.com/en/sports" Then
            wb.Forms(0).DomElement("username").Value = Book_name(6, 1)
            wb.Forms(0).DomElement("password").Value = Book_name(6, 2)
            wb.Forms(0).DomElement("submit").click()

        End If
    End Sub


    Private Sub wb1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles wb1.DocumentCompleted
        On Error Resume Next

        Do While wb1.IsBusy
            System.Windows.Forms.Application.DoEvents()
        Loop

        URL = e.Url.ToString()
        Book_login(wb1.Document, URL) 'ログイン処理

        HTML_TXT = wb1.Document.DomDocument.documentElement.outerhtml
        HTML_TXT = Replace(HTML_TXT, Chr(34), "") '「"」の削除
        HTML_TXT = Replace(HTML_TXT, " ", "")
        HTML_TXT = Replace(HTML_TXT, "　", "")
        HTML_TXT = Replace(HTML_TXT, "&nbsp;", "")
        HTML_TXT = Replace(HTML_TXT, "&NBSP;", "")


        If URL = "https://www1.pinnaclesports.com/members/canvas.asp#/Members/Lineoffering.asp?display=DynamicLines&sportType=Soccer&sportSubType=Eng.+Premier&descr=1" Then
            wb1.Document.Forms(2).DomElement("M1_350776482_0").Value = ""
            wb1.Document.Forms(2).DomElement("btnSubmitUpper").click()
        End If


        If URL = "http://www.yahoo.co.jp" Then
            b_url = "https://www1.pinnaclesports.com/members/canvas.asp#/Members/Lineoffering.asp?display=DynamicLines&sportType=Soccer&sportSubType=Eng.+Premier&descr=1"
            wb1.Navigate(b_url)
        End If



    End Sub


    Private Sub wb2_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles wb2.DocumentCompleted
        On Error Resume Next
        Do While wb2.IsBusy
            System.Windows.Forms.Application.DoEvents()
        Loop

        URL = e.Url.ToString()
        Book_login(wb2.Document, URL) 'ログイン処理


        If URL = "http://www.5dimes.eu/bbSportSelection.asp" Then
            wb1.Document.Forms(0).DomElement("Soccer_all").click(Soccer_England)
            wb2.Document.Forms(0).DomElement("Soccer_England").click()
            wb2.Document.Forms(0).DomElement("btnContinue").click()
        End If


        If URL = "http://www.5dimes.eu/BbGameSelection.asp" Then
            Dim i As Integer = 0

            Bet_txt(2, 0) = t2_1.Text '日付
            Bet_txt(2, 1) = t2_2.Text 'チーム名
            Bet_oss(2) = t2_3.Text 'オッズ
            Bet_df(2) = t2_4.Text 'Drawフラグ
            Bet_bet(2) = t2_5.Text() 'Bet

            For Each es As HtmlElement In wb2.Document.GetElementsByTagName("div")
                If es.GetAttribute("className") = "linesContainer" Then
                    For Each es2 As HtmlElement In es.Document.GetElementsByTagName("tr")
                        If es2.GetAttribute("className") = "linesRow" Then
                            bd(0) = date_ch(es2.GetElementsByTagName("td").Item(0).InnerText) '曜日
                            bd(2) = es2.GetElementsByTagName("td").Item(2).InnerText.Substring(es2.GetElementsByTagName("td").Item(2).InnerText.IndexOf(" "))  'チーム名（A)
                            bd(2) = team_name(bd(2))
                            bd(3) = es2.GetElementsByTagName("td").Item(4).InnerText '１×２　オッズ（１）

                            BTE値セット()
                            If Bet_txt(2, 1) = bd(2) Then
                                es3 = es2.GetElementsByTagName("td").Item(4)
                                es3 = es3.GetElementsByTagName("input").Item(0)
                                es3.SetAttribute("value", Bet_bet(2))
                            End If

                        ElseIf es2.GetAttribute("className") = "linesRowMid" Then
                            bd(1) = es2.GetElementsByTagName("td").Item(0).InnerText '時間
                            bd(4) = es2.GetElementsByTagName("td").Item(2).InnerText.Substring(es2.GetElementsByTagName("td").Item(2).InnerText.IndexOf(" ") + 1)  'チーム名（B)
                            bd(4) = team_name(bd(4))
                            bd(5) = es2.GetElementsByTagName("td").Item(4).InnerText '１×２　オッズ（２）


                            BTE値セット()
                            If Bet_txt(2, 1) = bd(4) Then
                                es3 = es2.GetElementsByTagName("td").Item(4)
                                es3 = es3.GetElementsByTagName("input").Item(0)
                                es3.SetAttribute("value", Bet_bet(2))
                            End If


                        ElseIf es2.GetAttribute("className") = "linesRowBot" Then
                            bd(6) = "Draw" 'チーム名（引分）
                            bd(7) = es2.GetElementsByTagName("td").Item(4).InnerText '１×２　オッズ（引分）

                            BTE値セット()
                            If (Bet_txt(2, 1) = bd(2) Or Bet_txt(2, 1) = bd(4)) And Bet_df(2) = 1 Then
                                es3 = es2.GetElementsByTagName("td").Item(4)
                                es3 = es3.GetElementsByTagName("input").Item(0)
                                es3.SetAttribute("value", Bet_bet(2))
                            End If

                        End If
                    Next
                End If
            Next
            wb2.Document.Forms(0).DomElement("btnContinue").click()
        End If
    End Sub


    Private Sub wb3_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles wb3.DocumentCompleted
        On Error Resume Next
        Do While wb3.IsBusy
            System.Windows.Forms.Application.DoEvents()
        Loop
        URL = e.Url.ToString()
        Book_login(wb3.Document, URL) 'ログイン処理


        If URL = "https://www1.pinnaclesports.com/members/canvas.asp#/Members/Lineoffering.asp?display=DynamicLines&sportType=Soccer&sportSubType=Eng.+Premier&descr=1" Then
            wb3.Document.Forms(2).DomElement("M1_350776482_0").Value = "22"
            wb3.Document.Forms(2).DomElement("btnSubmitUpper").click()
            Dim cnt = -2

            Bet_txt(3, 0) = t3_1.Text '日付
            Bet_txt(3, 1) = t3_2.Text 'チーム名
            Bet_oss(3) = t3_3.Text 'オッズ
            Bet_df(3) = t3_4.Text 'Drawフラグ
            Bet_bet(3) = t3_5.Text 'Bet

            For Each es As HtmlElement In wb3.Document.GetElementsByTagName("table")
                If es.GetAttribute("className") = "linesTbl" Then
                    Table内のtr 交互に３回出現
                    For Each es2 As HtmlElement In es.GetElementsByTagName("tr")
                        If es2.GetAttribute("className") = "linesAlt1" Or es2.GetAttribute("className") = "linesAlt2" Then
                            If f_cnt = 0 Then
                                f_cnt += 1
                                bd(0) = date_ch(es2.GetElementsByTagName("td").Item(0).InnerText) '[1]曜日
                                bd(2) = es2.GetElementsByTagName("td").Item(2).InnerText  '[3]チーム名（A)
                                bd(3) = es2.GetElementsByTagName("td").Item(4).InnerText '[4]１×２　オッズ（１）
                                es3 = es2.GetElementsByTagName("td").Item(4)
                                es3 = es3.GetElementsByTagName("a").Item(0)
                                XML_ck(0) = es3.GetElementsByTagName("input").Item(0).GetAttribute("id")
                                数値入力()
                                wb3.Document.Forms(2).DomElement(XML_ck(0)).Value = ""

                                If bd(2) = Bet_txt(3, 1) Then
                                    es3 = es2.GetElementsByTagName("td").Item(4)
                                    es3 = es3.GetElementsByTagName("a").Item(0)
                                    XML_ck(0) = es3.GetElementsByTagName("input").Item(0).GetAttribute("id")
                                    wb3.Document.Forms(2).DomElement(XML_ck(0)).Value = Bet_oss(3)
                                    'wb3.Document.Forms(2).DomElement("btnSubmitUpper").click()
                                    ' Exit Sub
                                End If

                            ElseIf f_cnt = 1 Then
                                f_cnt += 1
                                bd(1) = es2.GetElementsByTagName("td").Item(0).InnerText '[2]時間
                                bd(4) = es2.GetElementsByTagName("td").Item(2).InnerText '[5]チーム名（B)
                                bd(5) = es2.GetElementsByTagName("td").Item(4).InnerText '[6]１×２　オッズ（２）

                                es3 = es2.GetElementsByTagName("td").Item(4)
                                es3 = es3.GetElementsByTagName("a").Item(0)
                                XML_ck(0) = es3.GetElementsByTagName("input").Item(0).GetAttribute("id")
                                数値入力()
                                wb3.Document.Forms(2).DomElement(XML_ck(0)).Value = "88"

                                If bd(4) = Bet_txt(3, 1) Then
                                    es3 = es2.GetElementsByTagName("td").Item(4)
                                    es3 = es3.GetElementsByTagName("a").Item(0)
                                    XML_ck(0) = es3.GetElementsByTagName("input").Item(0).GetAttribute("id")
                                    wb3.Document.Forms(2).DomElement(XML_ck(0)).Value = Bet_oss(3)
                                    'wb3.Document.Forms(2).DomElement("btnSubmitUpper").click()

                                End If

                            ElseIf f_cnt = 2 Then
                                f_cnt = 0
                                bd(6) = es2.GetElementsByTagName("td").Item(2).InnerText '[7]チーム名（引分）
                                bd(7) = es2.GetElementsByTagName("td").Item(4).InnerText '[8]１×２　オッズ（引分）

                                es3 = es2.GetElementsByTagName("td").Item(4)
                                es3 = es3.GetElementsByTagName("a").Item(0)
                                XML_ck(0) = es3.GetElementsByTagName("input").Item(0).GetAttribute("id")
                                数値入力()
                                wb3.Document.Forms(2).DomElement(XML_ck(0)).Value = "99"
                            End If

                            Exit For


                        End If
                    Next
                    wb3.Document.Forms(2).DomElement("btnSubmitUpper").click()
                End If
            Next

        End If
    End Sub


    Private Sub wb4_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles wb4.DocumentCompleted
        On Error Resume Next
        Do While wb4.IsBusy
            System.Windows.Forms.Application.DoEvents()
        Loop

        URL = e.Url.ToString()
        Book_login(wb4.Document, URL) 'ログイン処理




        If URL = "http://sports.williamhill.com/bet/en-gb/betting/t/295/English-Premier-League.html" Then

            Bet_txt(4, 0) = t4_1.Text '日付
            Bet_txt(4, 1) = t4_2.Text 'チーム名
            Bet_oss(4) = t4_3.Text 'オッズ
            Bet_df(4) = t4_4.Text 'Drawフラグ



            For Each es As HtmlElement In wb4.Document.GetElementsByTagName("tr")
                If es.GetAttribute("className") = "rowOdd" Then
                    strArry = Split(es.GetElementsByTagName("span").Item(2).InnerText, " v ")
                    bd(0) = date_ch(es.GetElementsByTagName("span").Item(0).InnerText) '曜日
                    bd(1) = es.GetElementsByTagName("span").Item(1).InnerText '時間

                    bd(2) = strArry(0)  'チーム名（A)
                    bd(3) = es.GetElementsByTagName("div").Item(1).InnerText '１×２　オッズ（１）

                    bd(4) = strArry(1) 'チーム名（B)
                    bd(5) = es.GetElementsByTagName("div").Item(7).InnerText '１×２　オッズ（２）

                    bd(6) = "Draw" 'チーム名（引分）
                    bd(7) = es.GetElementsByTagName("div").Item(4).InnerText '１×２　オッズ（引分）


                    BTE値セット()
                    If bd(2) = Bet_txt(4, 1) Then
                        es3 = es.GetElementsByTagName("div").Item(1)
                    ElseIf bd(4) = Bet_txt(4, 1) Then
                        es3 = es.GetElementsByTagName("div").Item(7)
                    ElseIf Bet_df(4) = 1 And bd(4) = Bet_txt(4, 0) Then
                        es3 = es.GetElementsByTagName("div").Item(4)
                    End If

                    es3.InvokeMember("click")
                    Exit For

                End If
            Next

            System.Threading.Thread.Sleep(2000)

            For Each es As HtmlElement In wb4.Document.GetElementsByTagName("input")
                If es.GetAttribute("id") = "slip_sgl_stake491139115L" Then
                    es.SetAttribute("value", Bet_oss(4))
                End If
            Next

        End If

        For Each es As HtmlElement In wb4.Document.GetElementsByTagName("input")
            If es.GetAttribute("id") = "slipBtnPlaceBet" Then
                es.InvokeMember("click")
            End If
        Next

    End Sub


    Private Sub wb5_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles wb5.DocumentCompleted
        On Error Resume Next
        Do While wb5.IsBusy
            System.Windows.Forms.Application.DoEvents()
        Loop

        URL = e.Url.ToString()
        Book_login(wb5.Document, URL) 'ログイン処理


        If URL = "http://www.marathonbet.com/en/betting/Football/England/Premier+League/" Then
            If URL = "https://www.marathonbet.com/en/events.htm?id=21520" Then
                For Each es As HtmlElement In wb5.Document.GetElementsByTagName("tr")
                    If es.GetAttribute("className") = "event-header" Then
                        strArry = Split(es.GetElementsByTagName("td").Item(1).InnerText, "2.")

                        bd(0) = date_ch2(es.GetElementsByTagName("td").Item(2).InnerText) '曜日
                        bd(1) = date_ch3(es.GetElementsByTagName("td").Item(2).InnerText) '時間
                        bd(2) = strArry(0).Substring(strArry(0).IndexOf("1.") + 2)  'チーム名（A)
                        bd(3) = oss(es.GetElementsByTagName("td").Item(6).InnerText) '１×２　オッズ（１）

                        bd(4) = strArry(1) 'チーム名（B)
                        bd(5) = oss(es.GetElementsByTagName("td").Item(8).InnerText) '１×２　オッズ（２）
                        BTE値セット()
                        es3 = es.GetElementsByTagName("td").Item(8)
                        es3.InvokeMember("click")

                        Exit For


                        bd(6) = "Draw" 'チーム名（引分）
                        bd(7) = oss(es.GetElementsByTagName("td").Item(7).InnerText) '１×２　オッズ（引分）

                    End If
                Next

                System.Threading.Thread.Sleep(2000)

            End If

            For Each es As HtmlElement In wb5.Document.GetElementsByTagName("table")
                If es.GetAttribute("id") = "single-container" Then
                    es3 = es.GetElementsByTagName("td").Item(4)
                    es3 = es3.GetElementsByTagName("input").Item(0)
                    es3.SetAttribute("value", "")
                End If
            Next
    End Sub



    Private Sub wb6_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles wb6.DocumentCompleted
        On Error Resume Next
        Do While wb6.IsBusy
            System.Windows.Forms.Application.DoEvents()
        Loop

        URL = e.Url.ToString()
        Book_login(wb6.Document, URL) 'ログイン処理

        Dim TeamA = ""
        Dim loopf = 0

        If URL = "https://sports.bwin.com/en/sports#leagueIds=46&sportId=4/" Then
            For Each es As HtmlElement In wb6.Document.GetElementsByTagName("li")

                If es.GetElementsByTagName("h2").Item(0).GetAttribute("className") = "event-group-level2" Then
                    loopf = 0
                    For Each es2 As HtmlElement In es.GetElementsByTagName("li")
                        bd(0) = date_ch(es2.GetElementsByTagName("h2").Item(0).InnerText) '[1]曜日
                        If loopf = 0 Then
                            loopf = 1
                            For Each es3 As HtmlElement In es2.GetElementsByTagName("li")
                                bd(1) = es3.GetElementsByTagName("h6").Item(0).InnerText '[2]時間
                                bd(2) = es3.GetElementsByTagName("span").Item(1).InnerText '[3]チーム名（A)
                                bd(3) = es3.GetElementsByTagName("span").Item(0).InnerText '[4]１×２　オッズ（１）

                                BTE値セット()
                                es4 = es3.GetElementsByTagName("span").Item(0)
                                es4.InvokeMember("click")

                                bd(4) = es3.GetElementsByTagName("span").Item(5).InnerText '[5]チーム名（B)
                                bd(5) = es3.GetElementsByTagName("span").Item(4).InnerText '[6]１×２　オッズ（２）


                                bd(6) = "Draw" '[7]チーム名（引分）
                                bd(7) = es3.GetElementsByTagName("span").Item(2).InnerText '[8]１×２　オッズ（引分）


                                If TeamA = bd(2) Then
                                    TeamA = ""
                                Else
                                    TeamA = bd(2)

                                    For i2 = 0 To 7
                                        bd(i2) = SpaceDel(bd(i2))
                                    Next

                                End If
                            Next
                        Else
                            loopf = 0
                        End If

                    Next


                End If
            Next

        End If



    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        wb1.Navigate(Book_name(1, 0))
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        wb2.Navigate(Book_name(2, 0))
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        wb3.Navigate(Book_name(3, 0))
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        wb4.Navigate(Book_name(4, 0))
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        wb5.Navigate(Book_name(5, 0))
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        wb6.Navigate(Book_name(6, 0))
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        b_url = "https://www1.pinnaclesports.com/members/canvas.asp#/Members/Lineoffering.asp?display=DynamicLines&sportType=Soccer&sportSubType=Eng.+Premier&descr=1"
        wb3.Navigate(New System.Uri(b_url))
        wb1.Navigate(New System.Uri(b_url))
        wb3.Navigate(b_url)
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        b_url = "http://www.5dimes.eu/BbGameSelection.asp"
        wb2.Navigate(b_url)
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        b_url = "http://sports.williamhill.com/bet/en-gb/betting/t/295/English-Premier-League.html"
        wb4.Navigate(b_url)
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        b_url = "http://www.marathonbet.com/en/betting/Football/England/Premier+League/"
        wb5.Navigate(b_url)
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        williamhill.com BET
        For Each es As HtmlElement In wb4.Document.GetElementsByTagName("input")
            If es.GetAttribute("id") = "slipBtnPlaceBet" Then
                es.InvokeMember("click")
            End If
        Next

        Marathon 入力
        For Each es As HtmlElement In wb5.Document.GetElementsByTagName("table")
            If es.GetAttribute("id") = "single-container" Then
                es3 = es.GetElementsByTagName("td").Item(4)
                es3 = es3.GetElementsByTagName("input").Item(0)
                es3.SetAttribute("value", "")
            End If
        Next

        Marathon BET Click
        For Each es As HtmlElement In wb5.Document.GetElementsByTagName("table")
            If es.GetAttribute("className") = "panel-bet" Then
                es3 = es.GetElementsByTagName("td").Item(1)
                es3 = es3.GetElementsByTagName("a").Item(0)
                es3.InvokeMember("click")
            End If
        Next
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click


        b_url = "https://sports.bwin.com/en/sports#leagueIds=46&sportId=4/"
        wb6.Navigate(b_url)
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        For Each es As HtmlElement In wb6.Document.GetElementsByTagName("fieldset")
            If es.GetAttribute("className") = "stake" Then
                es3 = es.GetElementsByTagName("input").Item(0)
                es3.SetAttribute("value", "")
            End If
        Next

        For Each es As HtmlElement In wb6.Document.GetElementsByTagName("fieldset")
            If es.GetAttribute("className") = "buttons" Then
                es3 = es.GetElementsByTagName("div").Item(0)
                es3.InvokeMember("click")
            End If
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        b_url = "http://yahoo.co.jp"
        wb1.Navigate(b_url)

        b_url = "https://www1.pinnaclesports.com/members/canvas.asp#/Members/Lineoffering.asp?display=DynamicLines&sportType=Soccer&sportSubType=Eng.+Premier&descr=1"
        wb1.Navigate(b_url)
    End Sub

    Private Sub AbiToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Form3.Show()
    End Sub

    Private Sub アービトラージ確認ToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Form4.Show()
    End Sub

    Private Sub ベットログToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Form5.Show()
    End Sub

    Private Sub wb_server_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles wb_server.DocumentCompleted
        Dim ab() As String
        Dim betdata() As String

        On Error Resume Next
        Do While wb_server.IsBusy
            System.Windows.Forms.Application.DoEvents()
        Loop

        Dim URL As String = e.Url.ToString()

        If URL = abi_url Then
            読込HTML取得()
            HTML_TXT = wb_server.Document.DomDocument.documentElement.outerhtml
            HTML_TXT = Replace(HTML_TXT, Chr(34), "") '「"」の削除
            HTML_TXT = Replace(HTML_TXT, " ", "")
            HTML_TXT = Replace(HTML_TXT, "　", "")
            HTML_TXT = Replace(HTML_TXT, "&nbsp;", "")
            HTML_TXT = Replace(HTML_TXT, "&NBSP;", "")

            TextBox4.Text = wb_server.Document.Body.InnerText

            ab = Split(wb_server.Document.Body.InnerText, "*")

            For Each St As String In ab

                betdata = Split(St, ",")

                If Len(St) < 5 Or Len(betdata(9)) < 5 Then
                    Exit For
                End If

                TextBox1.Text = betdata(0)
                TextBox2.Text = betdata(1)
                TextBox3.Text = betdata(2)
                TextBox4.Text = betdata(3)
                TextBox5.Text = betdata(4)
                TextBox6.Text = betdata(5)
                TextBox7.Text = betdata(6)
                TextBox8.Text = betdata(7)
                TextBox9.Text = betdata(8)
                TextBox10.Text = betdata(9)

                TextBox4.Text = St
                Exit For
            Next
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        wb_server.Navigate(abi_url)
    End Sub

    Private Sub PinnaclesportsToolStripMenuItem_Click(sender As Object, e As EventArgs)
        wb1.Navigate(Book_name(1, 0))
    End Sub

    Private Sub DimesToolStripMenuItem_Click(sender As Object, e As EventArgs)
        wb2.Navigate(Book_name(2, 0))
    End Sub

    Private Sub BetclicToolStripMenuItem_Click(sender As Object, e As EventArgs)
        wb3.Navigate(Book_name(3, 0))
    End Sub

    Private Sub WilliamhillToolStripMenuItem_Click(sender As Object, e As EventArgs)
        wb4.Navigate(Book_name(4, 0))
    End Sub

    Private Sub MarathonbetToolStripMenuItem_Click(sender As Object, e As EventArgs)
        wb5.Navigate(Book_name(5, 0))
    End Sub

    Private Sub BwinToolStripMenuItem_Click(sender As Object, e As EventArgs)
        wb6.Navigate(Book_name(6, 0))
    End Sub

    Private Sub オッズ一覧ToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Form6.Show()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        wb6.Navigate("http://kkcr.sixcore.jp/abi/syslog.php?bu_1=" & My.Settings.user_id)
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs)

        Dim mc As System.Text.RegularExpressions.MatchCollection = _
    System.Text.RegularExpressions.Regex.Matches( _
        TextBox1.Text, _
        "<a\s+[^>]*href\s*=\s*(?:(?<quot>[""'])(?<url>.*?)\k<quot>|" + _
            "(?<url>[^\s>]+))[^>]*>(?<text>.*?)</a>", _
        System.Text.RegularExpressions.RegexOptions.IgnoreCase Or _
        System.Text.RegularExpressions.RegexOptions.Singleline)

        MsgBox(mc(0).Groups("url").Value())

        For Each m As System.Text.RegularExpressions.Match In mc
            Console.WriteLine("URL:{0}", m.Groups("url").Value)
            Console.WriteLine("テキスト:{0}", m.Groups("text").Value)
        Next
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs)
        WebBrowser1.Navigate("http://www.188bet.com/en-gb/")
    End Sub

End Class
