using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileTool.Models
{
    public class ProjectTeam
    {
        public int ProjectId { get; set; }
        public int PersonId { get; set; }
    

    public ProjectTeam() { }

        public ProjectTeam(int projectId, int personId)
        {
            ProjectId = projectId;
            PersonId = personId;
        } 
    }
}
