using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;

namespace Shoprite_Ghana_Limited.View
{
    internal class SqlConnection
    {
        private MySqlConnection conn;
        private string server;
        private string user;
        private string password;
        private string database;

        public SqlConnection()
        {
            server = "localhost";
            database = "shoprite";
            user = "russell";
            password = "12345";
            string connectionString;
            
            
            connectionString = "server=127.0.0.1;uid=russell;" + "pwd=12345;database=shoprite";
            conn = new MySqlConnection(connectionString);
        }

        public bool openConnection()
        {
            try
            {
                conn.Open();
                return true;
            }

            catch (MySqlException e)
            {
                switch (e.Number)
                {
                   
                    case 0:
                        MessageBox.Show("Cannot connect to server");
                        break;
                    case 1045:
                        MessageBox.Show("Invalid credentials");
                        break;


               
               }
                return false;
            }

        }

        public void closeConnection()
        {
            this.conn.Close();
        }
        
        public MySqlConnection get_connection()
        {
            return this.conn;    
        }
    }

    
}
