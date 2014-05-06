Imports System.Data.OleDb

Module ExcelUtilities
    Public Function GetWorksheetsFromWorkbook(ExcelConnection As OleDbConnection) As DataTable
        'Get the data table containg the schema guid.
        Dim dt As DataTable = ExcelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
        Return dt

    End Function
End Module
