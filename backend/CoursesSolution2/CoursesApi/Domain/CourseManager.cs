
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace CoursesApi.Domain;

public class CourseManager
{
    private readonly CoursesDatabaseMongoDbAdapter _adapter;

    public CourseManager(CoursesDatabaseMongoDbAdapter adapter)
    {
        _adapter = adapter;
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
        return response;
    }
}
