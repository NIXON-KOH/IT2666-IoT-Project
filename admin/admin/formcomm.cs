using System;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace admin
{
    public partial class formcomm : Form
    {
        public formcomm()
        {
            InitializeComponent();
        }
        

        string strConnectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;
        public delegate void myprocessDataDelegate(string strData);
        DataComms dataComms;

        public void commsDataRecieve(string dataReceived)
        {
            HandleData(dataReceived);
        }

        public void commsSendError(string errMsg)
        {
            MessageBox.Show(errMsg);
        }

        private void InitComms()
        {
            dataComms = new DataComms();
            dataComms.dataReceiveEvent += new DataComms.DataReceivedDelegate(commsDataRecieve);
            dataComms.dataSendErrorEvent += new DataComms.DataSendErrorDelegate(commsSendError);
        }

        private void HandleData(string strData)
        {
            //string strData = "Bin=1, Light=123, Distance=123, Water=123, RFID='Test', Temp=123, Red=True, Green=False";

            string[] splitData = strData.Split(',');

            Console.WriteLine(splitData);

            //Variables
            int bin_id = 0;
            int light = 0;
            int distance = 0;
            int water = 0;
            string rfid = string.Empty;
            int temp = 0;
            bool ledred = false;
            bool ledgreen = false;

            foreach (string i in splitData)
            {
                string[] keyValue = i.Trim().Split('=');

                string key = keyValue[0].Trim();
                string value = keyValue[1].Trim();

                switch (key)
                {
                    case "Bin":
                        bin_id = int.Parse(value);
                        break;

                    case "Light":
                        light = int.Parse(value);
                        break;

                    case "Distance":
                        distance = int.Parse(value);
                        break;

                    case "Water":
                        water = int.Parse(value);
                        break;

                    case "RFID":
                        rfid = value;
                        break;

                    case "Temp":
                        temp = int.Parse(value.Split('.')[0]);
                        break;

                    case "Red":
                        ledred = bool.Parse(value);
                        break;

                    case "Green":
                        ledgreen = bool.Parse(value);
                        break;


                }
            }

            SqlConnection myConnect = new SqlConnection(strConnectionString);


            string query = "INSERT Hardware (Bin_Id, Datetime, Light, Distance, Water, RFID, Temperature, LED_Red, LED_Green) " +
                            "VALUES (@Bin_Id, @Datetime, @Light, @Distance, @Water, @RFID, @Temp, @LED_Red, @LED_Green)";
            SqlCommand command = new SqlCommand(query, myConnect);


            command.Parameters.AddWithValue("@Bin_Id", bin_id);
            command.Parameters.AddWithValue("@Datetime", DateTime.Now);
            command.Parameters.AddWithValue("@Light", light);
            command.Parameters.AddWithValue("@Distance", distance);
            command.Parameters.AddWithValue("@Water", water);
            command.Parameters.AddWithValue("@RFID", rfid);
            command.Parameters.AddWithValue("@Temp", temp);
            command.Parameters.AddWithValue("@LED_Red", ledred);
            command.Parameters.AddWithValue("@LED_Green", ledgreen);

            myConnect.Open();
            int result = command.ExecuteNonQuery();
            myConnect.Close();
        }

        private void DataComms_Load(object sender, EventArgs e)
        {
            InitComms();
            LoginForm loginForm = new admin.LoginForm();
            loginForm.Show();
            
        }
    }
}

