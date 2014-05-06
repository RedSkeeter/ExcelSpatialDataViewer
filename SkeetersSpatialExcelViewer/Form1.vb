Imports System.Data.OleDb
'Imports Microsoft.Office.Interop.Excel
'Imports Microsoft.Office.Interop
Imports DotSpatial.Topology
Imports DotSpatial.Data
Imports DotSpatial.Controls
Imports DotSpatial.Symbology
Imports DotSpatial.Projections

Public Class Form1

    Dim WGSProjection As DotSpatial.Projections.ProjectionInfo = KnownCoordinateSystems.Geographic.World.WGS1984 'wgs84 dotspatial projection
    Dim SelectedColor As Color = Color.AliceBlue 'color for selected datagridview cells


    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Map.Projection = KnownCoordinateSystems.Projected.NorthAmerica.AlaskaAlbersEqualAreaConic

        'load the preferred base map if it exists
        LoadPreferredBaseMap(Map)

        'style the base layer 
        If Map.Layers.Count > 0 Then
            Dim MyLayer As IMapFeatureLayer = Map.Layers(0)
            Dim Symbolizer As New PolygonSymbolizer(Color.PaleGoldenrod, Color.LightGray, 1)
            MyLayer.Symbolizer = Symbolizer
        End If

        'temporary
        'Me.Map.Dock = DockStyle.None
        zTempAddLayers()
    End Sub

    Private Sub zTempAddLayers()
        Try
            Dim MyFont As New Font("Courier New", 8, FontStyle.Regular, GraphicsUnit.Pixel)

            'add gmu layer
            Dim GMUShp As String = "C:\Users\sdmiller\Documents\Work\GIS Common Layers\Game Management Units and Subunits.shp"
            Dim GMULayer As IMapLayer = Me.Map.AddLayer(GMUShp)
            'Dim GMULayerIndex As Integer = GetLayerIndex(GMULayer.LegendText.Trim)
            ApplyPolygonLayerStyle(Me.Map, GMULayer, "UNIT_SUB", Color.DimGray, MyFont, Color.White, Color.LightGray, 0.2)

            'add wear parks layer
            Dim WEARShp As String = "C:\Users\sdmiller\Documents\Work\GIS Common Layers\WEARParks.shp"
            Dim WEARLayer As IMapLayer = Me.Map.AddLayer(WEARShp)
            ApplyPolygonLayerStyle(Me.Map, WEARLayer, "PARKNAME", Color.DarkOliveGreen, MyFont, Color.ForestGreen, Color.DarkSeaGreen, 0.3)

            'zoom to the layer
            Map.ViewExtents = WEARLayer.DataSet.Extent

            'Map.AddLayer("C:\temp\ztest.shp")
        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try

    End Sub

    ''' <summary>
    ''' Applies styling and labeling to a MapPolygonLayer. 
    ''' </summary>
    ''' <param name="Map">Dotspatial Map</param>
    ''' <param name="PolygonLayer">MapPolygonLayer. IMapPolygonLayer</param>
    ''' <param name="LabelColumnName">Column name to use for labeling. String.</param>
    ''' <param name="LabelColor">Label color. System.Drawing.Color</param>
    ''' <param name="LabelFont"></param>
    ''' <param name="LayerFillColor">Fill color. System.Drawing.Color</param>
    ''' <param name="LayerOutlineColor">Outline color. System.Drawing.Color</param>
    ''' <param name="Opacity">Transparency of the fill color. 0=transparent, 1=opaque. Single</param>
    ''' <remarks>This is a utility function for quickly applying styles and labels to polygon layers.</remarks>
    Private Sub ApplyPolygonLayerStyle(Map As Map, PolygonLayer As IMapPolygonLayer, LabelColumnName As String, LabelColor As System.Drawing.Color, LabelFont As Font, LayerFillColor As System.Drawing.Color, LayerOutlineColor As System.Drawing.Color, Opacity As Single)

        'label the layer
        Map.AddLabels(PolygonLayer, "[" & LabelColumnName & "]", LabelFont, LabelColor)

        'now we'll get a reference to the PolygonLayer's Symbolizer and apply styling changes
        Dim MySymbolizer As PolygonSymbolizer = PolygonLayer.Symbolizer
        With MySymbolizer
            .SetFillColor(LayerFillColor.ToTransparent(Opacity))
            .SetOutline(LayerOutlineColor, 1)
        End With

        'show the labels
        PolygonLayer.ShowLabels = True

        'we want all the labels shown, even if they collide
        PolygonLayer.LabelLayer.Symbolizer.PreventCollisions = False

        'refresh the map
        Map.Refresh()
    End Sub

    ''' <summary>
    ''' Loads the preferred base map shapefile into the map.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadPreferredBaseMap(Map As DotSpatial.Controls.Map)
        'see if there is a preferred base map to show under the data
        If My.Settings.BaseMap.Trim.Length > 0 Then
            Try
                If My.Computer.FileSystem.FileExists(My.Settings.BaseMap.Trim) = True Then
                    'try to add the preferred shapefile if it exists
                    Map.AddLayer(My.Settings.BaseMap)
                    Dim BaseLayerFileInfo As New System.IO.FileInfo(My.Settings.BaseMap)
                    Dim BaseLayerIndex As Integer = GetLayerIndex(BaseLayerFileInfo.Name)
                    Dim BaseLayer As IMapLayer = Map.GetLayers(BaseLayerIndex)
                    BaseLayer.LegendText = "Base layer"
                    BaseLayer.Reproject(Map.Projection)
                Else
                    'base map could not be found, ask to remove it from preferences
                    If MsgBox("Could not load your preferred base map.  File does not exist.  Remove it from your preferences?", MsgBoxStyle.YesNo, "Error") = MsgBoxResult.Yes Then
                        My.Settings.BaseMap = ""
                    End If
                End If
            Catch ex As Exception
                'there was a problem loading the base map
                MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
            End Try
        End If
    End Sub

    ''' <summary>
    ''' Removes the layer containing the imported points from the map
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RemovePointsLayer()
        Try
            'get the index of the points layer in the map's layers collection
            Dim LayerIndex As Integer = GetLayerIndex("Points")

            'verify it's the point layer we're removing and not the base map which could be at position 0 (if there are no layers getlayerindex will return 0)
            Dim Layer As IMapLayer = Map.Layers(LayerIndex)

            'if layerindex happens to be zero determine if it's the points layer by it's legend text then remove it
            If LayerIndex = 0 Then
                If Layer.LegendText = "Points" Then
                    Map.Layers.RemoveAt(LayerIndex)
                End If
            Else
                Map.Layers.RemoveAt(LayerIndex)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' Loads Excel worksheet names into the form's WorksheetToolStripComboBox
    ''' </summary>
    ''' <param name="WorkSheetsList">List of worksheet names. List(Of String)</param>
    ''' <param name="SelectedWorksheetName">Name of the currently selected worksheet.  Optional.  This is the name of the worksheet that will appear in the ComboBox. String</param>
    ''' <remarks></remarks>
    Private Sub LoadWorksheetsComboboxes(WorkSheetsList As List(Of String), SelectedWorksheetName As String)
        'clear the worksheets combobox
        Me.WorksheetToolStripComboBox.Items.Clear()

        'set the comobobox's text to the requested worksheet name or the first worksheet name in the list of worksheets
        If SelectedWorksheetName = "" Then
            SelectedWorksheetName = WorkSheetsList(0).Trim
            Me.WorksheetToolStripComboBox.Text = SelectedWorksheetName
        Else
            Me.WorksheetToolStripComboBox.Text = SelectedWorksheetName
        End If

        'add the worksheet names to the combobox if they don't exist already
        For Each Sheet As String In WorkSheetsList
            'see if the sheet exists already
            Dim SheetExists As Boolean = False
            For Each SheetItem As String In Me.WorksheetToolStripComboBox.Items
                If SheetItem.Trim.ToLower = Sheet.Trim.ToLower Then
                    SheetExists = True
                End If
            Next
            'if the sheet doesn't exist already, add it
            If SheetExists = False Then
                Me.WorksheetToolStripComboBox.Items.Add(Sheet)
            End If
        Next
    End Sub


    ''' <summary>
    ''' Loads an Excel worksheet into the main DataGridView.
    ''' </summary>
    ''' <param name="Workbook">Full path to the Excel workbook to import</param>
    ''' <param name="WorkSheet">Name of the worksheet to use</param>
    ''' <remarks></remarks>
    Private Sub ImportDataFromExcel(Workbook As String, WorkSheet As String)

        'get a connection to the workbook
        Dim ExcelConnection As OleDbConnection = GetExcelConnection(Workbook)

        'open the connection
        ExcelConnection.Open()

        'get a list of the worksheets in the workbook
        Dim WorksheetsList As List(Of String) = GetWorksheetsFromExcelWorkbook(ExcelConnection)

        'if no worksheet was requested then grab the first one
        If WorkSheet.Trim = "" Then WorkSheet = WorksheetsList.Item(0)

        'load the worksheets into the worksheets comboboxes
        LoadWorksheetsComboboxes(WorksheetsList, WorkSheet)

        'get the data from the excel workbook and worksheet
        Dim ExcelDataTable As DataTable = GetDataTableFromExcelWorkbook(Workbook, WorkSheet)

        'add a row number column to the left of the datatable
        ExcelDataTable.Columns.Add("Row", Type.GetType("System.Int32"))
        ExcelDataTable.Columns(ExcelDataTable.Columns.Count - 1).SetOrdinal(0)

        'number the row column sequentially
        Dim i As Integer = 1
        For Each Row As DataRow In ExcelDataTable.Rows
            Row.Item(0) = i
            i = i + 1
        Next

        'close the connection to the workbook
        ExcelConnection.Close()

        'set the datagridview's datasource to the excel data sheet
        Me.DataGridView.DataSource = ExcelDataTable

        'load the column names into the lat/lon column name combo boxes
        LoadColumnNamesIntoComboboxes(ExcelDataTable)
    End Sub

    ''' <summary>
    ''' Loads the  lat/lon column name combo boxes with column names from SpatialDataTable
    ''' </summary>
    ''' <param name="SpatialDataTable">DataTable containing latitude and longitude columns</param>
    ''' <remarks></remarks>
    Private Sub LoadColumnNamesIntoComboboxes(SpatialDataTable As DataTable)
        'user needs to indicate which columns contain the lat/lon values, load up the combo boxes that allow this
        Try
            'clear the existing items
            Me.LatColumnToolStripComboBox.Items.Clear()
            Me.LonColumnToolStripComboBox.Items.Clear()
            Me.LatColumnToolStripComboBox.Text = ""
            Me.LonColumnToolStripComboBox.Text = ""

            'loop through the data columns and add the m to the comboboxes
            For Each Column As DataColumn In SpatialDataTable.Columns
                Me.LatColumnToolStripComboBox.Items.Add(Column.ColumnName)
                Me.LonColumnToolStripComboBox.Items.Add(Column.ColumnName)

                'try to guess the latitude column name
                If Column.ColumnName.Trim.Length >= 3 Then
                    If Column.ColumnName.Substring(0, 3).ToLower = "lat" Then
                        Me.LatColumnToolStripComboBox.Text = Column.ColumnName.Trim
                    End If

                    'try to guess the longitude column name
                    If Column.ColumnName.Substring(0, 3).ToLower = "lon" Then
                        Me.LonColumnToolStripComboBox.Text = Column.ColumnName.Trim
                    End If
                End If
            Next

            'if we have guessed the column names then load the points
            If Me.LatColumnToolStripComboBox.Text.Trim.Length > 0 And Me.LonColumnToolStripComboBox.Text.Trim.Length > 0 Then
                LoadPoints(SpatialDataTable, Me.LatColumnToolStripComboBox.Text.Trim, Me.LonColumnToolStripComboBox.Text.Trim)
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    ''' <summary>
    ''' Multiplies each value in the main DataGridView's selected Longitude column by -1 (sometimes longitude is reported in the western hemisphere with positive values, 
    ''' this routine corrects such a problem).
    ''' </summary>
    ''' <param name="DataTable">DataTable containing a longitude column</param>
    ''' <remarks></remarks>
    Private Sub NegifyLonColumn(DataTable As DataTable, LongitudeColumnName As String)
        Try
            For Each Row As DataRow In DataTable.Rows
                If Not IsDBNull(Row.Item(LongitudeColumnName)) Then
                    Row.Item(Me.LonColumnToolStripComboBox.Text.Trim) = Val(Row.Item(LongitudeColumnName)) * -1
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
            Me.LogTextBox.AppendText(ex.Message & vbNewLine)
        End Try
    End Sub

    Private Sub LoadPoints(CoordinatesDataTable As DataTable, LatitudeColumnName As String, LongitudeColumnName As String)
        'Loads the Lat/Lon pairs selected in the main DataGridView into a DotSpatial featureset which is then loaded into the map.
        Try
            RemovePointsLayer()

            'dim up a Dotspatial Featureset to hold the spatial data from the CoordinatesDataTable
            Dim SpatialFeatureSet As FeatureSet = GetPointFeatureSetFromDataTable(CoordinatesDataTable, LongitudeColumnName, LatitudeColumnName, WGSProjection, "Points")

            'map the featureset
            Map.Layers.Add(SpatialFeatureSet)
            Me.PointsFeatureSetDataGridView.DataSource = SpatialFeatureSet.DataTable

            'style the features
            Dim PointsFeatureLayer As IMapFeatureLayer = Map.Layers(GetLayerIndex("Points"))
            Dim Symbolizer As New PointSymbolizer(Color.Red, DotSpatial.Symbology.PointShape.Ellipse, 6)
            PointsFeatureLayer.Symbolizer = Symbolizer

        Catch ex As Exception
            'something went bonkers
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
            Me.LogTextBox.AppendText(ex.Message & vbNewLine)
        End Try
    End Sub



    ''' <summary>
    ''' Returns the index of a map layer determined by the layer's legend text.
    ''' </summary>
    ''' <param name="LayerLegendText">Legend text of the layer</param>
    ''' <returns>Integer</returns>
    ''' <remarks>Seems silly to get a layer index this way but it's the only way I found to do it.</remarks>
    Private Function GetLayerIndex(LayerLegendText As String) As Integer
        Dim PointsLayerIndex As Integer = 0 'this will hold the returned value
        Dim Index As Integer = 0 'current index in the loop below
        Try
            'loop through the layers
            For Each Layer As IMapLayer In Map.Layers
                'look for a match between the layer's legend text and the searched for legend text
                If Layer.LegendText = LayerLegendText Then
                    PointsLayerIndex = Index 'got it
                End If

                'increment the index
                Index = Index + 1
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

        'return the index
        Return PointsLayerIndex
    End Function

    Private Sub MapItToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles MapItToolStripButton.Click
        LoadPoints(Me.DataGridView.DataSource, Me.LatColumnToolStripComboBox.Text.Trim, Me.LonColumnToolStripComboBox.Text.Trim)
    End Sub

    ''' <summary>
    ''' Adds a shapefile to the map.
    ''' </summary>
    ''' <param name="Shapefile">Path to shapefile. String</param>
    ''' <remarks></remarks>
    Private Sub ImportShapefile(Shapefile As String, FillColor As System.Drawing.Color, OutlineColor As System.Drawing.Color)
        'add the selected shapefile to the map
        Dim NewLayer As IMapLayer = Map.AddLayer(Shapefile)
        Dim NewFeatureLayer As IMapFeatureLayer = NewLayer
        Dim Symbolizer As New PolygonSymbolizer(FillColor, OutlineColor)
        NewFeatureLayer.Symbolizer = Symbolizer
        Map.Refresh()
    End Sub

    Private Sub AddShapefileToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles AddShapefileToolStripButton.Click
        Dim OFD As New OpenFileDialog
        With OFD
            .DefaultExt = ".shp"
            .Filter = "Shapefiles|*.shp"
            '.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            .Multiselect = True
            .RestoreDirectory = True
            .Title = "Select a shapefile"
        End With
        If OFD.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                For Each FileToOpen In OFD.FileNames
                    If My.Computer.FileSystem.FileExists(FileToOpen) Then
                        ImportShapefile(FileToOpen, Color.Red, Color.Red)
                    Else
                        MsgBox("File does not exist: " & FileToOpen)
                    End If
                Next
            Catch ex As Exception
                MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
                Me.LogTextBox.AppendText(ex.Message)
            End Try
        End If
    End Sub

    Private Sub ZoominToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles ZoominToolStripButton.Click
        Map.FunctionMode = DotSpatial.Controls.FunctionMode.ZoomIn
    End Sub

    Private Sub ZoomOutToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles ZoomOutToolStripButton.Click
        Map.FunctionMode = DotSpatial.Controls.FunctionMode.ZoomOut
    End Sub

    Private Sub PanToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles PanToolStripButton.Click
        Map.FunctionMode = DotSpatial.Controls.FunctionMode.Pan
    End Sub

    Private Sub ZoomPreviousToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles ZoomPreviousToolStripButton.Click
        Map.ZoomToPrevious()
    End Sub

    Private Sub ZoomToFullExtentToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles ZoomToFullExtentToolStripButton.Click
        Map.ZoomToMaxExtent()
    End Sub


    Private Sub OpenExcelWorkbookToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OpenExcelWorkbookToolStripMenuItem.Click
        Dim OFD As New OpenFileDialog
        With OFD
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            .Multiselect = False
            .RestoreDirectory = True
            .Title = "Select an Excel workbook"
            .Filter = "Excel workbook (*.xls, *.xlsx)|*.xls;*.xlsx"
        End With
        If OFD.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                ImportData(OFD.FileName)
            Catch ex As Exception
                'oops
                MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
                Me.LogTextBox.AppendText(ex.Message)
            End Try
        End If
    End Sub

    Private Sub OpenWorkbookToolStripButton_Click(sender As System.Object, e As System.EventArgs)
        ImportDataFromExcel(Me.DataSourceToolStripStatusLabel.Text, "")
    End Sub


    Private Sub PreferencesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PreferencesToolStripMenuItem.Click
        'let the user change application preferences
        Dim PreferencesForm As New Preferences
        PreferencesForm.ShowDialog()
    End Sub


    ''' <summary>
    ''' Validates that the application has a workbook and lat/lon column names to work with before enabling the Map it button
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EnableMapping()
        If Me.LatColumnToolStripComboBox.Text.Trim.Length > 0 And Me.LonColumnToolStripComboBox.Text.Trim.Length > 0 Then
            Me.MapItToolStripButton.Enabled = True
        Else
            Me.MapItToolStripButton.Enabled = False
        End If
    End Sub

    Private Sub LoadImportedDataMetadata()
        Me.ImportedDataMetadataTextBox.Text = GetMetadataFromDataTable(Me.DataGridView.DataSource)
    End Sub

    Private Sub LatColumnToolStripComboBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles LatColumnToolStripComboBox.TextChanged
        HighlightSelectedColumns()
        EnableMapping()
    End Sub

    Private Sub LonColumnToolStripComboBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles LonColumnToolStripComboBox.TextChanged
        HighlightSelectedColumns()
        EnableMapping()
    End Sub

    ''' <summary>
    ''' Highlights the selected Lat/Lon columns in the main DataGridView
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub HighlightSelectedColumns()
        'look for the columns in the main datagridview that were selected by the user as the Lat/Lon columns
        For Each Column As DataGridViewColumn In DataGridView.Columns
            If Column.Name <> Me.LatColumnToolStripComboBox.Text.Trim And Column.Name <> Me.LonColumnToolStripComboBox.Text.Trim Then
                Column.DefaultCellStyle.BackColor = Color.White
                Column.DefaultCellStyle.ForeColor = Color.Gray
            Else
                Column.DefaultCellStyle.BackColor = SelectedColor
                Column.DefaultCellStyle.ForeColor = Color.Black
            End If
        Next
    End Sub

    Private Sub OpenWorkbookToolStripButton_Click_1(sender As System.Object, e As System.EventArgs) Handles OpenDataSourceToolStripButton.Click
        Dim Workbook As String = Me.DataSourceToolStripStatusLabel.Text.Trim
        If My.Computer.FileSystem.FileExists(Workbook) Then
            Process.Start(Workbook)
        Else
            MsgBox("There is no current workbook or the file does not exist")
        End If
    End Sub

    Private Sub WorkbookToolStripStatusLabel_TextChanged(sender As System.Object, e As System.EventArgs) Handles DataSourceToolStripStatusLabel.TextChanged
        'if we have a valid excel workbook enable the open it button
        If My.Computer.FileSystem.FileExists(Me.DataSourceToolStripStatusLabel.Text.Trim) Then
            Me.OpenDataSourceToolStripButton.Enabled = True
        Else
            Me.OpenDataSourceToolStripButton.Enabled = False
        End If
    End Sub

    Private Sub DataGridView_DragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles DataGridView.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        End If
    End Sub

    Private Sub DataGridView_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles DataGridView.DragDrop
        'open the dropped excel sheet
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim DroppedFiles() As String

            ' Assign the files to an array.
            DroppedFiles = e.Data.GetData(DataFormats.FileDrop)

            'get the dropped filename
            Dim CurrentFile As System.IO.FileInfo = My.Computer.FileSystem.GetFileInfo(DroppedFiles(0).ToString)

            'load the data into the main datagridview
            ImportData(CurrentFile.FullName)
        End If

    End Sub

    Private Function GetMetadataFromDataTable(DataTable As DataTable) As String
        Dim Metadata As String = "Data table: " & DataTable.TableName & vbNewLine
        Try
            Metadata = Metadata & "Rows: " & DataTable.Rows.Count & vbNewLine
            Metadata = Metadata & "Columns: " & DataTable.Columns.Count & vbNewLine

            Dim ColumnsList As String = ""
            For Each Col As DataColumn In DataTable.Columns
                ColumnsList = ColumnsList & Col.ColumnName & ","
            Next
            ColumnsList = ColumnsList.TrimEnd(",")

            Metadata = Metadata & "Columns list: " & ColumnsList & vbNewLine
            Metadata = Metadata & vbNewLine
            Metadata = Metadata & "Columns:" & vbNewLine

            For Each Column As DataColumn In DataTable.Columns
                Metadata = Metadata & "Caption: " & Column.Caption & vbNewLine
                Metadata = Metadata & "Column name: " & Column.ColumnName & vbNewLine
                Metadata = Metadata & "Data type: " & Column.DataType.ToString & vbNewLine
                Metadata = Metadata & "Allow null: " & Column.AllowDBNull & vbNewLine
                Metadata = Metadata & "Date/time mode: " & Column.DateTimeMode & vbNewLine
                Metadata = Metadata & "Default value: " & Column.DefaultValue & vbNewLine
                Metadata = Metadata & "Expression: " & Column.Expression & vbNewLine
                Metadata = Metadata & "Extended properties count: " & Column.ExtendedProperties.Count & vbNewLine
                For i As Integer = 0 To Column.ExtendedProperties.Count - 1
                    Metadata = Metadata & vbTab & "Property" & Column.ExtendedProperties.Item(i) & vbNewLine
                Next



                Metadata = Metadata & "Max length: " & Column.MaxLength & vbNewLine
                Metadata = Metadata & "Prefix: " & Column.Prefix.ToString & vbNewLine
                Metadata = Metadata & "Unique: " & Column.Unique & vbNewLine
                Metadata = Metadata & vbNewLine
            Next
        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
        Return Metadata
    End Function

    ''' <summary>
    ''' Imports a .dbf file 
    ''' </summary>
    ''' <param name="DBFFile">.dbf file to import. String. Full path.</param>
    ''' <remarks></remarks>
    Private Sub ImportDataFromDBF(DBFFile As String)
        'make a datatable to hold the data
        Dim DBFDataTable As New DataTable
        DBFDataTable = GetDataTableFromDBF(DBFFile)

        'load the column names comboboxes with column names
        LoadColumnNamesIntoComboboxes(DBFDataTable)

        'set the datagridview's datasource to our datatable
        Me.DataGridView.DataSource = DBFDataTable

        'put the imported datasource name into the worksheet combobox
        Me.WorksheetToolStripComboBox.Items.Clear()
        Dim DBFFileInfo As New System.IO.FileInfo(DBFFile)
        Me.WorksheetToolStripComboBox.Text = DBFFileInfo.Name

        'see if we're ready to load the data into the map
        EnableMapping()
    End Sub

    ''' <summary>
    ''' Imports a comma separated values text file.
    ''' </summary>
    ''' <param name="CSVFile">.csv file to import. Full path.</param>
    ''' <remarks></remarks>
    Private Sub ImportDataFromCSV(CSVFile As String)
        'a datatable to hold the csv data
        Dim CSVDataTable As New DataTable

        'get the data into a datatable
        If My.Computer.FileSystem.FileExists(CSVFile) Then
            'load the text file into the Source text box
            Me.SourceTextBox.Text = "Source of " & CSVFile & vbNewLine
            Dim FileContents As String = System.IO.File.ReadAllText(CSVFile)
            Me.SourceTextBox.Text = FileContents

            'get info about the file
            Dim CSVFileInfo As New IO.FileInfo(CSVFile)

            'find out if the file has headers or not
            Dim HasHeaders As Boolean
            Dim MsgBoxResult As MsgBoxResult = MsgBox("Does " & CSVFileInfo.Name & " have column headers in the first row? Click cancel to open the file to check for headers.", MsgBoxStyle.YesNoCancel)
            If MsgBoxResult = Microsoft.VisualBasic.MsgBoxResult.Yes Then
                HasHeaders = True
            ElseIf MsgBoxResult = Microsoft.VisualBasic.MsgBoxResult.No Then
                HasHeaders = False
            Else
                Process.Start(CSVFile)
                If MsgBox("Does " & CSVFileInfo.Name & " have column headers in the first row?", MsgBoxStyle.YesNo) = Microsoft.VisualBasic.MsgBoxResult.Yes Then
                    HasHeaders = True
                Else
                    HasHeaders = False
                End If
            End If

            'import the datatable
            CSVDataTable = GetDataTableFromCSV(CSVFile, HasHeaders)
            LoadColumnNamesIntoComboboxes(CSVDataTable)
            Me.DataGridView.DataSource = CSVDataTable
            Me.WorksheetToolStripComboBox.Items.Clear()
            Me.WorksheetToolStripComboBox.Text = CSVFileInfo.Name
            EnableMapping()
        End If
    End Sub


    ''' <summary>
    ''' Imports data
    ''' </summary>
    ''' <param name="File">Data source to import.  Full path to data file. String</param>
    ''' <remarks></remarks>
    Private Sub ImportData(File As String)


        'clear the datagridview
        Me.DataGridView.DataSource = Nothing

        Try
            If My.Computer.FileSystem.FileExists(File) Then
                'remove any existing points layer
                RemovePointsLayer()

                'update the status strip label
                Me.DataSourceToolStripStatusLabel.Text = File

                'figure out what kind of data we're importing and call the right function
                Dim MyFileInfo As New System.IO.FileInfo(File)
                If MyFileInfo.Extension.Trim.ToLower = ".dbf" Then
                    ImportDataFromDBF(File)
                ElseIf MyFileInfo.Extension.Trim.ToLower = ".xls" Or MyFileInfo.Extension.Trim.ToLower = ".xlsx" Then
                    ImportDataFromExcel(File, "")
                ElseIf MyFileInfo.Extension.Trim.ToLower = ".csv" Or MyFileInfo.Extension.Trim.ToLower = ".txt" Then
                    ImportDataFromCSV(File)
                Else
                    'hail mary, maybe it's a csv file
                    ImportDataFromCSV(File)
                    'MsgBox("Unrecognized data source")
                End If

                'load the imported data's metadata into the metadata tab
                LoadImportedDataMetadata()
            Else
                MsgBox("File does not exist")
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try
    End Sub

    'Private Sub Map_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles Map.DragDrop
    '    If e.Data.GetDataPresent(DataFormats.FileDrop) Then
    '        Dim DroppedFiles() As String

    '        ' Assign the files to an array.
    '        DroppedFiles = e.Data.GetData(DataFormats.FileDrop)

    '        'get the dropped filename
    '        Dim CurrentFile As System.IO.FileInfo = My.Computer.FileSystem.GetFileInfo(DroppedFiles(0).ToString)
    '        If CurrentFile.Extension = ".shp" Then
    '            Try
    '                ImportShapefile(CurrentFile.FullName, Color.Red, Color.Red)
    '            Catch ex As Exception
    '                MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
    '            End Try
    '        End If
    '    End If
    'End Sub

    'Private Sub Map_DragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles Map.DragEnter
    '    If e.Data.GetDataPresent(DataFormats.FileDrop) Then
    '        e.Effect = DragDropEffects.All
    '    End If
    'End Sub

    Private Sub ImportDBFToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ImportDBFToolStripMenuItem.Click
        Dim FOD As New OpenFileDialog
        With FOD
            .RestoreDirectory = True
            .Filter = "DBF Files (*.dbf)|*.dbf"
            .Multiselect = False
            .Title = "Import data from a .dbf file"
        End With

        If FOD.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            ImportDataFromDBF(FOD.FileName)
        End If
    End Sub

    
    Private Sub ExportSnapshotToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles ExportSnapshotToolStripButton.Click
        'export the map as an image
        'Dim SnapshotFile As String = ""
        'Dim SFD As New SaveFileDialog
        'With SFD
        '    .CheckPathExists = True
        '    .FileName = "MapImage.bmp"
        '    '.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        '    '.InitialDirectory = "C:\Users\sdmiller\Documents\WEAR Dataset Documentation and Archival Project 2013\DatasetImages"
        '    .OverwritePrompt = True
        '    .RestoreDirectory = True
        'End With
        'If SFD.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
        '    ExportMapImage(Me.Map, SFD.FileName)
        'End If
        Dim DatasetID As Integer = InputBox("DatasetID:", "DatasetID")
        Dim SaveFileName As String = "C:\Users\sdmiller\Documents\WEAR Dataset Documentation and Archival Project 2013\DatasetImages\" & DatasetID & ".bmp"
        ExportMapImage(Me.Map, SaveFileName)
    End Sub

    ''' <summary>
    ''' Exports Map as an image.
    ''' </summary>
    ''' <param name="Map">A DotSpatial map. DotSpatial.Controls.Map</param>
    ''' <param name="Filename">Full path and filename of image to be exported. String.</param>
    ''' <remarks></remarks>
    Public Sub ExportMapImage(Map As DotSpatial.Controls.Map, Filename As String)
        Dim MyRectangle As New Rectangle(0, 0, Map.Width, Map.Height)
        Dim MyBitmap As Bitmap = New Bitmap(Map.Width, Map.Height)
        Dim MyGraphics As Graphics = Graphics.FromImage(MyBitmap)
        Map.MapFrame.Print(MyGraphics, MyRectangle)
        MyBitmap.Save(Filename)

        'ask to open the file
        'If My.Computer.FileSystem.FileExists(Filename) Then
        '    If MsgBox("Open exported file?", MsgBoxStyle.YesNo, "Open") = MsgBoxResult.Yes Then
        '        Process.Start(Filename)
        '    End If
        'End If
    End Sub

    Private Sub ToggleLongitudeEastWestToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles ToggleLongitudeEastWestToolStripButton.Click
        'multiply all the longitudes by -1
        NegifyLonColumn(DataGridView.DataSource, Me.LonColumnToolStripComboBox.Text.Trim)

        'reload the points
        RemovePointsLayer()
        LoadPoints(Me.DataGridView.DataSource, Me.LatColumnToolStripComboBox.Text.Trim, Me.LonColumnToolStripComboBox.Text.Trim)
    End Sub

    Private Sub WorksheetToolStripComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles WorksheetToolStripComboBox.SelectedIndexChanged
        ImportDataFromExcel(Me.DataSourceToolStripStatusLabel.Text.Trim, Me.WorksheetToolStripComboBox.Text.Trim)
    End Sub

    Private Sub Legend_Click(sender As System.Object, e As System.EventArgs) Handles Legend.Click
        Dim CurrentLayer As IMapLayer = Map.Layers.SelectedLayer
        Me.PointsFeatureSetDataGridView.DataSource = GetLayerFeaturesetDatatable(Map, Map.Layers.IndexOf(CurrentLayer))
    End Sub

    Private Sub LoadSelectedLayerAttributesIntoDataGridView()

    End Sub

    ''' <summary>
    ''' Returns a map layer's featureset's DataTable
    ''' </summary>
    ''' <param name="Map">A DotSpatial Map</param>
    ''' <returns>DataTable of the Layer's Featureset's attributes</returns>
    ''' <remarks>
    ''' Use this function to get at a Layer's attributes.  A DotSpatial Layer does not have an attribute table (strangely enough).  
    ''' Getting to a Layer's attributes involves casting the Layer as a FeatureSet, then getting a handle on the FeatureSet's DataSet and then 
    ''' grabbing it's DataTable.  Confusing, huh?
    ''' </remarks>
    Private Function GetLayerFeaturesetDatatable(Map As DotSpatial.Controls.Map, MapLayerIndex As Integer) As DataTable
        Try
            'get a handle on a map layer
            Dim Layer As IMapLayer = Map.Layers(MapLayerIndex)
            'get a handle on Layer's Dataset which contains a DataTable of attributes
            Dim LayerFeatureset As IFeatureSet = Layer.DataSet
            'return the datatable
            Return LayerFeatureset.DataTable
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
    End Function



    Private Sub ImportPoint()
        'Dim PointLayer As FeatureSet = GetPointFeatureSetFromPoint(-165.3, 62.25, WGSProjection)
        'Me.DataGridView.DataSource = PointLayer.DataTable
        'Map.Layers.Add(PointLayer)
        Dim P As New ImportPointForm(Me.Map)
        P.ShowDialog(Me)

        Dim DataTable As New DataTable("Point")
        DataTable.Columns.Add("X", GetType(Double))
        DataTable.Columns.Add("Y", GetType(Double))
        Dim DataRow As DataRow = DataTable.NewRow
        DataRow.Item("X") = P.X
        DataRow.Item("Y") = P.Y
        DataTable.Rows.Add(DataRow)
        Me.DataGridView.DataSource = DataTable
        LoadColumnNamesIntoComboboxes(Me.DataGridView.DataSource)
        HighlightSelectedColumns()
        EnableMapping()
    End Sub

    Private Sub ImportPointToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles ImportPointToolStripButton.Click
        ImportPoint()
    End Sub

    Private Sub ImportCSVToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ImportCSVToolStripMenuItem.Click
        Dim FOD As New OpenFileDialog
        With FOD
            .Multiselect = False
            .Title = "Import data from a text file"
        End With

        If FOD.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            ImportDataFromCSV(FOD.FileName)
        End If
    End Sub

    'Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
    '    'Debug.Print(ExportFeaturesetToSql())
    '    LoopThroughFeatures()
    'End Sub

    'Private Function ExportFeaturesetToSql() As String
    '    'a string to return
    '    Dim ExportScript As String = ""

    '    'get the selected layer from the map
    '    Dim MyFeatureLayer As IMapFeatureLayer = Map.Layers.SelectedLayer
    '    MyFeatureLayer.Reproject(KnownCoordinateSystems.Geographic.World.WGS1984)

    '    'loop through the layer's features
    '    For Each Feature As Feature In MyFeatureLayer.DataSet.Features
    '        'get the feature's NAME attribute into a variable
    '        Dim FeatureName As String = Feature.DataRow.Item("NAME")

    '        'create a WKT representation of the Feature
    '        Dim WKT As String = "POLYGON(("

    '        'loop through the Feature's vertices
    '        For Each Coordinate As Coordinate In Feature.Coordinates
    '            'add the vertex's coordinates to the WKT string
    '            WKT = WKT & Coordinate.X & " " & Coordinate.Y & ","
    '        Next

    '        'trim the trailing comma and close out the WKT string
    '        WKT = WKT.Remove(WKT.Trim.Length - 1, 1) & "))"

    '        'create a Sql Server insert query to add the polygon to a table
    '        Dim InsertQuery As String = "INSERT INTO MyDataTable(Name,Feature) VALUES('" & FeatureName & "', geography::STPolyFromText('" & WKT & "', 4326);"

    '        'add the insert query to the script
    '        ExportScript = ExportScript & InsertQuery & vbNewLine
    '    Next
    '    Return ExportScript
    'End Function

    'Private Sub LoopThroughFeatures()
    '    'get the selected layer from the map
    '    Dim MyFeatureLayer As IMapFeatureLayer = Map.Layers.SelectedLayer
    '    MyFeatureLayer.Reproject(KnownCoordinateSystems.Geographic.World.WGS1984)

    '    'loop through the layer's features
    '    For Each Feature As Feature In MyFeatureLayer.DataSet.Features
    '        'get the feature's NAME attribute into a variable
    '        Dim FeatureName As String = Feature.DataRow.Item("NAME")
    '        Debug.Print("Feature: " & FeatureName & " has the following vertices:")

    '        'loop through the Feature's vertices
    '        For Each Coordinate As Coordinate In Feature.Coordinates
    '            'output each vertex's coordinates
    '            Debug.Print(vbTab & Coordinate.X & " " & Coordinate.Y)
    '        Next
    '    Next
    'End Sub


    Private Sub SourceTextBox_DragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles SourceTextBox.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        End If
    End Sub

    Private Sub SourceTextBox_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles SourceTextBox.DragDrop
        'open the dropped excel sheet
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim DroppedFiles() As String

            ' Assign the files to an array.
            DroppedFiles = e.Data.GetData(DataFormats.FileDrop)

            'get the dropped filename
            Dim CurrentFile As System.IO.FileInfo = My.Computer.FileSystem.GetFileInfo(DroppedFiles(0).ToString)

            Dim FileContents As String = System.IO.File.ReadAllText(CurrentFile.FullName)
            Me.SourceTextBox.Text = FileContents
        End If
    End Sub

    Private Sub Map_LayerAdded(sender As System.Object, e As DotSpatial.Symbology.LayerEventArgs) Handles Map.LayerAdded
        If Map.Layers.Count > 1 Then
            StyleLayer(Me.Map, Me.Map.Layers.Count - 1)
            Map.Refresh()
        End If
    End Sub

    ''' <summary>
    ''' Styles the map layer at position LayerIndex
    ''' </summary>
    ''' <param name="Map">A DotSpatial Map</param>
    ''' <param name="LayerIndex">Index of a layer in the Map's Layers collection</param>
    ''' <remarks></remarks>
    Private Sub StyleLayer(Map As Map, LayerIndex As Integer)
        Try
            'get a reference to the layer
            Dim Layer As IMapLayer = Map.Layers(LayerIndex)

            'get a reference to the layer's featureset
            Dim FeatureLayer As IMapFeatureLayer = Layer

            'determine what kind of features the featureset holds
            If FeatureLayer.DataSet.FeatureType = FeatureType.Polygon Then
                'make and apply a polygon symbolizer
                Dim Symbolizer As New DotSpatial.Symbology.PolygonSymbolizer(Color.Red.ToTransparent(0.1), Color.Red)
                FeatureLayer.Symbolizer = Symbolizer
            ElseIf FeatureLayer.DataSet.FeatureType = FeatureType.Line Then
                'make and apply a line symbolizer
                Dim Symbolizer As New LineSymbolizer(Color.Red, 1)
                FeatureLayer.Symbolizer = Symbolizer
            ElseIf FeatureLayer.DataSet.FeatureType = FeatureType.MultiPoint Or FeatureLayer.DataSet.FeatureType = FeatureType.Point Then
                'make and apply a point symbolizer
                Dim Symbolizer As New PointSymbolizer(Color.Red, DotSpatial.Symbology.PointShape.Ellipse, 3)
                FeatureLayer.Symbolizer = Symbolizer
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " " & System.Reflection.MethodBase.GetCurrentMethod.Name)
        End Try
    End Sub

End Class
