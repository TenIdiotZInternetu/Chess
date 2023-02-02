using System.Numerics;
using Microsoft.VisualBasic;

namespace Chess;

public class King : Piece
{
    protected override string Symbol => Strings.ChrW(177).ToString();
    private bool _moved = false;

    public King(Player owner, int xPosition, int yPosition)
        : base(owner, xPosition, yPosition)
    {
        owner.King = this;
    }

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
                
                if ((Board.IsSquareFree(destination) || 
                    Board.IsPieceOppositeColor(this, destination)) &&
                    IsSquareSafe(destination))
                    LegalMoves.Add(destination);
            }
        }
        
        if (CanCastleLeft())
            LegalMoves.Add(Position + new Vector2(-2, 0));
        
        if (CanCastleRight())
            LegalMoves.Add(Position + new Vector2(2, 0));
    }

    public override void Move(Vector2 position)
    {
        _moved = true;
        
        bool castledRight = Position - position == new Vector2(-2, 0);
        bool castledLeft = Position - position == new Vector2(2, 0);
        
        if (castledRight)
        {
            Rook rook = Board.GetPiece(Position + new Vector2(3, 0)) as Rook;
            rook.Move(Position + new Vector2(1, 0));
        }
        else if (castledLeft)
        {
            Rook rook = Board.GetPiece(Position + new Vector2(-4, 0)) as Rook;
            rook.Move(Position + new Vector2(-1, 0));
        }
        
        base.Move(position);
    }

    private bool CanCastleLeft()
    {
        if (_moved)
            return false;
        
        if (!RookIsPresent(Position + new Vector2(-4, 0)))
            return false;
        
        for (int x = -1; x >= -3; x--)
        {
            if (!Board.IsSquareFree(Position + new Vector2(x, 0)))
                return false;
        }
        
        for (int x = -1; x >= -2; x--)
        {
            if (!IsSquareSafe(Position + new Vector2(x, 0)))
                return false;
        }

        return true;
    }
    
    private bool CanCastleRight()
    {
        if (_moved)
            return false;

        if (!RookIsPresent(Position + new Vector2(3, 0)))
            return false;

        for (int x = 1; x <= 2; x++)
        {
            if (!Board.IsSquareFree(Position + new Vector2(x, 0)))
                return false;

            if (!IsSquareSafe(Position + new Vector2(x, 0)))
                return false;
        }

        return true;
    }
    
    private static bool RookIsPresent(Vector2 position)
    {
        Piece cornerPiece = Board.GetPiece(position);
        
        if (cornerPiece is not Rook)
            return false;

        Rook rook = cornerPiece as Rook;

        if (rook.Moved)
            return false;

        return true;
    }
    
    private static bool IsSquareSafe(Vector2 position)
    {
        foreach (Piece piece in Player.Opponent.ControlledPieces)
        {
            if (piece.LegalMoves.Contains(position))
                return false;
        }

        return true;
    }
}
