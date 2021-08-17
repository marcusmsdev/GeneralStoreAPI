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
    public class TransactionController : ApiController
    {
        private readonly GeneralStore_Context _context = new GeneralStore_Context();

        
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var products = await _context.Transactions.ToListAsync();
            return Ok(products);
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get([FromUri] int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction is null)
            {
                return NotFound();
            }
            return Ok(transaction);
        }
        
    }
}
