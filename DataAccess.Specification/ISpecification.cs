#region File Header

//  ***********************************************************************
// Project           : DataAccess.Specification
// Author           : Ajay Singh
// Created          : 06/03/2013
// 
// Last Modified By : Ajay Singh
// Last Modified On : 06/03/2013
// ***********************************************************************
//  <copyright file="ISpecification.cs" company="Ajay Singh">
//      Copyright (c) Ajay Singh. All rights reserved.
// </copyright>
// <summary></summary>
//  ***********************************************************************

#endregion

namespace DataAccess.Specification
{
    /// <summary>
    ///     Defines a interface for implementing a Specification Pattern
    /// </summary>
    public interface ISpecification<TEntity>
    {
        #region Method Declarations

        /// <summary>
        ///     Is the specification satisified by the entity?
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        bool IsSatisfiedBy(TEntity entity);

        #endregion
    }
}