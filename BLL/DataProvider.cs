using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DAO
{
    public class DataProvider
    {
        SqlCommand command;
        SqlConnection getConnect;
        SqlDataAdapter adapter;
        DataTable data;
        private static DataProvider instance;
        //private string connectionStr = @"Data Source=SUNSHINE\SUN;Initial Catalog=QLKS;Integrated Security=True";
        //private string connectionStr = @"Data Source=THIEN-AI\THIENAI;Initial Catalog=HotelManagement;Integrated Security=True";
        //private string connectionStr = @"Data Source=.\sqlexpress;Initial Catalog=HotelManagement;Integrated Security=True";

        private void getConnectData()
        {
            getConnect = new SqlConnection(@"Data Source=SUNSHINE\SUN;Initial Catalog=QLKS;Integrated Security=True");
            getConnect.Open();

        }
        //closeConnect SQL
        private void closeConnectData()
        {
            getConnect.Close();
            getConnect.Dispose();
        }
        //selectSQL
        public DataTable ExecuteQuery(string query, object [ ] parameter = null)
        {

            getConnectData();
            command = new SqlCommand(query, getConnect);
            AddParameter(query, parameter, command);
            adapter = new SqlDataAdapter(command);
            data = new DataTable();
            adapter.Fill(data);

            closeConnectData();
            return data;
        }
        //Thực hiện sql insert update delete
        public int ExecuteNoneQuery(string query, object [ ] parameter = null)
        {
            int dt = 0;
            getConnectData();
            command = new SqlCommand(query, getConnect);
            AddParameter(query, parameter, command);
            dt = command.ExecuteNonQuery();
            closeConnectData();

            return dt;
        }
        public object ExecuteScalar(string query, object [ ] parameter = null)
        {
            object data = new object();
            getConnectData();
            command = new SqlCommand(query, getConnect);
            AddParameter(query, parameter, command);
            data = command.ExecuteScalar();
            closeConnectData();

            return data;
        }
        private void AddParameter(string query, object [ ] parameter, SqlCommand command)
        {
            if ( parameter != null )
            {
                string [ ] listParameter = query.Split(' ');
                int i = 0;
                foreach ( string item in listParameter )
                {
                    if ( item.Contains("@") )
                    {
                        command.Parameters.AddWithValue(item, parameter [ i ]);
                        ++i;
                    }
                }
            }
        }
        public static DataProvider Instance
        {
            get { if ( instance == null ) instance = new DataProvider(); return instance; }
            private set => instance = value;
        }
        private DataProvider() { }
    }
}