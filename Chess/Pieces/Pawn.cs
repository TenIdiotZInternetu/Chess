using System.Numerics;
using System.Transactions;

namespace Chess;

/// <summary>
/// Represents the Pawn Piece type
/// </summary>
public class Pawn : Piece
{
    protected override string Symbol => "P";
    
    /// <summary>
    /// True if the Pawn has moved at least once during the game
    /// </summary>
    private bool _moved = false;
    
    /// <summary>
    /// Vertical direction in which the Pawn can move
    /// </summary>
    private readonly Vector2 _yDirection;
    
    /// <summary>
    /// True if the Pawn can be captured by en passant
    /// </summary>
    private bool _canBeEnPassant = false;
    
    /// <summary>
    /// Squares on which an opponent's Piece can be captured (once present) by this Pawn
    /// </summary>
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
        
        if (Owner.IsDoubleChecked)
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
    
    /// <summary>
    /// Checks and adds legal move if the Pawn can move 1 square forward
    /// </summary>
    private void CheckForwardMove()
    {
        Vector2 inFront = Position + _yDirection;
        
        if (Board.IsSquareFree(inFront) && KingStaysSafe(inFront))
            LegalMoves.Add(inFront);
    }
    
    /// <summary>
    /// Checks and adds legal move if the Pawn can move 2 squares forward
    /// </summary>
    private void CheckForwardTwoMove()
    {
        Vector2 oneInFront = Position + _yDirection;
        Vector2 twoInFront = Position + 2 * _yDirection;
        
        bool canMoveTwo = !_moved && 
                          Board.IsSquareFree(oneInFront) &&
                          Board.IsSquareFree(twoInFront);
        
        if (canMoveTwo && KingStaysSafe(twoInFront))
            LegalMoves.Add(twoInFront);
    }
    
    /// <summary>
    /// Checks if the Pawn can capture a Piece on the given square
    /// </summary>
    /// <param name="position">Coordinates of a square to be checked</param>
    /// <returns>True if the Piece can be captured</returns>
    private bool CanCapture(Vector2 position)
    {
        if (Board.IsSquareOutOfBounds(position))
            return false;
        
        return Board.IsPieceOppositeColor(this, position) &&
               KingStaysSafe(position);
    }

    /// <summary>
    /// Checks if the Pawn can capture an opponent's Pawn by en passant
    /// </summary>
    /// <param name="targetPosition">Position of the opponent's Pawn</param>
    /// <returns>True if the opponent's Pawn can be captured by en passant</returns>
    private bool CanEnPassant(Vector2 targetPosition)
    {
        if (Board.IsSquareOutOfBounds(targetPosition))
            return false;
        
        Piece target = Board.GetPiece(targetPosition);
        
        return Board.IsPieceOppositeColor(this, targetPosition) &&
               target is Pawn { _canBeEnPassant: true } &&
               KingStaysSafe(targetPosition);
    }
    
    public override void Move(Vector2 destination)
    {
        _moved = true;
        _canBeEnPassant = false;
        
        if (Math.Abs(destination.Y - Position.Y) == 2)
            _canBeEnPassant = true;

        bool enPassant = Math.Abs(destination.X - Position.X) == 1 &&
                         Board.IsSquareFree(destination);
        
        if (enPassant)
            Board.RemovePiece(destination - _yDirection);

        base.Move(destination);
        GameOver.ResetFiftyMoveCounter();
        
        bool promotion = (Owner == Player.BlackPlayer && destination.Y == 0) ||
                         (Owner == Player.WhitePlayer && destination.Y == 7);
        
        if (promotion)
            Promote();
    }

    /// <summary>
    /// Asks the Player for a Piece to promote the Pawn to and replaces the Pawn with the new Piece
    /// </summary>
    private void Promote()
    {
        CommentController.WritePromotionComment();
        
        string pieceToPromoteTo = "";

        while (pieceToPromoteTo == "")
        {
            pieceToPromoteTo = InputController.AskForPromotion();
        }
        
        int x = (int)Position.X;
        int y = (int)Position.Y;

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