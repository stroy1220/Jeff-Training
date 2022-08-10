namespace CoursesApi.Models;

public class CourseListResponse
{
    public List<CourseListItem> Data { get; set; } = new();

    public int NumberOfCourses { get; set; }
    public int TotalNumberOfDaysOfTraining { get; set; }
}

public class CourseListItem
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int NumberOfDays { get; set; }
}


public class CourseCreateItem
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int NumberOfDays { get; set; }
}