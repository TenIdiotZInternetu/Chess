using System.Numerics;

namespace Chess;

public static class InputController
{
    private static (int x, int y) InputCursor { get; } = (8, 15);
    private static (int x, int y) SecondaryInputCursor { get; } = (10, 15);

    public static bool ReadInputAndSuccess(Player player)
    {
        ResetInput();
        
        Console.SetCursorPosition(
            InputCursor.x,
            InputCursor.y);

        try
        {
            string input1 = Console.ReadLine();
            if (input1 == "") throw new ArgumentNullException();
            if (!IsInputRightFormat(input1)) throw new ArgumentException();

            int startingFile = (int)Enum.Parse(typeof(Columns), input1[0].ToString().ToUpper());
            int startingRank = (int)Char.GetNumericValue(input1[1]) - 1;

            Piece pickedPiece = Board.GetPiece(startingFile, startingRank);
            if (pickedPiece?.Color != player.Color)
                throw new UnauthorizedAccessException();

            Board.PickPiece(pickedPiece);

            string input2 = ReadSecondaryInput();
            if (input2 == "") throw new ArgumentNullException();
            if (!IsInputRightFormat(input2)) throw new ArgumentException();

            // TODO: Distinguish between types of inputs

            Vector2 moveDestination = new Vector2(
                (int)Enum.Parse(typeof(Columns), input2[0].ToString().ToUpper()),
                (int)Char.GetNumericValue(input2[1]) - 1
            );

            if (!pickedPiece.LegalMoves.Contains(moveDestination))
                throw new ArgumentOutOfRangeException();

            pickedPiece.Move(moveDestination);
            return true;
        }
        catch (ArgumentNullException e)
        {
            CommentController.WriteWarning("Choose your Piece");
        }
        catch (ArgumentOutOfRangeException e)
        {
            CommentController.WriteWarning("Choose one of the\nlegal moves");
        }
        catch (ArgumentException e)
        {
            CommentController.WriteWarning("Enter square position\nin format [file][rank]");
        }
        catch (UnauthorizedAccessException e)
        {
            CommentController.WriteWarning("Choose piece of your\ncolor");
        }
        catch (IndexOutOfRangeException e)
        {
            CommentController.WriteWarning("Choose rank between\n1 and 8");
        }

        BoardRenderer.RenderBoard();
        return false;
    }

    private static string? ReadSecondaryInput()
    {
        Console.SetCursorPosition(10, 15);
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write(": Piece -> ");
        return Console.ReadLine();
    }

    private static void ResetInput()
    {
        Console.SetCursorPosition(
            InputCursor.x,
            InputCursor.y);
        
        Console.Write("                    ");
    }

    private static bool IsInputRightFormat(string input)
    {
        if (input.Length == 2)
        {
            return Enum.IsDefined(typeof(Columns), input[0].ToString().ToUpper()) &&
                   char.IsNumber(input[1]);
        }

        return false;
    }
}