// See https://aka.ms/new-console-template for more information
// Author Adam Balko
// Semester project, Programming 1, Winter Semester 2022
// Used Technologies: .NET 6.0, JetBrains Rider, Github Copilot
// Tested on Windows 10

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
    
    while(!InputController.ReadInputAndConfirm()) {}
    
    GameOver.SaveBoardState();
    CommentController.ResetComments();
}

Console.ReadKey();