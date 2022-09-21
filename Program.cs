using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using School.Installers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Installer Auto
builder.Services.InstallServiceInAssembly(builder.Configuration);
//---------------------------

// register service "Autofac"
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly()!)
    .Where(t => t.Name.EndsWith("Service"))
    .AsImplementedInterfaces();
});
//---------------------------

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
