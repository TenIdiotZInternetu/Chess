using System.Numerics;

namespace Chess;

/// <summary>
/// Is Responsible for printing the Board to the Console
/// </summary>
public static class BoardRenderer
{
    /// <summary>
    /// X position of the top left corner of the Board
    /// </summary>
    private const int BoardXPosition = 8;
    /// <summary>
    /// Y position of the top left corner of the Board
    /// </summary>
    private const int BoardYPosition = 11;
    
    /// <summary>
    /// Prints the numbers of the ranks and the letters of the files to the Console
    /// </summary>
    public static void RenderCoordinates()
    {
        //Render A-H
        for (int i = 0; i < 8; i++)
        {
            Console.SetCursorPosition(8 + 2 * i, 2);
            Console.Write((Columns)i);

            Console.CursorLeft--;
            Console.CursorTop = 13;
            Console.Write((Columns)i);
        }

        //Render 1-8
        for (int i = 0; i < 8; i++)
        {
            Console.SetCursorPosition(5, 4 + i);
            Console.Write(8 - i);

            Console.CursorLeft = 26;
            Console.Write(8 - i);
        }
    }
    
    /// <summary>
    /// Print the whole Board with Pieces to the Console
    /// </summary>
    public static void RenderBoard()
    {
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                if ((x + y) % 2 != 0) 
                    RenderSquare(x, y, ConsoleColor.DarkYellow);
                else 
                    RenderSquare(x, y, ConsoleColor.DarkGray);
            }
        }

        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.SetCursorPosition(4, 16);
        Console.WriteLine("========================");
    }

    /// <summary>
    /// Render single Square with Piece occupying it to the Console
    /// </summary>
    /// <param name="squareX">X coordinate of the square</param>
    /// <param name="squareY">Y coordinate of the square</param>
    /// <param name="bgColor">Print color of the square</param>
    public static void RenderSquare(int squareX, int squareY, ConsoleColor bgColor)
    {
        Piece piece = Board.GetPiece(squareX, squareY);
        Console.BackgroundColor = bgColor;
        Console.SetCursorPosition(
            BoardXPosition + squareX * 2, 
            BoardYPosition - squareY);

        if (piece != null)
        {
            Console.ForegroundColor = piece.Color;
            Console.Write(Board.GetPiece(squareX, squareY));
        }
        else Console.Write(" ");
        
        Console.Write(" ");
    }

    /// <summary>
    /// Render single Square with Piece occupying it to the Console
    /// </summary>
    /// <param name="squarePosition">Coordinate vector with file and rank of the square</param>
    /// <param name="bgColor">Print color of the square</param>
    public static void RenderSquare(Vector2 squarePosition, ConsoleColor bgColor)
    {
        int x = (int)squarePosition.X;
        int y = (int)squarePosition.Y;
        
        RenderSquare(x, y, bgColor);
    }
}