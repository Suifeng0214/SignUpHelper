Public Class step2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        step4.Close()
        step4.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        step3.Close()
        step3.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            For Each link In WebBrowser1.Document.Links
                If link.GetAttribute("href") = "http://www.fitness.org.tw/exam/loginout.php" And link.innertext = "登出系統" Then
                    link.InvokeMember("click")
                    step4.Close()
                    step3.Close()
                    Me.Close()
                End If
            Next
        Catch
        End Try
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        For Each b As HtmlElement In WebBrowser1.Document.GetElementsByTagName("TD")
            If Mid(b.InnerText, 1, 1) = "H" Then
                b.InnerText = Replace(b.InnerText, "來自：140.135.201.61", "")
                Label1.Text = b.InnerText
            End If
        Next

    End Sub

    Private Sub step2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        step1.Timer1.Stop()
    End Sub
End Class