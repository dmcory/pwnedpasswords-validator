Module Magic
    Public Property helper As Password_helper = New Password_helper
    Sub Main()
        Console.WriteLine("Please provide a password to check it")
        Dim pwd As String = Console.ReadLine
        If String.IsNullOrWhiteSpace(pwd) Then Console.WriteLine("Please specify a password to check") : Console.ReadKey()
        Console.WriteLine("Let's begin...")
        Dim hitCount As Integer = helper.GetData(pwd).GetAwaiter.GetResult
        Select Case hitCount
            Case -1
                Console.WriteLine("Troy don't want to help you :( (Something happen)") 'API error
            Case 0
                Console.WriteLine("Yay! Your password is not in the internet :D (for now)")
            Case Else
                Console.WriteLine($"Oh no, your password has been found {hitCount} {If(hitCount > 1, "times", "time") } on the internet :(")
        End Select
        Console.ReadKey()
    End Sub

End Module
