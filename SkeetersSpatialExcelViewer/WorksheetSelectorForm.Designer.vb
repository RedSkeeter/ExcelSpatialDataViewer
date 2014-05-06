<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WorksheetSelectorForm
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
        Me.WorksheetsComboBox = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DoneButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'WorksheetsComboBox
        '
        Me.WorksheetsComboBox.FormattingEnabled = True
        Me.WorksheetsComboBox.Location = New System.Drawing.Point(12, 29)
        Me.WorksheetsComboBox.Name = "WorksheetsComboBox"
        Me.WorksheetsComboBox.Size = New System.Drawing.Size(226, 21)
        Me.WorksheetsComboBox.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(229, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Select the worksheet you would like to access:"
        '
        'DoneButton
        '
        Me.DoneButton.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.DoneButton.Location = New System.Drawing.Point(165, 56)
        Me.DoneButton.Name = "DoneButton"
        Me.DoneButton.Size = New System.Drawing.Size(75, 23)
        Me.DoneButton.TabIndex = 2
        Me.DoneButton.Text = "Done"
        Me.DoneButton.UseVisualStyleBackColor = True
        '
        'WorksheetSelectorForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(252, 90)
        Me.Controls.Add(Me.DoneButton)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.WorksheetsComboBox)
        Me.Name = "WorksheetSelectorForm"
        Me.Text = "WorksheetSelectorForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents WorksheetsComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DoneButton As System.Windows.Forms.Button
End Class
