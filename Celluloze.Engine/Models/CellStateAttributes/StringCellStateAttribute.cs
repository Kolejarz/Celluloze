namespace Celluloze.Engine.Models.CellStateAttributes;

internal record StringCellStateAttribute(string Name, string Value) : CellStateAttribute<string>(Name, Value);
