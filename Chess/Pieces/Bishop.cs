using System.Numerics;

namespace Chess;

/// <summary>
/// Represents the Bishop Piece type
/// </summary>
public class Bishop : Piece
{
    /// <inheritdoc/>
    protected override string Symbol => "B";

    /// <inheritdoc/>
    protected override Vector2[] ShiftVectors => new[]
    {
        new Vector2(1, 1), new Vector2(-1, -1),
        new Vector2(1, -1), new Vector2(-1, 1)
    };

    /// <inheritdoc/>
    public Bishop(Player owner, int xPosition, int yPosition) 
        : base(owner, xPosition, yPosition) {}
    
}