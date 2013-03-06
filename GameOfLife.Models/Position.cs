#region File Header

//  ***********************************************************************
// Project           : GameOfLife.Models
// Author           : Ajay Singh
// Created          : 06/03/2013
// 
// Last Modified By : Ajay Singh
// Last Modified On : 06/03/2013
// ***********************************************************************
//  <copyright file="Position.cs" company="Ajay Singh">
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

    public class Position : IPosition, IEquatable<IPosition>
    {
        public Position(int row, int column)
        {
            if (row < 0) throw new ArgumentOutOfRangeException("row", "row value must be >= 0");
            if (column < 0) throw new ArgumentOutOfRangeException("column", "column value must be >= 0");
            Row = row;
            Column = column;
        }

        #region IPosition Members

        public int Row { get; set; }

        public int Column { get; set; }


        public bool Equals(IPosition other)
        {
            if (other == null) return false;
            if (other.Column != Column) return false;
            if (other.Row != Row) return false;
            return true;
        }

        #endregion
    }
}