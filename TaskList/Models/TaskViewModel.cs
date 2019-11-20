using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskList.Models
{
    public class TaskViewModel
    {
        public int taskId { get; set; }
        public string taskDescription { get; set; }
        public string Status { get; set; }
    }

    public class TaskRequest
    {
        public string taskDescription { get; set; }
        public string Status { get; set; }
    }
}
