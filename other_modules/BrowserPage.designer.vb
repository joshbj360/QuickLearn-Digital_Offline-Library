<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BrowserPage
    Inherits DevExpress.XtraEditors.XtraUserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.NavigationFrame1 = New DevExpress.XtraBars.Navigation.NavigationFrame()
        Me.NavigationPage1 = New DevExpress.XtraBars.Navigation.NavigationPage()
        Me.NavigationPage2 = New DevExpress.XtraBars.Navigation.NavigationPage()
        CType(Me.NavigationFrame1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NavigationFrame1.SuspendLayout()
        Me.SuspendLayout()
        '
        'NavigationFrame1
        '
        Me.NavigationFrame1.Controls.Add(Me.NavigationPage1)
        Me.NavigationFrame1.Controls.Add(Me.NavigationPage2)
        Me.NavigationFrame1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NavigationFrame1.Location = New System.Drawing.Point(0, 0)
        Me.NavigationFrame1.Name = "NavigationFrame1"
        Me.NavigationFrame1.Pages.AddRange(New DevExpress.XtraBars.Navigation.NavigationPageBase() {Me.NavigationPage1, Me.NavigationPage2})
        Me.NavigationFrame1.SelectedPage = Me.NavigationPage1
        Me.NavigationFrame1.Size = New System.Drawing.Size(852, 495)
        Me.NavigationFrame1.TabIndex = 0
        Me.NavigationFrame1.Text = "NavigationFrame1"
        '
        'NavigationPage1
        '
        Me.NavigationPage1.Name = "NavigationPage1"
        Me.NavigationPage1.Size = New System.Drawing.Size(852, 495)
        '
        'NavigationPage2
        '
        Me.NavigationPage2.Caption = "NavigationPage2"
        Me.NavigationPage2.Name = "NavigationPage2"
        Me.NavigationPage2.Size = New System.Drawing.Size(852, 495)
        '
        'BrowserPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.NavigationFrame1)
        Me.Name = "BrowserPage"
        Me.Size = New System.Drawing.Size(852, 495)
        CType(Me.NavigationFrame1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NavigationFrame1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Public Shared WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents NavigationFrame1 As DevExpress.XtraBars.Navigation.NavigationFrame
    Friend WithEvents NavigationPage1 As DevExpress.XtraBars.Navigation.NavigationPage
    Friend WithEvents NavigationPage2 As DevExpress.XtraBars.Navigation.NavigationPage
End Class
