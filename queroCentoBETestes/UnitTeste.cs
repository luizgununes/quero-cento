using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using Xunit;
namespace queroCentoBETestes
{
    public class UnitTest
    {
        const string URL_API = "http://localhost/api/";
        const string URL_TOKEN = URL_API + "api/Loginapi/";
        
        string token;
        [Fact]
        //Esperado -> erro na autenticação
        public async void TestTokenDeAcessoIncorreto()
        { 
        HttpClient client = new HttpClient();
        var body = new
        {
            userid = "teste",
            accesskey = ""
        };
        var uri = new Uri(URL_TOKEN);
        var data = JsonConvert.SerializeObject(body);
        var content = new StringContent(data, Encoding.UTF8, "application/json");
        HttpResponseMessage response = null;
        response = await client.PostAsync(uri, content);
        Assert.Contains("Falha ao autenticar", response.Content.ReadAsStringAsync().Result.ToString());
        }
        [Fact]
        public async void TestTokenDeAcessoLoginCorreto()
        {
            HttpClient client = new HttpClient();
            var body = new
            {
                userid = "faustao",
                accesskey = "olocomeuolocomeuolocomeu"
            };
            var uri = new Uri(URL_TOKEN);
            var data = JsonConvert.SerializeObject(body);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;
            response = await client.PostAsync(uri, content);
            string json = response.Content.ReadAsStringAsync().Result;
            dynamic it = JsonConvert.DeserializeObject(json);
            token = "Bearer "+ it.accessToken;
            Assert.Contains("OK", it.message);
        }
        [Fact]
        public async void TestCriacaoUsuario()
        {
            HttpClient client = new HttpClient();
            var body1 = new
            {
                userid = "faustao",
                accesskey = "olocomeuolocomeuolocomeu"
            };
            var uri = new Uri(URL_TOKEN);
            var data = JsonConvert.SerializeObject(body1);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;
            response = await client.PostAsync(uri, content);
            string json = response.Content.ReadAsStringAsync().Result;
            dynamic it = JsonConvert.DeserializeObject(json);
            token = "Bearer " + it.accessToken;
            
             var body = new
            {
                username = "faustao",
                password = "olocomeuolocomeuolocomeu"
            };
             uri = new Uri(URL_API+"api/Usuarios/");
             data = JsonConvert.SerializeObject(body);
            
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Put,uri);
            req.Headers.TryAddWithoutValidation("Content-Type","application/json");
            req.Headers.TryAddWithoutValidation("Authorization", token);
            response = await client.SendAsync(req);
        }
    }
}
