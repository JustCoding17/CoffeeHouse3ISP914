using CoffeeHouse3ISP914.DB;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.IO;
using Microsoft.Win32;
using CoffeeHouse3ISP914.ClassHelper;
using static CoffeeHouse3ISP914.ClassHelper.EFClass;
using CoffeeHouse3ISP914.Windows;


namespace CoffeeHouse3ISP914.Windows
{
    /// <summary>
    /// Логика взаимодействия для MenuChangeWindow.xaml
    /// </summary>
    public partial class MenuChangeWindow : Window
    {
        private string pathPhoto = null;
        public MenuChangeWindow()
        {
            InitializeComponent();
            CMBTypeProduct.ItemsSource = Context.Category.ToList();
            CMBTypeProduct.SelectedIndex = 0;
            CMBTypeProduct.DisplayMemberPath = "Title";

        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product();
            product.Title = TbNameProduct.Text;
            product.Description = TbDisc.Text;
            product.Price = Convert.ToDecimal(TbPrice.Text);
            product.IdCategory = (CMBTypeProduct.SelectedItem as Category).IdCategory;
            if (pathPhoto != null)
            {
                product.PhotoPath = pathPhoto;
            }
            Context.Product.Add(product);
            Context.SaveChanges();
            MessageBox.Show("Ok");
        }

        private void BtnChooseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            var fileContent = string.Empty;
            openFileDialog.InitialDirectory = "c:\\";

            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == true)
            {
                ImgProduct.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                pathPhoto = openFileDialog.FileName;
            }
        }
    }
}
