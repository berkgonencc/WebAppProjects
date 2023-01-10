using System.ComponentModel.DataAnnotations;

namespace BlogApp.Web.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(5)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(5)]
        public string Description { get; set; }
        public string Slug { get; set; }
    }
}
