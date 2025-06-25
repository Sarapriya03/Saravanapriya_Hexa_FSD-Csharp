using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

//Load configuration file explicitly
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

//Add Ocelot service
builder.Services.AddOcelot();

var app = builder.Build();


if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseEndpoints(endpoints => endpoints.MapControllers());

//Configure Ocelot
await app.UseOcelot();
app.Run();
