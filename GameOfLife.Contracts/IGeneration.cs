#region File Header

//  ***********************************************************************
// Project           : GameOfLife.Contracts
// Author           : Ajay Singh
// Created          : 06/03/2013
// 
// Last Modified By : Ajay Singh
// Last Modified On : 06/03/2013
// ***********************************************************************
//  <copyright file="IGeneration.cs" company="Ajay Singh">
//      Copyright (c) Ajay Singh. All rights reserved.
// </copyright>
// <summary></summary>
//  ***********************************************************************

#endregion

namespace GameOfLife.Contracts
{
    public interface IGeneration
    {
        /// <summary>
        ///     Create the next generation of grid based on game rules
        /// </summary>
        /// <param name="currentGrid"> Grid which needs to evolve </param>
        /// <param name="gameRules"> Game rules to be applied to generate next generation </param>
        /// <returns> Retruns the instance of newly generated grid </returns>
        IGrid GetNextGeneration(IGrid currentGrid, IGameRules gameRules);
    }
}