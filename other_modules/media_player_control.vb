Imports PVS.MediaPlayer
Imports System.Text
Imports DevExpress.XtraBars.Navigation
Imports DevExpress.XtraLayout
Imports DevExpress.XtraEditors

Public Class media_player_control

#Region "Class Fields"

    Public myPlayer As Player
    Private shapeStatus As Integer              ' shapes - 0:none, 1:oval, 2:none, 3:rounded, 4:none, 5:star

    Private myInfoLabel As InfoLabel
    Private myInfoLabelText As StringBuilder = New StringBuilder(64)

    Private myMetadata As Metadata              ' media metadata properties

    Public issInitializing As Boolean
    Private wasDisposed As Boolean
#End Region

    Public Sub New()

        ' Check if Media Foundation is installed - PVS.MediaPlayer cannot be used without.
        If Not Player.MFPresent Then

            ' Media Foundation is not installed - show a message and exit the application
            MessageBox.Show("Microsoft Media Foundation" + vbNewLine + vbNewLine +
                    Player.MFPresent_ResultString + ".",
                    "PVS.MediaPlayer How To ...",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop)

            Throw New ApplicationException("Media Foundation not installed.")

        End If

        issInitializing = True
        InitializeComponent()               ' this call is required by the designer
        issInitializing = False

        myPlayer = New Player()             ' create a player
        myPlayer.Display.Window = PlayerDisplayPanel    ' and set its display to Panel1
        myPlayer.Repeat = True              ' repeat media playback when finished

        myPlayer.SleepDisabled = True       ' prevent the computer from entering sleep mode


        ' **** 8. GET MEDIA ENDED INFORMATION *****************************************************

        ' You may want to know when media has finished playing to play other (next) media and/or
        ' stop certain processes (e.g. animation on a display overlay).
        ' To detect that media has finished playing just subscribe to the MediaEnded event:

        AddHandler myPlayer.Events.MediaEnded, AddressOf MyPlayer_MediaEnded  ' see eventhandler below

        ' You don't want to start playing next media from the MediaEnded event before all processes
        ' have been notified that the previous media has finished playing, so there's another event:

        AddHandler myPlayer.Events.MediaEndedNotice, AddressOf MyPlayer_MediaEndedNotice  ' see below

        ' you can use this event to just stop any active processes (and not start any new media).
        ' (With the MediaStarted event you can (re)start processes when new media starts playing.)

        ' To unsubscribe from the event you can use the RemoveHandler statement.


        ' **** 11. CONTINUOUSLY RECEIVE INFORMATION ABOUT THE PLAYBACK POSITION *******************

        ' If you want to display the elapsed and/or remaining media playback time (or use your
        ' 'own' position slider) you can get continuous media playback positions information with:

        AddHandler myPlayer.Events.MediaPositionChanged, AddressOf MyPlayer_MediaPositionChanged ' see below

        ' The information is sent by the player every 100 milliseconds (10 times a second)
        ' This interval (and other timings) can be changed with the property myPlayer.TimerInterval

        ' To unsubscribe from the event you can use the RemoveHandler statement.


        ' **** 12. ADD A POSITION SLIDER CONTROLLED BY THE PLAYER *********************************

        ' The player can control your media playback position slider (trackbar) with:

        'myPlayer.Sliders.Position.TrackBar = TrackBar1
        'If issInitializing Then Return
        'myPlayer.Sliders.Position.LiveUpdate = True
    End Sub


    ' Clean Up - this is moved here from the 'Form1.Designer.vb' file and appended:
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If Not wasDisposed Then
                wasDisposed = True
                If disposing Then

                    ' disposing a player also stops its overlay, display clones, eventhandlers etc.
                    myPlayer.Dispose()      ' dispose the player
                    If myMetadata IsNot Nothing Then
                        myMetadata.Dispose()
                    End If

                    If myInfoLabel IsNot Nothing Then
                        myInfoLabel.Dispose()
                    End If

                    ' used by the designer - clean up
                    If components IsNot Nothing Then components.Dispose()
                End If
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    ' **** Media Play / Pause - Resume / Stop *****************************************************

