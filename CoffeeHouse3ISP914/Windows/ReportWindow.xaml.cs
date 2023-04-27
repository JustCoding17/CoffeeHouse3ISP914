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
using CoffeeHouse3ISP914.Windows;
using static CoffeeHouse3ISP914.ClassHelper.EFClass;

namespace CoffeeHouse3ISP914.Windows
{
    /// <summary>
    /// Логика взаимодействия для ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        public ReportWindow()
        {
            InitializeComponent();
        }

        private void btnSale_Click(object sender, RoutedEventArgs e)
        {
            ReportSaleWindow reportSaleWindow = new ReportSaleWindow();
            this.Hide();
            reportSaleWindow.ShowDialog();
            this.Show();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigateWindow navigateWindow = new NavigateWindow();
            navigateWindow.Show();
            this.Close();
        }
    }
}
