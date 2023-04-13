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
    /// Логика взаимодействия для EmployeeListWindow.xaml
    /// </summary>
    public partial class EmployeeListWindow : Window
    {
        public EmployeeListWindow()
        {
            InitializeComponent();
            if (EmployeeDataClass.Employee.IdPosition != 1)
            {
                btnAdd.Visibility = Visibility.Collapsed;
                btnEdit.Visibility = Visibility.Collapsed;
            }
            GetEmployee();
        }

        private void GetEmployee()
        {
            List<Employee> employees = new List<Employee>();
            employees = Context.Employee.ToList();
            LvEmployeeList.ItemsSource = employees;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigateWindow navigateWindow = new NavigateWindow();
            navigateWindow.Show();
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
                EmployeeChangeWindow employeeChangeWindow = new EmployeeChangeWindow();
                employeeChangeWindow.Show();
                this.Close();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (LvEmployeeList.SelectedItem is Employee)
            {
                var employee = LvEmployeeList.SelectedItem as Employee;
                EmployeeChangeWindow employeeChangeWindowEdit = new EmployeeChangeWindow(employee);
                employeeChangeWindowEdit.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Выберите запись, которую нужно изменить!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
