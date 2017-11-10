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
using System.Text;

#endregion

namespace Achilles.Acme.Plugins
{
    public enum PluginType : int
    {
        System    = 0x01,
        Component = 0x02,
        Service   = 0x04,
        Content   = 0x08
    }

    /// <summary>
    /// The ACME plugin types. 
    /// </summary>
    public class PluginTypes
    {
        public static readonly IDictionary<PluginType, string> Names = new Dictionary<PluginType, string>
        {
            { PluginType.System,    "System" },
            { PluginType.Component, "Component" },
            { PluginType.Service,   "Service" },
            { PluginType.Content,   "Content" },
        };
    }
}
