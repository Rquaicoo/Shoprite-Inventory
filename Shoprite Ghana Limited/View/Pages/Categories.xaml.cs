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
using Shoprite_Ghana_Limited.View.CategoryManagement;

namespace Shoprite_Ghana_Limited.View.Pages
{
    /// <summary>
    /// Interaction logic for Categories.xaml
    /// </summary>
    public partial class Categories : Page
    {

        SqlConnection connection = new SqlConnection();
        public Categories()
        {
            InitializeComponent();
            BindData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ManageCategories manageCategories = new ManageCategories();
            manageCategories.Show();

        }

        private void BindData()
        {
            //fetch data from database
            string sql = "SELECT * FROM categories;";
            connection.openConnection();

            try
            {
                MySqlDataAdapter cmd = new MySqlDataAdapter(sql, connection.get_connection());
                DataSet ds = new DataSet();
                cmd.Fill(ds, "CategoryDataBinding");
                CategoryDataGrid.DataContext = ds;
            }

            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }


        }

        private void UserDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
