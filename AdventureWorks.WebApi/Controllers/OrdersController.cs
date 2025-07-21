using AdventureWorks.Application.Features.Orders.Queries.GetTopOrders;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdventureWorks.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("top-orders")]
        public async Task<ActionResult<List<TopOrderDto>>> GetTopOrders([FromQuery] int topN = 5)
        {
            var result = await _mediator.Send(new GetTopOrdersQuery { TopN = topN });
            return Ok(result);
        }
    }
}