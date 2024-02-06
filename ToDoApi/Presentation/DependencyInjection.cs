using Microsoft.Extensions.DependencyInjection;

namespace TodoApi.Presentation;

public static class DependencyInjection
{
  public static IServiceCollection AddPresentation(this IServiceCollection services)
  {
    services.AddControllers()
      .AddApplicationPart(typeof(Abstractions.ApiController).Assembly);

    services.AddEndpointsApiExplorer();

    return services;
  }
}