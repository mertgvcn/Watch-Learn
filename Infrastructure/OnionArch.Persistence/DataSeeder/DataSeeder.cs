using Bogus;
using OnionArch.Domain.Entities;
using OnionArch.Domain.Enumerators;
using OnionArch.Persistence.Context;

namespace OnionArch.Persistence.DataSeeder;
public sealed class DataSeeder
{
	private readonly AppDbContext _context;

	public DataSeeder(AppDbContext context)
	{
		_context = context;
	}

	public async Task Seed()
	{
		_context.AddRange(CourseFaker.Generate(10));
		await _context.SaveChangesAsync(new());

	}

	public readonly static Faker<Course> CourseFaker = new Faker<Course>()
		.RuleFor(a => a.DateCreated, faker => faker.Date.Past())
		.RuleFor(a => a.Title, faker => faker.Lorem.Sentence(4))
		.RuleFor(a => a.ShortDescription, faker => faker.Lorem.Sentence(10))
		.RuleFor(a => a.Description, faker => faker.Lorem.Sentence(50))
		.RuleFor(a => a.Price, faker => faker.Random.Double(0, 1000))
		.RuleFor(a => a.ImgUrl, "https://www.datocms-assets.com/64859/1656365285-ingilizce-a1-a2-egitimi.png?q=70&auto=format&w=650&fit=max&iptc=allow")
		.RuleFor(a => a.Teacher, faker => new()
		{
			DateCreated = faker.Date.Past(),
			User = new()
			{
				FirstName = faker.Person.FirstName,
				LastName = faker.Person.LastName,
				Email = faker.Internet.Email(),
				PhoneNumber = "05301231212",
				Password = "12345",
				Role = Roles.Teacher
			}
		})
		.RuleFor(a => a.Students, faker => new List<Student>()
		{
			new()
			{
				DateCreated = faker.Date.Past(),
				User = new()
				{
					FirstName = faker.Person.FirstName,
					LastName = faker.Person.LastName,
					Email = faker.Internet.Email(),
					PhoneNumber = "05301231212",
					Password = "12345",
					Role = Roles.Student
				}
			},
		})
		.RuleFor(a => a.Lessons, faker => new List<Lesson>()
		{
			new()
			{
				LessonNumber = 1,
				Title = faker.Lorem.Sentence(6),
				Description = faker.Lorem.Sentence(10),
				Duration = new TimeSpan(2, 0, 0),
				VideoUrl = "https://www.youtube.com/watch?v=iu-LBY7NXD4"
			},
			new()
			{
				LessonNumber = 2,
				Title = faker.Lorem.Sentence(6),
				Description = faker.Lorem.Sentence(10),
				Duration = new TimeSpan(2, 0, 0),
				VideoUrl = "https://www.youtube.com/watch?v=iu-LBY7NXD4"
			},
			new()
			{
				LessonNumber = 3,
				Title = faker.Lorem.Sentence(6),
				Description = faker.Lorem.Sentence(10),
				Duration = new TimeSpan(2, 0, 0),
				VideoUrl = "https://www.youtube.com/watch?v=iu-LBY7NXD4"
			}
		})
		.RuleFor(a => a.CourseComments, faker => new List<CourseComment>()
		{
			new()
			{
				Comment = faker.Lorem.Sentence(10),
				Rating = faker.Random.Short(1,5),
				Student = new Student()
				{
					DateCreated = faker.Date.Past(),
					User = new()
					{
						FirstName = faker.Person.FirstName,
						LastName = faker.Person.LastName,
						Email = faker.Internet.Email(),
						PhoneNumber = "05301231212",
						Password = "12345",
						Role = Roles.Student
					}
				}
			},
			new()
			{
				Comment = faker.Lorem.Sentence(10),
				Rating = faker.Random.Short(1,5),
				Student = new Student()
				{
					DateCreated = faker.Date.Past(),
					User = new()
					{
						FirstName = faker.Person.FirstName,
						LastName = faker.Person.LastName,
						Email = faker.Internet.Email(),
						PhoneNumber = "05301231212",
						Password = "12345",
						Role = Roles.Student
					}
				}
			},
			new()
			{
				Comment = faker.Lorem.Sentence(10),
				Rating = faker.Random.Short(1,5),
				Student = new Student()
				{
					DateCreated = faker.Date.Past(),
					User = new()
					{
						FirstName = faker.Person.FirstName,
						LastName = faker.Person.LastName,
						Email = faker.Internet.Email(),
						PhoneNumber = "05301231212",
						Password = "12345",
						Role = Roles.Student
					}
				}
			}
		}).UseSeed(1453);
}
