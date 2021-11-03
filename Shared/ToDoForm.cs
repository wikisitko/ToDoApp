using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Shared
{
    public class ToDoForm
    {
        [StringLength(20, ErrorMessage = "Short description is too long. Use field description instead"), Required]
        public string ShortDescription { get; set; }
        [Required, StringLength(200, MinimumLength = 10)]
        public string Description { get; set; }
        [Range(1, 4)]
        public int Priority { get; set; }
        [FromNow]
        public DateTime DueDate { get; set; } = DateTime.Now;
        public TaskCategory Category { get; set; }
        public bool IfDone { get; set; }

    }
}

