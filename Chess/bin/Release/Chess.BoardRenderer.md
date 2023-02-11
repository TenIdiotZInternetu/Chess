### [Chess](Chess.md 'Chess')

## BoardRenderer Class

Is Responsible for printing the Board to the Console

```csharp
public static class BoardRenderer
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; BoardRenderer

| Fields | |
| :--- | :--- |
| [BoardXPosition](Chess.BoardRenderer.BoardXPosition.md 'Chess.BoardRenderer.BoardXPosition') | X position of the top left corner of the Board |
| [BoardYPosition](Chess.BoardRenderer.BoardYPosition.md 'Chess.BoardRenderer.BoardYPosition') | Y position of the top left corner of the Board |

| Methods | |
| :--- | :--- |
| [RenderBoard()](Chess.BoardRenderer.RenderBoard().md 'Chess.BoardRenderer.RenderBoard()') | Print the whole Board with Pieces to the Console |
| [RenderCoordinates()](Chess.BoardRenderer.RenderCoordinates().md 'Chess.BoardRenderer.RenderCoordinates()') | Prints the numbers of the ranks and the letters of the files to the Console |
| [RenderSquare(int, int, ConsoleColor)](Chess.BoardRenderer.RenderSquare(int,int,System.ConsoleColor).md 'Chess.BoardRenderer.RenderSquare(int, int, System.ConsoleColor)') | Render single Square with Piece occupying it to the Console |
| [RenderSquare(Vector2, ConsoleColor)](Chess.BoardRenderer.RenderSquare(System.Numerics.Vector2,System.ConsoleColor).md 'Chess.BoardRenderer.RenderSquare(System.Numerics.Vector2, System.ConsoleColor)') | Render single Square with Piece occupying it to the Console |
