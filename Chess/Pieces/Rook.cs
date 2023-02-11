using System.Numerics;

namespace Chess;

/// <summary>
/// Represents the Queen Piece type
/// </summary>
public class Rook : Piece
{
    protected override string Symbol => "R";
    
    /// <summary>
    /// True if the Rook has moved at least once during the game
    /// </summary>
    public bool Moved = false;
    
    protected override Vector2[] ShiftVectors => new[] 
    {
        new Vector2(0, 1), new Vector2(0, -1),
        new Vector2(1, 0), new Vector2(-1, 0),
    };
    
    public Rook(Player owner, int xPosition, int yPosition) 
        : base(owner, xPosition, yPosition) {}

    public override void Move(Vector2 position)
    {
        Moved = true;
        base.Move(position);
    }
}