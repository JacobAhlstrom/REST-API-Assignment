using DagnysBakeryAPI.Data;
using DagnysBakeryAPI.Entities;
using DagnysBakeryAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DagnysBakeryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(BakeryContext context) : ControllerBase
    {
        private readonly BakeryContext _context = context;

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProductById(int id)
        {
            var product = await _context.Products
                .Include(p => p.Supplier)  // Om du vill inkludera supplierinformation
                .FirstOrDefaultAsync(p => p.ProductId == id);

            if (product == null)
            {
                return NotFound(); // Returnerar 404 om produkten inte hittas
            }

            return Ok(product); // Returnerar 200 OK med produktdata
        }

        
        [HttpGet("name/{name}")]
        public async Task<ActionResult> GetProductsByName(string name)
        {
            var products = await _context.Products
                .Where(product => product.Name == name)
                .Include(product => product.Supplier)
                .Select(product => new ProductViewModel
                {
                    Name = product.Name,
                    ArticleNumber = product.ArticleNumber,
                    PricePerKg = product.PricePerKg,
                    Supplier = new SupplierViewModel
                    {
                        Name = product.Supplier.Name,
                        ContactPerson = product.Supplier.ContactPerson,
                        PhoneNumber = product.Supplier.PhoneNumber,
                        Email = product.Supplier.Email
                    }
                }
                )
                .ToListAsync();

            return Ok(new { success = true, products });
        }

        [HttpGet("supplier/{supplierId}")]
        public async Task<ActionResult> GetProductsBySupplier(int supplierId)
        {
            var supplier = await _context.Suppliers
                .Where(supplier => supplier.SupplierId == supplierId)
                .Include(supplier => supplier.Products)
                .Select(supplier => new
                {
                    supplier.Name,
                    supplier.ContactPerson,
                    supplier.PhoneNumber,
                    supplier.Email,
                    Products = supplier.Products.Select(product => new
                    {
                        product.Name,
                        product.ArticleNumber,
                        product.PricePerKg
                    })
                }
                )
                .FirstOrDefaultAsync();

            if (supplier == null)
                return NotFound();

            return Ok(new { success = true, supplier });
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct(ProductCreateViewModel model)
        {
            var product = new Product
            {
                Name = model.Name,
                ArticleNumber = model.ArticleNumber,
                PricePerKg = model.PricePerKg,
                SupplierId = model.SupplierId
            };

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProductById), new { id = product.ProductId }, product);
        }

        [HttpPatch("{productId}")]
        public async Task<ActionResult> UpdateProductPrice(int productId, decimal newPrice)
        {
            var product = _context.Products.Find(productId);
            if (product == null)
                return NotFound();

            product.PricePerKg = newPrice;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        
    }
}