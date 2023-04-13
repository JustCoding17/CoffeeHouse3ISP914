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

using CoffeeHouse3ISP914.ClassHelper;
using CoffeeHouse3ISP914.DB;
using static CoffeeHouse3ISP914.ClassHelper.EFClass;

namespace CoffeeHouse3ISP914.Windows
{
    /// <summary>
    /// Логика взаимодействия для MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
            if (EmployeeDataClass.Employee.IdPosition != 1)
            {
                btnAdd.Visibility = Visibility.Collapsed;
                btnEdit.Visibility = Visibility.Collapsed;
            }
            GetProduct();
        }
        private void GetProduct()
        {
            List<Product> productsList = new List<Product>();
            productsList = Context.Product.ToList();
            LvProductList.ItemsSource = productsList;
        }

        private void btnAddEdit_Click(object sender, RoutedEventArgs e)
        {
            MenuChangeWindow menuChangeWindow = new MenuChangeWindow();
            this.Hide();
            menuChangeWindow.ShowDialog();
            this.Show();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigateWindow navigateWindow = new NavigateWindow();
            navigateWindow.Show();
            this.Close();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (LvProductList.SelectedItem is Product)
            {
                var product = LvProductList.SelectedItem as Product;
                MenuChangeWindow menuChangeWindow = new MenuChangeWindow(product);
                menuChangeWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Выберите запись, которую нужно изменить!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
