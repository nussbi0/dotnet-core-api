using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace dotnet_core_api.Models
{
    public class Todo
    {
        [BsonElement("_id")]
        public ObjectId Id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string readableId
        {
            get { return Id.ToString(); }
        }
        public string task { get; set; } = string.Empty;
        public DateTime dueDate { get; set; }
        public bool done { get; set; } = false;
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}