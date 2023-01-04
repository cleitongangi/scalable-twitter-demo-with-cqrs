using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TwitterDemo.Domain.Models;

namespace TwitterDemo.Infra.Data.Write.EntityConfig
{
    public class UserFollowingConfiguration : IEntityTypeConfiguration<UserFollowingEntity>
    {
        public void Configure(EntityTypeBuilder<UserFollowingEntity> builder)
        {
            builder.ToTable("user_following");
            builder.HasKey(x => x.Id).HasName("pk_user_following");

            builder.Property(x => x.Id).HasColumnType("bigint").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.UserId).HasColumnType("bigint").IsRequired();
            builder.Property(x => x.TargetUserId).HasColumnType("bigint").IsRequired();
            builder.Property(x => x.CreatedAt).HasColumnType("timestamp").IsRequired();
            builder.Property(x => x.Active).HasColumnType("boolean").IsRequired();
            builder.Property(x => x.RemovedAt).HasColumnType("timestamp").IsRequired(false);
        }
    }
}
