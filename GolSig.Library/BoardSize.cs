using System;

namespace GameOfLife.Library
{
    /// <summary>
    /// Class used to set the size of Board (2 dimensional)
    /// </summary>
    public class BoardSize : IBoardSize
    {
        public int Rows { get; private set; }

        public int Columns { get; private set; }

        public BoardSize(int rows, int columns)
        {
            if (rows <= 0) throw new ArgumentOutOfRangeException( "rows" , "rows value must be > 0");
            if (columns <= 0) throw new ArgumentOutOfRangeException( "columns" , "columns value must be > 0");
            Columns = columns;
            Rows = rows;
        }
    }
}
