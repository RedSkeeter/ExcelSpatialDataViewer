Imports System.Data

Public Class WorksheetSelectorForm
    Private _WorksheetsDataTable As DataTable

    Private _SelectedWorksheet As String
    Public ReadOnly Property SelectedWorksheet() As String
        Get
            Return _SelectedWorksheet
        End Get
        'Set(ByVal value As String)
        '    _SelectedWorksheet = value
        'End Set
    End Property


    Public Sub New(WorksheetsDataTable As DataTable)
        InitializeComponent()
        _WorksheetsDataTable = WorksheetsDataTable
    End Sub

    Private Sub LoadWorksheetsComboBox(WorksheetsDataTable As DataTable)
        For Each WorksheetRow As DataRow In WorksheetsDataTable.Rows
            Dim WorksheetName As String = WorksheetRow.Item("TABLE_NAME").ToString.Trim
            Me.WorksheetsComboBox.Items.Add(WorksheetName)
        Next
    End Sub

    Private Sub WorksheetsComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles WorksheetsComboBox.SelectedIndexChanged
        _SelectedWorksheet = Me.WorksheetsComboBox.Text
    End Sub

    Private Sub DoneButton_Click(sender As System.Object, e As System.EventArgs) Handles DoneButton.Click
        _SelectedWorksheet = Me.WorksheetsComboBox.Text
    End Sub

    Private Sub WorksheetSelectorForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadWorksheetsComboBox(_WorksheetsDataTable)
    End Sub
End Class