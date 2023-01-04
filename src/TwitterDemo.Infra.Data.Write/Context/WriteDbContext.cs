using Microsoft.EntityFrameworkCore;
using TwitterDemo.Domain.Models;
using TwitterDemo.Infra.Data.Write.EntityConfig;

namespace TwitterDemo.Infra.Data.Write.Context
{
    public class WriteDbContext : DbContext
    {
        public DbSet<PostEntity> Posts { get; set; } = null!; // Posts
        public DbSet<PostTypeEntity> PostTypes { get; set; } = null!; // PostTypes
        public DbSet<UserAccountEntity> Users { get; set; } = null!; // Users        
        public DbSet<UserFollowingEntity> UserFollowing { get; set; } = null!; // UserFollowing

        public WriteDbContext(DbContextOptions<WriteDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new PostTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserAccountConfiguration());
            modelBuilder.ApplyConfiguration(new UserFollowingConfiguration());
            modelBuilder.ApplyConfiguration(new UserSummaryConfiguration());
        }
    }
}
