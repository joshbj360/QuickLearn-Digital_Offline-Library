Imports DevExpress.XtraBars.Navigation
Imports DevExpress.XtraEditors
Imports DevExpress.XtraNavBar
Imports System.Globalization

Module KA_Helpers
#Region "Containers"

    'container for media_player_control
    Private media_player_ As media_player_control
    Public Property getMediaPlayerControl As media_player_control
        Get
            Return media_player_
        End Get
        Set(value As media_player_control)
            media_player_ = value
        End Set
    End Property


    'get the textName of a clickedTile
    Private tileName_renamed, videoName_renamed, vidTileName_renamed As String
    Private pathLevel_renamed As Integer
    Private rnd As New Random
    Private playing_vid_renamed As video
    Public Property GetCurrentPlayingVid As video
        Get
            Return playing_vid_renamed
        End Get
        Set(value As video)
            playing_vid_renamed = value
        End Set
    End Property
    Public Property navTileNamePROP As String
        Get
            Return tileName_renamed
        End Get
        Set(value As String)
            tileName_renamed = value
        End Set
    End Property
    Public Property PathLevelPROP As Integer
        Get
            Return pathLevel_renamed
        End Get
        Set(value As Integer)
            pathLevel_renamed = value
        End Set
    End Property
    Public Property VideoNamePROP As String
        Get
            Return videoName_renamed
        End Get
        Set(value As String)
            videoName_renamed = value
        End Set
    End Property
    Private PrevNextDescription_renamed As String
    Public Property PrevNextDescription As String
        Get
            Return PrevNextDescription_renamed
        End Get
        Set(value As String)
            PrevNextDescription_renamed = value
        End Set
    End Property

    Public Property videoTileNameProp As String
        Get
            Return vidTileName_renamed
        End Get
        Set(value As String)
            vidTileName_renamed = value
        End Set
    End Property

    'current getTopicBySlash for PathLevel = 2
    Private _getTopicBySlash2 As List(Of String)
    Public Property getCurrentTopicBySlash_2 As List(Of String)
        Get
            Return _getTopicBySlash2
        End Get
        Set(value As List(Of String))
            _getTopicBySlash2 = value
        End Set

    End Property

    Private CurrentPlayList_renamed As List(Of String)
    Public Property getCurrentPlayList As List(Of String)
        Get
            Return CurrentPlayList_renamed
        End Get
        Set(value As List(Of String))
            CurrentPlayList_renamed = value
        End Set
    End Property

    'container for url
    Private url_renamed As String
    Public Property getUrl As String
        Get
            Return url_renamed
        End Get
        Set(value As String)
            url_renamed = value
        End Set
    End Property


    Private renamed As String
    Public Property getCount As String
        Get
            Return renamed
        End Get
        Set(value As String)
            renamed = value
        End Set
    End Property


    'container for webBrowser
    Private webBroweser_renamed As CefSharp.WinForms.ChromiumWebBrowser
    Public Property webBrowserPropty() As CefSharp.WinForms.ChromiumWebBrowser
        Get

            Return webBroweser_renamed
        End Get
        Set(value As CefSharp.WinForms.ChromiumWebBrowser)
            webBroweser_renamed = value
        End Set
    End Property

    Private tf_renamed As Boolean
    Public Property TrueFlase As Boolean
        Get
            Return tf_renamed
        End Get
        Set(value As Boolean)
            tf_renamed = value
        End Set
    End Property
#End Region

