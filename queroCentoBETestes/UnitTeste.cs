using Microsoft.Exchange.WebServices.Data;
using Newtonsoft.Json;
using queroCentoBE.Controllers;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace queroCentoBETestes
{
    public class UnitTest1
    {
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
        string url = "http://localhost/api/api/LoginApi/";
        var uri = new Uri(url);
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
            string url = "http://localhost/api/api/LoginApi/";
            var uri = new Uri(url);
            var data = JsonConvert.SerializeObject(body);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;
            response = await client.PostAsync(uri, content);
            Assert.Contains("OK", response.Content.ReadAsStringAsync().Result.ToString());
        }
    }
}
