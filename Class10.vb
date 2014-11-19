Public Class Class10
          For Each es As HtmlElement In wb1.Document.GetElementsByTagName("div")
                If es.GetAttribute("className") = "linesContainer" Then
                    For Each es2 As HtmlElement In es.Document.GetElementsByTagName("tr")
                        If es2.GetAttribute("className") = "linesRow" Then
                            bd(0) = date_ch(es2.GetElementsByTagName("td").Item(0).InnerText) '曜日
                            bd(4) = es2.GetElementsByTagName("td").Item(2).InnerText.Substring(es2.GetElementsByTagName("td").Item(2).InnerText.IndexOf(" "))  'チーム名（A)
                            bd(4) = team_name(bd(4))
                            bd(5) = es2.GetElementsByTagName("td").Item(4).InnerText '１×２　オッズ（１）
                        ElseIf es2.GetAttribute("className") = "linesRowMid" Then
                            bd(1) = es2.GetElementsByTagName("td").Item(0).InnerText '時間
                            bd(2) = es2.GetElementsByTagName("td").Item(2).InnerText.Substring(es2.GetElementsByTagName("td").Item(2).InnerText.IndexOf(" "))  'チーム名（B)
                            bd(2) = team_name(bd(2))
                            bd(3) = es2.GetElementsByTagName("td").Item(4).InnerText '１×２　オッズ（２）
                        ElseIf es2.GetAttribute("className") = "linesRowBot" Then
                            bd(6) = "Draw" 'チーム名（引分）
                            bd(7) = es2.GetElementsByTagName("td").Item(4).InnerText '１×２　オッズ（引分）

                            bd(18) = bookm + bd(0) + bd(1) + bd(2) + bd(4)

                            For i2 = 0 To 7
                                bd(i2) = SpaceDel(bd(i2))
                            Next
                            Web_book = My.Settings("serverurl") + "?book=" + bookm + "&a_1=" + bd(0) + "&a_2=" + bd(1) + "&a_3=" + bd(2) + " &a_4=" + bd(3) + "&a_5=" + bd(4) + "&a_6=" + bd(5) + "&a_7=" + bd(6) + " &a_8=" + bd(7) + " &a_18=" + bd(18) + " &a_19=ENGLAND-PREMIER LEAGUE"
                            oss_web_write(Web_book)
                            System.Threading.Thread.Sleep(1000)

    'テキストボックスに表示
                            text_show(cnt)

                        End If
                    Next



                End If
            Next
End Class
