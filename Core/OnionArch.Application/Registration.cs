using Microsoft.Extensions.DependencyInjection;
using OnionArch.Application.Features.Courses.Services;
using OnionArch.Application.Interfaces.Services;
using System.Reflection;

namespace OnionArch.Application;
public static class Registration
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICourseService, CourseService>();

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }
}
