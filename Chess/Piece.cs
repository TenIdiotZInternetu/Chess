using System.Numerics;

namespace Chess;

public abstract class Piece
{
    public readonly Player Owner;
    public readonly ConsoleColor Color;
    protected abstract string Symbol { get; }
    public List<Vector2> LegalMoves;
    public Vector2 Position;

    protected virtual Vector2[] ShiftVectors => Array.Empty<Vector2>();

    protected Piece(Player owner, int xPosition, int yPosition)
    {
        Owner = owner;
        Color = owner.Color;
        Position = new Vector2(xPosition, yPosition);
        Board.PutPiece(this);
        Owner.ControlledPieces.Add(this);
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

    public virtual void Move(Vector2 destination)
    {
        Board.RemovePiece(Position);
        Position = destination;
        
        Piece capturedPiece = Board.GetPiece(destination);
        
        if (capturedPiece != null)
        {
            Player.Opponent.ControlledPieces.Remove(capturedPiece);
        }
        
        Board.PutPiece(this);
    }
}