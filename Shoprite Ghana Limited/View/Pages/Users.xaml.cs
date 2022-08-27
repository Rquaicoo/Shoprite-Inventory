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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Shoprite_Ghana_Limited.View;
using Shoprite_Ghana_Limited.View.UserManagement;

namespace Shoprite_Ghana_Limited.View.Pages
{
    /// <summary>
    /// Interaction logic for Users.xaml
    /// </summary>
    public partial class Users : Page
    {
        SqlConnection connection = new SqlConnection();
        public Users()
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BindData()
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateUser user = new CreateUser();
            user.Show();
            
        }
    }
}
