### [Chess](Chess.md 'Chess')

## Pawn Class

Represents the Pawn Piece type

```csharp
public class Pawn : Chess.Piece
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Piece](Chess.Piece.md 'Chess.Piece') &#129106; Pawn

| Constructors | |
| :--- | :--- |
| [Pawn(Player, int, int)](Chess.Pawn.Pawn(Chess.Player,int,int).md 'Chess.Pawn.Pawn(Chess.Player, int, int)') | Represents a single Piece on the Board |

| Fields | |
| :--- | :--- |
| [_canBeEnPassant](Chess.Pawn._canBeEnPassant.md 'Chess.Pawn._canBeEnPassant') | True if the Pawn can be captured by en passant |
| [_moved](Chess.Pawn._moved.md 'Chess.Pawn._moved') | True if the Pawn has moved at least once during the game |
| [_yDirection](Chess.Pawn._yDirection.md 'Chess.Pawn._yDirection') | Vertical direction in which the Pawn can move |

| Properties | |
| :--- | :--- |
| [AttackedSquares](Chess.Pawn.AttackedSquares.md 'Chess.Pawn.AttackedSquares') | Squares on which an opponent's Piece can be captured (once present) by this Pawn |
| [Symbol](Chess.Pawn.Symbol.md 'Chess.Pawn.Symbol') | Character to be used when printing the Piece |

| Methods | |
| :--- | :--- |
| [CanCapture(Vector2)](Chess.Pawn.CanCapture(System.Numerics.Vector2).md 'Chess.Pawn.CanCapture(System.Numerics.Vector2)') | Checks if the Pawn can capture a Piece on the given square |
| [CanEnPassant(Vector2)](Chess.Pawn.CanEnPassant(System.Numerics.Vector2).md 'Chess.Pawn.CanEnPassant(System.Numerics.Vector2)') | Checks if the Pawn can capture an opponent's Pawn by en passant |
| [CheckForwardMove()](Chess.Pawn.CheckForwardMove().md 'Chess.Pawn.CheckForwardMove()') | Checks and adds legal move if the Pawn can move 1 square forward |
| [CheckForwardTwoMove()](Chess.Pawn.CheckForwardTwoMove().md 'Chess.Pawn.CheckForwardTwoMove()') | Checks and adds legal move if the Pawn can move 2 squares forward |
| [GetVision()](Chess.Pawn.GetVision().md 'Chess.Pawn.GetVision()') | Finds all squares this piece could move to if it didn't endanger the king |
| [Move(Vector2)](Chess.Pawn.Move(System.Numerics.Vector2).md 'Chess.Pawn.Move(System.Numerics.Vector2)') | Responsible for all property changes when the Piece is moved |
| [Promote()](Chess.Pawn.Promote().md 'Chess.Pawn.Promote()') | Asks the Player for a Piece to promote the Pawn to and replaces the Pawn with the new Piece |
