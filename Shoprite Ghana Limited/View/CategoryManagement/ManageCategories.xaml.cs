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

namespace Shoprite_Ghana_Limited.View.CategoryManagement
{
    /// <summary>
    /// Interaction logic for ManageCategories.xaml
    /// </summary>
    public partial class ManageCategories : Window
    {
        SqlConnection connection = new SqlConnection();
        

        public ManageCategories()
        {
            InitializeComponent();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            connection.openConnection();
            Category category = new Category(name.Text);

            bool status = category.createCategory();
            if (status)
            {
                MessageBox.Show("Category successfully added");
            }
            else
            {
                MessageBox.Show("Something happened");
            }

        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            connection.openConnection();
            Category category = new Category(name.Text);

            bool status = category.editCategories();
            if (status)
            {
                MessageBox.Show("Category successfully modified");
            }
            else
            {
                MessageBox.Show("Something happened");
            }
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            connection.openConnection();
            Category category = new Category(name.Text);

            bool status = category.deleteCategory();
            if (status)
            {
                MessageBox.Show("Category successfully removed");
            }
            else
            {
                MessageBox.Show("Something happened");
            }
        }
    }
}
