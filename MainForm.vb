Imports DevExpress.XtraEditors
Imports DevExpress.XtraBars.Docking2010.Views.WindowsUI
Imports QL_Desktop_1.BrowserPage
Imports CefSharp
Imports System.IO
Imports System.Management

Partial Public Class MainForm
    Inherits XtraForm
    Private browser As New BrowserPage()
    Private mp As media_player_control = New media_player_control

    Public Sub New()
        InitializeComponent()
        getMediaPlayerControl = mp
        AddHandler Me.windowsUIView1.QueryControl, AddressOf windowsUIView1_QueryControl
        createViewButtons()
        Get_Drive_Letter = "C:\Users\Josh\Desktop\QuickLearn\Quick_library\Quick_library\".Replace("\", "/")
        '  windowsUIView1.RestoreLayoutFromXml(Application.StartupPath + "\Data\sessionlayout\Winlayout.xml")
    End Sub

    ' Assigning a required content for each auto generated Document
    Sub windowsUIView1_QueryControl(sender As Object, e As DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs)
        mp.StopMedia()
        If e.Document Is math_pageDocument Then
            e.Control = New math_page()

        End If
        If e.Document Is economics_pageDocument Then
            e.Control = New economics_page()
        End If
        If e.Document Is computing_pageDocument Then
            e.Control = New computing_page()
        End If
        'If e.Document Is landing_pageDocument Then
        '    e.Control = New QL_Desktop_1.landing_page()
        'End If

        If e.Document Is science_pageDocument Then
            e.Control = New science_page()
        End If

        If e.Document Is browserPageDocument Then
            e.Control = browser
            'webBrowserPropty = TryCast(e.Control.Controls.Item("WebBrowser2"), WebBrowser)
        End If

        'If e.Document Is media_player_controlDocument Then
        '    e.Control = New QL_Desktop_1.media_player_control()
        'End If
        'If e.Document Is Document2 Then
        '    e.Control = New QL_Desktop_1.landing_page()
        'End If
        'If e.Document Is test_moduleDocument Then
        '    e.Control = New QL_Desktop_1.test_module()
        'End If
        If e.Control Is Nothing Then
            e.Control = New System.Windows.Forms.Control()
        End If
    End Sub
    Private Sub PageGroup1_HeaderClick(sender As Object, e As DevExpress.XtraBars.Docking2010.Views.DocumentHeaderClickEventArgs) Handles PageGroup1.HeaderClick
        mp.StopMedia()
        If e.Document Is math_pageDocument Then
            navTileNamePROP = "math"
        End If
        If e.Document Is computing_pageDocument Then
            navTileNamePROP = "computing"
        End If
        If e.Document Is science_pageDocument Then
            navTileNamePROP = "science"
        End If
        If e.Document Is economics_pageDocument Then
            navTileNamePROP = "economics-finance-domain"
        End If
    End Sub
    Private tc As Color
    Private Sub mainTileContainer_Click(sender As Object, e As TileClickEventArgs) Handles mainTileContainer.Click

        PathLevelPROP = 2
        TileForeColor = e.Tile.Appearances.Normal.ForeColor
        tc = e.Tile.Appearances.Normal.BackColor
        a_p = tc.A
        r1_p = tc.R
        r2_p = tc.R + 10
        g1_p = tc.G
        g2_p = tc.G + 10
        b1_p = tc.B
        b2_p = tc.B + 10


        If e.Tile Is math_pageTile Then
            navTileNamePROP = "math"

        End If
        If e.Tile Is science_pageTile Then
            navTileNamePROP = "science"
        End If
        If e.Tile Is computing_pageTile Then
            navTileNamePROP = "computing"
        End If
        If e.Tile Is economics_pageTile Then
            navTileNamePROP = "economics-finance-domain"
        End If
        If e.Tile Is ck12Tile Then
            getUrl = Get_Drive_Letter + "modules/en-ck12/index.html"
            Loadurl(getUrl)
            'TrueFlase = True
        End If
        If e.Tile Is GreatBooksTile Then
            getUrl = Get_Drive_Letter + "modules/en-ebooks/index.html"
            Loadurl(getUrl)
            'TrueFlase = True
        End If
        If e.Tile Is WikiSliceChemistry Then
            getUrl = Get_Drive_Letter + "modules/olpc/wikislice-chemistry-en/index.html"
            'webBrowserPropty.Navigate(getUrl)
            Loadurl(getUrl)
        End If
        If e.Tile Is PhetTile Then
            getUrl = Get_Drive_Letter + "modules/Phet/en/simulations/category/html.html"
            'webBrowserPropty.Navigate(getUrl)
            Loadurl(getUrl)
        End If
        If e.Tile Is EnotesTile Then
            getUrl = Get_Drive_Letter + "modules/eNotes/enotes_index.html"
            'webBrowserPropty.Navigate(getUrl)
            Loadurl(getUrl)
        End If
        If e.Tile Is WikiSlicePhysicsTile Then
            getUrl = Get_Drive_Letter + "modules/olpc/wikislice-physics-en/index.html"
            'webBrowserPropty.Navigate(getUrl) kjmkojj\\[l[l\
            Loadurl(getUrl)
        End If
        If e.Tile Is GCFlearTile Then
            getUrl = Get_Drive_Letter + "modules/en-GCF2015/index.html"
            'webBrowserPropty.Navigate(getUrl)
            Loadurl(getUrl)
        End If
        If e.Tile Is ReadingGuideTile Then
            getUrl = Get_Drive_Letter + "modules/en-oerafrica-reading/GSG_3_index.html"
            'webBrowserPropty.Navigate(getUrl)
            Loadurl(getUrl)
        End If
        If e.Tile Is worldMapTile Then
            getUrl = Get_Drive_Letter + "modules/en-worldmap/map.html"
            'webBrowserPropty.Navigate(getUrl)
            Loadurl(getUrl)
        End If
        If e.Tile Is WikipediaTile Then
            getUrl = Get_Drive_Letter + "modules/wikipedia_for_schools/index.htm"
            'webBrowserPropty.Navigate(getUrl)
            Loadurl(getUrl)
        End If
        If e.Tile Is FarmersMagTile Then
            getUrl = Get_Drive_Letter + "modules/en-infonet/export/default$text$-1$orgFarmerGroup.html"
            'webBrowserPropty.Navigate(getUrl)
            Loadurl(getUrl)
        End If
        If e.Tile Is MedLineTile Then
            getUrl = Get_Drive_Letter + "modules/en-medline_plus/encyclopedia.html"
            ' 'webBrowserPropty.Navigate(getUrl)
            Loadurl(getUrl)
        End If
        If e.Tile Is DigitalLiteracyTile Then
            getUrl = Get_Drive_Letter + "modules/powertyping/index.html"
            ' 'webBrowserPropty.Navigate(getUrl)
            Loadurl(getUrl)
        End If
        If e.Tile Is PracticalActionTile Then
            getUrl = Get_Drive_Letter + "modules/en-practical_action/index.html"
            '  'webBrowserPropty.Navigate(getUrl)
            Loadurl(getUrl)
        End If
        If e.Tile Is HesperiaTIle Then
            getUrl = Get_Drive_Letter + "modules/scratch/index.html"
            '  'webBrowserPropty.Navigate(getUrl)
            Loadurl(getUrl)
        End If
        If e.Tile Is InfonetTile Then
            getUrl = Get_Drive_Letter + "modules/en-infonet/starthere.html"
            ' 'webBrowserPropty.Navigate(getUrl)
            Loadurl(getUrl)
        End If
        If e.Tile Is MusicTheoryTile Then
            getUrl = Get_Drive_Letter + "modules/en-musictheory/index.html"
            ''webBrowserPropty.Navigate(getUrl)
            Loadurl(getUrl)
        End If
    End Sub
