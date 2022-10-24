using MiniShop.Entity;
using System.ComponentModel.DataAnnotations;

namespace MiniShop.Web.Models
{
    public class ProductWithCategoriesModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required!")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Name must be between 5 and 100 characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Price is required!")]
        [Range(1, 100000, ErrorMessage = "Price must be between 1$ and 100.000$")]
        public decimal? Price { get; set; }
        [Required(ErrorMessage = "Properties are required!")]
        [StringLength(300, MinimumLength = 10, ErrorMessage = "Properties must be between 10 and 300 characters.")]
        public string Properties { get; set; }
        public string ImageUrl { get; set; }
        public bool IsHome { get; set; }
        public bool IsApproved { get; set; }
        public List<Category> SelectedCategories { get; set; }
    }
}
