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
        
        foreach (Vector2 destination in GetWalkableSquares())
        {
            bool squareIsSafe = IsSquareSafe(destination);
            bool isntBlocked = Board.IsSquareFree(destination) ||
                               Board.IsPieceOppositeColor(this, destination);

            if (isntBlocked && squareIsSafe)
                LegalMoves.Add(destination);
        }
        
        bool cannotCastle = Owner.IsInCheck || _moved;

        if (cannotCastle)
            return;
        
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
    
    IEnumerable<Vector2> GetWalkableSquares()
    {
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0)
                    continue;

                Vector2 shiftVector = new Vector2(x, y);
                Vector2 destination = Position + shiftVector;

                yield return destination;
            }
        }
    }

    private bool CanCastleLeft()
    {
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

        if (cornerPiece is Rook rook)
        {
            return !rook.Moved;
        }

        return false;
    }
    
    private static bool IsSquareSafe(Vector2 position)
    {
        foreach (Piece piece in Player.IdlePlayer.ControlledPieces)
        {
            if (piece is Pawn pawn)
            {
                (Vector2 diagonalLeft, Vector2 diagonalRight) = pawn.AttackedSquares;
                if (diagonalLeft == position || diagonalRight == position)
                    return false;
            }
            
            else if (piece.LegalMoves.Contains(position))
                return false;
        }
        
        return true;
    }
}
