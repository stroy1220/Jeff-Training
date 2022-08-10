
namespace CoursesApi.Controllers;

// GET /courses
[ApiController]
public class CoursesController : ControllerBase
{
    private readonly CourseManager _courseManager;

    public CoursesController(CourseManager courseManager)
    {
        _courseManager = courseManager;
    }

    [HttpPost("courses")]
    public async Task<ActionResult> AddACourse([FromBody] CourseCreateItem request)
    {
        CourseListItem response = await _courseManager.AddACourseAsync(request);
        return StatusCode(201, response);
    }


    [HttpGet("courses")]
    public async Task<ActionResult> GetAllCourses()
    {
        
        CourseListResponse response = await _courseManager.GetAllCoursesAsync();

        return Ok(response);
    }


}
