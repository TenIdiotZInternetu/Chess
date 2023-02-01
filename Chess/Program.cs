// See https://aka.ms/new-console-template for more information

using Chess;

Console.SetWindowSize(32, 20);
BoardRenderer.RenderCoordinates();
Board.SetDefaultPiecePositions();
BoardRenderer.RenderBoard();

bool running = true;
int turn = 1;

Player blackPlayer = new Player(ConsoleColor.Black);
Player whitePlayer = new Player(ConsoleColor.White);

for (int i = 0; running; i++)
{
    Player currentPlayer;
    if (i % 2 == 0) currentPlayer = whitePlayer;
    else currentPlayer = blackPlayer;
    
    while(!InputController.ReadInputAndSuccess(currentPlayer)) {}
}


Console.ReadKey();