using AgileTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AgileTool.Controllers
{
    internal class PersonController
    {
        private List<Person> persons = new List<Person>();

        public void AddPerson(string name, string role)
        {
            Person p = new Person(persons.Count + 1, name, role);
            persons.Add(p);
            Console.WriteLine("Person added successfully.");
        }

        public void ListPersons()
        {
            if (persons.Count == 0)
            {
                Console.WriteLine("No persons found.");
                return;
            }
            foreach (var p in persons)
            {
                Console.WriteLine($"{p.Id}. {p.Name} - {p.Role}");
            }
        }
    }
}
