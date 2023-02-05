using System.Numerics;
using System.Transactions;

namespace Chess;

public class Pawn : Piece
{
    protected override string Symbol => "P";
    private bool _moved = false;
    private Vector2 _yDirection;
    private bool CanBeEnPassant = false;
    
    public (Vector2 DiagonalLeft, Vector2 DiagonalRight) AttackedSquares => (
        Position + _yDirection - Vector2.UnitX,
        Position + _yDirection + Vector2.UnitX
    );

    public Pawn(Player owner, int xPosition, int yPosition)
        : base(owner, xPosition, yPosition)
    {
        _yDirection = (Color == ConsoleColor.Black) ? 
            new Vector2(0, -1) :
            new Vector2(0, 1);
    }
    
    public override void FindLegalMoves()
    {
        LegalMoves = new List<Vector2>();
        
        if (Owner.Threats.Count > 1)
            return;

        CheckForwardMove();
        CheckForwardTwoMove();

        if (CanCapture(AttackedSquares.DiagonalLeft))
            LegalMoves.Add(AttackedSquares.DiagonalLeft);
        
        if (CanCapture(AttackedSquares.DiagonalRight))
            LegalMoves.Add(AttackedSquares.DiagonalRight);
        
        if (CanEnPassant(Position + Vector2.UnitX))
            LegalMoves.Add(AttackedSquares.DiagonalRight);

        if (CanEnPassant(Position - Vector2.UnitX))
            LegalMoves.Add(AttackedSquares.DiagonalLeft);
    }
    
    private void CheckForwardMove()
    {
        Vector2 inFront = Position + _yDirection;
        bool doesntLoseKing = !Owner.IsInCheck || BlocksCheck(inFront);
        
        if (Board.IsSquareFree(inFront) && doesntLoseKing)
            LegalMoves.Add(inFront);
    }
    
    private void CheckForwardTwoMove()
    {
        Vector2 twoInFront = Position + 2 * _yDirection;
        bool doesntLoseKing = !Owner.IsInCheck || BlocksCheck(twoInFront);
        bool canMoveTwo = !_moved && Board.IsSquareFree(twoInFront);
        
        if (canMoveTwo && doesntLoseKing)
            LegalMoves.Add(twoInFront);
    }
    
    private bool CanCapture(Vector2 position)
    {
        if (Board.IsSquareOutOfBounds(position))
            return false;
        
        bool doesntLoseKing = !Owner.IsInCheck || CapturesThreat(position);
        
        return Board.IsPieceOppositeColor(this, position) && doesntLoseKing;
    }

    private bool CanEnPassant(Vector2 targetPosition)
    {
        if (Board.IsSquareOutOfBounds(targetPosition))
            return false;
        
        Piece target = Board.GetPiece(targetPosition);
        
        bool doesntLoseKing = !Owner.IsInCheck || CapturesThreat(targetPosition);

        return Board.IsPieceOppositeColor(this, targetPosition) &&
               target is Pawn &&
               (target as Pawn).CanBeEnPassant;
    }
    
    public override void Move(Vector2 destination)
    {
        _moved = true;
        CanBeEnPassant = false;
        
        if (Math.Abs(destination.Y - Position.Y) == 2)
            CanBeEnPassant = true;

        bool enPassant = Math.Abs(destination.X - Position.X) == 1 &&
                         Board.IsSquareFree(destination);
        
        if (enPassant)
            Board.RemovePiece(destination - _yDirection);

        base.Move(destination);
        
        bool promotion = (Owner == Player.BlackPlayer && destination.Y == 0) ||
                         (Owner == Player.WhitePlayer && destination.Y == 7);
        
        if (promotion)
            Promote();
    }

    private void Promote()
    {
        CommentController.WritePromotionComment();
        
        string pieceToPromoteTo = "";

        while (pieceToPromoteTo == "")
        {
            pieceToPromoteTo = InputController.AskForPromotion();
        }
        
        int x = (int) Position.X;
        int y = (int) Position.Y;

        switch (pieceToPromoteTo)
        {
            case "Q":
                Board.PutPiece(new Queen(Owner, x, y));
                break;
            case "R":
                Board.PutPiece(new Rook(Owner, x, y));
                break;
            case "B":
                Board.PutPiece(new Bishop(Owner, x, y));
                break;
            case "N":
                Board.PutPiece(new Knight(Owner, x, y));
                break;
        }
        
    }
}