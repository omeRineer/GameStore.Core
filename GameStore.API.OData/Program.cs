using Core.ServiceModules;
using Core.Extensions;
using Entities.Main;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using Business.ServiceModules;
using Microsoft.OData.Edm;
using Autofac;
using Business.DependencyResolvers.Autofac;
using Autofac.Extensions.DependencyInjection;
using Core.Entities.Concrete.ProcessGroups;
using Core.Entities.Concrete.Menu;
using System.Text.Json.Serialization;
using Core.Utilities.ServiceTools;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Entities.Concrete.GeneralSettings;
using MeArch.Module.Security.Model.UserIdentity;
using Autofac.Core;
using Configuration;
using DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;

#region Edm Models
static IEdmModel GetEdmModel()
{
    var oDataBuilder = new ODataConventionModelBuilder();

    oDataBuilder.EntitySet<Category>("Categories");
    oDataBuilder.EntitySet<Game>("Games");
    oDataBuilder.EntitySet<Media>("Medias");
    oDataBuilder.EntitySet<SliderContent>("SliderContents");
    oDataBuilder.EntitySet<TypeLookup>("TypeLookups");
    oDataBuilder.EntitySet<GeneralSetting>("GeneralSettings");
    oDataBuilder.EntitySet<Menu>("Menus");
    oDataBuilder.EntitySet<Blog>("Blogs");
    oDataBuilder.EntitySet<Permission>("Permissions");
    oDataBuilder.EntitySet<Role>("Roles");
    oDataBuilder.EntitySet<User>("Users");

    return oDataBuilder.GetEdmModel();
}
#endregion

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(container => container.RegisterModule<AutofacDependencyResolversModule>());

builder.Services.AddCors(options =>
                options.AddDefaultPolicy(builder =>
                builder.AllowAnyHeader()
                       .AllowAnyMethod()
                       .AllowAnyOrigin()));

builder.Services.AddControllers()
                .AddOData(options =>
                {
                    options.EnableQueryFeatures();
                    options.AddRouteComponents("odata", GetEdmModel());
                });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

StaticServiceProvider.CreateInstance(app.Services.GetService<IServiceScopeFactory>());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
