using MongoDB.Bson;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Attributes;

namespace BooksApi.Models
{
    public class Tag
    {
        
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        //[BsonIgnoreIfDefault]
        public string? Id { get; set; }
        public string Name { get; set; }   
    }
}
