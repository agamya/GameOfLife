#region File Header

//  ***********************************************************************
// Project           : GameOfLife.Models
// Author           : Ajay Singh
// Created          : 06/03/2013
// 
// Last Modified By : Ajay Singh
// Last Modified On : 06/03/2013
// ***********************************************************************
//  <copyright file="Cell.cs" company="Ajay Singh">
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

    /// <summary>
    ///     Every cell in the grid is a Cell-object. So it must be as small as possible. 
    ///     Because every cell is pre-generated, no cells have to be generated when the Game Of Life play. 
    ///     Whether a cell is alive or not, is not part of the Cell-object.
    /// </summary>
    public class Cell : ICell
    {
        public Cell(IPosition position, bool alive)
        {
            if (position == null) throw new ArgumentNullException("position");
            Position = position;
            Alive = alive;
        }

        #region ICell Members

        public IPosition Position { get; set; }

        public bool Alive { get; set; }

        /// <summary>
        ///     Compare cell objects
        /// </summary>
        /// <param name="other"> </param>
        /// <returns> </returns>
        public bool Equals(ICell other)
        {
            if (other == null) return false;
            if (other.Alive != Alive) return false;
            if (!other.Position.Equals(Position)) return false;
            return true;
        }

        #endregion
    }
}