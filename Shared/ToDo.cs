using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Shared
{
    public enum TaskCategory { Praca, Dom, Nauka, Inne }
    public class ToDo
    {
        public int Id { get; set; }
        [StringLength(40, ErrorMessage = "Tytuł jest zbyt długi."), Required]
        public string ShortDescription { get; set; }
        [Required, StringLength(200, MinimumLength = 10)]
        public string Description { get; set; }
        [Range(1, 4)]
        public int Priority { get; set; }
        public DateTime DueDate { get; set; }
        public TaskCategory Category { get; set; } = TaskCategory.Inne;
        public bool IfDone { get; set; }
        public User User { get; set; }

    }
}
