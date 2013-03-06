#region File Header

//  ***********************************************************************
// Project           : DataAccess.Specification
// Author           : Ajay Singh
// Created          : 06/03/2013
// 
// Last Modified By : Ajay Singh
// Last Modified On : 06/03/2013
// ***********************************************************************
//  <copyright file="AndSpecification.cs" company="Ajay Singh">
//      Copyright (c) Ajay Singh. All rights reserved.
// </copyright>
// <summary></summary>
//  ***********************************************************************

#endregion

namespace DataAccess.Specification
{
    /// <summary>
    ///     Joins two Specifications in an And condition
    /// </summary>
    public class AndSpecification<TEntity> : ISpecification<TEntity>
    {
        #region Field(s)

        private readonly ISpecification<TEntity> _specificationOne;
        private readonly ISpecification<TEntity> _specificationTwo;

        #endregion

        #region Constructor(s)

        /// <summary>
        ///     Initialise a new instance of the AndSpecification class
        /// </summary>
        /// <param name="specificationOne"> </param>
        /// <param name="specificationTwo"> </param>
        public AndSpecification(ISpecification<TEntity> specificationOne, ISpecification<TEntity> specificationTwo)
        {
            _specificationOne = specificationOne;
            _specificationTwo = specificationTwo;
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
            return (_specificationOne.IsSatisfiedBy(entity) && _specificationTwo.IsSatisfiedBy(entity));
        }

        #endregion
    }
}