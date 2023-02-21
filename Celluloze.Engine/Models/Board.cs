using System.Drawing;

namespace Celluloze.Engine.Models;

public class Board
{
    private readonly Cell[,] _cells;

    public Board(Cell[,] cells)
    {
        _cells = cells;
        Size = new Size { Height = cells.GetLength(1), Width = cells.GetLength(0) };
    }

    public Size Size { get; }

    public Cell this[int x, int y]
    {
        get => _cells[x, y];
        set => _cells[x, y] = value;
    }
}
