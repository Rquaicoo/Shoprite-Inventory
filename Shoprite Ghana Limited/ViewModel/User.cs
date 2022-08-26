using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
using Shoprite_Ghana_Limited.View;

namespace Shoprite_Ghana_Limited.ViewModel
{
    internal class User
    {
        private string username { get; set; }
        private string email { get; set; }
        private string password { get; set; }
        private string fullname { get; set; }
        private string role { get; set; }
        private string id { get; set; }
        private string sql { get; set; }
        private MySqlCommand cmd;
        SqlConnection conn = new SqlConnection();

        public User()
        {
            username = "";
            email = "";
            password = "";
            fullname = "";
            role = "";
        }

        private bool getUsers()
        {
            sql = "SELECT id, username, fullname, email, password FROM users" + ";";
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

        private bool createUser()
        {
            
                sql = "INSERT INTO users (username, email, password, fullname, role) VALUES (" + "'" + username + "'" + "," + "'" + email + "'" + "," + "'" + password + "'" + "," + "'" + fullname + "'" + "," + "'" + role + "'" + ");";
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
                                MessageBox.Show("Username already exists");
                                break;
                        }
                        return false;
                    }
                }
            return true;
        }
        
        private bool editUser()
        {

            sql = "UPDATE users SET username = " + "'" + username + "'" + "," + "email = " + "'" + email + "'" + "," + "password = " + "'" + password + "'" + "," + "fullname = " + "'" + fullname + "'" + "," + "role = " + "'" + role + "'" + " WHERE username = " + "'" + username + "'" + ";";
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

        private bool deleteUser()
        {
            sql = "DELETE FROM users WHERE id = " + id + ";";
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
