#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System;

#endregion

namespace Achilles.Acme.Filters
{
    /// <summary>
    /// Provides unhandled error exception handling.
    /// </summary>
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        #region Fields

        private readonly ILogger _logger;

        #endregion

        #region Constructor(s)

        public GlobalExceptionFilter(
            ILoggerFactory logger )
        {
            _logger = logger.CreateLogger<GlobalExceptionFilter>();
        }

        #endregion

        #region Public API

        public override void OnException( ExceptionContext context )
        {
            base.OnException( context );

            if ( !context.ExceptionHandled )
                return;

            LogException( context.Exception );
        }

        #endregion

        #region Private Methods

        private void LogException( Exception e )
        {
            _logger.LogError( "ExceptionLogger", e, "An unhandled exception occurred." );
        }

        #endregion
    }
}