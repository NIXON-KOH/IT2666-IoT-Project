using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.Diagnostics; // Add this for Debug.WriteLine

namespace WindowsFormsApplication1
{
    public static class Session
    {
        public static string UserID;
    }

    public class LoginHandler
    {
        //retrieve connection information from App.Config
        private string strConnectionString = ConfigurationManager.ConnectionStrings["Database2"].ConnectionString;

        public LoginResult Login(string username, string password)
        {
            SqlConnection myConnect = new SqlConnection(strConnectionString);
            LoginResult result = new LoginResult();

            string strCommandText = "SELECT * FROM [User] WHERE User_Name=@username";
            SqlCommand cmd = new SqlCommand(strCommandText, myConnect);
            cmd.Parameters.AddWithValue("@username", username);

            try
            {
                myConnect.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Retrieve data from the database
                    string storedUsername = reader["User_Name"].ToString();
                    string storedHash = reader["User_PasswordHash"].ToString();
                    string storedSalt = reader["User_PasswordSalt"].ToString();
                    string storedRole = reader["User_Role"].ToString(); // Get User_Role as string

                    // Verify the password
                    if (VerifyHash(password, storedHash, storedSalt))
                    {
                        result.IsSuccess = true;
                        result.Username = storedUsername;
                        result.Role = storedRole; // Store Role as string
                        result.UserId = int.Parse(reader["User_Id"].ToString());
                        result.ErrorMessage = null; // No error message for successful login

                        Debug.WriteLine($"Valid Login Credentials Found: Username = {storedUsername}, Role = {storedRole}");
                    }
                    else
                    {
                        result.IsSuccess = false;
                        result.ErrorMessage = "Invalid username or password.";
                    }
                }
                else
                {
                    result.IsSuccess = false;
                    result.ErrorMessage = "Invalid username or password.";
                }

                reader.Close();
            }
            catch (SqlException ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = $"Database error: {ex.Message}";
                Debug.WriteLine($"Database Error during login for user '{username}': {ex.Message}");
            }
            finally
            {
                myConnect.Close();
            }

            return result;
        }


        static string ComputeHash(string password, string salt)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(salt + password);
                byte[] hashBytes = sha512.ComputeHash(inputBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }


        static bool VerifyHash(string password, string hash, string salt)
        {
            string computedHash = ComputeHash(password, salt);
            return computedHash == hash;
        }


        public class LoginResult
        {
            public bool IsSuccess { get; set; }
            public string Username { get; set; }
            public string Role { get; set; } // Role is now a string
            public int UserId { get; set; }
            public string ErrorMessage { get; set; }

            public LoginResult()
            {
                IsSuccess = false;
                Username = null;
                Role = null; // Default role as null string
                UserId = -1; // Default UserID
                ErrorMessage = null;
            }
        }
    }
}
