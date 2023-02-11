### [Chess](Chess.md 'Chess').[Board](Chess.Board.md 'Chess.Board')

## Board.PickPiece(int, int) Method

Draws all legal moves of the Piece at the given position.  
The Piece is expected to move to one of the drawn squares.

```csharp
public static Chess.Piece PickPiece(int x, int y);
```
#### Parameters

<a name='Chess.Board.PickPiece(int,int).x'></a>

`x` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

File (Column) of the Piece

<a name='Chess.Board.PickPiece(int,int).y'></a>

`y` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Rank (Row) of the Piece

#### Returns
[Piece](Chess.Piece.md 'Chess.Piece')  
Piece at the given Position