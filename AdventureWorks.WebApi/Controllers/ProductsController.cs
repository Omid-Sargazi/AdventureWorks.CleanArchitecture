using AdventureWorks.Application.Features.Products.Queries.FilterProducts;
using AdventureWorks.Application.Features.Products.Queries.GetAllProducts;
using AdventureWorks.Application.Features.Products.Queries.GetProductsWithCategoryOnly;
using AdventureWorks.Application.Features.Products.Queries.GetUnsoldProducts;
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

        [HttpGet("filter")]
        public async Task<IActionResult> Filter([FromQuery] decimal minPrice, [FromQuery] string? category)
        {
            var result = await _mediator.Send(new FilterProductsQuery
            {
                MinPrice = minPrice,
                Category = category
            });
            return Ok(result);
        }

        [HttpGet("unsold")]
        public async Task<IActionResult> GetUnsoldProducts()
        {
            var result = await _mediator.Send(new GetUnsoldProductsQuery());
            return Ok(result);
        } 
    }
}