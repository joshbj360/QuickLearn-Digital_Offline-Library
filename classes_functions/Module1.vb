Imports System.Management


Module Module1

    Dim vIDs() As String, iv As Int32 = 0
    Dim VID_PID_device As String = "VID_0461&PID_4E22" ' Change to your's 
    Dim bDsp As Boolean = True
    Dim bAttached As Boolean = False
    Public Sub Main()
        Do
            Console.WriteLine("1. List All Devices")
            Console.WriteLine("2. List USB Devices")
            Console.WriteLine("3. Find out the VID and the PID of the mouse.")
            Console.WriteLine("4. Find if Device " + VID_PID_device + " is connected.")
            Console.WriteLine("5. Exit")
            Select Case Console.ReadLine
                Case "1" : ListDevices_VID_PID()
                Case "2" : ListDevices_VID_PID("USB" + Chr(92))
                Case "3"
                    Console.Clear()
                    Console.WriteLine("Press 'Enter' key when the mouse is attached.")
                    Console.ReadLine()
                    bDsp = False
                    iv = 0
                    ListDevices_VID_PID("USB" + Chr(92))
                    Console.WriteLine("Detach the mouse and press 'Enter' key.")
                    Console.ReadLine()
                    ListDevices_VID_PID("USB" + Chr(92))
                    Console.WriteLine("Mouse VID and PID is: " + VID_PID_device)
                    Console.WriteLine("Attach again the mouse and press 'Enter' key.")
                    Console.ReadLine()
                    bAttached = Find_Device_By_VID_PID(VID_PID_device)
                    Console.WriteLine("Now on if you attach/remove it'll be detected. Press any key to exit.")
                    Do
                        Dim nowAttached As Boolean = Find_Device_By_VID_PID(VID_PID_device)
                        If nowAttached <> bAttached Then
                            bAttached = nowAttached
                            If bAttached Then
                                Console.WriteLine("Attached")
                            Else
                                Console.WriteLine("Removed")
                            End If
                        End If
                        System.Threading.Thread.Sleep(500)
                    Loop While Not Console.KeyAvailable
                    bDsp = True
                Case "4"
                    If Find_Device_By_VID_PID(VID_PID_device) Then
                        Console.WriteLine("Connected!")
                    End If
                Case "5" : Exit Do
            End Select
        Loop
    End Sub
    
    
    Public Sub ListDevices_VID_PID(Optional sFilter As String = "")
        Try
            Dim bCompare As Boolean = IIf(iv = 0, False, True)
            Dim info As Management.ManagementObject
            Dim search As System.Management.ManagementObjectSearcher
            Dim Name As String
            search = New System.Management.ManagementObjectSearcher("SELECT * From Win32_PnPEntity")
            For Each info In search.Get()
                Name = CType(info("Caption"), String)
                Dim ID As String = CType(info("DeviceID"), String)
                If sFilter = "" OrElse InStr(ID, sFilter) Then
                    If Not bCompare Then
                        ReDim Preserve vIDs(iv)
                        vIDs(iv) = ID : iv += 1
                    Else
                        Dim pos As Int32 = Array.IndexOf(vIDs, ID)
                        If pos > -1 Then
                            vIDs(pos) = ""
                        End If
                    End If
                    Dim n As String = ""
                    If bDsp Then n = (Name + " " + ID)
                    'get_list_of_devices += n + vbCrLf
                End If
            Next
            For i As Int32 = 0 To vIDs.Length - 1
                If vIDs(i).Length Then
                    VID_PID_device = Split(vIDs(i), "\")(1)
                    Exit For
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    
    Function Find_Device_By_VID_PID(Device_VID_PID As String) As Boolean
        Try
            ' See if the desired device shows up in the device manager. '
            Dim info As Management.ManagementObject
            Dim search As System.Management.ManagementObjectSearcher
            search = New System.Management.ManagementObjectSearcher("SELECT * From Win32_PnPEntity")
            For Each info In search.Get()
                ' Go through each device detected.'
                Dim ID As String = CType(info("DeviceID"), String)
                If InStr(info.Path.ToString, Device_VID_PID) Then
                    Return True
                End If
            Next
        Catch ex As Exception

        End Try
        'We did not find the device we were looking for '
        Return False
    End Function

End Module
