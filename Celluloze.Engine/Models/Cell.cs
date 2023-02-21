using System.Drawing;

namespace Celluloze.Engine.Models;

public class Cell
{
    private readonly Dictionary<Point, Cell> _neighbors = new();
    private readonly Dictionary<IComparableStateAttribute, int> _cellState = new();

    public Dictionary<Point, Cell> Neighbors => _neighbors;

    public Dictionary<IComparableStateAttribute, int> CellState => _cellState;

    public int X { get; }

    public int Y { get; }

    public Cell(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void InitializeNeighbors(Dictionary<Point, Cell> neighbors)
    {
        if (_neighbors.Any())
        {
            throw new InvalidOperationException("Changing neighbors is not possible after initialization");
        }

        foreach(var (coordinates, neighbor) in neighbors)
        {
            _neighbors[coordinates] = neighbor;
        }
    }

    public void UpdateState(params IComparableStateAttribute[] cellStateAttributes)
    {
        foreach(var attribute in cellStateAttributes)
        {
            if(_cellState.ContainsKey(attribute))
            {
                _cellState[attribute]++;
                continue;
            }

            var existingAttribute = _cellState.Keys.SingleOrDefault(attr => attr.Name == attribute.Name);
            if (existingAttribute is not null)
            {
                _cellState.Remove(existingAttribute);
            }

            _cellState.Add(attribute, 0);
        }
    }
}
