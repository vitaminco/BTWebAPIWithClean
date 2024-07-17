

using Application.Features.Product.Queries;
using Application.Interface;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Handlers.Product.Queries
{
    public class GetAllProductHandler : IRequestHandler<GetAllProductQuery, List<AppProduct>>
    {
        private readonly IAppDbContext appDbContext;
        private readonly IMemoryCache cache;

        public GetAllProductHandler(IAppDbContext appDbContext, IMemoryCache cache)
        {
            this.appDbContext = appDbContext;
            this.cache = cache;
        }
        public async Task<List<AppProduct>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var cacheKey = "ProductsCacheKey";//Tạo key
                cache.Remove(cacheKey); // Xóa cache trước khi thực hiện câu truy vấn mới và cho ra kết quả khi cập nhật query mà ko cần tắt

                var get = await appDbContext.AppProducts
                    .AsNoTracking() //ko lưu kết quả truy vấn, giúp giảm tải chương trình
                    .Where(p => p.Price >= 15)
                    .ToListAsync(cancellationToken);

                return get;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu cần thiết
                throw new Exception("Error fetching products", ex);
            }
        }
    }
}
