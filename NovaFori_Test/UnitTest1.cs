using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using NovaFori;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Xunit;
namespace NovaFori_Test
{
    public class UnitTest1 : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _httpClient;
        public UnitTest1(WebApplicationFactory<Startup> factory)
        {
            _httpClient = factory.CreateDefaultClient();
            _httpClient.BaseAddress = new Uri("https://localhost:5008/api/");
        }

        [Fact]
        public void Test1()
        {

        }
    }
}
