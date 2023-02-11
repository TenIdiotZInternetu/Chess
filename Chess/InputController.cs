using System.Numerics;
using System.Xml;

namespace Chess;

/// <summary>
/// Responsible for reading input from the console and choosing appropriate response.
/// </summary>
public static class InputController
{
    /// <summary>
    /// Position of cursor for primary input
    /// </summary>
    private static (int x, int y) PrimaryInputCursor { get; } = (8, 15);
    
    /// <summary>
    /// Position of cursor for choosing a square to move to
    /// </summary>
    private static (int x, int y) SecondaryInputCursor { get; } = (10, 15);
    
    private delegate void InputHandler(string input);
    
    /// <summary>
    /// Method responsible for creating appropriate response to input
    /// </summary>
    private static InputHandler ResolveInput { get; set; }

    /// <summary>
    /// Reads input and handles it
    /// </summary>
    /// <returns>True if the input was valid and no exceptions were raised</returns>
    public static bool ReadInputAndConfirm()
    {
        ResetInput();

        try
        {
            string input = ReadPrimaryInput();
            ResolveInput(input);
            return true;
        }
        catch (ArgumentNullException)
        {
            CommentController.WriteWarning("Choose your Piece");
        }
        catch (ArgumentOutOfRangeException)
        {
            CommentController.WriteWarning("Choose one of the\nlegal moves");
        }
        catch (ArgumentException)
        {
            CommentController.WriteWarning("Enter square position\nin format [file][rank]");
        }
        catch (UnauthorizedAccessException)
        {
            CommentController.WriteWarning("Choose piece of your\ncolor");
        }
        catch (IndexOutOfRangeException)
        {
            CommentController.WriteWarning("Choose rank between\n1 and 8");
        }

        BoardRenderer.RenderBoard();
        return false;
    }
    
    /// <summary>
    /// Awaits player's first input and chooses appropriate response
    /// </summary>
    /// <returns>Player's input</returns>
    /// <exception cref="ArgumentNullException">Player's input was empty</exception>
    /// <exception cref="ArgumentException">The input was of invalid format</exception>
    private static string ReadPrimaryInput()
    {
        string input = Console.ReadLine();
        if (input == "") throw new ArgumentNullException();
        
        switch (input)
        {
            // TODO: Add more input types
            
            // Move with picked piece
            default:
                if (!IsValidSquare(input)) throw new ArgumentException();
                ResolveInput = PickAndMovePiece;
                break;
        }
        
        return input;
    }

    /// <summary>
    /// Picks up a Piece and moves it to a square chosen by the player
    /// </summary>
    /// <param name="input">Player's primary input</param>
    /// <exception cref="UnauthorizedAccessException">Player chose a Piece not of his color</exception>
    /// <exception cref="ArgumentOutOfRangeException">Player chose a square that is not one of their legal moves</exception>
    private static void PickAndMovePiece(string input)
    {
        Vector2 pickedSquare = new Vector2(
            (int)Enum.Parse(typeof(Columns), input[0].ToString().ToUpper()),
            (int)Char.GetNumericValue(input[1]) - 1
        );

        Piece pickedPiece = Board.GetPiece(pickedSquare);
        
        if (pickedPiece?.Color != Player.CurrentPlayer.Color)
            throw new UnauthorizedAccessException();

        Board.PickPiece(pickedPiece);

        Vector2 moveDestination = AskForLegalMove(pickedPiece);
        
        if (!pickedPiece.LegalMoves.Contains(moveDestination))
            throw new ArgumentOutOfRangeException();

        pickedPiece.Move(moveDestination);
    }

    /// <summary>
    /// Prints the type of chosen Piece and asks the player to choose a square to move to
    /// </summary>
    /// <param name="pickedPiece">The piece to be moved</param>
    /// <returns>Coordinate vector of the chosen square</returns>
    /// <exception cref="ArgumentNullException">Player's input was empty</exception>
    /// <exception cref="ArgumentException">The input was of invalid format</exception>
    private static Vector2 AskForLegalMove(Piece pickedPiece)
    {
        Console.SetCursorPosition(
            SecondaryInputCursor.x,
            SecondaryInputCursor.y);

        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Gray;
        
        string pieceType = pickedPiece.GetType().Name;
        
        Console.Write($": {pieceType} -> ");
        string input = Console.ReadLine();
        
        if (input == "") throw new ArgumentNullException();
        if (!IsValidSquare(input)) throw new ArgumentException();

        return new Vector2(
            (int)Enum.Parse(typeof(Columns), input[0].ToString().ToUpper()),
            (int)Char.GetNumericValue(input[1]) - 1
        );
    }

    /// <summary>
    /// Clears the input line
    /// </summary>
    private static void ResetInput()
    {
        Console.SetCursorPosition(
            PrimaryInputCursor.x,
            PrimaryInputCursor.y);
        
        Console.Write("                    ");
        
        Console.SetCursorPosition(
            PrimaryInputCursor.x,
            PrimaryInputCursor.y);
    }

    /// <summary>
    /// Checks if the input has the format of one of the squares on the board
    /// </summary>
    /// <param name="input">Player's input</param>
    /// <returns>True if the input string has a valid square format</returns>
    private static bool IsValidSquare(string input)
    {
        if (input.Length == 2)
        {
            return Enum.IsDefined(typeof(Columns), input[0].ToString().ToUpper()) &&
                   char.IsNumber(input[1]);
        }

        return false;
    }

    /// <summary>
    /// Awaits player to choose a piece type to promote to. "Q", "K", "B", "R" are expected inputs.
    /// </summary>
    /// <returns>Players input ("Q", "K", "B" or "R")</returns>
    public static string AskForPromotion()
    {
        
        ResetInput();
        string input = Console.ReadLine().ToUpper();

        string[] options = { "Q", "K", "B", "R" };

        if (!options.Contains(input))
        {
            CommentController.WriteWarning("Choose one of the following\n(Q, K, B, R)");
            return "";
        }

        return input;
    }
}