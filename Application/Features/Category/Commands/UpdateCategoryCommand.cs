

using Application.DTOs.Category;
using MediatR;

namespace Application.Features.Category.Commands
{
    public class UpdateCategoryCommand():IRequest<CategoryReponse>
    {
        public int Id { get; set; }
        public UpdateCategoryRequest? UpdateCategoryRequest { get; set; }
    }
}
