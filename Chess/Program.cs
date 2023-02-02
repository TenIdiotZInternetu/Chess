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

Player blackPlayer = new Player(ConsoleColor.Black);
Player whitePlayer = new Player(ConsoleColor.White);

for (int i = 0; running; i++)
{
    Player currentPlayer;
    if (i % 2 == 0)
    {
        currentPlayer = whitePlayer;
        turn++;
    }
    else currentPlayer = blackPlayer;
    
    CommentController.WriteTurnNumber(turn);
    CommentController.WritePlayerOnMove(currentPlayer);
    
    while(!InputController.ReadInputAndSuccess(currentPlayer)) {}
    
    CommentController.ResetComments();
}

Console.ReadKey();