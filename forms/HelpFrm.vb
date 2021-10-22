Imports CefSharp
Imports CefSharp.WinForms
Public Class HelpFrm
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Dim Browser As New ChromiumWebBrowser("Http://wwww.quicklearnlib.blogspot.com/") With {.Dock = DockStyle.Fill}
        PanelControl1.Controls.Add(Browser)
    End Sub
End Class