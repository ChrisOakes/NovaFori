using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovaFori.Interfaces;
using NovaFori.Models;

namespace NovaFori.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private IToDoList _toDoList;

        public ToDoController(IToDoList toDoList)
        {
            _toDoList = toDoList;
        }

        [HttpPost]
        [Route("AddToDoItem/{Description}")]
        public async Task<IActionResult> AddToDoItem(string Description, [FromBody] List<t_to_do_item> li_t_to_do_item)
        {
            try
            {
                li_t_to_do_item = await _toDoList.AddToDoItem(Description, li_t_to_do_item);

                return Ok(li_t_to_do_item);
            }
            catch (Exception er)
            {

                return BadRequest(er);
            }
        }

        [HttpPost]
        [Route("ToggleToDoItem/{ToDoID}")]
        public async Task<IActionResult> ToggleToDoItem(int ToDoID, [FromBody] List<t_to_do_item> li_t_to_do_item)
        {
            try
            {
                li_t_to_do_item = await _toDoList.ToggleToDoItem(ToDoID, li_t_to_do_item);

                return Ok(li_t_to_do_item);
            }
            catch (Exception er)
            {

                return BadRequest(er);
            }
        }
    }
}
