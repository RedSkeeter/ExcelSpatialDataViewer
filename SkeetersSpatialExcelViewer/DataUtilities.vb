Imports System.Data.OleDb
Module DataUtilities

    'make an enumeration of allowed text file formats to import
    Enum TextFileFormat
        Delimited
        FixedWidth
    End Enum

    Public Function ConvertTextFileToDataTable(TextFile As String, Format As TextFileFormat) As DataTable

        Dim MyDataTable As New DataTable
        If My.Computer.FileSystem.FileExists(TextFile) Then
            Try
                Dim TextFileFolder As String = System.IO.Path.GetDirectoryName(TextFile)
                'get some info about the TextFile
                Dim TextFileInfo As New System.IO.FileInfo(TextFile)
                Dim TextFilename As String = TextFileInfo.Name
                Dim MyConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & TextFileFolder.Trim & ";Extended Properties='text;HDR=Yes;FMT=" & Format & "';"

                'make a connection
                Dim MyConnection As New System.Data.OleDb.OleDbConnection(MyConnectionString)

                'connect to the TextFile and get the data
                MyConnection.Open() 'open the connection

                'build a query, command and load the results into a DataReader
                Dim Sql As String = "SELECT * FROM " & TextFilename.Trim
                Dim MyCommand As New OleDbCommand(Sql, MyConnection)
                Dim MyDataReader As OleDbDataReader = MyCommand.ExecuteReader
                MyDataTable.Load(MyDataReader)
            Catch ex As Exception

            End Try
        End If
        Return MyDataTable
    End Function
End Module

