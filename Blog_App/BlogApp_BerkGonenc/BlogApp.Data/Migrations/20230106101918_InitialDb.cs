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
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1.png", false, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "If you’re looking to get into the crypto game How do you get free crypto? There are a variety of ways to earn free cryptocurrency in 2022, but every one of them is worth the effort. I’ve made the top methods to begin making money with cryptocurrency that is free. If it’s via airdrops or mining, there’s a method that works for everyone.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "7-ways-to-earn-free-crypto", "If you’re looking to get into the crypto game How do you get free crypto? There are a variety of ways to earn free cryptocurrency in 2022..", "7 Ways to Earn Free Crypto" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CreatedOn", "ImageUrl", "IsDeleted", "IsPublished", "LastModifiedOn", "LikeNumber", "PostContent", "PublishedOn", "Slug", "Summary", "Title" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2.png", false, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "December was a crucial month for Vela as we made significant progress in several areas of the platform. News about Vela beta incentives including a beta participation airdrop was shared, several AMAs with partners including Crypto Kingdoms, Astrabit, and The Gem Hunters were held, and product teasers were leaked by our team.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "vela-exchange-monthly-update", "December was a crucial month for Vela as we made significant progress in several areas of the platform.", "Vela Exchange Monthly Update" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CreatedOn", "ImageUrl", "IsDeleted", "IsPublished", "LastModifiedOn", "LikeNumber", "PostContent", "PublishedOn", "Slug", "Summary", "Title" },
                values: new object[] { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3.png", false, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, "It is great to see so many of you here today. We are here to tell you about the fantastic work the Ishi Inu community has been doing together with the $ISHU team.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "the-beginning-of-a-new-era", "It is great to see so many of you here today. We are here to tell you about the fantastic work the Ishi Inu community", "The beginning of a new era" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CreatedOn", "ImageUrl", "IsDeleted", "IsPublished", "LastModifiedOn", "LikeNumber", "PostContent", "PublishedOn", "Slug", "Summary", "Title" },
                values: new object[] { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "4.png", false, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, "Lorem ipsum dolor sit amet, consectetaur adipisicing elit.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "roadmap", "Last quarter of the roadmap is already done. The first quarter for 2022 will be starting soon.", "Roadmap" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CreatedOn", "ImageUrl", "IsDeleted", "IsPublished", "LastModifiedOn", "LikeNumber", "PostContent", "PublishedOn", "Slug", "Summary", "Title" },
                values: new object[] { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "5.png", false, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, "This is the definitive guide for anyone wanting to choose the right programming language career path in 2018. And let me be clear about something:\r\n\r\nThis is not a “top hottest languages” post throwing around a bunch of names and buzzwords.\r\n\r\nThis is an objective and practical review of the current state, tendencies, and safe near-future predictions of the IT industry at the start of 2018.\r\n\r\nIt’s based on statistical data from various trusted sources and is the result of a two-week period of in-depth research.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "here-are-the-best-programming-languages-to-learn-in-2018", "This is the definitive guide for anyone wanting to choose the right programming language career path in 2018.", "Here are the best programming languages to learn in 2018" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CreatedOn", "ImageUrl", "IsDeleted", "IsPublished", "LastModifiedOn", "LikeNumber", "PostContent", "PublishedOn", "Slug", "Summary", "Title" },
                values: new object[] { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "6.png", false, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, "After you get used to the language’s syntax it’s time to solve some problems. Start with simple ones that require implementation skills. In this stage, your goal is to define your coding style. Maybe you like to write with lots of spaces, maybe not. Maybe you put the braces on the same line with the ‘if’ statement, maybe not.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "how-to-prepare-for-competitive-programming", "This is how I won 3 out of 4 Gold medals in the Computing Olympiad.", "How to prepare for competitive programming ?" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CreatedOn", "ImageUrl", "IsDeleted", "IsPublished", "LastModifiedOn", "LikeNumber", "PostContent", "PublishedOn", "Slug", "Summary", "Title" },
                values: new object[] { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "7.png", false, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, "was over four years ago that I coined the term “Web 3.0.” Back then, it was clear to me: Ethereum — the platform I cofounded — would allow people to interact in mutually beneficial ways without anyone needing to trust each other. With technologies for message passing and data publication, we hoped to construct a peer-to-peer web that lets you do everything you can now, except there would no servers and no authorities to manage the flow of information.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "why-we-need-web-3", "Ethereum co-founder Gavin Wood on why today’s internet is broken — and how we can do better next time around — It was over four years ago that I coined the term “Web 3.0.” Back then, it was clear to me:", "Why We Need Web 3.0" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CreatedOn", "ImageUrl", "IsDeleted", "IsPublished", "LastModifiedOn", "LikeNumber", "PostContent", "PublishedOn", "Slug", "Summary", "Title" },
                values: new object[] { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "8.png", false, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, "I didn’t anticipate how much I’d appreciate a @Jack of fewer trades. Key to progress is class traitors: Generals warning of a military-industrial complex, product managers who narc on mendacious management, and tech leaders who violate the Silicon Valley code of the white guy — never criticize each other or your noble missions to save the world. Jack Dorsey has drawn his sword and taken aim at colleagues attempting to centralize control and gain from the promise of decentralization. Specifically, web3.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "the-false-promise-of-web3", "The advertised decentralization of power out of the hands of a few has, in fact, been a re-centralization of power into the hands of fewer — I didn’t anticipate how much I’d appreciate a @Jack of fewer trades.", "The False Promise of Web3" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CreatedOn", "ImageUrl", "IsDeleted", "IsPublished", "LastModifiedOn", "LikeNumber", "PostContent", "PublishedOn", "Slug", "Summary", "Title" },
                values: new object[] { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9.png", false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, "What triggered this thought was a visit to an industrial factory last week. We all know that something is happening. And everyone seems to agree that our future will be automated. But, we tend to believe that it will only — or mainly — affect repetitive “manual labor”.\r\n\r\nAutomation of “knowledge work” is not on many people’s agenda.But, is this correct? Or, is it a naïve view that will be detrimental to business and society? The factory visit made me think about these issues and what “knowledge workers” — executives, managers, advertisers, lawyers, accountants, etc. — need to do to remain relevant in the coming new world.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "hello-new-world-of-artificial-intelligence", "Why Everyone Must Prepare for the “Automation Revolution” — We need to get smarter about emerging technologies, such as artificial intelligence, robotics and blockchain.", "Hello New World of Artificial Intelligence" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CreatedOn", "ImageUrl", "IsDeleted", "IsPublished", "LastModifiedOn", "LikeNumber", "PostContent", "PublishedOn", "Slug", "Summary", "Title" },
                values: new object[] { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "10.png", false, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 31, "Last March, I was in Costa Rica with my girlfriend, spending our days between beautiful beaches and jungles full of exotic animals. There was barely any connectivity and we were immersed in nature in a way that we could never be in a big city. It felt great.\r\n\r\nBut in the evening, when we got back to the hotel and connected to the WiFi, our phones would immediately start pushing an entire day’s worth of notifications, constantly interrupting our special time together. It interrupted us while watching the sunset, while sipping a cocktail, while having dinner, while having an intimate moment. It took emotional time away from us.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "how-artificial-intelligence-will-make-technology-disappear", "This is a redacted transcript of a TEDx talk I gave last April at Ecole Polytechnique in France. The video can be seen on Youtube here.", "How Artificial Intelligence Will Make Technology Disappear" });

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
