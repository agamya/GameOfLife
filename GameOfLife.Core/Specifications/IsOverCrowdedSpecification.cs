#region File Header

//  ***********************************************************************
// Project           : GameOfLife.Core
// Author           : Ajay Singh
// Created          : 06/03/2013
// 
// Last Modified By : Ajay Singh
// Last Modified On : 06/03/2013
// ***********************************************************************
//  <copyright file="IsOverCrowdedSpecification.cs" company="Ajay Singh">
//      Copyright (c) Ajay Singh. All rights reserved.
// </copyright>
// <summary></summary>
//  ***********************************************************************

#endregion

#region

using System.Linq;
using DataAccess.Specification;
using GameOfLife.Contracts;

#endregion

namespace GameOfLife.Core.Specifications
{
    #region Using Statements

    

    #endregion

    /// <summary>
    ///     Check whether the specific cell is overcrowded or not
    ///     Rule for overcrowded is : cell is alive and no of neigbours > 3
    /// </summary>
    public class IsOverCrowdedSpecification : ISpecification<ICell>
    {
        private readonly IGrid _grid;
        private readonly INeighbour _neighbour;

        public IsOverCrowdedSpecification(IGrid grid)
        {
            _grid = grid;
            //This dependency can also be injected with any DI containers for e.g Unity, Autofac or Ninject
            _neighbour = new NeighboursFinder();
        }

        #region ISpecification<ICell> Members

        /// <summary>
        ///     Apply business logic
        /// </summary>
        /// <param name="currentCell"> Cell for which logic needs to apply </param>
        /// <returns> True if o </returns>
        public bool IsSatisfiedBy(ICell currentCell)
        {
            if (currentCell == null) return false;
            //Reterive total neighbours
            var neighbours = _neighbour.RetrieveNeighbours(currentCell, _grid);
            var aliveNeighbours = neighbours.Where(n => n.Alive).ToList();
            return (currentCell.Alive && aliveNeighbours.Count > 3);
        }

        #endregion
    }
}