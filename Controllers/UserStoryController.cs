using System;
using System.Data.SqlClient;
using AgileProjectTool;

namespace AgileProjectTool.Controllers
{
    public class UserStoryController
    {
        DatabaseHelper db = new DatabaseHelper();

        public void ChangeState(int storyId, int newState)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                // 1. Lấy state hiện tại
                string query = "SELECT State FROM USER_STORY WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", storyId);

                object result = cmd.ExecuteScalar();

                if (result == null)
                {
                    Console.WriteLine("UserStory not found!");
                    return;
                }

                int currentState = Convert.ToInt32(result);

                Console.WriteLine("Current state: " + currentState);
                Console.WriteLine("New state: " + newState);

                // 2. CHECK RULE (QUAN TRỌNG NHẤT)
                bool isValid =
                    (currentState == 1 && newState == 2) || // Backlog → In Sprint
                    (currentState == 2 && newState == 3) || // In Sprint → Done
                    (currentState == 2 && newState == 1);   // In Sprint → Backlog

                if (!isValid)
                {
                    Console.WriteLine("❌ Invalid state transition!");
                    return;
                }

                // 3. UPDATE DATABASE
                db.UpdateUserStoryState(storyId, newState);

                Console.WriteLine("✅ State updated successfully!");
            }
        }
    }
}