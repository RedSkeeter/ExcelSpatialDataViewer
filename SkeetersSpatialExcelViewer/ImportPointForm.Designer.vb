<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportPointForm
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
        Me.XCoordinateTextBox = New System.Windows.Forms.TextBox()
        Me.YCoordinateTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ProjectionChooserButton = New System.Windows.Forms.Button()
        Me.SubmitButton = New System.Windows.Forms.Button()
        Me.ProjectionTextBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'XCoordinateTextBox
        '
        Me.XCoordinateTextBox.Location = New System.Drawing.Point(32, 6)
        Me.XCoordinateTextBox.Name = "XCoordinateTextBox"
        Me.XCoordinateTextBox.Size = New System.Drawing.Size(177, 20)
        Me.XCoordinateTextBox.TabIndex = 0
        '
        'YCoordinateTextBox
        '
        Me.YCoordinateTextBox.Location = New System.Drawing.Point(32, 29)
        Me.YCoordinateTextBox.Name = "YCoordinateTextBox"
        Me.YCoordinateTextBox.Size = New System.Drawing.Size(177, 20)
        Me.YCoordinateTextBox.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(14, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "X"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(14, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Y"
        '
        'ProjectionChooserButton
        '
        Me.ProjectionChooserButton.Location = New System.Drawing.Point(134, 200)
        Me.ProjectionChooserButton.Name = "ProjectionChooserButton"
        Me.ProjectionChooserButton.Size = New System.Drawing.Size(117, 23)
        Me.ProjectionChooserButton.TabIndex = 4
        Me.ProjectionChooserButton.Text = "Choose projection"
        Me.ProjectionChooserButton.UseVisualStyleBackColor = True
        '
        'SubmitButton
        '
        Me.SubmitButton.Location = New System.Drawing.Point(134, 229)
        Me.SubmitButton.Name = "SubmitButton"
        Me.SubmitButton.Size = New System.Drawing.Size(117, 23)
        Me.SubmitButton.TabIndex = 5
        Me.SubmitButton.Text = "Submit"
        Me.SubmitButton.UseVisualStyleBackColor = True
        '
        'ProjectionTextBox
        '
        Me.ProjectionTextBox.Location = New System.Drawing.Point(32, 55)
        Me.ProjectionTextBox.Multiline = True
        Me.ProjectionTextBox.Name = "ProjectionTextBox"
        Me.ProjectionTextBox.Size = New System.Drawing.Size(230, 126)
        Me.ProjectionTextBox.TabIndex = 6
        '
        'ImportPointForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.ProjectionTextBox)
        Me.Controls.Add(Me.SubmitButton)
        Me.Controls.Add(Me.ProjectionChooserButton)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.YCoordinateTextBox)
        Me.Controls.Add(Me.XCoordinateTextBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ImportPointForm"
        Me.Text = "Import point"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents XCoordinateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents YCoordinateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ProjectionChooserButton As System.Windows.Forms.Button
    Friend WithEvents SubmitButton As System.Windows.Forms.Button
    Friend WithEvents ProjectionTextBox As System.Windows.Forms.TextBox
End Class
