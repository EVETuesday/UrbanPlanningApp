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
using static UrbanPlanningApp.CH.ClassHelper;
using static UrbanPlanningApp.CH.Context;

namespace UrbanPlanningApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddNewEstateObjectWindow.xaml
    /// </summary>
    public partial class AddNewEstateObjectWindow : Window
    {
        public AddNewEstateObjectWindow()
        {
            InitializeComponent();
            cmbFormat.ItemsSource=Formats;
            cmbFormat.DisplayMemberPath = "FormatTitle";
        }

        private void btnAddPhoto_Click(object sender, RoutedEventArgs e)
        {

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
    }
}
