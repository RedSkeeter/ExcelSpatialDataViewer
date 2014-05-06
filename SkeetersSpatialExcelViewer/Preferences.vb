Public Class Preferences

    Private Sub Preferences_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.PreferencesPropertyGrid.SelectedObject = My.Settings
    End Sub
End Class