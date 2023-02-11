### [Chess](Chess.md 'Chess').[InputController](Chess.InputController.md 'Chess.InputController')

## InputController.AskForLegalMove(Piece) Method

Prints the type of chosen Piece and asks the player to choose a square to move to

```csharp
private static System.Numerics.Vector2 AskForLegalMove(Chess.Piece pickedPiece);
```
#### Parameters

<a name='Chess.InputController.AskForLegalMove(Chess.Piece).pickedPiece'></a>

`pickedPiece` [Piece](Chess.Piece.md 'Chess.Piece')

The piece to be moved

#### Returns
[System.Numerics.Vector2](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector2 'System.Numerics.Vector2')  
Coordinate vector of the chosen square

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
Player's input was empty

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
The input was of invalid format