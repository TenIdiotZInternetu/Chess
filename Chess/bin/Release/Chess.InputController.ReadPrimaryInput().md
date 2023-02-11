### [Chess](Chess.md 'Chess').[InputController](Chess.InputController.md 'Chess.InputController')

## InputController.ReadPrimaryInput() Method

Awaits player's first input and chooses appropriate response

```csharp
private static string ReadPrimaryInput();
```

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
Player's input

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
Player's input was empty

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
The input was of invalid format