### [Chess](Chess.md 'Chess')

## Piece Class

Represents a single Piece on the Board

```csharp
public abstract class Piece
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Piece

Derived  
&#8627; [Bishop](Chess.Bishop.md 'Chess.Bishop')  
&#8627; [King](Chess.King.md 'Chess.King')  
&#8627; [Knight](Chess.Knight.md 'Chess.Knight')  
&#8627; [Pawn](Chess.Pawn.md 'Chess.Pawn')  
&#8627; [Queen](Chess.Queen.md 'Chess.Queen')  
&#8627; [Rook](Chess.Rook.md 'Chess.Rook')

| Constructors | |
| :--- | :--- |
| [Piece(Player, int, int)](Chess.Piece.Piece(Chess.Player,int,int).md 'Chess.Piece.Piece(Chess.Player, int, int)') | Represents a single Piece on the Board |

| Fields | |
| :--- | :--- |
| [Color](Chess.Piece.Color.md 'Chess.Piece.Color') | Color to be used when printing the Piece |
| [Owner](Chess.Piece.Owner.md 'Chess.Piece.Owner') | Player that controls the Piece |
| [Position](Chess.Piece.Position.md 'Chess.Piece.Position') | Coordinate vector with file and rank of the Piece |

| Properties | |
| :--- | :--- |
| [IsLongRange](Chess.Piece.IsLongRange.md 'Chess.Piece.IsLongRange') | True for Queen, Rook and Bishop |
| [LegalMoves](Chess.Piece.LegalMoves.md 'Chess.Piece.LegalMoves') | All square this piece is able to move to this turn |
| [ShiftVectors](Chess.Piece.ShiftVectors.md 'Chess.Piece.ShiftVectors') | Assigned to Queen, Rook and Bishop. Contains all possible directions of movement. |
| [Symbol](Chess.Piece.Symbol.md 'Chess.Piece.Symbol') | Character to be used when printing the Piece |
| [Vision](Chess.Piece.Vision.md 'Chess.Piece.Vision') | All squares this piece could move to if it didn't endanger the king |

| Methods | |
| :--- | :--- |
| [BlocksCheck(Vector2)](Chess.Piece.BlocksCheck(System.Numerics.Vector2).md 'Chess.Piece.BlocksCheck(System.Numerics.Vector2)') | Checks if the Piece interferes opponent's attack |
| [CapturesThreat(Vector2)](Chess.Piece.CapturesThreat(System.Numerics.Vector2).md 'Chess.Piece.CapturesThreat(System.Numerics.Vector2)') | Checks if the captured Piece is the one delivering the check |
| [ExposesKing()](Chess.Piece.ExposesKing().md 'Chess.Piece.ExposesKing()') | Checks if moving the Piece would expose the king to Check |
| [FindLegalMoves()](Chess.Piece.FindLegalMoves().md 'Chess.Piece.FindLegalMoves()') | Finds all squares this piece is able to move to this turn |
| [GetVision()](Chess.Piece.GetVision().md 'Chess.Piece.GetVision()') | Finds all squares this piece could move to if it didn't endanger the king |
| [Move(Vector2)](Chess.Piece.Move(System.Numerics.Vector2).md 'Chess.Piece.Move(System.Numerics.Vector2)') | Responsible for all property changes when the Piece is moved |
