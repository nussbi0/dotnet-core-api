using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace dotnet_core_api.Models
{
    public class Todo
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string text { get; set; } = string.Empty;
        // public DateTime UpdatedOn { get; set; } = DateTime.Now;
        // public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}