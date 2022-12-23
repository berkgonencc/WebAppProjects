using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApp.Data.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Slug = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsPublished = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PublishedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Summary = table.Column<string>(type: "TEXT", nullable: true),
                    PostContent = table.Column<string>(type: "TEXT", nullable: true),
                    Slug = table.Column<string>(type: "TEXT", nullable: true),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    LikeNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsPublished = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PublishedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CommentContent = table.Column<string>(type: "TEXT", nullable: true),
                    PostedBy = table.Column<string>(type: "TEXT", nullable: true),
                    ParentId = table.Column<int>(type: "INTEGER", nullable: true),
                    ParentPostId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsPublished = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PublishedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Comments_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Comments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Posts_ParentPostId",
                        column: x => x.ParentPostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostCategories",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCategories", x => new { x.PostId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_PostCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostCategories_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedOn", "Description", "IsDeleted", "IsPublished", "LastModifiedOn", "Name", "PublishedOn", "Slug" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Crypto Category", false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cryptocurrency", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cryptocurrency" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedOn", "Description", "IsDeleted", "IsPublished", "LastModifiedOn", "Name", "PublishedOn", "Slug" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Artificial Intelligence Category", false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Artificial Intelligence", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "artificial-intelligence" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedOn", "Description", "IsDeleted", "IsPublished", "LastModifiedOn", "Name", "PublishedOn", "Slug" },
                values: new object[] { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Web3 Category", false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Web3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "web3" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedOn", "Description", "IsDeleted", "IsPublished", "LastModifiedOn", "Name", "PublishedOn", "Slug" },
                values: new object[] { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Programming Category", false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Programming", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "programming" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CreatedOn", "ImageUrl", "IsDeleted", "IsPublished", "LastModifiedOn", "LikeNumber", "PostContent", "PublishedOn", "Slug", "Summary", "Title" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1.png", false, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Lorem ipsum dolor sit amet, consectetaur adipisicing elit.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "lorem-ipsum-dolor", "Lorem ipsum dolor sit amet.", "Lorem ipsum dolor." });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CreatedOn", "ImageUrl", "IsDeleted", "IsPublished", "LastModifiedOn", "LikeNumber", "PostContent", "PublishedOn", "Slug", "Summary", "Title" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2.png", false, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Lorem ipsum dolor sit amet, consectetaur adipisicing elit.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "lorem-ipsum-dolor", "Lorem ipsum dolor sit amet.", "Lorem ipsum dolor." });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CreatedOn", "ImageUrl", "IsDeleted", "IsPublished", "LastModifiedOn", "LikeNumber", "PostContent", "PublishedOn", "Slug", "Summary", "Title" },
                values: new object[] { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3.png", false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, "Lorem ipsum dolor sit amet, consectetaur adipisicing elit.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "lorem-ipsum-dolor", "Lorem ipsum dolor sit amet.", "Lorem ipsum dolor." });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CreatedOn", "ImageUrl", "IsDeleted", "IsPublished", "LastModifiedOn", "LikeNumber", "PostContent", "PublishedOn", "Slug", "Summary", "Title" },
                values: new object[] { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "4.png", false, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, "Lorem ipsum dolor sit amet, consectetaur adipisicing elit.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "lorem-ipsum-dolor", "Lorem ipsum dolor sit amet.", "Lorem ipsum dolor." });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CreatedOn", "ImageUrl", "IsDeleted", "IsPublished", "LastModifiedOn", "LikeNumber", "PostContent", "PublishedOn", "Slug", "Summary", "Title" },
                values: new object[] { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "5.png", false, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, "Lorem ipsum dolor sit amet, consectetaur adipisicing elit.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "lorem-ipsum-dolor", "Lorem ipsum dolor sit amet.", "Lorem ipsum dolor." });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CreatedOn", "ImageUrl", "IsDeleted", "IsPublished", "LastModifiedOn", "LikeNumber", "PostContent", "PublishedOn", "Slug", "Summary", "Title" },
                values: new object[] { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "6.png", false, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, "Lorem ipsum dolor sit amet, consectetaur adipisicing elit.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "lorem-ipsum-dolor", "Lorem ipsum dolor sit amet.", "Lorem ipsum dolor." });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CreatedOn", "ImageUrl", "IsDeleted", "IsPublished", "LastModifiedOn", "LikeNumber", "PostContent", "PublishedOn", "Slug", "Summary", "Title" },
                values: new object[] { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "7.png", false, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, "Lorem ipsum dolor sit amet, consectetaur adipisicing elit.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "lorem-ipsum-dolor", "Lorem ipsum dolor sit amet.", "Lorem ipsum dolor." });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CreatedOn", "ImageUrl", "IsDeleted", "IsPublished", "LastModifiedOn", "LikeNumber", "PostContent", "PublishedOn", "Slug", "Summary", "Title" },
                values: new object[] { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "8.png", false, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, "Lorem ipsum dolor sit amet, consectetaur adipisicing elit.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "lorem-ipsum-dolor", "Lorem ipsum dolor sit amet.", "Lorem ipsum dolor." });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CreatedOn", "ImageUrl", "IsDeleted", "IsPublished", "LastModifiedOn", "LikeNumber", "PostContent", "PublishedOn", "Slug", "Summary", "Title" },
                values: new object[] { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9.png", false, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, "Lorem ipsum dolor sit amet, consectetaur adipisicing elit.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "lorem-ipsum-dolor", "Lorem ipsum dolor sit amet.", "Lorem ipsum dolor." });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CreatedOn", "ImageUrl", "IsDeleted", "IsPublished", "LastModifiedOn", "LikeNumber", "PostContent", "PublishedOn", "Slug", "Summary", "Title" },
                values: new object[] { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "10.png", false, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 31, "Lorem ipsum dolor sit amet, consectetaur adipisicing elit.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "lorem-ipsum-dolor", "Lorem ipsum dolor sit amet.", "Lorem ipsum dolor." });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentContent", "CreatedOn", "IsDeleted", "IsPublished", "LastModifiedOn", "ParentId", "ParentPostId", "PostedBy", "PublishedOn" },
                values: new object[] { 1, "Lorem ipsum dolor", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentContent", "CreatedOn", "IsDeleted", "IsPublished", "LastModifiedOn", "ParentId", "ParentPostId", "PostedBy", "PublishedOn" },
                values: new object[] { 4, "Lorem ipsum dolor", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentContent", "CreatedOn", "IsDeleted", "IsPublished", "LastModifiedOn", "ParentId", "ParentPostId", "PostedBy", "PublishedOn" },
                values: new object[] { 5, "Lorem ipsum dolor", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "PostCategories",
                columns: new[] { "CategoryId", "PostId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "PostCategories",
                columns: new[] { "CategoryId", "PostId" },
                values: new object[] { 3, 1 });

            migrationBuilder.InsertData(
                table: "PostCategories",
                columns: new[] { "CategoryId", "PostId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "PostCategories",
                columns: new[] { "CategoryId", "PostId" },
                values: new object[] { 3, 2 });

            migrationBuilder.InsertData(
                table: "PostCategories",
                columns: new[] { "CategoryId", "PostId" },
                values: new object[] { 1, 3 });

            migrationBuilder.InsertData(
                table: "PostCategories",
                columns: new[] { "CategoryId", "PostId" },
                values: new object[] { 3, 3 });

            migrationBuilder.InsertData(
                table: "PostCategories",
                columns: new[] { "CategoryId", "PostId" },
                values: new object[] { 3, 4 });

            migrationBuilder.InsertData(
                table: "PostCategories",
                columns: new[] { "CategoryId", "PostId" },
                values: new object[] { 4, 5 });

            migrationBuilder.InsertData(
                table: "PostCategories",
                columns: new[] { "CategoryId", "PostId" },
                values: new object[] { 4, 6 });

            migrationBuilder.InsertData(
                table: "PostCategories",
                columns: new[] { "CategoryId", "PostId" },
                values: new object[] { 3, 7 });

            migrationBuilder.InsertData(
                table: "PostCategories",
                columns: new[] { "CategoryId", "PostId" },
                values: new object[] { 3, 8 });

            migrationBuilder.InsertData(
                table: "PostCategories",
                columns: new[] { "CategoryId", "PostId" },
                values: new object[] { 2, 9 });

            migrationBuilder.InsertData(
                table: "PostCategories",
                columns: new[] { "CategoryId", "PostId" },
                values: new object[] { 2, 10 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentContent", "CreatedOn", "IsDeleted", "IsPublished", "LastModifiedOn", "ParentId", "ParentPostId", "PostedBy", "PublishedOn" },
                values: new object[] { 2, "Lorem ipsum dolor", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentContent", "CreatedOn", "IsDeleted", "IsPublished", "LastModifiedOn", "ParentId", "ParentPostId", "PostedBy", "PublishedOn" },
                values: new object[] { 3, "Lorem ipsum dolor", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParentId",
                table: "Comments",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParentPostId",
                table: "Comments",
                column: "ParentPostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategories_CategoryId",
                table: "PostCategories",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "PostCategories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
