namespace Celluloze.Engine.Models.CellStateAttributes;

internal record NumberCellStateAttribute(string Name, int Value) : CellStateAttribute<int>(Name, Value);
