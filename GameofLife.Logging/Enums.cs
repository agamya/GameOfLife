// ***********************************************************************
// Assembly         : GameofLife.Logging
// Author           : SPG
// Created          : 01-29-2013
//
// Last Modified By : SPG
// Last Modified On : 01-29-2013
// ***********************************************************************
// <copyright file="Enum.cs" company="SportsmanGuide">
//     Copyright (c) SportsmanGuide. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace GameofLife.Logging
{
    #region Namespaces
    using System;
    using System.Collections.Generic;
    using System.Text;
    #endregion

    /// <summary>
    /// This enum corresponds to the categories, configured in Enterprise Library for logging,
    /// that decide about the destination of the log message.
    /// </summary>
    public enum Source
    {
        /// <summary>
        /// Trace information
        /// </summary>
        Trace,
        /// <summary>
        /// Information related to some kind of audit.
        /// </summary>
        Audit,
        /// <summary>
        /// Information about exceptions
        /// </summary>
        Exception
        
    }

    /// <summary>
    /// This enum corresponds to all the possible sources
    /// of log messages in the application.
    /// </summary>
    public enum LogCategory
    {
        /// <summary>
        /// If message is from Presentation tier
        /// </summary>
        Presentation,
        /// <summary>
        /// If message is from Business tier
        /// </summary>
        Business,
        /// <summary>
        /// If message is from DataAccess tier
        /// </summary>
        DataAccess
       
    }
}
