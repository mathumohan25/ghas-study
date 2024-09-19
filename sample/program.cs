using System;
using System.Data.SqlClient;

namespace sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your username:");
            string username = Console.ReadLine();

            string connectionString = "your_connection_string_here";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Users WHERE Username = @username";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.WriteLine("User found.");
                }
                else
                {
                    Console.WriteLine("User not found.");
                }
            }
        }
    }
}
