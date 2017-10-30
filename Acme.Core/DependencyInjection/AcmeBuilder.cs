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

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
            Services = services ?? throw new ArgumentNullException( nameof( services ) );

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

            var moduleParts = CompositionManager.GetModules();

            // Sort the moduleParts so that modules that provide dependent services are loaded first.
            moduleParts.Sort( ( moduleX, moduleY ) =>
            {
                if ( moduleX.Dependencies.Any( d => d.Name == moduleY.Name ) )
                {
                    return 1;
                }

                if ( moduleY.Dependencies.Any( d => d.Name == moduleX.Name ) )
                {
                    return -1;
                }

                return 0;
            } );

            foreach ( var modulePart in moduleParts )
            {
                foreach ( var moduleType in modulePart.Types )
                {
                    var module = CreateModule( modulePart.Assembly, moduleType );

                    module.Initialize( Services );

                    pluginRegistry.Add( module as IPlugin );
                }
            }
        }

        #endregion

        #region Private Methods

        
        private IModule CreateModule( Assembly moduleAssembly, Type moduleType )
        {
            if ( moduleType == null )
            {
                throw new Exception( string.Format( "Unable to retrieve the module type {0} from the loaded assemblies.", moduleType.Name ) );
            }

            var tryMe = Activator.CreateInstance( moduleType );

            return  moduleAssembly.CreateInstance( moduleType.FullName ) as IModule;
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
