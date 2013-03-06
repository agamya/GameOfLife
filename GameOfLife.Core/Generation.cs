#region File Header

//  ***********************************************************************
// Project           : GameOfLife.Core
// Author           : Ajay Singh
// Created          : 06/03/2013
// 
// Last Modified By : Ajay Singh
// Last Modified On : 06/03/2013
// ***********************************************************************
//  <copyright file="Generation.cs" company="Ajay Singh">
//      Copyright (c) Ajay Singh. All rights reserved.
// </copyright>
// <summary></summary>
//  ***********************************************************************

#endregion

#region

using GameOfLife.Contracts;

#endregion

namespace GameOfLife.Core
{
    #region Using Statements

    

    #endregion

    /// <summary>
    ///     Implement Game of life generation (simualtion) algorithms
    /// </summary>
    public class Generation : IGeneration
    {
        #region IGeneration Members

        /// <summary>
        ///     By applying game rules get the next genertion grid instance
        /// </summary>
        /// <param name="currentGrid"> Grid on which games rules </param>
        /// <param name="gameRules"> </param>
        /// <returns> Evolved grid instance </returns>
        public IGrid GetNextGeneration(IGrid currentGrid, IGameRules gameRules)
        {
            if (currentGrid != null && gameRules != null)
            {
                var gridCopy = currentGrid.Copy(currentGrid);
                foreach (var cell in currentGrid.GetAllCurrentCellInfo())
                {
                    cell.Alive = gameRules.WillBeAliveInNextGeneration(gridCopy, cell);
                    gridCopy.MakeCell(cell);
                }
                return gridCopy;
            }
            return null;
        }

        #endregion
    }
}