using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TodoApp.Models;

namespace TodoApp.DAL
{
    public class ToDoDAL
    {
        string conString = ConfigurationManager.ConnectionStrings["todoConfString"].ConnectionString;
        public List<TodoModel> GetAllTodo()
        {
            List<TodoModel> todoModels = new List<TodoModel>();
            using(SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "sp_GetAllTask";
                SqlDataAdapter sqlData = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                connection.Open();
                sqlData.Fill(dataTable);
                connection.Close();
                foreach(DataRow dr in dataTable.Rows)
                {
                    todoModels.Add(new TodoModel
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Task = Convert.ToString(dr["Task"]),
                        Category = Convert.ToString(dr["Category"]),
                        Priority = Convert.ToString(dr["Priority"])
                    });
                } 
            }

            return todoModels;
        }

        
        public List<TodoModel> GetTask(int id)
        {
            List<TodoModel> todoModels = new List<TodoModel>();
            using(SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "sp_GetTask";
                command.Parameters.AddWithValue("@Id", id);
                SqlDataAdapter sqlData = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                connection.Open();
                sqlData.Fill(dataTable);
                connection.Close();
                foreach(DataRow dr in dataTable.Rows)
                {
                    todoModels.Add(new TodoModel
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Task = Convert.ToString(dr["Task"]),
                        Category = Convert.ToString(dr["Category"]),
                        Priority = Convert.ToString(dr["Priority"])
                    });
                }
            }
            return todoModels;
        }
        
        public bool CreateTask(TodoModel todoModel)
        {
            int id = 0;

            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand sqlCommand = new SqlCommand("sp_CreateTask", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Task", todoModel.Task);
                sqlCommand.Parameters.AddWithValue("@Priority", todoModel.Priority);
                sqlCommand.Parameters.AddWithValue("@Category", todoModel.Category);

                connection.Open();
                id = sqlCommand.ExecuteNonQuery();
                connection.Close();
            }
            return id != 0;
        }

        public int DeleteTask(int? id)
        {
            int i = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand sqlCommand = new SqlCommand("sp_DeleteTask", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Id", id);
                connection.Open();
                i = sqlCommand.ExecuteNonQuery();
                connection.Close();
                

            }

            return i; 
        }

        public bool UpdateTask(int id, TodoModel todoModel)
        {
            int success = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand sqlCommand = new SqlCommand("sp_UpdateTask", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Id", todoModel.Id);
                sqlCommand.Parameters.AddWithValue("@Task", todoModel.Task);
                sqlCommand.Parameters.AddWithValue("@Priority", todoModel.Priority);
                sqlCommand.Parameters.AddWithValue("@Category", todoModel.Category);
                connection.Open();
                success = sqlCommand.ExecuteNonQuery();
                connection.Close();

            }
            return success != 0;
            
        }
    }
}