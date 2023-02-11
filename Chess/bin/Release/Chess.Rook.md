### [Chess](Chess.md 'Chess')

## Rook Class

Represents the Queen Piece type

```csharp
public class Rook : Chess.Piece
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Piece](Chess.Piece.md 'Chess.Piece') &#129106; Rook

| Constructors | |
| :--- | :--- |
| [Rook(Player, int, int)](Chess.Rook.Rook(Chess.Player,int,int).md 'Chess.Rook.Rook(Chess.Player, int, int)') | Represents a single Piece on the Board |

| Fields | |
| :--- | :--- |
| [Moved](Chess.Rook.Moved.md 'Chess.Rook.Moved') | True if the Rook has moved at least once during the game |

| Properties | |
| :--- | :--- |
| [ShiftVectors](Chess.Rook.ShiftVectors.md 'Chess.Rook.ShiftVectors') | Assigned to Queen, Rook and Bishop. Contains all possible directions of movement. |
| [Symbol](Chess.Rook.Symbol.md 'Chess.Rook.Symbol') | Character to be used when printing the Piece |

| Methods | |
| :--- | :--- |
| [Move(Vector2)](Chess.Rook.Move(System.Numerics.Vector2).md 'Chess.Rook.Move(System.Numerics.Vector2)') | Responsible for all property changes when the Piece is moved |
