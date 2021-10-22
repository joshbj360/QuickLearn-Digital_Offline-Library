Imports System.Threading.Tasks
Imports CefSharp

Imports CefSharp.WinForms

'<PermissionSet(Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
Public Class BrowserPage

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        Dim settings As CefSettings = New CefSettings

        'settings.CefCommandLineArgs.Add("enable-npapi", "1")
        'settings.CefCommandLineArgs.Add("ppapi-flash-path", "C:\Windows\System32\Macromed\Flash\pepflashplayer32_32_0_0_433.dll")
        'settings.CefCommandLineArgs.Add("ppapi-flash-version", "32.0.0.433")
        CefSharp.Cef.Initialize(settings)
        Dim Browser As New ChromiumWebBrowser("about:blank") With {.Dock = DockStyle.Fill}
        NavigationPage1.Controls.Add(Browser)
        webBrowserPropty = Browser

    End Sub

    Private Sub InitializeBrowser()



    End Sub

    'Private Sub OnFrameLoadEnd(sender As Object, e As FrameLoadEndEventArgs)
    '    Dim task As Task = New Task(Sub()
    '                                    If e.Url.Contains("jotform") Then
    '                                        PrintCookies(e.Url, e.HttpStatusCode, e.Frame, e.Browser)
    '                                        EvaluateScript(WebBrowser, Script1.Value)
    '                                    End If
    '                                End Sub)
    '    task.Start()
    'End Sub
    Private Shared Function EvaluateScript(browser1 As ChromiumWebBrowser, ByVal script As String) As Object
        Dim task = browser1.EvaluateScriptAsync(script)
        task.Wait()
        Dim response As JavascriptResponse = task.Result
        'Return If(response.Success, (If(response.Result, "")), response.Message)
        If response.Success Then
            If response.Result Is Nothing Then
                Return ""
            Else
                Return response.Result
            End If
        Else
            Return response.Message
        End If

    End Function

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) 
        If CefSharp.Cef.IsInitialized = True Then
            MsgBox("The browser is ok")
        End If
    End Sub
    'Public Visitor As CookieMonster
    'Sub PrintCookies(Url As String, HttpStatusCode As Integer, Frame As IFrame, Browser As IBrowser)
    '    Visitor = New CookieMonster()
    '    Dim CookieManager = Browser.GetCookieManager
    '    If CookieManager.VisitUrlCookies(Url, True, Visitor) Then Visitor.WaitForAllCookies()

    '    Dim sb = New Text.StringBuilder()
    '    For Each nameValue In Visitor.NamesValues
    '        sb.AppendLine(nameValue.Item1 + " = " + nameValue.Item2)
    '    Next

    '    MessageBox.Show("Cookies:" & vbCrLf & sb.ToString, Url & "(" & HttpStatusCode & ")")
    'End Sub
End Class
