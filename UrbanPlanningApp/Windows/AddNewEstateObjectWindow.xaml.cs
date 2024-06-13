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
    /// Логика взаимодействия для AddNewEstateObjectWindow.xaml
    /// </summary>
    public partial class AddNewEstateObjectWindow : Window
    {
        public EstateObject addedEstateObject = new EstateObject();
        public bool BackBtn = false;
        public AddNewEstateObjectWindow()
        {
            InitializeComponent();
            if(ActiveEmployee.IDPost==2)
            {
                tbHeaderUser.Text = "Добавить земельный участок";
                lblTypeOfActivity.Visibility = Visibility.Hidden;
                cmbTypeOfActivity.Visibility = Visibility.Hidden;
                brdrTypeOfActivity.Visibility = Visibility.Hidden;
            }
            else {
                tbHeaderUser.Text = "Добавить объект недвижимости";
                
            }
            cmbFormat.ItemsSource = Formats;
            cmbFormat.DisplayMemberPath = "FormatTitle";
            cmbFormat.SelectedIndex = 0;

            cmbTypeOfActivity.ItemsSource = new List<TypeOfActivity>() { TypeOfActivities[1], TypeOfActivities[2] };
            cmbTypeOfActivity.DisplayMemberPath = "Title";
            cmbTypeOfActivity.SelectedIndex = 0;

            cmbPostIndex.ItemsSource = Postindices;
            cmbPostIndex.DisplayMemberPath = "Postindex1";
            cmbPostIndex.SelectedIndex = 0;
        }

        private void btnAddPhoto_Click(object sender, RoutedEventArgs e)
        {
            LittleAddPhotoToNewEstateWindow littleAddPhotoToNewEstateWindow = new LittleAddPhotoToNewEstateWindow(this);
            littleAddPhotoToNewEstateWindow.ShowDialog();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            switch(ActiveEmployee.IDPost)
            {
                case 2:
                    DefaultEngineerWindow defaultEngineerWindow = new DefaultEngineerWindow();
                    defaultEngineerWindow.Show();
                    Close();
                    break;
                case 3:
                    DefaultArchitectWindow defaultArchitectWindow = new DefaultArchitectWindow();
                    defaultArchitectWindow.Show();
                    Close();
                    break;

            }
        }

        private void btnAddEstateObject_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbPrice.Text)|| string.IsNullOrEmpty(tbSquare.Text) || string.IsNullOrEmpty(dpDateOfApplication.Text) || string.IsNullOrEmpty(dpDateOfDefinition.Text) || string.IsNullOrEmpty(tbNumber.Text) || string.IsNullOrEmpty(tbAddress.Text))
            {
                MessageBox.Show("Все поля должны быть заполненными");
                return;
            }
            try
            {
                addedEstateObject.DateOfDefinition = Convert.ToDateTime(dpDateOfDefinition.Text);
                addedEstateObject.DateOfApplication = Convert.ToDateTime(dpDateOfApplication.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Неверный формат даты");
                return;
            }

            if (Convert.ToDateTime(dpDateOfDefinition.Text)>Convert.ToDateTime(dpDateOfApplication.Text))
            {
                MessageBox.Show("Дата ввода в эксплуатацию должна быть больше чем дата утверждения проекта");
                return;
            }

            try
            {
                addedEstateObject.Price = Convert.ToDecimal(tbPrice.Text);
                addedEstateObject.Square = Convert.ToDecimal(tbSquare.Text);
                addedEstateObject.Number = Convert.ToInt32(tbNumber.Text);
                addedEstateObject.Adress = Convert.ToString(tbAddress.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Неверный формат данных");
                return;
            }
            if (addedEstateObject.Square.ToString().Length>15)
            {
                MessageBox.Show("Неверный формат данных в строке - Площадь");
                return;
            }
            if (addedEstateObject.Price.ToString().Length > 13)
            {
                MessageBox.Show("Неверный формат данных в строке - Цена");
                return;
            }
            if (addedEstateObject.Adress.ToString().Length > 50)
            {
                MessageBox.Show("Неверный формат данных в строке - Адрес");
                return;
            }
            if (addedEstateObject.Number.ToString().Length > 10)
            {
                MessageBox.Show("Неверный формат данных в строке - Номер");
                return;
            }

            addedEstateObject.IDPostIndex = (cmbPostIndex.SelectedItem as Postindex).IDPostindex;
            addedEstateObject.IDFormat = (cmbFormat.SelectedItem as Format).IDFormat;
            addedEstateObject.Postindex=Postindices.Where(i=>i.IDPostindex==addedEstateObject.IDPostIndex).FirstOrDefault();
            
            addedEstateObject.Format = Formats.Where(i=>i.IDFormat==addedEstateObject.IDFormat).FirstOrDefault();
            if (ActiveEmployee.IDPost==2)
            {
                addedEstateObject.IDTypeOfActivity = TypeOfActivities[0].IDTypeOfActivity;
            }
            else
            {
                addedEstateObject.IDTypeOfActivity = (cmbTypeOfActivity.SelectedItem as TypeOfActivity).IDTypeOfActivity;
            }
            addedEstateObject.TypeOfActivity = TypeOfActivities.Where(i => i.IDTypeOfActivity == addedEstateObject.IDTypeOfActivity).FirstOrDefault();
            if (ActiveEmployee.IDPost !=2)
            {
                SelectEstateToNewEstateObjectWindow selectEstateToNewEstateObjectWindow = new SelectEstateToNewEstateObjectWindow(this);
                selectEstateToNewEstateObjectWindow.ShowDialog();
            }
            else
            {
                PostEstateObject();
            }
            if (!BackBtn)
            {
                MessageBox.Show("Объект недвижимости успешно добавлен");
                if (ActiveEmployee.IDPost == 2)
                {
                    DefaultEngineerWindow defaultEngineerWindow = new DefaultEngineerWindow();
                    defaultEngineerWindow.Show();
                }
                else
                {
                    DefaultArchitectWindow defaultArchitectWindow = new DefaultArchitectWindow();
                    defaultArchitectWindow.Show();
                }
                Close();
            }
            
        }
        public void PostEstateObject()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var sourse = new Uri(APP_PATH + "/api/EstateObject/AddNewEstateObject");
                string body = JsonConvert.SerializeObject(addedEstateObject);
                var payload = new StringContent(body, Encoding.UTF8, "application/json");
                var result = httpClient.PostAsync(sourse, payload).Result.Content.ReadAsStringAsync().Result;
            }
            GetData();
            PostNewPhotos();
        }
        public void PostEstateObject(EstateObject estateObject)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var sourse = new Uri(APP_PATH + "/api/EstateObject/AddNewEstateObject");
                string body = JsonConvert.SerializeObject(addedEstateObject);
                var payload = new StringContent(body, Encoding.UTF8, "application/json");
                var result = httpClient.PostAsync(sourse, payload).Result.Content.ReadAsStringAsync().Result;
            }
            GetData();
            if (estateObject.IDTypeOfActivity == 2)
            {
                FlatRelation flatRelation = new FlatRelation() { IDBuildEstate = estateObject.IDEstateObject };
                flatRelation.IDFlatEstate = EstateObjects.LastOrDefault().IDEstateObject;
                flatRelation.EstateObject = EstateObjects.Where(i=>i.IDEstateObject==flatRelation.IDBuildEstate).FirstOrDefault();
                flatRelation.EstateObject1 = EstateObjects.Where(i=>i.IDEstateObject==flatRelation.IDFlatEstate).FirstOrDefault();
                using (HttpClient httpClient = new HttpClient())
                {
                    var sourse = new Uri(APP_PATH + "/api/FlatRelation/AddNewFlatRelations");
                    string body = JsonConvert.SerializeObject(flatRelation);
                    var payload = new StringContent(body, Encoding.UTF8, "application/json");
                    var result = httpClient.PostAsync(sourse, payload).Result.Content.ReadAsStringAsync().Result;
                }
            }
            else
            {
                EstateRelation estateRelation = new EstateRelation() { IDPlaceEstate = estateObject.IDEstateObject };
                estateRelation.IDBuildingEstate = EstateObjects.LastOrDefault().IDEstateObject;
                estateRelation.EstateObject = EstateObjects.Where(i => i.IDEstateObject == estateRelation.IDPlaceEstate).FirstOrDefault();
                estateRelation.EstateObject1 = EstateObjects.Where(i => i.IDEstateObject == estateRelation.IDBuildingEstate).FirstOrDefault();
                using (HttpClient httpClient = new HttpClient())
                {
                    var sourse = new Uri(APP_PATH + "/api/EstateRelation/AddNewEstateRelations");
                    string body = JsonConvert.SerializeObject(estateRelation);
                    var payload = new StringContent(body, Encoding.UTF8, "application/json");
                    var result = httpClient.PostAsync(sourse, payload).Result.Content.ReadAsStringAsync().Result;
                }
            }
            GetData();
            PostNewPhotos();
        }
        public void PostNewPhotos()
        {
            if (LvEstatePhotoList.Items.Count<1)
            {
                return;
            }
            List<EstatePhoto> estatePhotos = LvEstatePhotoList.Items.Cast<EstatePhoto>().ToList();
            foreach (var estatePhoto in estatePhotos)
            {
                estatePhoto.IDEmployee=ActiveEmployee.IDEmployee;
                estatePhoto.IDEstateObject=EstateObjects.LastOrDefault().IDEstateObject;
                estatePhoto.EstateObject = EstateObjects.LastOrDefault();
                estatePhoto.Employee = ActiveEmployee;
                using (HttpClient httpClient = new HttpClient())
                {
                    var sourse = new Uri(APP_PATH + "/api/EstatePhoto/AddNewEstatePhoto");
                    string body = JsonConvert.SerializeObject(estatePhoto);
                    var payload = new StringContent(body, Encoding.UTF8, "application/json");
                    var result = httpClient.PostAsync(sourse, payload).Result.Content.ReadAsStringAsync().Result;
                }
            }            
            GetData();
        }
    }
}
