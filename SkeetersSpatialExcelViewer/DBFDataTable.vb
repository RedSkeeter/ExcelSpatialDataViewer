Imports System.Data.OleDb
Imports DotSpatial.Data
Imports DotSpatial.Projections
Imports DotSpatial.Topology
Imports Microsoft.VisualBasic.FileIO

Module DBFDataTable
    ''' <summary>
    ''' Extracts a DataTable from a DBF file
    ''' </summary>
    ''' <param name="DBF">Full path to DBF to transform. String</param>
    ''' <returns>DataTable</returns>
    ''' <remarks></remarks>
    Public Function GetDataTableFromDBF(DBF As String) As DataTable
        'datatable to hold the imported data
        Dim MyDataTable As New System.Data.DataTable()

        'make sure the file exists
        If My.Computer.FileSystem.FileExists(DBF) Then
            Try
                'get some info about the DBF
                Dim DBFFileInfo As New System.IO.FileInfo(DBF)
                Dim DBFFilename As String = DBFFileInfo.Name
                Dim DBFFileFolder As String = DBFFileInfo.DirectoryName

                'dbf filename can't be longer than 8 characters or have spaces, so if so, make a copy and work with that
                Dim RandomString As String = Rnd(99999).ToString.Replace(".", "") & Now.Second.ToString & Now.Millisecond.ToString & Now.Minute.ToString & Now.Hour.ToString
                Dim TempDBFFilename As String = "z" & RandomString.Substring(0, 7) & ".dbf"
                Dim TempDBFFilePath As String = ""
                If DBFFilename.Trim.Replace(DBFFileInfo.Extension, "").Length > 8 Or DBFFilename.Contains(" ") = True Then
                    'make a copy with a short filename to use
                    TempDBFFilePath = DBFFileFolder & "\" & TempDBFFilename
                    My.Computer.FileSystem.CopyFile(DBF, TempDBFFilePath, True)
                    DBFFilename = TempDBFFilename
                End If

                'try to connect to the dbf
                'make a connectionstring
                Dim MyConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & DBFFileFolder & ";Extended Properties=dBASE IV;User ID=Admin;Password=;"

                'make a connection
                Dim MyConnection As New System.Data.OleDb.OleDbConnection(MyConnectionString)

                'connect to the DBF and get the data
                MyConnection.Open() 'open the connection

                'build a query, command and load the results into a DataReader
                Dim Sql As String = "SELECT * FROM " & DBFFilename.Trim.Replace(".dbf", "").Trim & ""
                Dim MyCommand As New OleDbCommand(Sql, MyConnection)
                Dim MyDataReader As OleDbDataReader = MyCommand.ExecuteReader
                MyDataTable.Load(MyDataReader)
                MyConnection.Close()

                'if a temporary file was created try to delete it
                If My.Computer.FileSystem.FileExists(TempDBFFilePath) Then
                    My.Computer.FileSystem.DeleteFile(TempDBFFilePath)
                End If
            Catch ex As Exception
                MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
            End Try
        Else
            MsgBox("File not found. " & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End If
        Return MyDataTable
    End Function

    Public Function GetDataTableFromCSV(CSV As String, HasHeaderRow As Boolean) As DataTable

        'datatable to hold the imported data
        Dim MyDataTable As New System.Data.DataTable()

        'make sure the file exists
        If My.Computer.FileSystem.FileExists(CSV) Then
            Try
                'get some info about the CSV
                Dim CSVFileInfo As New System.IO.FileInfo(CSV)
                Dim CSVFilename As String = CSVFileInfo.Name.Trim
                Dim CSVFileFolder As String = CSVFileInfo.DirectoryName.Trim
                Dim CSVExtension As String = CSVFileInfo.Extension.Trim

                'make a connectionstring
                Dim MyConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & CSVFileFolder & ";Extended Properties=""text;HDR=" & IIf(HasHeaderRow = True, "YES", "NO") & ";FMT=Delimited"";"

                'make a connection
                Dim MyConnection As New System.Data.OleDb.OleDbConnection(MyConnectionString)

                'build a query, command and load the results into a DataReader
                Dim Sql As String = "SELECT * FROM [" & CSVFilename & "]"

                'connect to the CSV and get the data
                MyConnection.Open() 'open the connection
                Dim MyCommand As New OleDbCommand(Sql, MyConnection)

                Dim MyDataReader As OleDbDataReader = MyCommand.ExecuteReader(CommandBehavior.Default)
                MyDataTable.Load(MyDataReader)
                MyConnection.Close()
            Catch ex As Exception
                MsgBox(ex.InnerException.ToString & " " & ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
            End Try
        Else
            MsgBox("File not found. " & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End If
        Return MyDataTable
    End Function

    'Public Function GetDataTableFromText(TextFile As String) As DataTable

    '    'datatable to hold the imported data
    '    Dim MyDataTable As New System.Data.DataTable()

    '    'make sure the file exists
    '    If My.Computer.FileSystem.FileExists(TextFile) Then
    '        'Try
    '        'get some info about the TextFile
    '        Dim TextFileFileInfo As New System.IO.FileInfo(TextFile)
    '        Dim TextFileFilename As String = TextFileFileInfo.Name.Trim
    '        Dim TextFileFileFolder As String = TextFileFileInfo.DirectoryName.Trim
    '        Dim TextFileExtension As String = TextFileFileInfo.Extension.Trim

    '        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(TextFile)

    '            MyReader.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited
    '            MyReader.Delimiters = New String() {vbTab}

    '            Dim currentRow As String()
    '            'Loop through all of the fields in the file.  
    '            'If any lines are corrupt, report an error and continue parsing.  
    '            While Not MyReader.EndOfData
    '                Dim MyDataRow As DataRow = MyDataTable.NewRow
    '                Try
    '                    currentRow = MyReader.ReadFields()
    '                    If currentRow.Count <> 0 Then
    '                        MyDataRow.Item(0) = currentRow(0)
    '                        MyDataTable.Rows.Add(MyDataRow)
    '                        'For i As Integer = 0 To currentRow.Count - 1
    '                        '    Debug.Print(currentRow(i) & " | ")
    '                        'Next
    '                        ' Include code here to handle the row. 
    '                    End If
    '                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
    '                    Debug.Print("Line " & ex.Message & " is invalid.  Skipping")
    '                End Try
    '                Debug.Print(vbNewLine)
    '            End While
    '        End Using

    '        'Catch ex As Exception
    '        '    MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
    '        'End Try
    '    Else
    '        MsgBox("File not found. " & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
    '    End If
    '    Return MyDataTable
    'End Function

    ''' <summary>
    ''' Returns an OleDbConnection to the supplied Excel workbook
    ''' </summary>
    ''' <param name="Workbook">Full path to an Excel workbook</param>
    ''' <returns>OleDbConnection</returns>
    ''' <remarks></remarks>
    Public Function GetExcelConnection(Workbook As String) As OleDbConnection
        Dim MyConnection As New System.Data.OleDb.OleDbConnection() 'the connection to be returned
        If My.Computer.FileSystem.FileExists(Workbook) Then
            'get some info about the workbook
            Dim WorkbookFileInfo As New System.IO.FileInfo(Workbook)
            Dim Extension As String = WorkbookFileInfo.Extension

            'make a connection string to the workbook
            Dim MyConnectionString As String = ""
            If Extension = ".xls" Then
                MyConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" & Workbook & "; Extended Properties=""Excel 8.0;HDR=YES;IMEX=1"""
            ElseIf Extension = ".xlsx" Then
                MyConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Workbook & ";Extended Properties=""Excel 12.0 Xml;HDR=YES"";"
            Else
                MsgBox("Could not determine Excel version" & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
            End If
            MyConnection.ConnectionString = MyConnectionString
        End If
        Return MyConnection
    End Function

    ''' <summary>
    ''' Transforms the Excel workbook into a DataTable
    ''' </summary>
    ''' <param name="Workbook">Full path to an Excel workbook. String</param>
    ''' <param name="Worksheet">Worksheet name. Required. String</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetDataTableFromExcelWorkbook(Workbook As String, Worksheet As String) As DataTable
        'make a datatable to return
        Dim MyDataTable As New DataTable

        'make sure the workbook exists
        If My.Computer.FileSystem.FileExists(Workbook) Then
            If Worksheet.Trim.Length = 0 Then
                MsgBox("Worksheet cannot be empty string" & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
            Else
                Try
                    'make a connection
                    Dim MyConnection As OleDbConnection = GetExcelConnection(Workbook)

                    'connect to the Workbook and get the data
                    MyConnection.Open() 'open the connection

                    'build a query, command and load the results into a DataReader
                    Dim Sql As String = "SELECT * FROM [" & Worksheet & "]"
                    Dim MyCommand As New OleDbCommand(Sql, MyConnection)
                    Dim MyDataReader As OleDbDataReader = MyCommand.ExecuteReader

                    'transfer the datareader to the DataTable, load it into the datagridview and close the connection
                    MyDataTable.Load(MyDataReader)
                    MyConnection.Close()
                Catch ex As Exception
                    MsgBox("Error loading DataTable: " & ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
                End Try
            End If
        Else
            Throw New Exception("Workbook " & Workbook & " not found. ")
        End If
        Return MyDataTable
    End Function


    ''' <summary>
    ''' Returns a list of worksheets in the Excel workbook
    ''' </summary>
    ''' <param name="WorkbookConnection">An OleDbConnection to an Excel workbook. OleDbConnection.</param>
    ''' <returns>Worksheets list. List(Of String)</returns>
    ''' <remarks></remarks>
    Public Function GetWorksheetsFromExcelWorkbook(WorkbookConnection As OleDbConnection) As List(Of String)
        Dim WorksheetsList As New List(Of String) 'the list to return
        Try
            'get the list of worksheets in the workbook by examining the schema
            Dim WorksheetsDataTable As DataTable = WorkbookConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)

            'transform the worksheets datatable to a list
            For Each Row As DataRow In WorksheetsDataTable.Rows
                WorksheetsList.Add(Row.Item("TABLE_NAME"))
            Next
        Catch ex As Exception
            MsgBox(ex.Message & " (" & System.Reflection.MethodBase.GetCurrentMethod.Name & ")")
        End Try

        'return the list
        Return WorksheetsList
    End Function

    ''' <summary>
    ''' Cleans a spatial DataTable.  Cycles through each record and ensures the X and Y coordinate columns 
    ''' </summary>
    ''' <param name="SpatialDataTable"></param>
    ''' <param name="XColumnName"></param>
    ''' <param name="YColumnName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetCleanSpatialDataTable(SpatialDataTable As DataTable, XColumnName As String, YColumnName As String) As DataTable
        'this will be the returned data table
        Dim CleanSpatialDataTable As New DataTable("CleanSpatialData")

        'loop through the columns in the SpatialDataTable and duplicate each column inside the CleanSpatialDataTable
        For Each Col As DataColumn In SpatialDataTable.Columns
            CleanSpatialDataTable.Columns.Add(New DataColumn(Col.ColumnName, Col.DataType))
        Next

        'cleanse the data of nulls and zeroes
        For RowIndex As Integer = 0 To SpatialDataTable.Rows.Count - 1
            'make sure the lat/lon column values are not null
            If Not IsDBNull(SpatialDataTable.Rows(RowIndex).Item(YColumnName)) And Not IsDBNull(SpatialDataTable.Rows(RowIndex).Item(XColumnName)) Then
                'make sure the lat/lon column values are not zero (technically a lat/lon of 0,0 is possible, but highly unlikely)
                If Val(SpatialDataTable.Rows(RowIndex).Item(YColumnName)) <> 0 And Val(SpatialDataTable.Rows(RowIndex).Item(XColumnName)) <> 0 Then
                    Dim Row As DataRow = SpatialDataTable.Rows(RowIndex)
                    CleanSpatialDataTable.ImportRow(Row)
                End If
            End If
        Next
        Return CleanSpatialDataTable
    End Function

    Public Function GetPointFeatureSetFromDataTable(SpatialDataTable As DataTable, XColumnName As String, YColumnName As String, Projection As DotSpatial.Projections.ProjectionInfo, FeatureSetName As String) As DotSpatial.Data.FeatureSet

        'this will be the returned featureset
        Dim SpatialFeatureSet As New DotSpatial.Data.FeatureSet(FeatureType.Point)

        'the data in SpatialDataTable likely has null or zero value XY coordinates that will need to be cleaned out
        'this datatable will hold clean spatial rows (rows with null values or zero XY coordinates removed)
        Dim CleanSpatialDataTable As DataTable = GetCleanSpatialDataTable(SpatialDataTable, XColumnName, YColumnName)

        'add the columns from the cleanspatialdatatable to the featureset's datatable
        For Each Column As DataColumn In CleanSpatialDataTable.Columns
            SpatialFeatureSet.DataTable.Columns.Add(New DataColumn(Column.ColumnName, Column.DataType))
        Next

        'loop through the spatial datatable's rows and load the lat/lon coordinates as Features with attributes in the FeatureSet
        For RowIndex As Integer = 0 To CleanSpatialDataTable.Rows.Count - 1
            'make sure the lat/lon column values are not null
            If Not IsDBNull(CleanSpatialDataTable.Rows(RowIndex).Item(YColumnName)) And Not IsDBNull(CleanSpatialDataTable.Rows(RowIndex).Item(XColumnName)) Then
                'make sure the lat/lon column values are not zero (technically a lat/lon of 0,0 is possible, but highly unlikely)
                If Val(CleanSpatialDataTable.Rows(RowIndex).Item(YColumnName)) <> 0 And Val(CleanSpatialDataTable.Rows(RowIndex).Item(XColumnName)) <> 0 Then

                    'extract the value of the coordinates from the datatable (strings will convert to zeroes)
                    Dim Lat As Double = Val(CleanSpatialDataTable.Rows(RowIndex).Item(YColumnName.Trim))
                    Dim Lon As Double = Val(CleanSpatialDataTable.Rows(RowIndex).Item(XColumnName.Trim))

                    'add the lat/lon pair as a Feature to the Featureset
                    Dim MyPoint As New DotSpatial.Topology.Point(Lon, Lat)
                    Dim MyFeature As New Feature(MyPoint)
                    SpatialFeatureSet.AddFeature(MyFeature)

                    'now update the new feature's row with attributes from the coordinates datatable
                    For ColumnIndex As Integer = 0 To CleanSpatialDataTable.Columns.Count - 1
                        SpatialFeatureSet.DataTable.Rows(RowIndex).Item(ColumnIndex) = CleanSpatialDataTable.Rows(RowIndex).Item(ColumnIndex)
                    Next
                End If
            End If
        Next

        'assign featureset attributes
        With SpatialFeatureSet
            .Name = FeatureSetName
            .Projection = Projection
            .CoordinateType = CoordinateType.Regular
        End With

        'return the featureset
        Return SpatialFeatureSet
    End Function
End Module
