using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.GeoJsonObjectModel;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace queroCentoBE.Model.Entities
{
    public class Usuario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

            

    }
}
