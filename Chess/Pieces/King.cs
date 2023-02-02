using System.Numerics;
using Microsoft.VisualBasic;

namespace Chess;

public class King : Piece
{
    protected override string Symbol => Strings.ChrW(177).ToString();
    private bool _moved = false;
    public King(ConsoleColor color, int xPosition, int yPosition) 
        : base(color, xPosition, yPosition) {}

    public override void Move(Vector2 position)
    {
        _moved = true;
        base.Move(position);
    }
}