### [Chess](Chess.md 'Chess')

## Knight Class

Represents the Knight Piece type

```csharp
public class Knight : Chess.Piece
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Piece](Chess.Piece.md 'Chess.Piece') &#129106; Knight

| Constructors | |
| :--- | :--- |
| [Knight(Player, int, int)](Chess.Knight.Knight(Chess.Player,int,int).md 'Chess.Knight.Knight(Chess.Player, int, int)') | Represents a single Piece on the Board |

| Properties | |
| :--- | :--- |
| [Symbol](Chess.Knight.Symbol.md 'Chess.Knight.Symbol') | Character to be used when printing the Piece |

| Methods | |
| :--- | :--- |
| [GetVision()](Chess.Knight.GetVision().md 'Chess.Knight.GetVision()') | Finds all squares this piece could move to if it didn't endanger the king |
