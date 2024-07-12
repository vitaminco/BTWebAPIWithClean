

using Application.Features.Product.Queries;
using Application.Interface;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Handlers.Product.Queries
{
    public class GetByIdProductHandler : IRequestHandler<GetByIdProductQuery, AppProduct>
    {
        private readonly IAppDbContext appDbContext;
        private readonly ILogger<GetAllProductHandler> logger;

        public GetByIdProductHandler(IAppDbContext appDbContext, ILogger<GetAllProductHandler> logger)
        {
            this.appDbContext = appDbContext;
            this.logger = logger;
        }
        public async Task<AppProduct> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await appDbContext.AppProducts.FindAsync(request.Id);
                logger.LogInformation($"Tìm thấy: {res}");
                return res;
            }
            catch (Exception ex)
            {
                logger.LogInformation("Lỗi");
                return null;
            }
        }
    }
}
