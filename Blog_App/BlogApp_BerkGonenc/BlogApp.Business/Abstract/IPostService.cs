using BlogApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Abstract
{
    public interface IPostService
    {
        Task<Post> GetById(int id);
        Task<List<Post>> GetAll();
        void Delete(Post entity);
        Task UpdateAsync(Post entity);
        Task CreateAsync(Post entity);
        Task<List<Post>> GetTrendingPostsAsync();

    }
}
