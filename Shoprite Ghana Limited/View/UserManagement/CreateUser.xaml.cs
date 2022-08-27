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
using Shoprite_Ghana_Limited.View.Pages;
using Shoprite_Ghana_Limited.ViewModel;

namespace Shoprite_Ghana_Limited.View.UserManagement
{
    /// <summary>
    /// Interaction logic for CreateUser.xaml
    /// </summary>
    public partial class CreateUser : Window
    {
        private string role;
        

        public CreateUser()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            User user = new User(username.Text, email.Text, fullname.Text, password.Text, this.role);

            bool status = user.createUser();
            if (status)
            {
                MessageBox.Show("User successfully added");
            }

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            this.role = "admin";

        }

        private void attendant_Checked(object sender, RoutedEventArgs e)
        {
            this.role = "attendant";
        }

        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {

            User user = new User(username.Text, email.Text, fullname.Text, password.Text, this.role);

            bool status = user.editUser();
            if (status)
            {
                MessageBox.Show("User successfully updated");
            }
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            User user = new User(username.Text, email.Text, fullname.Text, password.Text, this.role);

            bool status = user.deleteUser();

            if (status)
            {
                MessageBox.Show("User successfully deleted");
            }
        }
    }
}
