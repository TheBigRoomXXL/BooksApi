using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BooksApi.Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Title { get; set; } = "Unknown Title";

        public string Author { get; set; } = "Unknown Author";

        public string State { get; set; } = "A lire";

        public string ISBN { get; set; } = string.Empty;

        public List<Tag>? Tags { get; set; }
    }
}