using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MediatR;
using Solution.Commands;
using Solution.Mapping;
using Solution.Queries;
using Solution.Repositories;
using Swashbuckle.AspNetCore.Annotations;

namespace Solution.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            if (mediator == null)
                throw new ArgumentNullException(nameof(mediator));

            _mediator = mediator;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateCustomerOrderCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction("GetOrder", new { orderId = result.Id }, result);
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrder(Guid orderId)
        {
            var query = new GetOrderByIdQuery(orderId);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpGet]
        // [SwaggerOperation(Summary = "summary....", Description = "description....")]
        // [SwaggerResponse(HttpStatusCodes.Created, "Returns the id of the created object", typeof(CreatedResponse))]
        public async Task<IActionResult> GetAllOrders()
        {
            var query = new GetAllOrdersQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
