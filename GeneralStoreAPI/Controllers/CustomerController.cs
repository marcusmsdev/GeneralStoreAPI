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
    public class CustomerController : ApiController
    {
        private readonly GeneralStore_Context _context = new GeneralStore_Context();

        [HttpPost]

        public async Task<IHttpActionResult> Post(CustomerCreate customer)
        {
            if (!ModelState.IsValid || customer is null)
            {
                return BadRequest();
            }

            var entity = new Customer
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                
            };
           
            _context.Customers.Add(entity);
            if (await _context.SaveChangesAsync() > 0)
            {
                return Ok($"Customer: {entity.FullName} was Added to the database!");
            }
            return InternalServerError();
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var customers = await _context.Customers.ToListAsync();
            return Ok(customers);
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get([FromUri] int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer is null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        [HttpPut]
        public async Task<IHttpActionResult> Put([FromUri] int id, [FromBody] Customer newCustomerData)
        {
            //check if the ids match...
            if (id != newCustomerData.Id)
            {
                return BadRequest("Invalid ID entry");
            }

            //check if newEmployeeData is valid... All 'Required Fields are accounted for'
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //check if the newEmployeeData is not 'nothing'
            if (newCustomerData is null)
            {
                return BadRequest("Empty Data Error.");
            }

            //Find an existing employee...
            var customer = await _context.Customers.FindAsync(id);

            //if that employee doesn't exist
            if (customer is null)
            {
                return NotFound();
            }

            //update employee w/ newemployeeData values
            customer.FirstName = newCustomerData.FirstName;
            customer.LastName = newCustomerData.LastName;
            
            //check to see if changes were made...
            if (await _context.SaveChangesAsync() > 0)
            {
                return Ok("Customer was updated!");
            }
            else
            {
                //if no changes could be made...
                return InternalServerError();
            }
        }
        [HttpDelete]
        public async Task<IHttpActionResult> Delete([FromUri] int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer is null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);

            if (await _context.SaveChangesAsync() > 0)
            {
                return Ok($"Customer was successfully Removed from the database.");
            }
            else
            {
                return InternalServerError();
            }
        }
    }
}


