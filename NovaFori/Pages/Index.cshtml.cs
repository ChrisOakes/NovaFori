using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovaFori.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace NovaFori.Pages
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public List<t_to_do_item> li_t_to_do_item { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAddNewListItem(string description, List<t_to_do_item> existing_list)
        {
            try
            {
                using (HttpClient myClient = new HttpClient())
                {
                    myClient.BaseAddress = new Uri("https://localhost:44324/api/");
                    var response = await myClient.PostAsJsonAsync<List<t_to_do_item>>("ToDo/AddToDoItem/" + description, existing_list);
                    var content = response.Content.ReadAsStringAsync();
                    li_t_to_do_item = JsonConvert.DeserializeObject<List<t_to_do_item>>(content.Result);

                }

                return new JsonResult(li_t_to_do_item);
            }
            catch (Exception er)
            {

                throw;
            }
        }
        public async Task<IActionResult> OnPostToggleListItem(int itemIndex, List<t_to_do_item> existing_list)
        {
            try
            {
                using (HttpClient myClient = new HttpClient())
                {
                    myClient.BaseAddress = new Uri("https://localhost:44324/api/");
                    var response = await myClient.PostAsJsonAsync<List<t_to_do_item>>("ToDo/ToggleToDoItem/"+itemIndex, existing_list);
                    var content = response.Content.ReadAsStringAsync();
                    li_t_to_do_item = JsonConvert.DeserializeObject<List<t_to_do_item>>(content.Result);

                }

                return new JsonResult(li_t_to_do_item);
            }
            catch (Exception er)
            {

                throw;
            }
        }
    }
}
