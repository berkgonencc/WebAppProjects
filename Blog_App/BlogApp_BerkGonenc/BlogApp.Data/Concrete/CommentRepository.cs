using BlogApp.Data.Abstract;
using BlogApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data.Concrete
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(MyAppContext _dbContext) : base(_dbContext)
        {

        }
        private MyAppContext context { get { return _dbContext as MyAppContext; } }
    }
}
