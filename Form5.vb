Public Class Form5

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WebBrowser1.Navigate("http://backyjob.xsrv.jp/abi/abi-betlist.php?uid=" & My.Settings.user_id)
    End Sub
End Class