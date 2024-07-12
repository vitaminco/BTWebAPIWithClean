
using Application.DTOs.Product;
using MediatR;

namespace Application.Features.Product.Commands
{
    public class CreateProductCommand():IRequest<ProductReponse>
    {
        public CreateProductRequest? CreateProductRequest { get; set; }
    }
}
