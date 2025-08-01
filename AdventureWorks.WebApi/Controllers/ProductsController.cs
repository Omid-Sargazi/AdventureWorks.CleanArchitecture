using AdventureWorks.Application.Features.Products.Queries.FilterProducts;
using AdventureWorks.Application.Features.Products.Queries.GetAllProducts;
using AdventureWorks.Application.Features.Products.Queries.GetMonthlySales;
using AdventureWorks.Application.Features.Products.Queries.GetProductsWithCategoryOnly;
using AdventureWorks.Application.Features.Products.Queries.GetTopSellingProducts;
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

        [HttpGet("top-selling")]
        public async Task<IActionResult> GetTopSellingProducts([FromQuery] int top = 10)
        {
            var result = await _mediator.Send(new GetTopSellingProductsQuery { TopN = top });
            return Ok(result);
        }

        [HttpGet("/api/reports/monthly-sales")]
        public async Task<IActionResult> GetMonthlySales([FromQuery] int? year)
        {
            var result = await _mediator.Send(new GetMonthlySalesQuery { Year = year });
            return Ok(result);
        }


    }
}