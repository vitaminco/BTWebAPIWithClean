
using Application.Features.Category.Queries;
using Application.Interface;
using Domain.Entities;
using MediatR;

namespace Application.Handlers.Category.Queries
{
    public class GetByIdCategoryHandler : IRequestHandler<GetByIdCategoryQuuery, AppCategory>
    {
        private readonly IAppDbContext appDbContext;

        public GetByIdCategoryHandler(IAppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<AppCategory> Handle(GetByIdCategoryQuuery request, CancellationToken cancellationToken)
        {
            try
            {
                var find = await appDbContext.AppCategories.FindAsync(request.Id);
                return find;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
