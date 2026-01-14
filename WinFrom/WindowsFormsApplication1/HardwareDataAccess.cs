using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    class HardwareDataAccess
    {
        private string strConnectionString = ConfigurationManager.ConnectionStrings["Database2"].ConnectionString;

        public async Task<HardwareData> FetchHardwareDataAsync()
        {
            HardwareData hardwareData = null;
            try
            {
                using (SqlConnection myConnect = new SqlConnection(strConnectionString))
                {
                    await myConnect.OpenAsync();

                    string strCommandText = "SELECT TOP 1 * FROM Hardware ORDER BY Datetime DESC";
                    SqlCommand cmd = new SqlCommand(strCommandText, myConnect);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            hardwareData = new HardwareData()
                            {
                                Datetime = Convert.ToDateTime(reader["Datetime"]),
                                Light = Convert.ToDouble(reader["Light"]),
                                Distance = Convert.ToDouble(reader["Distance"]),
                                Water = Convert.ToDouble(reader["Water"]),
                                RFID = reader["RFID"].ToString(),
                                Temperature = Convert.ToDouble(reader["Temperature"]),
                                LED_Red = Convert.ToBoolean(reader["LED_Red"]),
                                LED_Green = Convert.ToBoolean(reader["LED_Green"])
                            };
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine($"Database error in HardwareDataAccess.FetchHardwareDataAsync: {ex.Message}");
                throw; // Re-throw the exception to be handled by the calling method
            }
            return hardwareData;
        }
    }
}
