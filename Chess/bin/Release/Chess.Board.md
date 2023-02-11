### [Chess](Chess.md 'Chess')

## Board Class

Represents status of each square on the Board. Is Responsible for Piece movement.

```csharp
public static class Board
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Board

| Properties | |
| :--- | :--- |
| [Pieces](Chess.Board.Pieces.md 'Chess.Board.Pieces') | Gets the Board as a 2D array of Pieces |

| Methods | |
| :--- | :--- |
| [GetPiece(int, int)](Chess.Board.GetPiece(int,int).md 'Chess.Board.GetPiece(int, int)') | Returns the piece at the given position on the board |
| [GetPiece(Vector2)](Chess.Board.GetPiece(System.Numerics.Vector2).md 'Chess.Board.GetPiece(System.Numerics.Vector2)') | Returns the piece at the given position on the board |
| [IsPieceOppositeColor(Piece, Vector2)](Chess.Board.IsPieceOppositeColor(Chess.Piece,System.Numerics.Vector2).md 'Chess.Board.IsPieceOppositeColor(Chess.Piece, System.Numerics.Vector2)') | Checks if the square on the given position is occupied by a Piece of opposite color. |
| [IsSquareFree(Vector2)](Chess.Board.IsSquareFree(System.Numerics.Vector2).md 'Chess.Board.IsSquareFree(System.Numerics.Vector2)') | Checks if the square on the given position is occupied by any Piece |
| [IsSquareOutOfBounds(int, int)](Chess.Board.IsSquareOutOfBounds(int,int).md 'Chess.Board.IsSquareOutOfBounds(int, int)') | Checks if the given coordinates are a valid square within the board. |
| [IsSquareOutOfBounds(Vector2)](Chess.Board.IsSquareOutOfBounds(System.Numerics.Vector2).md 'Chess.Board.IsSquareOutOfBounds(System.Numerics.Vector2)') | Checks if the given coordinates are a valid square within the board. |
| [NormalizeBoard()](Chess.Board.NormalizeBoard().md 'Chess.Board.NormalizeBoard()') | Converts board to string representation, where first 8 characters are the eight rank,<br/>last 8 characters are the first rank.<br/>Each character represents a piece,<br/>0 represents empty square |
| [PickPiece(Piece)](Chess.Board.PickPiece(Chess.Piece).md 'Chess.Board.PickPiece(Chess.Piece)') | Draws all legal moves of the Piece at the given position.<br/>The Piece is expected to move to one of the drawn squares. |
| [PickPiece(int, int)](Chess.Board.PickPiece(int,int).md 'Chess.Board.PickPiece(int, int)') | Draws all legal moves of the Piece at the given position.<br/>The Piece is expected to move to one of the drawn squares. |
| [PutPiece(Piece)](Chess.Board.PutPiece(Chess.Piece).md 'Chess.Board.PutPiece(Chess.Piece)') | Places Piece on the board with position given by the Position property of the Piece.<br/>Piece is removed from its previous position.<br/>Any Piece previously occupying the square is removed from the game. |
| [RemovePiece(int, int)](Chess.Board.RemovePiece(int,int).md 'Chess.Board.RemovePiece(int, int)') | Removes Piece from the given square. |
| [RemovePiece(Vector2)](Chess.Board.RemovePiece(System.Numerics.Vector2).md 'Chess.Board.RemovePiece(System.Numerics.Vector2)') | Removes Piece from the given square. |
| [SetDefaultPiecePositions()](Chess.Board.SetDefaultPiecePositions().md 'Chess.Board.SetDefaultPiecePositions()') | Initiates all Pieces and puts them on the board in their starting positions. |
