using MongoDB.Bson.Serialization.Conventions;

var builder = WebApplication.CreateBuilder(args);
// Configuration of our application 

var conventionPack = new ConventionPack()
{
        new CamelCaseElementNameConvention()
};
ConventionRegistry.Register("courses-api", conventionPack, t => true);

builder.Services.AddScoped<CourseManager>();
// Add services to the container.


var coursesDbConnectionString = builder.Configuration.GetConnectionString("courses_db");

var mongoDbAdapter = new CoursesDatabaseMongoDbAdapter(coursesDbConnectionString);

builder.Services.AddSingleton(mongoDbAdapter);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// After we build the application

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

Console.WriteLine("Fixing To Run the Application");
app.Run();
Console.WriteLine("Ran the application");
