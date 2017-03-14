#region Copyright Notice

// Copyright (c) 2009 by Achilles Software, http://achilles-software.com
//
// The source code contained in this file may not be copied, modified, distributed or
// published by any means without the express written agreement by Achilles Software.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com
//
// All rights reserved.

#endregion

#region Namespaces

using Achilles.Acme.Composition;
using Achilles.Acme.Composition.Modules;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace Achilles.Acme.Plugins
{
    public abstract class PluginBase : IPlugin, IModule
    {
        #region Fields

        // TODO: Review or remove
        //private static IConfigurationRoot _configuration = null;

        #endregion

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

            // TODO: How to configure routes for the module
            //RegisterRoutes( RouteTable.Routes );
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
