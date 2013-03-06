#region File Header

//  ***********************************************************************
// Project           : GameOfLife.Contracts
// Author           : Ajay Singh
// Created          : 06/03/2013
// 
// Last Modified By : Ajay Singh
// Last Modified On : 06/03/2013
// ***********************************************************************
//  <copyright file="IPosition.cs" company="Ajay Singh">
//      Copyright (c) Ajay Singh. All rights reserved.
// </copyright>
// <summary></summary>
//  ***********************************************************************

#endregion

namespace GameOfLife.Contracts
{
    public interface IPosition
    {
        int Row { get; set; }
        int Column { get; set; }
        bool Equals(IPosition other);
    }
}