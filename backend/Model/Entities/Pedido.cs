using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace queroCentoBE.Model.Entities
{
    public class Pedido
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string UserID { get; set; }
        public string IdAnuncio { get; set; }
        public double Valor { get; set; }
        public double Quantidade { get; set; }
        public DateTime Data { get; set; }
    }
}
