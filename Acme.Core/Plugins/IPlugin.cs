#region Copyright Notice

// Copyright (c) 2015 by Achilles Software, http://achilles-software.com
//
// The source code contained in this file may not be copied, modified, distributed or
// published by any means without the express written agreement by Achilles Software.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com
//
// All rights reserved.

#endregion

#region Namespaces

using Microsoft.Extensions.Options;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

#endregion

namespace Achilles.Acme.Plugins
{
    public interface IPlugin
    {
        Guid Id { get; }
        string Name { get; }
        string Description { get; }
        string Version { get; }
        bool Enabled { get; set; }
        int Type { get; }
    }
}
