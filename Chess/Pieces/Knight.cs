using System.Numerics;

namespace Chess;

public class Knight : Piece
{
    protected override string Symbol => "K";
    //cringe one
    public Knight(Player owner, int xPosition, int yPosition) 
        : base(owner, xPosition, yPosition) {}
    
    public override void FindLegalMoves()
    {
        LegalMoves = new List<Vector2>();
        
        if (Owner.Threats.Count > 1)
            return;
        
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

            bool doesntLoseKing = !Owner.IsInCheck ||
                                  BlocksCheck(searchedPosition) ||
                                  CapturesThreat(searchedPosition);
            
            if ((Board.IsPieceOppositeColor(this, searchedPosition) ||
                Board.IsSquareFree(searchedPosition)) &&
                doesntLoseKing)
            {
                LegalMoves.Add(searchedPosition);
            }
        }
    }
}