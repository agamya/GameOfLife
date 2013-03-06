#region File Header

//  ***********************************************************************
// Project           : GameOfLife.Console
// Author           : Ajay Singh
// Created          : 06/03/2013
// 
// Last Modified By : Ajay Singh
// Last Modified On : 06/03/2013
// ***********************************************************************
//  <copyright file="UIHelper.cs" company="Ajay Singh">
//      Copyright (c) Ajay Singh. All rights reserved.
// </copyright>
// <summary></summary>
//  ***********************************************************************

#endregion

#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameOfLife.Contracts;
using GameOfLife.Models;

#endregion

namespace GameOfLife.Console.Helpers
{
    #region Using Statements

    

    #endregion

    public static class UiHelper
    {
        #region Constants

        private const char LiveCell = 'X';
        private const char DeadCell = '-';
        private const char Separator = ' ';
        private const char ColumnSeparator = ',';
        private const char RowSeparator = '|';

        #endregion

        #region Extension Methods

        /// <summary>
        ///     Takes individual cells and returns a formatted
        ///     string representing the grid.
        /// </summary>
        /// <param name="grid"> </param>
        /// <returns> </returns>
        public static string ToConsoleFormattedString(this IGrid grid)
        {
            if (grid == null) return string.Empty;
            var builder = new StringBuilder();
            for (var rowIndex = 0; rowIndex < grid.GridSize.Rows; rowIndex++)
            {
                for (var columnIndex = 0; columnIndex < grid.GridSize.Columns; columnIndex++)
                {
                    builder.Append(grid.GetCurrentCellInfo(new Position(rowIndex, columnIndex)).Alive
                                       ? LiveCell
                                       : DeadCell);
                    builder.Append(Separator);
                }
                builder.Append(Environment.NewLine);
            }

            return builder.ToString();
        }

        /// <summary>
        ///     Parses a string specifying row and column index of a live 
        ///     <see cref="ICell" /> 
        ///     The format of the sting is rowIndex,colIndex | rowIndex,colIndex
        ///     and returns a <see cref="IGrid{ICell}" /> object containing <paramref name="numberofRows" />
        ///     rows and <paramref name="numberOfcolumns" />
        /// </summary>
        /// <param name="gridRowColumnString"> </param>
        /// <returns> </returns>
        public static IGridSize GetGridSize(this string gridRowColumnString)
        {
            if (gridRowColumnString == null) return null;
            gridRowColumnString = gridRowColumnString.Trim(' ', ColumnSeparator);
            if (gridRowColumnString.Length != 0) //no alive cells
            {
                return ParseGridSize(gridRowColumnString);
            }
            return null;
        }

        /// <summary>
        ///     Parses a string specifying row and column index of a live 
        ///     <see cref="ICell" /> 
        ///     The format of the sting is rowIndex,colIndex | rowIndex,colIndex
        ///     and returns a <see cref="IGrid{ICell}" /> object containing <paramref name="numberofRows" />
        ///     rows and <paramref name="numberOfcolumns" />
        /// </summary>
        /// <param name="gridRowColumnString"> </param>
        /// <param name="gridSize"> </param>
        /// <returns> </returns>
        public static IEnumerable<ICell> ParseLiveCell(this string gridRowColumnString, IGridSize gridSize)
        {
            //create a grid and initialize it with dead cells
            //var grid = CreateGrid(numberofRows, numberOfcolumns);

            var liveCells = new List<ICell>();
            gridRowColumnString = gridRowColumnString.Trim(' ', RowSeparator);
            if (gridRowColumnString.Length != 0) //no alive cells
            {
                var rowColumnPairs = gridRowColumnString.Split(RowSeparator);
                liveCells.AddRange(
                    rowColumnPairs.Select(rowColumnPair => ParseCellPosition(rowColumnPair, gridSize)).Select(
                        cellPosition => new Cell(cellPosition, true)).Cast<ICell>());
            }

            return liveCells;
        }

        #endregion

        #region Private Methods

        private static IGridSize ParseGridSize(string rowColumnPair)
        {
            if (!rowColumnPair.Contains(ColumnSeparator)) //no valid row,col index pair
            {
                throw new ArgumentException(string.Format("The row column pair {0} has no rowColumn separator",
                                                          rowColumnPair));
            }

            var cellIndex = rowColumnPair.Split(ColumnSeparator);
            if (!cellIndex.Any()) //no valid row,col index
            {
                throw new ArgumentException(string.Format("The row column pair {0} is not valid", rowColumnPair));
            }

            int rowIndex;
            if (!Int32.TryParse(cellIndex[0], out rowIndex) || rowIndex < 0)
            {
                throw new ArgumentException(string.Format("The row column pair {0} is not valid", rowColumnPair));
            }

            int colIndex;
            if (!Int32.TryParse(cellIndex[1], out colIndex) || colIndex < 0)
            {
                throw new ArgumentException(string.Format("The row column pair {0} is not valid", rowColumnPair));
            }

            return new GridSize(rowIndex, colIndex);
        }

        private static IPosition ParseCellPosition(string rowColumnPair, IGridSize gridSize)
        {
            if (!rowColumnPair.Contains(ColumnSeparator)) //no valid row,col index pair
            {
                throw new ArgumentException(string.Format("The row column pair {0} has no rowColumn separator",
                                                          rowColumnPair));
            }

            var cellIndex = rowColumnPair.Split(ColumnSeparator);
            if (!cellIndex.Any()) //no valid row,col index
            {
                throw new ArgumentException(string.Format("The row column pair {0} is not valid", rowColumnPair));
            }

            int rowIndex;
            if (!Int32.TryParse(cellIndex[0], out rowIndex) || rowIndex < 0 || rowIndex >= gridSize.Rows)
            {
                throw new ArgumentException(string.Format("The row column pair {0} is not valid", rowColumnPair));
            }

            int colIndex;
            if (!Int32.TryParse(cellIndex[1], out colIndex) || colIndex < 0 || colIndex >= gridSize.Columns)
            {
                throw new ArgumentException(string.Format("The row column pair {0} is not valid", rowColumnPair));
            }

            return new Position(rowIndex, colIndex);
        }

        #endregion
    }
}