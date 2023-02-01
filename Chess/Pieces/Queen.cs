using System.Numerics;

namespace Chess;

public class Queen : Piece
{
    protected override string Symbol => "Q";
    protected override Vector2[] ShiftVectors => new[]
    {
        new Vector2(0, 1), new Vector2(0, -1),
        new Vector2(1, 0), new Vector2(-1, 0),
        new Vector2(1, 1), new Vector2(-1, -1),
        new Vector2(1, -1), new Vector2(-1, 1)
    };
    public Queen(ConsoleColor color, int xPosition, int yPosition) 
        : base(color, xPosition, yPosition) {}
}