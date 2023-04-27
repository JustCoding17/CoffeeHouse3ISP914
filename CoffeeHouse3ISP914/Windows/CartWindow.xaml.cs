using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
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
    /// Логика взаимодействия для CartWindow.xaml
    /// </summary>
    public partial class CartWindow : Window
    {
        public CartWindow()
        {
            InitializeComponent();
            GetListProduct();
        }

        private void GetListProduct()
        {
            ObservableCollection<Product> products = new ObservableCollection<Product>(CartClass.Products);
            LvCartList.ItemsSource = products;

            decimal generalprice = 0;
            foreach (var item in CartClass.Products)
            {
                generalprice += item.Price * item.Quantity;
            }
            TbPrice.Text = generalprice.ToString();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnRemoveFromCart_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button == null)
            {
                return;
            }

            var selectedProduct = button.DataContext as Product;

            if (selectedProduct != null)
            {
                selectedProduct.Quantity = 1;
                CartClass.Products.Remove(selectedProduct);

            }
            GetListProduct();
        }

        private void btnBuy_Click(object sender, RoutedEventArgs e)
        {
            Sale sale = new Sale();
            sale.IdEmployee = EmployeeDataClass.Employee.IdEmployee;
            sale.IdClient = 6;
            sale.Date = DateTime.Now;
            if (sale != null)
            {
                Context.Sale.Add(sale);
                Context.SaveChanges();
            }

            foreach (var item in CartClass.Products)
            {
                ProductSale productSale = new ProductSale();
                productSale.IdProduct = item.IdProduct;
                productSale.Count = item.Quantity;
                productSale.IdSale = Context.Sale.ToList().LastOrDefault().IdSale;
                productSale.FinalPrice = item.Price * item.Quantity;

                Context.ProductSale.Add(productSale);
                Context.SaveChanges();
            }            
            MessageBox.Show("Покупка успешно осуществлена!", "Успех!");
            CartClass.Products.Clear();
            this.Close();
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button == null)
            {
                return;
            }

            Product selectedProduct = button.DataContext as Product;

            if (selectedProduct != null)
            {
                if (selectedProduct.Quantity == 1 || selectedProduct.Quantity == 0)
                {
                    CartClass.Products.Remove(selectedProduct);
                }
                else
                {
                    selectedProduct.Quantity --;
                    int a = CartClass.Products.IndexOf(selectedProduct);
                    CartClass.Products.Remove(selectedProduct);
                    CartClass.Products.Insert(a, selectedProduct);
                }
            }

            GetListProduct();
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button == null)
            {
                return;
            }

            Product selectedProduct = button.DataContext as Product;

            if (selectedProduct != null)
            {
                selectedProduct.Quantity++;
                int a = CartClass.Products.IndexOf(selectedProduct);
                CartClass.Products.Remove(selectedProduct);
                CartClass.Products.Insert(a, selectedProduct);
            }

            GetListProduct();
        }
    }
}
