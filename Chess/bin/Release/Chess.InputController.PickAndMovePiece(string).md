### [Chess](Chess.md 'Chess').[InputController](Chess.InputController.md 'Chess.InputController')

## InputController.PickAndMovePiece(string) Method

Picks up a Piece and moves it to a square chosen by the player

```csharp
private static void PickAndMovePiece(string input);
```
#### Parameters

<a name='Chess.InputController.PickAndMovePiece(string).input'></a>

`input` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Player's primary input

#### Exceptions

[System.UnauthorizedAccessException](https://docs.microsoft.com/en-us/dotnet/api/System.UnauthorizedAccessException 'System.UnauthorizedAccessException')  
Player chose a Piece not of his color

[System.ArgumentOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException')  
Player chose a square that is not one of their legal moves