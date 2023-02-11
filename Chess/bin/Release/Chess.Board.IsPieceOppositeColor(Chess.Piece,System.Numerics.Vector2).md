### [Chess](Chess.md 'Chess').[Board](Chess.Board.md 'Chess.Board')

## Board.IsPieceOppositeColor(Piece, Vector2) Method

Checks if the square on the given position is occupied by a Piece of opposite color.

```csharp
public static bool IsPieceOppositeColor(Chess.Piece attacker, System.Numerics.Vector2 position);
```
#### Parameters

<a name='Chess.Board.IsPieceOppositeColor(Chess.Piece,System.Numerics.Vector2).attacker'></a>

`attacker` [Piece](Chess.Piece.md 'Chess.Piece')

The Piece of which color should be opposite to the given square

<a name='Chess.Board.IsPieceOppositeColor(Chess.Piece,System.Numerics.Vector2).position'></a>

`position` [System.Numerics.Vector2](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector2 'System.Numerics.Vector2')

Coordinate vector with file and rank of the square

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
True if the Piece at given position is of opposite color to the attacker