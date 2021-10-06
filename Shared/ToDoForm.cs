﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Shared
{
    public class ToDoForm
    {
        public int Id { get; set; }
        [StringLength(20, ErrorMessage = "Short description is too long. Use field description instead"), Required]
        public string ShortDescription { get; set; }
        [Required, StringLength(200, MinimumLength = 10)]
        public string Description { get; set; }
        [Range(1, 4)]
        public int Priority { get; set; }
        public DateTime DueDate { get; set; }
        public string Category { get; set; }
        public bool IfDone { get; set; }

    }
}

