#region File Header

//  ***********************************************************************
// Project           : GameOfLife.Data
// Author           : Ajay Singh
// Created          : 06/03/2013
// 
// Last Modified By : Ajay Singh
// Last Modified On : 06/03/2013
// ***********************************************************************
//  <copyright file="GridStorage.cs" company="Ajay Singh">
//      Copyright (c) Ajay Singh. All rights reserved.
// </copyright>
// <summary></summary>
//  ***********************************************************************

#endregion

#region

using System;
using GameOfLife.Contracts;
using GameOfLife.Models;

#endregion

namespace GameOfLife.Data
{

    #region Using Statements

    #endregion

    /// <summary>
    ///     Two dimensional array implementation to store te cell information
    /// </summary>
    public class GridStorage : IGridStorage
    {
        #region Private Fields

        private readonly bool[,] _gridDataContainer;
        private readonly IGridSize _gridSize;

        #endregion

        #region Public Methods

        public int Rows
        {
            get { return _gridSize.Rows; }
        }
        public int Columns
        {
            get { return _gridSize.Columns; }
        }
        public GridStorage(IGridSize gridSize)
        {
            if (gridSize == null) throw new ArgumentNullException("gridSize");
            _gridSize = gridSize;
            _gridDataContainer = new bool[gridSize.Rows,gridSize.Columns];
        }

        public void SetCell(IGridPosition gridPosition, bool alive)
        {
            if (gridPosition == null) throw new ArgumentNullException("gridPosition");
            if (!IsValidGridPosition(gridPosition)) throw new ArgumentOutOfRangeException("gridPosition");
            _gridDataContainer[gridPosition.Row, gridPosition.Column] = alive;
        }

        public bool IsCellAlive(IGridPosition gridPosition)
        {
            if (gridPosition == null) throw new ArgumentNullException("gridPosition");
            if (!IsValidGridPosition(gridPosition)) throw new ArgumentOutOfRangeException("gridPosition");
            return _gridDataContainer[gridPosition.Row, gridPosition.Column];
        }

        public ICell GetCell(IGridPosition gridPosition)
        {
            if (gridPosition == null) throw new ArgumentNullException("gridPosition");
            if (!IsValidGridPosition(gridPosition)) throw new ArgumentOutOfRangeException("gridPosition");
            var isCellAlive = IsCellAlive(gridPosition);
            //int getNumberOfAdjacentCells = GetNumberOfAdjacentCells(gridPosition);
            var cell = new Cell(new Position(gridPosition.Row, gridPosition.Column), isCellAlive);
            //cell.Neighbours = getNumberOfAdjacentCells;
            return cell;
        }

        #endregion

        #region Private Methods

        private bool IsValidGridPosition(IGridPosition gridPosition)
        {
            return (gridPosition.Column < _gridSize.Columns && gridPosition.Row < _gridSize.Rows);
        }

        #endregion
    }
}