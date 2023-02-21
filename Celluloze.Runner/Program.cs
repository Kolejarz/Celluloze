using Celluloze.Engine.Factories;
using Celluloze.Engine.Models.CellStateAttributes;
using Celluloze.Runner;
using Spectre.Console;

var cellRenderers = new[]
{
    new CellRenderer(new BooleanCellStateAttribute("Alive", true), Color.Aqua)
};

var consoleRenderer = new ConsoleRenderer(cellRenderers);
var board = BoardFactory.RandomBoard(48, 16, new[] { new BooleanCellStateAttribute("Alive", true) });

consoleRenderer.Render(board);