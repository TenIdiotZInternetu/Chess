### [Chess](Chess.md 'Chess')

## InputController Class

Responsible for reading input from the console and choosing appropriate response.

```csharp
public static class InputController
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; InputController

| Properties | |
| :--- | :--- |
| [PrimaryInputCursor](Chess.InputController.PrimaryInputCursor.md 'Chess.InputController.PrimaryInputCursor') | Position of cursor for primary input |
| [ResolveInput](Chess.InputController.ResolveInput.md 'Chess.InputController.ResolveInput') | Method responsible for creating appropriate response to input |
| [SecondaryInputCursor](Chess.InputController.SecondaryInputCursor.md 'Chess.InputController.SecondaryInputCursor') | Position of cursor for choosing a square to move to |

| Methods | |
| :--- | :--- |
| [AskForLegalMove(Piece)](Chess.InputController.AskForLegalMove(Chess.Piece).md 'Chess.InputController.AskForLegalMove(Chess.Piece)') | Prints the type of chosen Piece and asks the player to choose a square to move to |
| [AskForPromotion()](Chess.InputController.AskForPromotion().md 'Chess.InputController.AskForPromotion()') | Awaits player to choose a piece type to promote to. "Q", "K", "B", "R" are expected inputs. |
| [IsValidSquare(string)](Chess.InputController.IsValidSquare(string).md 'Chess.InputController.IsValidSquare(string)') | Checks if the input has the format of one of the squares on the board |
| [PickAndMovePiece(string)](Chess.InputController.PickAndMovePiece(string).md 'Chess.InputController.PickAndMovePiece(string)') | Picks up a Piece and moves it to a square chosen by the player |
| [ReadInputAndConfirm()](Chess.InputController.ReadInputAndConfirm().md 'Chess.InputController.ReadInputAndConfirm()') | Reads input and handles it |
| [ReadPrimaryInput()](Chess.InputController.ReadPrimaryInput().md 'Chess.InputController.ReadPrimaryInput()') | Awaits player's first input and chooses appropriate response |
| [ResetInput()](Chess.InputController.ResetInput().md 'Chess.InputController.ResetInput()') | Clears the input line |
