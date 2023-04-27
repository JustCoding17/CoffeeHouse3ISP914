using CoffeeHouse3ISP914.ClassHelper;
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
    /// Логика взаимодействия для ReportSaleWindow.xaml
    /// </summary>
    public partial class ReportSaleWindow : Window
    {
        List<VW_InfoSale> sale = new List<VW_InfoSale>();
        List<string> sortList = new List<string>()
        {
            "По возрастанию",
            "По убыванию"
        };
        public ReportSaleWindow()
        {
            InitializeComponent();
            TxtData.Text = EmployeeDataClass.Employee.LastName + " " + EmployeeDataClass.Employee.FirstName + " / " + EmployeeDataClass.Employee.Position.Title;
            CmbSort.ItemsSource = sortList;
            CmbSort.SelectedIndex = 0;
            GetSaleList();
        }

        private void GetSaleList()
        {
            sale = Context.VW_InfoSale.ToList();
            //sale = sale.Where(i => i.Date.ToString().Contains(TxbSearchBegin.Text)  i.Date.ToString().Contains(TxbSearchEnd.Text)).ToList();
            switch (CmbSort.SelectedIndex)
            {
                case 0:
                    sale = sale.OrderBy(i => i.Date).ToList();
                    break;
                case 1:
                    sale = sale.OrderByDescending(i => i.Date).ToList();
                    break;
                default:
                    break;
            }
            Dg.ItemsSource = sale;
        }

        void GetDate(DatePicker dateBegin, DatePicker dateEnd)
        {
            Dg.ItemsSource = Context.VW_InfoSale.ToList().Where(i => i.Date >= dateBegin.SelectedDate && i.Date <= dateEnd.SelectedDate);
        }

        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetSaleList();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DPBegin.SelectedDate.Value != null && DPEnd.SelectedDate.Value != null)
                {
                    if (DPEnd.SelectedDate.Value < DPBegin.SelectedDate.Value)
                    {
                        DatePicker datePicker = new DatePicker();
                        datePicker.SelectedDate = DPEnd.SelectedDate;
                        DPEnd.SelectedDate = DPEnd.SelectedDate;
                        DPBegin.SelectedDate = datePicker.SelectedDate;
                    }

                    GetDate(DPBegin, DPEnd);
                }
            }
            catch (Exception)
            {
                GetSaleList();
            }
            
           
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
