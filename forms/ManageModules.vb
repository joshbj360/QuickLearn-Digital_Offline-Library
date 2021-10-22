Imports System.IO
Imports System.Collections
Public Class ManageModules

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GetListOfModules()
        ' ListBoxControl1.DataSource = getListOfFolderSizes

    End Sub
    Public Function GetListOfModules() As List(Of String)

        Dim list_ As New List(Of String)
        Dim list1_ As New List(Of Long)
        For Each folder In Directory.EnumerateDirectories(Get_Drive_Letter + "modules/", "en-*", SearchOption.TopDirectoryOnly)
            list_.Add(folder)
            list1_.Add(GetFolderSize(folder))
        Next
        getListOfFolderSizes = list1_
        Return list_
    End Function
    Private list_size_renamed As List(Of Long)
    Public Property getListOfFolderSizes As List(Of Long)
        Get
            Return list_size_renamed
        End Get
        Set(value As List(Of Long))
            list_size_renamed = value
        End Set
    End Property
    Private Function GetFolderSize(ByVal folder As String, Optional ByVal includeSubFolders As Boolean = False) As Long
        Try
            Dim size As Long = 0
            Dim diBase As New DirectoryInfo(folder)
            Dim files() As FileInfo
            If includeSubFolders Then
                files = diBase.GetFiles("*", SearchOption.AllDirectories)
            Else
                files = diBase.GetFiles("*", SearchOption.TopDirectoryOnly)
            End If
            Dim ie As IEnumerator = files.GetEnumerator
            While ie.MoveNext 'And Not abort
                size += DirectCast(ie.Current, FileInfo).Length
            End While
            Return size
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message)
            Return -1
        End Try
    End Function


End Class
Public Class QLModule
    Public folder_renamed As String
    Public folderSize_renamed As Long

    'Public Sub New()
    '    folder_renamed = String.Format("{0}", "")
    '    folderSize_renamed = 0
    'End Sub
    Public Property ModuleFolder As String
        Get
            Return folder_renamed
        End Get
        Set(value As String)
            folder_renamed = value
        End Set
    End Property

    Public Property ModuleSize As Long
        Get
            Return folderSize_renamed
        End Get
        Set(value As Long)
            folderSize_renamed = value
        End Set
    End Property
End Class
Public Class QLModuleData
    Friend Shared Function QLModules() As List(Of QLModule)
        Dim qlmodules_ As New List(Of QLModule)
        Dim modl As QLModule = New QLModule()
        'Dim Joined = From item1 In ManageModules.GetListOfModules Join item2 In on  item1.I
        For Each folder In ManageModules.GetListOfModules 
            modl.folder_renamed = folder

            qlmodules_.Add(modl)
        Next
      
        Return qlmodules_
    End Function
End Class