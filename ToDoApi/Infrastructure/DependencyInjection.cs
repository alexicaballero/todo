using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TodoApi.Application.Abstractions;
using TodoApi.Domain.Abstractios;
using TodoApi.Infrastructure.Repositories;
using ToDoApi.Infrastructure.Servicces;

namespace TodoApi.Infrastructure;

public static class DependencyInjection
{
  public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, string connectionStringName)
  {
    var connectionString = configuration.GetConnectionString(connectionStringName);
    services.AddDbContext<ToDoContext>(options => options.UseSqlServer(connectionString));

    services.AddScoped<IToDoListRepository, ToDoListRepository>();
    services.AddScoped<IToDoItemRepository, ToDoItemRepository>();
    services.AddScoped<IUnitOfWork, UnitOfWork>();
    services.AddScoped<DatabaseMigrationService>();

    return services;
  }

  public static void UseMigrations(this IServiceProvider serviceProvider)
  {
    using (var scope = serviceProvider.CreateScope())
    {
      var services = scope.ServiceProvider;
      var migrationService = services.GetRequiredService<DatabaseMigrationService>();
      migrationService.ApplyMigrations();
    }
  }
}