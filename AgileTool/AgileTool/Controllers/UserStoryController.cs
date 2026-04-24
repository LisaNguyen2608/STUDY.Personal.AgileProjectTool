using AgileTool.Models;
using AgileTool.Data;
using System;
using System.Collections.Generic;

namespace AgileTool.Controllers
{
    public class UserStoryController
    {
        // Connect to database through DataService
        private DataService dataService = new DataService();

        // ADD a new story to database
        public void AddStory(int projectId, string description, int priority)
        {
            if (string.IsNullOrEmpty(description))
            {
                Console.WriteLine("Description cannot be empty!");
                return;
            }

            dataService.AddUserStory(projectId, description, priority);
            Console.WriteLine("User story added successfully!");
        }

        // TASK 4: Delete the story and all its related tasks
        public void DeleteStory(int storyId)
        {
            try
            {
                //  // Triggers a cascade delete at the database level
                dataService.DeleteUserStoryCascade(storyId);
                Console.WriteLine($"User Story ID {storyId} its tasks were deleted.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during delete: " + ex.Message);
            }
        }

        // LIST all stories from database
        public void ListStories()
        {
            List<UserStory> stories = dataService.GetAllUserStories();

            if (stories.Count == 0)
            {
                Console.WriteLine("No stories found!");
                return;
            }

            Console.WriteLine("=== All User Stories ===");
            foreach (UserStory s in stories)
            {
                Console.WriteLine("─────────────────");
                Console.WriteLine("ID:          " + s.Id);
                Console.WriteLine("Description: " + s.Description);
                Console.WriteLine("Priority:    " + s.Priority);
                Console.WriteLine("State:       " + s.GetStateName());
            }
            Console.WriteLine("─────────────────");
        }

        public void AddExistingStoryToProject(int storyId, int projectId)
        {
            dataService.AddExistingUserStoryToProject(storyId, projectId);
            Console.WriteLine("Story has been added to project!");
        }


        public List<UserStory> GetAllStories()
        {
            return dataService.GetAllUserStories();
        }
        public void MoveUserStoryState(int storyId, int newState)
        {
            dataService.UpdateUserStoryState(storyId, newState);
            Console.WriteLine("User story state updated!");
        }


    }
}