using MySql.Data.MySqlClient;
using Shoprite_Ghana_Limited.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Shoprite_Ghana_Limited.View.Pages.Attendant
{
    /// <summary>
    /// Interaction logic for Sale.xaml
    /// </summary>
    public partial class Sale : Page
    {
        SqlConnection connection = new SqlConnection();
        MySqlCommand cmd;
        private int till;

        private Sales[] sales = new Sales[10];
        private int index = 0;

        public Sale()
        {
            InitializeComponent();
            loadComboBox();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }

        private void onItemNameChange(object sender, TextChangedEventArgs e)
        {
            string sql = "SELECT id, name FROM products";

            cmd = new MySqlCommand(sql, connection.get_connection());

            MySqlDataReader reader = cmd.ExecuteReader();

            

            while (reader.Read())
            {
                //auto complete text in input box

            }

        }

        private void loadComboBox()
        {
            connection.openConnection();
            
            string sql = "SELECT * FROM products";

            cmd = new MySqlCommand(sql, connection.get_connection());
            
            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    comboBox.Items.Add(reader["name"].ToString());
                   
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
            connection.closeConnection();
        }

        private void quantity_TextChanged(object sender, TextChangedEventArgs e)
           
        {
            

        }

      

        private void Calculate_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                connection.openConnection();
                string sql = "SELECT price FROM products WHERE id=" + comboBox.SelectedIndex+1 + ";";

                cmd = new MySqlCommand(sql, connection.get_connection());
                MessageBox.Show("" + comboBox.SelectedIndex);

                try
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    MessageBox.Show("done");

                    while (reader.Read())
                    {

                        double price = Convert.ToDouble(reader["price"]);
                        int number = Convert.ToInt32(quantity.Text);
                        double discountGiven = Convert.ToDouble(discount.Text);


                        total.Text = (price * number - ( discountGiven * (price * number))).ToString();
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
                connection.closeConnection();
            }

            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            connection.openConnection();
            string sql = "SELECT id FROM tills WHERE status='open';";

            cmd = new MySqlCommand(sql, connection.get_connection());
            MessageBox.Show("" + comboBox.SelectedIndex);

            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                   this.till = Convert.ToInt32(reader["id"]);
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
            connection.closeConnection();

            int productId = Convert.ToInt32(comboBox.SelectedIndex + 1);
           
            int ItemQuantity = Convert.ToInt32(quantity.Text);
            double amount = Convert.ToDouble(total.Text);
            double discountValue = Convert.ToDouble(discount.Text);
            int attendantId = 2;

            Sales addSale = new Sales(amount, ItemQuantity, productId, attendantId, discountValue, this.till);
            sales[index] = addSale;
            this.index += 1;

            comboBox.SelectedIndex = -1;
            quantity.Text = "0";
            total.Text = "0.00";
            discount.Text = "0.00";

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            connection.openConnection();
            foreach (Sales item in sales)
            {
                string statement = $"INSERT INTO sales (productId, quantity, amount, discount, tillId, attendantId) VALUES ({item.productId}, {item.quantity}, {item.amount}, {item.discount}, {item.tillId}, {item.attendantId});";

                try
                {
                    cmd = new MySqlCommand(statement, connection.get_connection());
                    MySqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                   
                }
            }

            MessageBox.Show("Click OK to print reciept");

            connection.closeConnection();
        }
    }
}
