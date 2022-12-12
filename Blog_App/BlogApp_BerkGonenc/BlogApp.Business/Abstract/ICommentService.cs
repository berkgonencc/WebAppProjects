using BlogApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Abstract
{
    public interface ICommentService
    {
        Task<Comment> GetById(int id);
        Task<List<Comment>> GetAll();
        void Delete(Comment entity);
        Task UpdateAsync(Comment entity);
        Task CreateAsync(Comment entity);
    }
}
