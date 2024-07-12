

using Application.DTOs.Product;
using Domain.Entities;
using MediatR;

namespace Application.Features.Product.Commands
{
    public class DeleteProductCommand():IRequest<ProductReponse>
    {
        public int Id { get; set; }
    }
}
