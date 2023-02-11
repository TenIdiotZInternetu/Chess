### [Chess](Chess.md 'Chess').[King](Chess.King.md 'Chess.King')

## King.IsSquareSafe(Vector2) Method

Checks if the King cannot be captured on the given position in the next turn

```csharp
private static bool IsSquareSafe(System.Numerics.Vector2 position);
```
#### Parameters

<a name='Chess.King.IsSquareSafe(System.Numerics.Vector2).position'></a>

`position` [System.Numerics.Vector2](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector2 'System.Numerics.Vector2')

Coordinates of the checked square

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
True if the King won't get captured