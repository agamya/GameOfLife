using System;
using System.Collections.Generic;

namespace GameOfLife.Library
{
    /// <summary>
    /// Matrix like representation of the game board ( rows and columns)
    /// </summary>
    internal class Board : IBoard
    {
       
        private readonly Grid _grid;

        //public BoardSize BoardSize { get; set; }

        public IBoardSize BoardSize { get; set; }


        public Board(IBoardSize  boardSize)
        {
            if (boardSize == null) throw new ArgumentNullException("boardSize");
            BoardSize = boardSize;
            _grid = new Grid(this);
        }

        public Board CreateNextGeneration()
        {
            var newBoard = CloneEmptyNew();

            foreach (var cellInfo in GetAllNextGenerationCellInfo())
            {
                newBoard.MakeCell(cellInfo);
            }
            return newBoard;
        }

        public void Initialize(IEnumerable<CellInfo> cells)
        {
            if (cells == null) return;
            foreach (var cell in cells)
            {
                MakeCell(cell);
            }
        }

        public CellInfo GetCurrentCellInfo(Position position)
        {
            if (position == null) throw new ArgumentNullException("position");
            if (!IsValidPosition(position)) throw new ArgumentOutOfRangeException("position");
            return _grid.GetCurrentCellInfo(position);
        }

        public IEnumerable<CellInfo> GetAllCurrentCellInfo()
        {
            return _grid.GetAllCurrentCellInfo();
        }

        private IEnumerable<CellInfo> GetAllNextGenerationCellInfo()
        {
            return _grid.GetAllNextGenerationCellInfo();
        }

        private void MakeCell(CellInfo cellInfo)
        {
            _grid.MakeCell(cellInfo.Position, cellInfo.Alive);
        }

        private Board CloneEmptyNew()
        {
            return new Board(BoardSize);
        }

        private bool IsValidPosition(Position position)
        {
            return (position.Column <= BoardSize.Columns && position.Row <= BoardSize.Rows);
        }
    }
}