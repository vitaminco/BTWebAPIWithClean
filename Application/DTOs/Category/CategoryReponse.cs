

using FluentValidation.Results;

namespace Application.DTOs.Category
{
    public record CategoryReponse(bool Flag, string Mess = null!, List<ValidationFailure> Errors = null!);
}
