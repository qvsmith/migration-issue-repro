using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using IdentityServer4.EntityFramework.Options;
using System.Reflection;

namespace DataAccess.DbFactories
{
    public class TmpConfigurationDbContextFactory : IDbContextFactory<ConfigurationDbContext>
    {
        public ConfigurationDbContext Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<ConfigurationDbContext>();

            builder.UseNpgsql(Configuration.ConnectionString, optionsBuilder => optionsBuilder
            .MigrationsAssembly(typeof(CustomIdentityDbContext).GetTypeInfo().Assembly.GetName().Name));

            return new ConfigurationDbContext(builder.Options, new ConfigurationStoreOptions());
        }
    }
}
