namespace Chess;

public class Player
{
    public string Name;
    public ConsoleColor Color;
    public ConsoleColor PrintColor;
    
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