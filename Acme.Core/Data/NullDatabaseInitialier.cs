#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace Achilles.Acme.Data
{
    public class NullDatabaseInitialier: IDatabaseInitializer<DbContext>
    {
        public Task SeedAsync( DbContext context, IServiceProvider serviceProvider, IEnumerable<String> newAppliedMigrations )
        {
            // Does nothing
            return Task.CompletedTask;
        }
    }
}
