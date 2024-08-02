using MediatR;
using OnionArch.Application.Interfaces.UnitOfWorks;
using OnionArch.Domain.Entities;

namespace OnionArch.Application.Features.Courses.Queries.GetAllCourses;
public class GetAllCoursesQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllCoursesQueryRequest, IList<GetAllCoursesQueryResponse>>
{
    public async Task<IList<GetAllCoursesQueryResponse>> Handle(GetAllCoursesQueryRequest request, CancellationToken cancellationToken)
    {
        var courses = await unitOfWork.GetReadRepository<Course>().GetAllAsync();

        List<GetAllCoursesQueryResponse> response = [];

        foreach (var course in courses)
        {
            response.Add(new GetAllCoursesQueryResponse
            {
                Title = course.Title,
                Description = course.Description,
            });
        }

        return response;
    }
}
