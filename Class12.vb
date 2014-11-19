Public Class Class12
                If load_flg = 0 Then
     SendKeys.SendWait("{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{ENTER}")
                load_flg = 1
            ElseIf load_flg = 1 Then
     SendKeys.SendWait("{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{ENTER}")
                load_flg = 2
            ElseIf load_flg = 2 Then
     SendKeys.SendWait("{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{TAB}{ENTER}")
                load_flg = 3
            End If

            ToolStripStatusLabel1.Text = "解析中"

    For Each es As HtmlElement In wb1.Document.GetElementsByTagName("h2")
    If InStr(es.InnerText, "Daily Match Lists") > 0 Then
    bd(0) = es.GetElementsByTagName("span").Item(0).InnerText '曜日
     bd(0) = Replace(bd(0), "( ", "")
     bd(0) = Replace(bd(0), " )", "")
     End If
     Next rowOdd

    For Each es As HtmlElement In wb1.Document.GetElementsByTagName("div")
     If es.GetAttribute("id") = "ip_sport_0" Then

            For Each es As HtmlElement In wb1.Document.GetElementsByTagName("tr")
                If es.GetAttribute("className") = "rowOdd" Then
                    strArry = Split(es.GetElementsByTagName("span").Item(2).InnerText, " v ")
                    bd(0) = es.GetElementsByTagName("span").Item(0).InnerText '曜日
                    bd(1) = es.GetElementsByTagName("span").Item(1).InnerText '時間
                    bd(2) = strArry(0)  'チーム名（A)
                    bd(3) = es.GetElementsByTagName("div").Item(1).InnerText '１×２　オッズ（１）
                    bd(4) = strArry(1) 'チーム名（B)
                    bd(5) = es.GetElementsByTagName("div").Item(4).InnerText '１×２　オッズ（２）
                    bd(6) = "Draw" 'チーム名（引分）
                    bd(7) = es.GetElementsByTagName("div").Item(7).InnerText '１×２　オッズ（引分）

                    text_show(cnt)
                    For i2 = 0 To 7
                        bd(i2) = SpaceDel(bd(i2))
                    Next
                    Web_book = My.Settings("serverurl") + "?book=" + bookm + "&a_1=" + bd(0) + "&a_2=" + bd(1) + "&a_3=" + bd(2) + " &a_4=" + bd(3) + "&a_5=" + bd(4) + "&a_6=" + bd(5) + "&a_7=" + bd(6) + " &a_8=" + bd(7)
                    oss_web_write(Web_book)
                    System.Threading.Thread.Sleep(1000)


                End If
            Next
End Class
