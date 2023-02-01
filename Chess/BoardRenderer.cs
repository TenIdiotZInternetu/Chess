using System.Numerics;

namespace Chess;

public static class BoardRenderer
{
    private const int BoardXPosition = 8;
    private const int BoardYPosition = 11;
    
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

    public static void RenderSquare(Vector2 squarePosition, ConsoleColor bgColor)
    {
        int x = (int)squarePosition.X;
        int y = (int)squarePosition.Y;
        
        RenderSquare(x, y, bgColor);
    }
}