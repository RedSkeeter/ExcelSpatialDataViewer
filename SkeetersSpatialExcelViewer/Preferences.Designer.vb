<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Preferences
    Inherits System.Windows.Forms.Form

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
        Me.PreferencesPropertyGrid = New System.Windows.Forms.PropertyGrid()
        Me.SuspendLayout()
        '
        'PreferencesPropertyGrid
        '
        Me.PreferencesPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PreferencesPropertyGrid.Location = New System.Drawing.Point(0, 0)
        Me.PreferencesPropertyGrid.Name = "PreferencesPropertyGrid"
        Me.PreferencesPropertyGrid.Size = New System.Drawing.Size(845, 182)
        Me.PreferencesPropertyGrid.TabIndex = 0
        '
        'Preferences
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(845, 182)
        Me.Controls.Add(Me.PreferencesPropertyGrid)
        Me.Name = "Preferences"
        Me.Text = "Preferences"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PreferencesPropertyGrid As System.Windows.Forms.PropertyGrid
End Class
