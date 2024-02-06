using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TodoApi.Application;
using TodoApi.Infrastructure;
using TodoApi.Presentation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(options => options.CustomSchemaIds(x => x.FullName));

builder.Services
       .AddApplication()
       .AddInfrastructure(builder.Configuration, "TodoListConnectionString")
       .AddPresentation();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.Services.UseMigrations();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();