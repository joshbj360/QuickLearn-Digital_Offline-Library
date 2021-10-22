
Imports CefSharp
Imports CefSharp.WinForms
Public Class test_form
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

    End Sub

    Private Sub test_form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click

        ' Add any initialization after the InitializeComponent() call.
        Get_Drive_Letter = "H:\Josh!!!\Quick_library\Quick_library\".Replace("\", "/")
        Dim browser As New ChromiumWebBrowser("about:blank") With {.Dock = DockStyle.Fill}
        browser.Load(Get_Drive_Letter + "modules/en-GCF2015/index.html")
        'browser.Show()
        PanelControl1.Controls.Add(browser)
        If browser.Visible = True Then
            MsgBox("Browser is showing")
        End If
    End Sub
End Class