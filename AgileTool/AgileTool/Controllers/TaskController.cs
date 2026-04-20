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
    }
}