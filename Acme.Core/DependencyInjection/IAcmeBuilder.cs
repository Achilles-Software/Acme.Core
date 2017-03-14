#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using Achilles.Acme.Composition;
using Achilles.Acme.Composition.Modules;

#endregion

namespace Achilles.Acme.DependencyInjection
{
    /// <summary>
    /// The inteface for configuring ACME services.
    /// </summary>
    public interface IAcmeBuilder
    {
        /// <summary>
        /// Gets the <see cref="IServiceCollection"/> where ACME services are configured.
        /// </summary>
        IServiceCollection Services { get; }

        /// <summary>
        /// Gets the <see cref="CompositionManager"/> where <see cref="ComposablePart"/>s are configured.
        /// </summary>
        ComposablePartManager CompositionManager { get; }
    }
}
