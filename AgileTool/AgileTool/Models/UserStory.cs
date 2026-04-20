using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileTool.Models
{
    public class UserStory
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Description { get; set; }
        public int State { get; set; }     // 1=Backlog, 2=In Sprint, 3=Done
        public int Priority { get; set; }


        public UserStory(int id, int projectId, string description, int state, int priority)
        {
            Id = id;
            ProjectId = projectId;
            Description = description;
            State = state;
            Priority = priority;

        }

        public string GetStateName()
        {
            if (State == 1) return "Backlog";
            if (State == 2) return "In Sprint";
            if (State == 3) return "Done";

            return "Unknown";
        }

        public override string ToString()
        {
            return Description;
        }
    }
}
