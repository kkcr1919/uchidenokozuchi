Public Class Form4

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WebBrowser1.Navigate("http://backyjob.xsrv.jp/abi/abi-bet.php?uid=" & My.Settings.user_id)
    End Sub
End Class