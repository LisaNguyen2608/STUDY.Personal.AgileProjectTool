using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileTool.Models
{
    public class TaskAssignment
    {
        public int TaskId { get; set; }
        public int PersonId { get; set; }

        public TaskAssignment() { }

        public TaskAssignment(int taskId, int personId)
        {
            TaskId = taskId;
            PersonId = personId;
        }
    }
}