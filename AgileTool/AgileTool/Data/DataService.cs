using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AgileTool.Models;

namespace AgileTool.Data
{
    class DataService
    {
        private SqlConnection myConnection;
        public DataService()
        {
            string connstr = @"Server=(localdb)\MSSQLLocalDB;
                                Database=AgileTool;
                                Trusted_Connection=True;";
            myConnection = new SqlConnection(connstr);
            myConnection.Open();
        }

        // PROJECT METHODS
        public List<Project> GetAllProjects()
        {
            List<Project> projectList = new List<Project>();
            SqlCommand myCommand = new SqlCommand("SELECT Id, Name, Description FROM PROJECT", myConnection);
            SqlDataReader myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                projectList.Add(new Project(
                    Convert.ToInt32(myReader["Id"]),
                    myReader["Name"].ToString(),
                    myReader["Description"].ToString()
                ));
            }
            myReader.Close();
            return projectList;
        }

        public void AddProject(string name, string description)
        {
            SqlCommand myCommand = new SqlCommand("INSERT INTO PROJECT (Name, Description) VALUES (@Name, @Description)", myConnection);
            myCommand.Parameters.AddWithValue("@Name", name);
            myCommand.Parameters.AddWithValue("@Description", description);
            myCommand.ExecuteNonQuery();
        }

        public void AddExistingUserStoryToProject(int storyId, int projectId) //Task 1
        {
            SqlCommand myCommand = new SqlCommand("UPDATE USER_STORY SET ProjectId = @ProjectId WHERE Id = @StoryId", myConnection);
            myCommand.Parameters.AddWithValue("@ProjectId", projectId);
            myCommand.Parameters.AddWithValue("@StoryId", storyId);
            myCommand.ExecuteNonQuery();
        }



        // USER STORY METHODS

