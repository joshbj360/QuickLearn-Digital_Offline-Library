<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HotSpotForm
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HotSpotForm))
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CheckBoxShowPass = New System.Windows.Forms.CheckBox()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TextBoxPass = New DevExpress.XtraEditors.TextEdit()
        Me.TextBoxHostspotname = New DevExpress.XtraEditors.TextEdit()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ButtonSaveNameandPass = New System.Windows.Forms.Button()
        Me.ButtonLoadNameandPass = New System.Windows.Forms.Button()
        Me.ButtonStop = New System.Windows.Forms.Button()
        Me.ButtonStart = New System.Windows.Forms.Button()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.RibbonPage2 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.GroupBox1.SuspendLayout()
        CType(Me.TextBoxPass.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxHostspotname.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal
        Me.LabelControl1.Location = New System.Drawing.Point(39, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(292, 25)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Share Library to your Phone"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckBoxShowPass)
        Me.GroupBox1.Controls.Add(Me.LabelControl2)
        Me.GroupBox1.Controls.Add(Me.LabelControl3)
        Me.GroupBox1.Controls.Add(Me.TextBoxPass)
        Me.GroupBox1.Controls.Add(Me.TextBoxHostspotname)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 57)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(211, 162)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "HotSpot Details"
        '
        'CheckBoxShowPass
        '
        Me.CheckBoxShowPass.AutoSize = True
        Me.CheckBoxShowPass.Location = New System.Drawing.Point(7, 132)
        Me.CheckBoxShowPass.Name = "CheckBoxShowPass"
        Me.CheckBoxShowPass.Size = New System.Drawing.Size(101, 17)
        Me.CheckBoxShowPass.TabIndex = 5
        Me.CheckBoxShowPass.Text = "Show Password"
        Me.CheckBoxShowPass.UseVisualStyleBackColor = True
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(6, 41)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(73, 13)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "HotSpot Name:"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(6, 86)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl3.TabIndex = 4
        Me.LabelControl3.Text = "Password"
        '
        'TextBoxPass
        '
        Me.TextBoxPass.Location = New System.Drawing.Point(6, 105)
        Me.TextBoxPass.Name = "TextBoxPass"
        Me.TextBoxPass.Size = New System.Drawing.Size(167, 20)
        Me.TextBoxPass.TabIndex = 1
        '
        'TextBoxHostspotname
        '
        Me.TextBoxHostspotname.Location = New System.Drawing.Point(6, 59)
        Me.TextBoxHostspotname.Name = "TextBoxHostspotname"
        Me.TextBoxHostspotname.Size = New System.Drawing.Size(167, 20)
        Me.TextBoxHostspotname.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ButtonSaveNameandPass)
        Me.GroupBox2.Controls.Add(Me.ButtonLoadNameandPass)
        Me.GroupBox2.Controls.Add(Me.ButtonStop)
        Me.GroupBox2.Controls.Add(Me.ButtonStart)
        Me.GroupBox2.Location = New System.Drawing.Point(229, 57)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(126, 162)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Controls"
        '
        'ButtonSaveNameandPass
        '
        Me.ButtonSaveNameandPass.Location = New System.Drawing.Point(6, 99)
        Me.ButtonSaveNameandPass.Name = "ButtonSaveNameandPass"
        Me.ButtonSaveNameandPass.Size = New System.Drawing.Size(75, 23)
        Me.ButtonSaveNameandPass.TabIndex = 3
        Me.ButtonSaveNameandPass.Text = "Save"
        Me.ButtonSaveNameandPass.UseVisualStyleBackColor = True
        '
        'ButtonLoadNameandPass
        '
        Me.ButtonLoadNameandPass.Location = New System.Drawing.Point(6, 128)
        Me.ButtonLoadNameandPass.Name = "ButtonLoadNameandPass"
        Me.ButtonLoadNameandPass.Size = New System.Drawing.Size(75, 23)
        Me.ButtonLoadNameandPass.TabIndex = 2
        Me.ButtonLoadNameandPass.Text = "Load Settings"
        Me.ButtonLoadNameandPass.UseVisualStyleBackColor = True
        '
        'ButtonStop
        '
        Me.ButtonStop.Location = New System.Drawing.Point(6, 70)
        Me.ButtonStop.Name = "ButtonStop"
        Me.ButtonStop.Size = New System.Drawing.Size(75, 23)
        Me.ButtonStop.TabIndex = 1
        Me.ButtonStop.Text = "Stop"
        Me.ButtonStop.UseVisualStyleBackColor = True
        '
        'ButtonStart
        '
        Me.ButtonStart.Location = New System.Drawing.Point(6, 41)
        Me.ButtonStart.Name = "ButtonStart"
        Me.ButtonStart.Size = New System.Drawing.Size(75, 23)
        Me.ButtonStart.TabIndex = 0
        Me.ButtonStart.Text = "Start"
        Me.ButtonStart.UseVisualStyleBackColor = True
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'RibbonPage2
        '
        Me.RibbonPage2.Name = "RibbonPage2"
        Me.RibbonPage2.Text = "RibbonPage2"
        '
        'HotSpotForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(366, 226)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.LabelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "HotSpotForm"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Share Library"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.TextBoxPass.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxHostspotname.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBoxHostspotname As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonStop As System.Windows.Forms.Button
    Friend WithEvents ButtonStart As System.Windows.Forms.Button
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextBoxPass As DevExpress.XtraEditors.TextEdit
    Friend WithEvents CheckBoxShowPass As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonLoadNameandPass As System.Windows.Forms.Button
    Friend WithEvents ButtonSaveNameandPass As System.Windows.Forms.Button
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents RibbonPage2 As DevExpress.XtraBars.Ribbon.RibbonPage
End Class
