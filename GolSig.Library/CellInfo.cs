using System;

namespace GameOfLife.Library
{
    public class CellInfo : System.IEquatable<CellInfo>, ICellInfo
    {
        public Position Position { get;  set; }
       
        public bool Alive { get;  set; }

        //specially for json deserialization
        public CellInfo()
        {
            
        }
        public CellInfo(Position position, bool  alive)
        {
            if (position == null) throw new ArgumentNullException("position");
            Position = position;
            Alive = alive;
        }

        public bool Equals(CellInfo other)
        {
            if (other == null) return false;
            if (other.Alive != this.Alive) return false;
            if (!other.Position.Equals(this.Position)) return false;
            return true;
        }
    }
}
