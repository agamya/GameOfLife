#region File Header

//  ***********************************************************************
// Project           : GameOfLife.Contracts
// Author           : Ajay Singh
// Created          : 06/03/2013
// 
// Last Modified By : Ajay Singh
// Last Modified On : 06/03/2013
// ***********************************************************************
//  <copyright file="IGameRules.cs" company="Ajay Singh">
//      Copyright (c) Ajay Singh. All rights reserved.
// </copyright>
// <summary></summary>
//  ***********************************************************************

#endregion

namespace GameOfLife.Contracts
{
    public interface IGameRules
    {
        bool WillBeAliveInNextGeneration(IGrid grid, ICell cell);
        bool IsReproduciable(IGrid grid, ICell cell);
        bool IsUnderPopulated(IGrid grid, ICell cell);
        bool IsSurvivable(IGrid grid, ICell cell);
        bool IsOverCrowded(IGrid grid, ICell cell);
    }
}