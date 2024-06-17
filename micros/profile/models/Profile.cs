using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Profile.Models
{
    public class UserProfile
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Bio { get; set; } // Made nullable to address potential initialization concerns
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}