#Region "ViewButtons"
    Private canExecuteFunction As Func(Of Boolean) = Function() True
    Private executeFuncton As Action = Sub() MsgBox("Hello World!")
    Private Sub createViewButtons()
        windowsUIView1.AppearanceActionsBar.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap

        Dim vccAction As New DelegateAction(canExecuteFunction, AddressOf searchFrm)
        vccAction.Caption = "Search"
        vccAction.ImageOptions.Image = My.Resources.Shape_98
        vccAction.Type = ActionType.Navigation
        vccAction.Edge = ActionEdge.Left
        vccAction.Behavior = ActionBehavior.HideBarOnClick
        windowsUIView1.ContentContainerActions.Add(vccAction)

        'Dim ccAction As New DelegateAction(AddressOf hh, AddressOf manageModules)
        'ccAction.Caption = "Manage Modules"
        'ccAction.ImageOptions.Image = My.Resources.settings_1
        'ccAction.Type = ActionType.Navigation
        'ccAction.Edge = ActionEdge.Left
        'ccAction.Behavior = ActionBehavior.Default
        ''Page1.Actions.Add(ccAction)
        'windowsUIView1.ContentContainerActions.Add(ccAction)

        Dim wifiAction As New DelegateAction(AddressOf hh, AddressOf createWiFi)
        wifiAction.Caption = "Share Library"
        wifiAction.Description = "Share Library to your phone through WiFi Hotspot."
        wifiAction.ImageOptions.Image = My.Resources.wicd
        wifiAction.Type = ActionType.Navigation
        wifiAction.Edge = ActionEdge.Left
        windowsUIView1.ContentContainerActions.Add(wifiAction)

        Dim ejectButton As New DelegateAction(AddressOf hh, AddressOf createWiFi)
        ejectButton.Caption = "Eject Drive"
        ejectButton.ImageOptions.Image = My.Resources.usb_2
        ejectButton.Type = ActionType.Navigation
        ejectButton.Edge = ActionEdge.Right
        windowsUIView1.ContentContainerActions.Add(ejectButton)

        Dim HelpButton As New DelegateAction(AddressOf hh, AddressOf HelpFrm)
        HelpButton.Caption = "Help"
        HelpButton.ImageOptions.Image = My.Resources.Shape_12
        HelpButton.Type = ActionType.Navigation
        HelpButton.Edge = ActionEdge.Right
        windowsUIView1.ContentContainerActions.Add(HelpButton)

        Dim WhiteTheme As New SetSkinAction("Metropolis", "White Theme")
        WhiteTheme.Edge = ActionEdge.Right

        windowsUIView1.ContentContainerActions.Add(WhiteTheme)

        Dim blackTheme As New SetSkinAction("MetroBlack", "Black Theme")
        blackTheme.Edge = ActionEdge.Right
        windowsUIView1.ContentContainerActions.Add(blackTheme)


    End Sub
    'browser page buttons
    Private Sub Page1_ButtonClick(sender As Object, e As DevExpress.XtraBars.Docking2010.ButtonEventArgs) Handles Page1.ButtonClick
        If e.Button.Properties.Caption = "Backward" Then
            webBrowserPropty.Back()
        End If
        If e.Button.Properties.Caption = "Forward" Then
            webBrowserPropty.Forward()
        End If
    End Sub


    Shared Function hh() As Boolean
        Return True
    End Function
    Shared Sub searchFrm()
        Dim searchFrm As New SearchFrm
        searchFrm.ShowDialog(MainForm)
    End Sub
    Shared Sub createWiFi()

        Dim HotSpotfrm As New HotSpotForm
        HotSpotfrm.ShowDialog(MainForm)

    End Sub
    Sub HelpFrm()
        Me.windowsUIView1.ActivateContainer(Page1)
        Me.windowsUIView1.ActivateDocument(browser)
        getUrl = "Http://wwww.quicklearnlib.blogspot.com/"
        'webBrowserPropty.Navigate(getUrl)
        Loadurl(getUrl)
    End Sub
    Shared Sub manageModules()
        Dim mm As New ManageModules
        mm.ShowDialog(MainForm)
    End Sub

