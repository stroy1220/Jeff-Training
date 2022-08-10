using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CoursesApi.Domain;

public class CourseEntity
{

    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public ObjectId Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int NumberOfDays { get; set; }

    public DateTime WhenAdded { get; set; }

    public bool Archived { get; set; } = false;
}
