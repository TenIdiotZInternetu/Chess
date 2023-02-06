namespace Chess;

public static class GameOver
{
    private static int _fiftyMoveCounter;
    private static Dictionary<string, int> _boardStates = new();
    
    public static bool GameIsOver()
    {
        return CheckCheckmate() ||
               CheckStalemate() ||
               CheckRepetition() ||
               CheckInsufficientMaterial() ||
               Check50MoveRule();
    }
    
    private static bool CheckCheckmate()
    {
        Player player = Player.CurrentPlayer;
        
        if (!player.IsInCheck) return false;
        if (player.LegalMoves.Count > 0) return false;
            
        CommentController.WriteCheckmate(Player.CurrentPlayer);
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
    
    public static void ResetFiftyMoveCounter()
    {
        _boardStates.Clear();
        _fiftyMoveCounter = 0;
    }
    
    public static void IncreaseFiftyMoveCounter()
    {
        _fiftyMoveCounter++;
    }

    public static void SaveBoardState()
    {
        string boardState = Board.NormalizeBoard();
        
        if (!_boardStates.ContainsKey(boardState))
            _boardStates.Add(boardState, 1);
        else
            _boardStates[boardState]++;
    }
}