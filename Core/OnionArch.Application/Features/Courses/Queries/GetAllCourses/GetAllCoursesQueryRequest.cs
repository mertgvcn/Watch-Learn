using MediatR;

namespace OnionArch.Application.Features.Courses.Queries.GetAllCourses;
public class GetAllCoursesQueryRequest : IRequest<IList<GetAllCoursesQueryResponse>>
{
}
