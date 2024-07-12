

using Domain.Entities;
using MediatR;

namespace Application.Features.Category.Queries
{
    public class GetAllCategoryQuery() : IRequest<List<AppCategory>>
    {
    }
}
