#region File Header

//  ***********************************************************************
// Project           : GameOfLife.Core
// Author           : Ajay Singh
// Created          : 06/03/2013
// 
// Last Modified By : Ajay Singh
// Last Modified On : 06/03/2013
// ***********************************************************************
//  <copyright file="GameRules.cs" company="Ajay Singh">
//      Copyright (c) Ajay Singh. All rights reserved.
// </copyright>
// <summary></summary>
//  ***********************************************************************

#endregion

#region

using System;
using GameOfLife.Contracts;
using GameOfLife.Core.Specifications;

#endregion

namespace GameOfLife.Core
{
    #region Using Statements

    

    #endregion

    /// <summary>
    /// </summary>
    public class GameRules : IGameRules
    {
        #region IGameRules Members

        public bool WillBeAliveInNextGeneration(IGrid grid, ICell cell)
        {
            if (cell == null) throw new ArgumentNullException("cell");
            if (IsOverCrowded(grid, cell))
            {
                //Any live cell with more than three live neighbours dies, as if by overcrowding.
                return false;
            }
            if (IsSurvivable(grid, cell))
            {
                //Any live cell with two or three live neighbours lives on to the next generation.
                return true;
            }
            if (IsUnderPopulated(grid, cell))
            {
                //Any live cell with fewer than two live neighbours dies, as if caused by under-population.
                return false;
            }
            if (IsReproduciable(grid, cell))
            {
                //Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction
                return true;
            }
            return false;
        }

        public bool IsReproduciable(IGrid grid, ICell cell)
        {
            return new IsReproduciableSpecification(grid).IsSatisfiedBy(cell);
        }

        public bool IsUnderPopulated(IGrid grid, ICell cell)
        {
            return new IsUnderPopulatedSpecification(grid).IsSatisfiedBy(cell);
        }

        public bool IsSurvivable(IGrid grid, ICell cell)
        {
            return new IsSurvivableSpecification(grid).IsSatisfiedBy(cell);
        }

        public bool IsOverCrowded(IGrid grid, ICell cell)
        {
            return new IsOverCrowdedSpecification(grid).IsSatisfiedBy(cell);
        }

        #endregion
    }
}