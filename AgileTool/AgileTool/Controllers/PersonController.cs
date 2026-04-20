using AgileTool.Models;
using AgileTool.Data;
using System;
using System.Collections.Generic;

namespace AgileTool.Controllers
{
    public class PersonController
    {
        private DataService dataService = new DataService();

        public void AddPerson(string name, string role)
        {
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name cannot be empty!");
                return;
            }
            dataService.AddPerson(name, role);
            Console.WriteLine(" Person added successfully!");
        }

        public void ListPersons()
        {
            List<Person> persons = dataService.GetAllPersons();

            if (persons.Count == 0)
            {
                Console.WriteLine("No persons found!");
                return;
            }

            Console.WriteLine("=== All Persons ===");
            foreach (Person p in persons)
            {
                Console.WriteLine("─────────────────");
                Console.WriteLine("ID:   " + p.Id);
                Console.WriteLine("Name: " + p.Name);
                Console.WriteLine("Role: " + p.Role);
            }
            Console.WriteLine("─────────────────");
        }

        public List<Person> GetAllPersons()
        {
            return dataService.GetAllPersons();
        }
    }
}