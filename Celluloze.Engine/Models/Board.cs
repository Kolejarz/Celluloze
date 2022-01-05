using System.Drawing;

namespace Celluloze.Engine.Models;

public class Board
{
    private readonly Cell[][] _cells;

    public Board(Cell[][] cells)
    {
        _cells = cells;
        Size = new Size { Height = cells.Length, Width = cells[0].Length };
    }

    public Size Size { get; }

    public Cell this[int x, int y]
    {
        get => _cells[y][x]; 
        set => _cells[y][x] = value;
    }
}
