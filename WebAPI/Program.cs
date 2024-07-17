using Infrastructure.DependencyInjection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Thêm dịch vụ vào container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
});

// Sử dụng dịch vụ trong Infrastructure
builder.Services.ServiceInfastructure(builder.Configuration);

var app = builder.Build();

// Sử dụng middleware phục vụ tệp tĩnh
app.UseStaticFiles();

// Cấu hình xử lý HTTP request.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
        /*c.RoutePrefix = string.Empty; // Đặt Swagger UI tại root của ứng dụng (http://localhost:<port>/)*/
        c.DocumentTitle = "Web API Custom"; // Thay đổi tiêu đề của trang Swagger UI
        c.InjectStylesheet("/swagger-ui/custom.css"); // Thêm file CSS tùy chỉnh
        c.InjectJavascript("/swagger-ui/custom.js"); // Thêm file JavaScript tùy chỉnh
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
