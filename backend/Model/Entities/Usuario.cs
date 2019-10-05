using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
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
        public string TipoUsuario { get; set; }
        public string Documento { get; set; } //Precisa validar CPF e CNPJ
        public string Nome { get; set; }
        public string EndRua { get; set; }
        public string EndNum { get; set; }
        public string EndBairro { get; set; }
        public string EndCidade { get; set; }
        public string EndComplemento { get; set; }
        public string EndEstado { get; set; } //deverá ser colocado como lista
        public byte ImagemUsuario { get; set; }
        public string Telefone { get; set; } //salvar no banco com máscara
    }
}
