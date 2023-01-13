using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitterDemo.Domain.Models;

namespace TwitterDemo.Infra.Data.Write.EntityConfig
{
    public class PostConfiguration : IEntityTypeConfiguration<PostEntity>
    {
        public void Configure(EntityTypeBuilder<PostEntity> builder)
        {
            builder.ToTable("posts");
            builder.HasKey(x => x.Id).HasName("pk_posts");

            builder.Property(x => x.Id).HasColumnType("bigint").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Text).HasColumnType("varchar(2000)").IsRequired(false).HasMaxLength(2000);
            builder.Property(x => x.CreatedAt).HasColumnType("timestamp").IsRequired();
            builder.Property(x => x.UserId).HasColumnType("bigint").IsRequired();
            builder.Property(x => x.ParentId).HasColumnType("bigint").IsRequired(false);
            builder.Property(x => x.TypeId).HasColumnType("integer").IsRequired();

            // Foreign keys
            builder.HasOne(a => a.Parent).WithMany(b => b.Posts).HasForeignKey(c => c.ParentId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_posts_post_parent");
            builder.HasOne(a => a.PostType).WithMany(b => b.Posts).HasForeignKey(c => c.TypeId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_posts_post_type");
            builder.HasOne(a => a.User).WithMany(b => b.Posts).HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_posts_user");
        }
    }
}
