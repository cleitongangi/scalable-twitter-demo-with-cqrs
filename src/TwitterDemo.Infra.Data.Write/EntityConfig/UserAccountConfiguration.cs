using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TwitterDemo.Domain.Models;

namespace TwitterDemo.Infra.Data.Write.EntityConfig
{
    public class UserAccountConfiguration : IEntityTypeConfiguration<UserAccountEntity>
    {
        public void Configure(EntityTypeBuilder<UserAccountEntity> builder)
        {
            builder.ToTable("user_account");
            builder.HasKey(x => x.Id).HasName("pk_user");

            builder.Property(x => x.Id).HasColumnType("bigint").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Username).HasColumnType("varchar(14)").IsRequired().HasMaxLength(14);
            builder.Property(x => x.JoinedAt).HasColumnType("timestamp").IsRequired();

            // Only for test because don't exist Users CRUD
            builder.HasData(
                    new UserAccountEntity
                    {
                        Id = 1,
                        Username = "cleiton.gangi",
                        JoinedAt = DateTime.Now,
                    },
                    new UserAccountEntity
                    {
                        Id = 2,
                        Username = "user2",
                        JoinedAt = DateTime.Now,
                    },
                    new UserAccountEntity
                    {
                        Id = 3,
                        Username = "user3",
                        JoinedAt = DateTime.Now,
                    }
                );
        }
    }
}
