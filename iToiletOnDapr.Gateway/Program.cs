var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Enable endpoint routing, required for the reverse proxy
app.UseRouting();

// Register the reverse proxy routes
app.UseEndpoints(endpoints =>
{
    endpoints.MapReverseProxy();
});

app.Run();