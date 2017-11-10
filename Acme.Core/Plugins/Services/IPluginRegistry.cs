#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using Achilles.Acme.Data.Services;
using System;
using System.Collections.Generic;

#endregion

namespace Achilles.Acme.Plugins.Services
{
    public interface IPluginRegistry : IService<IPlugin>
    {
        #region Add

        void Add( IPlugin plugin );

        #endregion

        #region Query Methods

        IPlugin Get( Guid id );

        IEnumerable<IPlugin> GetByType( int pluginType );

        #endregion
    }
}
