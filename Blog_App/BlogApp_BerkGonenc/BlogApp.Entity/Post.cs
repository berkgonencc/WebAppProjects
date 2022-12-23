using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Entity
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string PostContent { get; set; }
        public string Slug { get; set; }
        public string ImageUrl { get; set; }
        public int LikeNumber { get; set; }



        public List<Comment> Comments { get; set; }
        public List<PostCategory> PostCategories { get; set; }

    }
}
