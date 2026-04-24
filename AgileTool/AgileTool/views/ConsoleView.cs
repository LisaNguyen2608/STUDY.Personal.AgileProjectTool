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

        public void Run()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("==============================");
                Console.WriteLine("     AGILE PROJECT TOOL       ");
                Console.WriteLine("==============================");
                Console.WriteLine("1. Project Menu");
                Console.WriteLine("2. Person Menu");
                Console.WriteLine("3. User Story Menu");
                Console.WriteLine("4. Task Menu");
                Console.WriteLine("5. Team Menu");
                Console.WriteLine("0. Exit");
                Console.WriteLine("==============================");
                Console.Write("Choose: ");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid! Please enter a number!");
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {
                    case 1: ShowMenu(); break;
                    case 2: PersonMenu(); break;
                    case 3: UserStoryMenu(); break;
                    case 4: TaskMenu(); break;
                    case 5: TeamMenu(); break;
                    case 0: running = false; break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }

                if (running)
                {
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
            Console.WriteLine("Goodbye! 👋");
        }

        public void ShowMenu()
        {
            Console.WriteLine("=== Project Menu ===");
            Console.WriteLine("1. Create Project");
            Console.WriteLine("2. List Projects");
            Console.WriteLine("3. Add User Story to Project"); // TASK 1
            Console.WriteLine("4. Back");
            Console.Write("Choose: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice)) return;

            if (choice == 1)
            {
                Console.Write("Project name: ");
                string name = Console.ReadLine();
                Console.Write("Description: ");
                string desc = Console.ReadLine();
                projectController.CreateProject(name, desc);
            }
            else if (choice == 2)
            {
                projectController.ListProjects();
            }
            else if (choice == 3) // TASK 1
            {
                projectController.ListProjects();
                Console.Write("Select Project ID: ");
                int pid = int.Parse(Console.ReadLine());

                userStoryController.ListStories();
                Console.Write("Select Story ID: ");
                int sid = int.Parse(Console.ReadLine());
                
                userStoryController.AddExistingStoryToProject(sid, pid);
            }
        }

        public void PersonMenu()
        {
            Console.WriteLine("=== Person Menu ===");
            Console.WriteLine("1. Add Person");
            Console.WriteLine("2. List Persons");
            Console.WriteLine("3. Back");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice)) return;

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
            Console.WriteLine("3. Add Existing Task");
            Console.WriteLine("4. Delete Story"); // TASK 4
            Console.WriteLine("5. Back");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice)) return;

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
            else if (choice == 3)
            {
                userStoryController.ListStories();
                Console.Write("Select Story ID: ");
                int sid = int.Parse(Console.ReadLine());

                taskController.ListTasks();
                Console.Write("Select Task ID: ");
                int tid = int.Parse(Console.ReadLine());

                taskController.AddTaskToUserStory(tid, sid);
            }

            else if (choice == 4) // TASK 4
            {
                Console.Write("Enter Story ID to Delete (Warning: Cascade Delete): ");
                int sid = int.Parse(Console.ReadLine());
                userStoryController.DeleteStory(sid);
            }
        }

        public void TaskMenu()
        {
            Console.WriteLine("=== Task Menu ===");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. List Tasks");
            Console.WriteLine("3. Assign Person to Task");
            Console.WriteLine("4. Remove Person from Task"); // TASK 5 
            Console.WriteLine("5. Update Task Priority");    // TASK 6 
            Console.WriteLine("6. Produce Task Report");          // TASK 9
            Console.WriteLine("7. Back");
            Console.Write("Choose: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice)) return;

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
            else if (choice == 3)
            {
                Console.Write("Enter Task ID: ");
                int tid = int.Parse(Console.ReadLine());
                Console.Write("Enter Person ID to assign: ");
                int pid = int.Parse(Console.ReadLine());
                taskController.AssignPerson(tid, pid);
            }
            else if (choice == 4) // TASK 5
            {
                Console.Write("Enter Task ID: ");
                int tid = int.Parse(Console.ReadLine());
                Console.Write("Enter Person ID to remove: ");
                int pid = int.Parse(Console.ReadLine());
                taskController.UnassignPerson(tid, pid);
            }
            else if (choice == 5) // TASK 6
            {
                Console.Write("Enter Task ID: ");
                int tid = int.Parse(Console.ReadLine());
                Console.Write("Enter New Priority (1-5): ");
                int prio = int.Parse(Console.ReadLine());
                taskController.UpdatePriority(tid, prio);
            }
            else if (choice == 6) // TASK 9
            {
                taskController.ProduceReport();
            }
        }

        public void TeamMenu()
        {
            Console.WriteLine("=== Team Menu ===");
            Console.WriteLine("1. Add Person to Project");
            Console.WriteLine("2. View Team");
            Console.WriteLine("3. Back");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice)) return;

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