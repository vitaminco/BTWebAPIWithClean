
using FluentValidation.Results;

namespace Application.DTOs.Product
{
    public record ProductReponse(bool Flag, string Mess = null!, List<ValidationFailure> Errors = null!);

}
