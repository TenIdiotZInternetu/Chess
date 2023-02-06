// See https://aka.ms/new-console-template for more information

using Chess;

Console.SetWindowSize(29, 24);
Console.BufferHeight = Console.WindowHeight;
Console.BufferWidth = Console.WindowWidth;

BoardRenderer.RenderCoordinates();
Board.SetDefaultPiecePositions();
BoardRenderer.RenderBoard();

bool running = true;
int move = 0;

for (int turn = 0; ; turn++)
{
    if (turn % 2 == 0)
    {
        Player.CurrentPlayer = Player.WhitePlayer;
        move++;
        GameOver.IncreaseFiftyMoveCounter();
    }
    else
        Player.CurrentPlayer = Player.BlackPlayer;

    CommentController.WriteTurnNumber(move);
    CommentController.WritePlayerOnMove(Player.CurrentPlayer);
    
    Player.CurrentPlayer.Threats.Clear();
    Player.IdlePlayer.FindLegalMoves();
    Player.CurrentPlayer.FindLegalMoves();

    if (GameOver.GameIsOver())
        break;
    
    while(!InputController.ReadInputAndConfirm(Player.CurrentPlayer)) {}
    
    GameOver.SaveBoardState();
    CommentController.ResetComments();
}

Console.ReadKey();