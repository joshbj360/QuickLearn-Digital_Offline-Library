Public Class Topic

    Private vid As DataRow
    Private pk_renamed, available_renamed, parent_id_renamed, files_complete_renamed, total_files_renamed, size_on_disk_renamed, remote_size_renamed, sort_order_renamed As Integer
    Private title_renamed, description_renamed, kind_renamed, id_renamed, slug_renamed, path_renamed, extrafields_renamed, youtube_id_renamed As String
    Public Sub New(ByVal vid As DataRow)
        Me.vid = vid
        pk_renamed = String.Format("{0}", vid("pk"))
        title_renamed = String.Format("{0}", vid("title"))
        description_renamed = String.Format("{0}", vid("description"))
        available_renamed = vid("available")
        files_complete_renamed = vid("files_complete")
        total_files_renamed = vid("total_files")
        kind_renamed = String.Format("{0}", "topic")
        parent_id_renamed = vid("parent_id")
        id_renamed = String.Format("{0}", vid("id"))
        slug_renamed = String.Format("{0}", vid("slug"))
        path_renamed = String.Format("{0}", vid("path"))
        extrafields_renamed = String.Format("{0}", vid("extra_fields"))
        youtube_id_renamed = String.Format("{0}", vid("youtube_id"))
        size_on_disk_renamed = String.Format("{0}", vid("size_on_disk"))
        remote_size_renamed = String.Format("{0}", vid("remote_size"))
        sort_order_renamed = String.Format("{0}", vid("sort_order"))

    End Sub
    Public ReadOnly Property pk
        Get
            Return pk_renamed
        End Get
    End Property
    Public ReadOnly Property title
        Get
            Return title_renamed
        End Get
    End Property
    Public ReadOnly Property description
        Get
            Return description_renamed
        End Get
    End Property
    Public ReadOnly Property available
        Get
            Return available_renamed
        End Get
    End Property
    Public ReadOnly Property files_complete
        Get
            Return files_complete_renamed
        End Get
    End Property
    Public ReadOnly Property total_files
        Get
            Return total_files_renamed
        End Get
    End Property
    Public ReadOnly Property kind
        Get
            Return kind_renamed
        End Get
    End Property
    Public ReadOnly Property parent_id
        Get
            Return parent_id_renamed
        End Get
    End Property
    Public ReadOnly Property id
        Get
            Return id_renamed
        End Get
    End Property
    Public ReadOnly Property slug
        Get
            Return slug_renamed
        End Get
    End Property
    Public ReadOnly Property path
        Get
            Return path_renamed
        End Get
    End Property
    Public ReadOnly Property extra_fields
        Get
            Return extrafields_renamed
        End Get
    End Property
    Public ReadOnly Property youtube_id
        Get
            Return youtube_id_renamed
        End Get
    End Property

End Class
Public Class getTopicData
    Friend Shared Function GetDbVideos() As List(Of Topic)
        Dim ret As New List(Of Topic)()
        Dim ds As New KA_dbDataSet
        ds.Clear()
        Dim table As KA_dbDataSet.topicsDataTable = ds.topics
        Dim oleAdpt As New KA_dbDataSetTableAdapters.topicsTableAdapter
        oleAdpt.Fill(table)
        For Each row As KA_dbDataSet.topicsRow In table.Rows
            ret.Add(New Topic(row))
        Next row
        Return ret
    End Function
End Class

