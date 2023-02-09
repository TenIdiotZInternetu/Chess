using System.Numerics;

namespace Chess;

/// <summary>
/// Represents status of each square on the Board. Is Responsible for Piece movement.
/// </summary>
public static class Board
{
    /// <summary>
    /// Gets the Board as a 2D array of Pieces
    /// </summary>
    private static Piece[,] Pieces { get; } = new Piece[8, 8];

    /// <summary>
    /// Converts board to string representation, where first 8 characters are the eight rank,
    /// last 8 characters are the first rank.
    /// Each character represents a piece,
    /// 0 represents empty square
    /// </summary>
    /// <returns>The string representation of the Board</returns>
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

    /// <summary>
    /// Returns the piece at the given position on the board
    /// </summary>
    /// <param name="x">File (Column) of the Piece</param>
    /// <param name="y">Rank (Row) of the Piece</param>
    /// <returns>The piece at given position</returns>
    public static Piece GetPiece(int x, int y)
    {
        return Pieces[x, y];
    }
    
    /// <summary>
    /// Returns the piece at the given position on the board
    /// </summary>
    /// <param name="position">Coordinate vector with file and rank of the Piece</param>
    /// <returns>The piece at given position</returns>
    public static Piece GetPiece(Vector2 position)
    {
        int x = (int)position.X;
        int y = (int)position.Y;

        return GetPiece(x, y);
    }
    
    /// <summary>
    /// Places Piece on the board with position given by the Position property of the Piece.
    /// Piece is removed from its previous position.
    /// Any Piece previously occupying the square is removed from the game.
    /// </summary>
    /// <param name="piece">Piece to be put on the board</param>
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

    /// <summary>
    /// Removes Piece from the given square.
    /// </summary>
    /// <param name="x">File (Column) of the Piece</param>
    /// <param name="y">Rank (Row) of the Piece</param>
    public static void RemovePiece(int x, int y)
    {
        Pieces[x, y] = null;
    }

    /// <summary>
    /// Removes Piece from the given square.
    /// </summary>
    /// <param name="position">Coordinate vector with file and rank of the Piece</param>
    public static void RemovePiece(Vector2 position)
    {
        int x = (int)position.X;
        int y = (int)position.Y;
        
        RemovePiece(x, y);
    }

    /// <summary>
    /// Draws all legal moves of the Piece at the given position.
    /// The Piece is expected to move to one of the drawn squares.
    /// </summary>
    /// <param name="x">File (Column) of the Piece</param>
    /// <param name="y">Rank (Row) of the Piece</param>
    /// <returns></returns>
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

    /// <summary>
    /// Draws all legal moves of the Piece at the given position.
    /// The Piece is expected to move to one of the drawn squares.
    /// </summary>
    /// <param name="piece">The Piece expected to move</param>
    /// <returns></returns>
    public static Piece PickPiece(Piece piece)
    {
        int x = (int)piece.Position.X;
        int y = (int)piece.Position.Y;

        return PickPiece(x, y);
    }

    /// <summary>
    /// Initiates all Pieces and puts them on the board in their starting positions.
    /// </summary>
    public static void SetDefaultPiecePositions()
    {
        int rank;
        Player[] players = { Player.BlackPlayer, Player.WhitePlayer};
        
        foreach (Player player in players)
        {
            for (byte file = 0; file < 8; file++)
            {
                rank = (player == Player.BlackPlayer) ? 6 : 1;
                new Pawn(player, file, rank);
            }
            
            rank = (player == Player.BlackPlayer) ? 7 : 0;

            new Rook(player, 0, rank);
            new Rook(player, 7, rank);
            new Knight(player, 1, rank);
            new Knight(player, 6, rank);
            new Bishop(player, 2, rank);
            new Bishop(player, 5, rank);
            new Queen(player, 3, rank);
            new King(player, 4, rank);
        }
    }

    /// <summary>
    /// Checks if the given coordinates are a valid square within the board.
    /// </summary>
    /// <param name="x">File (Column) of the square</param>
    /// <param name="y">Rank (Row) of the square</param>
    /// <returns>True if the square doesn't lie on the Board</returns>
    public static bool IsSquareOutOfBounds(int x, int y)
    {
        return x < 0 || x > 7 || y < 0 || y > 7;
    }
    
    /// <summary>
    /// Checks if the given coordinates are a valid square within the board.
    /// </summary>
    /// <param name="position">Coordinate vector with file and rank of the square</param>
    /// <returns>True if the square doesn't lie on the Board</returns>
    public static bool IsSquareOutOfBounds(Vector2 position)
    {
        int x = (int)position.X;
        int y = (int)position.Y;

        return IsSquareOutOfBounds(x, y);
    }
    
    /// <summary>
    /// Checks if the square on the given position is occupied by any Piece
    /// </summary>
    /// <param name="position">Coordinate vector with file and rank of the square</param>
    /// <returns>True if the square isn't occupied by any Piece</returns>
    public static bool IsSquareFree(Vector2 position)
    {
        if (IsSquareOutOfBounds(position)) 
            return false;

        Piece searchedSquare = GetPiece(position);
        return searchedSquare == null;
    }

    /// <summary>
    /// Checks if the square on the given position is occupied by a Piece of opposite color.
    /// </summary>
    /// <param name="attacker">The Piece of which color should be opposite to the given square</param>
    /// <param name="position">Coordinate vector with file and rank of the square</param>
    /// <returns>True if the Piece at given position is of opposite color to the attacker</returns>
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