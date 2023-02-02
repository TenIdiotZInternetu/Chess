namespace Chess;

public class Player
{
    public static Player WhitePlayer = new Player(ConsoleColor.White);
    public static Player BlackPlayer = new Player(ConsoleColor.Black);
    
    public string Name;
    public ConsoleColor Color;
    public ConsoleColor PrintColor;
    public List<Piece> ControlledPieces = new List<Piece>();
    
    public Player(ConsoleColor color)
    {
        Color = color;
        
        if (color == ConsoleColor.Black)
        {
            Name = "Black";
            PrintColor = ConsoleColor.DarkGray;
        }
        else
        {
            Name = "White";
            PrintColor = ConsoleColor.DarkYellow;
        }
    }
    
    public void PrintName()
    {
        Console.ForegroundColor = PrintColor;
        Console.Write(Color);
        Console.ForegroundColor = ConsoleColor.Gray;
    }
}