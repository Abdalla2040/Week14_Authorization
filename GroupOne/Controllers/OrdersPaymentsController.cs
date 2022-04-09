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

namespace GroupOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersPaymentsController : ControllerBase
    {
        private readonly Group1ComputerStore4Context _context;

        public OrdersPaymentsController(Group1ComputerStore4Context context)
        {
            _context = context;
        }

        // GET: api/OrdersPayments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdersPayment>>> GetOrdersPayment()
        {
            return await _context.OrdersPayment.ToListAsync();
        }

        // GET: api/OrdersPayments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdersPayment>> GetOrdersPayment(int id)
        {
            var ordersPayment = await _context.OrdersPayment.FindAsync(id);

            if (ordersPayment == null)
            {
                return NotFound();
            }

            return ordersPayment;
        }

        // PUT: api/OrdersPayments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdersPayment(int id, OrdersPayment ordersPayment)
        {
            if (id != ordersPayment.OrderPaymentId)
            {
                return BadRequest();
            }

            _context.Entry(ordersPayment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdersPaymentExists(id))
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

        // POST: api/OrdersPayments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrdersPayment>> PostOrdersPayment(OrdersPayment ordersPayment)
        {
            _context.OrdersPayment.Add(ordersPayment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrdersPayment", new { id = ordersPayment.OrderPaymentId }, ordersPayment);
        }

        // DELETE: api/OrdersPayments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdersPayment(int id)
        {
            var ordersPayment = await _context.OrdersPayment.FindAsync(id);
            if (ordersPayment == null)
            {
                return NotFound();
            }

            _context.OrdersPayment.Remove(ordersPayment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrdersPaymentExists(int id)
        {
            return _context.OrdersPayment.Any(e => e.OrderPaymentId == id);
        }
    }
}
