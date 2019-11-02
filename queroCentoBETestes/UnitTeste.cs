using Newtonsoft.Json;
using queroCentoBE.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;
namespace queroCentoBETestes
{
    public class UnitTest
    {
#if DEBUG
        const string URL_API = "http://localhost/api";
#else
        const string URL_API = "http://localhost:8080/api";
#endif
        const string URL_TOKEN = URL_API + "/LoginApi/";
        string token;
#region TestTokenDeAcessoIncorreto
        [Fact]
        //Esperado -> erro na autenticação
        public async void TestTokenDeAcessoIncorreto()
        {
            //JSON PARA RESGATAR TOKEN
            var bodyToken = new
            {
                userid = "faustao",
                accesskey = "a"
            };
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, new Uri(URL_TOKEN))
            {
                Content = new StringContent(JsonConvert.SerializeObject(bodyToken), Encoding.UTF8, "application/json")
            };
            //FAZ REQUISIÇÃO
            HttpResponseMessage response = await new HttpClient().SendAsync(req);
            Assert.Contains("Falha ao autenticar", response.Content.ReadAsStringAsync().Result);
        }
#endregion
#region TestTokenDeAcessoLoginCorreto
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
#endregion
#region TestCriacaoUsuario
        [Fact]
        public async void TestCriacaoUsuario()
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
            token = "Bearer " + it.accessToken;
            var body = new
            {
                username = "TesteCriacaoUsuario",
                password = "teste"
            };
            req = new HttpRequestMessage(HttpMethod.Put, new Uri(URL_API + "/Usuarios/"));
            req.Headers.TryAddWithoutValidation("Authorization", token);
            req.Content = new StringContent(
                JsonConvert.SerializeObject(body),
                Encoding.UTF8, "application/json");
            response = await new HttpClient().SendAsync(req);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
#endregion
#region TestDeletarUsuario
        [Fact]
        public async void TestDeletarUsuario()
        {
            //JSON PARA RESGATAR TOKEN
            var bodyToken = new
            {
                userid = "faustao",
                accesskey = "olocomeuolocomeuolocomeu"
            };
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, new Uri(URL_TOKEN));
            req.Content = new StringContent(
                JsonConvert.SerializeObject(bodyToken),
                Encoding.UTF8, "application/json");
            //FAZ REQUISIÇÃO
            var response = await new HttpClient().SendAsync(req);
            dynamic it = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);
            token = "Bearer " + it.accessToken;
            HttpRequestMessage req2 = new HttpRequestMessage(HttpMethod.Get, new Uri(URL_API + "/Usuarios/"));
            req2.Headers.TryAddWithoutValidation("Authorization", token);
            response = await new HttpClient().SendAsync(req2);
            Usuario usuario = JsonConvert
                .DeserializeObject<List<Usuario>>(response.Content.ReadAsStringAsync().Result)
                .FirstOrDefault(x => x.Username == "TesteCriacaoUsuario");
            req = new HttpRequestMessage(HttpMethod.Delete, new Uri(URL_API + "/Usuarios/" + usuario.Id));
            req.Headers.TryAddWithoutValidation("Authorization", token);
            response = await new HttpClient().SendAsync(req);
            Assert.Equal(HttpStatusCode.Accepted, response.StatusCode);
        }
#endregion
    }
}
