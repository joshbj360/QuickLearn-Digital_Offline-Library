<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class media_player_control
    Inherits DevExpress.XtraEditors.XtraUserControl

    'UserControl overrides dispose to clean up the component list.
    '<System.Diagnostics.DebuggerNonUserCode()> _
    'Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    '    If disposing AndAlso components IsNot Nothing Then
    '        components.Dispose()
    '    End If
    '    MyBase.Dispose(disposing)
    'End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.PlayerDisplayPanel = New DevExpress.XtraEditors.PanelControl()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.DescriptionLbl = New DevExpress.XtraLayout.SimpleLabelItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.PlayerDisplayPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DescriptionLbl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.PlayerDisplayPanel)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(617, 137, 650, 400)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(592, 386)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'PlayerDisplayPanel
        '
        Me.PlayerDisplayPanel.Location = New System.Drawing.Point(2, 27)
        Me.PlayerDisplayPanel.Name = "PlayerDisplayPanel"
        Me.PlayerDisplayPanel.Size = New System.Drawing.Size(588, 357)
        Me.PlayerDisplayPanel.TabIndex = 8
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.DescriptionLbl})
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(592, 386)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.PlayerDisplayPanel
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 25)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(592, 361)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'DescriptionLbl
        '
        Me.DescriptionLbl.AllowHotTrack = False
        Me.DescriptionLbl.AppearanceItemCaption.Font = New System.Drawing.Font("Segoe Print", 9.0!)
        Me.DescriptionLbl.AppearanceItemCaption.ForeColor = System.Drawing.Color.DimGray
        Me.DescriptionLbl.AppearanceItemCaption.Options.UseFont = True
        Me.DescriptionLbl.AppearanceItemCaption.Options.UseForeColor = True
        Me.DescriptionLbl.Location = New System.Drawing.Point(0, 0)
        Me.DescriptionLbl.Name = "DescriptionLbl"
        Me.DescriptionLbl.Size = New System.Drawing.Size(592, 25)
        Me.DescriptionLbl.TextSize = New System.Drawing.Size(118, 21)
        '
        'media_player_control
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "media_player_control"
        Me.Size = New System.Drawing.Size(592, 386)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.PlayerDisplayPanel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DescriptionLbl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents PlayerDisplayPanel As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents DescriptionLbl As DevExpress.XtraLayout.SimpleLabelItem

End Class
