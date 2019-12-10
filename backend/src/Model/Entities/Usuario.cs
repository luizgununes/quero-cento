using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace queroCentoBE.Model.Entities
{
    public class Usuario : IEntidade
    {
        public enum TipoUsuario
        {
            Física = 'F',
            Jurídica = 'J'
        };
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [Required]
        [RegularExpression(@"[\w\W\.\@]+",ErrorMessage = "O username não pode conter espaços e acentuação")]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [BsonDefaultValue(0)]
        public TipoUsuario Tipo { get; set; }
        [RegularExpression(@"(\d{2}[\.]?\d{3}[\.]?\d{3}[\/]?\d{4}[-]?\d{2})|(\d{3}[\.]?\d{3}[\.]?\d{3}[-]?\d{2})", ErrorMessage = "O documento deve estar no formato: XXX.XXX.XXX-XX ou XX.XXX.XXX/XXXX-XX")]
        public string Documento { get; set; }
        [RegularExpression(@"^[aA-zZàÀ-ùÙáÁ-úÚ\\çÇ\']+((\s[aA-zZàÀ-ùÙáÁ-úÚ\\çÇ\'\.]+)+)?$", ErrorMessage = "O nome deve estar em um formato válido")]
        public string Nome { get; set; }
        public string EndRua { get; set; }
        public string EndNum { get; set; }
        public string EndBairro { get; set; }
        public string EndCidade { get; set; }
        public string EndComplemento { get; set; }
        public string EndEstado { get; set; } //deverá ser colocado como lista
        public byte ImagemUsuario { get; set; }
        [Phone]
        public string Telefone { get; set; } //salvar no banco com máscara
    }
}
