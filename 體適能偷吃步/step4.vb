Public Class step4
    Private Sub 報名頁面_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        '  WebBrowser1.Navigate("http://www.fitness.org.tw/exam/quizDirectReg.php?r=" + step2.TextBox1.Text)
        WebBrowser1.Navigate("http://www.fitness.org.tw/exam/quizregister.php#")
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        WebBrowser1.Document.Window.ScrollTo(50, 285)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If WebBrowser1.Url.ToString = "http://www.fitness.org.tw/exam/index.php" Then '防止從這裡登出會自動跳到登入表單
            step3.Close()
            step2.Close()
            step1.Show()
            Me.Close()
            Timer1.Stop()
        End If
    End Sub
End Class