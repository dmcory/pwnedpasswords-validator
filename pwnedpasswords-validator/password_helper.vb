Imports System.Net.Http
Imports System.Security.Cryptography
Imports System.Text

Public Class password_helper
    Private Const apiUrl As String = "https://api.pwnedpasswords.com/range/"
    Private Shared ReadOnly httpClient As HttpClient = New HttpClient

    Public Async Function Req(ByVal pwd As String) As Task(Of List(Of String))

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
