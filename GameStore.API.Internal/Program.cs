using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using Business.ServiceModules;
using Configuration;
using Core.Extensions;
using Core.ServiceModules;
using Core.Utilities.ServiceTools;
using DataAccess.Concrete.EntityFramework;
using DataAccess.ServiceModules;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.FileProviders;
using System;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(container => container.RegisterModule<AutofacDependencyResolversModule>());

//await builder.Services.AddRabbitMqAsync();
builder.Services.AddServiceModules(new IServiceModule[]
{
    new BusinessServiceModule(),
    new MeArchitectureServiceModule(),
    new RepositoryServiceModule()
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();


#region Host Build

var app = builder.Build();

StaticServiceProvider.CreateInstance(app.Services.GetService<IServiceScopeFactory>());

#if !DEBUG
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CoreContext>();
    db.Database.Migrate();
}
#endif

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomExceptionHandler();

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

#endregion

