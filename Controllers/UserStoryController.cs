using System;
using System.Collections.Generic;
using AgileProjectTool.Database;
using AgileProjectTool.Models;

namespace AgileProjectTool.Controllers
{
    public class UserStoryController
    {
        DataService dataService = new DataService();

        // TASK 7: Change State
        public void ChangeState(int storyId, int newState)
        {
            // 1. Get all UserStories
            List<UserStory> stories = dataService.GetAllUserStories();

            // 2. Find stories by Id
            UserStory story = stories.Find(s => s.Id == storyId);

            if (story == null)
            {
                Console.WriteLine("UserStory not found!");
                return;
            }

            int currentState = story.State;

            Console.WriteLine("Current state: " + currentState);
            Console.WriteLine("New state: " + newState);

            // 3. VALIDATION (feasible action)
            bool isValid =
                (currentState == 1 && newState == 2) || // Backlog → In Sprint
                (currentState == 2 && newState == 3) || // In Sprint → Done
                (currentState == 2 && newState == 1);   // In Sprint → Backlog

            if (!isValid)
            {
                Console.WriteLine("Invalid state transition!");
                return;
            }

            // 4. Update database
            dataService.UpdateUserStoryState(storyId, newState);

            Console.WriteLine("State updated successfully!");
        }
    }
}