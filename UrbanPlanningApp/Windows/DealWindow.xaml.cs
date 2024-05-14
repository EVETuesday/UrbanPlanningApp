using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using UrbanPlanningApp.DataBasesClasses;
using static UrbanPlanningApp.CH.ClassHelper;
using static UrbanPlanningApp.CH.Context;

namespace UrbanPlanningApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для DealWindow.xaml
    /// </summary>
    public partial class DealWindow : Window
    {
        public DealWindow()
        {
            InitializeComponent();
            if (DealSelectedEstateObject.OwnerClient==null)
            {
                tbDealInfo.Text = $"Переход права собственности от \"UrbanPlanningCompany\" к \"{DealSelectedClient.FullName}\". ";
            }
            else
            {
                tbDealInfo.Text = $"Переход права собственности от \"{DealSelectedEstateObject.OwnerClient.FullName}\" к \"{DealSelectedClient.FullName}\". ";
            }
            
            LvEstateList.ItemsSource=new List<EstateObject>() { DealSelectedEstateObject };
            LvClientList.ItemsSource = new List<Client>() {DealSelectedClient};
            tbPrice.Text=DealSelectedEstateObject.Price.ToString();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            DealClientSeeWindow dealClientSeeWindow = new DealClientSeeWindow();
            dealClientSeeWindow.Show();
            Close();
        }

        private void btnAddCheck_Click(object sender, RoutedEventArgs e)
        {
            Check check = new Check();
            check.FullCost=Convert.ToDecimal(tbPrice.Text);
            check.DateOfTheSale = DateTime.Now;
            check.IDClient = DealSelectedClient.IDClient;
            check.Client = DealSelectedClient;
            check.IDEmployee = ActiveEmployee.IDEmployee;
            check.Employee = ActiveEmployee;
            check.IDEstateObject=DealSelectedEstateObject.IDEstateObject;
            check.EstateObject= DealSelectedEstateObject;

            using (HttpClient httpClient = new HttpClient())
            {
                var sourse = new Uri(APP_PATH + "/api/Check/AddNewCheck");
                string body = JsonConvert.SerializeObject(check);
                var payload = new StringContent(body, Encoding.UTF8, "application/json");
                var result = httpClient.PostAsync(sourse, payload).Result.Content.ReadAsStringAsync().Result;
            }
            GetData();
            MessageBox.Show("Переход собственности успешно произведён");
            DefaultManagerWindow defaultManagerWindow = new DefaultManagerWindow();
            defaultManagerWindow.Show();
            Close();
        }
    }
}
