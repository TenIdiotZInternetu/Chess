using System.Numerics;
using Microsoft.VisualBasic;

namespace Chess;

public class King : Piece
{
    protected override string Symbol => Strings.ChrW(177).ToString();
    private bool _moved = false;
    public King(Player owner, int xPosition, int yPosition) 
        : base(owner, xPosition, yPosition) {}

    public override void FindLegalMoves()
    {
        LegalMoves = new List<Vector2>();
        
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0)
                    continue;
                
                Vector2 shiftVector = new Vector2(x, y);
                Vector2 destination = Position + shiftVector;
                
                if (Board.IsSquareFree(destination) || 
                    Board.IsPieceOppositeColor(this, destination))
                    LegalMoves.Add(destination);
            }
        }
    }

    public override void Move(Vector2 position)
    {
        _moved = true;
        base.Move(position);
    }
}