#Region "Media Play / Pause - Resume / Stop / fullscreen / playlist / PrevNext / getPlayingVideo"

    Public Sub PlayMedia(ByVal videoStr As String)
        ' select and play media

        myPlayer.Play(videoStr)
        If (myPlayer.LastError) Then
            MessageBox.Show(myPlayer.LastErrorString)
        Else
            ' show media metadata properties (here for audio media only)
            If Not myPlayer.Has.Video Then
                myMetadata = myPlayer.Media.GetMetadata
                PlayerDisplayPanel.BackgroundImageLayout = ImageLayout.Zoom

                PlayerDisplayPanel.BackgroundImage = myMetadata.Image
                'myOverlay.subtitlesLabel.Text = myMetadata.Artist + vbNewLine + myMetadata.Title
            End If
        End If
    End Sub

    'Public Sub PauseMedia()
    '    myPlayer.Paused = Not myPlayer.Paused
    '    If (myPlayer.Paused) Then
    '        pausebtn.Text = "Resume"
    '    Else
    '        pausebtn.Text = "Pause"
    '    End If
    'End Sub

    Public Sub StopMedia()
        Try
            myPlayer.Stop()
        Catch ex As Exception

        End Try

    End Sub


    Public Function Fullscreen(ByVal fullScreenState As Boolean) As Boolean
        myPlayer.FullScreenMode = FullScreenMode.Display
        Return myPlayer.FullScreen = fullScreenState
    End Function



    'Play previous and Next Video
    Public Sub PrevNextVideo(Optional ByVal math As Integer = Nothing)
        Dim dlg As New DevExpress.Utils.WaitDialogForm
        dlg.Caption = "Loading video..."
        Try
            ' videoTileNameProp = Nothing
            Dim i As Integer = getCurrentPlayList.IndexOf(videoTileNameProp)
            videoTileNameProp = getCurrentPlayList(i + math)

            Dim vid As video = getVideo(videoTileNameProp)
            VideoNamePROP = Get_Drive_Letter + "modules\en-kalite-ess\content\" + vid.youtube_id + ".mp4"

            PrevNextDescription = ToTitleCase(vid.title) + vbCrLf + vid.description
            DescriptionLbl.Text = PrevNextDescription

            PlayMedia(VideoNamePROP)
            i = Nothing
        Catch ex As Exception
            dlg.Dispose()
            MsgBox(ex.Message)
        End Try
        dlg.Dispose()
    End Sub

    'get the name of the video playing in the player
    Public Function getPlayingVIDname() As String
        Return myPlayer.Media.GetName(MediaName.FileName).Trim(".mp4".ToCharArray)
    End Function
#End Region

    ' **** Player Eventhandlers *******************************************************************


    ' **** Player Eventhandlers *******************************************************************

