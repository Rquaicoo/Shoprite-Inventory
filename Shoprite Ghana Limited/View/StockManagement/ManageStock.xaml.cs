using MySql.Data.MySqlClient;
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
using Shoprite_Ghana_Limited.View;
using Shoprite_Ghana_Limited.ViewModel;
using System.Xml.Linq;

namespace Shoprite_Ghana_Limited.View.StockManagement
{
    /// <summary>
    /// Interaction logic for ManageStock.xaml
    /// </summary>
    public partial class ManageStock : Window
    {
        private int categoryId;
        SqlConnection connection = new SqlConnection();

        public ManageStock()
        {
            InitializeComponent();
            loadComboBox();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.categoryId = comboBox.SelectedIndex + 1;
        }

        private void add(object sender, RoutedEventArgs e)
        {
            connection.openConnection();

            Stock stock = new Stock(Convert.ToInt32(quantity.Text), categoryId);

            bool status = stock.createStock();
            if (status)
            {
                MessageBox.Show("Stock successfully added");
            }
            else
            {
                MessageBox.Show("Something happened");
            }

        }

        private void loadComboBox()
        {
            string query = "SELECT * FROM categories;";

            connection.openConnection();
            MySqlCommand cmd = new MySqlCommand(query, connection.get_connection());

            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                MessageBox.Show("done");
                while (reader.Read())
                {
                    comboBox.Items.Add(reader["id"].ToString() + "-" + reader["name"].ToString());
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void edit(object sender, RoutedEventArgs e)
        {
            connection.openConnection();

            Stock stock = new Stock(Convert.ToInt32(quantity.Text), categoryId);

            bool status = stock.editStock();
            if (status)
            {
                MessageBox.Show("Stock successfully modified");
            }
            else
            {
                MessageBox.Show("Something happened");
            }
        }

        private void remove(object sender, RoutedEventArgs e)
        {
            connection.openConnection();

            Stock stock = new Stock(Convert.ToInt32(quantity.Text), categoryId);

            bool status = stock.deleteStock();
            if (status)
            {
                MessageBox.Show("Stock successfully deleted");
            }
            else
            {
                MessageBox.Show("Something happened");
            }
        }
    }
}
