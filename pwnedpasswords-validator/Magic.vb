Module Magic
    Public Property helper As password_helper
    Sub Main()
        Console.WriteLine("Enter a password to check")
        Dim pwd As String = Console.ReadLine
        If String.IsNullOrWhiteSpace(pwd) Then Console.WriteLine("Please specify a password to check") : Console.ReadKey()
        Console.WriteLine("Checking password...")

    End Sub

End Module
