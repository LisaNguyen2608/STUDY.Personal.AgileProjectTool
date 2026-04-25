using AgileProjectTool.Controllers;
using AgileProjectTool.Database;
using AgileProjectTool.Models;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        DataService dataService = new DataService();

        Console.WriteLine("=== PROJECT LIST ===");

        // TASK 7 
        UserStoryController controller = new UserStoryController();

        Console.WriteLine("=== TEST VALID CASE ===");
        controller.ChangeState(7, 2); // 1 → 2 (correct)

        Console.WriteLine("\n=== TEST VALID CASE 2 ===");
        controller.ChangeState(7, 1); // 2 → 1 (correct)

        Console.WriteLine("\n=== TEST INVALID CASE ===");
        controller.ChangeState(7, 3); // if 1 → 3 (incorrect)

        Console.ReadLine();
    }
}