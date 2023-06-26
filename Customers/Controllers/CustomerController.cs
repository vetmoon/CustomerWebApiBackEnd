using Customers.Database;
using Customers.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Customers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerDbContext CusstomerDbContext;
        public CustomerController(CustomerDbContext cxustomerDbcontext)
        {
            this.CusstomerDbContext = cxustomerDbcontext;
        }
        [HttpGet]
        public async Task<IActionResult> GetCustomer()
        {
            var Customers = await CusstomerDbContext.Customers.ToListAsync();
            return Ok(Customers);

        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer cus)
        {
            cus.Id = new Guid();
            await CusstomerDbContext.Customers.AddAsync(cus);
            await CusstomerDbContext.SaveChangesAsync();
            return Ok(cus);
        }
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateCustomer([FromRoute] Guid id, [FromBody] Customer cus)
        {
            var customer = await CusstomerDbContext.Customers.FirstOrDefaultAsync(a => a.Id == id);
            if (customer != null)
            {
                customer.Name = cus.Name;
                customer.MobileNo = cus.MobileNo;
                customer.EmailID = cus.EmailID;
                await CusstomerDbContext.SaveChangesAsync();
                return Ok(cus);
            }
            else
            {
                return NotFound("Customer not found");
            }

        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] Guid id)
        {
            var customer = await CusstomerDbContext.Customers.FirstOrDefaultAsync(a => a.Id == id);
            if (customer != null)
            {
                CusstomerDbContext.Remove(customer);
                await CusstomerDbContext.SaveChangesAsync();
                return Ok(customer);
            }
            else
            {
                return NotFound("Customer not found");
            }

        }
    }
}

