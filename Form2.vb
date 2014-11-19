Public Class form2

    Private txtBox_id() As System.Windows.Forms.TextBox
    Private txtBox_pass() As System.Windows.Forms.TextBox

    Private Sub form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error Resume Next

        '設定情報読込
        Me.txtBox_id = New System.Windows.Forms.TextBox(20) {}
        Me.txtBox_pass = New System.Windows.Forms.TextBox(20) {}

        Me.txtBox_id(1) = Me.TextBox1
        Me.txtBox_pass(1) = Me.TextBox2
        Me.txtBox_id(2) = Me.TextBox3
        Me.txtBox_pass(2) = Me.TextBox4
        Me.txtBox_id(3) = Me.TextBox5
        Me.txtBox_pass(3) = Me.TextBox6
        Me.txtBox_id(4) = Me.TextBox7
        Me.txtBox_pass(4) = Me.TextBox8
        Me.txtBox_id(5) = Me.TextBox9
        Me.txtBox_pass(5) = Me.TextBox10
        Me.txtBox_id(6) = Me.TextBox11
        Me.txtBox_pass(6) = Me.TextBox12
        Me.txtBox_id(7) = Me.TextBox13
        Me.txtBox_pass(7) = Me.TextBox14
        Me.txtBox_id(8) = Me.TextBox15
        Me.txtBox_pass(8) = Me.TextBox16
        Me.txtBox_id(9) = Me.TextBox17
        Me.txtBox_pass(9) = Me.TextBox18
        Me.txtBox_id(10) = Me.TextBox19
        Me.txtBox_pass(10) = Me.TextBox20
        Me.txtBox_id(11) = Me.TextBox21
        Me.txtBox_pass(11) = Me.TextBox22

        For i = 1 To 11
            Me.txtBox_id(i).Text = My.Settings("Book_id_" & i)
            Me.txtBox_pass(i).Text = My.Settings("Book_pass_" & i)
        Next

        Me.txt_uid.Text = My.Settings.user_id
        Me.txt_mbet.Text = My.Settings.max_bet

    End Sub

    Private Sub form2_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        On Error Resume Next

        For i = 1 To 11
            My.Settings("Book_id_" & i) = Me.txtBox_id(i).Text
            My.Settings("Book_ipass_" & i) = Me.txtBox_pass(i).Text
        Next

        My.Settings.user_id = Me.txt_uid.Text
        My.Settings.max_bet = Me.txt_mbet.Text

        My.Settings.Save()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txt_uid.Text = "" Then
            MsgBox("管理Noを入力してください")
        End If

        If txt_mbet.Text = "" Then
            MsgBox("BET額を入力してください")
        End If


        On Error Resume Next
        Dim url = "http://kkcr.sixcore.jp/abi/user.php?"
        
        url = url & "bu_1=" & Me.txt_uid.Text
        url = url & "&bu_2=" & Me.txt_mbet.Text

        For i = 1 To 11
            My.Settings("Book_id_" & i) = Me.txtBox_id(i).Text
            My.Settings("Book_pass_" & i) = Me.txtBox_pass(i).Text

            url = url & "&bu_" & (i * 2) + 1 & "=" & Me.txtBox_id(i).Text & "&bu_" & (i * 2) + 2 & "=" & Me.txtBox_pass(i).Text
        Next

        For i = 12 To 13
            url = url & "&bu_" & (i * 2) + 1 & "=0&bu_" & (i * 2) + 2 & "=0"
        Next
        url = url & "&bu_29=0"
        WebBrowser1.Navigate(url)

        My.Settings.user_id = Me.txt_uid.Text
        My.Settings.max_bet = Me.txt_mbet.Text

        My.Settings.Save()

    End Sub
End Class