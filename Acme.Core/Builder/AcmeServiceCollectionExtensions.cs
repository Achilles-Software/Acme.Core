﻿#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using Achilles.Acme.Composition.Modules;
using Achilles.Acme.Configuration;
using Achilles.Acme.Http;
using Achilles.Acme.Plugins.Services;
using Achilles.Acme.Razor;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

using System;
using System.Linq;

#endregion

namespace Achilles.Acme.Builder
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
        /// <returns>An <see cref="IAcmeBuilder"/> that can be used to further configure Acme services.</returns>
        public static IAcmeBuilder AddAcme( this IServiceCollection services )
        {
            if ( services == null )
            {
                throw new ArgumentNullException( nameof( services ) );
            }

            // Configure MVC components
            var mvcBuilder = services.AddMvcCore();

            services.Configure<RazorViewEngineOptions>( options =>
            {
                options.ViewLocationExpanders.Add( new AreaViewComponentLocationExpander() );
            } );

            // Add Acme services
            services.TryAddSingleton<IPluginRegistry>( new PluginRegistry() );

            // Acme area viewcomponets depends on IHttpContextAccessor which Hosting doesn't add  by default
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Configure our HttpContext accessor helper
            HttpContextAccessorHelper.Configure( services.BuildServiceProvider().GetRequiredService<IHttpContextAccessor>() );

            // Add the Acme module feature provider
            var environment = GetServiceFromCollection<IHostingEnvironment>( services );
            mvcBuilder.ConfigureApplicationPartManager( manager =>
            {
                manager.FeatureProviders.Add( new CompositionFeatureProvider( environment.ApplicationName ) );
            } );

            var builder = new AcmeBuilder( services, mvcBuilder.PartManager );

            return builder;
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

            if ( setupAction == null )
            {
                throw new ArgumentNullException( nameof( setupAction ) );
            }

            var builder = services.AddAcme();

            services.Configure( setupAction );

            return builder;
        }

        #endregion

        #region Private Methods

        private static T GetServiceFromCollection<T>( IServiceCollection services )
        {
            return (T)services
                .LastOrDefault( d => d.ServiceType == typeof( T ) )
                ?.ImplementationInstance;
        }

        #endregion
    }
}