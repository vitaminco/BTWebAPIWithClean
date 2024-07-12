

using Application.DTOs.Product;
using Application.Features.Product.Commands;
using Application.Interface;
using MediatR;

namespace Application.Handlers.Product.Commands
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, ProductReponse>
    {
        private readonly IAppDbContext appDbContext;

        public DeleteProductHandler(IAppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<ProductReponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //tìm trong bảng producct
                var find = await appDbContext.AppProducts.FindAsync(request.Id);
                if (find == null)
                {
                    return new ProductReponse(false, "Khong tìm thấy");
                }
                appDbContext.AppProducts.Remove(find);
                await appDbContext.SaveChangeAsync(cancellationToken);
                return new ProductReponse(true, "Xóa thành công");
            }
            catch (Exception ex)
            {
                return new ProductReponse(false, $"Lỗi {ex}");
            }
        }
    }
}
