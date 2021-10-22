Public Class video
    Private vid As DataRow
    Private PID_renamed, sort_order_renamed As Integer
    Private pk_renamed, available_renamed, parent_id_renamed, files_complete_renamed, total_files_renamed, size_on_disk_renamed, remote_size_renamed As String
    Private title_renamed, description_renamed, kind_renamed, id_renamed, slug_renamed, path_renamed, extrafields_renamed, youtube_id_renamed As String
    Public Sub New(ByVal vid As DataRow)
        Me.vid = vid
        PID_renamed = CInt(vid("ID1"))
        pk_renamed = String.Format("{0}", vid("pk"))
        title_renamed = String.Format("{0}", vid("title"))
        description_renamed = String.Format("{0}", vid("description"))
        available_renamed = String.Format("{0}", vid("available"))
        files_complete_renamed = String.Format("{0}", vid("files_complete"))
        total_files_renamed = String.Format("{0}", vid("total_files"))
        kind_renamed = String.Format("{0}", "video")
        parent_id_renamed = String.Format("{0}", vid("parent_id"))
        id_renamed = String.Format("{0}", vid("id"))
        slug_renamed = String.Format("{0}", vid("slug"))
        path_renamed = String.Format("{0}", vid("path"))
        extrafields_renamed = String.Format("{0}", vid("extra_fields"))
        youtube_id_renamed = String.Format("{0}", vid("youtube_id"))
        size_on_disk_renamed = String.Format("{0}", vid("size_on_disk"))
        remote_size_renamed = String.Format("{0}", vid("remote_size"))
        sort_order_renamed = CInt(vid("sort_order"))

    End Sub
    Public ReadOnly Property PID As Integer
        Get
            Return PID_renamed
        End Get
    End Property

    Public ReadOnly Property pk As String
        Get
            Return pk_renamed
        End Get
    End Property
    Public ReadOnly Property title As String
        Get
            Return title_renamed
        End Get
    End Property
    Public ReadOnly Property description As String
        Get
            Return description_renamed
        End Get
    End Property
    Public ReadOnly Property available As String
        Get
            Return available_renamed
        End Get
    End Property
    Public ReadOnly Property files_complete As String
        Get
            Return files_complete_renamed
        End Get
    End Property
    Public ReadOnly Property total_files As String
        Get
            Return total_files_renamed
        End Get
    End Property
    Public ReadOnly Property kind As String
        Get
            Return kind_renamed
        End Get
    End Property
    Public ReadOnly Property parent_id As String
        Get
            Return parent_id_renamed
        End Get
    End Property
    Public ReadOnly Property id As String
        Get
            Return id_renamed
        End Get
    End Property
    Public ReadOnly Property slug As String
        Get
            Return slug_renamed
        End Get
    End Property
    Public ReadOnly Property path As String
        Get
            Return path_renamed
        End Get
    End Property
    Public ReadOnly Property extra_fields As String
        Get
            Return extrafields_renamed
        End Get
    End Property
    Public ReadOnly Property youtube_id As String
        Get
            Return youtube_id_renamed
        End Get
    End Property
    Public ReadOnly Property sort_order As Integer
        Get
            Return sort_order_renamed
        End Get
    End Property

End Class
Public Class getVideoData
    Friend Shared Function GetDbVideos() As List(Of video)
        Dim ret As New List(Of video)
        Dim ds As New KA_dbDataSet
        ds.Clear()
        Dim table As KA_dbDataSet.videosDataTable = ds.videos
        Dim oleAdpt As New KA_dbDataSetTableAdapters.videosTableAdapter
        oleAdpt.Fill(table)
        For Each row As KA_dbDataSet.videosRow In table.Rows
            ret.Add(New video(row))
        Next row
        Return ret
    End Function
End Class
