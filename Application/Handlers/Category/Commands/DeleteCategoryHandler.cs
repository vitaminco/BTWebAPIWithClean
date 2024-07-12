

using Application.DTOs.Category;
using Application.Features.Category.Commands;
using Application.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Category.Commands
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, CategoryReponse>
    {
        private readonly IAppDbContext appDbContext;

        public DeleteCategoryHandler(IAppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<CategoryReponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var find = await appDbContext.AppCategories.FindAsync(request.Id);
                if (find != null)
                {
                    var relatedProducts = await appDbContext.AppProducts
                                                  .Where(p => p.CategoryId == request.Id)
                                                  .ToListAsync(cancellationToken);
                    //xóa cha
                    appDbContext.AppCategories.Remove(find);
                    //xóa con
                    appDbContext.AppProducts.RemoveRange(relatedProducts);

                    await appDbContext.SaveChangeAsync(cancellationToken);
                    return new CategoryReponse(true, "Xóa thành công");
                }
                else
                {
                    return new CategoryReponse(false, "Xóa ko thành công");
                }
            }
            catch (Exception ex)
            {
                return new CategoryReponse(false, $"Lỗi {ex}");
            }
        }
    }
}
