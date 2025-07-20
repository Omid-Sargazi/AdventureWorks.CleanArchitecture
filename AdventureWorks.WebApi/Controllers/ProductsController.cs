using AdventureWorks.Application.Features.Products.Queries.GetAllProducts;
using AdventureWorks.Application.Features.Products.Queries.GetProductsWithCategoryOnly;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdventureWorks.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllProductsQuery());
            return Ok(result);
        }
        [HttpGet("with-category")]
        public async Task<IActionResult> GetOnlyWithCategory()
        {
            var result = await _mediator.Send(new GetProductsWithCategoryOnlyQuery());
            return Ok(result);
        }
    }
}