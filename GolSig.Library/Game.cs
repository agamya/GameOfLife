using System;
using System.Collections.Generic;

namespace GameOfLife.Library
{
    /// <summary>
    /// You can play the game
    ///     initialize it with living cells
    ///     ask for the next generation
    ///     read the cell info
    /// </summary>
    public class Game : IGame
    {
        private Board Board { get; set; }

        public Game(IBoardSize boardSize)
        {
            if (boardSize == null) throw new ArgumentNullException("boardSize");
            Board = new Board(boardSize);
        }

        public void Initialize(IEnumerable<CellInfo> cells)
        {
            if (cells == null) throw new ArgumentNullException("cells");
            Board.Initialize(cells);
        }

        public IEnumerable<CellInfo> Cells()
        {
            return Board.GetAllCurrentCellInfo();
        }

        //test purpose only
        public CellInfo Cell(Position position)
        {
            if (position == null) throw new ArgumentNullException("position");
            return Board.GetCurrentCellInfo(position);
        }

        public void Next()
        {
            var newBoard = Board.CreateNextGeneration();
            Board = newBoard;
        }

    }
}