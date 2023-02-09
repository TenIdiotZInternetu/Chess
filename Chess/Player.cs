using System.Numerics;

namespace Chess;

/// <summary>
/// Represents one of the users playing the game
/// </summary>
public class Player
{
    // Singletons. There are only two players in a game of chess.
    public static readonly Player WhitePlayer = new(ConsoleColor.White);
    public static readonly Player BlackPlayer = new(ConsoleColor.Black);
    
    /// <summary>
    /// Player that is currently making a move
    /// </summary>
    public static Player CurrentPlayer { get; set; }
    
    /// <summary>
    /// Player waiting for the opponent to make a move
    /// </summary>
    public static Player IdlePlayer => (CurrentPlayer == WhitePlayer) ?
        BlackPlayer : WhitePlayer;
    
    /// <summary>
    /// Player who is playing against this player
    /// </summary>
    private Player Opponent => (this == WhitePlayer) ? 
        BlackPlayer : WhitePlayer;

    /// <summary>
    /// Symbolic color of the player
    /// </summary>
    public readonly ConsoleColor Color;
    
    /// <summary>
    /// Color of to be printed in the console
    /// </summary>
    private readonly ConsoleColor _printColor;
    
    /// <summary>
    /// All pieces on the board this player can move with
    /// </summary>
    public List<Piece> ControlledPieces = new();
    
    /// <summary>
    /// King piece controlled by this player
    /// </summary>
    public King King;
    
    /// <summary>
    /// All opponent's pieces giving a check to this player's king
    /// </summary>
    public List<Piece> Threats = new();
    
    /// <summary>
    /// All squares pieces of this player can move to this turn
    /// </summary>
    public List<Vector2> LegalMoves = new();
    
    /// <summary>
    /// True if the player's king is in check
    /// </summary>
    public bool IsInCheck => Threats.Count > 0;
    
    /// <summary>
    /// True if the player's king is checked by two pieces at once
    /// </summary>
    public bool IsDoubleChecked => Threats.Count > 1;
    
    /// <summary>
    /// Represents one of the users playing the game
    /// </summary>
    /// <param name="color">Symbolic color of the player</param>
    public Player(ConsoleColor color)
    {
        Color = color;
        
        _printColor = (color == ConsoleColor.Black) ?
            ConsoleColor.DarkGray :
            ConsoleColor.DarkYellow;
    }
    
    /// <summary>
    /// Prints the player's color in the console. Color of the text is player's _printColor
    /// </summary>
    public void PrintName()
    {
        Console.ForegroundColor = _printColor;
        Console.Write(Color);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    
    /// <summary>
    /// Finds all squares pieces of this player can move to this turn
    /// </summary>
    public void FindLegalMoves()
    {
        LegalMoves.Clear();
        
        foreach (Piece piece in ControlledPieces)
        {
            piece.FindLegalMoves();
            LegalMoves.AddRange(piece.LegalMoves);
            
            bool givesCheck = piece.LegalMoves.Contains(Opponent.King.Position);

            if (givesCheck)
            {
                CommentController.WriteCheck(CurrentPlayer);
                Opponent.Threats.Add(piece);
            }
        }
    }
}