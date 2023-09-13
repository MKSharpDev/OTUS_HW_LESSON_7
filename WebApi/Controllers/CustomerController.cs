using System;
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


        [HttpGet()]   
        public Task<Customer> GetCustomerAsync()
        {
            throw new NotImplementedException();
        }
        [HttpGet("{id}")]
        public Task<Customer> GetCustomerByIdAsync([FromRoute] long id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]   
        public Task<long> CreateCustomerAsync([FromBody] Customer customer)
        {
            throw new NotImplementedException();
        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public Task<long> PutCustomerAsync([FromBody] Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}