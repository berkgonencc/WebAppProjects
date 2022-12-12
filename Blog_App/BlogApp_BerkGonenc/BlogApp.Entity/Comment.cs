using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Entity
{
    public class Comment : BaseEntity
    {
        public string CommentContent { get; set; }
        public string PostedBy { get; set; }
        public Comment Parent { get; set; }
        public Post ParentPost { get; set; }
    }
}
