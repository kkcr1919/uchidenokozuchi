Public Class Class9
      For Each es As HtmlElement In wb1.Document.GetElementsByTagName("li")

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

                                    bd(18) = bookm + bd(0) + bd(1) + bd(2) + bd(4)

    'テキストボックスに表示
                                    text_show(cnt)
    'WEBに保存
                                    Web_book = My.Settings("serverurl") + "?book=" + bookm + "&a_1=" + bd(0) + "&a_2=" + bd(1) + "&a_3=" + bd(2) + " &a_4=" + bd(3) + "&a_5=" + bd(4) + "&a_6=" + bd(5) + "&a_7=" + bd(6) + " &a_8=" + bd(7) + " &a_18=" + bd(18) + " &a_19=ENGLAND-PREMIER LEAGUE"
                                    oss_web_write(Web_book)
                                    System.Threading.Thread.Sleep(1000)

                                End If
                            Next
                        Else
                            loopf = 0
                        End If

                    Next


                End If
            Next
End Class
