using Autofac.Extensions.DependencyInjection;
using Autofac;
using Business;
using Business.DependencyResolvers.Autofac;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler =
            ReferenceHandler.IgnoreCycles;
        });
builder.Services.AddBusinessServices();
builder.Services.AddDataAccessServices(builder.Configuration);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Host
//.UseServiceProviderFactory(new AutofacServiceProviderFactory())
//.ConfigureContainer<ContainerBuilder>(builder =>
//{
//    builder.RegisterModule(new AutofacBusinessModule());
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();