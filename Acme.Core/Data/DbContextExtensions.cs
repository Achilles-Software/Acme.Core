#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

#endregion

namespace Achilles.Acme.Data
{
    public static class DbContextExtensions
    {
        #region DbContext Data Initialization

        private static IDatabaseInitializer<DbContext> _initializer = new NullDatabaseInitialier();

        public static void SetInitializer( this DbContext dbContext, IDatabaseInitializer<DbContext> dbInitializer )
        {
            _initializer = dbInitializer;
        }

        public static async Task MigrateDatabaseToLatestVersionAsync( this DbContext dbContext, IServiceProvider serviceProvider )
        {
            await dbContext.MigrateDatabaseToLatestVersionAsync( _initializer, serviceProvider );
        }

        public static async Task MigrateDatabaseToLatestVersionAsync<TContext, TContextInitializer>( this TContext dbContext, TContextInitializer initializer, IServiceProvider serviceProvider )
            where TContext: DbContext
            where TContextInitializer : IDatabaseInitializer<TContext>
        {
            try
            {
                using ( var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope() )
                {
                    var pendingMigrations = dbContext.Database.GetPendingMigrations();

                    if ( pendingMigrations.Any() )
                    {
                        await dbContext.Database.MigrateAsync();

                        await initializer.SeedAsync( dbContext, serviceScope.ServiceProvider, pendingMigrations );
                    }
                }
            }
            catch ( Exception e )
            {
                var logger = serviceProvider.GetRequiredService<ILogger<TContext>>();
                logger.LogError( e, "An error occurred while migrating or seeding the DbContext." );
            }
        }

        #endregion
    }
}
