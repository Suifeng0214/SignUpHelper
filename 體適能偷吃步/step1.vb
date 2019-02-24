Public Class step1
    Dim a As Boolean
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Then
            MsgBox("請確實輸入完整!", 0 + 48, "提示")
        Else
            Try
                WebBrowser1.Document.GetElementById("username").SetAttribute("value", TextBox1.Text) '帳號'
                WebBrowser1.Document.GetElementById("userpass").SetAttribute("value", TextBox2.Text)  '密碼'
                WebBrowser1.Document.GetElementById("loginValidCode").SetAttribute("value", TextBox3.Text)  '驗證碼'
            Catch
                MsgBox("發生錯誤!", 0 + 48, "提示")
            End Try
            Try
                WebBrowser1.Document.GetElementById("userLogin-button").DomElement.click() '登入'

            Catch
                MsgBox("登入失敗,稍後程式自動重啟", 0 + 48, “提示”)
                Application.Restart()
            End Try
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '測試網路連線
        Dim net As Boolean = My.Computer.Network.IsAvailable
        If net.ToString = False Then
            MsgBox("請連上網際網路後再重試！", 0 + 48, "提示")
            Me.Close()
        End If
        '檢查更新功能
        Try
            Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("https://raw.githubusercontent.com/Suifeng0214/SignUpHelper/master/version.txt")
            Dim response As System.Net.HttpWebResponse = request.GetResponse
            Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream)

            Dim newestversion As String = sr.ReadToEnd
            Dim currentversion As String = Application.ProductVersion
            If newestversion.Contains(currentversion) Then
                MsgBox("目前是最新版本！", 0 + 64, "提示")
            Else
                If MsgBox("偵測到新版本 v" + newestversion + vbNewLine + "是否下載最新版輔助?", 4 + 64, "提示") = vbYes Then
                    Process.Start("https://github.com/Suifeng0214/SignUpHelper/raw/master/SignUpHelper.exe")
                End If
            End If


            Label5.Text = "本軟體為免費版本" + vbNewLine + "請勿擅自販售!" + vbNewLine + vbNewLine + "=-=-=-=-=-=-=-=-=使用說明=-=-=-=-=-=-=-=-=" + vbNewLine + vbNewLine +
            "請先至體適能官網註冊帳密~" + vbNewLine + vbNewLine + "＊註冊完後詳細教學請觀看教學影片" + vbNewLine + vbNewLine + vbNewLine + "=-=-=-=-=-=-=-=-=版本內容=-=-=-=-=-=-=-=-=" + vbNewLine + vbNewLine + "無"
            Label6.Text = "目前版本: v" + currentversion + ""
        Catch
            MsgBox("檢查更新失敗！", 0 + 48, "提示")
        End Try
        Timer1.Start()
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        WebBrowser1.Document.Window.ScrollTo(50, 285) '把捲軸移至(x,y)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click '重新產生認證碼 '按鈕
        For Each link In WebBrowser1.Document.Links
            If link.GetAttribute("href") = "http://www.fitness.org.tw/exam/login.php#" And link.innertext = "重新產生認證碼" Then
                link.InvokeMember("click")
            End If
        Next
    End Sub

    Private Sub WebBrowser2_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser2.DocumentCompleted
        WebBrowser2.Document.Window.ScrollTo(480, 285) '把捲軸移至(x,y)
    End Sub

    '  Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
    '  Dim save2, save3, save4, save5, save6, save7, save8, save9, save10, save11, save12, save13, save14, save15 As String '取第n個代碼之後的
    'Dim re1, re2, re3, re4, re5, re6, re7, re8, re9, re10, re11, re12, re13, re14, re15 As String '代碼
    'Dim number1, number2, number3, number4, number5, number6, number7, number8, number9, number10, number11, number12, number13, number14, number15 As Integer '重新搜尋第n個quizDesc位置
    '
    '  For Each a As HtmlElement In WebBrowser2.Document.GetElementsByTagName("body")
    '
    '        number1 = InStr(a.InnerHtml, "<div id=" + Chr(34) + "quizDesc") '讀取第一個編號
    '        re1 = Mid(a.InnerHtml, number1 + 17, 4) ''成功取得第一個代碼
    '       '-----
    '       save2 = a.InnerHtml
    '       save2 = Mid(a.InnerHtml, number1 + 21, Len(a.InnerHtml) - (number1 + 21)) '取第一個代碼之後的
    '       number2 = InStr(save2, "<div id=" + Chr(34) + "quizDesc") '重新搜尋第二個quizDesc位置
    '       re2 = Mid(save2, number2 + 17, 4) ''成功取得第二個代碼
    '      '-----
    '      save3 = Mid(save2, number2 + 21, Len(a.InnerHtml) - (number2 + 21)) '取第二個代碼之後的
    '      number3 = InStr(save3, "<div id=" + Chr(34) + "quizDesc") '重新搜尋第三個quizDesc位置
    '      re3 = Mid(save3, number3 + 17, 4) '成功取得第三個代碼
    '-----
    '     save4 = Mid(save3, number3 + 21, Len(a.InnerHtml) - (number3 + 21)) '取第三個代碼之後的
    '     number4 = InStr(save4, "<div id=" + Chr(34) + "quizDesc") '重新搜尋第四個quizDesc位置
    '    re4 = Mid(save4, number4 + 17, 4) '成功取得第四個代碼
    '    '-----
    '    save5 = Mid(save4, number4 + 21, Len(a.InnerHtml) - (number4 + 21)) '取第四個代碼之後的
    '    number5 = InStr(save5, "<div id=" + Chr(34) + "quizDesc") '重新搜尋第五個quizDesc位置
    '   re5 = Mid(save5, number5 + 17, 4) '成功取得第五個代碼
    '-----
    '  Next
    '    Label4.Text = re1 + " 第一場" + vbNewLine + re2 + " 第二場" + vbNewLine + re3 + " 第三場" + vbNewLine + re4 + " 第四場" + vbNewLine + re5 + " 第五場" + vbNewLine + re6
    ' End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("http://www.fitness.org.tw/exam/")
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If WebBrowser1.Url.ToString = "http://www.fitness.org.tw/exam/quizmain.php" Or
            WebBrowser2.Url.ToString = "http://www.fitness.org.tw/exam/quizmain.php" Then '如果已經登入,跳轉到第二表單
            step2.Show()
            Me.Close()
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Process.Start("https://goo.gl/forms/ODva9ym8ZC6bSQ6i1")
    End Sub
End Class
