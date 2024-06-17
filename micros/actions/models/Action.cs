using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Actions.Models
{
    public class Action
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } // Make Id optional
        
        [BsonElement("Name")]
        public string Name { get; set; } = null!;
        
        [BsonElement("Description")]
        public string Description { get; set; } = null!;
    }
}