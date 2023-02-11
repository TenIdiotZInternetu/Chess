namespace Chess;

/// <summary>
/// Responsible for checking whether the game should end or not
/// </summary>
public static class GameOver
{
    /// <summary>
    /// Counts the number of moves without a capture or pawn move
    /// </summary>
    private static int _fiftyMoveCounter;
    
    /// <summary>
    /// Stores how many times the current board state has been reached
    /// </summary>
    private static Dictionary<string, int> _boardStates = new();
    
    /// <summary>
    /// Checks if the players reached either a draw or a win
    /// </summary>
    /// <returns>True if the players reached draw or win</returns>
    public static bool GameIsOver()
    {
        return CheckCheckmate() ||
               CheckStalemate() ||
               CheckRepetition() ||
               CheckInsufficientMaterial() ||
               Check50MoveRule();
    }
    
    // Methods below check for different ways of ending the game
    
    private static bool CheckCheckmate()
    {
        Player player = Player.CurrentPlayer;
        
        if (!player.IsInCheck) return false;
        if (player.LegalMoves.Count > 0) return false;
            
        CommentController.WriteCheckmate(Player.IdlePlayer);
        return true;
    }
    
    private static bool CheckStalemate()
    {
        Player player = Player.CurrentPlayer;
        
        if (player.IsInCheck) return false;
        if (player.LegalMoves.Count > 0) return false;

        CommentController.WriteStalemate();
        return true;
    }
    
    private static bool CheckRepetition()
    {
        if (_boardStates.ContainsValue(3))
        {
            CommentController.WriteRepetition();
            return true;
        }
        else return false;
    }
    
    private static bool CheckInsufficientMaterial()
    {
        if (Player.WhitePlayer.ControlledPieces.Count > 2) return false;
        if (Player.BlackPlayer.ControlledPieces.Count > 2) return false;
        
        List<Type>[] materialConditions ={
            new() { typeof(King)},
            new() { typeof(King), typeof(Knight)},
            new() { typeof(King), typeof(Bishop)},
        };
        
        List<Type> whiteMaterial = Player.WhitePlayer.ControlledPieces
            .Select(piece => piece.GetType())
            .ToList();

        List<Type> blackMaterial = Player.BlackPlayer.ControlledPieces
            .Select(piece => piece.GetType())
            .ToList();

        bool MaterialMatches(List<Type> playerMaterial) => 
            materialConditions.Any(condition => 
                playerMaterial.All(condition.Contains));

        if (MaterialMatches(whiteMaterial) &&
            MaterialMatches(blackMaterial))
        {
            CommentController.WriteInsufficientMaterial();
            return true;
        }
        else return false;
    }
    
    private static bool Check50MoveRule()
    {
        if (_fiftyMoveCounter >= 50)
        {
            CommentController.Write50MoveRule();
            return true;
        }
        else return false;
    }
    
    // Methods above are used to check for different ways of ending the game
    
    /// <summary>
    /// Resets the counter counting towards 50 move draw.
    /// Also resets saved board states, since they cannot be reached again.
    /// </summary>
    public static void ResetFiftyMoveCounter()
    {
        _boardStates.Clear();
        _fiftyMoveCounter = 0;
    }
    
    /// <summary>
    /// Increase counter counting towards 50 move draw.
    /// </summary>
    public static void IncreaseFiftyMoveCounter()
    {
        _fiftyMoveCounter++;
    }

    /// <summary>
    /// Save current board state. Count how many times the state has been reached.
    /// </summary>
    public static void SaveBoardState()
    {
        string boardState = Board.NormalizeBoard();
        
        if (!_boardStates.ContainsKey(boardState))
            _boardStates.Add(boardState, 1);
        else
            _boardStates[boardState]++;
    }
}