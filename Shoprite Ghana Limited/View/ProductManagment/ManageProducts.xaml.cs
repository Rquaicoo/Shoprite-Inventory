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
using Shoprite_Ghana_Limited.ViewModel;

namespace Shoprite_Ghana_Limited.View.ProductManagment
{
    /// <summary>
    /// Interaction logic for ManageProducts.xaml
    /// </summary>

    
    public partial class ManageProducts : Window
    {
        private int cartegoryId;

        SqlConnection connection = new SqlConnection();
        public ManageProducts()
        {
            InitializeComponent();
            loadComboBox();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.cartegoryId = comboBox.SelectedIndex + 1;

        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product(name.Text, Convert.ToDouble(price.Text),Convert.ToInt32(reorderLevel.Text), this.cartegoryId, "");

            try
            {
                bool status = product.createProduct();
                if (status)
                {
                    MessageBox.Show("Product sucessfully added");
                }
                else
                {
                    MessageBox.Show("Something happened");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
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

        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product(name.Text, Convert.ToDouble(price.Text), Convert.ToInt32(reorderLevel.Text), this.cartegoryId, "");

            try
            {
                bool status = product.editProduct();
                if (status)
                {
                    MessageBox.Show("Product sucessfully added");
                }
                else
                {
                    MessageBox.Show("Something happened");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }

        }

        private void Remove_Button_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product(name.Text, Convert.ToDouble(price.Text), Convert.ToInt32(reorderLevel.Text), this.cartegoryId, "");

            try
            {
                bool status = product.deleteProduct();
                if (status)
                {
                    MessageBox.Show("Product sucessfully added");
                }
                else
                {
                    MessageBox.Show("Something happened");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }
    }
}
