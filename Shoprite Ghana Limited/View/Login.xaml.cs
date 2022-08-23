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
                Console.WriteLine(usernameValue, passwordValue);
            }
        }
    }
}
