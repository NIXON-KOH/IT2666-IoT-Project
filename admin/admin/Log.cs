using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;


namespace admin
{
    class Log
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;

        public void LogActivity(string activity)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO [Log] ([Datetime], [User_ID], [Activity]) VALUES (@Datetime, @User, @Activity)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Parameters for the SQL query
                        command.Parameters.AddWithValue("@Datetime", DateTime.Now);
                        command.Parameters.AddWithValue("@User", Session.UserId);
                        command.Parameters.AddWithValue("@Activity", activity);

                        // Execute the query
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions (e.g., log them to a file or display a message)
                Console.WriteLine("Error: " + ex.Message);
            }
        }


    }
}
