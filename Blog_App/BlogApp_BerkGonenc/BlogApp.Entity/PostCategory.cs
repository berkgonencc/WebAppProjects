using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Entity
{
    public class PostCategory
    {
        public Post Post { get; set; }
        public int PostId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
