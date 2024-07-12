

using Domain.Entities;
using MediatR;

namespace Application.Features.Product.Queries
{
    public class GetByIdProductQuery () :IRequest<AppProduct>
    {
        public int Id { get; set; }
    }
}
