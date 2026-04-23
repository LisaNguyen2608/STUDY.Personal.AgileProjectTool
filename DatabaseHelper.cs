using System;
using System.Data.SqlClient;

public class DatabaseHelper
{
    private string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=AgileProjectToolDB;Trusted_Connection=True;";

    public SqlConnection GetConnection()
    {
        return new SqlConnection(connectionString);
    }
    public void UpdateUserStoryState(int storyId, int newState)
    {
        using (SqlConnection conn = GetConnection())
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