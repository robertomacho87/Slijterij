using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Slijterij.DAL;
using Slijterij.Models;

namespace Slijterij.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly WhiskeyContext _context;

        public ProductController(WhiskeyContext context)
        {
            _context = context;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            List<Product> products = new List<Product> { new Product { ID = 1, Name = "Seaweed", Age = 30, AlcoholByVolume = 40, TypeID = 2, OriginID = 2, Price = 499.99M, AmountInStock = 1, Available = true },
                new Product { ID = 2, Name = "Oak", Age = 10, AlcoholByVolume = 40, TypeID = 1, OriginID = 1, Price = 49.99M, AmountInStock = 15, Available = false } };

            //return products;



                    return await _context.Products.Include(p => p.Type).Include(p => p.Origin).ToListAsync();
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.Include(p => p.Type).Include(p => p.Origin).FirstOrDefaultAsync(p => p.ID == id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // TODO: Add method to GET product by search string

        // PUT: api/Product/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.ID)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Product
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.ID }, product);
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            // TODO: Set Available to False instead of removing product

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ID == id);
        }
    }
}
