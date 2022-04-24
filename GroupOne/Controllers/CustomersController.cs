#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GroupOne.Data;
using GroupOne.Models;
using Microsoft.AspNetCore.Authorization;


namespace GroupOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly Group1ComputerStore4Context _context;
        private readonly JwtAuthenticationManager jwtAuthenticationManager;

        public CustomersController(Group1ComputerStore4Context context, JwtAuthenticationManager jwtAuthenticationManager)
        {
            _context = context;
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }

        // GET: api/Customers
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomer()
        {
            return await _context.Customer.ToListAsync();
        }

        [AllowAnonymous]
        [HttpPost("Authorize")]
        public IActionResult AuthUser([FromBody] User usr)
        {
            var token = jwtAuthenticationManager.Authenticate(usr.username, usr.password);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }

        // GET: api/Customers/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _context.Customer.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
        }

        // DELETE: api/Customers/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.CustomerId == id);
        }
    }
}
