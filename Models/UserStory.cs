using System;
using System.Collections.Generic;
using System.Text;

namespace AgileProjectTool.Models
{
    public class UserStory
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public string Description { get; set; }

        public int State { get; set; }

        public int Priority { get; set; }
    }
}
