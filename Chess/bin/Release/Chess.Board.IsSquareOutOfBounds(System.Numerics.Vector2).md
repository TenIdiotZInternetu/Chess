### [Chess](Chess.md 'Chess').[Board](Chess.Board.md 'Chess.Board')

## Board.IsSquareOutOfBounds(Vector2) Method

Checks if the given coordinates are a valid square within the board.

```csharp
public static bool IsSquareOutOfBounds(System.Numerics.Vector2 position);
```
#### Parameters

<a name='Chess.Board.IsSquareOutOfBounds(System.Numerics.Vector2).position'></a>

`position` [System.Numerics.Vector2](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector2 'System.Numerics.Vector2')

Coordinate vector with file and rank of the square

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
True if the square doesn't lie on the Board