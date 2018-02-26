Imports System.Net
Imports System.Net.Http
Imports System.Security.Cryptography
Imports System.Text

Public Class Password_helper
    Private Const pwd_apiUrl As String = "https://api.pwnedpasswords.com/range/"
    Private Shared ReadOnly httpClient As HttpClient = New HttpClient

    Public Async Function GetData(ByVal pwd As String) As Task(Of Integer)
        Dim pwd_hash = HashPassword(pwd), pwd_prefix = pwd_hash.Substring(0, 5), pwd_url = $"{pwd_apiUrl}{pwd_prefix}"
        Using response = Await httpClient.GetAsync(pwd_url)
            If response.StatusCode = HttpStatusCode.OK Then
                Dim content = Await response.Content.ReadAsStringAsync
                Dim lines = content.Split({vbCrLf}, StringSplitOptions.RemoveEmptyEntries)
                Dim exists = lines.FirstOrDefault(Function(x) $"{pwd_prefix}{x}".StartsWith(pwd_hash))
                If Not String.IsNullOrWhiteSpace(exists) Then Return Int32.Parse(exists.Split({":"}, StringSplitOptions.RemoveEmptyEntries).Last)
                Return 0
            Else
                Return -1
            End If
        End Using
    End Function

    Private Function HashPassword(ByVal pwd As String) As String
        Using sha As SHA1Managed = New SHA1Managed
            Dim hash = sha.ComputeHash(Encoding.UTF8.GetBytes(pwd)) : Dim sb = New StringBuilder(hash.Length * 2)
            For Each b As Byte In hash
                sb.Append(b.ToString("X2"))
            Next
            Return sb.ToString
        End Using
    End Function
End Class
