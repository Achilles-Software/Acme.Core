#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using Achilles.Acme.Composition;
using Achilles.Acme.Composition.Modules;
using Achilles.Acme.Configuration;
using Achilles.Acme.Plugins;
using Achilles.Acme.Plugins.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

#endregion

namespace Achilles.Acme.DependencyInjection
{
    public class AcmeBuilder : IAcmeBuilder
    {
        #region Properties

        public IServiceCollection Services { get; }

        public ComposablePartManager CompositionManager { get; private set; }

        #endregion

        #region Constructor

        public AcmeBuilder( IServiceCollection services )
        {
            if ( services == null )
            {
                throw new ArgumentNullException( nameof( services ) );
            }

            Services = services;

            CompositionManager = new ComposablePartManager();
        }

        #endregion

        #region Public Methods

        public void AddModuleServices()
        {
            var environment = GetServiceFromCollection<IHostingEnvironment>( Services );
            var pluginRegistry = GetServiceFromCollection<IPluginRegistry>( Services );

            if ( environment == null )
            {
                return;
            }

            // Get a list of candidate composable part assemblies.. 
            var parts = ComposableAssemblyDiscoveryProvider.DiscoverComposableAssemblies( environment.ApplicationName );

            foreach ( var part in parts )
            {
                CompositionManager.ComposableParts.Add( part );
            }

            foreach ( ComposablePart composablePart in CompositionManager.ComposableParts )
            {
                var p = composablePart;

                foreach ( var type in composablePart.Types )
                {
                    if ( ModuleConventions.IsModule( type ) )
                    {
                        var moduleObject = this.CreateModule( composablePart.Assembly, type.AsType() );

                        var module = moduleObject as IModule;
                        var pluginBase = moduleObject as PluginBase;
                        var plugin = moduleObject as IPlugin;

                        module.Initialize( Services );

                        pluginRegistry.Add( plugin );
                    }
                }
            }
        }

        #endregion

        #region Private Methods

        private object CreateModule( Assembly moduleAssembly, Type moduleType )
        {
            if ( moduleType == null )
            {
                throw new Exception( string.Format( "Unable to retrieve the module type {0} from the loaded assemblies.", moduleType.Name ) );
            }

            var moduleObject = moduleAssembly.CreateInstance( moduleType.FullName );

            return moduleObject;
        }

        private static T GetServiceFromCollection<T>( IServiceCollection services )
        {
            return (T)services
                .FirstOrDefault( d => d.ServiceType == typeof( T ) )
                ?.ImplementationInstance;
        }
        
        #endregion
    }
}
