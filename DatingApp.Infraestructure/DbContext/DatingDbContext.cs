namespace DatingApp.Infrastructure.DbContext
{
    using Microsoft.EntityFrameworkCore;
    using Models.Entities;

    /// <summary>
    /// 
    /// </summary>
    public class DatingDbContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public DatingDbContext(DbContextOptions<DatingDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<AppUser> Users { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AppUser>().ToTable("AppUsers", "Dating.Authentication");
        }
    }
}