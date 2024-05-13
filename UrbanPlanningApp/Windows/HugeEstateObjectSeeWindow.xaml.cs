using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using static UrbanPlanningApp.CH.Context;

namespace UrbanPlanningApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для HugeEstateObjectSeeWindow.xaml
    /// </summary>
    public partial class HugeEstateObjectSeeWindow : Window
    {
        public HugeEstateObjectSeeWindow(EstateObject estateObject)
        {
            InitializeComponent();
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
    }
}
