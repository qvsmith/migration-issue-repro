using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Reflection;

namespace DataAccess.DbFactories
{
    public class TmpCustomIdentityDbContextFactory : IDbContextFactory<CustomIdentityDbContext>
    {
        public CustomIdentityDbContext Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<CustomIdentityDbContext>();

            builder.UseNpgsql(Configuration.ConnectionString, optionsBuilder => optionsBuilder
            .MigrationsAssembly(typeof(CustomIdentityDbContext).GetTypeInfo().Assembly.GetName().Name));

            return new CustomIdentityDbContext(builder.Options);
        }
    }
}
