Imports System.Globalization
Imports DevExpress.LookAndFeel
Imports DevExpress.Skins
Imports DevExpress.Skins.Info
Imports DevExpress.Utils
Imports DevExpress.XtraBars.Docking2010.Customization
Imports DevExpress.XtraSplashScreen

Friend NotInheritable Class Program
    ''' <summary>
    ''' The main entry point for the application.
    ''' </summary>
    Private Sub New()
    End Sub
    <STAThread>
    Shared Sub Main()
        DevExpress.XtraEditors.WindowsFormsSettings.ApplyDemoSettings()
        SkinManager.EnableFormSkins()
        DevExpress.UserSkins.BonusSkins.Register()
        AppearanceObject.DefaultFont = New Font("Segoe UI", 8.25F)

        Dim demoCI As CultureInfo = CType(Application.CurrentCulture.Clone(), CultureInfo)
        'demoCI.NumberFormat.CurrencySymbol = "N"

        Application.CurrentCulture = demoCI
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        'DataHelper.CreateWmiService()
        'SplashScreenManager.ShowForm(Nothing, GetType(SplashScreen), True, True, False, 1000)
        Application.Run(New MainForm)
    End Sub
End Class
