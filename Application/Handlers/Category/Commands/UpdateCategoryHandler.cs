

using Application.DTOs.Category;
using Application.Features.Category.Commands;
using Application.Interface;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Handlers.Category.Commands
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, CategoryReponse>
    {
        private readonly IAppDbContext appDbContext;
        private readonly IMapper mapper;

        public UpdateCategoryHandler(IAppDbContext appDbContext, IMapper mapper)
        {
            this.appDbContext = appDbContext;
            this.mapper = mapper;
        }
        public async Task<CategoryReponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var find = await appDbContext.AppCategories.FindAsync(request.Id);
                if (find == null)
                {
                    return new CategoryReponse(false, "Cập nhật ko thành công");
                }
                //cập nhật dữ liệu
                mapper.Map(request.UpdateCategoryRequest, find);
                find.UpdatedAt = DateTime.Now;

                appDbContext.AppCategories.Update(find);
                await appDbContext.SaveChangeAsync(cancellationToken);
                return new CategoryReponse(true, "Cập nhật thành công");
            }
            catch (Exception ex)
            {
                return new CategoryReponse(false, "Cập nhật ko thành công");
            }
        }
    }
}
