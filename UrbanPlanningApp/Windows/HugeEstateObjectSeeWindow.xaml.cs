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
    /// Логика взаимодействия для HugeEstateObjectSeeWindow.xaml
    /// </summary>
    public partial class HugeEstateObjectSeeWindow : Window
    {
        EstateObject estateObject2;
        public HugeEstateObjectSeeWindow(EstateObject estateObject)
        {
            InitializeComponent();
            estateObject2 = estateObject;
            lblHeader.Content = "Объект: " + estateObject.IDEstateObject;
            LvEstateList.ItemsSource=new List<EstateObject>() { estateObject };
            ObservableCollection<EstatePhoto> estatePhotoslv = new ObservableCollection<EstatePhoto>();
            estatePhotoslv = new ObservableCollection<EstatePhoto> (EstatePhotos.Where(e => e.IDEstateObject==estateObject.IDEstateObject));
            if (estateObject.OwnerClient==null)
            {
                estateObject.OwnerClient = new Client();
            }
            LvEstatePhotoList.ItemsSource = estatePhotoslv;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            EstateObjectSeeWindow estateObjectSeeWindow = new EstateObjectSeeWindow();
            estateObjectSeeWindow.Show();
            Close();
        }

        private void btnAddPhoto_Click(object sender, RoutedEventArgs e)
        {
            LittleAddPhotoWindow littleAddPhotoWindow = new LittleAddPhotoWindow(estateObject2,this);
            littleAddPhotoWindow.ShowDialog();
        }

        private void btnDeletePhoto_Click(object sender, RoutedEventArgs e)
        {
            EstatePhoto estatePhoto = (EstatePhoto)(sender as Button).DataContext;
            using (HttpClient httpClient = new HttpClient())
            {
                var sourse = new Uri(APP_PATH+ "/api/EstatePhoto/DeleteEstatePhoto");
                string body = JsonConvert.SerializeObject(estatePhoto);
                var payload = new StringContent(body, Encoding.UTF8, "application/json");
                var result = httpClient.PostAsync(sourse, payload).Result.Content.ReadAsStringAsync().Result;
            }
            GetData();
            LvEstatePhotoList.ItemsSource = EstatePhotos.Where(i => i.IDEstateObject == estateObject2.IDEstateObject);
        }
    }
}
