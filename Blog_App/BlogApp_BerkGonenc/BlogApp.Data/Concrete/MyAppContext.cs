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
        public MyAppContext(DbContextOptions options) : base(options)
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
                new Post() { Id = 1, Title = "Lorem ipsum dolor.", Summary = "Lorem ipsum dolor sit amet.", PostContent = "Lorem ipsum dolor sit amet, consectetaur adipisicing elit.", Slug = "lorem-ipsum-dolor", IsPublished = true, ImageUrl = "1.png" },
                new Post() { Id = 2, Title = "Lorem ipsum dolor.", Summary = "Lorem ipsum dolor sit amet.", PostContent = "Lorem ipsum dolor sit amet, consectetaur adipisicing elit.", Slug = "lorem-ipsum-dolor", IsPublished = true, ImageUrl = "2.png" },
                new Post() { Id = 3, Title = "Lorem ipsum dolor.", Summary = "Lorem ipsum dolor sit amet.", PostContent = "Lorem ipsum dolor sit amet, consectetaur adipisicing elit.", Slug = "lorem-ipsum-dolor", IsPublished = false, ImageUrl = "3.png" },
                new Post() { Id = 4, Title = "Lorem ipsum dolor.", Summary = "Lorem ipsum dolor sit amet.", PostContent = "Lorem ipsum dolor sit amet, consectetaur adipisicing elit.", Slug = "lorem-ipsum-dolor", IsPublished = true, ImageUrl = "4.png" },
                new Post() { Id = 5, Title = "Lorem ipsum dolor.", Summary = "Lorem ipsum dolor sit amet.", PostContent = "Lorem ipsum dolor sit amet, consectetaur adipisicing elit.", Slug = "lorem-ipsum-dolor", IsPublished = true, ImageUrl = "5.png" },
                new Post() { Id = 6, Title = "Lorem ipsum dolor.", Summary = "Lorem ipsum dolor sit amet.", PostContent = "Lorem ipsum dolor sit amet, consectetaur adipisicing elit.", Slug = "lorem-ipsum-dolor", IsPublished = true, ImageUrl = "6.png" },
                new Post() { Id = 7, Title = "Lorem ipsum dolor.", Summary = "Lorem ipsum dolor sit amet.", PostContent = "Lorem ipsum dolor sit amet, consectetaur adipisicing elit.", Slug = "lorem-ipsum-dolor", IsPublished = true, ImageUrl = "7.png" },
                new Post() { Id = 8, Title = "Lorem ipsum dolor.", Summary = "Lorem ipsum dolor sit amet.", PostContent = "Lorem ipsum dolor sit amet, consectetaur adipisicing elit.", Slug = "lorem-ipsum-dolor", IsPublished = true, ImageUrl = "8.png" },
                new Post() { Id = 9, Title = "Lorem ipsum dolor.", Summary = "Lorem ipsum dolor sit amet.", PostContent = "Lorem ipsum dolor sit amet, consectetaur adipisicing elit.", Slug = "lorem-ipsum-dolor", IsPublished = true, ImageUrl = "9.png" },
                new Post() { Id = 10, Title = "Lorem ipsum dolor.", Summary = "Lorem ipsum dolor sit amet.", PostContent = "Lorem ipsum dolor sit amet, consectetaur adipisicing elit.", Slug = "lorem-ipsum-dolor", IsPublished = true, ImageUrl = "10.png" }
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
                new Comment() { Id = 1, CommentContent = "Lorem ipsum dolor", ParentId = null, ParentPostId = 1 },
                new Comment() { Id = 2, CommentContent = "Lorem ipsum dolor", ParentId = 1, ParentPostId = 1 },
                new Comment() { Id = 3, CommentContent = "Lorem ipsum dolor", ParentId = 1, ParentPostId = 1 },
                new Comment() { Id = 4, CommentContent = "Lorem ipsum dolor", ParentId = null, ParentPostId = 2 },
                new Comment() { Id = 5, CommentContent = "Lorem ipsum dolor", ParentId = null, ParentPostId = 3 }

                );

        }
    }
}
