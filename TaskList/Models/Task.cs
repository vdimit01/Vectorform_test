using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskList.Models
{
    public class myTask
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int taskId { get; set; }
        public string taskDescription { get; set; }
        public string Status { get; set; }

    }
}