#End Region



    Private Sub mainTileContainer_ButtonClick(sender As Object, e As DevExpress.XtraBars.Docking2010.ButtonEventArgs) Handles mainTileContainer.ButtonClick
        If e.Button.Properties.Caption = "All Modules" Then
            Me.windowsUIView1.ActivateContainer(Page1)
            Me.windowsUIView1.ActivateDocument(browser)
            getUrl = Get_Drive_Letter + "all_modules.html"
            'webBrowserPropty.Navigate(getUrl)
            Loadurl(getUrl)
        End If
        If e.Button.Properties.Caption = "Search" Then
            Dim searchFrm As New SearchFrm
            searchFrm.ShowDialog(Me)
        End If
        If e.Button.Properties.Caption = "Disclaimer" Then
            Dim searchFrm As New HelpFrm
            searchFrm.ShowDialog(Me)
        End If
        If e.Button.Properties.Caption = "Exit" Then
            Dim closeAction As FlyoutAction = CreateCloseAction()
            Flyout2.Action = closeAction
            If windowsUIView1.ShowFlyoutDialog(Flyout2) <> System.Windows.Forms.DialogResult.No Then
                Application.Exit()
            End If
        End If
    End Sub

    Private Sub Loadurl(ByVal url As String)
        Dim dlg As New DevExpress.Utils.WaitDialogForm
        dlg.Caption = "Loading... "
        webBrowserPropty.Load(url)
        dlg.Dispose()
    End Sub
    Private Sub windowsUIView1_DocumentDeactivated(sender As Object, e As DevExpress.XtraBars.Docking2010.Views.DocumentEventArgs) Handles windowsUIView1.DocumentDeactivated
        mp.StopMedia()
    End Sub
    Private Sub RestoreSession()
        Using sr As New StreamWriter(Application.StartupPath + "\data\sessionlayout\NavTileNameProp.txt")

        End Using
    End Sub
    Private Sub saveCurrentSession()
        'save the queried list to txt file
        Dim s As String = "."
        Using sw As New StreamWriter(Application.StartupPath + "\data\sessionlayout\getTopicBySlash.txt")

            For Each item As String In getCurrentTopicBySlash_2
                sw.WriteLine(item)
            Next
            sw.Flush()
            sw.Close()
        End Using
        Using sw1 As New StreamWriter(Application.StartupPath + "\data\sessionlayout\queriedlist.txt")
            For Each item In getCurrentPlayList
                sw1.WriteLine(item)
            Next
            sw1.Flush()
            sw1.Close()
        End Using
        Using sw2 As New StreamWriter(Application.StartupPath + "\data\sessionlayout\ListOfPath.txt")
            For Each item In getListOfPath()
                sw2.WriteLine(item)
            Next
            sw2.Flush()
            sw2.Close()
        End Using
        Using sw3 As New StreamWriter(Application.StartupPath + "\data\sessionlayout\PathLevelProp.txt")
            sw3.WriteLine(PathLevelPROP)
        End Using
        Using sw4 As New StreamWriter(Application.StartupPath + "\data\sessionlayout\NavTileNameProp.txt")
            sw4.WriteLine(navTileNamePROP)
        End Using
        MsgBox(s)
        'save the mainform layout
        windowsUIView1.SaveLayoutToXml(Application.StartupPath + "\Data\sessionlayout\Winlayout.xml")
    End Sub

    Protected Overrides Sub OnClosing(ByVal e As System.ComponentModel.CancelEventArgs)
        MyBase.OnClosing(e)
        Dim restoreTimerState As Boolean = False
        '   saveCurrentSession()
        Dim closeAction As FlyoutAction = CreateCloseAction()
        Flyout2.Action = closeAction


        If windowsUIView1.ShowFlyoutDialog(Flyout2) <> System.Windows.Forms.DialogResult.Yes Then
            e.Cancel = True

        End If
    End Sub
    Private Function CreateCloseAction() As FlyoutAction
        Dim closeAction As New FlyoutAction()
        '    closeAction.Caption = "QuickLearn Digital Library"
        closeAction.Description = "Do you really want To close the library?" + vbCrLf _
                                   + "______________________________________________________________" + vbCrLf _
                                   + " QuickLearn Educational Consult. Copyright (c) 2018 - " + Today.Date.Year.ToString
        closeAction.Commands.Add(FlyoutCommand.Yes)
        closeAction.Commands.Add(FlyoutCommand.No)

        Return closeAction
    End Function

