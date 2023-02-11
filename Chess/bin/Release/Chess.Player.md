### [Chess](Chess.md 'Chess')

## Player Class

Represents one of the users playing the game

```csharp
public class Player
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Player

| Constructors | |
| :--- | :--- |
| [Player(ConsoleColor)](Chess.Player.Player(System.ConsoleColor).md 'Chess.Player.Player(System.ConsoleColor)') | Represents one of the users playing the game |

| Fields | |
| :--- | :--- |
| [_printColor](Chess.Player._printColor.md 'Chess.Player._printColor') | Color of to be printed in the console |
| [Color](Chess.Player.Color.md 'Chess.Player.Color') | Symbolic color of the player |
| [ControlledPieces](Chess.Player.ControlledPieces.md 'Chess.Player.ControlledPieces') | All pieces on the board this player can move with |
| [King](Chess.Player.King.md 'Chess.Player.King') | King piece controlled by this player |
| [LegalMoves](Chess.Player.LegalMoves.md 'Chess.Player.LegalMoves') | All squares pieces of this player can move to this turn |
| [Threats](Chess.Player.Threats.md 'Chess.Player.Threats') | All opponent's pieces giving a check to this player's king |

| Properties | |
| :--- | :--- |
| [CurrentPlayer](Chess.Player.CurrentPlayer.md 'Chess.Player.CurrentPlayer') | Player that is currently making a move |
| [IdlePlayer](Chess.Player.IdlePlayer.md 'Chess.Player.IdlePlayer') | Player waiting for the opponent to make a move |
| [IsDoubleChecked](Chess.Player.IsDoubleChecked.md 'Chess.Player.IsDoubleChecked') | True if the player's king is checked by two pieces at once |
| [IsInCheck](Chess.Player.IsInCheck.md 'Chess.Player.IsInCheck') | True if the player's king is in check |
| [Opponent](Chess.Player.Opponent.md 'Chess.Player.Opponent') | Player who is playing against this player |

| Methods | |
| :--- | :--- |
| [FindLegalMoves()](Chess.Player.FindLegalMoves().md 'Chess.Player.FindLegalMoves()') | Finds all squares pieces of this player can move to this turn |
| [PrintName()](Chess.Player.PrintName().md 'Chess.Player.PrintName()') | Prints the player's color in the console. Color of the text is player's _printColor |
