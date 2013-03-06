#region File Header

//  ***********************************************************************
// Project           : GameOfLife.Contracts
// Author           : Ajay Singh
// Created          : 06/03/2013
// 
// Last Modified By : Ajay Singh
// Last Modified On : 06/03/2013
// ***********************************************************************
//  <copyright file="IGrid.cs" company="Ajay Singh">
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

    public interface IGrid
    {
        IGridSize GridSize { get; set; }
        void Initialize(IEnumerable<ICell> cells);
        ICell GetCurrentCellInfo(IPosition position);
        IEnumerable<ICell> GetAllCurrentCellInfo();
        void MakeCell(IPosition position, bool alive);
        void MakeCell(ICell cell);
        IGrid Copy(IGrid currentGrid);
    }
}