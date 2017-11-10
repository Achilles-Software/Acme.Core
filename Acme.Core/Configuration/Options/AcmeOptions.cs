#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

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
