### [Chess](Chess.md 'Chess')

## GameOver Class

Responsible for checking whether the game should end or not

```csharp
public static class GameOver
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; GameOver

| Fields | |
| :--- | :--- |
| [_boardStates](Chess.GameOver._boardStates.md 'Chess.GameOver._boardStates') | Stores how many times the current board state has been reached |
| [_fiftyMoveCounter](Chess.GameOver._fiftyMoveCounter.md 'Chess.GameOver._fiftyMoveCounter') | Counts the number of moves without a capture or pawn move |

| Methods | |
| :--- | :--- |
| [GameIsOver()](Chess.GameOver.GameIsOver().md 'Chess.GameOver.GameIsOver()') | Checks if the players reached either a draw or a win |
| [IncreaseFiftyMoveCounter()](Chess.GameOver.IncreaseFiftyMoveCounter().md 'Chess.GameOver.IncreaseFiftyMoveCounter()') | Increase counter counting towards 50 move draw. |
| [ResetFiftyMoveCounter()](Chess.GameOver.ResetFiftyMoveCounter().md 'Chess.GameOver.ResetFiftyMoveCounter()') | Resets the counter counting towards 50 move draw.<br/>Also resets saved board states, since they cannot be reached again. |
| [SaveBoardState()](Chess.GameOver.SaveBoardState().md 'Chess.GameOver.SaveBoardState()') | Save current board state. Count how many times the state has been reached. |
