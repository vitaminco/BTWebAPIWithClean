


using Application.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<AppCategory> AppCategories { get; set; }
        public DbSet<AppProduct> AppProducts { get; set; }

        //Triễn khai interface IAppDbContext để lưu CRUD 
        public Task<int> SaveChangeAsync(CancellationToken cancellationToken)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //App category
            modelBuilder.Entity<AppCategory>()
                .Property(c => c.Name)
                .HasMaxLength(200);
            modelBuilder.Entity<AppCategory>()
                .Property(c => c.Description)
                .HasMaxLength(500);
            modelBuilder.Entity<AppCategory>()
                .Property(c => c.Img)
                .HasMaxLength(500);
            //App product
            modelBuilder.Entity<AppProduct>()
                .Property(c => c.Name)
                .HasMaxLength(200);
            modelBuilder.Entity<AppProduct>()
                .Property(c => c.Description)
                .HasMaxLength(500);
            modelBuilder.Entity<AppProduct>()
                .Property(c => c.Cover_Img)
                .HasMaxLength(500);
            //Khóa ngoại
            modelBuilder.Entity<AppProduct>()
                .HasOne(s => s.Category)
                .WithMany(s => s.products)
                .HasForeignKey(s => s.CategoryId)
                .IsRequired(false); // Cho phép khóa ngoại rỗng
        }
    }
}
