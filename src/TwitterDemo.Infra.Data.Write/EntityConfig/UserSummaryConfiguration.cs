using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TwitterDemo.Domain.Models;

namespace TwitterDemo.Infra.Data.Write.EntityConfig
{
    public class UserSummaryConfiguration : IEntityTypeConfiguration<UserSummaryEntity>
    {
        public void Configure(EntityTypeBuilder<UserSummaryEntity> builder)
        {
            builder.ToTable("user_summary");
            builder.HasKey(x => x.UserId).HasName("pk_user_summary");

            builder.Property(x => x.UserId).HasColumnType("bigint").IsRequired().ValueGeneratedNever(); ;
            builder.Property(x => x.FollowersCount).HasColumnType("integer").IsRequired();
            builder.Property(x => x.FollowingCount).HasColumnType("integer").IsRequired();
            builder.Property(x => x.PostsCount).HasColumnType("integer").IsRequired();
            builder.Property(x => x.UpdatedAt).HasColumnType("timestamp").IsRequired();

            builder.HasOne(a => a.User)
                .WithOne(b => b.UserSummary)
                .HasForeignKey<UserSummaryEntity>(c => c.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_summary_user");

            builder.HasData(
                new UserSummaryEntity()
                {
                    UserId = 1,
                    FollowersCount = 0,
                    FollowingCount = 0,
                    PostsCount = 0,
                    UpdatedAt = DateTime.Now,
                },
                new UserSummaryEntity()
                {
                    UserId = 2,
                    FollowersCount = 0,
                    FollowingCount = 0,
                    PostsCount = 0,
                    UpdatedAt = DateTime.Now,
                },
                new UserSummaryEntity()
                {
                    UserId = 3,
                    FollowersCount = 0,
                    FollowingCount = 0,
                    PostsCount = 0,
                    UpdatedAt = DateTime.Now,
                });
        }
    }
}
