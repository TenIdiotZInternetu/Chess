namespace Chess;

public static class CommentController
{
    private static (int x, int y) CommentCursor { get; } = (8, 17);

    public static void WriteComment(string text)
    {
        ResetComment();
        Console.SetCursorPosition(
            CommentCursor.x,
            CommentCursor.y);
        
        Console.Write(text);
    }
    
    public static void ResetComment()
    {
        Console.SetCursorPosition(
            CommentCursor.x,
            CommentCursor.y);
        
        Console.Write("                                                              ");
    }
}