Public Class Class7

        Private Sub wb1_DocumentCompleted_1(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles wb1.DocumentCompleted
            On Error Resume Next
        Dim URL As String = e.Url.ToString()


            '読込HTML取得
            HTML_TXT = wb1.Document.DomDocument.documentElement.outerhtml
            HTML_TXT = Replace(HTML_TXT, Chr(34), "") '「"」の削除
            HTML_TXT = Replace(HTML_TXT, " ", "")
            HTML_TXT = Replace(HTML_TXT, "　", "")
            HTML_TXT = Replace(HTML_TXT, "&nbsp;", "")
            HTML_TXT = Replace(HTML_TXT, "&NBSP;", "")

            Dim cnt = -2
            Dim chekHTML
            Dim chekHTML2
            Dim strArry() As String

            'URLにより処理分岐
            'If URL = "http://www.pinnaclesports.com/League/Soccer/French+1/1/Lines.aspx" Then
            If URL = My.Settings("url1") Then

                For Each es As HtmlElement In wb1.Document.GetElementsByTagName("tr")
                    If es.GetAttribute("className") = "event-header" Then
                        strArry = Split(es.GetElementsByTagName("td").Item(1).InnerText, "2.")


                        bd(0) = date_ch(es.GetElementsByTagName("td").Item(2).InnerText) '曜日
                        bd(1) = date_ch2(es.GetElementsByTagName("td").Item(2).InnerText) '時間
                        bd(2) = strArry(0).Substring(strArry(0).IndexOf("1.") + 2)  'チーム名（A)
                        bd(3) = oss(es.GetElementsByTagName("td").Item(6).InnerText) '１×２　オッズ（１）
                        bd(4) = strArry(1) 'チーム名（B)
                        bd(5) = oss(es.GetElementsByTagName("td").Item(8).InnerText) '１×２　オッズ（２）
                        bd(6) = "Draw" 'チーム名（引分）
                        bd(7) = oss(es.GetElementsByTagName("td").Item(7).InnerText) '１×２　オッズ（引分）

                        bd(18) = bookm + bd(0) + bd(1) + bd(2) + bd(4)

                        'テキストボックスに表示
                        text_show(cnt)
                        For i2 = 0 To 7
                            bd(i2) = SpaceDel(bd(i2))
                        Next
                        Web_book = My.Settings("serverurl") + "?book=" + bookm + "&a_1=" + bd(0) + "&a_2=" + bd(1) + "&a_3=" + bd(2) + " &a_4=" + bd(3) + "&a_5=" + bd(4) + "&a_6=" + bd(5) + "&a_7=" + bd(6) + " &a_8=" + bd(7) + " &a_18=" + bd(18) + " &a_19=ENGLAND-PREMIER LEAGUE"
                        oss_web_write(Web_book)
                        System.Threading.Thread.Sleep(1000)

                    End If
                Next


        End If
        End Sub

End Class
