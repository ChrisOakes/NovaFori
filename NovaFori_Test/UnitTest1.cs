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
using NovaFori.Models;

namespace NovaFori_Test
{
    public class UnitTest1 : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _httpClient;
        public UnitTest1(WebApplicationFactory<Startup> factory)
        {
            _httpClient = factory.CreateDefaultClient();
            _httpClient.BaseAddress = new Uri("https://localhost:44324/api/");
        }

        public List<t_to_do_item> li_t_to_do_item { get; set; }

        [Fact]
        public async Task TestController()
        {
            //arrange
            //act
            var response = await _httpClient.GetAsync("ToDo/test");
            //assert

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetListOfItems()
        {
            //arrange
            //act
            var response = await _httpClient.GetAsync("ToDo/GetList");
            var content = response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<t_to_do_item>>(content.Result);
            //assert

            Assert.IsType<List<t_to_do_item>>(result);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Add_To_Do_List_Item()
        {
            //arrange
            string description = "Adding a new to do item";

            li_t_to_do_item = new List<t_to_do_item>();

            //act
            var response = await _httpClient.PostAsJsonAsync<List<t_to_do_item>>("ToDo/AddToDoItem/" + description, li_t_to_do_item);
            var content = response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<t_to_do_item>>(content.Result);
            //assert

            Assert.IsType<List<t_to_do_item>>(result);
            Assert.Equal(1, result.Count);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task Toggle_To_Do_List_Item(bool currentValue)
        {
            //arrange

            //We need a list of ToDos
            li_t_to_do_item = new List<t_to_do_item>();

            t_to_do_item t_to_do_item = new t_to_do_item();
            t_to_do_item.Complete = true;
            t_to_do_item.Created = DateTime.Now;
            t_to_do_item.Description = "Start the NovaFori code test";
            t_to_do_item.Updated = DateTime.Now;

            li_t_to_do_item.Add(t_to_do_item);

            t_to_do_item = new t_to_do_item();

            t_to_do_item.Complete = currentValue;
            t_to_do_item.Created = DateTime.Now;
            t_to_do_item.Description = "Create the required folders";
            t_to_do_item.Updated = DateTime.Now;

            li_t_to_do_item.Add(t_to_do_item);
            t_to_do_item = new t_to_do_item();

            t_to_do_item.Complete = false;
            t_to_do_item.Created = DateTime.Now;
            t_to_do_item.Description = "Connect to a local git repository";
            t_to_do_item.Updated = DateTime.Now;

            li_t_to_do_item.Add(t_to_do_item);


            //act

            var response = await _httpClient.PostAsJsonAsync<List<t_to_do_item>>("ToDo/ToggleToDoItem/1", li_t_to_do_item);
            var content = response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<t_to_do_item>>(content.Result);
            //assert

            Assert.IsType<List<t_to_do_item>>(result);

            if (currentValue)
            {
                Assert.False(result[1].Complete);
            } else
            {
                Assert.True(result[1].Complete);

            }
        }
    }
}
