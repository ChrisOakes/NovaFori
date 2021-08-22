using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NovaFori.Models
{
    public class t_to_do_item
    {
        [Required(ErrorMessage = "You are required to enter a To Do description")]
        public string Description { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; } = DateTime.Now;
        public bool Complete { get; set; } = false;
    }
}
