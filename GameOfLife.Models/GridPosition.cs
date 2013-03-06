#region File Header

//  ***********************************************************************
// Project           : GameOfLife.Models
// Author           : Ajay Singh
// Created          : 06/03/2013
// 
// Last Modified By : Ajay Singh
// Last Modified On : 06/03/2013
// ***********************************************************************
//  <copyright file="GridPosition.cs" company="Ajay Singh">
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

    public class GridPosition : IGridPosition
    {
        public GridPosition(IPosition position)
        {
            if (position == null) throw new ArgumentNullException("position");
            Row = position.Row;
            Column = position.Column;
        }

        #region IGridPosition Members

        public int Row { get; private set; }

        public int Column { get; private set; }

        #endregion
    }
}