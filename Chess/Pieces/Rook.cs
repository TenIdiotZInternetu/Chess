using System.Numerics;

namespace Chess;

public class Rook : Piece
{
    protected override string Symbol => "R";
    private bool _moved = false;
    protected override Vector2[] ShiftVectors => new[] 
    {
        new Vector2(0, 1), new Vector2(0, -1),
        new Vector2(1, 0), new Vector2(-1, 0),
    };
    
    public Rook(Player owner, int xPosition, int yPosition) 
        : base(owner, xPosition, yPosition) {}

    public override void Move(Vector2 position)
    {
        _moved = true;
        base.Move(position);
    }
}