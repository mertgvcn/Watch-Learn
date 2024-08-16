using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnionArch.Application.Interfaces.Repositories;
using OnionArch.Persistence.Context;
using OnionArch.Persistence.Repository;

namespace OnionArch.Persistence;
public static class Registration
{
	public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<AppDbContext>(opt =>
			opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

		AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

		services.AddScoped<IStudentRepository, StudentRepository>();
		services.AddScoped<ITeacherRepository, TeacherRepository>();
		services.AddScoped<ICourseRepository, CourseRepository>();
		services.AddScoped<ILessonRepository, LessonRepository>();
		services.AddScoped<IAuditLogRepository, AuditLogRepository>();
		services.AddScoped<IUserRepository, UserRepository>();
		services.AddScoped<IUserRefreshTokenRepository, UserRefreshTokenRepository>();
		services.AddScoped<IStudentLessonProgressRepository, StudentLessonProgressRepository>();
	}

	public async static Task<IHost> FillDatabase(this IHost app)
	{
		using var scope = app.Services.CreateScope();
		var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
		await new DataSeeder.DataSeeder(context).Seed();
		return app;
	}
}
