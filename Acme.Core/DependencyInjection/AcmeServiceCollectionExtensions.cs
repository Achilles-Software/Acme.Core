#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using Achilles.Acme.Configuration;
using Achilles.Acme.Filters;
using Achilles.Acme.Http;
using Achilles.Acme.Plugins.Services;
using Achilles.Acme.Razor;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;

using System;

#endregion

namespace Achilles.Acme.DependencyInjection
{
    /// <summary>
    /// Extension methods for adding Acme services to an <see cref="IServiceCollection" />.
    /// </summary>
    public static class AcmeServiceCollectionExtensions
    {
        #region Public Methods

        /// <summary>
        /// Adds Acme services to the specified <see cref="IServiceCollection" />.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
        /// <returns>An <see cref="IAcmeBuilder"/> that can be used to further configure the ACME services.</returns>
        public static IAcmeBuilder AddAcme( this IServiceCollection services )
        {
            if ( services == null )
            {
                throw new ArgumentNullException( nameof( services ) );
            }

            return AddAcme( services, setupAction: null );
        }

        /// <summary>
        /// Adds Acme services to the specified <see cref="IServiceCollection" />.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
        /// <param name="setupAction">An <see cref="Action{AcmeOptions}"/> to configure the provided <see cref="AcmeOptions"/>.</param>
        /// <returns>An <see cref="IAcmeBuilder"/> that can be used to further configure the ACME services.</returns>
        public static IAcmeBuilder AddAcme( this IServiceCollection services, Action<AcmeOptions> setupAction )
        {
            if ( services == null )
            {
                throw new ArgumentNullException( nameof( services ) );
            }

            var builder = new AcmeBuilder( services );

            if ( setupAction != null )
            {
                services.Configure( setupAction );
            }

            // TODO: Remove this need for asp.net core 2...

            // Acme depends on IHttpContextAccessor which Hosting doesn't add  by default
            // services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // The plugin registry service is part of the core
            var pluginRegistry = new PluginRegistry();
            services.AddSingleton<IPluginRegistry>( pluginRegistry );

            services.Configure<RazorViewEngineOptions>( options =>
            {
                options.ViewLocationExpanders.Add( new AreaViewComponentLocationExpander() );
            } );

            // Configure our HttpContext accessor helper
            HttpContextAccessorHelper.Configure( services.BuildServiceProvider().GetRequiredService<IHttpContextAccessor>() );

            // Add Modules and their services
            builder.AddModuleServices();

            return builder;
        }

        #endregion
    }
}
