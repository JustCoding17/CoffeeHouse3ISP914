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

            GetProduct();
        }
        private void GetProduct()
        {
            List<Product> productsList = new List<Product>();
            productsList = Context.Product.ToList();
            LvProductList.ItemsSource = productsList;
        }
    }
}
