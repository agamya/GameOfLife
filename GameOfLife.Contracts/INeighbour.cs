#region File Header

//  ***********************************************************************
// Project           : GameOfLife.Contracts
// Author           : Ajay Singh
// Created          : 06/03/2013
// 
// Last Modified By : Ajay Singh
// Last Modified On : 06/03/2013
// ***********************************************************************
//  <copyright file="INeighbour.cs" company="Ajay Singh">
//      Copyright (c) Ajay Singh. All rights reserved.
// </copyright>
// <summary></summary>
//  ***********************************************************************

#endregion

#region

using System.Collections.Generic;

#endregion

namespace GameOfLife.Contracts
{
    #region Using Statements

    

    #endregion

    public interface INeighbour
    {
        /// <summary>
        ///     Retreive all neighbours of the current cell
        /// </summary>
        /// <param name="cell"> Cell for which neighbours needs to be find </param>
        /// <param name="grid"> Grid which contains all cell information </param>
        /// <returns> Retruns the info of all neighbours </returns>
        IEnumerable<ICell> RetrieveNeighbours(ICell cell, IGrid grid);
    }
}