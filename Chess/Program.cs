// See https://aka.ms/new-console-template for more information

using Chess;

Console.SetWindowSize(29, 24);
Console.BufferHeight = Console.WindowHeight;
Console.BufferWidth = Console.WindowWidth;

BoardRenderer.RenderCoordinates();
Board.SetDefaultPiecePositions();
BoardRenderer.RenderBoard();

bool running = true;
int turn = 0;

for (int i = 0; running; i++)
{
    
    if (i % 2 == 0)
    {
        Player.CurrentPlayer = Player.WhitePlayer;
        turn++;
    }
    else
    {
        Player.CurrentPlayer = Player.BlackPlayer;
    }

    CommentController.WriteTurnNumber(turn);
    CommentController.WritePlayerOnMove(Player.CurrentPlayer);
    
    Player.CurrentPlayer.Threats.Clear();

    foreach (Piece piece in Player.Opponent.ControlledPieces)
    {
        piece.FindLegalMoves();
        
        if (piece.LegalMoves.Contains(Player.CurrentPlayer.King.Position))
        {
            CommentController.WriteCheck(Player.CurrentPlayer);
            Player.CurrentPlayer.Threats.Add(piece);
        }
    }
    
    Player.CurrentPlayer.King.FindLegalMoves();
    
    while(!InputController.ReadInputAndSuccess(Player.CurrentPlayer)) {}
    
    CommentController.ResetComments();
}

Console.ReadKey();