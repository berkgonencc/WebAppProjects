using BlogApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data.Abstract
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<List<Post>> GetTrendingPostsAsync();
        Task<List<Post>> GetRecentPostsAsync();
        Task<Post> GetFullPostAsync(string slug);
        Task<List<Post>> GetHomePagePostsAsync(string category);
        Task CreateAsync(Post post, int[] categoryIds);
        Task<Post> GetPostWithCategoriesAsync(int id);
        Task UpdateAsync(Post post, int[] categoryIds);
        Task UpdateIsPublishedAsync(Post post);

    }
}
