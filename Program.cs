using AgileProjectTool.Controllers;
using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        DatabaseHelper db = new DatabaseHelper();

        using (SqlConnection conn = db.GetConnection())
        {
            conn.Open();

            string query = "SELECT * FROM Project";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("Id: " + reader["Id"]);
                Console.WriteLine("Name: " + reader["Name"]);
                Console.WriteLine("Description: " + reader["Description"]);
                Console.WriteLine("----------------------");
            }
        }

        UserStoryController controller = new UserStoryController();
        controller.ChangeState(7, 3);

        Console.ReadLine();

    }
}