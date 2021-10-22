Imports System.Management
Imports System.IO
Imports System.ComponentModel

Public Class SplashScreen
    Sub New()
        InitializeComponent()
        labelControl1.Text = "Copyright © 2018 - " + Today.Year.ToString

    End Sub

    Public Overrides Sub ProcessCommand(ByVal cmd As System.Enum, ByVal arg As Object)
        MyBase.ProcessCommand(cmd, arg)
    End Sub

    Public Enum SplashScreenCommand
        SomeCommandId
    End Enum
    Private WithEvents m_MediaConnectWatcher As ManagementEventWatcher

    Private Sub SplashScreen_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        MsgBox(e.CloseReason.ToString)
    End Sub


    Private Sub SplashScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(CInt((Screen.PrimaryScreen.WorkingArea.Width / 2) - (Me.Width / 2)), CInt((Screen.PrimaryScreen.WorkingArea.Height / 2) - (Me.Height / 2)))
        lbl_detection.Text = "Waiting for USB detection"
        'lbl_insertion.Text = ""
        'ListDevices_VID_PID("USB\")
        StartDetection()

        Check_All_Drive_Names_and_Types()
        Get_Drive_Letter_from_USBdrives()
    End Sub
    Public Sub StartDetection()
        ' __InstanceOperationEvent will trap both Creation and Deletion of class instances
        Dim query2 As New WqlEventQuery("SELECT * FROM __InstanceOperationEvent WITHIN 1 " & "WHERE TargetInstance ISA 'Win32_DiskDrive'")
        m_MediaConnectWatcher = New ManagementEventWatcher
        m_MediaConnectWatcher.Query = query2
        m_MediaConnectWatcher.Start()
    End Sub
    Dim LblText As String = ""
    Dim lbl_text As String = ""
    Dim DriveLetter As String = ""
    Dim mbo, obj As ManagementBaseObject
    Private Sub Arrived(ByVal sender As Object, ByVal e As System.Management.EventArrivedEventArgs) Handles m_MediaConnectWatcher.EventArrived

        ' the first thing we have to do is figure out if this is a creation or deletion event
        mbo = CType(e.NewEvent, ManagementBaseObject)
        ' next we need a copy of the instance that was either created or deleted
        obj = CType(mbo("TargetInstance"), ManagementBaseObject)
        Select Case mbo.ClassPath.ClassName
            Case "__InstanceCreationEvent"
                If obj("InterfaceType").ToString = "USB" Then
                    LblText = (obj("Caption").ToString & " (Drive letter " & GetDriveLetterFromDisk(obj("Name").ToString) & ") has been plugged in")
                    DriveLetter = GetDriveLetterFromDisk(obj("Name").ToString)

                Else
                    LblText = (obj("InterfaceType").ToString)
                End If
            Case "__InstanceDeletionEvent"
                If obj("InterfaceType").ToString = "USB" Then
                    LblText = obj("Caption").ToString & " has been unplugged"
                    DriveLetter = ""
                Else
                    LblText = obj("InterfaceType").ToString
                End If
            Case Else
                LblText = "nope: " & obj("Caption").ToString
        End Select
        Invoke(New LabelTextDelegate(AddressOf LabelText))
        
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

    Private Delegate Sub LabelTextDelegate()

    Private Sub LabelText()
        If InvokeRequired Then
            Invoke(New LabelTextDelegate(AddressOf LabelText))
        Else
            lbl_detection.Text = LblText
            If DriveLetter <> "" Then
                Dim FilesFound() As String = My.Computer.FileSystem.GetFiles(DriveLetter & "\",
                        Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, "startmgr.Txt").ToArray

                If FilesFound.Count > 0 Then
                    'MemoEdit1.Text = My.Computer.FileSystem.ReadAllText(FilesFound(0))
                    lbl_detection.Text = "QuickLearn Drive Detected"
                    MainForm()
                Else
                    'MemoEdit1.Text = ""
                    lbl_detection.Text = DriveLetter & " is not Quicklearn Drive"

                End If
            Else
                lbl_detection.Text = "Waiting for USB insertion"

            End If
        End If
    End Sub
    'Get all the list of drives and types already plugged to the computer and store it to a new list of drives
    Public Sub Check_All_Drive_Names_and_Types()
        Dim drives As List(Of Drive) = New List(Of Drive)
        Dim allDrives() As DriveInfo = DriveInfo.GetDrives()
        Dim d As DriveInfo

        For Each d In allDrives
            drives.Add(New Drive(d.Name, d.DriveType.ToString, d.RootDirectory.ToString))
        Next

        get_list_of_drives = drives
    End Sub

    'From the list of the drives, get all USB-removable drives, and return their drive letter
    Private Function Get_only_USB_drives() As List(Of String)
        Dim USB_drives As List(Of String) = New List(Of String)
        For Each drive In get_list_of_drives
            If drive.DriveFileType.ToLower.Contains("removable") Then
                USB_drives.Add(drive.DriveName)
            End If
        Next
        Return USB_drives
    End Function

    'From the list of USB drives plugged, look or startmgr.txt, and return drive letter as string
    Private Sub Get_Drive_Letter_from_USBdrives()
        Get_Drive_Letter = Nothing
        For Each USB_drive In Get_only_USB_drives()
            Dim FilesFound() As String = My.Computer.FileSystem.GetFiles(USB_drive.Trim,
                                       Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, "startmgr.txt").ToArray
            If FilesFound.Count > 0 Then
                Get_Drive_Letter = USB_drive
                lbl_detection.Text = "QuickLearn Drive Detected"
                MainForm()
                Exit For
            Else
                lbl_detection.Text = "Waiting for USB insertion"
            End If
        Next
    End Sub
   

    Private Sub MainForm()
        Dim mainForm As New MainForm
        ' mainForm.TopMost = True
        mainForm.Show()
        Hide()
    End Sub
    'get fullpath of selectected drive
    Private Function get_selected_Drive_path(ByVal usb_drive As String) As String
        Dim path As String = ""
        For Each drive In get_list_of_drives
            If drive.DriveName = usb_drive Then
                path = drive.DriveFullpath
            End If
        Next
        Return path
    End Function


End Class
