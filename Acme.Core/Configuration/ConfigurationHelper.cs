#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

#endregion

namespace Achilles.Acme.Configuration
{
    public class ConfigurationHelper
    {
        private static IConfigurationRoot _configuration;

        public static IConfigurationRoot GetConfiguration( IServiceCollection services )
        {
            if ( _configuration == null )
            {
                var environment = GetServiceFromCollection<IHostingEnvironment>( services );

                var builder = new ConfigurationBuilder()
                    .SetBasePath( environment.ContentRootPath )
                    .AddJsonFile( "appsettings.json", optional: true, reloadOnChange: true )
                    .AddJsonFile( $"appsettings.{environment.EnvironmentName}.json", optional: true );

                _configuration = builder.Build();

                return _configuration;
            }
            else
            {
                return _configuration;
            }
        }

        #region Private Methods

        private static T GetServiceFromCollection<T>( IServiceCollection services )
        {
            return (T)services
                .FirstOrDefault( d => d.ServiceType == typeof( T ) )
                ?.ImplementationInstance;
        }

        #endregion
    }
}
