Imports DotSpatial.Controls
Imports DotSpatial.Projections

Public Class ImportPointForm
    Private _Map As Map
    Public Property Map() As Map
        Get
            Return _Map
        End Get
        Set(ByVal value As Map)
            _Map = value
        End Set
    End Property

    Private _ProjectionInfo As ProjectionInfo
    Public Property ProjectionInfo() As ProjectionInfo
        Get
            Return _ProjectionInfo
        End Get
        Set(ByVal value As ProjectionInfo)
            _ProjectionInfo = value
        End Set
    End Property

    Private _Y As Double
    Public Property Y() As Double
        Get
            Return _Y
        End Get
        Set(ByVal value As Double)
            _Y = value
        End Set
    End Property


    Private _X As Double
    Public Property X() As Double
        Get
            Return _X
        End Get
        Set(ByVal value As Double)
            _X = value
        End Set
    End Property


    Public Sub New(Map As Map)
        InitializeComponent()
        _Map = Map
    End Sub


    Private Sub ImportPointForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ProjectionChooserButton_Click(sender As System.Object, e As System.EventArgs) Handles ProjectionChooserButton.Click
        Dim ProjectionDialog As New MapFrameProjectionDialog(_Map)
        If ProjectionDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Me.ProjectionTextBox.Text = ProjectionDialog.Text
        End If

    End Sub

    Private Sub SubmitButton_Click(sender As System.Object, e As System.EventArgs) Handles SubmitButton.Click
        If IsNumeric(Me.XCoordinateTextBox.Text) And IsNumeric(Me.YCoordinateTextBox.Text) Then
            _X = Me.XCoordinateTextBox.Text
            _Y = Me.YCoordinateTextBox.Text
            Me.Close()
        Else
            If MsgBox("Coordinates must be numeric.  Cancel to return to form.", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                Me.Close()
            End If
        End If

        Me.Close()
    End Sub
End Class