#region File Header

//  ***********************************************************************
// Project           : DataAccess.Specification
// Author           : Ajay Singh
// Created          : 06/03/2013
// 
// Last Modified By : Ajay Singh
// Last Modified On : 06/03/2013
// ***********************************************************************
//  <copyright file="NotSpecification.cs" company="Ajay Singh">
//      Copyright (c) Ajay Singh. All rights reserved.
// </copyright>
// <summary></summary>
//  ***********************************************************************

#endregion

namespace DataAccess.Specification
{
    /// <summary>
    ///     Checks that a specification does not match a condition
    /// </summary>
    public class NotSpecification<TEntity> : ISpecification<TEntity>
    {
        #region Field(s)

        private readonly ISpecification<TEntity> _specification;

        #endregion

        #region Constructor(s)

        /// <summary>
        ///     Initialise a new instance of the NotSpecification class
        /// </summary>
        /// <param name="specification"> </param>
        public NotSpecification(ISpecification<TEntity> specification)
        {
            _specification = specification;
        }

        #endregion

        #region Public Method(s)

        /// <summary>
        ///     Is the specification satisified by the entity?
        /// </summary>
        /// <param name="entity"> </param>
        /// <returns> </returns>
        public bool IsSatisfiedBy(TEntity entity)
        {
            return !(_specification.IsSatisfiedBy(entity));
        }

        #endregion
    }
}