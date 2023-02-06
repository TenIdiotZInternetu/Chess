using System.Numerics;

namespace Chess;

public class Player
{
    public static readonly Player WhitePlayer = new(ConsoleColor.White);
    public static readonly Player BlackPlayer = new(ConsoleColor.Black);
    
    public static Player CurrentPlayer { get; set; }
    public static Player IdlePlayer => (CurrentPlayer == WhitePlayer) ?
        BlackPlayer : WhitePlayer;
    private Player Opponent => (this == WhitePlayer) ? 
        BlackPlayer : WhitePlayer;

    public readonly ConsoleColor Color;
    private readonly ConsoleColor _printColor;
    
    public List<Piece> ControlledPieces = new();
    public King King;
    public List<Piece> Threats = new();
    public List<Vector2> LegalMoves = new();
    public bool IsInCheck => Threats.Count > 0;
    
    public Player(ConsoleColor color)
    {
        Color = color;
        
        _printColor = (color == ConsoleColor.Black) ?
            ConsoleColor.DarkGray :
            ConsoleColor.DarkYellow;
    }
    
    public void PrintName()
    {
        Console.ForegroundColor = _printColor;
        Console.Write(Color);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    
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