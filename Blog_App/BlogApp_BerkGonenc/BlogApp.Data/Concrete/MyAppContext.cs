using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data.Concrete
{
    public class MyAppContext : DbContext
    {
        public MyAppContext(DbContextOptions<MyAppContext> options) : base(options)
        {

        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostCategory>().HasKey(pc => new
            {
                pc.PostId,
                pc.CategoryId
            });

            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "Cryptocurrency", Description = "Crypto Category", Slug = "cryptocurrency" },
                new Category() { Id = 2, Name = "Artificial Intelligence", Description = "Artificial Intelligence Category", Slug = "artificial-intelligence" },
                new Category() { Id = 3, Name = "Web3", Description = "Web3 Category", Slug = "web3" },
                new Category() { Id = 4, Name = "Programming", Description = "Programming Category", Slug = "programming" }
                );
            modelBuilder.Entity<Post>().HasData(
                new Post() { Id = 1, Title = "7 Ways to Earn Free Crypto", Summary = "If you’re looking to get into the crypto game How do you get free crypto? There are a variety of ways to earn free cryptocurrency in 2022..", PostContent = "If you’re looking to get into the crypto game How do you get free crypto? There are a variety of ways to earn free cryptocurrency in 2022, but every one of them is worth the effort. I’ve made the top methods to begin making money with cryptocurrency that is free. If it’s via airdrops or mining, there’s a method that works for everyone.", Slug = "7-ways-to-earn-free-crypto", IsPublished = true, ImageUrl = "1.png", LikeNumber = 1 },
                new Post() { Id = 2, Title = "Vela Exchange Monthly Update", Summary = "December was a crucial month for Vela as we made significant progress in several areas of the platform.", PostContent = "December was a crucial month for Vela as we made significant progress in several areas of the platform. News about Vela beta incentives including a beta participation airdrop was shared, several AMAs with partners including Crypto Kingdoms, Astrabit, and The Gem Hunters were held, and product teasers were leaked by our team.", Slug = "vela-exchange-monthly-update", IsPublished = true, ImageUrl = "2.png", LikeNumber = 5 },
                new Post() { Id = 3, Title = "The beginning of a new era", Summary = "It is great to see so many of you here today. We are here to tell you about the fantastic work the Ishi Inu community", PostContent = "It is great to see so many of you here today. We are here to tell you about the fantastic work the Ishi Inu community has been doing together with the $ISHU team.", Slug = "the-beginning-of-a-new-era", IsPublished = true, ImageUrl = "3.png", LikeNumber = 11 },
                new Post() { Id = 4, Title = "Roadmap", Summary = "Last quarter of the roadmap is already done. The first quarter for 2022 will be starting soon.", PostContent = "Lorem ipsum dolor sit amet, consectetaur adipisicing elit.", Slug = "roadmap", IsPublished = true, ImageUrl = "4.png", LikeNumber = 21 },
                new Post() { Id = 5, Title = "Here are the best programming languages to learn in 2018", Summary = "This is the definitive guide for anyone wanting to choose the right programming language career path in 2018.", PostContent = "This is the definitive guide for anyone wanting to choose the right programming language career path in 2018. And let me be clear about something:\r\n\r\nThis is not a “top hottest languages” post throwing around a bunch of names and buzzwords.\r\n\r\nThis is an objective and practical review of the current state, tendencies, and safe near-future predictions of the IT industry at the start of 2018.\r\n\r\nIt’s based on statistical data from various trusted sources and is the result of a two-week period of in-depth research.", Slug = "here-are-the-best-programming-languages-to-learn-in-2018", IsPublished = true, ImageUrl = "5.png", LikeNumber = 13 },
                new Post() { Id = 6, Title = "How to prepare for competitive programming ?", Summary = "This is how I won 3 out of 4 Gold medals in the Computing Olympiad.", PostContent = "After you get used to the language’s syntax it’s time to solve some problems. Start with simple ones that require implementation skills. In this stage, your goal is to define your coding style. Maybe you like to write with lots of spaces, maybe not. Maybe you put the braces on the same line with the ‘if’ statement, maybe not.", Slug = "how-to-prepare-for-competitive-programming", IsPublished = true, ImageUrl = "6.png", LikeNumber = 14 },
                new Post() { Id = 7, Title = "Why We Need Web 3.0", Summary = "Ethereum co-founder Gavin Wood on why today’s internet is broken — and how we can do better next time around — It was over four years ago that I coined the term “Web 3.0.” Back then, it was clear to me:", PostContent = "was over four years ago that I coined the term “Web 3.0.” Back then, it was clear to me: Ethereum — the platform I cofounded — would allow people to interact in mutually beneficial ways without anyone needing to trust each other. With technologies for message passing and data publication, we hoped to construct a peer-to-peer web that lets you do everything you can now, except there would no servers and no authorities to manage the flow of information.", Slug = "why-we-need-web-3", IsPublished = true, ImageUrl = "7.png", LikeNumber = 15 },
                new Post() { Id = 8, Title = "The False Promise of Web3", Summary = "The advertised decentralization of power out of the hands of a few has, in fact, been a re-centralization of power into the hands of fewer — I didn’t anticipate how much I’d appreciate a @Jack of fewer trades.", PostContent = "I didn’t anticipate how much I’d appreciate a @Jack of fewer trades. Key to progress is class traitors: Generals warning of a military-industrial complex, product managers who narc on mendacious management, and tech leaders who violate the Silicon Valley code of the white guy — never criticize each other or your noble missions to save the world. Jack Dorsey has drawn his sword and taken aim at colleagues attempting to centralize control and gain from the promise of decentralization. Specifically, web3.", Slug = "the-false-promise-of-web3", IsPublished = true, ImageUrl = "8.png", LikeNumber = 12 },
                new Post() { Id = 9, Title = "Hello New World of Artificial Intelligence", Summary = "Why Everyone Must Prepare for the “Automation Revolution” — We need to get smarter about emerging technologies, such as artificial intelligence, robotics and blockchain.", PostContent = "What triggered this thought was a visit to an industrial factory last week. We all know that something is happening. And everyone seems to agree that our future will be automated. But, we tend to believe that it will only — or mainly — affect repetitive “manual labor”.\r\n\r\nAutomation of “knowledge work” is not on many people’s agenda.But, is this correct? Or, is it a naïve view that will be detrimental to business and society? The factory visit made me think about these issues and what “knowledge workers” — executives, managers, advertisers, lawyers, accountants, etc. — need to do to remain relevant in the coming new world.", Slug = "hello-new-world-of-artificial-intelligence", IsPublished = false, ImageUrl = "9.png", LikeNumber = 50 },
                new Post() { Id = 10, Title = "How Artificial Intelligence Will Make Technology Disappear", Summary = "This is a redacted transcript of a TEDx talk I gave last April at Ecole Polytechnique in France. The video can be seen on Youtube here.", PostContent = "Last March, I was in Costa Rica with my girlfriend, spending our days between beautiful beaches and jungles full of exotic animals. There was barely any connectivity and we were immersed in nature in a way that we could never be in a big city. It felt great.\r\n\r\nBut in the evening, when we got back to the hotel and connected to the WiFi, our phones would immediately start pushing an entire day’s worth of notifications, constantly interrupting our special time together. It interrupted us while watching the sunset, while sipping a cocktail, while having dinner, while having an intimate moment. It took emotional time away from us.", Slug = "how-artificial-intelligence-will-make-technology-disappear", IsPublished = true, ImageUrl = "10.png", LikeNumber = 31 }
                );
            modelBuilder.Entity<PostCategory>().HasData(
                new PostCategory() { PostId = 1, CategoryId = 1 },
                new PostCategory() { PostId = 2, CategoryId = 1 },
                new PostCategory() { PostId = 3, CategoryId = 1 },
                new PostCategory() { PostId = 1, CategoryId = 3 },
                new PostCategory() { PostId = 2, CategoryId = 3 },
                new PostCategory() { PostId = 3, CategoryId = 3 },
                new PostCategory() { PostId = 4, CategoryId = 3 },
                new PostCategory() { PostId = 5, CategoryId = 4 },
                new PostCategory() { PostId = 6, CategoryId = 4 },
                new PostCategory() { PostId = 7, CategoryId = 3 },
                new PostCategory() { PostId = 8, CategoryId = 3 },
                new PostCategory() { PostId = 9, CategoryId = 2 },
                new PostCategory() { PostId = 10, CategoryId = 2 }
                );
            modelBuilder.Entity<Comment>().HasData(
                new Comment() { Id = 1, CommentContent = "Lorem ipsum dolor", ParentId = null, ParentPostId = 1, IsPublished=true },
                new Comment() { Id = 2, CommentContent = "Lorem ipsum dolor", ParentId = 1, ParentPostId = 1, IsPublished = true },
                new Comment() { Id = 3, CommentContent = "Lorem ipsum dolor", ParentId = 1, ParentPostId = 1, IsPublished = true },
                new Comment() { Id = 4, CommentContent = "Lorem ipsum dolor", ParentId = null, ParentPostId = 2, IsPublished = true },
                new Comment() { Id = 5, CommentContent = "Lorem ipsum dolor", ParentId = null, ParentPostId = 3, IsPublished = false }

                );

        }
    }
}
