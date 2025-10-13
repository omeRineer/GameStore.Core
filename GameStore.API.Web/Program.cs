using Business.ServiceModules;
using Core.ServiceModules;
using DataAccess.ServiceModules;
using Core.Extensions;
using Autofac;
using Business.DependencyResolvers.Autofac;
using Autofac.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(container => container.RegisterModule<AutofacDependencyResolversModule>());


builder.Services.AddServiceModules(new IServiceModule[]
{
    new RepositoryServiceModule(),
    new MeArchitectureServiceModule(),
    new WebModule()
});

builder.Services.AddControllers();

var app = builder.Build();

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