#Region "Player Eventhandlers"


    ' Display the elapsed and remaining playback time
    Private Sub MyPlayer_MediaPositionChanged(sender As Object, e As PositionEventArgs)

        videoStartlabel.Text = TimeSpan.FromTicks(e.FromStart).ToString().Substring(0, 8) ' "hh:mm:ss"
        VideoEndLabel.Text = TimeSpan.FromTicks(e.ToStop).ToString().Substring(0, 8)    ' "hh:mm:ss"

        ' from .NET 4.0 TimeSpan supports (custom) format strings e.g.
        ' Label1.Text = TimeSpan.FromTicks(e.FromStart).ToString("hh\:mm\:ss")   ' "hh:mm:ss"

    End Sub




    ' Mouse clicked on player display - movie, overlay or just display
    Private Sub MyPlayer_MediaMouseClick(sender As Object, e As MouseEventArgs)
        If (myPlayer.Display.Mode = DisplayMode.Stretch) Then
            myPlayer.Display.Mode = DisplayMode.ZoomCenter
        Else
            myPlayer.Display.Mode = DisplayMode.Stretch
        End If
    End Sub

    ' Mouse clicked on player display clone
    Private Sub Clone_MouseClick(sender As Object, e As MouseEventArgs)

        Dim clickedPanel As Panel = CType(sender, Panel)

        Dim props As CloneProperties = myPlayer.DisplayClones.GetProperties(clickedPanel)
        If props.Layout = CloneLayout.Stretch Then
            props.Layout = CloneLayout.Zoom
        Else
            props.Layout = CloneLayout.Stretch
        End If
        myPlayer.DisplayClones.SetProperties(clickedPanel, props)

    End Sub

    ' Media has finished playing (1)
    Private Sub MyPlayer_MediaEndedNotice(sender As Object, e As EndedEventArgs)

        ' you can just stop any processes (and not starting new media) from the
        ' MediaEndedNotice eventhandler that is fired just before the MediaEnded event.

        'Select Case e.StopReason

        '    Case StopReason.Finished

        '    Case StopReason.AutoStop

        '    Case StopReason.UserStop

        'End Select

    End Sub
    ' Dispose media metadata properties
    Private Sub DisposeMetadata()
        If myMetadata IsNot Nothing Then
            '  myOverlay.subtitlesLabel.Text = String.Empty
            PlayerDisplayPanel.BackgroundImage = Nothing
            myMetadata.Dispose()
            myMetadata = Nothing
        End If
    End Sub
    ' Media has finished playing (2)
    Private Sub MyPlayer_MediaEnded(sender As Object, e As EndedEventArgs)

        DisposeMetadata()

        'Select Case e.StopReason

        '    Case StopReason.Finished
        '        ' play next media ...

        '    Case StopReason.AutoStop

        '    Case StopReason.UserStop

        'End Select

    End Sub



    ' Show an infolabel on the position slider of the player when scrolled
    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs)

        ' Get the position slider's x-coordinate of the current position (= thumb location)
        ' (myInfoLabel.AlignOffset has been set to 0, 7)
        Dim myInfoLabelLocation As Point = myPlayer.Sliders.ValueToPoint(TrackBar1, TrackBar1.Value)

        ' Show the infolabel
        myInfoLabel.Show(myPlayer.Position.FromStart.ToString().Substring(0, 8), TrackBar1, myInfoLabelLocation)

    End Sub




#End Region

    ' **** Controls Handling **********************************************************************




#Region " containers"
    Private trackB As TrackBar
    Public Property TrackBar1 As TrackBar
        Get
            Return trackB
        End Get
        Set(value As TrackBar)
            trackB = value
        End Set
    End Property

    Private srtlabel, stplabel As LabelControl
    Public Property VideoStartLabel As LabelControl
        Get
            Return srtlabel
        End Get
        Set(value As LabelControl)
            srtlabel = value
        End Set
    End Property
    Public Property VideoEndLabel As LabelControl
        Get
            Return stplabel
        End Get
        Set(value As LabelControl)
            stplabel = value
        End Set
    End Property



    Private navFrame_renamed As NavigationFrame
    Private control_renamed As PanelControl
    Private subjectLayoutItem_renamed, topicsLayoutItem_renamed, descLayoutItem_renamed As LayoutItem

    Public Property getPanelControl As PanelControl
        Get
            Return control_renamed
        End Get
        Set(value As PanelControl)
            control_renamed = value
        End Set
    End Property
    Public Property GetNavFrame As NavigationFrame
        Get
            Return navFrame_renamed
        End Get
        Set(value As NavigationFrame)
            navFrame_renamed = value
        End Set
    End Property
    Public Property getSubjectLayoutItem As LayoutItem
        Get
            Return subjectLayoutItem_renamed
        End Get
        Set(value As LayoutItem)
            subjectLayoutItem_renamed = value
        End Set
    End Property
    Public Property getTopicLayoutItem As LayoutItem
        Get
            Return topicsLayoutItem_renamed
        End Get
        Set(value As LayoutItem)
            topicsLayoutItem_renamed = value
        End Set
    End Property

    Public Property getDescLayoutItem As LayoutItem
        Get
            Return descLayoutItem_renamed
        End Get
        Set(value As LayoutItem)
            descLayoutItem_renamed = value
        End Set
    End Property
#End Region




End Class

