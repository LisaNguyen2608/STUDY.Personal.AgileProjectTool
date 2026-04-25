using AgileTool.Models;
using AgileTool.Data;
using System;
using System.Collections.Generic;

namespace AgileTool.Controllers
{
    public class TaskController
    {
        private DataService dataService = new DataService();

        public void AddTask(int userStoryId, string description, int priority, int difficulty)
        {
            if (string.IsNullOrEmpty(description)) return;
            dataService.AddTask(userStoryId, description, priority, difficulty, "General");
        }


        public void AssignPerson(int taskId, int personId)
        {
            try
            {
                dataService.AddPersonToTask(taskId, personId);
                Console.WriteLine($"Person ID {personId} successfully assigned to Task ID {taskId}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while assigning person: " + ex.Message);
            }
        }
        //Task 2
        public void AddTaskToUserStory(int taskId, int storyId)
        {
            dataService.AddExistingUserStoryToProject(taskId, storyId);
            Console.WriteLine("Task added to story!");
        }

        // TASK 5
        public void UnassignPerson(int taskId, int personId)
        {
            try
            {
                dataService.RemovePersonFromTask(taskId, personId);
                Console.WriteLine($"Person ID {personId} successfully removed from Task ID {taskId}.");
            }
            catch (Exception ex) { Console.WriteLine("An error occurred: " + ex.Message); }
        }

        // TASK 6
        public void UpdatePriority(int taskId, int newPriority)
        {
            try
            {
                dataService.UpdateTaskPriority(taskId, newPriority);
                Console.WriteLine($"Priority for Task ID {taskId} updated to {newPriority}.");
            }
            catch (Exception ex) { Console.WriteLine("An error occurred: " + ex.Message); }
        }

        public void ListTasks()
        {
            List<Task> tasks = dataService.GetAllTasks();

            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks found!");
                return;
            }

            Console.WriteLine("=== All Tasks ===");
            foreach (Task t in tasks)
            {
                Console.WriteLine("─────────────────");
                Console.WriteLine("ID:          " + t.Id);
                Console.WriteLine("Description: " + t.Description);
                Console.WriteLine("Priority:    " + t.Priority);
                Console.WriteLine("Difficulty:  " + t.Difficulty);
                Console.WriteLine("State:       " + t.GetStateName());
            }
            Console.WriteLine("─────────────────");
        }

        public List<Task> GetAllTasks()
        {
            return dataService.GetAllTasks();
        }
        public void MoveTaskState(int taskId, int newState)
        {
            Task task = dataService.GetTaskById(taskId);
            if (task == null)
            {
                Console.WriteLine("Task not found!");
                return;
            }

            UserStory story = dataService.GetUserStoryById(task.UserStoryId);
            if (story.State != 2)
            {
                Console.WriteLine("Task can only move when the user story is IN SPRINT.");
                return;
            }

            // Check allowed transitions
            if (Math.Abs(newState - task.State) != 1)
            {
                Console.WriteLine("Invalid state transition!");
                return;
            }

            // Dependency rule
            if (newState == 2) // moving to In Process
            {
                if (!dataService.AreDependencyTasksDone(story.Id))
                {
                    Console.WriteLine("Cannot move task to IN PROCESS because dependency tasks are not done.");
                    return;
                }
            }

            dataService.UpdateTaskState(taskId, newState);
            Console.WriteLine("Task state updated!");
        }
        //Produce Task Report
        public void ProduceTaskReport(int taskId)
        {
            // Get the task
            Task t = dataService.GetTaskById(taskId);
            if (t == null)
            {
                Console.WriteLine("Task not found!");
                return;
            }

            // Get the user story linked to this task
            UserStory s = dataService.GetUserStoryById(t.UserStoryId);

            // Get persons assigned to this task
            List<Person> persons = dataService.GetPersonByTask(taskId);

            Console.WriteLine("=== Task Report ===");
            Console.WriteLine("ID:            " + t.Id);
            Console.WriteLine("Description:   " + t.Description);
            Console.WriteLine("Priority:      " + t.Priority);
            Console.WriteLine("Difficulty:    " + t.Difficulty);
            Console.WriteLine("State:         " + t.State);
            Console.WriteLine("Category:      " + t.Category);
            Console.WriteLine("Planned Time:  " + t.PlannedTime);
            Console.WriteLine("Actual Time:   " + t.ActualTime);

            Console.WriteLine();
            Console.WriteLine("User Story ID: " + s.Id);
            Console.WriteLine("Story State:   " + s.State);
            Console.WriteLine("Story Desc:    " + s.Description);

            Console.WriteLine();
            Console.WriteLine("Assigned Persons:");
            if (persons.Count == 0)
                Console.WriteLine("  Nobody");
            else
                foreach (var p in persons)
                    Console.WriteLine("  " + p.Name + " (" + p.Role + ")");

            Console.WriteLine("---------------------------");
        }

    }
}