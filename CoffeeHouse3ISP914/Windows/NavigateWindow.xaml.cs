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
    /// Логика взаимодействия для NavigateWindow.xaml
    /// </summary>
    public partial class NavigateWindow : Window
    {
        public NavigateWindow()
        {
            InitializeComponent();
            TxtData.Text = EmployeeDataClass.Employee.LastName + " " + EmployeeDataClass.Employee.FirstName + " / " + EmployeeDataClass.Employee.Position.Title;
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menuWindow = new MenuWindow();
            menuWindow.Show();
            this.Close();
        }
    }
}
