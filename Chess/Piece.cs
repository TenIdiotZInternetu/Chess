using System.Numerics;

namespace Chess;

public abstract class Piece
{
    public readonly Player Owner;
    public readonly ConsoleColor Color;
    protected abstract string Symbol { get; }
    public List<Vector2> LegalMoves = new();
    public Vector2 Position;
    protected bool IsLongRange => ShiftVectors.Length > 0;

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
        
        if (Owner.Threats.Count > 1)
            return;

        foreach (var vector in ShiftVectors)
        {
            Vector2 searchedPosition = Position + vector;

            bool doesntLoseKing;
            
            while (Board.IsSquareFree(searchedPosition))
            {
                doesntLoseKing = !Owner.IsInCheck || BlocksCheck(searchedPosition);
                
                if (doesntLoseKing)
                    LegalMoves.Add(searchedPosition);
                
                searchedPosition += vector;
            }
            
            doesntLoseKing = !Owner.IsInCheck || CapturesThreat(searchedPosition);

            if (Board.IsPieceOppositeColor(this, searchedPosition) &&
                doesntLoseKing)
            {
                LegalMoves.Add(searchedPosition);
            }
        }
    }

    public virtual void Move(Vector2 destination)
    {
        Board.RemovePiece(Position);
        Position = destination;
        Board.PutPiece(this);
    }
    
    protected bool BlocksCheck(Vector2 destination)
    {
        if (!Owner.IsInCheck)
            return false;
        
        Piece threat = Owner.Threats[0];

        if (!threat.IsLongRange)
            return false;
        
        Vector2 threatPosition = threat.Position;
        Vector2 kingPosition = Owner.King.Position;

        foreach (Vector2 vector in threat.ShiftVectors)
        {
            Vector2 searchedPosition = threatPosition + vector;
            
            while (Board.IsSquareFree(searchedPosition))
            {
                if (searchedPosition == destination)
                    break;

                searchedPosition += vector;
            }
            
            if (searchedPosition == kingPosition)
                return false;
        }
        
        return true;
    }
    
    protected bool CapturesThreat(Vector2 destination)
    {
        if (!Owner.IsInCheck)
            return false;
        
        Piece threat = Owner.Threats[0];
        Vector2 threatPosition = threat.Position;
        
        return destination == threatPosition;
    }
}