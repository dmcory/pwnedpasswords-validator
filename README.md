# VB.NET wrapper

> My password has been pwned?

This wrapper uses Troy Hunt's [have i been pwned?](https://haveibeenpwned.com) API to verify if your password has been exposed. 

Obviously, we don't sent the password through the internet, the API uses something called [k-Anonymity](https://blog.cloudflare.com/validating-leaked-passwords-with-k-anonymity/) that in short-terms, allows us to send the first 5 characters  of a SHA-1 password and returns us a data set. (or nothing, if the password is not on internet :smile:)

## Contents
- [Setup](#setup)
- [How to Use](#how-to-use)
- [Contributing](#contributing)
- [Mole Masters](#mole-masters)
- [To-do List](#to-do-list)

## Setup
- Visual Studio
- Internet (to verify the password)

Just run the project in your Visual Studio and that's it! :sunny:

## How To Use
```
Dim helper As New Password_helper
Dim hitCount = helper.GetData('qwerty').GetAwaiter.GetResult
If hitCount > 0 Then
  Console.WriteLine("Your password is exposed.")
Else
  Console.WriteLine("Your password is not exposed.")
End If
```

## Contributing
If you want to contribute or have an idea to make this library better, please create another branch.

## Mole Masters
+ [Dark Mystical Cory](http://twitter.com/dmcory)

## To-do List
- [ ] Nothing yet :squirrel:
