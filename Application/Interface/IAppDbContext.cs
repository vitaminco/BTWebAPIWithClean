

using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interface
{
    public interface IAppDbContext
    {
        
        public DbSet<AppCategory> AppCategories { get; set; }
        public DbSet<AppProduct> AppProducts { get; set; }
        //phương thức không đồng bộ dùng để lưu các thay đổi vào cơ sở dữ liệu
        Task<int> SaveChangeAsync(CancellationToken cancellationToken);
    }
}
