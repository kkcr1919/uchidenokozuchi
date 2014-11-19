Public Class Class11
        For Each t As String In strTemp
                        If t = "{}" Then
    strTemp(i - 10) 'A
    strTemp(i - 9) 'B
    strTemp(i - 6) 'Date
    strTemp(i+23) 'A
    strTemp(i+24) 'Draw
    strTemp(i+25) 'B


   For Each t As String In strTemp
                        If t = "{}" Then
    strTemp(i - 10) 'A
    strTemp(i - 9) 'B
    strTemp(i - 6) 'Date
    strTemp(i+23) 'A
    strTemp(i+24) 'Draw
    strTemp(i+25) 'B


                            bd(0) = date_ch(strTemp(i - 6)) '曜日
                            bd(1) = date_ch2(strTemp(i - 6)) '時間
                            bd(2) = Replace(strTemp(i - 10), "'", "")  'チーム名（A)
                            bd(3) = strTemp(i + 23) '１×２　オッズ（１）
                            bd(4) = Replace(strTemp(i - 9), "'", "") 'チーム名（B)
                            bd(5) = strTemp(i + 24) '１×２　オッズ（２）
                            bd(6) = "Draw" 'チーム名（引分）
                            bd(7) = strTemp(i + 25) '１×２　オッズ（引分）

                            bd(18) = bookm + bd(0) + bd(1) + bd(2) + bd(4)

    テキストボックスに表示
                            text_show(cnt)
                            For i2 = 0 To 7
                                bd(i2) = SpaceDel(bd(i2))
                            Next
                            Web_book = My.Settings("serverurl") + "?book=" + bookm + "&a_1=" + bd(0) + "&a_2=" + bd(1) + "&a_3=" + bd(2) + " &a_4=" + bd(3) + "&a_5=" + bd(4) + "&a_6=" + bd(5) + "&a_7=" + bd(6) + " &a_8=" + bd(7) + " &a_18=" + bd(18) + " &a_19=ENGLAND-PREMIER LEAGUE"
                            oss_web_write(Web_book)
                            System.Threading.Thread.Sleep(1000)

                        End If
                        i += 1
                    Next




    For Each es2 As HtmlElement In es.GetElementsByTagName("tr")


        bd(0) = date_ch(es.GetElementsByTagName("div").Item(2).InnerText) '曜日
        bd(1) = date_ch(es.GetElementsByTagName("div").Item(2).InnerText) '時間
        bd(2) = es.GetElementsByTagName("span").Item(0).InnerText  'チーム名（A)
        bd(3) = oss(es.GetElementsByTagName("td").Item(6).InnerText) '１×２　オッズ（１）
        bd(4) = es.GetElementsByTagName("span").Item(2).InnerText 'チーム名（B)
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




    Next
End Class
