

using Application.Features.Product.Queries;
using Application.Interface;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Product.Queries
{
    public class GetAllProductHandler : IRequestHandler<GetAllProductQuery, List<AppProduct>>
    {
        private readonly IAppDbContext appDbContext;

        public GetAllProductHandler(IAppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<List<AppProduct>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var get = await appDbContext.AppProducts.ToListAsync();
                return get;
            }
            catch (Exception ex) { 
                return null;
            }
        }
    }
}
