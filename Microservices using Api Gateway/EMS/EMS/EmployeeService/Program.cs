using EmployeeDAL.DataAccess;
using EmployeeDAL.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<IEmpProfileDataRepo<EmpProfile>, EmpProfileDataRepo>();
var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
