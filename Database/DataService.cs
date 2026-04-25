using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AgileProjectTool.Models;

namespace AgileProjectTool.Database
{
    public class DataService
    {
        private string connectionString =
            "Server=(localdb)\\MSSQLLocalDB;Database=AgileProjectToolDB;Trusted_Connection=True;";

        // Get UserStories
        public List<UserStory> GetAllUserStories()
        {
            List<UserStory> list = new List<UserStory>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM USER_STORY";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    
                    UserStory story = new UserStory();

                    story.Id = Convert.ToInt32(reader["Id"]);
                    story.ProjectId = Convert.ToInt32(reader["ProjectId"]);
                    story.Description = reader["Description"].ToString();
                    story.State = Convert.ToInt32(reader["State"]);
                    story.Priority = Convert.ToInt32(reader["Priority"]);

                    list.Add(story);
                }

                reader.Close();
            }

            return list;
        }

        // Update state
        public void UpdateUserStoryState(int storyId, int newState)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "UPDATE USER_STORY SET State = @State WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@State", newState);
                cmd.Parameters.AddWithValue("@Id", storyId);

                cmd.ExecuteNonQuery();
            }
        }
    }
}