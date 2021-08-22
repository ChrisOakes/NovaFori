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
        public async Task<List<t_to_do_item>> AddToDoItem(string Description, List<t_to_do_item> ExistingList)
        {
            try
            {
                t_to_do_item t_to_do_item = new t_to_do_item();
                t_to_do_item.Complete = false;
                t_to_do_item.Created = DateTime.Now;
                t_to_do_item.Description = Description;
                t_to_do_item.Updated = DateTime.Now;

                ExistingList.Add(t_to_do_item);

                return ExistingList;
            }
            catch (Exception er)
            {

                _logger.LogError(er, "Error encountered");
                throw;
            }
        }

        public async Task<List<t_to_do_item>> GetListOfItems()
        {
            try
            {
                List<t_to_do_item> li_t_to_do_items = new List<t_to_do_item>();

                return li_t_to_do_items;
            }
            catch (Exception er)
            {
                _logger.LogError(er, "Error encountered");
                throw;
            }
        }

        public async Task<List<t_to_do_item>> ToggleToDoItem(int ItemIndex, List<t_to_do_item> ExistingList)
        {
            try
            {

                ExistingList[ItemIndex].Complete = !ExistingList[ItemIndex].Complete;
                ExistingList[ItemIndex].Updated = DateTime.Now;

                return ExistingList;
            }
            catch (Exception er)
            {
                _logger.LogError(er, "Error encountered");
                throw;
            }
        }
    }
}
