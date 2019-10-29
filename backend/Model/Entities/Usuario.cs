using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace queroCentoBE.Model.Entities
{
    public class Usuario
    {
        public Usuario(string id, string username, string password, string tipoUsuario, string documento, string nome, string endRua, string endNum, string endBairro, string endCidade, string endComplemento, string endEstado, byte imagemUsuario, string telefone)
        {
            Id = id;
            Username = username;
            Password = password;
            TipoUsuario = tipoUsuario;
            Documento = documento;
            Nome = nome;
            EndRua = endRua;
            EndNum = endNum;
            EndBairro = endBairro;
            EndCidade = endCidade;
            EndComplemento = endComplemento;
            EndEstado = endEstado;
            ImagemUsuario = imagemUsuario;
            Telefone = telefone;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
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
