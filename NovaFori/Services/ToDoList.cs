using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NovaFori.Interfaces;
using NovaFori.Models;

namespace NovaFori.Services
{
    public class ToDoList : IToDoList
    {
        private ILogger<ToDoList> _logger;

        public ToDoList(ILogger<ToDoList> logger)
        {
            _logger = logger;
        }
        public async Task<List<t_to_do_item>> AddToDoItem(string Description, List<t_to_do_item> ExistinList)
        {
            try
            {
                List<t_to_do_item> li_t_to_do_item = new List<t_to_do_item>();

                return li_t_to_do_item;
            }
            catch (Exception er)
            {

                _logger.LogError(er, "Error encountered");
                throw;
            }
        }

        public async Task<List<t_to_do_item>> ToggleToDoItem(int ItemID, List<t_to_do_item> ExistinList)
        {
            try
            {
                List<t_to_do_item> li_t_to_do_item = new List<t_to_do_item>();

                return li_t_to_do_item;
            }
            catch (Exception er)
            {
                _logger.LogError(er, "Error encountered");
                throw;
            }
        }
    }
}
