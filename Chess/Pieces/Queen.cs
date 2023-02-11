using System.Numerics;

namespace Chess;

/// <summary>
/// Represents the Queen Piece type
/// </summary>
public class Queen : Piece
{
    /// <inheritdoc/>
    protected override string Symbol => "Q";
    
    /// <inheritdoc/>
    protected override Vector2[] ShiftVectors => new[]
    {
        new Vector2(0, 1), new Vector2(0, -1),
        new Vector2(1, 0), new Vector2(-1, 0),
        new Vector2(1, 1), new Vector2(-1, -1),
        new Vector2(1, -1), new Vector2(-1, 1)
    };
    
    /// <inheritdoc/>
    public Queen(Player owner, int xPosition, int yPosition) 
        : base(owner, xPosition, yPosition) {}
}