using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для LittleAddPhotoWindow.xaml
    /// </summary>
    public partial class LittleAddPhotoWindow : Window
    {
        HugeEstateObjectSeeWindow hugeEstateObjectSeeWindow2;
        EstateObject estateObject2;
        public LittleAddPhotoWindow(EstateObject estateObject, HugeEstateObjectSeeWindow hugeEstateObjectSeeWindow)
        {
            InitializeComponent();
            hugeEstateObjectSeeWindow2 = hugeEstateObjectSeeWindow;
            estateObject2 = estateObject;
        }

        private void btnAddPhoto_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                imgPhoto.Source = new BitmapImage(new Uri(tbUri.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Изоображение имеет неверный формат", "", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            
            EstatePhoto estatePhoto = new EstatePhoto() { IDEmployee = ActiveEmployee.IDEmployee, IDEstateObject = estateObject2.IDEstateObject, PhotoPath = tbUri.Text, Employee = ActiveEmployee, EstateObject = estateObject2 };
            using (HttpClient httpClient = new HttpClient())
            {
                var sourse = new Uri(APP_PATH+ "/api/EstatePhoto/AddNewEstatePhoto");
                string body = JsonConvert.SerializeObject(estatePhoto);
                var payload = new StringContent(body, Encoding.UTF8, "application/json");
                var result = httpClient.PostAsync(sourse, payload).Result.Content.ReadAsStringAsync().Result;
            }
            GetData();
            hugeEstateObjectSeeWindow2.LvEstatePhotoList.ItemsSource = EstatePhotos.Where(i=>i.IDEstateObject== estateObject2.IDEstateObject);
            Close();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnTryPhoto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                imgPhoto.Source = new BitmapImage(new Uri(tbUri.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Изоображение имеет неверный формат", "",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            
        }
    }
}
