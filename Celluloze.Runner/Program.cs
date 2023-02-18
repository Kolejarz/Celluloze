using Celluloze.Engine.Factories;
using Celluloze.Engine.Models;
using Celluloze.Runner;
using Spectre.Console;

var cellRenderers = new[]
{
    new CellRenderer("EMPTY", Color.Aqua),
    new CellRenderer("OCCUPIED", Color.DarkBlue)
};

var consoleRenderer = new ConsoleRenderer(cellRenderers);
var board = BoardFactory.RandomBoard(48, 16);
board[10, 2] = new Cell("OCCUPIED", 0);
board[6, 13] = new Cell("OCCUPIED", 0);
board[6, 14] = new Cell("O", 0);

consoleRenderer.Render(board);