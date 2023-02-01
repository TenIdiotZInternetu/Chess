using System.Numerics;

namespace Chess;

public abstract class Piece
{
    public readonly ConsoleColor Color;
    protected abstract string Symbol { get; }
    public List<Vector2> LegalMoves;
    public Vector2 Position;

    protected virtual Vector2[] ShiftVectors => Array.Empty<Vector2>();

    protected Piece(ConsoleColor color, int xPosition, int yPosition)
    {
        Color = color;
        Position = new Vector2(xPosition, yPosition);
        Board.PutPiece(this);
    }

    public override string ToString() => Symbol;

    public virtual void FindLegalMoves()
    {
        LegalMoves = new List<Vector2>();
        
        foreach (var vector in ShiftVectors)
        {
            Vector2 searchedPosition = Position + vector;
            
            while (Board.IsSquareFree(searchedPosition))
            {
                LegalMoves.Add(searchedPosition);
                searchedPosition += vector;
            }
            
            if (Board.IsPieceOppositeColor(this, searchedPosition))
                LegalMoves.Add(searchedPosition);
        }
    }

    public void Move(Vector2 destination)
    {
        Board.RemovePiece(Position);
        Position = destination;
        Board.PutPiece(this);
    }
}