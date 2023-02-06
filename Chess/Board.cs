using System.Numerics;

namespace Chess;

public static class Board
{
    private static Piece[,] Pieces { get; } = new Piece[8, 8];

    public static string NormalizeBoard()
    {
        string board = "";

        for (int y = 7; y >= 0; y--)
        {
            for (int x = 0; x < 8; x++)
            {
                Piece piece = GetPiece(x, y);
                board += (piece == null) ? 
                    "0" : piece.ToString();
            }
        }

        return board;
    }

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
        int x = (int)piece.Position.X;
        int y = (int)piece.Position.Y;
        
        Piece capturedPiece = GetPiece(x, y);

        if (capturedPiece != null)
        {
            capturedPiece.Owner.ControlledPieces.Remove(capturedPiece);
            GameOver.ResetFiftyMoveCounter();
        }
        
        Pieces[x, y] = piece;
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
        Player[] players = { Player.BlackPlayer, Player.WhitePlayer};
        
        foreach (Player player in players)
        {
            for (byte file = 0; file < 8; file++)
            {
                rank = (player == Player.BlackPlayer) ? 6 : 1;
                // new Pawn(player, file, rank);
            }
            
            rank = (player == Player.BlackPlayer) ? 7 : 0;

            // new Rook(player, 0, rank);
            // new Rook(player, 7, rank);
            // new Knight(player, 1, rank);
            // new Knight(player, 6, rank);
            new Bishop(player, 2, rank);
            // new Bishop(player, 5, rank);
            // new Queen(player, 3, rank);
            new King(player, 4, rank);
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

    public static bool IsThreatenedByPawn(Vector2 position)
    {
        if (IsSquareOutOfBounds(position))
            return false;
            
        Piece piece = GetPiece(position);
        return piece is Pawn pawn && pawn.Owner == Player.IdlePlayer;
    }
}