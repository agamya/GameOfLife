#region File Header

//  ***********************************************************************
// Project           : GameOfLife.Console
// Author           : Ajay Singh
// Created          : 06/03/2013
// 
// Last Modified By : Ajay Singh
// Last Modified On : 06/03/2013
// ***********************************************************************
//  <copyright file="GridHelper.cs" company="Ajay Singh">
//      Copyright (c) Ajay Singh. All rights reserved.
// </copyright>
// <summary></summary>
//  ***********************************************************************

#endregion

#region

using System;
using System.Collections.Generic;
using System.Diagnostics;
using GameOfLife.Contracts;
using GameOfLife.Core;
using GameofLife.Logging;

#endregion

namespace GameOfLife.Console.Helpers
{
    public static class GridHelper
    {
        public static IGrid CreateGrid(IGridSize gridSize, IEnumerable<ICell> liveCells)
        {
            var grid = new Grid(gridSize);
            //Mark all cells
            foreach (var liveCell in liveCells)
            {
                grid.MakeCell(liveCell.Position, liveCell.Alive);
            }

            return grid;
        }

        public static IGrid GetNextGenerationGrid(IGrid currentGrid, IGameRules gameRules)
        {
            try
            {
                return new Generation().GetNextGeneration(currentGrid, gameRules);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                ApplicationLogger.LogException(1, e, LogCategory.Business, TraceEventType.Error);
            }
            return null;
        }
    }
}