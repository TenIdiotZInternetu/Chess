using System.Numerics;

namespace Chess;

public static class Board
{
    private static Piece?[,] Pieces { get; } = new Piece[8, 8];

    public static Piece GetPiece(int x, int y)
    {
        return Pieces[x, y];
    }
    
    public static Piece GetPiece(Vector2 position)
    {
        int x = (int)position.X;
        int y = (int)position.Y;

        return GetPiece(x, y);
    }
    
    public static void PutPiece(Piece piece)
    {
        Pieces[(int)piece.Position.X, (int)piece.Position.Y] = piece;
        BoardRenderer.RenderBoard();
    }

    public static void RemovePiece(int x, int y)
    {
        Pieces[x, y] = null;
    }

    public static void RemovePiece(Vector2 position)
    {
        int x = (int)position.X;
        int y = (int)position.Y;
        
        RemovePiece(x, y);
    }

    public static Piece PickPiece(int x, int y)
    {
        Piece pickedPiece = GetPiece(x, y);
        BoardRenderer.RenderSquare(x, y, ConsoleColor.Red);
        
        pickedPiece.FindLegalMoves();
        
        foreach (var square in pickedPiece.LegalMoves)
        {
            BoardRenderer.RenderSquare(square, ConsoleColor.Green);
        }

        return pickedPiece;
    }

    public static Piece PickPiece(Piece piece)
    {
        int x = (int)piece.Position.X;
        int y = (int)piece.Position.Y;

        return PickPiece(x, y);
    }

    public static void SetDefaultPiecePositions()
    {
        int rank;
        
        foreach (ConsoleColor color in new[] { ConsoleColor.Black, ConsoleColor.White })
        {
            for (byte file = 0; file < 8; file++)
            {
                rank = (color == ConsoleColor.Black) ? 6 : 1;
                new Pawn(color, file, rank);
            }
            
            rank = (color == ConsoleColor.Black) ? 7 : 0;

            new Rook(color, 0, rank);
            new Rook(color, 7, rank);
            new Knight(color, 1, rank);
            new Knight(color, 6, rank);
            new Bishop(color, 2, rank);
            new Bishop(color, 5, rank);
            new Queen(color, 3, rank);
            new King(color, 4, rank);
        }
    }

    public static bool IsSquareOutOfBounds(int x, int y)
    {
        return x < 0 || x > 7 || y < 0 || y > 7;
    }
    
    public static bool IsSquareOutOfBounds(Vector2 position)
    {
        int x = (int)position.X;
        int y = (int)position.Y;

        return IsSquareOutOfBounds(x, y);
    }
    
    public static bool IsSquareFree(Vector2 position)
    {
        if (IsSquareOutOfBounds(position)) 
            return false;

        Piece searchedSquare = GetPiece(position);
        return searchedSquare == null;
    }

    public static bool IsPieceOppositeColor(Piece attacker, Vector2 position)
    {
        if (IsSquareOutOfBounds(position)) 
            return false;

        if (IsSquareFree(position))
            return false;

        Piece searchedPiece = GetPiece(position);
        return searchedPiece.Color != attacker.Color;
    }
}