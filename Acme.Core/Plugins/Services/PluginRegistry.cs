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
using System.Threading.Tasks;
using Achilles.Acme.Data.Services;

#endregion

namespace Achilles.Acme.Plugins.Services
{
    public class PluginRegistry : IPluginRegistry
    {
        private static int index = 1;
        private List<IPlugin> plugins = new List<IPlugin>();

        #region Constructor(s)

        public PluginRegistry()
        {
        }

        #endregion

        #region Add

        public void Add( IPlugin plugin )
        {
            plugin.Id = index++;

            plugins.Add( plugin );
        }

        #endregion

        #region CRUD Methods

        public Task<ServiceResult> CreateAsync( IPlugin plugin )
        {
            Add( plugin );

            return Task.FromResult( ServiceResult.Success );
        }

        public Task<ServiceResult> DeleteAsync( IPlugin item )
        {
            throw new NotSupportedException();
        }

        public Task<ServiceResult> EditAsync( IPlugin item )
        {
            throw new NotSupportedException();
        }

        #endregion

        #region Query Methods

        public IPlugin Get( Guid uid )
        {
            return plugins.FirstOrDefault( p => p.UId == uid );
        }

        public IQueryable<IPlugin> GetAll()
        {
            return plugins.AsQueryable();
        }

        public Task<IPlugin> GetAsync( int id )
        {
            return Task.FromResult( plugins.FirstOrDefault( p => p.Id == id ) );
        }

        public IEnumerable<IPlugin> GetByType( int pluginType )
        {
            return GetAll().Where( p => p.Type == pluginType );
        }

        #endregion
    }
}
