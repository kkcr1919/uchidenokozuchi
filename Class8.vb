Public Class Class8
           For Each es0 As HtmlElement In wb1.Document.GetElementsByTagName("div")
                If es0.GetAttribute("className") = "main-block-events" Then

                    For Each es As HtmlElement In es0.GetElementsByTagName("h2")
                        If es.GetAttribute("className") = "category-path" Then
                            bd(21) = es.GetElementsByTagName("span").Item(1).InnerText '国
                            bd(22) = es.GetElementsByTagName("span").Item(2).InnerText 'リーグ名
                        End If
                    Next

                    For Each es As HtmlElement In es0.GetElementsByTagName("tr")
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

    'bd(10) = es.GetElementsByTagName("td").Item(14).InnerText 'UNDER
    'bd(8) = oss(es.GetElementsByTagName("td").Item(14).InnerText) 'UNDER
    'bd(9) = oss(es.GetElementsByTagName("td").Item(15).InnerText) 'OVER


                            bd(8) = ossou(es.GetElementsByTagName("td").Item(15).InnerText) 'オーバー
                            bd(9) = ou(0)
                            bd(10) = ou(1)
                            bd(11) = ossou(es.GetElementsByTagName("td").Item(14).InnerText) 'アンダー
                            bd(12) = ou(0)
                            bd(13) = ou(1)


    'テキストボックスに表示
                            text_show(cnt)
                            For i2 = 0 To 7
                                bd(i2) = SpaceDel(bd(i2))
                            Next
                            Web_book = My.Settings("serverurl") + "?book=" + bookm + "&a_1=" + bd(0) + "&a_2=" + bd(1) + "&a_3=" + bd(2) + " &a_4=" + bd(3) + "&a_5=" + bd(4) + "&a_6=" + bd(5) + "&a_7=" + bd(6) + " &a_8=" + bd(7) + " &a_9=" + bd(9) + " &a_10=" + bd(10) + " &a_11=" + bd(12) + " &a_12=" + bd(13) + " &a_18=" + bd(18) + " &a_19=" + bd(21) + "-" + bd(22)
                            oss_web_write(Web_book)
                            System.Threading.Thread.Sleep(1000)

                        End If
                    Next




                End If
            Next
End Class
