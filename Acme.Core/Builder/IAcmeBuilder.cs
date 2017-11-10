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

#endregion

namespace Achilles.Acme.Builder
{
    /// <summary>
    /// The inteface for configuring Acme services.
    /// </summary>
    public interface IAcmeBuilder
    {
        /// <summary>
        /// Gets the <see cref="IServiceCollection"/> where Acme services are configured.
        /// </summary>
        IServiceCollection Services { get; }

        /// <summary>
        /// Gets the <see cref="ApplicationPartManager"/> where <see cref="ApplicationPart"/>s
        /// are configured.
        /// </summary>
        ApplicationPartManager PartManager { get; }
    }
}
