Imports System.Data.OleDb
Imports System.Management
Imports System.IO
Imports System
Module app_functions
    Private con As OleDbConnection
    Public Sub conn()

        Try

            con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\data\database\db.accdb")

            con.Open()

        Catch ex As Exception

        End Try
    End Sub
    Public ReadOnly Property QLCaption As String
        Get
            Return "QuickLearn Digital Library."
        End Get
    End Property

    'get driveInstance Message
    Private _driveMessage As String
    Public Property GetDriveMessage As String
        Get
            Return _driveMessage
        End Get
        Set(value As String)
            _driveMessage = value
        End Set
    End Property
    'get drive letter
    Private drive_leter_renamed As String
    Public Property Get_Drive_Letter As String
        Get
            Return drive_leter_renamed
        End Get
        Set(value As String)
            drive_leter_renamed = value
        End Set
    End Property

    'a public list of drives
    Private Property _drives As List(Of Drive)
    Public Property get_list_of_drives As List(Of Drive)
        Get
            Return _drives
        End Get
        Set(value As List(Of Drive))
            _drives = value
        End Set
    End Property


#Region "AlertForm"

    Private alertForm1 As New DevExpress.XtraBars.Alerter.AlertControl
    Public Sub alertDlog(ByVal Form As System.Windows.Forms.Form, Optional ByVal Caption As String = "", Optional ByVal text As String = "")
        With alertForm1
            .FormLocation = DevExpress.XtraBars.Alerter.AlertFormLocation.BottomRight
            .AutoFormDelay = 2000
            .AutoHeight = True
            .FormDisplaySpeed = DevExpress.XtraBars.Alerter.AlertFormDisplaySpeed.Moderate
            .ShowPinButton = False
            .FormShowingEffect = DevExpress.XtraBars.Alerter.AlertFormShowingEffect.FadeIn
            .AppearanceCaption.Font = New Drawing.Font("Tahoma", 12, FontStyle.Bold)
            .AppearanceCaption.Options.UseTextOptions = True
            .AppearanceText.Font = New Drawing.Font("Tahoma", 10, FontStyle.Bold)
            .Show(Form, Caption, text)

        End With
    End Sub
#End Region
End Module


Public Class Drive
    'This class defines the drive, and it's propertise
    Private DriveName_renamed, DriveFileType_renamed, drivesize_renamed, drivefullpath_renamed As String

    'initializes the propertise required by the parameters
    Public Sub New(ByVal _d_name As String, ByVal _d_type As String, ByVal _d_fullpath As String)
        DriveName_renamed = _d_name
        DriveFileType_renamed = _d_type
        drivefullpath_renamed = _d_fullpath
        'drivesize_renamed = _d_size
    End Sub

    'name property
    Public Property DriveName As String
        Get
            Return DriveName_renamed
        End Get
        Set(value As String)
            DriveName_renamed = value
        End Set
    End Property

    'drive type property
    Public Property DriveFileType As String
        Get
            Return DriveFileType_renamed
        End Get
        Set(value As String)
            DriveFileType_renamed = value
        End Set
    End Property

    'drive size property
    Public Property DriveSize As String
        Get
            Return DriveFileType_renamed
        End Get
        Set(value As String)
            DriveFileType_renamed = value
        End Set
    End Property

    'drive fullpath property
    Public Property DriveFullpath As String
        Get
            Return drivefullpath_renamed
        End Get
        Set(value As String)
            drivefullpath_renamed = value
        End Set
    End Property

    'Private Sub LabelText()
    '    If InvokeRequired Then
    '        Invoke(New LabelTextDelegate(AddressOf LabelText))
    '    Else
    '        lbl_detection.Text = LblText
    '        If DriveLetter <> "" Then
    '            Dim FilesFound() As String = My.Computer.FileSystem.GetFiles(DriveLetter & "\",
    '                    Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, "start_mgr.Txt").ToArray

    '            If FilesFound.Count > 0 Then
    '                'MemoEdit1.Text = My.Computer.FileSystem.ReadAllText(FilesFound(0))
    '                lbl_insertion.Text = FilesFound(0) & " is being displayed in the RichTextBox"
    '                lbl_insertion.BackColor = Color.Lime
    '            Else
    '                'MemoEdit1.Text = ""
    '                lbl_insertion.Text = DriveLetter & " does not contain star_mgr.Txt"
    '                lbl_insertion.BackColor = Color.OrangeRed
    '            End If
    '        Else
    '            lbl_insertion.Text = "Waiting for USB insertion"
    '            lbl_insertion.BackColor = Color.White
    '        End If
    '    End If
    'End Sub
End Class
