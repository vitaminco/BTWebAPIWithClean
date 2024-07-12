

using Domain.Entities;
using MediatR;

namespace Application.Features.Product.Queries
{
    public class GetAllProductQuery() : IRequest<List<AppProduct>>
    {
    }
}