#Region "Load Flash Action"

    Private Function CreateFlashAction(ByVal Desc As String, ByVal Optional flycommand As String = Nothing) As FlyoutAction
        Dim description As String = Desc + vbCrLf +
                                    "________________________________________________________________________________________" + vbCrLf _
                                    + "By clicking 'OK' on this application, you agree to our terms and conditions." + vbCrLf _
                                    + "________________________________________________________________________________________" + vbCrLf _
                                    + "We do not claim any right whatsoever on the ownership of some of the modules," + vbCrLf _
                                    + "However, Copyright of any kind without a written permission, would be dealt with" + vbCrLf _
                                    + "legal actions." + vbCrLf _
                                    + "Most of the modules are covered under Creative Commons Attribution-NonCommercial- " + vbCrLf _
                                    + "ShareAlike 3.0 Unported License. For more information and latest updates, visit" + vbCrLf _
                                    + "our blog: https : //quicklearnlib.blogspot.com/" + vbCrLf _
                                    + "_______________________________________________________________________________________" + vbCrLf _
                                    + " QuickLearn Educational Consult. Copyright (c) 2018 - " + Today.Date.Year.ToString

        Dim loadaction As New FlyoutAction()
        loadaction.Description = description
        Return loadaction
    End Function


    'get the QL drive letter
    Public Sub GetQLDriveMessage()
        Dim QLMessage As String = Nothing
        Dim boolDriveStatus As Boolean = False
        'Get all drives plugged to the system
        Dim drives As List(Of Drive) = New List(Of Drive)
        Dim allDrives() As DriveInfo = DriveInfo.GetDrives()
        Dim d As DriveInfo
        For Each d In allDrives
            drives.Add(New Drive(d.Name, d.DriveType.ToString, d.RootDirectory.ToString))
        Next

        'Get all the removable drives from the list of drives.
        Dim USB_drives As List(Of String) = New List(Of String)
        For Each drive In drives
            If drive.DriveFileType.ToLower.Contains("removable") Then
                USB_drives.Add(drive.DriveName)
            End If
        Next

        'Get QL drive letter from the list of removable drives.
        If USB_drives.Count <= 0 Then
            GetDriveMessage = "Plug in QuickLearn Drive."
            '   MsgBox(GetDriveMessage)
        End If
        For Each USB_drive In USB_drives
            Dim FilesFound() As String = My.Computer.FileSystem.GetFiles(USB_drive + "Quick_library\Readme".Trim,
                                       Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, "startmgr.txt").ToArray
            If FilesFound.Count > 0 Then
                '  Get_Drive_Letter = (USB_drive + "QuickLearn\Quick_library\Quick_library\").Replace("\", "/")
                '   Get_Drive_Letter = (USB_drive + "Quick_library\").Replace("\", "/")
                GetDriveMessage = "QuickLearn Drive plugged in."
                ' MsgBox(Get_Drive_Letter)
            Else

                GetDriveMessage = "Cannot find QuickLearn Drive."
                ' MsgBox(GetDriveMessage)
            End If

        Next

    End Sub
    Private WithEvents m_MediaConnectWatcher As ManagementEventWatcher
    Public Sub StartDetection()
        ' __InstanceOperationEvent will trap both Creation and Deletion of class instances
        Dim query2 As New WqlEventQuery("SELECT * FROM __InstanceOperationEvent WITHIN 1 " & "WHERE TargetInstance ISA 'Win32_DiskDrive'")
        m_MediaConnectWatcher = New ManagementEventWatcher
        m_MediaConnectWatcher.Query = query2
        m_MediaConnectWatcher.Start()
    End Sub

    Private Sub Arrived(ByVal sender As Object, ByVal e As System.Management.EventArrivedEventArgs) Handles m_MediaConnectWatcher.EventArrived
        Dim mbo, obj As ManagementBaseObject
        Dim DriveLetter As String = ""
        Dim IsQLDrive As New Boolean
        ' the first thing we have to do is figure out if this is a creation or deletion event
        mbo = CType(e.NewEvent, ManagementBaseObject)
        ' next we need a copy of the instance that was either created or deleted
        obj = CType(mbo("TargetInstance"), ManagementBaseObject)
        Select Case mbo.ClassPath.ClassName
            Case "__InstanceCreationEvent"
                If obj("InterfaceType").ToString = "USB" Then
                    DriveLetter = GetDriveLetterFromDisk(obj("Name").ToString)
                    Dim FilesFound() As String = My.Computer.FileSystem.GetFiles(DriveLetter + "\Quick_library\Readme".Trim,
                                       Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, "startmgr.txt").ToArray
                    If FilesFound.Count > 0 Then
                        IsQLDrive = True
                        '    Get_Drive_Letter = (DriveLetter + "\QuickLearn\Quick_library\Quick_library\").Replace("\", "/")
                        ' Get_Drive_Letter = (DriveLetter + "\Quick_library\").Replace("\", "/")
                        GetDriveMessage = "QuickLearn Drive plugged in."
                        ' MsgBox(Get_Drive_Letter)
                        XtraMessageBox.Show(GetDriveMessage, QLCaption, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'MsgBox(IsQLDrive.ToString)
                    End If


                Else
                    GetDriveMessage = (obj("InterfaceType").ToString) + " is not QuickLearn Drive."
                End If
            Case "__InstanceDeletionEvent"
                If obj("InterfaceType").ToString = "USB" Then
                    GetDriveMessage = "QuickLearn Drive " + obj("Caption").ToString & " has been unplugged"
                    DriveLetter = ""
                    XtraMessageBox.Show(GetDriveMessage, QLCaption, MessageBoxButtons.OK, MessageBoxIcon.Information)


                    'Else
                    '    LblText = obj("InterfaceType").ToString

                End If
                IsQLDrive = False
            Case Else
                GetDriveMessage = "nope: " & obj("Caption").ToString
        End Select
        ' Invoke(New LabelTextDelegate(AddressOf LabelText))

    End Sub

    Private Function GetDriveLetterFromDisk(ByVal Name As String) As String
        Dim oq_part, oq_disk As ObjectQuery
        Dim mos_part, mos_disk As ManagementObjectSearcher
        Dim obj_part, obj_disk As ManagementObject
        Dim ans As String = ""
        ' WMI queries use the "\" as an escape charcter
        Name = Replace(Name, "\", "\\")

        ' First we map the Win32_DiskDrive instance with the association called
        ' Win32_DiskDriveToDiskPartition. Then we map the Win23_DiskPartion
        ' instance with the assocation called Win32_LogicalDiskToPartition
        oq_part = New ObjectQuery("ASSOCIATORS OF {Win32_DiskDrive.DeviceID=""" & Name & """} WHERE AssocClass = Win32_DiskDriveToDiskPartition")
        mos_part = New ManagementObjectSearcher(oq_part)
        For Each obj_part In mos_part.Get()
            oq_disk = New ObjectQuery("ASSOCIATORS OF {Win32_DiskPartition.DeviceID=""" & obj_part("DeviceID").ToString & """} WHERE AssocClass = Win32_LogicalDiskToPartition")
            mos_disk = New ManagementObjectSearcher(oq_disk)
            For Each obj_disk In mos_disk.Get()
                ans &= obj_disk("Name").ToString
            Next
        Next
        Return ans
    End Function

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load



        GetQLDriveMessage()
        Flyout31.Action = CreateFlashAction(GetDriveMessage)
        Flyout31.Subtitle = ""
        If windowsUIView1.ShowFlyoutDialog(Flyout31) = System.Windows.Forms.DialogResult.OK Then
            StartDetection()
        Else
            Application.Exit()

        End If
    End Sub


#End Region
End Class
