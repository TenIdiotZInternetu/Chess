using System.Numerics;

namespace Chess;

/// <summary>
/// Represents the Knight Piece type
/// </summary>
public class Knight : Piece
{
    /// <inheritdoc/>
    protected override string Symbol => "K";
    //cringe one
    
    /// <inheritdoc/>
    public Knight(Player owner, int xPosition, int yPosition) 
        : base(owner, xPosition, yPosition) {}
    
    /// <inheritdoc/>
    public override void GetVision()
    {
        Vision = new List<Vector2>();
        
        Vector2[] shiftVectors = {
            new Vector2(2, 1), new Vector2(-2, -1),
            new Vector2(2, -1), new Vector2(-2, 1),
            new Vector2(1, 2), new Vector2(1, -2),
            new Vector2(-1, 2), new Vector2(-1, -2)
        };

        foreach (var vector in shiftVectors)
        {
            Vector2 searchedPosition = Position;
            searchedPosition += vector;
            
            if (Board.IsSquareOutOfBounds(searchedPosition))
                continue;
            
            if (Board.IsPieceOppositeColor(this, searchedPosition) ||
                Board.IsSquareFree(searchedPosition))
            {
                Vision.Add(searchedPosition);
            }
        }
    }
}