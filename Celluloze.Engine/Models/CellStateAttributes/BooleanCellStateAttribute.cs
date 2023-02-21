namespace Celluloze.Engine.Models.CellStateAttributes;

public record BooleanCellStateAttribute(string Name, bool Value) : CellStateAttribute<bool>(Name, Value);

