using Application.DTOs.Product;
using Application.Features.Product.Commands;
using Application.Features.Product.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await mediator.Send(new GetAllProductQuery()));
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id) => Ok(await mediator.Send(new GetByIdProductQuery { Id = id}));
        [HttpPost]
        public async Task<ActionResult<ProductReponse>> Add(CreateProductRequest createProductRequest)
            => Ok(await mediator.Send(new CreateProductCommand { CreateProductRequest = createProductRequest}));
        [HttpPut("{id:int}")]
        public async Task<ActionResult<ProductReponse>> Update(int id, UpdateProductRequest updateProductRequest)
            => Ok(await mediator.Send(new UpdateProductCommand { Id = id, UpdateProductRequest= updateProductRequest}));
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ProductReponse>> Delete(int id) => Ok(await mediator.Send(new DeleteProductCommand { Id = id }));
    }
}
