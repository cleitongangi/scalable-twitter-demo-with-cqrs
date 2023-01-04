﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TwitterDemo.Infra.Data.Write.Context;

#nullable disable

namespace TwitterDemo.Infra.Data.Write.Migrations
{
    [DbContext(typeof(WriteDbContext))]
    partial class WriteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TwitterDemo.Domain.Models.PostEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp")
                        .HasColumnName("created_at");

                    b.Property<long?>("ParentId")
                        .HasColumnType("bigint")
                        .HasColumnName("parent_id");

                    b.Property<string>("Text")
                        .HasMaxLength(777)
                        .HasColumnType("varchar(777)")
                        .HasColumnName("text");

                    b.Property<int>("TypeId")
                        .HasColumnType("integer")
                        .HasColumnName("type_id");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_posts");

                    b.HasIndex("ParentId")
                        .HasDatabaseName("ix_posts_parent_id");

                    b.HasIndex("TypeId")
                        .HasDatabaseName("ix_posts_type_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_posts_user_id");

                    b.ToTable("posts", (string)null);
                });

            modelBuilder.Entity("TwitterDemo.Domain.Models.PostTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<string>("TypeDescription")
                        .HasMaxLength(6)
                        .IsUnicode(false)
                        .HasColumnType("varchar(6)")
                        .HasColumnName("type_description");

                    b.HasKey("Id")
                        .HasName("pk_post_type");

                    b.ToTable("post_type", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            TypeDescription = "Post"
                        },
                        new
                        {
                            Id = 2,
                            TypeDescription = "Repost"
                        },
                        new
                        {
                            Id = 3,
                            TypeDescription = "Quote"
                        });
                });

            modelBuilder.Entity("TwitterDemo.Domain.Models.UserAccountEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("JoinedAt")
                        .HasColumnType("timestamp")
                        .HasColumnName("joined_at");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)")
                        .HasColumnName("username");

                    b.HasKey("Id")
                        .HasName("pk_user");

                    b.ToTable("user_account", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            JoinedAt = new DateTime(2023, 1, 4, 0, 22, 43, 401, DateTimeKind.Local).AddTicks(8613),
                            Username = "cleiton.gangi"
                        },
                        new
                        {
                            Id = 2L,
                            JoinedAt = new DateTime(2023, 1, 4, 0, 22, 43, 401, DateTimeKind.Local).AddTicks(8620),
                            Username = "user2"
                        },
                        new
                        {
                            Id = 3L,
                            JoinedAt = new DateTime(2023, 1, 4, 0, 22, 43, 401, DateTimeKind.Local).AddTicks(8621),
                            Username = "user3"
                        });
                });

            modelBuilder.Entity("TwitterDemo.Domain.Models.UserFollowingEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean")
                        .HasColumnName("active");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("RemovedAt")
                        .HasColumnType("timestamp")
                        .HasColumnName("removed_at");

                    b.Property<long>("TargetUserId")
                        .HasColumnType("bigint")
                        .HasColumnName("target_user_id");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_user_following");

                    b.ToTable("user_following", (string)null);
                });

            modelBuilder.Entity("TwitterDemo.Domain.Models.UserSummaryEntity", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.Property<int>("FollowersCount")
                        .HasColumnType("integer")
                        .HasColumnName("followers_count");

                    b.Property<int>("FollowingCount")
                        .HasColumnType("integer")
                        .HasColumnName("following_count");

                    b.Property<int>("PostsCount")
                        .HasColumnType("integer")
                        .HasColumnName("posts_count");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp")
                        .HasColumnName("updated_at");

                    b.HasKey("UserId")
                        .HasName("pk_user_summary");

                    b.ToTable("user_summary", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = 1L,
                            FollowersCount = 0,
                            FollowingCount = 0,
                            PostsCount = 0,
                            UpdatedAt = new DateTime(2023, 1, 4, 0, 22, 43, 402, DateTimeKind.Local).AddTicks(2445)
                        },
                        new
                        {
                            UserId = 2L,
                            FollowersCount = 0,
                            FollowingCount = 0,
                            PostsCount = 0,
                            UpdatedAt = new DateTime(2023, 1, 4, 0, 22, 43, 402, DateTimeKind.Local).AddTicks(2448)
                        },
                        new
                        {
                            UserId = 3L,
                            FollowersCount = 0,
                            FollowingCount = 0,
                            PostsCount = 0,
                            UpdatedAt = new DateTime(2023, 1, 4, 0, 22, 43, 402, DateTimeKind.Local).AddTicks(2449)
                        });
                });

            modelBuilder.Entity("TwitterDemo.Domain.Models.PostEntity", b =>
                {
                    b.HasOne("TwitterDemo.Domain.Models.PostEntity", "Parent")
                        .WithMany("Posts")
                        .HasForeignKey("ParentId")
                        .HasConstraintName("fk_posts_post_parent");

                    b.HasOne("TwitterDemo.Domain.Models.PostTypeEntity", "PostType")
                        .WithMany("Posts")
                        .HasForeignKey("TypeId")
                        .IsRequired()
                        .HasConstraintName("fk_posts_post_type");

                    b.HasOne("TwitterDemo.Domain.Models.UserAccountEntity", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("fk_posts_user");

                    b.Navigation("Parent");

                    b.Navigation("PostType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TwitterDemo.Domain.Models.UserSummaryEntity", b =>
                {
                    b.HasOne("TwitterDemo.Domain.Models.UserAccountEntity", "User")
                        .WithOne("UserSummary")
                        .HasForeignKey("TwitterDemo.Domain.Models.UserSummaryEntity", "UserId")
                        .IsRequired()
                        .HasConstraintName("fk_user_summary_user");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TwitterDemo.Domain.Models.PostEntity", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("TwitterDemo.Domain.Models.PostTypeEntity", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("TwitterDemo.Domain.Models.UserAccountEntity", b =>
                {
                    b.Navigation("Posts");

                    b.Navigation("UserSummary")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
