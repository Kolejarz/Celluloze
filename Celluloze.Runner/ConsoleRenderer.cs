using Celluloze.Engine.Models;
using Spectre.Console;

namespace Celluloze.Runner;

internal class ConsoleRenderer
{
    private readonly Dictionary<string, CellRenderer> _cellRenderers = new();
    private readonly HashSet<string> _missingRenderers = new();
    private readonly CellRenderer _defaultCellRenderer;

    public ConsoleRenderer(params CellRenderer[] cellRenderers)
    {
        _defaultCellRenderer = new CellRenderer(string.Empty, Color.Red);
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
                _ = _cellRenderers.TryGetValue(cell.State, out var renderer);

                canvas.SetPixel(x, y, renderer?.Color ?? _defaultCellRenderer.Color);
            }
        }

        AnsiConsole.Write(canvas);
    }
}