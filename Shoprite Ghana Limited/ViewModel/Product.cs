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
    internal class Product
    {
        private string name { get; set; }
        private double price { get; set; }
        private int reorderLevel { get; set; }
        private int categoryId { get; set; }

        private string barcode { get; set; }
        
        private string id { get; set; }
        private string sql { get; set; }
        private MySqlCommand cmd;
        SqlConnection conn = new SqlConnection();

        public Product(string name, double price, int reorderLevel, int categoryId, string barcode)
        {
            this.name = name;
            this.price = price;
            this.reorderLevel = reorderLevel;
            this.categoryId = categoryId;
            this.barcode = barcode;
        }

        private bool getProducts()
        {
            sql = "SELECT id, name, price, reorderLevel, categoryId FROM products" + ";";
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
                            MessageBox.Show("An error occured");
                            break;
                    }
                    return false;
                }
            }
            return true;
        }

        internal bool createProduct()
        {

            sql = "INSERT INTO products (name, price, reorderLevel, categoryId) VALUES (" + "'" + name + "'" + "," +  + price + ","  + reorderLevel  + "," + categoryId + "," + ");";
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
                            MessageBox.Show("Product already exists");
                            break;
                    }
                    return false;
                }
            }
            return true;
        }

        internal bool editProduct()
        {

            sql = "UPDATE products SET name = " + "'" + name + "'" + "," + "price = " + price + "," + "reorderLevel = " + reorderLevel + "," + "categoryId = " + categoryId + " WHERE name = " + "'" + name + "'" + ";";
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

        internal bool deleteUser()
        {
            sql = "DELETE FROM products WHERE name = '" + name + "';";
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