#Region "Methods and Functions"
    'To convert Any string to Title Case
    Public Function ToTitleCase(input As String) As String
        Return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input)
    End Function
    'Create Khan tiles at the main menu
    'Public Sub CreateKhanTiles(ByVal tileGroup As TileGroup)
    '    Dim tilenames As List(Of String) = getTopicBySlash(getListOfPath, 1).Distinct.ToList
    '    For Each tilename In tilenames
    '        Dim tile As New TileItem
    '        Dim element As New TileItemElement
    '        tile.ItemSize = TileItemSize.Wide
    '        tile.AppearanceItem.Normal.Font = New Font("Segoe UI Light", 13, FontStyle.Bold)
    '        tile.AppearanceItem.Normal.BackColor = Color.FromArgb(228, rnd.Next(0), rnd.Next(0), rnd.Next(50))
    '        tile.AppearanceItem.Normal.BorderColor = Color.FromArgb(0, 175, 240) 'Color.FromArgb(228, rnd.Next(0), rnd.Next(0), rnd.Next(50))
    '        tile.Name = tilename
    '        element.Text = ToTitleCase(tilename).Replace("-", " ")
    '        element.TextAlignment = TileItemContentAlignment.MiddleCenter
    '        tile.Elements.Add(element)
    '        tileGroup.Items.Add(tile)
    '    Next
    'End Sub


    Public Sub createVideoTiles(ByVal tilegroup As TileGroup, ByVal itemName As String, Optional ByVal itemCaption As String = "Loading module")
        Dim dlg As New DevExpress.Utils.WaitDialogForm
        dlg.Caption = "Loading " + itemCaption + " module"

        Dim superToolTip As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip
        Dim superToolTipInfo As DevExpress.Utils.SuperToolTipSetupArgs = New DevExpress.Utils.SuperToolTipSetupArgs


        Dim tileNames As New List(Of String)

        tilegroup.Items.Clear()


        tileNames = getTopicBySlash(getQueriedList(getListOfPath, itemName), 5).Distinct.ToList()
        getCurrentPlayList = Nothing
        getCurrentPlayList = tileNames
        For Each tileVideoName In tileNames
            Dim tileV As New TileItem
            tileV.Name = tileVideoName

            tileV.AppearanceItem.Normal.BackColor = getRandomRGBColor()
            'tileV.AppearanceItem.Normal.BackColor2 = Color.Violet
            tileV.AppearanceItem.Normal.BorderColor = getRandomRGBColor()
            tileV.AppearanceItem.Normal.ForeColor = TileForeColor
            ' tileV.TextAlignment = TileItemContentAlignment.MiddleCenter
            'tileV.AppearanceItem.Normal.Font = New Font("Segoe UI Light", 10.8)
            Dim tileElement As New TileItemElement
            tileElement.Text = ToTitleCase(tileVideoName).Replace("-", " ")
            tileElement.TextAlignment = TileItemContentAlignment.MiddleCenter
            tileV.Elements.Add(tileElement)

            '' Tile Item super Tool Tip
            'superToolTipInfo.Title.Text = getVideo(tileVideoName).title
            'superToolTipInfo.Contents.Text = getVideo(tileVideoName).description
            'superToolTip.Setup(superToolTipInfo)


            tilegroup.Items.Add(tileV)
        Next
        dlg.Dispose()
    End Sub

    'create subject tiles, in TileBar  and assign each subject in tilenames to each tile.
    Public Sub createTiles(ByVal tileBarGroup As TileBarGroup, ByVal tilename As String)
        Dim rnd As New Random
        Dim tileNames As New List(Of String)

        tileNames = getTopicBySlash(getQueriedList(getListOfPath, navTileNamePROP), PathLevelPROP).Distinct.ToList
        getCurrentTopicBySlash_2 = Nothing
        getCurrentTopicBySlash_2 = tileNames

        For Each tilename In tileNames
            Dim tile As New TileBarItem

            tile.Name = tilename
            tile.AppearanceItem.Normal.BackColor = getRandomRGBColor()
            '  tile.AppearanceItem.Normal.BackColor2 = Color.Violet
            tile.AppearanceItem.Normal.ForeColor = TileForeColor
            Dim tileItemElement As New DevExpress.XtraEditors.TileItemElement

            tileItemElement.Text = ToTitleCase(tilename).Replace("-", " ")
            If tilename = "organic-che-mistry" Then
                tileItemElement.Text = "Organic Chemistry"
            End If
            If tilename = "computer-sci-ence" Then
                tileItemElement.Text = "Computer Science"
            End If
            tileItemElement.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
            tileItemElement.Appearance.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
            tileItemElement.Appearance.Normal.Font = New Font("Segoe UI Light", 12, FontStyle.Bold)
            tile.Elements.Add(tileItemElement)
            tile.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
            tileBarGroup.Items.Add(tile)
        Next
        'getCurrentTopicBySlash_2 = tileNames
        'tileNames.Clear()
        'getListOfPath.Clear()
    End Sub

    'create sub subjects queried by the subject tileName
    Public Sub loadModule(ByVal navBar As NavBarControl, ByVal navBarGroup As NavBarGroup, ByVal str As String)

        navBarGroup.Caption = ToTitleCase(str).Replace("-", " ") 'e.Item.Elements(0).Text
        Dim navbaritems As New List(Of String)
        navBarGroup.ItemLinks.Clear()
        navbaritems = getTopicBySlash(getQueriedList(getListOfPath, str), 3).Distinct.ToList
        For Each navbarItemName In navbaritems
            Dim navitem As New NavBarItem
            navitem.Name = navbarItemName
            navitem.Caption = ToTitleCase(navbarItemName.Replace("-", " "))
            navBar.BeginUpdate()
            navBarGroup.ItemLinks.Add(navitem)
            navBarGroup.Expanded = True
            navBar.EndUpdate()
        Next

    End Sub
    'get video by filter string
    Public Function getVideo(ByVal filterString As String) As video
        Dim vid As video = getVideoData.GetDbVideos.FirstOrDefault(Function(x) x.path.Contains(filterString))
        Return vid
    End Function

    'get video by filter string from youtube ID
    Public Function getVideoFromYoutubeID(ByVal filterString As String) As video
        Dim vid As video = getVideoData.GetDbVideos.FirstOrDefault(Function(x) x.youtube_id = filterString)
        Return vid
    End Function

    'Converts the list of videonames(in string) to list of videos
    ''Public Function getCurrentVideoPlayList() As List(Of video)

    ''    Dim VideoPlayList As New List(Of video)
    ''    For Each vidName In getCurrentPlayList
    ''        VideoPlayList.Add(getVideo(vidName))
    ''    Next

    ''    Return VideoPlayList
    ''End Function

    'Get list of topics from the video path, after each 'slash' character
    Public Function getTopicBySlash(ByVal listToQuery As List(Of String), ByVal slashIndex As Integer) As List(Of String)
        Dim videos As List(Of video) = getVideoData.GetDbVideos
        Dim slashedTopics As New List(Of String)
        For Each video In listToQuery
            'Dim vidPath As String = video.path
            If video.Contains("/"c) Then
                video = video.Split("/"c)(slashIndex)
            End If
            slashedTopics.Add(video)
        Next
        Return slashedTopics
    End Function
    'return a list of list after queried by filter string
    Public Function getQueriedList(ByVal targetList As List(Of String), ByVal filterString As String) As List(Of String)
        Dim resultList = From resultValues In targetList Where (resultValues.Contains(filterString)) Select resultValues
        Return resultList.ToList()
    End Function


    'get the sorted list of path, based on the sort_order field
    Public Function getListOfPath() As List(Of String)
        Dim paths As New List(Of String)
        Dim videos As List(Of video) = getVideoData.GetDbVideos

        For Each video In videos.OrderBy(Function(x) x.sort_order)
            paths.Add(video.path)
        Next
        Return paths
    End Function



