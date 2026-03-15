using System;
using System.Collections.Generic;
using System.Text;

namespace AgileProjectTool.Models
{
    public class StoryDependency
    {
        public int StoryId { get; set; }

        public int DependsOnStoryId { get; set; }
    }
}