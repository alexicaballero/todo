using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using TodoApi.Application.Abstractions;
using TodoApi.Domain.Abstractios;
using TodoApi.Infrastructure.Repositories;
using ToDoApi.Infrastructure.Servicces;

namespace TodoApi.Infrastructure;

public static class DependencyInjection
{
  public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, string connectionStringName)
  {
    Console.WriteLine("***********************************************************************");
    Debug.WriteLine("***********************************************************************");
    var connectionString = configuration.GetConnectionString(connectionStringName);
    Console.WriteLine(connectionString);
    Debug.WriteLine(connectionString);
    Console.WriteLine("***********************************************************************");
    Debug.WriteLine("***********************************************************************");

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