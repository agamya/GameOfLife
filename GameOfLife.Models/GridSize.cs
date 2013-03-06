#region File Header

//  ***********************************************************************
// Project           : GameOfLife.Models
// Author           : Ajay Singh
// Created          : 06/03/2013
// 
// Last Modified By : Ajay Singh
// Last Modified On : 06/03/2013
// ***********************************************************************
//  <copyright file="GridSize.cs" company="Ajay Singh">
//      Copyright (c) Ajay Singh. All rights reserved.
// </copyright>
// <summary></summary>
//  ***********************************************************************

#endregion

#region

using System;
using GameOfLife.Contracts;

#endregion

namespace GameOfLife.Models
{
    #region Using Statements

    

    #endregion

    public class GridSize : IGridSize
    {
        public GridSize(int rows, int columns)
        {
            if (rows <= 0) throw new ArgumentOutOfRangeException("rows", "rows value must be > 0");
            if (columns <= 0) throw new ArgumentOutOfRangeException("columns", "columns value must be > 0");
            Rows = rows;
            Columns = columns;
        }

        #region IGridSize Members

        public int Rows { get; private set; }

        public int Columns { get; private set; }

        #endregion
    }
}