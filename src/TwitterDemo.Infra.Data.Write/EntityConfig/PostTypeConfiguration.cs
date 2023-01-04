using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TwitterDemo.Domain.Models;

namespace TwitterDemo.Infra.Data.Write.EntityConfig
{
    public class PostTypeConfiguration : IEntityTypeConfiguration<PostTypeEntity>
    {
        public void Configure(EntityTypeBuilder<PostTypeEntity> builder)
        {
            builder.ToTable("post_type");
            builder.HasKey(x => x.Id).HasName("pk_post_type");

            builder.Property(x => x.Id).HasColumnType("integer").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.TypeDescription).HasColumnType("varchar(6)").IsRequired(false).IsUnicode(false).HasMaxLength(6);

            builder.HasData(
                    new PostTypeEntity
                    {
                        Id = 1,
                        TypeDescription = "Post"
                    },
                    new PostTypeEntity
                    {
                        Id = 2,
                        TypeDescription = "Repost"
                    },
                    new PostTypeEntity
                    {
                        Id = 3,
                        TypeDescription = "Quote"
                    }
                );
        }
    }
}
