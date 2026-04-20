using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileTool.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Constructor
        public Project(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
