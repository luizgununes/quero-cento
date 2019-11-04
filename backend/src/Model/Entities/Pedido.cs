using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace queroCentoBE.Model.Entities
{
    public class Pedido : IEntidade
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [Required]
        public string UserID { get; set; }
        [Required]
        public string IdAnuncio { get; set; }
        [Range(0, 9999.999, ErrorMessage = "Digite um preço válido")]
        public double Valor { get; set; }
        [Range(0, 9999.999, ErrorMessage = "Digite uma quantidade válida")]
        public double Quantidade { get; set; }
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
    }
}
