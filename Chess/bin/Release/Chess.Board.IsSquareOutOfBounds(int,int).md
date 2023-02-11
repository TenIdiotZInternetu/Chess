### [Chess](Chess.md 'Chess').[Board](Chess.Board.md 'Chess.Board')

## Board.IsSquareOutOfBounds(int, int) Method

Checks if the given coordinates are a valid square within the board.

```csharp
public static bool IsSquareOutOfBounds(int x, int y);
```
#### Parameters

<a name='Chess.Board.IsSquareOutOfBounds(int,int).x'></a>

`x` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

File (Column) of the square

<a name='Chess.Board.IsSquareOutOfBounds(int,int).y'></a>

`y` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Rank (Row) of the square

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
True if the square doesn't lie on the Board