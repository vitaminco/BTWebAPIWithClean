
using Application.Configuration;
using Application.FluentValidations.Category;
using Application.FluentValidations.Product;
using Application.Handlers.Category.Queries;
using Application.Handlers.Product.Queries;
using Application.Interface;
using FluentValidation.AspNetCore;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection ServiceInfastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //sử dụng để tao db
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default"),
                b => b.MigrationsAssembly(typeof(ServiceContainer).Assembly.FullName)), ServiceLifetime.Scoped);

            /*Đăng kí interface IAppDbContext*/
            services.AddScoped<IAppDbContext>(provider => provider.GetService<AppDbContext>());
            //thêm automapper
            services.AddAutoMapper(typeof(AutoMapperConfig));
            //Thêm mediatR, Chứa các hannder
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(GetAllCategoryHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetAllProductHandler).Assembly);
            });
            // Thêm FluentValidation vào dịch vụ (báo lỗi)
            services.AddControllers()
               .AddFluentValidation(v =>
               {
                   v.RegisterValidatorsFromAssemblyContaining<CategoryValidator>();
                   v.RegisterValidatorsFromAssemblyContaining<ProductValidator>();
               });

            return services;
        }
    }

}
