
using Application.DTOs.Category;
using Application.Features.Category.Commands;
using Application.Interface;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;

namespace Application.Handlers.Category.Commands
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, CategoryReponse>
    {
        private readonly IAppDbContext appDbContext;
        private readonly IMapper mapper;
        private readonly IValidator<CreateCategoryRequest> validator;

        public CreateCategoryHandler(IAppDbContext appDbContext, IMapper mapper, IValidator<CreateCategoryRequest> validator)
        {
            this.appDbContext = appDbContext;
            this.mapper = mapper;
            this.validator = validator;
        }
        public async Task<CategoryReponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //Thêm Validation
                var validationResult = await validator.ValidateAsync(request.CreateCategoryRequest, cancellationToken);
                if (!validationResult.IsValid)
                {
                    return new CategoryReponse(false, "Validation failed", validationResult.Errors);
                }
                //Mapp DTO -> Entities
                var add = mapper.Map<AppCategory>(request.CreateCategoryRequest);
                if (add == null)
                {
                    return new CategoryReponse(false, "Chưa điền thông tin");
                }
                add.CreatedAt = DateTime.Now;

                await appDbContext.AppCategories.AddAsync(add);
                await appDbContext.SaveChangeAsync(cancellationToken);
                return new CategoryReponse(true, "Thêm thành công");
            }
            catch (Exception ex)
            {
                return new CategoryReponse(false, $"Lỗi {ex}");
            }
        }
    }
}
