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
    
    public static void WriteTurnNumber(int moveNumber)
    {
        Console.SetCursorPosition(
            TurnCursor.x,
            TurnCursor.y);
        
        Console.Write($"Move {moveNumber}");
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

    public static void WriteCheck(Player player)
    {
        ResetComments();
        Console.SetCursorPosition(
            7,
            PlayerOnMoveCursor.y);
        
        player.PrintName();
        Console.Write(" is in check!");
    }

    public static void WritePromotionComment()
    {
        ResetComments();
        Console.SetCursorPosition(
            0,
            PlayerOnMoveCursor.y);

        string text = "Choose piece to\npromote to\n(K, Q, R, B)";
        Console.Write(AddPadding(text));
    }

    public static void WriteCheckmate(Player player)
    {
        ResetComments();
        
        Console.SetCursorPosition(
            0,
            PlayerOnMoveCursor.y);

        Console.Write(AddPadding("Checkmate!"));
        Console.Write("\t  ");
        player.PrintName();
        Console.Write(" wins!");
    }
    
    public static void WriteStalemate()
    {
        ResetComments();
        
        Console.SetCursorPosition(
            0,
            PlayerOnMoveCursor.y);

        string text = "Stalemate!\nNo One Wins!";
        Console.Write(AddPadding(text));
    }
    
    public static void WriteRepetition()
    {
        ResetComments();
        
        Console.SetCursorPosition(
            0,
            PlayerOnMoveCursor.y);

        string text = "Draw by\nRepetition!";
        Console.Write(AddPadding(text));
    }
    
    public static void WriteInsufficientMaterial()
    {
        ResetComments();
        
        Console.SetCursorPosition(
            0,
            PlayerOnMoveCursor.y);

        string text = "Draw by\nInsufficient Material!";
        Console.Write(AddPadding(text));
    }
    
    public static void Write50MoveRule()
    {
        ResetComments();
        
        Console.SetCursorPosition(
            0,
            PlayerOnMoveCursor.y);

        string text = "Draw by\n50 Move Rule!";
        Console.Write(AddPadding(text));
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
            PlayerOnMoveCursor.x,
            PlayerOnMoveCursor.y);
        
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