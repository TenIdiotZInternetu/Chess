using System.Numerics;

namespace Chess;

public class Pawn : Piece
{
    protected override string Symbol => "P";
    private bool _moved = false;
    private Vector2 _yDirection;
    public bool CanBeEnPassant = false;

    public Pawn(ConsoleColor color, int xPosition, int yPosition)
        : base(color, xPosition, yPosition)
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

        Vector2 diagonalLeft = Position + _yDirection + Vector2.UnitX;
        Vector2 diagonalRight = Position + _yDirection - Vector2.UnitX;
        
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
}