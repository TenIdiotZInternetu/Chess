namespace Chess;

public class Player
{
    public static readonly Player WhitePlayer = new Player(ConsoleColor.White);
    public static readonly Player BlackPlayer = new Player(ConsoleColor.Black);
    
    public static Player CurrentPlayer = WhitePlayer;
    public static Player Opponent => (CurrentPlayer == WhitePlayer) ? BlackPlayer : WhitePlayer;

    private string Name;
    public readonly ConsoleColor Color;
    private readonly ConsoleColor _printColor;
    
    public List<Piece> ControlledPieces = new List<Piece>();
    public King King;
    public List<Piece> Threats = new List<Piece>();
    public bool IsInCheck => Threats.Count > 0;
    
    public Player(ConsoleColor color)
    {
        Color = color;
        
        if (color == ConsoleColor.Black)
        {
            Name = "Black";
            _printColor = ConsoleColor.DarkGray;
        }
        else
        {
            Name = "White";
            _printColor = ConsoleColor.DarkYellow;
        }
    }
    
    public void PrintName()
    {
        Console.ForegroundColor = _printColor;
        Console.Write(Color);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
}