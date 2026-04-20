using AgileTool.Models;
using AgileTool.Data;
using System;
using System.Collections.Generic;

namespace AgileTool.Controllers
{
    public class ProjectTeamController
    {
        private DataService dataService = new DataService();

        public void AddPersonToProject(int projectId, int personId)
        {
            dataService.AddPersonToProject(projectId, personId);
            Console.WriteLine("Person added to project!");
        }

        public void ListTeam(int projectId)
        {
            List<Person> team = dataService.GetPersonsByProject(projectId);

            if (team.Count == 0)
            {
                Console.WriteLine("No team members found!");
                return;
            }

            Console.WriteLine("=== Project Team ===");
            foreach (Person p in team)
            {
                Console.WriteLine("─────────────────");
                Console.WriteLine("ID:   " + p.Id);
                Console.WriteLine("Name: " + p.Name);
                Console.WriteLine("Role: " + p.Role);
            }
            Console.WriteLine("─────────────────");
        }

        public List<Person> GetTeamByProject(int projectId)
        {
            return dataService.GetPersonsByProject(projectId);
        }
    }
}