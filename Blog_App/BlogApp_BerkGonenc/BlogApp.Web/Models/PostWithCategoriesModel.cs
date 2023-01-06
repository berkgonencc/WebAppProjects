using BlogApp.Entity;
using System.ComponentModel.DataAnnotations;

namespace BlogApp.Web.Models
{
    public class PostWithCategoriesModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required(ErrorMessage ="The Story field is required.")]
        public string PostContent { get; set; }
        public string ImageUrl { get; set; }
        public bool IsPublished { get; set; }
        public List<Category> SelectedCategories { get; set; }
    }
}
