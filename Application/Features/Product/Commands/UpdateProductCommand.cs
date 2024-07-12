

using Application.DTOs.Product;
using MediatR;

namespace Application.Features.Product.Commands
{
    public class UpdateProductCommand() : IRequest<ProductReponse>
    {
        public int Id { get; set; }
        public UpdateProductRequest? UpdateProductRequest { get; set; }
    }
}
