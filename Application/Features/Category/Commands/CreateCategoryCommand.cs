

using Application.DTOs.Category;
using MediatR;

namespace Application.Features.Category.Commands
{
    public class CreateCategoryCommand() :IRequest<CategoryReponse>
    {
        //sử dụng để tạo một danh mục mới.
        public CreateCategoryRequest? CreateCategoryRequest { get; set; }

    }
}
