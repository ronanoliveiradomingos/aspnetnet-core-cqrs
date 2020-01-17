using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Solution.Mapping;
using Solution.Queries;
using Solution.Repositories;
using Solution.Responses;

namespace Solution.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            if (mediator == null)
                throw new ArgumentNullException(nameof(mediator));

            _mediator = mediator;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetCustomers()
        {
            var query = new GetAllCustomersQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomer(Guid customerId)
        {
            var query = new GetCustomerByIdQuery(customerId);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpGet("{customerId}/orders")]
        public async Task<IActionResult> GetCustomerOrders(Guid customerId)
        {
            var query = new GetCustomerOrdersQuery(customerId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}