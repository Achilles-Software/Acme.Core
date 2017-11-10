#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using Achilles.Acme.Data.Models;
using System;

#endregion

namespace Achilles.Acme.Plugins
{
    public interface IPlugin : IEntity
    {
        Guid UId { get; }

        string Name { get; }

        string Description { get; }

        string Version { get; }

        int Type { get; }
    }
}
