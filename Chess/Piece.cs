using System.Numerics;

namespace Chess;

/// <summary>
/// Represents a single Piece on the Board
/// </summary>
public abstract class Piece
{
    /// <summary>
    /// Player that controls the Piece
    /// </summary>
    public readonly Player Owner;
    
    /// <summary>
    /// Color to be used when printing the Piece
    /// </summary>
    public readonly ConsoleColor Color;
    
    /// <summary>
    /// Character to be used when printing the Piece
    /// </summary>
    protected abstract string Symbol { get; }
    
    /// <summary>
    /// All square this piece is able to move to this turn
    /// </summary>
    public List<Vector2> LegalMoves = new();
    
    /// <summary>
    /// Coordinate vector with file and rank of the Piece
    /// </summary>
    public Vector2 Position;
    
    /// <summary>
    /// True for Queen, Rook and Bishop
    /// </summary>
    protected bool IsLongRange => ShiftVectors.Length > 0;

    /// <summary>
    /// Assigned to Queen, Rook and Bishop. Contains all possible directions of movement.
    /// </summary>
    protected virtual Vector2[] ShiftVectors => Array.Empty<Vector2>();

    /// <summary>
    /// Represents a single Piece on the Board
    /// </summary>
    /// <param name="owner">Player that controls this Piece</param>
    /// <param name="xPosition">File (column) this Piece starts at</param>
    /// <param name="yPosition">Rank (row) this Piece starts at</param>
    protected Piece(Player owner, int xPosition, int yPosition)
    {
        Owner = owner;
        Color = owner.Color;
        Position = new Vector2(xPosition, yPosition);
        Board.PutPiece(this);
        Owner.ControlledPieces.Add(this);
    }
    
    public override string ToString() => Symbol;

    /// <summary>
    /// Finds all squares this piece is able to move to this turn
    /// </summary>
    public virtual void FindLegalMoves()
    {
        LegalMoves = new List<Vector2>();
        
        if (Owner.IsDoubleChecked)
            return;

        foreach (var vector in ShiftVectors)
        {
            Vector2 searchedPosition = Position + vector;
            
            while (Board.IsSquareFree(searchedPosition))
            {
                if (KingStaysSafe(searchedPosition))
                    LegalMoves.Add(searchedPosition);
                
                searchedPosition += vector;
            }

            if (Board.IsPieceOppositeColor(this, searchedPosition) &&
                KingStaysSafe(searchedPosition))
            {
                LegalMoves.Add(searchedPosition);
            }
        }
    }

    /// <summary>
    /// Responsible for all property changes when the Piece is moved
    /// </summary>
    /// <param name="destination">Coordinates of the square the Piece should be moved to</param>
    public virtual void Move(Vector2 destination)
    {
        Board.RemovePiece(Position);
        Position = destination;
        Board.PutPiece(this);
    }
    
    /// <summary>
    /// Checks if the Piece interferes opponent's attack
    /// </summary>
    /// <param name="destination">Coordinates of the square the Piece would've blocked</param>
    /// <returns>True if the attack is interfered</returns>
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
    
    /// <summary>
    /// Checks if the captured Piece is the one delivering the check
    /// </summary>
    /// <param name="destination">Coordinates of the captured Piece</param>
    /// <returns>True if the Captured Piece is the threat</returns>
    protected bool CapturesThreat(Vector2 destination)
    {
        if (!Owner.IsInCheck)
            return false;
        
        Piece threat = Owner.Threats[0];
        Vector2 threatPosition = threat.Position;
        
        return destination == threatPosition;
    }

    /// <summary>
    /// Checks if the King cannot be captured after moving the Piece to the given position
    /// </summary>
    /// <param name="position">Coordinates of the square the Piece is moving to</param>
    /// <returns>True if the King cannot be captured the next move</returns>
    protected bool KingStaysSafe(Vector2 position)
    {
        return !Owner.IsInCheck ||
               BlocksCheck(position) ||
               CapturesThreat(position);
    }
}