using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Shoprite_Ghana_Limited.View;

namespace Shoprite_Ghana_Limited.ViewModel
{
    internal class Stock
    {
        private int quantity { get; set; }
        private int categoryId { get; set; }
       
        private string id { get; set; }
        private string sql { get; set; }
        private MySqlCommand cmd;
        SqlConnection conn = new SqlConnection();

        public Stock(int quantity, int categoryId)
        {
            this.quantity = quantity;
            this.categoryId = categoryId;
        }

        private bool getStock()
        {
            sql = "SELECT id, categoryId, quantity FROM stock" + ";";
            if (conn.openConnection() == true)
            {
                try
                {
                    cmd = new MySqlCommand(sql, conn.get_connection());
                    MySqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                    return true;
                }
                catch (MySqlException e)
                {
                    switch (e.Number)
                    {
                        case 1062:
                            MessageBox.Show("Stock already exists");
                            break;
                    }
                    return false;
                }
            }
            return true;
        }

        internal bool createStock()
        {

            sql = "INSERT INTO stock (quantity, categoryId) VALUES (" + quantity + ","  + categoryId  + ");";
            if (conn.openConnection() == true)
            {
                try
                {
                    cmd = new MySqlCommand(sql, conn.get_connection());
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException e)
                {
                    switch (e.Number)
                    {
                        case 1062:
                            MessageBox.Show("Stock already exists");
                            break;
                    }
                    return false;
                }
            }
            return true;
        }

        internal bool editStock()
        {

            sql = "UPDATE stock SET categoryId = " + categoryId + "," + "quantity = " + quantity + "," + " WHERE categoryId = " + categoryId + ";";
            if (conn.openConnection() == true)
            {
                try
                {
                    cmd = new MySqlCommand(sql, conn.get_connection());
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException e)
                {
                    switch (e.Number)
                    {
                        case 1062:
                            MessageBox.Show("An error occured");
                            break;
                    }
                    return false;
                }
            }
            return true;
        }

        internal bool deleteStock()
        {
            sql = "DELETE FROM stock WHERE categoryId = " + categoryId + ";";
            if (conn.openConnection() == true)
            {
                try
                {
                    cmd = new MySqlCommand(sql, conn.get_connection());
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException e)
                {
                    switch (e.Number)
                    {
                        case 1062:
                            MessageBox.Show("An error occured");
                            break;
                    }
                    return false;
                }
            }
            return true;
        }
    }
}
