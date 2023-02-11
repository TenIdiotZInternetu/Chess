### [Chess](Chess.md 'Chess').[Board](Chess.Board.md 'Chess.Board')

## Board.PutPiece(Piece) Method

Places Piece on the board with position given by the Position property of the Piece.  
Piece is removed from its previous position.  
Any Piece previously occupying the square is removed from the game.

```csharp
public static void PutPiece(Chess.Piece piece);
```
#### Parameters

<a name='Chess.Board.PutPiece(Chess.Piece).piece'></a>

`piece` [Piece](Chess.Piece.md 'Chess.Piece')

Piece to be put on the board