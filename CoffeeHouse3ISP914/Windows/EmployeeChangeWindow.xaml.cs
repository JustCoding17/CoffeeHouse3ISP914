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
    /// Логика взаимодействия для EmployeeChangeWindow.xaml
    /// </summary>
    public partial class EmployeeChangeWindow : Window
    {
        private bool isEmployeeChange = false;
        private Employee editEmployee;

        public EmployeeChangeWindow()
        {
            InitializeComponent();

            CMBPosition.ItemsSource = Context.Position.ToList();
            CMBPosition.SelectedIndex = 0;
            CMBPosition.DisplayMemberPath = "Title";

            CMBGender.ItemsSource = Context.Gender.ToList();
            CMBGender.SelectedIndex = 0;
            CMBGender.DisplayMemberPath = "Title";
        }

        public EmployeeChangeWindow(Employee employee)
        {
            InitializeComponent();

            TxtTitle.Text = "Изменение сотрудника";
            BtnAdd.Content = "Обновить";

            CMBPosition.ItemsSource = Context.Position.ToList();
            CMBPosition.SelectedIndex = 0;
            CMBPosition.DisplayMemberPath = "Title";

            CMBGender.ItemsSource = Context.Gender.ToList();
            CMBGender.SelectedIndex = 0;
            CMBGender.DisplayMemberPath = "Title";

            TbLastName.Text = employee.LastName.ToString();
            TbFirstName.Text = employee.FirstName.ToString();
            TbPatronymic.Text = employee.Patronymic.ToString();
            CMBPosition.SelectedItem = Context.Position.Where(i => i.IdPosition == employee.IdPosition).FirstOrDefault();
            DPBirthday.Text = employee.DateOfBirth.ToString();
            CMBGender.SelectedItem = Context.Gender.Where(i => i.IdGender == employee.IdGender).FirstOrDefault();
            TbLogin.Text = employee.Login.ToString();
            TbPassword.Text = employee.Password.ToString();

            isEmployeeChange = true;
            editEmployee = employee;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (isEmployeeChange)
            {
                editEmployee.LastName = TbLastName.Text;
                editEmployee.FirstName = TbFirstName.Text;
                editEmployee.Patronymic = TbPatronymic.Text;
                editEmployee.IdPosition = (CMBPosition.SelectedItem as Position).IdPosition;
                editEmployee.DateOfBirth = DPBirthday.SelectedDate.Value;
                editEmployee.IdGender = (CMBGender.SelectedItem as Gender).IdGender;
                editEmployee.Login = TbLogin.Text;
                editEmployee.Password = TbPassword.Text;

                Context.SaveChanges();
                MessageBox.Show("Сотрудник успешно обновлен!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                EmployeeListWindow employeeListWindow = new EmployeeListWindow();
                employeeListWindow.Show();
                this.Close();
            }
            else
            {
                Employee emp = new Employee();
                emp.LastName = TbLastName.Text;
                emp.FirstName = TbFirstName.Text;
                emp.Patronymic = TbPatronymic.Text;
                emp.IdPosition = (CMBPosition.SelectedItem as Position).IdPosition;
                emp.DateOfBirth = DPBirthday.SelectedDate.Value;
                emp.IdGender = (CMBGender.SelectedItem as Gender).IdGender;
                emp.Login = TbLogin.Text;
                emp.Password = TbPassword.Text;

                Context.Employee.Add(emp);
                Context.SaveChanges();
                MessageBox.Show("Сотрудник успешно добавлен!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                EmployeeListWindow employeeListWindow = new EmployeeListWindow();
                employeeListWindow.Show();
                this.Close();

            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            EmployeeListWindow employeeListWindow = new EmployeeListWindow();
            employeeListWindow.Show();
            this.Close();
        }
    }
}
