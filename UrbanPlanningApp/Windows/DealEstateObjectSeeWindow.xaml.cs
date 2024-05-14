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
    /// Логика взаимодействия для DealEstateObjectSeeWindow.xaml
    /// </summary>
    public partial class DealEstateObjectSeeWindow : Window
    {
        ObservableCollection<EstateObject> estateObjects;
        public DealEstateObjectSeeWindow()
        {
            InitializeComponent();
            GetData();
            estateObjects = new ObservableCollection<EstateObject>(EstateObjects);
            SetLv();
        }
        void SetLv()
        {
            LvEstateList.ItemsSource = estateObjects;
        }
        void SetLv(string searchWord)
        {
            if (string.IsNullOrEmpty(searchWord))
            {
                estateObjects = EstateObjects;
            }
            else
            {
                estateObjects = new ObservableCollection<EstateObject>(estateObjects.Where(i => i.IDEstateObject.ToString().Contains(tbSearch.Text) || i.Adress.ToString().ToLower().Contains(tbSearch.Text.ToLower())));
            }
            SetLv();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            DefaultManagerWindow defaultManagerWindow = new DefaultManagerWindow();
            defaultManagerWindow.Show();
            Close();
        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                switch (cmbSort.SelectedIndex)
                {
                    case 0:
                        estateObjects = new ObservableCollection<EstateObject>(estateObjects.OrderBy(i => i.IDEstateObject));
                        break;
                    case 1:
                        estateObjects = new ObservableCollection<EstateObject>(estateObjects.OrderBy(i => i.Price));
                        break;
                    case 2:
                        estateObjects = new ObservableCollection<EstateObject>(estateObjects.OrderBy(i => i.Square));
                        break;
                    case 3:
                        estateObjects = new ObservableCollection<EstateObject>(estateObjects.OrderBy(i => i.Adress));
                        break;
                }
                SetLv();
            }
            catch
            {
                return;
            }
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetLv(tbSearch.Text);
        }

        private void btnAddEstateObject_Click(object sender, RoutedEventArgs e)
        {
            if (LvEstateList.SelectedItem==null)
            {
                MessageBox.Show("Выберете объект недвижимости");
                return;
            }
            DealSelectedEstateObject = LvEstateList.SelectedItem as EstateObject;
            DealSelectedEstateObject.OwnerClient = (from Check c in Checks join Client cl in Clients on c.IDClient equals cl.IDClient join EstateObject eo in EstateObjects on c.IDEstateObject equals eo.IDEstateObject where eo.IDEstateObject == DealSelectedEstateObject.IDEstateObject select cl).LastOrDefault();
            DealClientSeeWindow dealClientSeeWindow = new DealClientSeeWindow();
            dealClientSeeWindow.Show();
            Close();
        }
    }
}
