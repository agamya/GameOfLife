using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameOfLife.Contracts;
using GameOfLife.Core;
using GameOfLife.Models;

namespace GameOfLife.Test.Helper
{
    public static class Helper
    {
        public static IGrid PreConfiguredGrid()
        {
            var grid = new Grid(new GridSize(4, 3));
            var cell = new Cell(new Position(2, 2), true);
            grid.MakeCell(cell);
            cell = new Cell(new Position(3, 1), true);
            grid.MakeCell(cell);
            return grid;
        }
    }
}
