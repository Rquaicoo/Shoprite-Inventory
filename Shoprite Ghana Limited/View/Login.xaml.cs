using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace Shoprite_Ghana_Limited.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private string usernameValue, passwordValue, sql;
        private SqlConnection conn = new SqlConnection();
        private MySqlCommand cmd;

      public Login()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void submitClick(object sender, RoutedEventArgs e)
        {
            usernameValue = username.Text;
            passwordValue = password.Password;

            if (string.IsNullOrEmpty(usernameValue) || string.IsNullOrEmpty(passwordValue))
            {
                MessageBox.Show("Enter username or password");
            }

            else
            {
                sql = "SELECT username, email, role FROM users WHERE username=" + "'" + usernameValue + "'" + " AND password=" + "MD5(" + passwordValue + ");";
                if (conn.openConnection() ==true)
                {
                    try
                    {
                        cmd = new MySqlCommand(sql, conn.get_connection());
                        object a = cmd.ExecuteScalar();

                        if(a == null)
                        {
                            MessageBox.Show("Invalid username or password");
                        }

                        else
                        {
                            AttendantDashboard user = new AttendantDashboard();
                            Home admin = new Home();

                            MySqlDataReader reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                string role = reader["role"].ToString();
                                if (role == "admin")
                                {                                    
                                    admin.Show();
                                    this.Close();
                                }
                                
                                else
                                {
                                    user.Show();
                                    this.Close();
                                }
                            }
                            

                            
                        }
                    }

                    catch (MySqlException x)
                    {
                        MessageBox.Show("" + x);
                    }
                }
            }
        }
    }
}
