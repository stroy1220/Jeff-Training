var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapPost("/", (CourseInstructorAssignmentRequest request) =>
{
   
        var response = new InstructorAssignmentResponse { Name = "Jeff Gonzalez" + DateTime.Now.ToString(), Email = "jeff@hypertheory.com" };
        return Results.Ok(response);
   
});

app.Run();


public class CourseInstructorAssignmentRequest
{
    public string id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public int numberOfDays { get; set; }
}

public class InstructorAssignmentResponse
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}