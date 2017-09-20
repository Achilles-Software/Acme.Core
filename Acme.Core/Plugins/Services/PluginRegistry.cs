#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace Achilles.Acme.Plugins.Services
{
    public class PluginRegistry : IPluginRegistry
    {
        private List<IPlugin> plugins;

        #region Constructor(s)

        public PluginRegistry()
        {
            this.plugins = new List<IPlugin>( 10 );
        }

        #endregion

        #region Add/Remove Methods

        public void Add( IPlugin plugin )
        {
            plugins.Add( plugin );
        }

        public void Clear()
        {
            plugins.Clear();
        }

        #endregion

        #region Query Methods

        public IPlugin Get( Guid id )
        {
            return GetAll().FirstOrDefault<IPlugin>( p => p.Id == id );
        }

        public IEnumerable<IPlugin> GetAll()
        {
            return plugins;//..Select<IPlugin>( p => p );
        }

        public IEnumerable<IPlugin> GetByType( int pluginType )
        {
            return GetAll().Where( p => p.Type == pluginType );
        }

        #endregion
    }
}
