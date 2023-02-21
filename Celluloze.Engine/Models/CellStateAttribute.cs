namespace Celluloze.Engine.Models;

public abstract record CellStateAttribute<T>(string Name, T Value) : IComparableStateAttribute;
