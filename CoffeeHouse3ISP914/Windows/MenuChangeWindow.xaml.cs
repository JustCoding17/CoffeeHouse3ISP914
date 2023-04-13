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
        private bool isMenuChange = false;
        private Product editproduct;
        private string pathPhoto = null;
        public MenuChangeWindow()
        {
            InitializeComponent();
            //Заполнение выпадающего списка "Категория"
            CMBTypeProduct.ItemsSource = Context.Category.ToList();
            CMBTypeProduct.SelectedIndex = 0;
            CMBTypeProduct.DisplayMemberPath = "Title";

        }
        public MenuChangeWindow(Product product)
        {
            InitializeComponent();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            //Проверка на пустые поля при добавлении
            if (string.IsNullOrWhiteSpace(TbNameProduct.Text) ||
                string.IsNullOrWhiteSpace(CMBTypeProduct.Text) ||
                string.IsNullOrWhiteSpace(TbPrice.Text))
            {
                MessageBox.Show("Не все поля заполнены!", "Ошибка");
                return;
            }

            //Проверка на существующий продукт
            var titleProd = Context.Product.ToList()
                .Where(i => i.Title == TbNameProduct.Text).FirstOrDefault();
            if (titleProd != null)
            {
                MessageBox.Show("Такой продукт уже существует", "Ошибка");
                return;
            }
            //Проверка на цифры в цене
            bool result = Int64.TryParse(TbPrice.Text, out var number);
            if (result != true)
            {
                MessageBox.Show("Цена должна быть заполнена числами!", "Ошибка");
                return;
            }
            //Заполнение экземпляра класса данными
            Product product = new Product();
            product.Title = TbNameProduct.Text;
            product.Description = TbDisc.Text;
            product.Price = Convert.ToDecimal(TbPrice.Text);
            product.IdCategory = (CMBTypeProduct.SelectedItem as Category).IdCategory;
            if (pathPhoto != null)
            {
                product.PhotoPath = File.ReadAllBytes(pathPhoto);
            }
            Context.Product.Add(product);
            Context.SaveChanges();
            MessageBox.Show("Товар успешно добавлен");
        }

        private void BtnChooseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                ImgProduct.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                pathPhoto = openFileDialog.FileName;
            }
        }
    }
}
