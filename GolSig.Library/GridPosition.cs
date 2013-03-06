using System;

namespace GameOfLife.Library
{
    internal class GridPosition : IGridPosition
    {
        public int Row { get; private set; }

        public int Column { get; private set; }

        public GridPosition(Position position)
        {
            if (position == null) throw new ArgumentNullException("position");
            Row = position.Row + 1;
            Column = position.Column + 1;
        }

    }
}