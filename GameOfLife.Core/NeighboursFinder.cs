#region File Header

//  ***********************************************************************
// Project           : GameOfLife.Core
// Author           : Ajay Singh
// Created          : 06/03/2013
// 
// Last Modified By : Ajay Singh
// Last Modified On : 06/03/2013
// ***********************************************************************
//  <copyright file="NeighboursFinder.cs" company="Ajay Singh">
//      Copyright (c) Ajay Singh. All rights reserved.
// </copyright>
// <summary></summary>
//  ***********************************************************************

#endregion

#region

using System.Collections.Generic;
using GameOfLife.Contracts;

#endregion

namespace GameOfLife.Core
{
    #region Using Statements

    

    #endregion

    /// <summary>
    ///     Find total alive neighbours of a specific cell
    /// </summary>
    public class NeighboursFinder : INeighbour
    {
        #region INeighbour Members

        /// <summary>
        ///     Count how many neighbours of the specific cell are alive.
        ///     There are total 8 neighbours for a specific cell
        /// </summary>
        /// <param name="cell"> Cell for which neighbours needs to be find </param>
        /// <param name="grid"> Grid which contains all cell information </param>
        /// <returns> Retruns the info of all neighbours </returns>
        public IEnumerable<ICell> RetrieveNeighbours(ICell cell, IGrid grid)
        {
            if (cell == null || grid == null) return null;
            var neighbours = new List<ICell>();
            var currCellPosition = cell.Position;

            //CalculateDiagonalTopLeftNeighbour
            currCellPosition.Row = cell.Position.Row - 1;
            currCellPosition.Column = cell.Position.Column - 1;
            if (IsValidIndex(currCellPosition, grid)) neighbours.Add(grid.GetCurrentCellInfo(currCellPosition));

            //CalculateTopNeighbour
            currCellPosition.Row = cell.Position.Row - 1;
            currCellPosition.Column = cell.Position.Column;
            if (IsValidIndex(currCellPosition, grid)) neighbours.Add(grid.GetCurrentCellInfo(currCellPosition));

            //CalculateDiagonalTopRightNeighbour
            currCellPosition.Row = cell.Position.Row - 1;
            currCellPosition.Column = cell.Position.Column + 1;
            if (IsValidIndex(currCellPosition, grid)) neighbours.Add(grid.GetCurrentCellInfo(currCellPosition));

            //CalculateLeftNeighbour
            currCellPosition.Row = cell.Position.Row;
            currCellPosition.Column = cell.Position.Column - 1;
            if (IsValidIndex(currCellPosition, grid)) neighbours.Add(grid.GetCurrentCellInfo(currCellPosition));

            //CalculateRightNeighbour
            currCellPosition.Row = cell.Position.Row;
            currCellPosition.Column = cell.Position.Column + 1;
            if (IsValidIndex(currCellPosition, grid)) neighbours.Add(grid.GetCurrentCellInfo(currCellPosition));

            //CalculateDiagonalBottomLeftNeighbour
            currCellPosition.Row = cell.Position.Row + 1;
            currCellPosition.Column = cell.Position.Column - 1;
            if (IsValidIndex(currCellPosition, grid)) neighbours.Add(grid.GetCurrentCellInfo(currCellPosition));

            //CalculateBottomNeighbour
            currCellPosition.Row = cell.Position.Row + 1;
            currCellPosition.Column = cell.Position.Column;
            if (IsValidIndex(currCellPosition, grid)) neighbours.Add(grid.GetCurrentCellInfo(currCellPosition));

            //CalculateDiagonalBottomRightNeighbour
            currCellPosition.Row = cell.Position.Row + 1;
            currCellPosition.Column = cell.Position.Column + 1;
            if (IsValidIndex(currCellPosition, grid)) neighbours.Add(grid.GetCurrentCellInfo(currCellPosition));

            return neighbours;
        }

        #endregion

        /// <summary>
        ///     Check whether the current requested cell position is valid withing grid or not
        /// </summary>
        /// <param name="position"> Position information </param>
        /// <param name="grid"> Grid instance to check </param>
        /// <returns> If valid return true else false </returns>
        private bool IsValidIndex(IPosition position, IGrid grid)
        {
            if (position.Row > grid.GridSize.Rows - 1 || position.Row < 0) return false;

            if (position.Column > grid.GridSize.Columns - 1 || position.Column < 0) return false;

            return true;
        }
    }
}