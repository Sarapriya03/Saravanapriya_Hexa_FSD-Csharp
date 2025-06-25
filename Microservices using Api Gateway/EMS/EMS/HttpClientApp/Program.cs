var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();

//Register HttpClientFactory
builder.Services.AddHttpClient("ApiGatewayClient", client =>
{
    client.BaseAddress=new Uri("http://localhost:5272/");
    client.DefaultRequestHeaders.Add("Accept","application/json");
});
var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseEndpoints(endpoints => {  endpoints.MapControllers(); });

app.Run();
