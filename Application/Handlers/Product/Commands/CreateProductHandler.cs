
using Application.DTOs.Category;
using Application.DTOs.Product;
using Application.Features.Product.Commands;
using Application.Interface;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Product.Commands
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductReponse>
    {
        private readonly IAppDbContext appDbContext;
        private readonly IMapper mapper;
        private readonly IValidator<CreateProductRequest> validator;

        public CreateProductHandler(IAppDbContext appDbContext, IMapper mapper, IValidator<CreateProductRequest> validator)
        {
            this.appDbContext = appDbContext;
            this.mapper = mapper;
            this.validator = validator;
        }
        public async Task<ProductReponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {   
                //Thêm Validation
                var validationResult = await validator.ValidateAsync(request.CreateProductRequest, cancellationToken);
                if (!validationResult.IsValid)
                {
                    return new ProductReponse(false, "Validation failed", validationResult.Errors);
                }
                //So sánh Id
                var cateId = await appDbContext.AppCategories.FirstOrDefaultAsync(c => c.Id == request.CreateProductRequest.CategoryId, cancellationToken);
                //Map dữ liệu
                var res = mapper.Map<AppProduct>(request.CreateProductRequest);
                //Kiểm tra
                if (res == null)
                {
                    return new ProductReponse(false, "Chưa thêm dữ liệu hoặc nhập không đúng");
                }
                //Cho phép CategoryId null
                res.CategoryId = cateId?.Id;
                res.CreatedAt = DateTime.Now;
                await appDbContext.AppProducts.AddAsync(res);
                await appDbContext.SaveChangeAsync(cancellationToken);
                return new ProductReponse(true, "Thêm thành công");
            }
            catch (Exception ex)
            {
                return new ProductReponse(false, $"Lỗi {ex}");
            }
        }
    }
}
