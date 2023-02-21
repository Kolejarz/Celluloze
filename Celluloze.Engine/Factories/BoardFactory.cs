using Celluloze.Engine.Models;
using Celluloze.Engine.Models.CellStateAttributes;

namespace Celluloze.Engine.Factories
{
    public static class BoardFactory
    {
        public static Board EmptyBoard(int width, int height)
        {
            var board = new Cell[width, height];

            for(var x = 0; x < width; x++)
            {
                for(var y = 0; y < height; y++)
                {
                    board[x, y] = new Cell(x, y);
                }
            }

            return new Board(board);
        }

        public static Board StripesBoard(int width, int height)
        {
            var board = EmptyBoard(width, height);

            for(var y = 0; y < height; y++)
            {
                for(var x = 0; x < width; x++)
                {
                    if(x + y % 3 == 0)
                    {
                        board[x, y].CellState.Add(new BooleanCellStateAttribute("STRIPE", true), 0);
                    }
                }
            }

            return board;
        }

        public static Board RandomBoard(int width, int height, IComparableStateAttribute[] cellState, double fillThreshold = 0.66)
        {
            var random = new Random();

            var board = EmptyBoard(width, height);

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    if (random.NextDouble() > fillThreshold)
                    {
                        board[x, y].UpdateState(cellState);
                    }
                }
            }

            return board;
        }
    }
}
