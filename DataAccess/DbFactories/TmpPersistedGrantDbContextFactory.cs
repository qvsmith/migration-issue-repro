using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Reflection;

namespace DataAccess.DbFactories
{
    public class TmpPersistedGrantDbContextFactory : IDbContextFactory<PersistedGrantDbContext>
    {
        public PersistedGrantDbContext Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<PersistedGrantDbContext>();

            builder.UseNpgsql(Configuration.ConnectionString, optionsBuilder => optionsBuilder
            .MigrationsAssembly(typeof(CustomIdentityDbContext).GetTypeInfo().Assembly.GetName().Name));

            return new PersistedGrantDbContext(builder.Options, new OperationalStoreOptions());
        }
    }
}
