#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using Achilles.Acme.Composition.Modules;
using Achilles.Acme.Plugins;
using Achilles.Acme.Plugins.Services;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Linq;
using System.Reflection;

#endregion

namespace Achilles.Acme.Builder
{
    /// <summary>
    /// Extensions methods for configuring Acme composition via an <see cref="IAcmeBuilder"/>.
    /// </summary>
    public static class AcmeCompositionBuilderExtensions
    {
        /// <summary>
        /// Initializes Acme module composition feature modules.
        /// </summary>
        /// <param name="builder">The <see cref="IAcmeBuilder"/>.</param>
        /// <returns>The <see cref="IAcmeBuilder"/>.</returns>
        public static IAcmeBuilder InitializeModules( this IAcmeBuilder builder )
        {
            if ( builder == null )
            {
                throw new ArgumentNullException( nameof( builder ) );
            }

            // Required services for plugins
            var pluginRegistry = GetServiceFromCollection<IPluginRegistry>( builder.Services );

            // Populate the composition feature
            var compositionFeature = new CompositionFeature();

            builder.PartManager.PopulateFeature( compositionFeature );

            foreach ( var modulePart in compositionFeature.Modules )
            {
                foreach ( var moduleType in modulePart.Types )
                {
                    var module = CreateModule( modulePart.Assembly, moduleType );

                    module.Initialize( builder.Services );

                    pluginRegistry.Add( module as IPlugin );
                }
            }

            return builder;
        }

        #region Private Methods

        private static IModule CreateModule( Assembly moduleAssembly, Type moduleType )
        {
            if ( moduleType == null )
            {
                throw new Exception( string.Format( "Unable to retrieve the module type {0}.", moduleType.Name ) );
            }

            return Activator.CreateInstance( moduleType ) as IModule;
        }

        private static T GetServiceFromCollection<T>( IServiceCollection services )
        {
            return (T)services
                .LastOrDefault( d => d.ServiceType == typeof( T ) )
                ?.ImplementationInstance;
        }

        #endregion
    }
}
