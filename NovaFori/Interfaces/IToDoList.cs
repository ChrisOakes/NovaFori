using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovaFori.Models;

namespace NovaFori.Interfaces
{
    public interface IToDoList
    {
        public Task<List<t_to_do_item>> AddToDoItem(string Description, List<t_to_do_item> ExistinList);
        public Task<List<t_to_do_item>> ToggleToDoItem(int ItemID, List<t_to_do_item> ExistinList);

    }
}
