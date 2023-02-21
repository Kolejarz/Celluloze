using Celluloze.Engine;
using Celluloze.Engine.Models;
using Spectre.Console;

namespace Celluloze.Runner;

internal class ConsoleRenderer
{
    private readonly Dictionary<IComparableStateAttribute, CellRenderer> _cellRenderers = new();
    private readonly CellRenderer _defaultCellRenderer;

    public ConsoleRenderer(params CellRenderer[] cellRenderers)
    {
        _defaultCellRenderer = new CellRenderer(default!, Color.White);

        foreach (var cellRenderer in cellRenderers)
        {
            _cellRenderers.Add(cellRenderer.State, cellRenderer);
        }
    }

    public void Render(Board board)
    {
        var width = board.Size.Width;
        var height = board.Size.Height;

        var canvas = new Canvas(width, height);

        for (var x = 0; x < width; x++)
        {
            for (var y = 0; y < height; y++)
            {
                var cell = board[x, y];
                var renderer = _defaultCellRenderer;

                foreach(var (attribute, _) in cell.CellState)
                {
                    if (_cellRenderers.TryGetValue(attribute, out renderer)) break;
                }

                canvas.SetPixel(x, y, renderer?.Color ?? _defaultCellRenderer.Color);
            }
        }

        AnsiConsole.Write(canvas);
    }
}