#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using Achilles.Acme.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

#endregion

namespace Achilles.Acme.Builder
{
    /// <summary>
    /// Extensions for configuring Acme using an <see cref="IAcmeBuilder"/>.
    /// </summary>
    public static class AcmeBuilderExtensions
    {
        /// <summary>
        /// Registers an action to configure <see cref="AcmeOptions"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IAcmeBuilder"/>.</param>
        /// <param name="setupAction">An <see cref="Action{AcmeOptions}"/>.</param>
        /// <returns>The <see cref="IAcmeBuilder"/>.</returns>
        public static IAcmeBuilder AddAcmeOptions( this IAcmeBuilder builder,  Action<AcmeOptions> setupAction )
        {
            if ( builder == null )
            {
                throw new ArgumentNullException( nameof( builder ) );
            }

            if ( setupAction == null )
            {
                throw new ArgumentNullException( nameof( setupAction ) );
            }

            builder.Services.Configure<AcmeOptions>( setupAction );

            return builder;
        }
    }
}
