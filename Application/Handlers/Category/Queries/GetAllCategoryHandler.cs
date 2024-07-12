

using Application.Features.Category.Queries;
using Application.Interface;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Category.Queries
{
    public class GetAllCategoryHandler : IRequestHandler<GetAllCategoryQuery, List<AppCategory>>
    {
        private readonly IAppDbContext appDbContext;

        public GetAllCategoryHandler(IAppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<List<AppCategory>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var get = await appDbContext.AppCategories.ToListAsync();
                return get;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
