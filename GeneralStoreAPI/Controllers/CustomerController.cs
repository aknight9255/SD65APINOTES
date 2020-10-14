using GeneralStoreAPI.Models;
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
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        [HttpPost]
        public async Task<IHttpActionResult> Post(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest(ModelState);
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<Customer> listOfCustomers = await _context.Customers.ToListAsync();
            return Ok(listOfCustomers);
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetByID([FromUri] int id)
        {
            Customer foundCustomer = await _context.Customers.FindAsync(id);
            if (foundCustomer == null)
            {
                return NotFound();
            }
            return Ok(foundCustomer);
        }
        [HttpPut]
        public async Task<IHttpActionResult> Put([FromUri] int id, [FromBody]Customer model)
        {
            if (ModelState.IsValid)
            {
                if(id != model.ID)
                {
                    return BadRequest("Customer ID mismatch");
                }
                _context.Entry(model).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest(ModelState);
        }
        [HttpDelete]
        public async Task<IHttpActionResult> Delete([FromUri]int id)
        {
            var foundCustomer = await _context.Customers.FindAsync(id);
            if(foundCustomer == null)
            {
                return NotFound();
            }
            _context.Customers.Remove(foundCustomer);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
