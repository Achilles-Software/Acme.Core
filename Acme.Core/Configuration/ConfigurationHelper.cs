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
    // TJT: Get rid of this

    public class ConfigurationHelper
    {
        private static IConfiguration _configuration;

        public static IConfiguration GetConfiguration( IServiceCollection services )
        {
            if ( _configuration == null )
            {
                _configuration = GetServiceFromCollection<IConfiguration>( services );

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
            // REVIEW: 
            return (T)services
                .FirstOrDefault( d => d.ServiceType == typeof( T ) )
                ?.ImplementationInstance;
        }

        #endregion
    }
}
