using System.Numerics;
using System.Transactions;

namespace Chess;

public class Pawn : Piece
{
    protected override string Symbol => "P";
    private bool _moved = false;
    private Vector2 _yDirection;
    public bool CanBeEnPassant = false;

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

        Vector2 inFront = Position + _yDirection;
        Vector2 twoInFront = Position + 2 * _yDirection;
        
        if (Board.IsSquareFree(inFront))
            LegalMoves.Add(inFront);
        
        if (!_moved && Board.IsSquareFree(twoInFront))
            LegalMoves.Add(twoInFront);

        Vector2 diagonalLeft = Position + _yDirection - Vector2.UnitX;
        Vector2 diagonalRight = Position + _yDirection + Vector2.UnitX;
        
        if (Board.IsPieceOppositeColor(this, diagonalLeft)) 
            LegalMoves.Add(diagonalLeft);
        
        if (Board.IsPieceOppositeColor(this, diagonalRight))
            LegalMoves.Add(diagonalRight);
        
        if (CanEnPassant(Position + Vector2.UnitX))
            LegalMoves.Add(diagonalRight);

        if (CanEnPassant(Position - Vector2.UnitX))
            LegalMoves.Add(diagonalLeft);
    }

    private bool CanEnPassant(Vector2 position)
    {
        if (Board.IsSquareOutOfBounds(position))
            return false;
        
        Piece target = Board.GetPiece(position);

        return Board.IsPieceOppositeColor(this, position) &&
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