using System;
using System.Collections.Generic;
using System.Text;

namespace AgileProjectTool.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        public int UserStoryId { get; set; }

        public string Description { get; set; }

        public int State { get; set; }

        public int PlannedHours { get; set; }

        public int ActualHours { get; set; }
    }
}