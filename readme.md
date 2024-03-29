Semester project for the course Programming 1 at Charles University.  
This build was tested on Windows 10 computers only.  
The application can be further improved by implementing chess notation input and optimizing algorithms checking King's safety.  
Author: Adam Balko  

# How to play

Official rules of Chess can be found [here](https://en.wikipedia.org/wiki/Rules_of_chess#:~:text=Each%20type%20of%20chess%20piece,replaces%20it%20on%20its%20square.)

### Launching the game

Download the full source code of the game  
Find the executable file at <ins>Chess/bin/Release/net6.0/Chess.exe</ins>  
Open the file and you're good to go.

### Moving the pieces

As soon as the application launches, white player can start typing in your moves.  
Start with choosing your piece by specifiyng its position. The format is [file][rank]  
  
  For example: Picking the pawn on E2
  
  ![Picking the pawn on E2](https://cdn.discordapp.com/attachments/481431046089605120/1074035889510035566/image.png)
  
Your picked piece will turn to red, and all of the legal moves on will turn to green. Choose one of the legal moves.  
  
  For example: One of the legal moves for the pawn is E4  
      
      
  ![Moving the pawn to E4](https://cdn.discordapp.com/attachments/481431046089605120/1074037542426513508/image.png)
  
The input is case insensitive.  
If you choose a square you cannot move to or a piece that doesn't belong to you, you will be warned by the console.

  For example: If we tried to move with White's knight on C3
    
    
  ![Moving with opponent's piece](https://cdn.discordapp.com/attachments/481431046089605120/1074039572964593764/image.png)
  
To unpick the chosen piece, simply left the input field blank and hit enter. This will trigger a warning and your move will be reset.

### Castling

To castle, pick your king.  
Then move to the G file to castle short or move to the C file to castle long.  
  
  For example: White wants to castle long by moving to C1
  
  ![Castling long](https://cdn.discordapp.com/attachments/481431046089605120/1074042312595869696/image.png)
  
### Promotion

When you escort your pawn to the other side of the board, you can promote it to another piece.  
Simply fill in one of the provided options.  

  For example: White wants to promote its G pawn to become a queen
  
  ![Promoting to queen](https://cdn.discordapp.com/attachments/481431046089605120/1074044747884273794/image.png)


