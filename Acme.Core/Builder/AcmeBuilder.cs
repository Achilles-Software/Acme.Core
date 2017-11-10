#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection;

using System;

#endregion

namespace Achilles.Acme.Builder
{
    /// <summary>
    /// Provides configuration of Acme services.
    /// </summary>
    public class AcmeBuilder : IAcmeBuilder
    {
        #region Properties

        /// <inheritdoc />
        public IServiceCollection Services { get; }

        /// <inheritdoc />
        public ApplicationPartManager PartManager { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes an instance of <see cref="AcmeBuilder"/>
        /// </summary>
        /// <param name="services">The <see cref="ServiceCollection"/> to add Acme services.</param>
        /// <param name="manager">The <see cref="ApplicationPartManager"/> for the Acme application.</param>
        public AcmeBuilder( IServiceCollection services, ApplicationPartManager manager )
        {
            Services = services ?? throw new ArgumentNullException( nameof( services ) );
            PartManager = manager ?? throw new ArgumentNullException( nameof( manager ) );
        }

        #endregion
    }
}
