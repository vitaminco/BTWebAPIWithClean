

using Application.DTOs.Category;
using FluentValidation;

namespace Application.FluentValidations.Category
{
    public class CategoryValidator : AbstractValidator<CreateCategoryRequest>
    {
        public CategoryValidator()
        {
            RuleFor(category => category.Name).NotEmpty().WithMessage("Name là bắt buộc");
            RuleFor(category => category.Img).NotEmpty().WithMessage("Img là bắt buộc");
        }
    }
}
