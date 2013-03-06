namespace GameOfLife.Library
{
    internal class ExtendedCellStatusInfo : System.IEquatable<ExtendedCellStatusInfo>
    {
    
        
        public bool Alive { get; private set; }

        public int NumberOfLivingAdjacentCells
        {
            get;
            private set;
        }

        public ExtendedCellStatusInfo(bool alive , int numberOfLivingAdjacentCells)
        {
            if (numberOfLivingAdjacentCells < 0 || numberOfLivingAdjacentCells > 8) throw new System.ArgumentOutOfRangeException("numberOfLivingAdjacentCells");
            Alive = alive;
            NumberOfLivingAdjacentCells = numberOfLivingAdjacentCells;
        }

        public bool Equals(ExtendedCellStatusInfo other)
        {
            if (other == null) return false;
            if (other.Alive != this.Alive) return false;
            if (other.NumberOfLivingAdjacentCells != this.NumberOfLivingAdjacentCells) return false;
            return true;
        }
    }
}