#End Region
#Region "Generate Random Colors"  'generate random colors from inputed range.
    Private m_rnd As New Random
    Public Function getRandomRGBColor() As Color
        If r2_p > 255 Then
            r2_p = 255
        End If
        If g2_p > 255 Then
            g2_p = 255
        End If
        If b2_p > 255 Then
            b2_p = 255
        End If
        Return Color.FromArgb(a_p, _
                              m_rnd.Next(r1_p, r2_p), _
                              m_rnd.Next(g1_p, g2_p), _
                              m_rnd.Next(b1_p, b2_p))
    End Function

    Private A_renamed, r1_renamed, r2_renamed, g1_renamed, g2_renamed, b1_renamed, b2_renamed As Integer
    Private color_ As Color
    Public Property TileForeColor As Color
        Get
            Return color_
        End Get
        Set(value As Color)
            color_ = value
        End Set
    End Property
    Public Property a_p As Integer
        Get
            Return A_renamed
        End Get
        Set(value As Integer)
            A_renamed = value
        End Set
    End Property
    Public Property r1_p As Integer
        Get
            Return r1_renamed
        End Get
        Set(value As Integer)
            r1_renamed = value
        End Set
    End Property
    Public Property r2_p As Integer
        Get
            Return r2_renamed
        End Get
        Set(value As Integer)
            r2_renamed = value
        End Set
    End Property
    Public Property g1_p As Integer
        Get
            Return g1_renamed
        End Get
        Set(value As Integer)
            g1_renamed = value
        End Set
    End Property
    Public Property g2_p As Integer
        Get
            Return g2_renamed
        End Get
        Set(value As Integer)
            g2_renamed = value
        End Set
    End Property
    Public Property b1_p As Integer
        Get
            Return b1_renamed
        End Get
        Set(value As Integer)
            b1_renamed = value
        End Set
    End Property
    Public Property b2_p As Integer
        Get
            Return b2_renamed
        End Get
        Set(value As Integer)
            b2_renamed = value
        End Set
    End Property
#End Region

End Module
