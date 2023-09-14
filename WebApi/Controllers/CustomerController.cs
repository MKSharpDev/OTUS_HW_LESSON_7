using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CustomerController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<CustomerController> _logger;
        public CustomerController(AppDbContext context, ILogger<CustomerController> logger)
        {
            _context = context;
            _logger = logger;
        }


        [HttpGet()]   
        public IEnumerable<Customer> GetCustomerAsync()
        {
            return this._context.Customer.ToArray();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var customer = _context.Customer.SingleOrDefault(p => p.Id == id);
            if (customer != null)
            {
                return Ok(customer);
            }

            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Customer>> Post([FromBody] Customer customer)
        {
            var SearchCustomer = _context.Customer.SingleOrDefault(p => p.Id == customer.Id);
            if (SearchCustomer == null)
            {
                this._context.Customer.Add(customer);
                await this._context.SaveChangesAsync();
                return CreatedAtAction(nameof(Post), new { id = customer.Id }, customer);
            }

            var error = new ProblemDetails
            {
                Type = "https://httpstatuses.com/409",
                Status = StatusCodes.Status409Conflict,
                Title = "Already exist"
            };
            return StatusCode(409, error); 

            

        }
    }
}