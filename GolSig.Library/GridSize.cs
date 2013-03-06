using System;

namespace GameOfLife.Library
{

    internal class GridSize :IGridSize
    {
        public int Rows { get; private set; }

        public int Columns { get; private set; }

        internal GridSize(int rows, int columns)
        {
            if (rows <= 0) throw new ArgumentOutOfRangeException("rows", "rows value must be > 0");
            if (columns <= 0) throw new ArgumentOutOfRangeException("columns", "columns value must be > 0");
            Rows = rows + 2;
            Columns = columns + 2;
        }
    }
}