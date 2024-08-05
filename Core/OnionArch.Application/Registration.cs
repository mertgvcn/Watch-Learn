using Microsoft.Extensions.DependencyInjection;
using OnionArch.Application.Features.Auth.Services;
using OnionArch.Application.Features.Courses.Services;
using OnionArch.Application.Features.Lessons.Services;
using OnionArch.Application.Features.Students.Services;
using OnionArch.Application.Features.Teachers.Services;
using OnionArch.Application.Interfaces.Services;
using OnionArch.Infrastructure.Token;
using System.Reflection;

namespace OnionArch.Application;
public static class Registration
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<ITeacherService, TeacherService>();
        services.AddScoped<ICourseService, CourseService>();
        services.AddScoped<ILessonService, LessonService>();
        services.AddScoped<ITokenService, TokenService>();

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }
}
