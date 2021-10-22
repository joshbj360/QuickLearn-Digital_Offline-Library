Public Class HotSpotForm
    Dim ind As Integer = 1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        ButtonStart.Enabled = True
        ButtonStop.Enabled = False
        CheckBoxShowPass.Checked = False

        TextBoxHostspotname.Text = My.Settings.HotspotName
        TextBoxPass.Text = My.Settings.Password

    End Sub



    Private Sub ButtonSaveNameandPass_Click(sender As Object, e As EventArgs) Handles ButtonSaveNameandPass.Click
        If TextBoxHostspotname.Text.Length < 4 Then
            MessageBox.Show("Hotspot name must be 4 Characters or more !", "Error Message")
        ElseIf TextBoxPass.Text.Length < 8 Then
            MessageBox.Show("Password must be 8 Characters or more !", "Error Message")
        ElseIf TextBoxHostspotname.Text.Length > 4 And TextBoxPass.Text.Length > 8 Then
            Dim result As Integer = MessageBox.Show("Are you sure to save Hotspot Name & Password ?", "Notification", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                My.Settings.HotspotName = TextBoxHostspotname.Text
                My.Settings.Password = TextBoxPass.Text
                MessageBox.Show("Hotspot Name & Password has been Saved", "Notification")

                CheckBoxShowPass.Checked = False
            End If
        End If
    End Sub

    Private Sub ButtonLoadNameandPass_Click(sender As Object, e As EventArgs) Handles ButtonLoadNameandPass.Click
        TextBoxHostspotname.Text = My.Settings.HotspotName
        TextBoxPass.Text = My.Settings.Password
        CheckBoxShowPass.Checked = False

    End Sub



    Private Sub ButtonStart_Click(sender As Object, e As EventArgs) Handles ButtonStart.Click
        Try
            Dim process As New Process()
            process.StartInfo.FileName = "cmd.exe"
            process.StartInfo.Verb = "runas"
            process.StartInfo.UseShellExecute = True
            process.StartInfo.Arguments = String.Format("/c {0} & {1} & {2}", "netsh wlan set hostednetwork mode=allow ssid=" & My.Settings.HotspotName & " key=" & My.Settings.Password, "netsh wlan start hostednetwork", "pause")
            Process.Start(process.StartInfo)
            MsgBox("Hotspot started successfully", MsgBoxStyle.Information)
            ButtonStart.Enabled = False
            ButtonStop.Enabled = True
        Catch ex As Exception
            MessageBox.Show("Failed to Start Hotspot", "Error")
        End Try
    End Sub

    Private Sub ButtonStop_Click(sender As Object, e As EventArgs) Handles ButtonStop.Click
        Try
            Dim process As New Process()
            process.StartInfo.FileName = "cmd.exe"
            process.StartInfo.Verb = "runas"
            process.StartInfo.UseShellExecute = True
            process.StartInfo.Arguments = String.Format("/c {0} & {1} & {2}", "netsh wlan set hostednetwork mode=disallow ssid=" & My.Settings.HotspotName & " key=" & My.Settings.Password, "netsh wlan stop hostednetwork", "pause")
            Process.Start(process.StartInfo)
            MsgBox("Hotspot stop successfully", MsgBoxStyle.Information)
            ButtonStart.Enabled = True
            ButtonStop.Enabled = False
        Catch ex As Exception
            MessageBox.Show("Failed to Stop Hotspot", "Error")
        End Try
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            If ind = 1 Then
                'Me.Hide()
                Me.Hide()
                Me.ShowInTaskbar = True
                NotifyIcon1.Visible = True
                e.Cancel = True
                NotifyIcon1.ShowBalloonTip(3000)
            Else
                Me.Show()

                If ButtonStop.Enabled = True Then
                    Dim result As Integer = MessageBox.Show("Hotspot is still alive, continue to exit by turning off hotspot ?", "Notification", MessageBoxButtons.YesNo)
                    If result = DialogResult.Yes Then
                        Try
                            Dim process As New Process()
                            process.StartInfo.FileName = "cmd.exe"
                            process.StartInfo.Verb = "runas"
                            process.StartInfo.UseShellExecute = True
                            process.StartInfo.Arguments = String.Format("/c {0} & {1} & {2}", "netsh wlan set hostednetwork mode=disallow ssid=" & My.Settings.HotspotName & " key=" & My.Settings.Password, "netsh wlan stop hostednetwork", "pause")
                            Process.Start(process.StartInfo)
                            MsgBox("Hotspot stop successfully", MsgBoxStyle.Information)
                            Me.Show()
                            e.Cancel = False
                        Catch ex As Exception
                            MessageBox.Show("Failed to Stop Hotspot", "Error")
                        End Try
                    End If
                End If

                e.Cancel = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.Show()
    End Sub


    'Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
    '    ind = 0
    '    Me.Close()
    'End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ButtonSaveNameandPass.Click

    End Sub
End Class
