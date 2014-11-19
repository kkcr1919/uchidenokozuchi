Public Class Form3
    Private HTML_TXT As Object 'HTML内容


    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WebBrowser1.Navigate("http://backyjob.xsrv.jp/abi/abi-betdata.php")
    End Sub


    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        Dim ab() As String
        Dim betdata() As String

        On Error Resume Next
        Do While WebBrowser1.IsBusy
            System.Windows.Forms.Application.DoEvents()
        Loop

        Dim URL As String = e.Url.ToString()

        If URL = "http://backyjob.xsrv.jp/abi/abi-betdata.php" Then
            '読込HTML取得
            HTML_TXT = WebBrowser1.Document.DomDocument.documentElement.outerhtml
            HTML_TXT = Replace(HTML_TXT, Chr(34), "") '「"」の削除
            HTML_TXT = Replace(HTML_TXT, " ", "")
            HTML_TXT = Replace(HTML_TXT, "　", "")
            HTML_TXT = Replace(HTML_TXT, "&nbsp;", "")
            HTML_TXT = Replace(HTML_TXT, "&NBSP;", "")

            TextBox10.Text = WebBrowser1.Document.Body.InnerText

            ab = Split(WebBrowser1.Document.Body.InnerText, "*")

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
            Next
        End If

    End Sub
End Class