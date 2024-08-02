using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace OnionArch.Application;
public static class Registration
{
    public static void AddApplication(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
    }
}
