
using Domain.Entities;
using MediatR;

namespace Application.Features.Category.Queries
{
    public class GetByIdCategoryQuuery :IRequest<AppCategory>
    {
        public int Id { get; set; }
    }
}
