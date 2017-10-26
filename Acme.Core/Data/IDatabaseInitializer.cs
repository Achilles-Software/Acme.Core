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
using System.Threading.Tasks;

#endregion

namespace Achilles.Acme.Data
{
    /// <summary>
    /// DbContext database initializer interface.
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public interface IDatabaseInitializer<TContext> where TContext : DbContext
    {
        /// <summary>
        /// This method is called after migrating to the latest version.
        /// </summary>
        /// <param name="context">The DbContext</param>
        /// <param name="serviceProvider">Scoped service provider</param>
        /// <param name="newlyAppliedMigrations"></param>
        /// <returns></returns>
        Task SeedAsync( TContext context, IServiceProvider serviceProvider, IEnumerable<String> newlyAppliedMigrations );
    }
}
