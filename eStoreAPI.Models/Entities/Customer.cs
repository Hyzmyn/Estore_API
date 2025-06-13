using System.ComponentModel.DataAnnotations;

namespace eStoreAPI.Models.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(100)]
        public string CustomerName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [StringLength(20)]
        public string? Phone { get; set; }

        [StringLength(200)]
        public string? Address { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}