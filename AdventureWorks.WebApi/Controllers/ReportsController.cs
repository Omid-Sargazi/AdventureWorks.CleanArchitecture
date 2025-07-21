using AdventureWorks.Application.Features.Products.Queries.GetTopCustomers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdventureWorks.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReportsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("top-customers")]
        public async Task<IActionResult> GetTopCustomers([FromQuery] int top=5)
        {
            var result = await _mediator.Send(new GetTopCustomersQuery { TopN = top });
                return Ok(result);
        }
    }
}
