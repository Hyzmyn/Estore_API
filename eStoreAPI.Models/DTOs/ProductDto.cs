namespace eStoreAPI.Models.DTOs
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
    }

    public class CreateProductDto
    {
        public string ProductName { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
    }

    public class UpdateProductDto
    {
        public string ProductName { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
    }
}