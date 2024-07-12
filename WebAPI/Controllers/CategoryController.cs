
using Application.DTOs.Category;
using Application.Features.Category.Commands;
using Application.Features.Category.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoryController(IMediator mediator) // mediator lấy dữ liệu từ reques và handler
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await mediator.Send(new GetAllCategoryQuery()));
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id) => Ok(await mediator.Send(new GetByIdCategoryQuuery { Id = id}));
        [HttpPost]
        public async Task<ActionResult<CategoryReponse>> Add(CreateCategoryRequest createCategoryRequest)
            => Ok(await mediator.Send(new CreateCategoryCommand { CreateCategoryRequest = createCategoryRequest }));
        [HttpPut("{id:int}")]
        public async Task<ActionResult<CategoryReponse>> Update(int id, UpdateCategoryRequest updateCategoryRequest)
            => Ok(await mediator.Send(new UpdateCategoryCommand { Id = id, UpdateCategoryRequest = updateCategoryRequest}));
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id) => Ok(await mediator.Send(new DeleteCategoryCommand { Id = id }));
    }
}
