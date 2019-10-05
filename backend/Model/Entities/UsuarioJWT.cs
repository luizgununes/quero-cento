using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace queroCentoBE.Model.Entities
{
    public class UsuarioJWT
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public string UserID { get; set; }
        public string AccessKey { get; set; }
    }
    public class TokenConfigurations
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Seconds { get; set; }
    }
}
