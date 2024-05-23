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
using static UrbanPlanningApp.CH.Context;

namespace UrbanPlanningApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для SelectEstateToNewEstateObjectWindow.xaml
    /// </summary>
    public partial class SelectEstateToNewEstateObjectWindow : Window
    {
        AddNewEstateObjectWindow addNewEstateObjectWindow2;
        public SelectEstateToNewEstateObjectWindow( AddNewEstateObjectWindow addNewEstateObjectWindow)
        {
            InitializeComponent();
            addNewEstateObjectWindow2 = addNewEstateObjectWindow;
            if ((addNewEstateObjectWindow2.cmbTypeOfActivity.SelectedItem as TypeOfActivity).IDTypeOfActivity==3)
            {
                LvEstateList.ItemsSource = EstateObjects.Where(i => i.IDTypeOfActivity == 2);
            }
            else
            {
                LvEstateList.ItemsSource = EstateObjects.Where(i => i.IDTypeOfActivity == 1);
            }
            
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            addNewEstateObjectWindow2.BackBtn = true;
            Close();

        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Выберете объект, внутри которого находится создаваемый объект недвижимости\nНапример - Квартира внутри дома","",MessageBoxButton.OK,MessageBoxImage.Information);
        }

        private void LvEstateList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EstateObject estateObject = LvEstateList.SelectedItem as EstateObject;
            addNewEstateObjectWindow2.PostEstateObject(estateObject);
            addNewEstateObjectWindow2.BackBtn = false;
            Close();
        }
    }
}
