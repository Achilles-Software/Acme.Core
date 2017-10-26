#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using Achilles.Acme.Composition.Modules;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

using System;

#endregion

namespace Achilles.Acme.Plugins
{
    public abstract class PluginBase : IPlugin, IModule
    {
        #region Constructor

        public PluginBase()
        {
        }

        #endregion

        #region Public Properties

        public bool Enabled { get; set; }

        #endregion

        #region IModule Methods

        public virtual void Initialize( IServiceCollection serviceCollection )
        {
            // Call plugin abstract methods
            RegisterSettings( serviceCollection );
            RegisterServices( serviceCollection );
            RegisterViews( serviceCollection );
        }

        #endregion

        #region IPlugin Members

        public abstract Guid Id
        {
            get;
        }

        public abstract string Description
        {
            get;
        }

        public abstract string Name
        {
            get;
        }

        public abstract int Type
        {
            get;
        }

        public abstract String Version
        {
            get;
        }

        #endregion

        #region Abstract Methods

        protected abstract void RegisterSettings( IServiceCollection serviceCollection );

        protected abstract void RegisterServices( IServiceCollection serviceCollection );

        protected abstract void RegisterViews( IServiceCollection serviceCollection );

        protected abstract void RegisterRoutes( RouteCollection routes );

        #endregion
    }
}
