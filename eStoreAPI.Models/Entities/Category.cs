using System.ComponentModel.DataAnnotations;

namespace eStoreAPI.Models.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; } = string.Empty;

        [StringLength(200)]
        public string? Description { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}