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
        private ProjectController projectController = new ProjectController();
        private PersonController personController = new PersonController();
        private UserStoryController userStoryController = new UserStoryController();
        private TaskController taskController = new TaskController();
        private ProjectTeamController teamController = new ProjectTeamController();
        public void ShowMenu()
        {
            Console.WriteLine("1. Create Project");
            Console.Write("Choose: ");
            int choice;
            string input = Console.ReadLine();
            if (!int.TryParse(input, out choice))
            {
                Console.WriteLine("Please enter a valid number!");
                return;
            }

            if (choice == 1)
            {
                Console.Write("Project name: ");
                string name = Console.ReadLine();

                Console.Write("Description: ");
                string desc = Console.ReadLine();

                projectController.CreateProject(name, desc);
            }
        }
   

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

        public void UserStoryMenu()
        {
            Console.WriteLine("=== User Story Menu ===");
            Console.WriteLine("1. Add Story");
            Console.WriteLine("2. List Stories");
            Console.WriteLine("3. Back");

            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.Write("Project ID: ");
                int pid = int.Parse(Console.ReadLine());

                Console.Write("Description: ");
                string desc = Console.ReadLine();

                Console.Write("Priority: ");
                int pr = int.Parse(Console.ReadLine());

                userStoryController.AddStory(pid, desc, pr);
            }
            else if (choice == 2)
            {
                userStoryController.ListStories();
            }
        }

        public void TaskMenu()
        {
            Console.WriteLine("=== Task Menu ===");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. List Tasks");
            Console.WriteLine("3. Back");

            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.Write("Story ID: ");
                int sid = int.Parse(Console.ReadLine());

                Console.Write("Description: ");
                string desc = Console.ReadLine();

                Console.Write("Priority: ");
                int pr = int.Parse(Console.ReadLine());

                Console.Write("Difficulty: ");
                int diff = int.Parse(Console.ReadLine());

                taskController.AddTask(sid, desc, pr, diff);
            }
            else if (choice == 2)
            {
                taskController.ListTasks();
            }
        }


        public void TeamMenu()
        {
            Console.WriteLine("=== Team Menu ===");
            Console.WriteLine("1. Add Person to Project");
            Console.WriteLine("2. View Team");
            Console.WriteLine("3. Back");

            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.Write("Project ID: ");
                int pid = int.Parse(Console.ReadLine());

                Console.Write("Person ID: ");
                int per = int.Parse(Console.ReadLine());

                teamController.AddPersonToProject(pid, per);
            }
            else if (choice == 2)
            {
                Console.Write("Project ID: ");
                int pid = int.Parse(Console.ReadLine());

                teamController.ListTeam(pid);
            }
        }


    }
}
