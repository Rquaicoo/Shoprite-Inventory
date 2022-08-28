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
using Shoprite_Ghana_Limited.View.StockManagement;
using Shoprite_Ghana_Limited.View;

namespace Shoprite_Ghana_Limited.View.Pages
{
    /// <summary>
    /// Interaction logic for Stock.xaml
    /// </summary>
    public partial class Stock : Page
    {
        SqlConnection connection = new SqlConnection();
        public Stock()
        {
            InitializeComponent();
            BindData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ManageStock manageStock = new ManageStock();
            manageStock.Show();
        }

        private void UserDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BindData()
        {
            //fetch data from database
            string sql = "SELECT * FROM stock;";
            connection.openConnection();

            try
            {
                MySqlDataAdapter cmd = new MySqlDataAdapter(sql, connection.get_connection());
                DataSet ds = new DataSet();
                cmd.Fill(ds, "StockDataBinding");
                StockDataGrid.DataContext = ds;
            }

            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }


        }
    }
}
