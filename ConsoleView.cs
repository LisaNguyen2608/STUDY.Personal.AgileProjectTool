using AgileTool.Controllers;
using AgileTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileTool.views
{
    internal class ConsoleView
    {
        
        private PersonController personController = new PersonController();
        public void PersonMenu()
        {
            Console.WriteLine("=== Person Menu ===");
            Console.WriteLine("1. Add Person");
            Console.WriteLine("2. List Persons");
            Console.WriteLine("3. Back");

            
            
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.Write("Enter name: ");
                string name = Console.ReadLine();

                Console.Write("Enter role: ");
                string role = Console.ReadLine();

                personController.AddPerson(name, role);
            }
            else if (choice == 2)
            {
                personController.ListPersons();
            }
        }
    }
}
