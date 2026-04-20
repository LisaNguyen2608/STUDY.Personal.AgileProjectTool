using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileTool.Models
{
    public class Task
    {
        public int Id { get; set; }
        public int UserStoryId { get; set; }
        public string Description { get; set; }
        public int State { get; set; }     // 1=To Do, 2=In Progress, 3=Done
        public int Priority { get; set; }
        public int Difficulty { get; set; }
        public DateTime? PlannedStartDate { get; set; }
        public DateTime? PlannedEndDate { get; set; }
        public DateTime? ActualStartDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
        public decimal PlannedTime { get; set; }
        public decimal ActualTime { get; set; }
        public string Category { get; set; }

  

    public Task() { }

        public Task(int id, int userstoryId, string description, int state, int prioroty, int difficulty, string category)
        {
            Id = id;
            UserStoryId = userstoryId;
            Description = description;
            State = state;
            Priority = prioroty;
            Difficulty = difficulty;
            Category = category;

        }

        public string GetStateName()
        {
            if (State == 1) return "To Be Done";
            if (State == 2) return "In Process";
            if (State == 3) return "Done";
            return "Unknown";
        }

        public override string ToString()
        {
            return Description;
        } 
    }
}
