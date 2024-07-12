

using Application.DTOs.Category;
using Domain.Entities;
using MediatR;

namespace Application.Features.Category.Commands
{
    public class DeleteCategoryCommand() :IRequest<CategoryReponse>
    {
        public int Id { get; set; }
    }
}
