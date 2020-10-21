namespace DatingApp.Infrastructure.DbContext
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    public class DesignTimeDatingDbContextFactory : IDesignTimeDbContextFactory<DatingDbContext>
    {
        public DatingDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DatingDbContext>();
            var currentAssembly = this.GetType().Assembly;
            var connectionString = "Data Source=(local);database=DatingDb;trusted_connection=yes;";
            builder.UseSqlServer(
                connectionString,
                optionsBuilder => { optionsBuilder.MigrationsAssembly(currentAssembly.FullName); });
            return new DatingDbContext(builder.Options);
        }
    }
}