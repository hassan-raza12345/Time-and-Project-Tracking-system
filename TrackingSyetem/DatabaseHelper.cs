using System;
using System.Data.SqlClient;

namespace TrackingSystem
{
    public class DatabaseHelper
    {
        private SqlConnection connection;
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\SC\\source\\repos\\Tracking System\\TrackingSyetem\\Database1.mdf\";Integrated Security=True;Connect Timeout=30";

        public DatabaseHelper()
        {
            connection = new SqlConnection(connectionString);
        }

        public DataTable GetProjects()
        {
            DataTable projects = new DataTable();
            using (SqlCommand cmd = new SqlCommand("SELECT ProjectID, ProjectName FROM Projects", connection))
            {
                connection.Open();
                projects.Load(cmd.ExecuteReader());
            }
            return projects;
        }

        public DataTable GetTasksForProject(int projectId)
        {
            DataTable tasks = new DataTable();
            using (SqlCommand cmd = new SqlCommand("SELECT TaskID, TaskName FROM Tasks WHERE ProjectID = @ProjectID", connection))
            {
                cmd.Parameters.AddWithValue("@ProjectID", projectId);
                connection.Open();
                tasks.Load(cmd.ExecuteReader());
            }
            return tasks;
        }

        public bool SaveProgress(int taskId, string progress)
        {
            using (SqlCommand cmd = new SqlCommand("UPDATE Tasks SET Progress = @Progress WHERE TaskID = @TaskID", connection))
            {
                cmd.Parameters.AddWithValue("@Progress", progress);
                cmd.Parameters.AddWithValue("@TaskID", taskId);

                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }
}
