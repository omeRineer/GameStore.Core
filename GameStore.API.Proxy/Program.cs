using Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddReverseProxy()
                .LoadFromConfig(CoreConfiguration.GetSection("ReverseProxy"));

var app = builder.Build();

app.UseHttpsRedirection();

app.MapReverseProxy();

app.Run();