﻿#region File Header

//  ***********************************************************************
// Project           : DataAccess.Specification
// Author           : Ajay Singh
// Created          : 06/03/2013
// 
// Last Modified By : Ajay Singh
// Last Modified On : 06/03/2013
// ***********************************************************************
//  <copyright file="SpecificationExtensionMethods.cs" company="Ajay Singh">
//      Copyright (c) Ajay Singh. All rights reserved.
// </copyright>
// <summary></summary>
//  ***********************************************************************

#endregion

namespace DataAccess.Specification
{
    /// <summary>
    ///     Extension methods for implementing the Specification pattern
    /// </summary>
    public static class SpecificationExtensionMethods
    {
        #region Public Method(s)

        /// <summary>
        ///     Makes an entity satisfy two specification
        /// </summary>
        /// <typeparam name="TEntity"> </typeparam>
        /// <param name="specificationOne"> </param>
        /// <param name="specificationTwo"> </param>
        /// <returns> </returns>
        public static ISpecification<TEntity> And<TEntity>(this ISpecification<TEntity> specificationOne,
                                                           ISpecification<TEntity> specificationTwo)
        {
            return new AndSpecification<TEntity>(specificationOne, specificationTwo);
        }

        /// <summary>
        ///     Makes a entity satisfy the first OR second specification
        /// </summary>
        /// <typeparam name="TEntity"> </typeparam>
        /// <param name="specificationOne"> </param>
        /// <param name="specificationTwo"> </param>
        /// <returns> </returns>
        public static ISpecification<TEntity> Or<TEntity>(this ISpecification<TEntity> specificationOne,
                                                          ISpecification<TEntity> specificationTwo)
        {
            return new OrSpecification<TEntity>(specificationOne, specificationTwo);
        }


        /// <summary>
        ///     Makes sure an entity does not satisfy the specification
        /// </summary>
        /// <typeparam name="TEntity"> </typeparam>
        /// <param name="specification"> </param>
        /// <returns> </returns>
        public static ISpecification<TEntity> Not<TEntity>(this ISpecification<TEntity> specification)
        {
            return new NotSpecification<TEntity>(specification);
        }

        #endregion
    }
}