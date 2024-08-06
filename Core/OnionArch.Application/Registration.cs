using Microsoft.Extensions.DependencyInjection;
using OnionArch.Application.Features.Auth.Services;
using OnionArch.Application.Features.Courses.Services;
using OnionArch.Application.Features.Lessons.Services;
using OnionArch.Application.Features.Students.Services;
using OnionArch.Application.Features.Teachers.Services;
using OnionArch.Application.Features.Users.Services;
using OnionArch.Application.Interfaces.Services;
using System.Reflection;

namespace OnionArch.Application;
public static class Registration
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<ITeacherService, TeacherService>();
        services.AddScoped<ICourseService, CourseService>();
        services.AddScoped<ILessonService, LessonService>();

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }
}
