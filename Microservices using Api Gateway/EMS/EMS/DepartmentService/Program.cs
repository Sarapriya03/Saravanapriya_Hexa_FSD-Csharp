using DepartmentDAL.DataAccess;
using DepartmentDAL.Models;
using EmployeeDAL.DataAccess;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<IDepartmentDataRepo<Department>, DepartmentDataRepo>();
var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseEndpoints(endpoints => {  endpoints.MapControllers(); });

app.Run();
