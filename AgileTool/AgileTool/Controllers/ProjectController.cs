using AgileTool.Models;
using AgileTool.Data;
using System;
using System.Collections.Generic;

namespace AgileTool.Controllers
{
    public class ProjectController
    {
        private DataService dataService = new DataService();

        public void CreateProject(string name, string description)
        {
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name cannot be empty!");
                return;
            }
            dataService.AddProject(name, description);
            Console.WriteLine("Project created successfully!");
        }

        public void ListProjects()
        {
            List<Project> projects = dataService.GetAllProjects();

            if (projects.Count == 0)
            {
                Console.WriteLine("No projects found!");
                return;
            }

            Console.WriteLine("=== All Projects ===");
            foreach (Project p in projects)
            {
                Console.WriteLine("─────────────────");
                Console.WriteLine("ID:          " + p.Id);
                Console.WriteLine("Name:        " + p.Name);
                Console.WriteLine("Description: " + p.Description);
            }
            Console.WriteLine("─────────────────");
        }

        public List<Project> GetAllProjects()
        {
            return dataService.GetAllProjects();
        }
    }
}