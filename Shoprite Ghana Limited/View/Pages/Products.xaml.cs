using System;
using System.Collections.Generic;
using System.Data;
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
using MySql.Data.MySqlClient;
using Shoprite_Ghana_Limited.View.ProductManagment;

namespace Shoprite_Ghana_Limited.View.Pages
{
    /// <summary>
    /// Interaction logic for Products.xaml
    /// </summary>
    public partial class Products : Page
    {
        SqlConnection connection = new SqlConnection();
        public Products()
        {
            InitializeComponent();
            BindData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ManageProducts manageProducts = new ManageProducts();
            manageProducts.Show();
        }

        private void ProductDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        
        private void BindData()
        {
            //fetch data from database
            string sql = "SELECT * FROM products;";
            connection.openConnection();

            try
            {
                MySqlDataAdapter cmd = new MySqlDataAdapter(sql, connection.get_connection());
                DataSet ds = new DataSet();
                cmd.Fill(ds, "ProductBinding");
                ProductDataGrid.DataContext = ds;
            }

            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }


        }
    }
}
