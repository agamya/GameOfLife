#region File Header

//  ***********************************************************************
// Project           : GameOfLife.Core
// Author           : Ajay Singh
// Created          : 06/03/2013
// 
// Last Modified By : Ajay Singh
// Last Modified On : 06/03/2013
// ***********************************************************************
//  <copyright file="Grid.cs" company="Ajay Singh">
//      Copyright (c) Ajay Singh. All rights reserved.
// </copyright>
// <summary></summary>
//  ***********************************************************************

#endregion

#region

using System;
using System.Collections.Generic;
using System.Linq;
using GameOfLife.Contracts;
using GameOfLife.Data;
using GameOfLife.Models;

#endregion

namespace GameOfLife.Core
{

    /// <summary>
    ///   The class contains the grid information
    /// </summary>
    public class Grid : IGrid
    {
        private readonly IGridStorage _gridStorage;

        public Grid(IGridSize gridSize)
        {
            if (gridSize == null) throw new ArgumentNullException("gridSize");
            GridSize = gridSize;
            _gridStorage = new GridStorage(gridSize);
        }

        #region IGrid Members

        public ICell GetCurrentCellInfo(IPosition position)
        {
            if (position == null) throw new ArgumentNullException("position");
            if (!IsValidPosition(position)) throw new ArgumentOutOfRangeException("position");
            var gridPosition = CreateGridPositionFrom(position);
            var isCellAlive = _gridStorage.IsCellAlive(gridPosition);
            var newCell = new Cell(position, isCellAlive);
            return newCell;
        }

        public IEnumerable<ICell> GetAllCurrentCellInfo()
        {
            for (int i = 0; i < GridSize.Rows; i++)
            {
                for (int j = 0; j < GridSize.Columns; j++)
                {
                    yield return GetCurrentCellInfo(new Position(i, j));
                }
            }
        }

        public void MakeCell(IPosition position, bool alive)
        {
            if (position == null) throw new ArgumentNullException("position");
            if (!IsValidPosition(position)) throw new ArgumentOutOfRangeException("position");
            var gridPosition = CreateGridPositionFrom(position);
            _gridStorage.SetCell(gridPosition, alive);
        }

        public void MakeCell(ICell cell)
        {
            MakeCell(cell.Position, cell.Alive);
        }

        /// <summary>
        ///     Create new instance of current grid
        /// </summary>
        /// <param name="currentGrid"> Current grid </param>
        /// <returns> Retunr new grid instance </returns>
        public IGrid Copy(IGrid currentGrid)
        {
            var gridCopy = new Grid(currentGrid.GridSize);
            foreach (
                var newCell in currentGrid.GetAllCurrentCellInfo().Select(cell => new Cell(cell.Position, cell.Alive)))
            {
                gridCopy.MakeCell(newCell);
            }

            return gridCopy;
        }

        public void Initialize(IEnumerable<ICell> cells)
        {
            if (cells == null) return;
            foreach (var cell in cells)
            {
                MakeCell(cell.Position, cell.Alive);
            }
        }

        public IGridSize GridSize { get; set; }

        #endregion

        private IGridPosition CreateGridPositionFrom(IPosition position)
        {
            return new GridPosition(position);
        }

        private bool IsValidPosition(IPosition position)
        {
            return (position.Column < GridSize.Columns && position.Row < GridSize.Rows);
        }


    }
}