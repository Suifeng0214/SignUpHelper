Public Class step3
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            step4.WebBrowser1.Document.GetElementById("registerName").SetAttribute("value", TextBox1.Text) '
            step4.WebBrowser1.Document.GetElementById("registerSchool").SetAttribute("value", TextBox2.Text) '
            step4.WebBrowser1.Document.GetElementById("registerClass").SetAttribute("value", TextBox3.Text) '
            step4.WebBrowser1.Document.GetElementById("registerSitNo").SetAttribute("value", TextBox4.Text) '
            step4.WebBrowser1.Document.GetElementById("registerAddress").SetAttribute("value", TextBox5.Text) '
            step4.WebBrowser1.Document.GetElementById("registerTEL").SetAttribute("value", TextBox6.Text) '
            step4.WebBrowser1.Document.GetElementById("emergencyName").SetAttribute("value", TextBox7.Text) '
            step4.WebBrowser1.Document.GetElementById("emergencyRelation").SetAttribute("value", TextBox8.Text) '
            step4.WebBrowser1.Document.GetElementById("emergencyAddress").SetAttribute("value", TextBox9.Text) '
            step4.WebBrowser1.Document.GetElementById("emergencyTEL").SetAttribute("value", TextBox10.Text) '
            step4.WebBrowser1.Document.GetElementById("emergencyMobile").SetAttribute("value", TextBox11.Text)
            step4.WebBrowser1.Document.GetElementById("emergencyMobile").SetAttribute("value", TextBox11.Text) '
            '-----------------------------------------------------------
            For Each a1 As HtmlElement In step4.WebBrowser1.Document.GetElementsByTagName("SELECT")
                '性別
                If a1.GetAttribute("name") = "registerSEX" Then
                    a1.SetAttribute("value", Mid(ComboBox1.Text, 1, 1))  'MID是函數第一個1表從第幾位開始算,第二個1表向右算幾格
                End If
                '年
                If a1.GetAttribute("name") = "registerBirthYear" Then
                    a1.SetAttribute("value", ComboBox2.Text)
                    a1.RaiseEvent("onchange")
                End If
                '月
                If a1.GetAttribute("name") = "registerBirthMonth" Then
                    a1.SetAttribute("value", ComboBox3.Text)
                    a1.RaiseEvent("onchange")
                End If
                '日
                If a1.GetAttribute("name") = "registerBirthDay" Then
                    a1.SetAttribute("value", ComboBox4.Text)
                    a1.RaiseEvent("onchange")
                End If
                If a1.GetAttribute("name") = "registerCounty" Then
                    a1.SetAttribute("value", Mid(ComboBox5.Text, 5, 2))
                    a1.RaiseEvent("onchange")
                End If
                If a1.GetAttribute("name") = "emergencyCounty" Then
                    a1.SetAttribute("value", Mid(ComboBox7.Text, 5, 2))
                    a1.RaiseEvent("onchange")
                End If

                If a1.GetAttribute("name") = "registerCountyZone" Then
                    a1.SetAttribute("value", Mid(ComboBox6.Text, 5, 3))
                    a1.RaiseEvent("onchange")
                End If
                If a1.GetAttribute("name") = "emergencyCountyZone" Then
                    a1.SetAttribute("value", Mid(ComboBox8.Text, 5, 3))
                    a1.RaiseEvent("onchange")
                End If
            Next
        Catch
            MsgBox("發生錯誤!", 0 + 48, "提示")
        End Try
        '------------------------------------------------------------
    End Sub
End Class