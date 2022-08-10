namespace CoursesApi.Adapters;

public class InstructorsApiHttp
{
    private readonly HttpClient _http;

    public InstructorsApiHttp(HttpClient http)
    {
        _http = http;
    }


    public async Task<InstructorAssignmentResponse?> GetAssignedInstructorForCourseAsync(CourseEntity course)
    {
        var response = await _http.GetAsync("/");
        response.EnsureSuccessStatusCode(); // Punch me in the nose if there is a failure

        var content = await response.Content.ReadFromJsonAsync<InstructorAssignmentResponse>();

        return content;
    }
}



public class InstructorAssignmentResponse
{
    public string name { get; set; }
    public string email { get; set; }
}
