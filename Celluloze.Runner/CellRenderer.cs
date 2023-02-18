using Spectre.Console;

namespace Celluloze.Runner;

internal record CellRenderer(string State, Color Color, char Character = '█');