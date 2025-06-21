using DAL.DataAccess;
using DAL.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();

//To register dependency with Life-Time
builder.Services.AddScoped<IAdminInfoRepo<AdminInfo>, AdminInfoRepo>();
builder.Services.AddScoped<IProductRepo<Product>, ProductRepo>();
builder.Services.AddScoped<ICustomerInfoRepo<CustomerInfo>, CustomerInfoRepo>();
builder.Services.AddScoped<IProductRepo<Product>, ProductRepo>();
builder.Services.AddScoped<IOrderRepo<Order>, OrderRepo>();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();
