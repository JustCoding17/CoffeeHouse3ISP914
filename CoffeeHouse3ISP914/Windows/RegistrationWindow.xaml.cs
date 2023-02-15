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
using static CoffeeHouse3ISP914.ClassHelper.EFClass;

namespace CoffeeHouse3ISP914.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
            CmbGender.ItemsSource = Context.Gender.ToList();
            CmbGender.SelectedIndex = 0;
            CmbGender.DisplayMemberPath = "Title";
        }

        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbLastName.Text) ||
                string.IsNullOrWhiteSpace(TbFirstName.Text) ||
                string.IsNullOrWhiteSpace(DpBirthDay.Text) ||
                string.IsNullOrWhiteSpace(TbPhoneNumber.Text) ||
                string.IsNullOrWhiteSpace(TbEmail.Text) ||
                string.IsNullOrWhiteSpace(CmbGender.Text) ||
                string.IsNullOrWhiteSpace(TbLogin.Text) ||
                string.IsNullOrWhiteSpace(PbPassword.Password))
            {
                MessageBox.Show("Все поля должны быть заполнены!", "Ошибка");
                return;
            }

            var authUser = Context.Client.ToList()
                .Where(i => i.Login == TbLogin.Text).FirstOrDefault();
            if (authUser != null)
            {
                MessageBox.Show("Такой логин уже занят", "Ошибка");
                return;
            }

            DB.Client client = new DB.Client();
            client.LastName = TbLastName.Text;
            client.FirstName = TbFirstName.Text;
            client.DateOfBirth = DpBirthDay.SelectedDate.Value;
            client.PhoneNumber = TbPhoneNumber.Text;
            client.Email = TbEmail.Text;
            client.IdGender = (CmbGender.SelectedItem as DB.Gender).IdGender;
            client.Login = TbLogin.Text;
            client.Password = PbPassword.Password;
            client.BonusCard = 0;

            Context.Client.Add(client);
            Context.SaveChanges();

            PrivateOfficeWindow privateOfficeWindow = new PrivateOfficeWindow();
            privateOfficeWindow.Show();
            this.Close();
        }

        private void TbSignIn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AutorizationWindow autorizationWindow = new AutorizationWindow();
            autorizationWindow.Show();
            this.Close();
        }
    }
}
