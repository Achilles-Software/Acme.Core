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

using Achilles.Acme.Composition.Modules;
using Achilles.Acme.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#endregion

namespace Achilles.Acme.Configuration
{
    public class AcmeOptions
    {
        public string ConnectionString { get; set; } = "DefaultConnection";
    }
}
