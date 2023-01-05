using BlogApp.Entity;

namespace BlogApp.Web.Models
{
    public class PostModel
    {
        public Post Post { get; set; }
        public List<Category> Categories { get; set; }
    }
}
