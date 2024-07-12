

using Application.DTOs.Product;
using Application.Features.Product.Commands;
using Application.Interface;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Product.Commands
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ProductReponse>
    {
        private readonly IAppDbContext appDbContext;
        private readonly IMapper mapper;

        public UpdateProductHandler(IAppDbContext appDbContext, IMapper mapper)
        {
            this.appDbContext = appDbContext;
            this.mapper = mapper;
        }
        public async Task<ProductReponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {

            var productToUpdate = await appDbContext.AppProducts.FindAsync(request.Id);
            //Tìm Id của category đem so sánh và tiến hành update

            if (productToUpdate == null)
            {
                return new ProductReponse(false, "Không tìm thấy hoặc nhập dữ liệu không đúng");
            }
            //lây id cũ 
            var CateId = await appDbContext.AppCategories.FirstOrDefaultAsync(c => c.Id == request.UpdateProductRequest.CategoryId, cancellationToken);

            //Cập nhật
            mapper.Map(request.UpdateProductRequest, productToUpdate);
            productToUpdate.CategoryId = CateId?.Id;
            productToUpdate.UpdatedAt = DateTime.Now;

            appDbContext.AppProducts.Update(productToUpdate );
            await appDbContext.SaveChangeAsync(cancellationToken);

            return new ProductReponse(true, "Cập nhật thành công");

        }
    }
}
