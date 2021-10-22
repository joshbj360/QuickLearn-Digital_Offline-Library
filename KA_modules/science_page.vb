Imports System.Text
Imports DevExpress.XtraNavBar
Imports DevExpress.XtraBars.Navigation
Imports DevExpress.XtraEditors
Imports PVS.MediaPlayer
Public Class science_page
    Private mp As media_player_control = getMediaPlayerControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        createTiles(TileBarGroup2, navTileNamePROP) 'create the subject tiles
        NavBarControl1.OptionsNavPane.NavPaneState = NavPaneState.Expanded
        NavBarGroup1.Expanded = True

        loadModule(NavBarControl1, NavBarGroup1, TileBarGroup2.Items(0).Name) 'load the topics for each subject
        createVideoTiles(TileGroup2, NavBarGroup1.ItemLinks(0).ItemName, NavBarGroup1.ItemLinks(0).Item.Caption) 'create tiles for the video
        ' ListBoxControl1.DataSource = getCurrentPlayList
        'assign controls to global containers in Helpers Module
        mp.GetNavFrame = Me.NavigationFrame1
        mp.getSubjectLayoutItem = Me.subjectLayoutitem
        mp.getTopicLayoutItem = Me.topicsLayoutItem
        mp.getDescLayoutItem = Me.descLayoutItem
        mp.VideoEndLabel = Me.videdEndlabel
        mp.VideoStartLabel = Me.videoStartlabel
        mp.TrackBar1 = Me.TrackBar1

        mp.myPlayer.Sliders.Position.TrackBar = TrackBar1
        If mp.issInitializing Then Return
        mp.myPlayer.Sliders.Position.LiveUpdate = True
    End Sub

    'event for the subject tile, creates topic naviagetion and load the first topic in the list
    Private Sub TileBar1_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileBar1.ItemClick
        Dim dlg As New DevExpress.Utils.WaitDialogForm
        dlg.Caption = "Loading " + e.Item.Text + " module"
        loadModule(NavBarControl1, NavBarGroup1, e.Item.Name)
        createVideoTiles(TileGroup2, NavBarGroup1.ItemLinks(0).ItemName, NavBarGroup1.ItemLinks(0).Item.Caption)
        mp.StopMedia()
        NavigationFrame1.SelectedPage = NavigationPage1
        dlg.Dispose()
    End Sub

    'Create video tiles and stop any playing video
    Private Sub NavBarControl1_LinkClicked(sender As Object, e As NavBarLinkEventArgs) Handles NavBarControl1.LinkClicked
        createVideoTiles(TileGroup2, e.Link.ItemName, e.Link.Item.Caption)
        'ListBoxControl1.DataSource = getCurrentPlayList
        ' getCurrentPlayList.Clear()


        mp.StopMedia()
        NavigationFrame1.SelectedPage = NavigationPage1
    End Sub

    'plays the video, when the videoTile is clicked
    Private Sub TileControl1_ItemClick(sender As Object, e As TileItemEventArgs) Handles TileControl1.ItemClick
        Dim dlg As New DevExpress.Utils.WaitDialogForm
        dlg.Caption = "Loading video..."
        Dim vid As video = getVideo(e.Item.Name)
        videoTileNameProp = e.Item.Name
        PrevNextDescription = ToTitleCase(vid.title) + vbCrLf + vid.description
        mp.DescriptionLbl.Text = PrevNextDescription
        VideoNamePROP = Get_Drive_Letter + "modules\en-kalite-ess\content\" + vid.youtube_id + ".mp4"
        GetCurrentPlayingVid = vid
        'WebBrowser1.Navigate("H:\Josh_Quicklearn\en-kalite-ess\content\_BFDgTci0ck.mp4") '+ getVideoID(e.Item.Name))
        mp.Dock = DockStyle.Fill
        PanelControl1.Controls.Add(mp)
        mp.PlayMedia(VideoNamePROP)
        'MsgBox(mp.getPlayingVIDname)
        NavigationFrame1.SelectedPage = NavigationPage2
        dlg.Dispose()
    End Sub
    'move the navigation frame, a page backwards which go back To playlist
    Public Sub gobackToPlayList()
        Try
            NavigationFrame1.SelectPrevPage()
            mp.StopMedia()
        Catch ex As Exception

        End Try


    End Sub
#Region "Buttons"

    Private Sub WindowsUIButtonPanel1_ButtonChecked(sender As Object, e As DevExpress.XtraBars.Docking2010.ButtonEventArgs) Handles WindowsUIButtonPanel1.ButtonChecked
        'full screen
        If e.Button.Properties.Caption = "Fullscreen" Then
            subjectLayoutitem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            topicsLayoutItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            mp.DescriptionLbl.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            e.Button.Properties.Caption = "Exit Fullscreen"
            mp.Fullscreen(True)
        End If
        ' Pause / Resume
        If e.Button.Properties.Caption = "Resume" Then
            mp.myPlayer.Paused = mp.myPlayer.Paused
            If (mp.myPlayer.Paused) Then
                e.Button.Properties.Caption = "Pause"
            End If
        End If
    End Sub
    Private Sub WindowsUIButtonPanel1_ButtonUnchecked(sender As Object, e As DevExpress.XtraBars.Docking2010.ButtonEventArgs) Handles WindowsUIButtonPanel1.ButtonUnchecked
        'full screen
        If e.Button.Properties.Caption = "Exit Fullscreen" Then
            subjectLayoutitem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            topicsLayoutItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            mp.DescriptionLbl.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            e.Button.Properties.Caption = "Fullscreen"
            mp.Fullscreen(False)
        End If
        ' Pause / Resume
        If e.Button.Properties.Caption = "Pause" Then
            mp.myPlayer.Paused = Not mp.myPlayer.Paused
            If (mp.myPlayer.Paused) Then
                e.Button.Properties.Caption = "Resume"
            End If
        End If
    End Sub
    Private Sub WindowsUIButtonPanel1_ButtonClick(sender As Object, e As DevExpress.XtraBars.Docking2010.ButtonEventArgs) Handles WindowsUIButtonPanel1.ButtonClick
        ' Play
        If e.Button.Properties.Caption = "Play" Then
            If VideoNamePROP IsNot Nothing Then
                mp.PlayMedia(VideoNamePROP)
            End If
        End If

        ' Stop
        If e.Button.Properties.Caption = "Stop" Then
            mp.StopMedia()
        End If
        'return back to playlist
        If e.Button.Properties.Caption = "Playlist" Then
            subjectLayoutitem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            topicsLayoutItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            gobackToPlayList()
        End If



        'play next video
        If e.Button.Properties.Caption = "Next Video" Then
            mp.PrevNextVideo(1)
        End If
        'play previous video
        If e.Button.Properties.Caption = "Previous Video" Then
            mp.PrevNextVideo(-1)
        End If
    End Sub

    Friend Sub BackToPlayList()
        Try


        Catch ex As Exception

        End Try
        mp.StopMedia()

    End Sub
#End Region



End Class
