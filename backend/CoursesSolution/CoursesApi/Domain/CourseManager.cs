
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace CoursesApi.Domain;

public class CourseManager
{
    private readonly CoursesDatabaseMongoDbAdapter _adapter;
    private ILogger<CourseManager> _logger;
    private InstructorsApiHttp _instructorApiAdapter;

    public CourseManager(CoursesDatabaseMongoDbAdapter adapter, ILogger<CourseManager> logger, InstructorsApiHttp instructorApiAdapter)
    {
        _adapter = adapter;
        _logger = logger;
        _instructorApiAdapter = instructorApiAdapter;
    }

    public async Task<CourseListResponse> GetAllCoursesAsync()
    {

        var query = _adapter.Courses.AsQueryable()
            .Where(c => c.Archived == false)
            .OrderBy(c => c.Name)
            .Select(c => new CourseListItem
            {
                Id =c.Id.ToString(),
                Name = c.Name,
                Description = c.Description,
                NumberOfDays = c.NumberOfDays
            });

        var response = await query.ToListAsync();

        return new CourseListResponse
        {
            Data = response,
            TotalNumberOfDaysOfTraining = response.Sum(t => t.NumberOfDays),
            NumberOfCourses = response.Count()
        };
        
    }

    public async Task<CourseListItem> AddACourseAsync(CourseCreateItem request)
    {
        var courseToAdd = new CourseEntity
        {
            Name = request.Name,
            Description = request.Description,
            NumberOfDays = request.NumberOfDays,
            Archived = false,
            WhenAdded = DateTime.Now
        };

        await _adapter.Courses.InsertOneAsync(courseToAdd);

        var response = new CourseListItem
        {
            Id = courseToAdd.Id.ToString(),
            Name = courseToAdd.Name,
            Description = courseToAdd.Description,
            NumberOfDays = courseToAdd.NumberOfDays
        };

        var instructor = await _instructorApiAdapter.GetAssignedInstructorForCourseAsync(courseToAdd);
        _logger.LogInformation($"The Instructor Assigned is {instructor?.name}");
        return response;
    }
}
