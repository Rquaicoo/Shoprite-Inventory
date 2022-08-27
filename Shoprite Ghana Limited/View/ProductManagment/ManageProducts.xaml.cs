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
using Shoprite_Ghana_Limited.View;

namespace Shoprite_Ghana_Limited.View.ProductManagment
{
    /// <summary>
    /// Interaction logic for ManageProducts.xaml
    /// </summary>

    
    public partial class ManageProducts : Window
    {

        SqlConnection connection = new SqlConnection();
        public ManageProducts()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string query = "SELECT * FROM categories;";

            MySqlCommand cmd = new MySqlCommand(query, connection.get_connection());

            MySqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                comboBox.Items.Add(reader.GetString(0));
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string query = "SELECT * FROM categories;";

            MySqlCommand cmd = new MySqlCommand(query, connection.get_connection());

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                comboBox.Items.Add(reader.GetString("name"));

            }
        }
    }
}
