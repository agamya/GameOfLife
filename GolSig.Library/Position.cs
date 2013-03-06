using System;

namespace GameOfLife.Library
{
    public class Position : IEquatable<Position>, IPosition
    {
        public int Row { get;  set; }

        public int Column { get;  set; }

        //specialy for json deserialization
        public Position()
        {
                
        }
        public Position(int row , int column)
        {
            if (row < 0) throw new ArgumentOutOfRangeException( "row","row value must be >= 0");
            if (column < 0) throw new ArgumentOutOfRangeException( "column" , "column value must be >= 0");
            Row = row;
            Column = column;
        }

        public bool Equals(Position other)
        {
            if (other == null) return false;
            if (other.Column != this.Column) return false;
            if (other.Row != this.Row) return false;
            return true;
        }
    }
}
