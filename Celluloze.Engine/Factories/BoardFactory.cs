using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Celluloze.Engine.Models;

namespace Celluloze.Engine.Factories
{
    public static class BoardFactory
    {
        public static Board EmptyBoard(int width, int height)
        {
            var rows = new List<Cell[]>();
            for(var i = 0; i < height; i++)
            {
                var row = Enumerable.Repeat(new Cell("EMPTY", 0), width).ToArray();
                rows.Add(row);
            }

            return new Board(rows.ToArray());
        }

        public static Board StripesBoard(int width, int height)
        {
            var board = EmptyBoard(width, height);
            for (var rowIndex = 0; rowIndex < height; rowIndex++)
            {
                for (var columnIndex = 0; columnIndex < width; columnIndex++)
                {
                    if ((rowIndex + columnIndex) % 3 == 0)
                    {
                        board[columnIndex, rowIndex] = new Cell("OCCUPIED", 0);
                    }
                }
            }

            return board;
        }

        public static Board RandomBoard(int width, int height, double fillThreshold = 0.66)
        {
            var random = new Random();

            var board = EmptyBoard(width, height);
            for (var rowIndex = 0; rowIndex < height; rowIndex++)
            {
                for (var columnIndex = 0; columnIndex < width; columnIndex++)
                {
                    if (random.NextDouble() > fillThreshold)
                    {
                        board[columnIndex, rowIndex] = new Cell("OCCUPIED", 0);
                    }
                }
            }

            return board;
        }
    }
}
