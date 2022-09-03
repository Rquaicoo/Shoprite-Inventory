using MySql.Data.MySqlClient;
using Shoprite_Ghana_Limited.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Shoprite_Ghana_Limited.ViewModel
{
    internal class Sales
    {
        SqlConnection connection = new SqlConnection();

        public double amount;
        public int quantity;
        public int productId;
        public int attendantId;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            
        public double discount;
        public int tillId;
        public MySqlCommand cmd;

        
        public Sales()
        {
          ;
        }

        internal bool createSale(Sales[] items)
        {

            connection.openConnection();
            foreach (Sales item in items)
            {
                string statement =  $"INSERT INTO sales (productId, quantity, amount, discount, tillId, aattendantId) VALUES '{productId}', '{quantity}', '{amount}', '{discount}', '{tillId}', '{attendantId}';";

                try
                {
                    cmd = new MySqlCommand(statement, connection.get_connection());
                    MySqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                    return true;
                }
                catch (MySqlException e)
                {
                    MessageBox.Show("" + e);
                    return false;
                }
            }


            return true;
           
        }
        
        
    }
}
