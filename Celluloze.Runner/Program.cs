using System.Drawing;using Celluloze.Engine.Factories;
using Celluloze.Engine.Models;
using Celluloze.Runner;

var cellRenderers = new[]
{
    new CellRenderer("EMPTY", ConsoleColor.Cyan),
    new CellRenderer("OCCUPIED", ConsoleColor.DarkBlue)
};

var consoleRenderer = new ConsoleRenderer(cellRenderers);
var board = BoardFactory.RandomBoard(48, 16);
board[10, 2] = new Cell("OCCUPIED", 0);
board[6, 13] = new Cell("OCCUPIED", 0);

consoleRenderer.Render(board);