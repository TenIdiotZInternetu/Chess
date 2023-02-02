namespace Chess;

public static class CommentController
{
    private static (int x, int y) TurnCursor { get; } = (12, 17);
    private static (int x, int y) PlayerOnMoveCursor { get; } = (9, 18);
    private static (int x, int y) WarningCursor { get; } = (0, 20);

    public static void WritePlayerOnMove(Player player)
    {
        Console.SetCursorPosition(
            PlayerOnMoveCursor.x,
            PlayerOnMoveCursor.y);
        
        player.PrintName();
        Console.Write(" to move");
    }
    
    public static void WriteTurnNumber(int turnNumber)
    {
        Console.SetCursorPosition(
            TurnCursor.x,
            TurnCursor.y);
        
        Console.Write($"Turn {turnNumber}");
    }
    
    public static void WriteWarning(string text)
    {
        ResetWarning();
        Console.SetCursorPosition(
            WarningCursor.x,
            WarningCursor.y);
        
        text = AddPadding(text);
        Console.Write(text);
    }
    
    public static void ResetWarning()
    {
        Console.SetCursorPosition(
            WarningCursor.x,
            WarningCursor.y);
        
        Console.Write(new string(' ', Console.WindowWidth * 2));
    }

    public static void ResetComments()
    {
        Console.SetCursorPosition(
            TurnCursor.x,
            TurnCursor.y);
        
        Console.Write(new string(' ', Console.WindowWidth * 5));
    }

    private static string AddPadding(string text)
    {
        string[] lines = text.Split('\n');
        string paddedText = String.Empty;

        foreach (string line in lines)
        {
            int padding = (Console.WindowWidth - line.Length) / 2 + 1; 
            paddedText += new string(' ', padding) + line + "\n";
        }

        return paddedText;
    }
}