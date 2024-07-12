

using Application.DTOs.Product;
using FluentValidation;

namespace Application.FluentValidations.Product
{
    public class ProductValidator:AbstractValidator<CreateProductRequest>
    {
        public ProductValidator()
        {
            RuleFor(category => category.Name).NotEmpty().WithMessage("Tên sản phẩm là bắt buộc");
        }
    }
}
