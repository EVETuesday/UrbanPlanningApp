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
using UrbanPlanningApp.DataBasesClasses;
using static UrbanPlanningApp.CH.ClassHelper;

namespace UrbanPlanningApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для LittleAddPhotoToNewEstateWindow.xaml
    /// </summary>
    public partial class LittleAddPhotoToNewEstateWindow : Window
    {
        AddNewEstateObjectWindow addNewEstateObjectWindow2;
        public LittleAddPhotoToNewEstateWindow(AddNewEstateObjectWindow addNewEstateObjectWindow)
        {
            InitializeComponent();
            addNewEstateObjectWindow2 = addNewEstateObjectWindow;
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
                MessageBox.Show("Изоображение имеет неверный формат", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
            List<EstatePhoto> estatePhotos = addNewEstateObjectWindow2.LvEstatePhotoList.Items.Cast<EstatePhoto>().ToList();
            estatePhotos.Add(new EstatePhoto() {IDEmployee =ActiveEmployee.IDEmployee, Employee=ActiveEmployee, PhotoPath = tbUri.Text});
            addNewEstateObjectWindow2.LvEstatePhotoList.ItemsSource= estatePhotos;
            Close();
        }
    }
}
