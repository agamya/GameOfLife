using System;

namespace GameOfLife.Library
{
    /// <summary>
    /// two dimensional array implementation
    /// </summary>
    internal class GridStorage : IGridStorage
    {
        private readonly bool[,] _gridDataContainer;
        private GridSize _gridSize;

        public GridStorage(GridSize gridSize)
        {
            if (gridSize == null) throw new ArgumentNullException("gridSize");
            _gridSize = gridSize;
            _gridDataContainer = new bool[gridSize.Rows, gridSize.Columns];
        }

        public void SetCellData(GridPosition gridPosition, bool alive)
        {
            if (gridPosition == null) throw new ArgumentNullException("gridPosition");
            if (!IsValidGridPosition(gridPosition)) throw new ArgumentOutOfRangeException("gridPosition");
            _gridDataContainer[gridPosition.Row, gridPosition.Column] = alive;
        }


        public bool IsCellAlive(GridPosition gridPosition)
        {
            if (gridPosition == null) throw new ArgumentNullException("gridPosition");
            if (!IsValidGridPosition(gridPosition)) throw new ArgumentOutOfRangeException("gridPosition");
            return _gridDataContainer[gridPosition.Row, gridPosition.Column];
        }


        public CellStatusInfo GetGridCell(GridPosition gridPosition)
        {
            if (gridPosition == null) throw new ArgumentNullException("gridPosition");
            if (!IsValidGridPosition(gridPosition)) throw new ArgumentOutOfRangeException("gridPosition");
            var isCellAlive = IsCellAlive(gridPosition);
            return new CellStatusInfo(isCellAlive);
        }


        public ExtendedCellStatusInfo CreateExtendedGridCellInfo(GridPosition gridPosition)
        {

            if (!IsValidGridPosition(gridPosition)) throw new ArgumentOutOfRangeException("gridPosition");

            bool isCellAlive = IsCellAlive(gridPosition);
            int getNumberOfAdjacentCells = GetNumberOfAdjacentCells(gridPosition);
            var newCell = new ExtendedCellStatusInfo(isCellAlive, getNumberOfAdjacentCells);
            return newCell;
        }

        private int GetNumberOfAdjacentCells(GridPosition gridPosition)
        {
            int numberOfLivingAdjacentCells=0;
            if (_gridDataContainer[gridPosition.Row - 1, gridPosition.Column - 1]) numberOfLivingAdjacentCells += 1;
            if (_gridDataContainer[gridPosition.Row - 1, gridPosition.Column]) numberOfLivingAdjacentCells += 1;
            if (_gridDataContainer[gridPosition.Row - 1, gridPosition.Column + 1]) numberOfLivingAdjacentCells += 1;
            if (_gridDataContainer[gridPosition.Row, gridPosition.Column - 1]) numberOfLivingAdjacentCells += 1;
            if (_gridDataContainer[gridPosition.Row, gridPosition.Column + 1]) numberOfLivingAdjacentCells += 1;
            if (_gridDataContainer[gridPosition.Row + 1, gridPosition.Column - 1]) numberOfLivingAdjacentCells += 1;
            if (_gridDataContainer[gridPosition.Row + 1, gridPosition.Column]) numberOfLivingAdjacentCells += 1;
            if (_gridDataContainer[gridPosition.Row + 1, gridPosition.Column + 1]) numberOfLivingAdjacentCells += 1;
            return numberOfLivingAdjacentCells;
        }

        private bool IsValidGridPosition(GridPosition gridPosition)
        {
            return (gridPosition.Column < _gridSize.Columns && gridPosition.Row < _gridSize.Rows);
        }




       
    }
}