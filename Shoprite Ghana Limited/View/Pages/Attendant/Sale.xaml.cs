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
        private double[] prices = new double[100];
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
         
                connection.openConnection();

                int prodId = Convert.ToInt32(comboBox.SelectedIndex) + 1;
            
                string sql = "SELECT price FROM products WHERE id=" + prodId + ";";

                cmd = new MySqlCommand(sql, connection.get_connection());

                try
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                 

                    while (reader.Read())
                    {

                        double price = Convert.ToDouble(reader["price"]);
                        int number = Convert.ToInt32(quantity.Text);
                        double discountGiven = Convert.ToDouble(discount.Text);

                        MessageBox.Show("" + reader["price"].ToString());

                        total.Text = (price * number - ( discountGiven * (price * number))).ToString();
                    }
                    
                }
                
            catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
                connection.closeConnection();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            connection.openConnection();
            string sql = "SELECT id FROM tills WHERE status='open';";

            cmd = new MySqlCommand(sql, connection.get_connection());

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

            //amount, ItemQuantity, productId, attendantId, discountValue, this.till
            sales[index] = new Sales();
            sales[index].amount = amount;
            this.sales[index].quantity = ItemQuantity;
            this.sales[index].productId = productId;
            this.sales[index].attendantId = attendantId;
            this.sales[index].discount = discountValue;
            this.sales[index].tillId = this.till;
          

            this.index ++;
           

            comboBox.SelectedIndex = -1;
            quantity.Text = "0";
            total.Text = "0.00";
            discount.Text = "0.00";

            MessageBox.Show("Item added");
        }
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            connection.openConnection();
            for (int i=0; i<index; i++)
            {
                try
                {
                    string statement = $"INSERT INTO sales (productId, quantity, amount, discount, tillId, attendantId) VALUES (" + sales[i].productId + "," + sales[i].quantity + "," + sales[i].amount + "," + sales[i].discount + "," + sales[i].tillId + "," + sales[i].attendantId + ");";
 
                        try
                        {
                            cmd = new MySqlCommand(statement, connection.get_connection());
                            cmd.ExecuteNonQuery();                 
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show("" + ex);
                        }

                }

                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                    MessageBox.Show("" + sales[i].productId + "," + sales[i].quantity + "," + sales[i].amount + "," + sales[i].discount + "," + sales[i].tillId + "," + sales[i].attendantId);
                    break;
                }
                
            }

            MessageBox.Show("Click OK to print reciept");

            connection.closeConnection();
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
