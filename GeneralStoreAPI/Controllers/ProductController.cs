using GeneralStoreAPI.Models;
using GeneralStoreAPI.Models.GeneralStore_Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GeneralStoreAPI.Controllers
{
    public class ProductController : ApiController
    {
        private readonly GeneralStore_Context _context = new GeneralStore_Context();

        [HttpPost]

        public async Task<IHttpActionResult> Post(ProductCreate product)
        {
            if (!ModelState.IsValid || product is null)
            {
                return BadRequest();
            }

            var prod = new Product
            {
                Sku = product.Sku,
                Name = product.Name,
                Cost = product.Cost,
                NumberInInventory = product.NumberInInventory,
                IsInStock = product.IsInStock,

            };

            _context.Products.Add(prod);
            if (await _context.SaveChangesAsync() > 0)
            {
                return Ok($"Customer: {prod.Name} was Added to the database!");
            }
            return InternalServerError();
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get([FromUri] int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product is null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        
        }
    }


