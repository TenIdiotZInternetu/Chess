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
    /// All squares this piece could move to if it didn't endanger the king
    /// </summary>
    public List<Vector2> Vision { get; protected set; } = new();

    /// <summary>
    /// All square this piece is able to move to this turn
    /// </summary>
    public List<Vector2> LegalMoves { get; protected set; } = new();
    
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
    /// Finds all squares this piece could move to if it didn't endanger the king
    /// </summary>
    public virtual void GetVision()
    {
        Vision = new List<Vector2>();

        foreach (var vector in ShiftVectors)
        {
            Vector2 searchedPosition = Position + vector;
            
            while (Board.IsSquareFree(searchedPosition))
            {
                Vision.Add(searchedPosition);
                searchedPosition += vector;
            }

            if (Board.IsPieceOppositeColor(this, searchedPosition))
            {
                Vision.Add(searchedPosition);
            }
        }
    }
    
    /// <summary>
    /// Finds all squares this piece is able to move to this turn
    /// </summary>
    public virtual void FindLegalMoves()
    {
        LegalMoves = new List<Vector2>();

        if (Owner.IsDoubleChecked)
            return;

        if (ExposesKing())
            return;
        
        foreach (var square in Vision)
        {
            bool kingStaysSafe = !Owner.IsInCheck ||
                                 BlocksCheck(square) ||
                                 CapturesThreat(square);
            
            if (kingStaysSafe)
                LegalMoves.Add(square);
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
    private bool BlocksCheck(Vector2 destination)
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
    private bool CapturesThreat(Vector2 destination)
    {
        if (!Owner.IsInCheck)
            return false;
        
        Piece threat = Owner.Threats[0];
        Vector2 threatPosition = threat.Position;
        
        return destination == threatPosition;
    }

    /// <summary>
    /// Checks if moving the Piece would expose the king to Check
    /// </summary>
    /// <returns>True if the owner's king would be in Check after the move</returns>
    private bool ExposesKing()
    {
        if (Owner.IsInCheck)
            return false;
        
        Piece[] longRangeAttackers = Player.IdlePlayer.ControlledPieces
            .Where(p => p.IsLongRange && p.Vision.Contains(Position))
            .ToArray();

        foreach (Piece piece in longRangeAttackers)
        {
            foreach (Vector2 vector in piece.ShiftVectors)
            {
                Vector2 searchedPosition = piece.Position + vector;

                while (Board.IsSquareFree(searchedPosition) ||
                       searchedPosition == Position )
                {
                    searchedPosition += vector;
                }
                
                if (searchedPosition == Owner.King.Position)
                    return true;
            }
        }

        return false;
    }
}