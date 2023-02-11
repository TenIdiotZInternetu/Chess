### [Chess](Chess.md 'Chess')

## King Class

Represents the King piece

```csharp
public class King : Chess.Piece
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [Piece](Chess.Piece.md 'Chess.Piece') &#129106; King

| Constructors | |
| :--- | :--- |
| [King(Player, int, int)](Chess.King.King(Chess.Player,int,int).md 'Chess.King.King(Chess.Player, int, int)') | Represents a single Piece on the Board |

## King(Player, int, int) Constructor

Represents a single Piece on the Board

```csharp
public King(Chess.Player owner, int xPosition, int yPosition);
```
#### Parameters

<a name='Chess.King.King(Chess.Player,int,int).owner'></a>

`owner` [Player](Chess.Player.md 'Chess.Player')

Player that controls this Piece

<a name='Chess.King.King(Chess.Player,int,int).xPosition'></a>

`xPosition` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

File (column) this Piece starts at

<a name='Chess.King.King(Chess.Player,int,int).yPosition'></a>

`yPosition` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Rank (row) this Piece starts at

| Fields | |
| :--- | :--- |
| [_moved](Chess.King._moved.md 'Chess.King._moved') | True if the King has moved at least once during the game |

## King._moved Field

True if the King has moved at least once during the game

```csharp
private bool _moved;
```

#### Field Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

| Properties | |
| :--- | :--- |
| [Symbol](Chess.King.Symbol.md 'Chess.King.Symbol') | Character to be used when printing the Piece |

### [Chess](Chess.md 'Chess').[King](Chess.King.md 'Chess.King')

## King.Symbol Property

Character to be used when printing the Piece

```csharp
protected override string Symbol => "±"
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

| Methods | |
| :--- | :--- |
| [CanCastleLeft()](Chess.King.CanCastleLeft().md 'Chess.King.CanCastleLeft()') | Checks if the King can castle to the C file.<br/>Rook must be able to move to the D file. |
| [CanCastleRight()](Chess.King.CanCastleRight().md 'Chess.King.CanCastleRight()') | Checks if the King can castle to the G file.<br/>Rook must be able to move to the F file. |
| [FindLegalMoves()](Chess.King.FindLegalMoves().md 'Chess.King.FindLegalMoves()') | Finds all squares this piece is able to move to this turn |
| [GetWalkableSquares()](Chess.King.GetWalkableSquares().md 'Chess.King.GetWalkableSquares()') | Yields all the squares with distance 1 from the King |
| [IsSquareSafe(Vector2)](Chess.King.IsSquareSafe(System.Numerics.Vector2).md 'Chess.King.IsSquareSafe(System.Numerics.Vector2)') | Checks if the King cannot be captured on the given position in the next turn |
| [Move(Vector2)](Chess.King.Move(System.Numerics.Vector2).md 'Chess.King.Move(System.Numerics.Vector2)') | Responsible for all property changes when the Piece is moved |
| [RookIsPresent(Vector2)](Chess.King.RookIsPresent(System.Numerics.Vector2).md 'Chess.King.RookIsPresent(System.Numerics.Vector2)') | Checks if the Rook stands on the given position |

## King.CanCastleLeft() Method

Checks if the King can castle to the C file.  
Rook must be able to move to the D file.

```csharp
private bool CanCastleLeft();
```

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
True if such maneuver is possible

## King.CanCastleRight() Method

Checks if the King can castle to the G file.  
Rook must be able to move to the F file.

```csharp
private bool CanCastleRight();
```

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
True if such maneuver is possible

## King.FindLegalMoves() Method

Finds all squares this piece is able to move to this turn

```csharp
public override void FindLegalMoves();
```

## King.GetWalkableSquares() Method

Yields all the squares with distance 1 from the King

```csharp
private System.Collections.Generic.IEnumerable<System.Numerics.Vector2> GetWalkableSquares();
```

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Numerics.Vector2](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector2 'System.Numerics.Vector2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
Coordinates of a square with a distance 1 from the King

## King.Move(Vector2) Method

Responsible for all property changes when the Piece is moved

```csharp
public override void Move(System.Numerics.Vector2 position);
```
#### Parameters

<a name='Chess.King.Move(System.Numerics.Vector2).position'></a>

`position` [System.Numerics.Vector2](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector2 'System.Numerics.Vector2')

## King.RookIsPresent(Vector2) Method

Checks if the Rook stands on the given position

```csharp
private static bool RookIsPresent(System.Numerics.Vector2 position);
```
#### Parameters

<a name='Chess.King.RookIsPresent(System.Numerics.Vector2).position'></a>

`position` [System.Numerics.Vector2](https://docs.microsoft.com/en-us/dotnet/api/System.Numerics.Vector2 'System.Numerics.Vector2')

The Coordinates of a square the rook should stand on

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
True if the Rook stands on the given position