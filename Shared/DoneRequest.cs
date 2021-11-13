using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Shared
{
    public class DoneRequest
    {
        public int TaskId { get; set; }
        public bool Done { get; set; }
    }
}
