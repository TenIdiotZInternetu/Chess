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
    Player currentPlayer;
    
    if (i % 2 == 0)
    {
        currentPlayer = Player.WhitePlayer;
        turn++;
    }
    else currentPlayer = Player.BlackPlayer;
    
    CommentController.WriteTurnNumber(turn);
    CommentController.WritePlayerOnMove(currentPlayer);
    
    while(!InputController.ReadInputAndSuccess(currentPlayer)) {}
    
    CommentController.ResetComments();
}

Console.ReadKey();