using Microsoft.AspNetCore.Mvc;
using eStoreAPI.Data.Repositories;
using eStoreAPI.Models.DTOs;
using eStoreAPI.Models.Entities;

namespace eStoreAPI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            var products = await _productRepository.GetAllAsync();
            var productDtos = products.Select(p => new ProductDto
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                UnitPrice = p.UnitPrice,
                UnitsInStock = p.UnitsInStock,
                Description = p.Description,
                CategoryId = p.CategoryId,
                CategoryName = p.Category?.CategoryName
            });

            return Ok(productDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return NotFound();

            var productDto = new ProductDto
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                Description = product.Description,
                CategoryId = product.CategoryId,
                CategoryName = product.Category?.CategoryName
            };

            return Ok(productDto);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProduct(CreateProductDto createProductDto)
        {
            var product = new Product
            {
                ProductName = createProductDto.ProductName,
                UnitPrice = createProductDto.UnitPrice,
                UnitsInStock = createProductDto.UnitsInStock,
                Description = createProductDto.Description,
                CategoryId = createProductDto.CategoryId
            };

            var createdProduct = await _productRepository.CreateAsync(product);

            var productDto = new ProductDto
            {
                ProductId = createdProduct.ProductId,
                ProductName = createdProduct.ProductName,
                UnitPrice = createdProduct.UnitPrice,
                UnitsInStock = createdProduct.UnitsInStock,
                Description = createdProduct.Description,
                CategoryId = createdProduct.CategoryId
            };

            return CreatedAtAction(nameof(GetProduct), new { id = productDto.ProductId }, productDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, UpdateProductDto updateProductDto)
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);
            if (existingProduct == null)
                return NotFound();

            existingProduct.ProductName = updateProductDto.ProductName;
            existingProduct.UnitPrice = updateProductDto.UnitPrice;
            existingProduct.UnitsInStock = updateProductDto.UnitsInStock;
            existingProduct.Description = updateProductDto.Description;
            existingProduct.CategoryId = updateProductDto.CategoryId;

            await _productRepository.UpdateAsync(existingProduct);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var deleted = await _productRepository.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}