Imports System
Imports System.IO
Imports System.Net
Imports System.Reflection

Module ModMain

    Sub Main(args As String())
        Try
            Dim StartupPath As String = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)
            Dim DownloadContent As String = IO.File.ReadAllText(StartupPath & "\Download.txt")
            Dim wc As New WebClient
            For Each Line In DownloadContent.Split(vbCrLf).Where(Function(l) l.Contains(vbTab))
                Dim Columns As List(Of String) = Line.Split(vbTab).ToList
                Dim sURL = Columns(0)
                Dim FileName As String = Columns(Columns.Count - 1)
                If FileName.Trim.Length = 0 Then
                    FileName = Guid.NewGuid.ToString.Split("-")(0)
                End If
                wc.DownloadFile(sURL, StartupPath & "\" & FileName)
            Next
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub
End Module
