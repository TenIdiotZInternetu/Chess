using System.Numerics;

namespace Chess;

public class Rook : Piece
{
    protected override string Symbol => "R";
    protected override Vector2[] ShiftVectors => new[] 
    {
        new Vector2(0, 1), new Vector2(0, -1),
        new Vector2(1, 0), new Vector2(-1, 0),
    };
    
    private bool _moved = true;
    
    public Rook(ConsoleColor color, int xPosition, int yPosition) 
        : base(color, xPosition, yPosition) {}
}