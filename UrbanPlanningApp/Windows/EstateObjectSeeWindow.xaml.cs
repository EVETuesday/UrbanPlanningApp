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
    /// Логика взаимодействия для EstateObjectSeeWindow.xaml
    /// </summary>
    public partial class EstateObjectSeeWindow : Window
    {
        ObservableCollection<EstateObject> estateObjects;
        public EstateObjectSeeWindow()
        {
            InitializeComponent();
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
            switch (ActiveEmployee.IDPost)
            {
                case 1:
                    DefaultManagerWindow defaultManagerWindow = new DefaultManagerWindow();
                    defaultManagerWindow.Show();
                    Close();
                    break;
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

        private void btnSeeEstate(object sender, RoutedEventArgs e)
        {
            EstateObject estateObject = (EstateObject)(sender as Button).DataContext;
            HugeEstateObjectSeeWindow hugeEstateObjectSeeWindow = new HugeEstateObjectSeeWindow(estateObject);
            hugeEstateObjectSeeWindow.Show();
            Close();
        }
    }
}
