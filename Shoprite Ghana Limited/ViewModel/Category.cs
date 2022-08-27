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
    internal class Category
    {
        private string name { get; set; }
        private string id { get; set; }
        private string sql { get; set; }
        private MySqlCommand cmd;
        SqlConnection conn = new SqlConnection();

        public Category(string name)
        {
            this.name = name;
        }

        private bool getCategories()
        {
            sql = "SELECT id, name FROM categories" + ";";
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
                            MessageBox.Show("Username already exists");
                            break;
                    }
                    return false;
                }
            }
            return true;
        }

        internal bool createCategory()
        {

            sql = "INSERT INTO categories (name) VALUES (" + "'" + name + "'" + ");";
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
                            MessageBox.Show("Category already exists");
                            break;
                    }
                    return false;
                }
            }
            return true;
        }

        internal bool editCategories()
        {

            sql = "UPDATE categories SET name = " + "'" + name + "'" + " WHERE name = " + "'" + name + "'" + ";";
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

        internal bool deleteCategory()
        {
            sql = "DELETE FROM categories WHERE name = '" + name + "';";
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
