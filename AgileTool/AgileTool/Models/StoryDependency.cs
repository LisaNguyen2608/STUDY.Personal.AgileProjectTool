using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileTool.Models
{
    public class StoryDependency
    {
        public int StoryId { get; set; }
        public int DependsOnStoryId { get; set; }

        public StoryDependency() { }

        public StoryDependency(int storyId, int dependsOnStoryId)
        {
            StoryId = storyId;
            DependsOnStoryId = dependsOnStoryId;
        }
    }
}