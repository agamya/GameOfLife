using System;
using System.Collections.Generic;

namespace GameOfLife.Library
{
    /// <summary>
    ///  the grid is a "board" with an extra row on top & bottom and an extra column left & right (with dead cells)
    ///  takes care of the position transformations
    /// </summary>
    internal class Grid
    {

        private readonly GridStorage _gridStorage;
        private readonly Board _board;
        private readonly Rules _gameRules;

        public Grid(Board board)
        {
            if (board == null) throw new ArgumentNullException("board");
            _board = board;
            var gridSize = CreateGridSizeFrom(board.BoardSize);
            _gridStorage = new GridStorage(gridSize);
            _gameRules = new Rules();
        }


        public CellInfo GetCurrentCellInfo(Position position)
        {
            if (position == null) throw new ArgumentNullException("position");
            if(!IsValidPosition(position)) throw new ArgumentOutOfRangeException("position");
            var gridPosition = CreateGridPositionFrom(position);
            var isCellAlive = _gridStorage.IsCellAlive(gridPosition);
            var newCell = new CellInfo(position,isCellAlive);
            return newCell;
        }

        public IEnumerable<CellInfo> GetAllCurrentCellInfo()
        {
            for (int i = 0; i < _board.BoardSize.Rows; i++)
            {
                for (int j = 0; j < _board.BoardSize.Columns; j++)
                {
                    yield return GetCurrentCellInfo(new Position(i, j));
                }
            }
        }

        public IEnumerable<CellInfo> GetAllNextGenerationCellInfo()
        {
            for (int i = 0; i < _board.BoardSize.Rows; i++)
            {
                for (int j = 0; j < _board.BoardSize.Columns; j++)
                {
                    yield return CreateNextGenerationCellInfo(new Position(i, j));
                }
            }
        }

      

        public void MakeCell(Position position, bool alive)
        {
            if (position == null) throw new ArgumentNullException("position");
            if (!IsValidPosition(position)) throw new ArgumentOutOfRangeException("position");
            var gridPosition = CreateGridPositionFrom(position);
            _gridStorage.SetCellData(gridPosition, alive);
        }

        private CellInfo CreateNextGenerationCellInfo(Position position)
        {
            var gridPosition = CreateGridPositionFrom(position);
            var currentExtendedGridCellInfo = _gridStorage.CreateExtendedGridCellInfo(gridPosition);
            var aliveNextGeneration = _gameRules.WillBeAliveNextGeneration(currentExtendedGridCellInfo);
            return new CellInfo(position, aliveNextGeneration);
        }
      
        private static GridSize CreateGridSizeFrom(BoardSize boardSize)
        {
            return new GridSize(boardSize.Rows, boardSize.Columns);
        }

        private static GridPosition CreateGridPositionFrom(Position position)
        {
            return new GridPosition(position);
        }

        private bool IsValidPosition(Position position)
        {
            return (position.Column < _board.BoardSize.Columns && position.Row < _board.BoardSize.Rows);
        }

    }
}