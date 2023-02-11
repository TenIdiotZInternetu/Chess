### [Chess](Chess.md 'Chess')

## CommentController Class

Responsible for printing information and warnings during the game

```csharp
public static class CommentController
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; CommentController

| Properties | |
| :--- | :--- |
| [PlayerOnMoveCursor](Chess.CommentController.PlayerOnMoveCursor.md 'Chess.CommentController.PlayerOnMoveCursor') | Position of cursor for comments requiring action from player |
| [TurnCursor](Chess.CommentController.TurnCursor.md 'Chess.CommentController.TurnCursor') | Position of cursor for printing turn number |
| [WarningCursor](Chess.CommentController.WarningCursor.md 'Chess.CommentController.WarningCursor') | Position of cursor for warnings as a reaction to invalid input |

| Methods | |
| :--- | :--- |
| [AddPadding(string)](Chess.CommentController.AddPadding(string).md 'Chess.CommentController.AddPadding(string)') | Adds whitespaces before text to align it to the center of window |
| [ResetComments()](Chess.CommentController.ResetComments().md 'Chess.CommentController.ResetComments()') | Clears all lines of comments |
| [ResetWarning()](Chess.CommentController.ResetWarning().md 'Chess.CommentController.ResetWarning()') | Clears the warning text |
| [Write50MoveRule()](Chess.CommentController.Write50MoveRule().md 'Chess.CommentController.Write50MoveRule()') | Prints "Draw by 50 Move Rule!" |
| [WriteCheck(Player)](Chess.CommentController.WriteCheck(Chess.Player).md 'Chess.CommentController.WriteCheck(Chess.Player)') | Prints "[player] is in check!" |
| [WriteCheckmate(Player)](Chess.CommentController.WriteCheckmate(Chess.Player).md 'Chess.CommentController.WriteCheckmate(Chess.Player)') | Prints "Checkmate! [player] wins!" |
| [WriteInsufficientMaterial()](Chess.CommentController.WriteInsufficientMaterial().md 'Chess.CommentController.WriteInsufficientMaterial()') | Prints "Draw by Insufficient Material" |
| [WritePlayerOnMove(Player)](Chess.CommentController.WritePlayerOnMove(Chess.Player).md 'Chess.CommentController.WritePlayerOnMove(Chess.Player)') | Prints "[player] to move" |
| [WritePromotionComment()](Chess.CommentController.WritePromotionComment().md 'Chess.CommentController.WritePromotionComment()') | Prints "Choose piece to promote to (K, Q, R, B)" |
| [WriteRepetition()](Chess.CommentController.WriteRepetition().md 'Chess.CommentController.WriteRepetition()') | Prints "Draw by Repetition" |
| [WriteStalemate()](Chess.CommentController.WriteStalemate().md 'Chess.CommentController.WriteStalemate()') | Prints "Stalemate! No One Wins!" |
| [WriteTurnNumber(int)](Chess.CommentController.WriteTurnNumber(int).md 'Chess.CommentController.WriteTurnNumber(int)') | Prints "Move [moveNumber]" |
| [WriteWarning(string)](Chess.CommentController.WriteWarning(string).md 'Chess.CommentController.WriteWarning(string)') | Prints warning about invalid input |
