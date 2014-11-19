Public Class book
    Private Sub b1()
        wb.DomElement("UserName").Value = Book_name(1, 1)
        wb.DomElement("password").Value = Book_name(1, 2)
        wb.DomElement("CustomerId").Value = Book_name(1, 1)
        wb.DomElement("Password").Value = Book_name(1, 2)
    End Sub

    Private Sub b2()
        wb.DomElement("Password").focus()
        SendKeys.SendWait("{TAB}")
        SendKeys.SendWait("{ENTER}")
        wb.DomElement("submit1").click()
    End Sub

    Private Sub b3()
        wb.DomElement("btnSubmitUpper").click()
        wb.DomElement("submitBottom").click()
    End Sub

    Private Sub b4()
        wb.DomElement("txtName").Value = Book_name(6, 1)
        wb.DomElement("txtPass").Value = Book_name(6, 2)
        wb.DomElement("btnLogin").click()
    End Sub

    Private Sub b5()
        wb.DomElement("stake").Value()
        wb.DomElement("btnPlaceBet_BS").Value()
        wb.DomElement("btnConfirm_BS").click()
    End Sub

    Private Sub b6()
        wb.DomElement("username").Value()
        wb.DomElement("password").Value()
    End Sub

    Private Sub b7()
        wb.DomElement("od-s-").Value()
        wb.DomElement("title").Value()
        wb.DomElement("stk_0").Value()
        wb.DomElement("submit-Button").click()
        wb.DomElement("btnClick").click()
    End Sub

    Private Sub b8()

        wb.DomElement("account").Value()
        wb.DomElement("password").Value()
        wb.DomElement("submit").click()
    End Sub


    Private Sub b9()
        wb.DomElement("Form").click()
        wb.DomElement("ctl01_mainContent_btnContinueTop").click()
        wb.DomElement("amt_1848750_3").Value()
        wb.DomElement("ctl00_mainContent_btnContinueTop").click()
    End Sub


    Private Function txodd(txod)
        txod = Math.Floor(txod / 10) / 100
        Return txod
    End Function

    Private Function date_ch(txt)
        Dim strArry() As String

        strArry = Split(txt, " ")
        strArry(0) = Replace(strArry(0), "/2014", "")

        If InStr(txt, "Jan") > 0 Then
            strArry = Split(txt, "Jan")
            txt = "1/" + strArry(0)
        ElseIf InStr(txt, "Feb") > 0 Then
            strArry = Split(txt, "Feb")
            txt = "2/" + strArry(0)
        ElseIf InStr(txt, "Mar") > 0 Then
            strArry = Split(txt, "Mar")
            txt = "3/" + strArry(0)
        End If



        txt = Replace(strArry(0), "/0", "/")

        Return txt
    End Function

    Private Function date_ch2(txt)

        Dim strArry() As String
        If InStr(txt, "Jan") > 0 Then
            strArry = Split(txt, "Jan")
            txt = "1/" + strArry(0)
        ElseIf InStr(txt, "Feb") > 0 Then
            strArry = Split(txt, "Feb")
            txt = "2/" + strArry(0)
        ElseIf InStr(txt, "Mar") > 0 Then
            strArry = Split(txt, "Mar")
            txt = "3/" + strArry(0)
        End If


        strArry = Split(txt, " ")
        strArry(1) = Replace(strArry(1), "'", "")
        txt = Replace(strArry(1), " ", "")

        Return txt
    End Function

    Private Function oss(txt)
        Dim strArry() As String
        Dim oss2(2) As Integer

        If InStr(txt, "/") > 0 Then
            strArry = Split(txt, "/")

            oss2(0) = Integer.Parse(strArry(0))
            oss2(1) = Integer.Parse(strArry(1))

            txt = (oss2(0) + oss2(1)) / oss2(1) * 100
            txt = Math.Floor(txt) / 100
        End If

        Return txt
    End Function

    Private Function ossou(txt)
        Dim strouArry() As String
        Dim oss2(2) As Integer

        strouArry = Split(txt, vbCrLf)
        ou(0) = Replace(strouArry(0), "(", "")
        ou(0) = Replace(ou(0), ")", "")
        ou(0) = SpaceDel(ou(0))
        ou(1) = SpaceDel(oss(strouArry(1)))

        Return ou(1)
    End Function
    Private Function team_name(txt)
        txt = Replace(txt, "(ENG-FACup)", "")
        txt = Replace(txt, "(ENG-P)", "")
        txt = Replace(txt, "(ENG-Trophy)", "")
        txt = Replace(txt, "(ENG-One)", "")
        txt = Replace(txt, "(ENG-Conf)", "")
        Return txt
    End Function


    Private Function SpaceDel(txt)
        txt = Replace(txt, " ", "")
        txt = Replace(txt, "　", "")
        Return txt
    End Function

    Private Sub text_show(txt)
        For i = 0 To 6
            TextBox1.Text += """" + bd(i) + """," '曜日
        Next
        TextBox1.Text += bd(7) + vbCrLf
        TextBox1.Text = SpaceDel(TextBox1.Text)
    End Sub

    Private Sub oss_write(txt)
        Dim file_path = My.Settings("bookm")
        Dim dtNow As DateTime = DateTime.Now
        Dim stPrompt1 As String = dtNow.ToString("yyyyMMdd")

        Dim sw As IO.StreamWriter = New IO.StreamWriter(file_path & stPrompt1 & ".csv", True, System.Text.Encoding.UTF8)
        txt = Replace(txt, " ", "")
        txt = Replace(txt, "　", "")
        sw.Write(txt)
        sw.Write(vbCrLf)
        sw.Close()
    End Sub


End Class
