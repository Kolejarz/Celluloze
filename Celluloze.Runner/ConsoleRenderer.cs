using Celluloze.Engine.Models;

namespace Celluloze.Runner;

internal class ConsoleRenderer
{
    private readonly Dictionary<string, CellRenderer> _cellRenderers = new();
    private readonly HashSet<string> _missingRenderers = new();
    private readonly CellRenderer _defaultCellRenderer;

    public ConsoleRenderer(params CellRenderer[] cellRenderers)
    {
        _defaultCellRenderer = new CellRenderer(string.Empty, ConsoleColor.Black);
        foreach (var cellRenderer in cellRenderers)
        {
            _cellRenderers.Add(cellRenderer.State, cellRenderer);
        }
    }

    public void Render(Board board)
    {
        Console.SetCursorPosition(0, 0);
        var height = board.Size.Height;
        var width = board.Size.Width;

        var horizontalBorder = new string(AsciiDrawingBoxes.HorizontalThin, width * 2);

        Console.WriteLine($"{AsciiDrawingBoxes.TopLeftThin}{horizontalBorder}{AsciiDrawingBoxes.TopRightThin}");
        for (var rowIndex = 0; rowIndex < height; rowIndex++)
        {
            Console.Write(AsciiDrawingBoxes.VerticalThin);
            for (var columnIndex = 0; columnIndex < width; columnIndex++)
            {
                RenderCell(board[columnIndex, rowIndex]);
            }
            Console.WriteLine(AsciiDrawingBoxes.VerticalThin);
        }
        Console.WriteLine($"{AsciiDrawingBoxes.BottomLeftThin}{horizontalBorder}{AsciiDrawingBoxes.BottomRightThin}");

        if (_missingRenderers.Any())
        {
            DisplayWarning($"Missing state renderer detected: {string.Join('\r', _missingRenderers.ToList())}");
        }
    }

    private static void DisplayWarning(string message)
    {
        Console.BackgroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    private void RenderCell(Cell cell)
    {
        var cellRendererConfigured = _cellRenderers.TryGetValue(cell.State, out var cellRenderer);
        if (!cellRendererConfigured)
        {
            _missingRenderers.Add(cell.State);
        }
        cellRenderer ??= _defaultCellRenderer;

        Console.ForegroundColor = cellRenderer.Color;
        Console.Write($"{cellRenderer.Character}{cellRenderer.Character}");
        Console.ResetColor();
    }

    private static class AsciiDrawingBoxes
    {
        internal static char TopLeftThin => '┌';
        internal static char TopRightThin => '┐';
        internal static char BottomLeftThin => '└';
        internal static char BottomRightThin => '┘';

        internal static char TopLeftThick => '┏';
        internal static char TopRightThick => '┓';
        internal static char BottomLeftThick => '┗';
        internal static char BottomRightThick => '┛';

        internal static char HorizontalThin => '─';
        internal static char VerticalThin => '│';

        internal static char HorizontalThick => '━';
        internal static char VerticalThick => '┃';
    }
}