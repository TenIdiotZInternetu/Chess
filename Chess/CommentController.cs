namespace Chess;

/// <summary>
/// Responsible for printing information and warnings during the game
/// </summary>
public static class CommentController
{
    /// <summary>
    /// Position of cursor for printing turn number
    /// </summary>
    private static (int x, int y) TurnCursor { get; } = (12, 17);
    
    /// <summary>
    /// Position of cursor for comments requiring action from player
    /// </summary>
    private static (int x, int y) PlayerOnMoveCursor { get; } = (9, 18);
    
    /// <summary>
    /// Position of cursor for warnings as a reaction to invalid input
    /// </summary>
    private static (int x, int y) WarningCursor { get; } = (0, 20);
    
    /// <summary>
    /// Prints "[player] to move"
    /// </summary>
    public static void WritePlayerOnMove(Player player)
    {
        Console.SetCursorPosition(
            PlayerOnMoveCursor.x,
            PlayerOnMoveCursor.y);
        
        player.PrintName();
        Console.Write(" to move");
    }
    
    /// <summary>
    /// Prints "Move [moveNumber]"
    /// </summary>
    public static void WriteTurnNumber(int moveNumber)
    {
        Console.SetCursorPosition(
            TurnCursor.x,
            TurnCursor.y);
        
        Console.Write($"Move {moveNumber}");
    }
    
    /// <summary>
    /// Prints warning about invalid input
    /// </summary>
    /// <param name="text">Text to be printed</param>
    public static void WriteWarning(string text)
    {
        ResetWarning();
        Console.SetCursorPosition(
            WarningCursor.x,
            WarningCursor.y);
        
        text = AddPadding(text);
        Console.Write(text);
    }

    /// <summary>
    /// Prints "[player] is in check!"
    /// </summary>
    /// <param name="player"></param>
    public static void WriteCheck(Player player)
    {
        ResetComments();
        Console.SetCursorPosition(
            7,
            PlayerOnMoveCursor.y);
        
        player.PrintName();
        Console.Write(" is in check!");
    }

    /// <summary>
    /// Prints "Choose piece to promote to (K, Q, R, B)"
    /// </summary>
    public static void WritePromotionComment()
    {
        ResetComments();
        Console.SetCursorPosition(
            0,
            PlayerOnMoveCursor.y);

        string text = "Choose piece to\npromote to\n(K, Q, R, B)";
        Console.Write(AddPadding(text));
    }
    
    /// <summary>
    /// Prints a the reason for end of game
    /// </summary>
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
    
    /// <summary>
    /// Prints a the reason for end of game
    /// </summary>
    public static void WriteStalemate()
    {
        ResetComments();
        
        Console.SetCursorPosition(
            0,
            PlayerOnMoveCursor.y);

        string text = "Stalemate!\nNo One Wins!";
        Console.Write(AddPadding(text));
    }
    
    /// <summary>
    /// Prints a the reason for end of game
    /// </summary>
    public static void WriteRepetition()
    {
        ResetComments();
        
        Console.SetCursorPosition(
            0,
            PlayerOnMoveCursor.y);

        string text = "Draw by\nRepetition!";
        Console.Write(AddPadding(text));
    }
    
    /// <summary>
    /// Prints a the reason for end of game
    /// </summary>
    public static void WriteInsufficientMaterial()
    {
        ResetComments();
        
        Console.SetCursorPosition(
            0,
            PlayerOnMoveCursor.y);

        string text = "Draw by\nInsufficient Material!";
        Console.Write(AddPadding(text));
    }
    
    /// <summary>
    /// Prints a the reason for end of game
    /// </summary>
    public static void Write50MoveRule()
    {
        ResetComments();
        
        Console.SetCursorPosition(
            0,
            PlayerOnMoveCursor.y);

        string text = "Draw by\n50 Move Rule!";
        Console.Write(AddPadding(text));
    }
    
    /// <summary>
    /// Clears the warning text
    /// </summary>
    private static void ResetWarning()
    {
        Console.SetCursorPosition(
            WarningCursor.x,
            WarningCursor.y);
        
        Console.Write(new string(' ', Console.WindowWidth * 2));
    }

    /// <summary>
    /// Clears all lines of comments
    /// </summary>
    public static void ResetComments()
    {
        Console.SetCursorPosition(
            PlayerOnMoveCursor.x,
            PlayerOnMoveCursor.y);
        
        Console.Write(new string(' ', Console.WindowWidth * 5));
    }

    /// <summary>
    /// Adds whitespaces before text to align it to the center of window
    /// </summary>
    /// <param name="text">Text to be centered</param>
    /// <returns>Padded text</returns>
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