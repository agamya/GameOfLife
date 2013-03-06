#region File Header

//  ***********************************************************************
// Project           : GameOfLife.Contracts
// Author           : Ajay Singh
// Created          : 06/03/2013
// 
// Last Modified By : Ajay Singh
// Last Modified On : 06/03/2013
// ***********************************************************************
//  <copyright file="IGridSize.cs" company="Ajay Singh">
//      Copyright (c) Ajay Singh. All rights reserved.
// </copyright>
// <summary></summary>
//  ***********************************************************************

#endregion

namespace GameOfLife.Contracts
{
    /// <summary>
    ///     To store the information of Grid
    /// </summary>
    public interface IGridSize
    {
        /// <summary>
        ///     Total number of rows
        /// </summary>
        int Rows { get; }

        /// <summary>
        ///     Total number of columns
        /// </summary>
        int Columns { get; }
    }
}