        public List<UserStory> GetAllUserStories()
        {
            List<UserStory> storyList = new List<UserStory>();
            SqlCommand myCommand = new SqlCommand("SELECT Id, ProjectId, Description, State, Priority FROM USER_STORY", myConnection);
            SqlDataReader myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                storyList.Add(new UserStory(
                    Convert.ToInt32(myReader["Id"]),
                    Convert.ToInt32(myReader["ProjectId"]),
                    myReader["Description"].ToString(),
                    Convert.ToInt32(myReader["State"]),
                    Convert.ToInt32(myReader["Priority"])
                ));
            }
            myReader.Close();
            return storyList;
        }

        public void AddUserStory(int projectId, string description, int priority)
        {
            SqlCommand myCommand = new SqlCommand("INSERT INTO USER_STORY (ProjectId, Description, State, Priority) VALUES (@ProjectId, @Description, 1, @Priority)", myConnection);
            myCommand.Parameters.AddWithValue("@ProjectId", projectId);
            myCommand.Parameters.AddWithValue("@Description", description);
            myCommand.Parameters.AddWithValue("@Priority", priority);
            myCommand.ExecuteNonQuery();
        }

        public void DeleteUserStoryCascade(int storyId)
        {
            using (SqlTransaction transaction = myConnection.BeginTransaction())
            {
                try
                {
                    SqlCommand cmd1 = new SqlCommand("DELETE FROM TASK_ASSIGNMENT WHERE TaskId IN (SELECT Id FROM TASK WHERE UserStoryId = @StoryId)", myConnection, transaction);
                    cmd1.Parameters.AddWithValue("@StoryId", storyId);
                    cmd1.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand("DELETE FROM TASK WHERE UserStoryId = @StoryId", myConnection, transaction);
                    cmd2.Parameters.AddWithValue("@StoryId", storyId);
                    cmd2.ExecuteNonQuery();

                    SqlCommand cmd3 = new SqlCommand("DELETE FROM USER_STORY WHERE Id = @StoryId", myConnection, transaction);
                    cmd3.Parameters.AddWithValue("@StoryId", storyId);
                    cmd3.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (Exception) { transaction.Rollback(); throw; }
            }

        }
        // Update story state
        public void UpdateStoryState(int storyId, int newState)
        {
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = myConnection;
            myCommand.CommandText = "UPDATE USER_STORY SET State = @State " +
                                    "WHERE Id = @Id";
            myCommand.Parameters.AddWithValue("@State", newState);
            myCommand.Parameters.AddWithValue("@Id", storyId);
            myCommand.CommandType = CommandType.Text;
            myCommand.ExecuteNonQuery();
        }
        // Get ONE user story by Id
        public UserStory GetUserStoryById(int storyId)
        {
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = myConnection;
            myCommand.CommandText = "SELECT Id, ProjectId, Description, " +
                                    "State, Priority FROM USER_STORY " +
                                    "WHERE Id = @Id";
            myCommand.Parameters.AddWithValue("@Id", storyId);
            myCommand.CommandType = CommandType.Text;

            SqlDataReader myReader = myCommand.ExecuteReader();
            UserStory story = null;
            if (myReader.Read())
            {
                story = new UserStory(
                    Convert.ToInt32(myReader["Id"]),
                    Convert.ToInt32(myReader["ProjectId"]),
                    myReader["Description"].ToString(),
                    Convert.ToInt32(myReader["State"]),
                    Convert.ToInt32(myReader["Priority"])
                );
            }
            myReader.Close();
            return story;
        }

        // Get all user stories that belong to a specific project
        public List<UserStory> GetStoriesByProjectId(int projectId)
        {
            List<UserStory> list = new List<UserStory>();

            SqlCommand cmd = new SqlCommand(
                "SELECT Id, ProjectId, Description, State, Priority FROM USER_STORY WHERE ProjectId = @pid",
                myConnection
            );

            cmd.Parameters.AddWithValue("@pid", projectId);

            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                UserStory s = new UserStory(
                    Convert.ToInt32(r["Id"]),
                    Convert.ToInt32(r["ProjectId"]),
                    r["Description"].ToString(),
                    Convert.ToInt32(r["State"]),
                    Convert.ToInt32(r["Priority"])
                );

                list.Add(s);
            }

            r.Close();
            return list;
        }


        // TASK METHODS

        public List<Task> GetAllTasks()
        {
            List<Task> taskList = new List<Task>();
            SqlCommand myCommand = new SqlCommand("SELECT Id, UserStoryId, Description, State, Priority, Difficulty, Category FROM TASK", myConnection);
            SqlDataReader myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                taskList.Add(new Task(
                    Convert.ToInt32(myReader["Id"]),
                    Convert.ToInt32(myReader["UserStoryId"]),
                    myReader["Description"].ToString(),
                    Convert.ToInt32(myReader["State"]),
                    Convert.ToInt32(myReader["Priority"]),
                    Convert.ToInt32(myReader["Difficulty"]),
                    myReader["Category"].ToString()
                ));
            }
            myReader.Close();
            return taskList;
        }
        public List<Task> GetTasksByUserStory(int userStoryId)
        {
            List<Task> taskList = new List<Task>();

            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = myConnection;
            myCommand.CommandText = "SELECT Id, UserStoryId, Description, " +
                                    "State, Priority, Difficulty, Category " +
                                    "FROM TASK WHERE UserStoryId = @UserStoryId";
            myCommand.Parameters.AddWithValue("@UserStoryId", userStoryId);
            myCommand.CommandType = CommandType.Text;

            SqlDataReader myReader = myCommand.ExecuteReader();
            bool notEoF = myReader.Read();
            while (notEoF)
            {
                Task t = new Task(
                    Convert.ToInt32(myReader["Id"]),
                    Convert.ToInt32(myReader["UserStoryId"]),
                    myReader["Description"].ToString(),
                    Convert.ToInt32(myReader["State"]),
                    Convert.ToInt32(myReader["Priority"]),
                    Convert.ToInt32(myReader["Difficulty"]),
                    myReader["Category"].ToString()
                );
                taskList.Add(t);
                notEoF = myReader.Read();
            }
            myReader.Close();
            return taskList;
        }

        public void AddTask(int userStoryId, string description, int priority, int difficulty, string category)
        {
            SqlCommand myCommand = new SqlCommand("INSERT INTO TASK (UserStoryId, Description, State, Priority, Difficulty, Category) VALUES (@UserStoryId, @Description, 1, @Priority, @Difficulty, @Category)", myConnection);
            myCommand.Parameters.AddWithValue("@UserStoryId", userStoryId);
            myCommand.Parameters.AddWithValue("@Description", description);
            myCommand.Parameters.AddWithValue("@Priority", priority);
            myCommand.Parameters.AddWithValue("@Difficulty", difficulty);
            myCommand.Parameters.AddWithValue("@Category", category);
            myCommand.ExecuteNonQuery();
        }
        // Update task state
        public void UpdateTaskState(int taskId, int newState)
        {
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = myConnection;
            myCommand.CommandText = "UPDATE TASK SET State = @State " +
                                    "WHERE Id = @Id";
            myCommand.Parameters.AddWithValue("@State", newState);
            myCommand.Parameters.AddWithValue("@Id", taskId);
            myCommand.CommandType = CommandType.Text;
            myCommand.ExecuteNonQuery();
        }
        // Update task priority
        public void UpdateTaskPriority(int taskId, int newPriority)
        {
            SqlCommand myCommand = new SqlCommand("UPDATE TASK SET Priority = @Priority WHERE Id = @Id", myConnection);
            myCommand.Parameters.AddWithValue("@Priority", newPriority);
            myCommand.Parameters.AddWithValue("@Id", taskId);
            myCommand.ExecuteNonQuery();
        }
        public void AddPersonToTask(int taskId, int personId)
        {
            SqlCommand myCommand = new SqlCommand("INSERT INTO TASK_ASSIGNMENT (TaskId, PersonId) VALUES (@TaskId, @PersonId)", myConnection);
            myCommand.Parameters.AddWithValue("@TaskId", taskId);
            myCommand.Parameters.AddWithValue("@PersonId", personId);
            myCommand.ExecuteNonQuery();
        }

        public void RemovePersonFromTask(int taskId, int personId)
        {
            SqlCommand myCommand = new SqlCommand("DELETE FROM TASK_ASSIGNMENT WHERE TaskId = @TaskId AND PersonId = @PersonId", myConnection);
            myCommand.Parameters.AddWithValue("@TaskId", taskId);
            myCommand.Parameters.AddWithValue("@PersonId", personId);
            myCommand.ExecuteNonQuery();
        }
        public void AddTaskToUserStory(int taskId, int storyId)
        {
            SqlCommand myCommand = new SqlCommand("UPDATE TASK SET UserStoryId = @UserStoryId WHERE Id = @Id", myConnection);
            myCommand.Parameters.AddWithValue("@UserStoryId", storyId);
            myCommand.Parameters.AddWithValue("@Id", taskId);
            myCommand.ExecuteNonQuery();
        }
        public void UpdateUserStoryState(int storyId, int newState)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myConnection;
            cmd.CommandText = "UPDATE USER_STORY SET State = @state WHERE Id = @id";
            cmd.Parameters.AddWithValue("@state", newState);
            cmd.Parameters.AddWithValue("@id", storyId);
            cmd.ExecuteNonQuery();
        }
        // Get ONE task by Id
        public Task GetTaskById(int taskId)
        {
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = myConnection;
            myCommand.CommandText = "SELECT Id, UserStoryId, Description, " +
                                    "State, Priority, Difficulty, Category " +
                                    "FROM TASK WHERE Id = @Id";
            myCommand.Parameters.AddWithValue("@Id", taskId);
            myCommand.CommandType = CommandType.Text;

            SqlDataReader myReader = myCommand.ExecuteReader();
            Task task = null;
            if (myReader.Read())
            {
                task = new Task(
                    Convert.ToInt32(myReader["Id"]),
                    Convert.ToInt32(myReader["UserStoryId"]),
                    myReader["Description"].ToString(),
                    Convert.ToInt32(myReader["State"]),
                    Convert.ToInt32(myReader["Priority"]),
                    Convert.ToInt32(myReader["Difficulty"]),
                    myReader["Category"].ToString()
                );
            }
            myReader.Close();
            return task;
        }
        public List<int> GetDependencies(int storyId)
        {
            List<int> deps = new List<int>();

            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = myConnection;
            myCommand.CommandText = "SELECT DependsOnStoryId FROM STORY_DEPENDENCY WHERE StoryId = @StoryId";
            myCommand.Parameters.AddWithValue("@StoryId", storyId);

            SqlDataReader myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                deps.Add(Convert.ToInt32(myReader["DependsOnStoryId"]));
            }
            myReader.Close();

            return deps;
        }

        public bool AreDependencyTasksDone(int storyId)
        {
            // Get all stories this one depends on
            List<int> deps = GetDependencies(storyId);

            foreach (int depId in deps)
            {
                List<Task> tasks = GetTasksByUserStory(depId);
                foreach (Task t in tasks)
                {
                    if (t.State != 3) return false;
                }
            }


            return true;
        }

        public List<Person> GetPersonByTask(int taskId)
        {
            List<Person> personList = new List<Person>();
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = myConnection;
            myCommand.CommandText = "SELECT P.Id, P.Name, P.Role " +
                                    "FROM PERSON P " +
                                    "INNER JOIN TASK_ASSIGNMENT TA " +
                                    "ON P.Id = TA.PersonId " +
                                    "WHERE TA.TASKId = @TaskId";
            myCommand.Parameters.AddWithValue("@TaskId", taskId);
            myCommand.CommandType = CommandType.Text;

            SqlDataReader myReader = myCommand.ExecuteReader();
            bool notEoF = myReader.Read();
            while (notEoF)
            {
                Person p = new Person(
                    Convert.ToInt32(myReader["Id"]),
                    myReader["Name"].ToString(),
                    myReader["Role"].ToString()
                );
                personList.Add(p);
                notEoF = myReader.Read();
            }
            myReader.Close();
            return personList;
        }


        // PERSON - TEAM METHODS

        public List<Person> GetAllPersons()
        {
            List<Person> personList = new List<Person>();
            SqlCommand myCommand = new SqlCommand("SELECT Id, Name, Role FROM PERSON", myConnection);
            SqlDataReader myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                personList.Add(new Person(Convert.ToInt32(myReader["Id"]), myReader["Name"].ToString(), myReader["Role"].ToString()));
            }
            myReader.Close();
            return personList;
        }

        public void AddPerson(string name, string role)
        {
            SqlCommand myCommand = new SqlCommand("INSERT INTO PERSON (Name, Role) VALUES (@Name, @Role)", myConnection);
            myCommand.Parameters.AddWithValue("@Name", name);
            myCommand.Parameters.AddWithValue("@Role", role);
            myCommand.ExecuteNonQuery();
        }

        public List<Person> GetPersonsByProject(int projectId)
        {
            List<Person> personList = new List<Person>();
            SqlCommand myCommand = new SqlCommand(@"SELECT P.Id, P.Name, P.Role FROM PERSON P 
                                                  INNER JOIN PROJECT_TEAM PT ON P.Id = PT.PersonId 
                                                  WHERE PT.ProjectId = @ProjectId", myConnection);
            myCommand.Parameters.AddWithValue("@ProjectId", projectId);
            SqlDataReader myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                personList.Add(new Person(Convert.ToInt32(myReader["Id"]), myReader["Name"].ToString(), myReader["Role"].ToString()));
            }
            myReader.Close();
            return personList;
        }

        public void AddPersonToProject(int projectId, int personId)
        {
            SqlCommand myCommand = new SqlCommand("INSERT INTO PROJECT_TEAM (ProjectId, PersonId) VALUES (@ProjectId, @PersonId)", myConnection);
            myCommand.Parameters.AddWithValue("@ProjectId", projectId);
            myCommand.Parameters.AddWithValue("@PersonId", personId);
            myCommand.ExecuteNonQuery();
        }
    }
}