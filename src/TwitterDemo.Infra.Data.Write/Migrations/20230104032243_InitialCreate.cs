using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TwitterDemo.Infra.Data.Write.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "post_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    typedescription = table.Column<string>(name: "type_description", type: "varchar(6)", unicode: false, maxLength: 6, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_post_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_account",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false),
                    joinedat = table.Column<DateTime>(name: "joined_at", type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_following",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<long>(name: "user_id", type: "bigint", nullable: false),
                    targetuserid = table.Column<long>(name: "target_user_id", type: "bigint", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    removedat = table.Column<DateTime>(name: "removed_at", type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_following", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "posts",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    text = table.Column<string>(type: "varchar(777)", maxLength: 777, nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp", nullable: false),
                    userid = table.Column<long>(name: "user_id", type: "bigint", nullable: false),
                    parentid = table.Column<long>(name: "parent_id", type: "bigint", nullable: true),
                    typeid = table.Column<int>(name: "type_id", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_posts", x => x.id);
                    table.ForeignKey(
                        name: "fk_posts_post_parent",
                        column: x => x.parentid,
                        principalTable: "posts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_posts_post_type",
                        column: x => x.typeid,
                        principalTable: "post_type",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_posts_user",
                        column: x => x.userid,
                        principalTable: "user_account",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "user_summary",
                columns: table => new
                {
                    userid = table.Column<long>(name: "user_id", type: "bigint", nullable: false),
                    followerscount = table.Column<int>(name: "followers_count", type: "integer", nullable: false),
                    followingcount = table.Column<int>(name: "following_count", type: "integer", nullable: false),
                    postscount = table.Column<int>(name: "posts_count", type: "integer", nullable: false),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_summary", x => x.userid);
                    table.ForeignKey(
                        name: "fk_user_summary_user",
                        column: x => x.userid,
                        principalTable: "user_account",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "post_type",
                columns: new[] { "id", "type_description" },
                values: new object[,]
                {
                    { 1, "Post" },
                    { 2, "Repost" },
                    { 3, "Quote" }
                });

            migrationBuilder.InsertData(
                table: "user_account",
                columns: new[] { "id", "joined_at", "username" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 1, 4, 0, 22, 43, 401, DateTimeKind.Local).AddTicks(8613), "cleiton.gangi" },
                    { 2L, new DateTime(2023, 1, 4, 0, 22, 43, 401, DateTimeKind.Local).AddTicks(8620), "user2" },
                    { 3L, new DateTime(2023, 1, 4, 0, 22, 43, 401, DateTimeKind.Local).AddTicks(8621), "user3" }
                });

            migrationBuilder.InsertData(
                table: "user_summary",
                columns: new[] { "user_id", "followers_count", "following_count", "posts_count", "updated_at" },
                values: new object[,]
                {
                    { 1L, 0, 0, 0, new DateTime(2023, 1, 4, 0, 22, 43, 402, DateTimeKind.Local).AddTicks(2445) },
                    { 2L, 0, 0, 0, new DateTime(2023, 1, 4, 0, 22, 43, 402, DateTimeKind.Local).AddTicks(2448) },
                    { 3L, 0, 0, 0, new DateTime(2023, 1, 4, 0, 22, 43, 402, DateTimeKind.Local).AddTicks(2449) }
                });

            migrationBuilder.CreateIndex(
                name: "ix_posts_parent_id",
                table: "posts",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "ix_posts_type_id",
                table: "posts",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "ix_posts_user_id",
                table: "posts",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "posts");

            migrationBuilder.DropTable(
                name: "user_following");

            migrationBuilder.DropTable(
                name: "user_summary");

            migrationBuilder.DropTable(
                name: "post_type");

            migrationBuilder.DropTable(
                name: "user_account");
        }
    }
}
