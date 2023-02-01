using System.Numerics;

namespace Chess;

public class Bishop : Piece
{
    protected override string Symbol => "B";

    protected override Vector2[] ShiftVectors => new[]
    {
        new Vector2(1, 1), new Vector2(-1, -1),
        new Vector2(1, -1), new Vector2(-1, 1)
    };

    public Bishop(ConsoleColor color, int xPosition, int yPosition) 
        : base(color, xPosition, yPosition) {}
    
}