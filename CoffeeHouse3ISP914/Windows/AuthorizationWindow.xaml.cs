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
using static CoffeeHouse3ISP914.ClassHelper.EFClass;

namespace CoffeeHouse3ISP914.Windows
{
    /// <summary>
    /// Логика взаимодействия для AutorizationWindow.xaml
    /// </summary>
    public partial class AutorizationWindow : Window
    {
        public AutorizationWindow()
        {
            InitializeComponent();
        }

        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            var authEmployee = Context.Employee.ToList()
                .Where(i => i.Login == TbLogin.Text && i.Password == PbPassword.Password).FirstOrDefault();
            if (authEmployee != null)
            {
                ClassHelper.EmployeeDataClass.Employee = authEmployee;
                NavigateWindow navigateWindow = new NavigateWindow();
                navigateWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Такой пользователь не найден", "Ошибка");
            }
            
        }

        private void TbReg_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            RegistrationWindow registrationWindow =  new RegistrationWindow();
            registrationWindow.Show();
            this.Close();
        }
    }
}
