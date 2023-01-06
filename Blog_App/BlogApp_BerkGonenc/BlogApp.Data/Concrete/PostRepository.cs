using BlogApp.Data.Abstract;
using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data.Concrete
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(MyAppContext _dbContext) : base(_dbContext)
        {

        }
        private MyAppContext context { get { return _dbContext as MyAppContext; } }

        public async Task<List<Post>> GetTrendingPostsAsync()
        {
            return await context.Posts.Where(p => p.IsPublished == true && p.IsDeleted == false && p.LikeNumber > 10).OrderBy(p => p.LikeNumber).Take(3).ToListAsync();
        }
        public async Task<List<Post>> GetRecentPostsAsync()
        {
            return await context.Posts.Where(p => p.IsPublished && p.IsDeleted == false).OrderBy(p => p.PublishedOn).ToListAsync();
        }

        public async Task<Post> GetFullPostAsync(string slug)
        {
            return await context.Posts
                .Where(p => p.Slug == slug)
                .Include(p => p.PostCategories)
                .ThenInclude(pc => pc.Category)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Post>> GetHomePagePostsAsync(string category)
        {
            var posts = context
                .Posts
                .Where(p => p.IsDeleted == false && p.IsPublished)
                .AsQueryable();
            if (!string.IsNullOrEmpty(category))
            {
                posts = posts.Include(p => p.PostCategories).ThenInclude(pc => pc.Category).Where(p => p.PostCategories.Any(pc => pc.Category.Slug == category));
            }
            return await posts.ToListAsync();
        }

        public async Task CreateAsync(Post post, int[] categoryIds)
        {
            await context.Posts.AddAsync(post);
            await context.SaveChangesAsync();
            post.PostCategories = categoryIds.Select(catId => new PostCategory
            {
                CategoryId = catId,
                PostId = post.Id
            }).ToList();
            await context.SaveChangesAsync();
        }
    }
}
