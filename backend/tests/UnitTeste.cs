using Newtonsoft.Json;
using queroCentoBE.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static queroCentoBE.Model.Entities.Usuario;

namespace queroCentoBETestes
{
    public class UnitTest
    {
        
    #if DEBUG
        const string URL_API = "http://localhost/api";
    #else
        const string URL_API = "http://localhost:777/api";
    #endif
        const string URL_TOKEN = URL_API + "/LoginApi/";
        string token;

        [Theory]
        [InlineData("faustao","a")]
        [InlineData("", "")]
        [InlineData(null, null)]
        public async void TestTokenDeAcessoLoginIncorreto(string userid,string acceskey)
        {
            //JSON PARA RESGATAR TOKEN
            var bodyToken = new
            {
                userid = userid,
                accesskey = acceskey
            };
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, new Uri(URL_TOKEN))
            {
                Content = new StringContent(JsonConvert.SerializeObject(bodyToken), Encoding.UTF8, "application/json")
            };
            //FAZ REQUISIÇÃO
            HttpResponseMessage response = await new HttpClient().SendAsync(req);
            Assert.Contains("Falha ao autenticar", response.Content.ReadAsStringAsync().Result);
        }

        [Fact]
        public async void TestTokenDeAcessoLoginCorreto()
        {
            //JSON PARA RESGATAR TOKEN
            var bodyToken = new {
                userid = "faustao",
                accesskey = "olocomeuolocomeuolocomeu"
            };
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, new Uri(URL_TOKEN));
            req.Content = new StringContent(JsonConvert.SerializeObject(bodyToken), Encoding.UTF8, "application/json");
            //FAZ REQUISIÇÃO
            var response = await new HttpClient().SendAsync(req);
            Assert.Contains("OK", response.Content.ReadAsStringAsync().Result);
        }

        [Theory]
        [InlineData("Muriel.Lima@1!3", "", TipoUsuario.Jurídica, "42.3825.367/0001-10", "Sant'ana ç")]
        [InlineData("@ lima.Muriel", "testezaço", TipoUsuario.Física, "278.936.200-199", "Engenheiro JR. @123")]
        [InlineData("muriellima()", "AbCç12@.&%", TipoUsuario.Jurídica, "42.385.367/0001-10", "10")]
        [InlineData("", "AbCç12@.&%", TipoUsuario.Física, "278.936.200-99", "-123")]
        public async void TestValidaCriacaoUsuarioInCorreto(string username, string password, TipoUsuario tipo, string documento, string nome)
        {
            token = await Token();
            Usuario usuario = new Usuario
            {
                Username = username,
                Password = password,
                Tipo = tipo,
                Documento = documento,
                Nome = nome
            };

            // Executa validação do modelo
            var resultadoValidacao = new List<ValidationResult>();
            var contexto = new ValidationContext(usuario, null, null);
            Validator.TryValidateObject(usuario, contexto, resultadoValidacao, true);
            Assert.True(resultadoValidacao.Count() > 0);
        }

        [Theory]
        [InlineData("Muriel.Lima@13", "", TipoUsuario.Jurídica, "42.385.367/0001-10", "Sant'ana ç")]
        [InlineData("@lima.Muriel", "testezaço", TipoUsuario.Física, "278.936.200-99", "Engenheiro JR.")]
        [InlineData("muriellima", "AbCç12@.&%", TipoUsuario.Jurídica, "42.385.367/0001-10", "10")]
        [InlineData("123", "123456", TipoUsuario.Física, "278.936.200-99", "Agenor testador")]
        public async void TestValidaCriacaoUsuarioCorreto(string username, string password, TipoUsuario tipo, string documento, string nome)
        {
            token = await Token();
            Usuario usuario = new Usuario
            {
                Username = username,
                Password = password,
                Tipo = tipo,
                Documento = documento,
                Nome = nome
            };

            // Executa validação do modelo
            var resultadoValidacao = new List<ValidationResult>();
            var contexto = new ValidationContext(usuario, null, null);
            Validator.TryValidateObject(usuario, contexto, resultadoValidacao, true);
            Assert.True(resultadoValidacao.Count() == 0);
        }

        [Theory]
        [InlineData("teste", "testezinho", 1, "42.385.367/0001-10", "Sant'ana ç")]
        public async void TestCriacaoUsuarioCorreto(string username, string password, int tipo, string documento, string nome)
        {
            token = await Token();
            var body = new
            {
                username = username,
                password = password,
                tipo = tipo,
                documento = documento,
                nome = nome
            };

            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Put, new Uri(URL_API + "/Usuarios/"));
            req.Headers.TryAddWithoutValidation("Authorization", token);
            req.Content = new StringContent(
                JsonConvert.SerializeObject(body),
                Encoding.UTF8, "application/json");
            var response = await new HttpClient().SendAsync(req);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Theory]
        [InlineData("teste")]
        public async void TestDeletarUsuario(string username)
        {
            token = await Token();
            HttpRequestMessage req2 = new HttpRequestMessage(HttpMethod.Get, new Uri(URL_API + "/Usuarios/"));
            req2.Headers.TryAddWithoutValidation("Authorization", token);
            var response = await new HttpClient().SendAsync(req2);
            Usuario usuario = JsonConvert
                .DeserializeObject<List<Usuario>>(response.Content.ReadAsStringAsync()?.Result)
                .FirstOrDefault(x => x.Username == username);
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Delete, new Uri(URL_API + "/Usuarios/" + usuario?.Id));
            req.Headers.TryAddWithoutValidation("Authorization", token);
            response = await new HttpClient().SendAsync(req);
            if(usuario == null)
                Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            else
                Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);
        }

        private async Task<string> Token()
        {
            //JSON PARA RESGATAR TOKEN
            var bodyToken = new
            {
                userid = "faustao",
                accesskey = "olocomeuolocomeuolocomeu"
            };
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, new Uri(URL_TOKEN))
            {
                Content = new StringContent(JsonConvert.SerializeObject(bodyToken), Encoding.UTF8, "application/json")
            };
            //FAZ REQUISIÇÃO
            var response = await new HttpClient().SendAsync(req);
            dynamic it = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);
            return  "Bearer " + it.accessToken;
        }
    }
}
